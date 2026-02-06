using CapaComun;
using CapaDatos.DAO;
using CapaEntidad.Clases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
 
namespace CapaNegocio
{
    public class CN_Reservas
    {
        private CD_ReservaDAO reservaDAO = new CD_ReservaDAO();
        private CD_LaboratorioDAO laboratorioDAO = new CD_LaboratorioDAO();

        //Listar reservas con filtros opcionales
        public List<Reserva_Entidad> ListarReservas(DateTime? fechaDesde = null, DateTime? fechaHasta = null,
                                                     int? idLaboratorio = null, int? idUsuario = null,
                                                     int? idEstadoReserva = null)
        {
            try
            {
                return reservaDAO.ListarReservas(fechaDesde, fechaHasta, idLaboratorio, idUsuario, idEstadoReserva);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al listar reservas: " + ex.Message, ex);
            }
        }

        public List<Reserva_Entidad> ListarReservasActivas()
        {
            return ListarReservas(idEstadoReserva: 1);
        }

        /// <summary>
        /// Lista reservas de un laboratorio específico en una fecha
        /// </summary>
        public List<Reserva_Entidad> ListarReservasPorLaboratorioYFecha(int idLaboratorio, DateTime fecha)
        {
            return ListarReservas(
                fechaDesde: fecha.Date,
                fechaHasta: fecha.Date,
                idLaboratorio: idLaboratorio
            );
        }

        /// <summary>
        /// Lista reservas del usuario actual (según cache)
        /// </summary>
        public List<Reserva_Entidad> ListarMisReservas()
        {
            return ListarReservas(idUsuario: UsuarioLoginCache.idUsuario);
        }

        /// <summary>
        /// Lista reservas futuras (desde hoy en adelante)
        /// </summary>
        public List<Reserva_Entidad> ListarReservasFuturas()
        {
            List<Reserva_Entidad> todasReservas = ListarReservas(fechaDesde: DateTime.Now.Date);
            return todasReservas.Where(r => r.EsFutura).ToList();
        }


        //Crear reserva con validaciones
        public int CrearReserva(Reserva_Entidad reserva)
        {
            try
            {
                //Valida los datos básicos de la reserva (laboratorio, cantidad usuarios, motivo)
                ValidarDatosBasicosReserva(reserva);

                if (reserva.Fecha.Date < DateTime.Now.Date)
                {
                    throw new Exception("No se puede crear una reserva en una fecha pasada");
                }

                if (reserva.Fecha.Date == DateTime.Now.Date &&
                    reserva.HoraInicio < DateTime.Now.TimeOfDay)
                {
                    throw new Exception("No se puede crear una reserva con hora de inicio pasada");
                }

                if (reserva.HoraFin <= reserva.HoraInicio)
                {
                    throw new Exception("La hora de fin debe ser mayor que la hora de inicio");
                }

                double duracionHoras = (reserva.HoraFin - reserva.HoraInicio).TotalHours;

                if (duracionHoras < 0.5) //Mínimo 30 minutos
                {
                    throw new Exception("La duración mínima de una reserva es de 30 minutos");
                }

                if (duracionHoras > 8) //Máximo 8 horas
                {
                    throw new Exception("La duración máxima de una reserva es de 8 horas");
                }

                //Valida que la cantidad de usuarios no exceda la capacidad del laboratorio
                Laboratorio_Entidad laboratorio = laboratorioDAO.obtenerLaboratorioPorId(reserva.IdLaboratorio);

                if (laboratorio == null)
                {
                    throw new Exception("El laboratorio seleccionado no existe");
                }

                if (reserva.CantidadUsuarios > laboratorio.Capacidad)
                {
                    throw new Exception($"La cantidad de usuarios ({reserva.CantidadUsuarios}) excede la capacidad del laboratorio ({laboratorio.Capacidad})");
                }

                if (reserva.CantidadUsuarios <= 0)
                {
                    throw new Exception("La cantidad de usuarios debe ser mayor a 0");
                }

                //Valida que no haya reservas solapadas para el mismo laboratorio en el mismo horario
                List<Reserva_Entidad> reservasSolapadas = reservaDAO.VerificarSolapamiento(
                    reserva.IdLaboratorio,
                    reserva.Fecha,
                    reserva.HoraInicio,
                    reserva.HoraFin
                );

                if (reservasSolapadas.Count > 0)
                {
                    Reserva_Entidad primera = reservasSolapadas[0];
                    throw new Exception(
                        $"Ya existe una reserva que se solapa con el horario seleccionado:\n" +
                        $"Horario ocupado: {primera.HorarioTexto}\n" +
                        $"Reservado por: {primera.NombreUsuario}\n" +
                        $"Motivo: {primera.Motivo}"
                    );
                }

                //Si el ID de usuario no se ha proporcionado, asignar el del usuario logueado (según cache)
                if (reserva.IdUsuario == 0)
                {
                    reserva.IdUsuario = UsuarioLoginCache.idUsuario;
                }

                //Límite de reservas activas por usuario
                int reservasActivasUsuario = ContarReservasActivasUsuario(reserva.IdUsuario);

                if (reservasActivasUsuario >= 5) //Límite de 5 reservas activas por usuario
                {
                    throw new Exception($"El usuario tiene {reservasActivasUsuario} reservas activas. El límite es 5. Cancele o finalice alguna reserva antes de crear una nueva.");
                }

                //Crear la reserva
                int idReservaCreada = reservaDAO.CrearReserva(reserva);

                if (idReservaCreada == 0)
                {
                    throw new Exception("No se pudo crear la reserva");
                }

                return idReservaCreada;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al crear reserva: " + ex.Message, ex);
            }
        }


        //Actualizar reserva con validaciones
        public bool ActualizarReserva(Reserva_Entidad reserva)
        {
            try
            {
                //Validar que la reserva existe
                if (reserva.IdReserva <= 0)
                {
                    throw new Exception("ID de reserva inválido");
                }

                //Obtener reserva actual de la BD
                Reserva_Entidad reservaActual = reservaDAO.ObtenerReservaPorId(reserva.IdReserva);

                if (reservaActual == null)
                {
                    throw new Exception("No se encontró la reserva");
                }

                //Valida que la reserva esté en estado activa (solo las reservas activas pueden modificarse)
                if (!reservaActual.EsActiva)
                {
                    throw new Exception($"No se puede modificar una reserva con estado: {reservaActual.NombreEstadoReserva}");
                }

                //Valida adicional: No se pueden modificar reservas pasadas (aunque estén activas)
                if (reservaActual.EsPasada)
                {
                    throw new Exception("No se puede modificar una reserva que ya pasó");
                }

                ValidarDatosBasicosReserva(reserva);
                //Valida que la fecha no sea pasada (aunque esté activa, no se puede cambiar a una fecha pasada)
                if (reserva.Fecha.Date < DateTime.Now.Date)
                {
                    throw new Exception("No se puede cambiar la reserva a una fecha pasada");
                }

               
                if (reserva.HoraFin <= reserva.HoraInicio)
                {
                    throw new Exception("La hora de fin debe ser mayor que la hora de inicio");
                }

                //Valida duración mínima y máxima (30 minutos - 8 horas)
                double duracionHoras = (reserva.HoraFin - reserva.HoraInicio).TotalHours;

                if (duracionHoras < 0.5)
                {
                    throw new Exception("La duración mínima de una reserva es de 30 minutos");
                }

                if (duracionHoras > 8)
                {
                    throw new Exception("La duración máxima de una reserva es de 8 horas");
                }

                //Valida que la cantidad de usuarios no exceda la capacidad del laboratorio
                Laboratorio_Entidad laboratorio = laboratorioDAO.obtenerLaboratorioPorId(reserva.IdLaboratorio);

                if (laboratorio == null)
                {
                    throw new Exception("El laboratorio seleccionado no existe");
                }

                if (reserva.CantidadUsuarios > laboratorio.Capacidad)
                {
                    throw new Exception($"La cantidad de usuarios excede la capacidad del laboratorio ({laboratorio.Capacidad})");
                }

                //Verifica que no haya reservas solapadas para el mismo laboratorio en el mismo
                //horario, excluyendo la reserva actual (por eso se pasa el ID de reserva a excluir)
                List<Reserva_Entidad> reservasSolapadas = reservaDAO.VerificarSolapamiento(
                    reserva.IdLaboratorio,
                    reserva.Fecha,
                    reserva.HoraInicio,
                    reserva.HoraFin,
                    reserva.IdReserva //Excluir esta reserva de la verificación
                );

                if (reservasSolapadas.Count > 0)
                {
                    Reserva_Entidad primera = reservasSolapadas[0];
                    throw new Exception(
                        $"Ya existe otra reserva que se solapa con el nuevo horario:\n" + $"Horario ocupado: {primera.HorarioTexto}\n" +
                        $"Reservado por: {primera.NombreUsuario}"
                    );
                }

                //Actualizar la reserva
                return reservaDAO.ActualizarReserva(reserva);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al actualizar reserva: " + ex.Message, ex);
            }
        }

        //Cancelar reserva con validaciones
        public bool CancelarReserva(int idReserva)
        {
            try
            {
                if (idReserva <= 0)
                {
                    throw new Exception("ID de reserva inválido");
                }

                //Obtener reserva actual
                Reserva_Entidad reserva = reservaDAO.ObtenerReservaPorId(idReserva);

                if (reserva == null)
                {
                    throw new Exception("No se encontró la reserva");
                }

                //Validar que está activa
                if (!reserva.EsActiva)
                {
                    throw new Exception($"Solo se pueden cancelar reservas activas. Estado actual: {reserva.NombreEstadoReserva}");
                }


                return reservaDAO.CancelarReserva(idReserva);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al cancelar reserva: " + ex.Message, ex);
            }
        }

        //Finalizar reserva con validaciones
        public bool FinalizarReserva(int idReserva)
        {
            try
            {
                if (idReserva <= 0)
                {
                    throw new Exception("ID de reserva inválido");
                }

                //Obtener reserva actual
                Reserva_Entidad reserva = reservaDAO.ObtenerReservaPorId(idReserva);

                if (reserva == null)
                {
                    throw new Exception("No se encontró la reserva");
                }

                //Validar que está activa
                if (!reserva.EsActiva)
                {
                    throw new Exception($"Solo se pueden finalizar reservas activas. Estado actual: {reserva.NombreEstadoReserva}");
                }

                //Validación adicional: Solo finalizar reservas pasadas o en curso
                if (reserva.EsFutura)
                {
                    throw new Exception("No se puede finalizar una reserva futura. Use 'Cancelar' en su lugar.");
                }


                return reservaDAO.FinalizarReserva(idReserva);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al finalizar reserva: " + ex.Message, ex);
            }
        }


        //Obtener reserva por ID con validaciones
        public Reserva_Entidad ObtenerReservaPorId(int idReserva)
        {
            try
            {
                if (idReserva <= 0)
                {
                    throw new Exception("ID de reserva inválido");
                }

                Reserva_Entidad reserva = reservaDAO.ObtenerReservaPorId(idReserva);

                if (reserva == null)
                {
                    throw new Exception($"No se encontró la reserva con ID: {idReserva}");
                }

                return reserva;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener reserva: " + ex.Message, ex);
            }
        }

        //Consultar reservas de un laboratorio en una fecha específica (para verificar disponibilidad)
        public List<Reserva_Entidad> ConsultarDisponibilidad(int idLaboratorio, DateTime fecha)
        {
            try
            {
                return reservaDAO.ConsultarDisponibilidad(idLaboratorio, fecha);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al consultar disponibilidad: " + ex.Message, ex);
            }
        }

        //Verificar si un laboratorio está disponible en un horario específico (sin solapamientos)
        public bool EstaDisponible(int idLaboratorio, DateTime fecha, TimeSpan horaInicio, TimeSpan horaFin, int? idReservaExcluir = null)
        {
            try
            {
                List<Reserva_Entidad> solapadas = reservaDAO.VerificarSolapamiento(idLaboratorio, fecha, horaInicio, horaFin, idReservaExcluir);

                return solapadas.Count == 0; //Disponible si no hay solapamiento
            }
            catch (Exception ex)
            {
                throw new Exception("Error al verificar disponibilidad: " + ex.Message, ex);
            }
        }

        // Contar reservas activas de un usuario (para limitar la cantidad de reservas activas por usuario)
        public int ContarReservasActivasUsuario(int idUsuario)
        {
            try
            {
                List<Reserva_Entidad> reservas = ListarReservas(idUsuario: idUsuario, idEstadoReserva: 1);
                return reservas.Count;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al contar reservas: " + ex.Message, ex);
            }
        }

        //Obtener estadísticas de reservas por estado (activas, canceladas, finalizadas)
        public Dictionary<string, int> ObtenerEstadisticasPorEstado()
        {
            try
            {
                List<Reserva_Entidad> todasReservas = ListarReservas();

                return new Dictionary<string, int>
                {
                    { "Activas", todasReservas.Count(r => r.EsActiva) },
                    { "Canceladas", todasReservas.Count(r => r.EsCancelada) },
                    { "Finalizadas", todasReservas.Count(r => r.EsFinalizada) }
                };
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener estadísticas: " + ex.Message, ex);
            }
        }

        //Obtener horarios libres de un laboratorio en una fecha específica (para mostrar opciones al crear o modificar reservas)
        public List<string> ObtenerHorariosLibres(int idLaboratorio, DateTime fecha)
        {
            try
            {
                List<Reserva_Entidad> reservasDelDia = ConsultarDisponibilidad(idLaboratorio, fecha);
                List<string> horariosLibres = new List<string>();

                //Horario de operación: 7:00 AM - 9:00 PM
                TimeSpan horaApertura = new TimeSpan(7, 0, 0);
                TimeSpan horaCierre = new TimeSpan(21, 0, 0);

                //Generar bloques de 1 hora
                for (TimeSpan hora = horaApertura; hora < horaCierre; hora = hora.Add(TimeSpan.FromHours(1)))
                {
                    TimeSpan horaFin = hora.Add(TimeSpan.FromHours(1));

                    //Verificar si este bloque está libre
                    bool estaLibre = true;
                    foreach (var reserva in reservasDelDia)
                    {
                        if (hora < reserva.HoraFin && horaFin > reserva.HoraInicio)
                        {
                            estaLibre = false;
                            break;
                        }
                    }

                    if (estaLibre)
                    {
                        horariosLibres.Add($"{hora:hh\\:mm} - {horaFin:hh\\:mm}");
                    }
                }

                return horariosLibres;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener horarios libres: " + ex.Message, ex);
            }
        }

        //Validaciones privadas
        //Validar los datos básicos de una reserva (laboratorio, cantidad usuarios, motivo)
        private void ValidarDatosBasicosReserva(Reserva_Entidad reserva)
        {
            if (reserva == null)
            {
                throw new ArgumentNullException("La reserva no puede ser nula");
            }

            if (reserva.IdLaboratorio <= 0)
            {
                throw new ArgumentException("Debe seleccionar un laboratorio válido");
            }

            if (reserva.CantidadUsuarios <= 0)
            {
                throw new ArgumentException("La cantidad de usuarios debe ser mayor a 0");
            }

            if (string.IsNullOrWhiteSpace(reserva.Motivo))
            {
                throw new ArgumentException("El motivo de la reserva es obligatorio");
            }

            if (reserva.Motivo.Length > 200)
            {
                throw new ArgumentException("El motivo no puede exceder 200 caracteres");
            }
        }
    }
}
