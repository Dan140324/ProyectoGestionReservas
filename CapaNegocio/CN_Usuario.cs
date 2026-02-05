using CapaDatos.DAO;
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
        private CD_UsuarioDAO obj_dao = new CD_UsuarioDAO();

        public bool login(string usuario, string contrasena)
        {
            return obj_dao.login(usuario, contrasena);
        }

        public bool crearUsuario(string usuario, string contrasena, string nombreUsuario)
        {
            if (string.IsNullOrWhiteSpace(usuario) || string.IsNullOrWhiteSpace(contrasena) || string.IsNullOrWhiteSpace(nombreUsuario))
            {
                throw new ArgumentException("El nombre de usuario, la contraseña y el nombre completo son obligatorios.");
            }
            
            if (obj_dao.ExisteUsuario(usuario))
            {
                throw new ArgumentException ("El nombre de usuario ya está en uso. Elige otro.");
            }

            return obj_dao.crearUsuario(usuario, contrasena, nombreUsuario);
        }

        public DataTable listarUsuarios(string filtroUsuario = null, string filtroNombreUsuario = null, string filtroEstado = null, string filtroRol = null)
        {
            try
            {
                return obj_dao.listarUsuarios(filtroUsuario, filtroNombreUsuario, filtroEstado, filtroRol);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al listar usuarios: " + ex.Message, ex);
            }
        }
    }
}
