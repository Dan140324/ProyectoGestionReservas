using CapaDatos.SQL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace CapaDatos.DAO
{
    public class CD_LaboratorioDAO
    {
        private CD_ManagementSQL obj_sql = new CD_ManagementSQL();

        public DataTable getListaLaboratorio()
        {
            List<CD_SP_Parametros> lista_parametros = new List<CD_SP_Parametros>();

            return obj_sql.EjecutarSP_Query("sp_ListarLaboratoriosActivos", lista_parametros);
        }

        public bool guardarLaboratorio(int? idLaboratorio, string nombreLaboratorio, int capacidad, int idEstado)
        {
            List<CD_SP_Parametros> lista_parametros = new List<CD_SP_Parametros>();
            lista_parametros.Add(new CD_SP_Parametros("@idLaboratorio", SqlDbType.Int, (object)idLaboratorio ?? DBNull.Value));
            lista_parametros.Add(new CD_SP_Parametros("@nombre", SqlDbType.VarChar, nombreLaboratorio));
            lista_parametros.Add(new CD_SP_Parametros("@capacidad", SqlDbType.Int, capacidad));
            lista_parametros.Add(new CD_SP_Parametros("@idEstado", SqlDbType.Int, idEstado));

            return obj_sql.EjecutarSP_NonQuery("sp_GuardarLaboratorio", lista_parametros);
        }

        public bool eliminarLaboratorio(int idLaboratorio)
        {
            List<CD_SP_Parametros> lista_parametros = new List<CD_SP_Parametros>();
            lista_parametros.Add(new CD_SP_Parametros("@idLaboratorio", SqlDbType.Int, idLaboratorio));

            return obj_sql.EjecutarSP_NonQuery("sp_EliminarLaboratorio", lista_parametros);
        }


    }
}
