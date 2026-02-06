using CapaDatos.DAO;
using CapaEntidad.Clases;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CapaNegocio.Laboratorios
{
    public class CN_Laboratorios
    {
        private CD_LaboratorioDAO laboratorioDAO = new CD_LaboratorioDAO();

        // MÉTODO REFACTORIZADO: Retorna List<Laboratorio_Entidad>
        public List<Laboratorio_Entidad> getListaLaboratorios()
        {
            try
            {
                return laboratorioDAO.getListaLaboratorio();
            }
            catch (Exception ex)
            {
                throw new Exception("Error en capa de negocio al obtener laboratorios: " + ex.Message, ex);
            }
        }

        // ALTERNATIVA: Si aún necesitas DataTable en algunos lugares
        public DataTable getListaLaboratoriosDataTable()
        {
            try
            {
                return laboratorioDAO.getListaLaboratorioDataTable();
            }
            catch (Exception ex)
            {
                throw new Exception("Error en capa de negocio al obtener laboratorios: " + ex.Message, ex);
            }
        }

        //Obtener laboratorio por ID
        public Laboratorio_Entidad ObtenerLaboratorioPorId(int idLaboratorio)
        {
            try
            {
                if (idLaboratorio <= 0)
                {
                    throw new ArgumentException("El ID del laboratorio debe ser mayor a 0");
                }

                Laboratorio_Entidad laboratorio = laboratorioDAO.obtenerLaboratorioPorId(idLaboratorio);

                if (laboratorio == null)
                {
                    throw new Exception($"No se encontró el laboratorio con ID: {idLaboratorio}");
                }

                return laboratorio;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener laboratorio: " + ex.Message, ex);
            }
        }

        public bool guardarLaboratorio(Laboratorio_Entidad laboratorio)
        {
            try
            {
                // Validaciones de negocio
                if (string.IsNullOrWhiteSpace(laboratorio.NombreLaboratorio))
                {
                    throw new ArgumentException("El nombre del laboratorio es obligatorio.");
                }

                if (laboratorio.NombreLaboratorio.Length > 50)
                {
                    throw new ArgumentException("El nombre del laboratorio no puede exceder 50 caracteres.");
                }

                if (laboratorio.Capacidad <= 0)
                {
                    throw new ArgumentException("La capacidad debe ser mayor a 0.");
                }

                if (laboratorio.Capacidad > 100)
                {
                    throw new ArgumentException("La capacidad no puede ser mayor a 100.");
                }

                // Si todo está bien, guardar
                return laboratorioDAO.guardarLaboratorio(laboratorio);
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

        // Validar si existe un laboratorio con el mismo nombre
        public bool existeLaboratorioConNombre(string nombre, int? idLaboratorioExcluir = null)
        {
            try
            {
                List<Laboratorio_Entidad> laboratorios = laboratorioDAO.getListaLaboratorio();

                foreach (var lab in laboratorios)
                {
                    // Si estamos editando, excluir el laboratorio actual
                    if (idLaboratorioExcluir.HasValue && lab.IdLaboratorio == idLaboratorioExcluir.Value)
                        continue;

                    if (lab.NombreLaboratorio.Equals(nombre, StringComparison.OrdinalIgnoreCase))
                        return true;
                }

                return false;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al validar nombre de laboratorio: " + ex.Message, ex);
            }
        }

        public bool eliminarLaboratorio(int idLaboratorio)
        {
            try
            {
                if (idLaboratorio <= 0)
                {
                    throw new ArgumentException("El ID del laboratorio debe ser mayor a 0.");
                }

                return laboratorioDAO.eliminarLaboratorio(idLaboratorio);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al eliminar laboratorio: " + ex.Message, ex);
            }
        }

        // Métodos adicionales útiles

        // Obtener solo laboratorios activos
        public List<Laboratorio_Entidad> getListaLaboratoriosActivos()
        {
            try
            {
                List<Laboratorio_Entidad> todos = laboratorioDAO.getListaLaboratorio();
                return todos.FindAll(lab => lab.IdEstado == 1); // 1 = Activo
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener laboratorios activos: " + ex.Message, ex);
            }
        }

        // Buscar laboratorios por nombre
        public List<Laboratorio_Entidad> buscarLaboratoriosPorNombre(string nombre)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(nombre))
                {
                    return getListaLaboratorios();
                }

                List<Laboratorio_Entidad> todos = laboratorioDAO.getListaLaboratorio();
                return todos.FindAll(lab =>
                    lab.NombreLaboratorio.ToLower().Contains(nombre.ToLower())
                );
            }
            catch (Exception ex)
            {
                throw new Exception("Error al buscar laboratorios: " + ex.Message, ex);
            }
        }

        // Contar total de laboratorios
        public int contarLaboratorios()
        {
            try
            {
                return laboratorioDAO.getListaLaboratorio().Count;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al contar laboratorios: " + ex.Message, ex);
            }
        }
    }
}
