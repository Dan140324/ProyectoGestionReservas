using CapaDatos.SQL;
using CapaEntidad.Clases;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos.DAO
{
    public class CD_ReservaDAO
    {
        private CD_ManagementSQL obj_sql = new CD_ManagementSQL();

        //Listar reservas mediante filtros
        public List<Reserva_Entidad> ListarReservas(DateTime? fechaDesde = null, DateTime? fechaHasta = null,
                                                     int? idLaboratorio = null, int? idUsuario = null,
                                                     int? idEstadoReserva = null)
        {
            List<Reserva_Entidad> listaReservas = new List<Reserva_Entidad>();

            try
            {
                List<CD_SP_Parametros> lista_parametros = new List<CD_SP_Parametros>();
                lista_parametros.Add(new CD_SP_Parametros("@fechaDesde", SqlDbType.Date, fechaDesde.HasValue ? (object)fechaDesde.Value : DBNull.Value));
                lista_parametros.Add(new CD_SP_Parametros("@fechaHasta", SqlDbType.Date, fechaHasta.HasValue ? (object)fechaHasta.Value : DBNull.Value));
                lista_parametros.Add(new CD_SP_Parametros("@idLaboratorio", SqlDbType.Int, idLaboratorio.HasValue ? (object)idLaboratorio.Value : DBNull.Value));
                lista_parametros.Add(new CD_SP_Parametros("@idUsuario", SqlDbType.Int, idUsuario.HasValue ? (object)idUsuario.Value : DBNull.Value));
                lista_parametros.Add(new CD_SP_Parametros("@idEstadoReserva", SqlDbType.Int, idEstadoReserva.HasValue ? (object)idEstadoReserva.Value : DBNull.Value));

                DataTable dt = obj_sql.EjecutarSP_Query("sp_ListarReservas", lista_parametros);

                foreach (DataRow row in dt.Rows)
                {
                    Reserva_Entidad reserva = new Reserva_Entidad
                    {
                        IdReserva = Convert.ToInt32(row["idReserva"]),
                        IdLaboratorio = Convert.ToInt32(row["idLaboratorio"]),
                        NombreLaboratorio = row["nombreLaboratorio"].ToString(),
                        CapacidadLaboratorio = Convert.ToInt32(row["capacidadLaboratorio"]),
                        IdUsuario = Convert.ToInt32(row["idUsuario"]),
                        NombreUsuario = row["nombreUsuario"].ToString(),
                        Fecha = Convert.ToDateTime(row["fecha"]),
                        HoraInicio = (TimeSpan)row["horaInicio"],
                        HoraFin = (TimeSpan)row["horaFin"],
                        CantidadUsuarios = Convert.ToInt32(row["cantidadUsuarios"]),
                        Motivo = row["motivo"].ToString(),
                        IdEstadoReserva = Convert.ToInt32(row["idEstadoReserva"]),
                        NombreEstadoReserva = row["nombreEstadoReserva"].ToString(),
                        FechaCreacion = row["fechaCreacion"] != DBNull.Value ? Convert.ToDateTime(row["fechaCreacion"]) : (DateTime?)null
                    };
                    listaReservas.Add(reserva);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al listar reservas: " + ex.Message, ex);
            }

            return listaReservas;
        }


        public List<Reserva_Entidad> VerificarSolapamiento(int idLaboratorio, DateTime fecha, TimeSpan horaInicio, TimeSpan horaFin,
                                                           int? idReservaExcluir = null)
        {
            List<Reserva_Entidad> reservasSolapadas = new List<Reserva_Entidad>();

            try
            {
                List<CD_SP_Parametros> lista_parametros = new List<CD_SP_Parametros>();
                lista_parametros.Add(new CD_SP_Parametros("@idLaboratorio", SqlDbType.Int, idLaboratorio));
                lista_parametros.Add(new CD_SP_Parametros("@fecha", SqlDbType.Date, fecha));
                lista_parametros.Add(new CD_SP_Parametros("@horaInicio", SqlDbType.Time, horaInicio));
                lista_parametros.Add(new CD_SP_Parametros("@horaFin", SqlDbType.Time, horaFin));
                lista_parametros.Add(new CD_SP_Parametros("@idReservaExcluir", SqlDbType.Int,
                    idReservaExcluir.HasValue ? (object)idReservaExcluir.Value : DBNull.Value));

                DataTable dt = obj_sql.EjecutarSP_Query("sp_VerificarSolapamiento", lista_parametros);

                foreach (DataRow row in dt.Rows)
                {
                    Reserva_Entidad reserva = new Reserva_Entidad
                    {
                        IdReserva = Convert.ToInt32(row["idReserva"]),
                        HoraInicio = (TimeSpan)row["horaInicio"],
                        HoraFin = (TimeSpan)row["horaFin"],
                        NombreUsuario = row["nombreUsuario"].ToString(),
                        Motivo = row["motivo"].ToString()
                    };
                    reservasSolapadas.Add(reserva);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al verificar solapamiento: " + ex.Message, ex);
            }

            return reservasSolapadas;
        }


        public int CrearReserva(Reserva_Entidad reserva)
        {
            try
            {
                List<CD_SP_Parametros> lista_parametros = new List<CD_SP_Parametros>();
                lista_parametros.Add(new CD_SP_Parametros("@idLaboratorio", SqlDbType.Int, reserva.IdLaboratorio));
                lista_parametros.Add(new CD_SP_Parametros("@idUsuario", SqlDbType.Int, reserva.IdUsuario));
                lista_parametros.Add(new CD_SP_Parametros("@fecha", SqlDbType.Date, reserva.Fecha));
                lista_parametros.Add(new CD_SP_Parametros("@horaInicio", SqlDbType.Time, reserva.HoraInicio));
                lista_parametros.Add(new CD_SP_Parametros("@horaFin", SqlDbType.Time, reserva.HoraFin));
                lista_parametros.Add(new CD_SP_Parametros("@cantidadUsuarios", SqlDbType.Int, reserva.CantidadUsuarios));
                lista_parametros.Add(new CD_SP_Parametros("@motivo", SqlDbType.VarChar, reserva.Motivo));

                //El SP retorna el ID de la reserva creada
                DataTable dt = obj_sql.EjecutarSP_Query("sp_CrearReserva", lista_parametros);

                if (dt.Rows.Count > 0)
                {
                    return Convert.ToInt32(dt.Rows[0]["idReservaCreada"]);
                }

                return 0;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al crear reserva: " + ex.Message, ex);
            }
        }


        public Reserva_Entidad ObtenerReservaPorId(int idReserva)
        {
            Reserva_Entidad reserva = null;

            try
            {
                List<CD_SP_Parametros> lista_parametros = new List<CD_SP_Parametros>();
                lista_parametros.Add(new CD_SP_Parametros("@idReserva", SqlDbType.Int, idReserva));

                DataTable dt = obj_sql.EjecutarSP_Query("sp_ObtenerReservaPorId", lista_parametros);

                if (dt.Rows.Count > 0)
                {
                    DataRow row = dt.Rows[0];
                    reserva = new Reserva_Entidad
                    {
                        IdReserva = Convert.ToInt32(row["idReserva"]),
                        IdLaboratorio = Convert.ToInt32(row["idLaboratorio"]),
                        NombreLaboratorio = row["nombreLaboratorio"].ToString(),
                        CapacidadLaboratorio = Convert.ToInt32(row["capacidadLaboratorio"]),
                        IdUsuario = Convert.ToInt32(row["idUsuario"]),
                        NombreUsuario = row["nombreUsuario"].ToString(),
                        Fecha = Convert.ToDateTime(row["fecha"]),
                        HoraInicio = (TimeSpan)row["horaInicio"],
                        HoraFin = (TimeSpan)row["horaFin"],
                        CantidadUsuarios = Convert.ToInt32(row["cantidadUsuarios"]),
                        Motivo = row["motivo"].ToString(),
                        IdEstadoReserva = Convert.ToInt32(row["idEstadoReserva"]),
                        NombreEstadoReserva = row["nombreEstadoReserva"].ToString(),
                        FechaCreacion = row["fechaCreacion"] != DBNull.Value ? Convert.ToDateTime(row["fechaCreacion"]) : (DateTime?)null
                    };
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener reserva: " + ex.Message, ex);
            }

            return reserva;
        }


        public bool ActualizarReserva(Reserva_Entidad reserva)
        {
            try
            {
                List<CD_SP_Parametros> lista_parametros = new List<CD_SP_Parametros>();
                lista_parametros.Add(new CD_SP_Parametros("@idReserva", SqlDbType.Int, reserva.IdReserva));
                lista_parametros.Add(new CD_SP_Parametros("@idLaboratorio", SqlDbType.Int, reserva.IdLaboratorio));
                lista_parametros.Add(new CD_SP_Parametros("@fecha", SqlDbType.Date, reserva.Fecha));
                lista_parametros.Add(new CD_SP_Parametros("@horaInicio", SqlDbType.Time, reserva.HoraInicio));
                lista_parametros.Add(new CD_SP_Parametros("@horaFin", SqlDbType.Time, reserva.HoraFin));
                lista_parametros.Add(new CD_SP_Parametros("@cantidadUsuarios", SqlDbType.Int, reserva.CantidadUsuarios));
                lista_parametros.Add(new CD_SP_Parametros("@motivo", SqlDbType.VarChar, reserva.Motivo));

                return obj_sql.EjecutarSP_NonQuery("sp_ActualizarReserva", lista_parametros);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al actualizar reserva: " + ex.Message, ex);
            }
        }

 
        public bool CancelarReserva(int idReserva)
        {
            try
            {
                List<CD_SP_Parametros> lista_parametros = new List<CD_SP_Parametros>();
                lista_parametros.Add(new CD_SP_Parametros("@idReserva", SqlDbType.Int, idReserva));

                return obj_sql.EjecutarSP_NonQuery("sp_CancelarReserva", lista_parametros);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al cancelar reserva: " + ex.Message, ex);
            }
        }

 
        public bool FinalizarReserva(int idReserva)
        {
            try
            {
                List<CD_SP_Parametros> lista_parametros = new List<CD_SP_Parametros>();
                lista_parametros.Add(new CD_SP_Parametros("@idReserva", SqlDbType.Int, idReserva));

                return obj_sql.EjecutarSP_NonQuery("sp_FinalizarReserva", lista_parametros);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al finalizar reserva: " + ex.Message, ex);
            }
        }

        public List<Reserva_Entidad> ConsultarDisponibilidad(int idLaboratorio, DateTime fecha)
        {
            List<Reserva_Entidad> reservasDelDia = new List<Reserva_Entidad>();

            try
            {
                List<CD_SP_Parametros> lista_parametros = new List<CD_SP_Parametros>();
                lista_parametros.Add(new CD_SP_Parametros("@idLaboratorio", SqlDbType.Int, idLaboratorio));
                lista_parametros.Add(new CD_SP_Parametros("@fecha", SqlDbType.Date, fecha));

                DataTable dt = obj_sql.EjecutarSP_Query("sp_ConsultarDisponibilidad", lista_parametros);

                foreach (DataRow row in dt.Rows)
                {
                    Reserva_Entidad reserva = new Reserva_Entidad
                    {
                        IdReserva = Convert.ToInt32(row["idReserva"]),
                        HoraInicio = (TimeSpan)row["horaInicio"],
                        HoraFin = (TimeSpan)row["horaFin"],
                        NombreUsuario = row["nombreUsuario"].ToString(),
                        Motivo = row["motivo"].ToString(),
                        CantidadUsuarios = Convert.ToInt32(row["cantidadUsuarios"])
                    };
                    reservasDelDia.Add(reserva);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al consultar disponibilidad: " + ex.Message, ex);
            }

            return reservasDelDia;
        }

        public int FinalizarReservasPasadas()
        {
            try
            {
                List<CD_SP_Parametros> lista_parametros = new List<CD_SP_Parametros>();
                DataTable dt = obj_sql.EjecutarSP_Query("sp_FinalizarReservasPasadas", lista_parametros);

                if (dt.Rows.Count > 0)
                {
                    return Convert.ToInt32(dt.Rows[0]["ReservasFinalizadas"]);
                }

                return 0;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al finalizar reservas pasadas: " + ex.Message, ex);
            }
        }
    }
}

