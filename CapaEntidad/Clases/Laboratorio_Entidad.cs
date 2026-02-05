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
        private int idLaboratorio;
        private string nombreLaboratorio;
        private int capacidad;
        private int idEstado;
        
        public Laboratorio_Entidad(int idLaboratorio, string nombreLaboratorio, int capacidad, int idEstado)
        {
            this.idLaboratorio = idLaboratorio;
            this.nombreLaboratorio = nombreLaboratorio;
            this.capacidad = capacidad;
            this.idEstado = idEstado;
        }

        [DisplayName("ID Laboratorio")]

        public int IdLaboratorio
        {
            get { return idLaboratorio; }
            set { idLaboratorio = value; }
        }


        [DisplayName("Nombre Laboratorio")]
        [Required(ErrorMessage = "El nombre del laboratorio es obligatorio.")]
        public string NombreLaboratorio
        {
            get { return nombreLaboratorio; }
            set { nombreLaboratorio = value; }
        }

        [DisplayName("Capacidad")]
        [Required(ErrorMessage = "La capacidad del laboratorio es obligatoria.")]
        public int Capacidad
        {
            get { return capacidad; }
            set { capacidad = value; }
        }

        [DisplayName("Estado")]
        [Required(ErrorMessage = "El estado del laboratorio es obligatorio.")]
        public int IdEstado
        {
            get { return idEstado; }
            set { idEstado = value; }
        }
        
    }
}

