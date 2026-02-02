using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad.Clases
{
    internal class Reserva_Entidad
    {
        private int idReserva;
        private Laboratorio_Entidad laboratorio;
        private string docente;
        private string asignaturaMotivo;
        private DateTime fecha;
        private TimeSpan horaInicio;
        private TimeSpan horaFin;
        private int numEstudiantes;
        private int estadoReserva;

    }
}
