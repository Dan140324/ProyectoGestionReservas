using CapaDatos.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;


namespace CapaNegocio.Laboratorios
{
    public class CN_Laboratorios
    {
        private CD_LaboratorioDAO obj_dao = new CD_LaboratorioDAO();

        public DataTable getListaLaboratorios()
        {
            return obj_dao.getListaLaboratorio();
        }

        public bool guardarLaboratorio(int? idLaboratorio, string nombreLaboratorio, int capacidad, int idEstado)
        {
            return obj_dao.guardarLaboratorio(idLaboratorio, nombreLaboratorio, capacidad, idEstado);
        }

        public bool eliminarLaboratorio(int idLaboratorio)
        {
            return obj_dao.eliminarLaboratorio(idLaboratorio);
        }

    }
}
