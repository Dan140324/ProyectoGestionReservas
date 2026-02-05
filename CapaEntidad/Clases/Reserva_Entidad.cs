using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad.Clases
{
    public class Reserva_Entidad
    {
        private int idReserva;
        private int idLaboratorio;
        private int idUsuario;
        private string asignaturaMotivo;
        private DateTime fecha;
        private TimeSpan horaInicio;
        private TimeSpan horaFin;
        private int numEstudiantes;
        private int idEstado;

        public Reserva_Entidad(int idReserva, int idLaboratorio, int idUsuario, string asignaturaMotivo, DateTime fecha, TimeSpan horaInicio, TimeSpan horaFin, int numEstudiantes, int idEstado)
        {
            this.idReserva = idReserva;
            this.idLaboratorio = idLaboratorio;
            this.idUsuario = idUsuario;
            this.asignaturaMotivo = asignaturaMotivo;
            this.fecha = fecha;
            this.horaInicio = horaInicio;
            this.horaFin = horaFin;
            this.numEstudiantes = numEstudiantes;
            this.idEstado = idEstado;
        }

        public int IdReserva
        {
            get { return idReserva; }
            set { idReserva = value; }
        }

        public int IdLaboratorio
        {
            get { return idLaboratorio; }
            set { idLaboratorio = value; }
        } 

        public int IdUsuario
        {
            get { return idUsuario; }
            set { idUsuario = value; }
        }

        public string AsignaturaMotivo
        {
            get { return asignaturaMotivo; }
            set { asignaturaMotivo = value; }
        }

        public DateTime Fecha
        {
            get { return fecha; }
            set { fecha = value; }
        }

        public TimeSpan HoraInicio
        {
            get { return horaInicio; }
            set { horaInicio = value; }
        }

        public TimeSpan HoraFin
        {
            get { return horaFin; }
            set { horaFin = value; }
        }   

        public int NumEstudiantes
        {
            get { return numEstudiantes; }
            set { numEstudiantes = value; }
        }

        public int IdEstado
        {
            get { return idEstado; }
            set { idEstado = value; }
        }
    }
}
