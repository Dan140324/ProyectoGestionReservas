using CapaDatos.SQL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using CapaEntidad.Clases;

namespace CapaDatos.DAO
{
    public class CD_LaboratorioDAO
    {
        private CD_ManagementSQL obj_sql = new CD_ManagementSQL();

        // MÉTODO REFACTORIZADO: Retorna List<Laboratorio_Entidad>
        public List<Laboratorio_Entidad> getListaLaboratorio()
        {
            List<Laboratorio_Entidad> listaLaboratorios = new List<Laboratorio_Entidad>();

            try
            {
                List<CD_SP_Parametros> lista_parametros = new List<CD_SP_Parametros>();
                DataTable dt = obj_sql.EjecutarSP_Query("sp_ListarLaboratoriosActivos", lista_parametros);

                // Convertir DataTable a List<Laboratorio_Entidad>
                foreach (DataRow row in dt.Rows)
                {
                    Laboratorio_Entidad laboratorio = new Laboratorio_Entidad
                    {
                        IdLaboratorio = Convert.ToInt32(row["idLaboratorio"]),
                        NombreLaboratorio = row["nombre"].ToString(),
                        Capacidad = Convert.ToInt32(row["capacidad"]),
                        // Si tu SP retorna el idEstado, descomenta esto:
                        // IdEstado = Convert.ToInt32(row["idEstado"]),
                        // NombreEstado = row["nombreEstado"].ToString()
                    };

                    listaLaboratorios.Add(laboratorio);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener lista de laboratorios: " + ex.Message, ex);
            }

            return listaLaboratorios;
        }

        // ALTERNATIVA: Método que retorna DataTable (por si aún lo necesitas)
        public DataTable getListaLaboratorioDataTable()
        {
            List<CD_SP_Parametros> lista_parametros = new List<CD_SP_Parametros>();
            return obj_sql.EjecutarSP_Query("sp_ListarLaboratoriosActivos", lista_parametros);
        }

        // Obtener un laboratorio por ID (retorna entidad)
        public Laboratorio_Entidad obtenerLaboratorioPorId(int idLaboratorio)
        {
            Laboratorio_Entidad laboratorio = null;

            try
            {
                List<CD_SP_Parametros> lista_parametros = new List<CD_SP_Parametros>();
                lista_parametros.Add(new CD_SP_Parametros("@idLaboratorio", SqlDbType.Int, idLaboratorio));

                DataTable dt = obj_sql.EjecutarSP_Query("sp_ObtenerLaboratorioPorId", lista_parametros);

                if (dt.Rows.Count > 0)
                {
                    DataRow row = dt.Rows[0];
                    laboratorio = new Laboratorio_Entidad
                    {
                        IdLaboratorio = Convert.ToInt32(row["idLaboratorio"]),
                        NombreLaboratorio = row["nombre"].ToString(),
                        Capacidad = Convert.ToInt32(row["capacidad"]),
                        IdEstado = Convert.ToInt32(row["idEstado"])
                    };
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener laboratorio por ID: " + ex.Message, ex);
            }

            return laboratorio;
        }

        // Guardar laboratorio (recibe entidad)
        public bool guardarLaboratorio(Laboratorio_Entidad laboratorio)
        {
            try
            {
                List<CD_SP_Parametros> lista_parametros = new List<CD_SP_Parametros>();
                lista_parametros.Add(new CD_SP_Parametros("@idLaboratorio", SqlDbType.Int,
                    laboratorio.IdLaboratorio == 0 ? (object)DBNull.Value : laboratorio.IdLaboratorio));
                lista_parametros.Add(new CD_SP_Parametros("@nombre", SqlDbType.VarChar, laboratorio.NombreLaboratorio));
                lista_parametros.Add(new CD_SP_Parametros("@capacidad", SqlDbType.Int, laboratorio.Capacidad));
                lista_parametros.Add(new CD_SP_Parametros("@idEstado", SqlDbType.Int, laboratorio.IdEstado));

                return obj_sql.EjecutarSP_NonQuery("sp_GuardarLaboratorio", lista_parametros);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al guardar laboratorio: " + ex.Message, ex);
            }
        }

        // Método sobrecargado: mantener compatibilidad con código anterior
        public bool guardarLaboratorio(int? idLaboratorio, string nombreLaboratorio, int capacidad, int idEstado)
        {
            Laboratorio_Entidad laboratorio = new Laboratorio_Entidad
            {
                IdLaboratorio = idLaboratorio ?? 0,
                NombreLaboratorio = nombreLaboratorio,
                Capacidad = capacidad,
                IdEstado = idEstado
            };

            return guardarLaboratorio(laboratorio);
        }

        public bool eliminarLaboratorio(int idLaboratorio)
        {
            try
            {
                List<CD_SP_Parametros> lista_parametros = new List<CD_SP_Parametros>();
                lista_parametros.Add(new CD_SP_Parametros("@idLaboratorio", SqlDbType.Int, idLaboratorio));
                return obj_sql.EjecutarSP_NonQuery("sp_EliminarLaboratorio", lista_parametros);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al eliminar laboratorio: " + ex.Message, ex);
            }
        }
    }


}

