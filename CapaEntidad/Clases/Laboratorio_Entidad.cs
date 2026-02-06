using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace CapaEntidad.Clases
{
    public class Laboratorio_Entidad
    {
        // Constructor vacío (necesario para binding)
        public Laboratorio_Entidad()
        {
        }

        // Constructor con parámetros
        public Laboratorio_Entidad(int idLaboratorio, string nombreLaboratorio, int capacidad, int idEstado)
        {
            this.IdLaboratorio = idLaboratorio;
            this.NombreLaboratorio = nombreLaboratorio;
            this.Capacidad = capacidad;
            this.IdEstado = idEstado;
        }

        // Constructor completo con nombre de estado (para mostrar en grid)
        public Laboratorio_Entidad(int idLaboratorio, string nombreLaboratorio, int capacidad, int idEstado, string nombreEstado)
        {
            this.IdLaboratorio = idLaboratorio;
            this.NombreLaboratorio = nombreLaboratorio;
            this.Capacidad = capacidad;
            this.IdEstado = idEstado;
            this.NombreEstado = nombreEstado;
        }

        // Propiedades
        [DisplayName("ID")]
        public int IdLaboratorio { get; set; }

        [DisplayName("Nombre del Laboratorio")]
        [Required(ErrorMessage = "El nombre del laboratorio es obligatorio.")]
        public string NombreLaboratorio { get; set; }

        [DisplayName("Capacidad")]
        [Required(ErrorMessage = "La capacidad del laboratorio es obligatoria.")]
        [Range(1, 100, ErrorMessage = "La capacidad debe estar entre 1 y 100.")]
        public int Capacidad { get; set; }

        [DisplayName("Estado")]
        [Required(ErrorMessage = "El estado del laboratorio es obligatorio.")]
        public int IdEstado { get; set; }

        // Propiedad adicional para mostrar el nombre del estado en el grid
        [DisplayName("Estado")]
        public string NombreEstado { get; set; }
    }
}

