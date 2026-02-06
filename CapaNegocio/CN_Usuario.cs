using CapaComun;
using CapaDatos.DAO;
using CapaEntidad.Clases;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace CapaNegocio
{
    public class CN_Usuario
    {
        private CD_UsuarioDAO usuarioDAO = new CD_UsuarioDAO();

        public bool Login(string usuario, string contrasena)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(usuario))
                    throw new ArgumentException("El usuario es obligatorio");

                if (string.IsNullOrWhiteSpace(contrasena))
                    throw new ArgumentException("La contraseña es obligatoria");

                Usuario_Entidad usuarioLogin = usuarioDAO.Login(usuario, contrasena);

                if (usuarioLogin != null)
                {
                    //Actualiza caché con datos de usuario logueado
                    UsuarioLoginCache.idUsuario = usuarioLogin.IdUsuario;
                    UsuarioLoginCache.nombreUsuario = usuarioLogin.NombreUsuario;
                    UsuarioLoginCache.idRol = usuarioLogin.IdRol;
                    UsuarioLoginCache.rol = usuarioLogin.NombreRol;
                    return true;
                }

                return false;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al iniciar sesión: " + ex.Message, ex);
            }
        }

        //Listar usuarios con filtros opcionales
        public List<Usuario_Entidad> ListarUsuarios(string filtroUsuario = null, string filtroNombreUsuario = null,
                                                    string filtroEstado = null, string filtroRol = null)
        {
            try
            {
                return usuarioDAO.ListarUsuarios(filtroUsuario, filtroNombreUsuario, filtroEstado, filtroRol);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al listar usuarios: " + ex.Message, ex);
            }
        }

        // Obtener usuario por ID
        public Usuario_Entidad ObtenerUsuarioPorId(int idUsuario)
        {
            try
            {
                if (idUsuario <= 0)
                    throw new ArgumentException("ID de usuario inválido");

                Usuario_Entidad usuario = usuarioDAO.ObtenerUsuarioPorId(idUsuario);

                if (usuario == null)
                    throw new Exception($"No se encontró el usuario con ID: {idUsuario}");

                return usuario;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener usuario: " + ex.Message, ex);
            }
        }

        public bool CrearUsuario(Usuario_Entidad usuario)
        {
            try
            {
                ValidarDatosUsuario(usuario);

                // Validar que no exista el usuario
                if (usuarioDAO.ExisteUsuario(usuario.Usuario))
                {
                    throw new Exception($"Ya existe un usuario con el nombre '{usuario.Usuario}'");
                }

                // Validar longitud de contraseña
                if (usuario.Contrasena.Length < 4)
                {
                    throw new ArgumentException("La contraseña debe tener al menos 4 caracteres");
                }

                return usuarioDAO.CrearUsuario(usuario);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al crear usuario: " + ex.Message, ex);
            }
        }

        // Método sobrecargado para compatibilidad
        public bool CrearUsuario(string usuario, string contrasena, string nombreUsuario)
        {
            Usuario_Entidad nuevoUsuario = new Usuario_Entidad
            {
                Usuario = usuario,
                Contrasena = contrasena,
                NombreUsuario = nombreUsuario,
                IdRol = 2, // Usuario normal por defecto
                IdEstado = 1 // Activo por defecto
            };

            return CrearUsuario(nuevoUsuario);
        }

        public bool ActualizarUsuario(Usuario_Entidad usuario)
        {
            try
            {
                if (usuario.IdUsuario <= 0)
                    throw new ArgumentException("ID de usuario inválido");

                //Utilizar validaciones de negocio
                ValidarDatosUsuario(usuario);

                //Validar que no se esté cambiando a un usuario que ya existe
                List<Usuario_Entidad> usuarios = usuarioDAO.ListarUsuarios(filtroUsuario: usuario.Usuario);
                foreach (var u in usuarios)
                {
                    if (u.IdUsuario != usuario.IdUsuario)
                    {
                        throw new Exception($"Ya existe otro usuario con el nombre '{usuario.Usuario}'");
                    }
                }

                //Validar longitud de contraseña si se cambió
                if (!string.IsNullOrWhiteSpace(usuario.Contrasena) && usuario.Contrasena.Length < 4)
                {
                    throw new ArgumentException("La contraseña debe tener al menos 4 caracteres");
                }

                //Validar que no se pueda desactivar al último administrador
                if (usuario.IdRol == 1 && usuario.IdEstado == 2) // Si es admin y se está desactivando
                {
                    int cantidadAdminsActivos = ContarAdministradoresActivos();
                    if (cantidadAdminsActivos <= 1)
                    {
                        throw new Exception("No se puede desactivar a usted mismo.");
                    }
                }

                return usuarioDAO.ActualizarUsuario(usuario);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al actualizar usuario: " + ex.Message, ex);
            }
        }
        /*
        public bool CambiarEstadoUsuario(int idUsuario, int nuevoEstado)
        {
            try
            {
                if (idUsuario <= 0)
                    throw new ArgumentException("ID de usuario inválido");

                if (nuevoEstado != 1 && nuevoEstado != 2)
                    throw new ArgumentException("Estado inválido (debe ser 1=Activo o 2=Inactivo)");

                //Obtener el usuario
                Usuario_Entidad usuario = usuarioDAO.ObtenerUsuarioPorId(idUsuario);

                // Validar que no se desactive al último administrador
                if (usuario.EsAdministrador && nuevoEstado == 2)
                {
                    int cantidadAdminsActivos = ContarAdministradoresActivos();
                    if (cantidadAdminsActivos <= 1)
                    {
                        throw new Exception("No se puede desactivar al último administrador del sistema");
                    }
                }

                // Validar que no se desactive al usuario actual
                if (idUsuario == UsuarioLoginCache.idUsuario)
                {
                    throw new Exception("No puedes desactivar tu propia cuenta");
                }

                return usuarioDAO.CambiarEstadoUsuario(idUsuario, nuevoEstado);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al cambiar estado: " + ex.Message, ex);
            }
        }*/

        // Verificar si existe un usuario
        public bool ExisteUsuario(string usuario)
        {
            try
            {
                return usuarioDAO.ExisteUsuario(usuario);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al verificar usuario: " + ex.Message, ex);
            }
        }

        //Método privado para validar datos de usuario antes de crear o actualizar
        private void ValidarDatosUsuario(Usuario_Entidad usuario)
        {
            if (string.IsNullOrWhiteSpace(usuario.Usuario))
                throw new ArgumentException("El usuario es obligatorio");

            if (string.IsNullOrWhiteSpace(usuario.NombreUsuario))
                throw new ArgumentException("El nombre completo es obligatorio");

            if (usuario.Usuario.Length > 50)
                throw new ArgumentException("El usuario no puede exceder 50 caracteres");

            if (usuario.NombreUsuario.Length > 50)
                throw new ArgumentException("El nombre no puede exceder 50 caracteres");

            if (usuario.IdRol <= 0)
                throw new ArgumentException("Debe seleccionar un rol válido");

            if (usuario.IdEstado <= 0)
                throw new ArgumentException("Debe seleccionar un estado válido");
        }

        private int ContarAdministradoresActivos()
        {
            List<Usuario_Entidad> usuarios = usuarioDAO.ListarUsuarios(filtroRol: "Administrador", filtroEstado: "Activo");
            return usuarios.Count;
        }

        // Listar solo usuarios activos
        public List<Usuario_Entidad> ListarUsuariosActivos()
        {
            return usuarioDAO.ListarUsuarios(filtroEstado: "Activo");
        }

        // Listar solo administradores
        public List<Usuario_Entidad> ListarAdministradores()
        {
            return usuarioDAO.ListarUsuarios(filtroRol: "Administrador");
        }

        // Buscar usuarios por nombre
        public List<Usuario_Entidad> BuscarPorNombre(string nombre)
        {
            if (string.IsNullOrWhiteSpace(nombre))
                return ListarUsuarios();

            return usuarioDAO.ListarUsuarios(filtroNombreUsuario: nombre);
        }

        // Contar total de usuarios
        public int ContarUsuarios()
        {
            return usuarioDAO.ListarUsuarios().Count;
        }

        // Contar usuarios por estado
        public int ContarUsuariosPorEstado(string estado)
        {
            return usuarioDAO.ListarUsuarios(filtroEstado: estado).Count;
        }
    }
}