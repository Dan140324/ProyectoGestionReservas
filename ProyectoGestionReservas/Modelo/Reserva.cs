using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoGestionReservas.Modelo
{
    public class Reserva
    {
        private int idReserva;
        private Laboratorio laboratorio;
        private string docente;
        private string asignaturaMotivo;
        private DateTime fecha;
        private TimeSpan horaInicio;
        private TimeSpan horaFin;
        private int numEstudiantes;
        private int estadoReserva;

    }
}
