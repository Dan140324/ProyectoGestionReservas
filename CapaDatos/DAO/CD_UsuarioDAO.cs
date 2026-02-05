using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos.SQL;
using System.Data;
using CapaComun;

namespace CapaDatos.DAO
{
    public class CD_UsuarioDAO
    {
        private CD_ManagementSQL obj_sql = new CD_ManagementSQL();

        public bool login(string usuario, string contrasena)
        {
            List<CD_SP_Parametros> lista_parametros = new List<CD_SP_Parametros>();
            lista_parametros.Add(new CD_SP_Parametros("@usuario", SqlDbType.VarChar, usuario));
            lista_parametros.Add(new CD_SP_Parametros("@contrasena", SqlDbType.VarChar, contrasena));
            DataTable dtResultado = obj_sql.EjecutarSP_Query("sp_login", lista_parametros);

            if (dtResultado != null && dtResultado.Rows.Count > 0)
            {
                DataRow fila = dtResultado.Rows[0];

                // Llenamos la caché con los nombres exactos del procedimiento
                UsuarioLoginCache.idUsuario = Convert.ToInt32(fila["idUsuario"]);
                UsuarioLoginCache.nombreUsuario = fila["nombreUsuario"].ToString();
                UsuarioLoginCache.idRol = Convert.ToInt32(fila["idRol"]);
                UsuarioLoginCache.rol = fila["rol"].ToString(); // "Administrador" o "Usuario"

                return true;
            }
            return false;

        }

        public bool crearUsuario(string usuario, string contrasena, string nombreUsuario)
        {
            List<CD_SP_Parametros> lista_parametros = new List<CD_SP_Parametros>();
            lista_parametros.Add(new CD_SP_Parametros("@usuario", SqlDbType.VarChar, usuario));
            lista_parametros.Add(new CD_SP_Parametros("@contrasena", SqlDbType.VarChar, contrasena));
            lista_parametros.Add(new CD_SP_Parametros("@nombreUsuario", SqlDbType.VarChar, nombreUsuario));

            return obj_sql.EjecutarSP_NonQuery("sp_CrearUsuario", lista_parametros);
        }

        public bool ExisteUsuario(string usuario)
        {
            List<CD_SP_Parametros> lista = new List<CD_SP_Parametros>();
            lista.Add(new CD_SP_Parametros("@usuario", SqlDbType.VarChar, usuario));

            DataTable dt = obj_sql.EjecutarSP_Query("sp_ExisteUsuario", lista);

            // Si el resultado es 1, devolvemos true
            return dt.Rows.Count > 0 && Convert.ToInt32(dt.Rows[0]["Resultado"]) == 1;
        }

        public DataTable listarUsuarios(string? filtroUsuario, string? filtroNombreUsuario, string? filtroEstado, string? filtroRol)
        {
            List<CD_SP_Parametros> lista_parametros = new List<CD_SP_Parametros>();
            lista_parametros .Add(new CD_SP_Parametros("@filtroUsuario", SqlDbType.VarChar, (object)filtroUsuario ?? DBNull.Value));
            lista_parametros .Add(new CD_SP_Parametros("@filtroNombreUsuario", SqlDbType.VarChar, (object)filtroNombreUsuario ?? DBNull.Value));
            lista_parametros .Add(new CD_SP_Parametros("@filtroEstado", SqlDbType.VarChar, (object)filtroEstado ?? DBNull.Value));
            lista_parametros .Add(new CD_SP_Parametros("@filtroRol", SqlDbType.VarChar, (object)filtroRol ?? DBNull.Value));

            return obj_sql.EjecutarSP_Query("sp_ListarUsuarios", lista_parametros);
        }
    }
}
