using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad.Clases
{
    public class Reserva_Entidad
    {
        //Constructor para Binding
        public Reserva_Entidad()
        {
        }
        //Constructor para crear nueva reserva
        public Reserva_Entidad(int idLaboratorio, int idUsuario, DateTime fecha, TimeSpan horaInicio, 
                               TimeSpan horaFin, int cantidadUsuarios, string motivo)
        {
            this.IdLaboratorio = idLaboratorio;
            this.IdUsuario = idUsuario;
            this.Fecha = fecha;
            this.HoraInicio = horaInicio;
            this.HoraFin = horaFin;
            this.CantidadUsuarios = cantidadUsuarios;
            this.Motivo = motivo;
            this.IdEstadoReserva = 1; //Estado por defecto: Activa
        }

        //Constructor completo (con nombres para mostrar en UI)
        public Reserva_Entidad(int idReserva, int idLaboratorio, string nombreLaboratorio, int capacidadLaboratorio, int idUsuario, 
                               string nombreUsuario, DateTime fecha, TimeSpan horaInicio, TimeSpan horaFin, int cantidadUsuarios, 
                               string motivo, int idEstadoReserva, string nombreEstadoReserva, DateTime? fechaCreacion)
        {
            this.IdReserva = idReserva;
            this.IdLaboratorio = idLaboratorio;
            this.NombreLaboratorio = nombreLaboratorio;
            this.CapacidadLaboratorio = capacidadLaboratorio;
            this.IdUsuario = idUsuario;
            this.NombreUsuario = nombreUsuario;
            this.Fecha = fecha;
            this.HoraInicio = horaInicio;
            this.HoraFin = horaFin;
            this.CantidadUsuarios = cantidadUsuarios;
            this.Motivo = motivo;
            this.IdEstadoReserva = idEstadoReserva;
            this.NombreEstadoReserva = nombreEstadoReserva;
            this.FechaCreacion = fechaCreacion;
        }

        //Propiedades
        [DisplayName("ID")]
        public int IdReserva { get; set; }

        //Relación con Laboratorio
        [DisplayName("ID Laboratorio")]
        [Required(ErrorMessage = "Debe seleccionar un laboratorio.")]
        public int IdLaboratorio { get; set; }

        [DisplayName("Laboratorio")]
        public string NombreLaboratorio { get; set; }

        [DisplayName("Capacidad")]
        public int CapacidadLaboratorio { get; set; }

        //Relación con Usuario dueño de la reserva
        [DisplayName("ID Usuario")]
        [Required(ErrorMessage = "Debe estar asociado a un usuario.")]
        public int IdUsuario { get; set; }

        [DisplayName("Reservado por")]
        public string NombreUsuario { get; set; }

        //Datos de la reserva
        [DisplayName("Fecha")]
        [Required(ErrorMessage = "La fecha es obligatoria.")]
        public DateTime Fecha { get; set; }

        [DisplayName("Hora Inicio")]
        [Required(ErrorMessage = "La hora de inicio es obligatoria.")]
        public TimeSpan HoraInicio { get; set; }

        [DisplayName("Hora Fin")]
        [Required(ErrorMessage = "La hora de fin es obligatoria.")]
        public TimeSpan HoraFin { get; set; }

        [DisplayName("Cantidad Usuarios")]
        [Required(ErrorMessage = "La cantidad de usuarios es obligatoria.")]
        [Range(1, 100, ErrorMessage = "La cantidad debe estar entre 1 y 100.")]
        public int CantidadUsuarios { get; set; }

        [DisplayName("Motivo")]
        [Required(ErrorMessage = "El motivo es obligatorio.")]
        [StringLength(200, ErrorMessage = "El motivo no puede exceder 200 caracteres.")]
        public string Motivo { get; set; }

        //Estado de la reserva
        [DisplayName("ID Estado")]
        [Required(ErrorMessage = "El estado es obligatorio.")]
        public int IdEstadoReserva { get; set; }

        [DisplayName("Estado")]
        public string NombreEstadoReserva { get; set; }

        //Para auditoría
        [DisplayName("Fecha Creación")]
        public DateTime? FechaCreacion { get; set; }
=

        //Propiedades calculadas y métodos auxiliares
        //Duración en horas
        public double DuracionHoras => (HoraFin - HoraInicio).TotalHours;

        //Texto para mostrar el horario
        public string HorarioTexto => $"{HoraInicio:hh\\:mm} - {HoraFin:hh\\:mm}";

        //Texto completo de la fecha y hora
        public string FechaHoraTexto => $"{Fecha:dd/MM/yyyy} {HorarioTexto}";

        //Estados
        public bool EsActiva => IdEstadoReserva == 1 || NombreEstadoReserva?.ToLower() == "activa";
        public bool EsCancelada => IdEstadoReserva == 2 || NombreEstadoReserva?.ToLower() == "cancelada";
        public bool EsFinalizada => IdEstadoReserva == 3 || NombreEstadoReserva?.ToLower() == "finalizada";

        //Validación de solapamiento para validar nuevas reservas (no accede a BD)
        public bool SeSolapaCon(Reserva_Entidad otraReserva)
        {
            //Mismo laboratorio y misma fecha
            if (this.IdLaboratorio != otraReserva.IdLaboratorio ||
                this.Fecha.Date != otraReserva.Fecha.Date)
                return false;

            //Verificar solapamiento de horarios
            return this.HoraInicio < otraReserva.HoraFin &&
                   this.HoraFin > otraReserva.HoraInicio;
        }

        public bool EsModificable => EsActiva;

        public bool EsCancelable => EsActiva;

        public bool ExcedeCapacidad => CantidadUsuarios > CapacidadLaboratorio;

        public bool EsFutura => Fecha.Date > DateTime.Now.Date ||
                                (Fecha.Date == DateTime.Now.Date && HoraInicio > DateTime.Now.TimeOfDay);
        
        public bool EsPasada => Fecha.Date < DateTime.Now.Date ||
                               (Fecha.Date == DateTime.Now.Date && HoraFin < DateTime.Now.TimeOfDay);

        //Color para UI según estado
        public string ColorEstado
        {
            get
            {
                if (EsActiva) return "Green";
                if (EsCancelada) return "Red";
                if (EsFinalizada) return "Gray";
                return "Black";
            }
        }
    }
}
