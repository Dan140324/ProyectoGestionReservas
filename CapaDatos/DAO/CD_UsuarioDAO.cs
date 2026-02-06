using CapaComun;
using CapaDatos.SQL;
using CapaEntidad.Clases;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos.DAO
{
    public class CD_UsuarioDAO
    {
        private CD_ManagementSQL obj_sql = new CD_ManagementSQL();

        //Login retornará usuario que acaba de iniciar sesión
        public Usuario_Entidad Login(string usuario, string contrasena)
        {
            Usuario_Entidad usuarioLogin = null;

            try
            {
                List<CD_SP_Parametros> lista_parametros = new List<CD_SP_Parametros>();
                lista_parametros.Add(new CD_SP_Parametros("@usuario", SqlDbType.VarChar, usuario));
                lista_parametros.Add(new CD_SP_Parametros("@contrasena", SqlDbType.VarChar, contrasena));

                DataTable dtResultado = obj_sql.EjecutarSP_Query("sp_login", lista_parametros);

                if (dtResultado != null && dtResultado.Rows.Count > 0)
                {
                    DataRow fila = dtResultado.Rows[0];

                    usuarioLogin = new Usuario_Entidad
                    {
                        IdUsuario = Convert.ToInt32(fila["idUsuario"]),
                        NombreUsuario = fila["nombreUsuario"].ToString(),
                        Usuario = usuario,
                        IdRol = Convert.ToInt32(fila["idRol"]),
                        NombreRol = fila["rol"].ToString()
                    };
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al realizar login: " + ex.Message, ex);
            }

            return usuarioLogin;
        }

        //Listar usuarios mediante filtros
        public List<Usuario_Entidad> ListarUsuarios(string filtroUsuario = null, string filtroNombreUsuario = null, 
                                                    string filtroEstado = null, string filtroRol = null)
        {
            List<Usuario_Entidad> listaUsuarios = new List<Usuario_Entidad>();

            try
            {
                List<CD_SP_Parametros> lista_parametros = new List<CD_SP_Parametros>();
                lista_parametros.Add(new CD_SP_Parametros("@filtroUsuario", SqlDbType.VarChar, (object)filtroUsuario ?? DBNull.Value));
                lista_parametros.Add(new CD_SP_Parametros("@filtroNombreUsuario", SqlDbType.VarChar, (object)filtroNombreUsuario ?? DBNull.Value));
                lista_parametros.Add(new CD_SP_Parametros("@filtroEstado", SqlDbType.VarChar, (object)filtroEstado ?? DBNull.Value));
                lista_parametros.Add(new CD_SP_Parametros("@filtroRol", SqlDbType.VarChar, (object)filtroRol ?? DBNull.Value));

                DataTable dt = obj_sql.EjecutarSP_Query("sp_ListarUsuarios", lista_parametros);

                //Asignar usuarios en memoria
                foreach (DataRow row in dt.Rows)
                {
                    Usuario_Entidad usuario = new Usuario_Entidad
                    {
                        IdUsuario = Convert.ToInt32(row["idUsuario"]),
                        Usuario = row["usuario"].ToString(),
                        NombreUsuario = row["nombreUsuario"].ToString(),
                        IdRol = Convert.ToInt32(row["idRol"]),
                        NombreRol = row["Rol"].ToString(),
                        IdEstado = Convert.ToInt32(row["idEstado"]),
                        NombreEstado = row["Estado"].ToString()
                    };
                    listaUsuarios.Add(usuario);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al listar usuarios: " + ex.Message, ex);
            }

            return listaUsuarios;
        }

        public Usuario_Entidad ObtenerUsuarioPorId(int idUsuario)
        {
            Usuario_Entidad usuario = null;
            try
            {
                List<CD_SP_Parametros> lista_parametros = new List<CD_SP_Parametros>();
                lista_parametros.Add(new CD_SP_Parametros("@idUsuario", SqlDbType.Int, idUsuario));
                DataTable dt = obj_sql.EjecutarSP_Query("sp_ObtenerUsuarioPorId", lista_parametros);
                if (dt.Rows.Count > 0)
                {
                    DataRow row = dt.Rows[0];
                    usuario = new Usuario_Entidad
                    {
                        IdUsuario = Convert.ToInt32(row["idUsuario"]),
                        Usuario = row["usuario"].ToString(),
                        NombreUsuario = row["nombreUsuario"].ToString(),
                        Contrasena = row["contrasena"].ToString(),
                        IdRol = Convert.ToInt32(row["idRol"]),
                        NombreRol = row["Rol"].ToString(),
                        IdEstado = Convert.ToInt32(row["idEstado"]),
                        NombreEstado = row["Estado"].ToString()
                    };
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener usuario: " + ex.Message, ex);
            }
            return usuario;
        }

        public bool CrearUsuario(Usuario_Entidad usuario)
        {
            try
            {
                List<CD_SP_Parametros> lista_parametros = new List<CD_SP_Parametros>();
                lista_parametros.Add(new CD_SP_Parametros("@usuario", SqlDbType.VarChar, usuario.Usuario));
                lista_parametros.Add(new CD_SP_Parametros("@contrasena", SqlDbType.VarChar, usuario.Contrasena));
                lista_parametros.Add(new CD_SP_Parametros("@nombreUsuario", SqlDbType.VarChar, usuario.NombreUsuario));
                return obj_sql.EjecutarSP_NonQuery("sp_CrearUsuario", lista_parametros);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al crear usuario: " + ex.Message, ex);
            }
        }

        public bool CrearUsuario(string usuario, string contrasena, string nombreUsuario)
        {
            return CrearUsuario(new Usuario_Entidad(usuario, contrasena, nombreUsuario, 2, 1));
        }

        public bool ActualizarUsuario(Usuario_Entidad usuario)
        {
            try
            {
                List<CD_SP_Parametros> lista_parametros = new List<CD_SP_Parametros>();
                lista_parametros.Add(new CD_SP_Parametros("@idUsuario", SqlDbType.Int, usuario.IdUsuario));
                lista_parametros.Add(new CD_SP_Parametros("@usuario", SqlDbType.VarChar, usuario.Usuario));
                lista_parametros.Add(new CD_SP_Parametros("@nombreUsuario", SqlDbType.VarChar, usuario.NombreUsuario));
                lista_parametros.Add(new CD_SP_Parametros("@contrasena", SqlDbType.VarChar, usuario.Contrasena));
                lista_parametros.Add(new CD_SP_Parametros("@idRol", SqlDbType.Int, usuario.IdRol));
                lista_parametros.Add(new CD_SP_Parametros("@idEstado", SqlDbType.Int, usuario.IdEstado));
                return obj_sql.EjecutarSP_NonQuery("sp_ActualizarUsuario", lista_parametros);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al actualizar usuario: " + ex.Message, ex);
            }
        }
        public bool ExisteUsuario(string usuario)
        {
            try
            {
                List<CD_SP_Parametros> lista = new List<CD_SP_Parametros>();
                lista.Add(new CD_SP_Parametros("@usuario", SqlDbType.VarChar, usuario));
                DataTable dt = obj_sql.EjecutarSP_Query("sp_ExisteUsuario", lista);
                return dt.Rows.Count > 0 && Convert.ToInt32(dt.Rows[0]["Resultado"]) == 1;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al verificar usuario: " + ex.Message, ex);
            }
        }
    }
}
