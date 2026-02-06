using CapaComun;
using CapaEntidad.Clases;
using CapaNegocio;
using CapaNegocio.Laboratorios;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaPresentacion.FormulariosReservas
{
    public partial class FrmCrearReserva : Form
    {
        private CN_Reservas cnReservas = new CN_Reservas();
        private CN_Laboratorios cnLaboratorios = new CN_Laboratorios();

        public FrmCrearReserva()
        {
            InitializeComponent();
        }

        private void FrmCrearReserva_Load(object sender, EventArgs e)
        {
            ConfigurarControles();
            CargarLaboratorios();
            EstablecerValoresPorDefecto();
        }

        //Configurar controles del formulario
        private void ConfigurarControles()
        {
            //Configurar DateTimePicker de fecha
            dtpFecha.MinDate = DateTime.Now.Date; //No permitir fechas pasadas
            dtpFecha.MaxDate = DateTime.Now.AddMonths(3); //Máximo 3 meses adelante
            dtpFecha.Format = DateTimePickerFormat.Custom;
            dtpFecha.CustomFormat = "dd/MM/yyyy";

            //Configurar DateTimePicker de horas
            dtpHoraInicio.Format = DateTimePickerFormat.Custom;
            dtpHoraInicio.CustomFormat = "HH:mm";
            dtpHoraInicio.ShowUpDown = true;

            dtpHoraFin.Format = DateTimePickerFormat.Custom;
            dtpHoraFin.CustomFormat = "HH:mm";
            dtpHoraFin.ShowUpDown = true;

            //Configurar NumericUpDown
            nudCantidadUsuarios.Minimum = 1;
            nudCantidadUsuarios.Maximum = 100;
            nudCantidadUsuarios.Value = 1;

            //Labels de advertencia inicialmente ocultos
            lblAdvertenciaDisponibilidad.Visible = false;
            lblAdvertenciaCapacidad.Visible = false;
            lblAdvertenciaHorario.Visible = false;
            lblDuracion.Text = "";
        }

        private void CargarLaboratorios()
        {
            try
            {
                //Cargar laboratorios activos en el ComboBox
                List<Laboratorio_Entidad> laboratorios = cnLaboratorios.getListaLaboratorios();

                cmbLaboratorio.DataSource = null;
                cmbLaboratorio.DataSource = laboratorios;
                cmbLaboratorio.DisplayMember = "NombreLaboratorio";
                cmbLaboratorio.ValueMember = "IdLaboratorio";
                cmbLaboratorio.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MostrarError("Error al cargar laboratorios", ex.Message);
            }
        }

        private void EstablecerValoresPorDefecto()
        {
            //Establecer fecha de hoy
            dtpFecha.Value = DateTime.Now.Date;

            //Establecer hora de inicio: siguiente hora en punto
            DateTime ahora = DateTime.Now;
            TimeSpan horaActual = ahora.TimeOfDay;
            TimeSpan proximaHora = TimeSpan.FromHours(Math.Ceiling(horaActual.TotalHours));

            dtpHoraInicio.Value = DateTime.Today.Add(proximaHora);

            //Establecer hora fin: 2 horas después
            dtpHoraFin.Value = DateTime.Today.Add(proximaHora.Add(TimeSpan.FromHours(2)));

            // Cantidad por defecto
            nudCantidadUsuarios.Value = 20;
        }

        //Validaciones en tiempo real
        private void cmbLaboratorio_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbLaboratorio.SelectedIndex >= 0)
            {
                Laboratorio_Entidad labSeleccionado = (Laboratorio_Entidad)cmbLaboratorio.SelectedItem;

                //Muestra capacidad del laboratorio
                lblCapacidadLab.Text = $"Capacidad: {labSeleccionado.Capacidad} usuarios";

                //Actualiza el máximo del NumericUpDown al laboratorio escogido
                nudCantidadUsuarios.Maximum = labSeleccionado.Capacidad;

                //Validar disponibilidad
                ValidarDisponibilidadEnTiempoReal();
                ValidarCapacidad();
            }
        }

        private void dtpFecha_ValueChanged(object sender, EventArgs e)
        {
            //Validar disponibilidad cuando cambia la fecha
            ValidarDisponibilidadEnTiempoReal();
        }

        private void dtpHoraInicio_ValueChanged(object sender, EventArgs e)
        {
            //Aumenta en uno la hora fin si es menor o igual a la hora inicio
            if (dtpHoraFin.Value <= dtpHoraInicio.Value)
            {
                dtpHoraFin.Value = dtpHoraInicio.Value.AddHours(1);
            }

            //Calcular y mostrar duración
            MostrarDuracion();

            //Validar horario
            ValidarHorario();

            //Validar disponibilidad
            ValidarDisponibilidadEnTiempoReal();
        }

        private void dtpHoraFin_ValueChanged(object sender, EventArgs e)
        {
            //Calcular y mostrar duración
            MostrarDuracion();

            //Validar horario
            ValidarHorario();

            //Validar disponibilidad
            ValidarDisponibilidadEnTiempoReal();
        }

        private void nudCantidadUsuarios_ValueChanged(object sender, EventArgs e)
        {
            ValidarCapacidad();
        }

        private void txtMotivo_TextChanged(object sender, EventArgs e)
        {
            //Muestra contador de caracteres
            lblContadorMotivo.Text = $"{txtMotivo.Text.Length}/200";
        }

        //Métodos para validaciones
        private void MostrarDuracion()
        {
            TimeSpan duracion = dtpHoraFin.Value.TimeOfDay - dtpHoraInicio.Value.TimeOfDay;

            if (duracion.TotalHours > 0)
            {
                lblDuracion.Text = $"Duración: {duracion.TotalHours:0.0} horas";
                lblDuracion.ForeColor = Color.Blue;
            }
            else
            {
                lblDuracion.Text = "Duración: inválida";
                lblDuracion.ForeColor = Color.Red;
            }
        }

        private void ValidarHorario()
        {
            TimeSpan horaInicio = dtpHoraInicio.Value.TimeOfDay;
            TimeSpan horaFin = dtpHoraFin.Value.TimeOfDay;
            TimeSpan duracion = horaFin - horaInicio;

            lblAdvertenciaHorario.Visible = false;

            //Validar que hora fin > hora inicio
            if (horaFin <= horaInicio)
            {
                MostrarAdvertencia(lblAdvertenciaHorario, "La hora de fin debe ser mayor que la hora de inicio");
                return;
            }

            //Validar duración mínima (30 minutos)
            if (duracion.TotalHours < 0.5)
            {
                MostrarAdvertencia(lblAdvertenciaHorario, "La duración mínima es de 30 minutos");
                return;
            }

            //Validar duración máxima (8 horas)
            if (duracion.TotalHours > 8)
            {
                MostrarAdvertencia(lblAdvertenciaHorario, "La duración máxima es de 8 horas");
                return;
            }

            //Horario válido
            lblAdvertenciaHorario.Visible = false;
        }

        private void ValidarCapacidad()
        {
            if (cmbLaboratorio.SelectedIndex < 0)
            {
                lblAdvertenciaCapacidad.Visible = false;
                return;
            }

            Laboratorio_Entidad labSeleccionado = (Laboratorio_Entidad)cmbLaboratorio.SelectedItem;
            int cantidadUsuarios = (int)nudCantidadUsuarios.Value;

            if (cantidadUsuarios > labSeleccionado.Capacidad)
            {
                MostrarAdvertencia(lblAdvertenciaCapacidad, $"La cantidad ({cantidadUsuarios}) excede la capacidad del laboratorio ({labSeleccionado.Capacidad})");
            }
            else
            {
                lblAdvertenciaCapacidad.Visible = false;
            }
        }

        private void ValidarDisponibilidadEnTiempoReal()
        {
            //Limpiar advertencia
            lblAdvertenciaDisponibilidad.Visible = false;
            lstReservasConflicto.Items.Clear();

            //Verificar que haya un laboratorio seleccionado
            if (cmbLaboratorio.SelectedIndex < 0)
                return;

            try
            {
                Laboratorio_Entidad labSeleccionado = (Laboratorio_Entidad)cmbLaboratorio.SelectedItem;
                DateTime fecha = dtpFecha.Value.Date;
                TimeSpan horaInicio = dtpHoraInicio.Value.TimeOfDay;
                TimeSpan horaFin = dtpHoraFin.Value.TimeOfDay;

                //Verifica si está disponible
                bool disponible = cnReservas.EstaDisponible(labSeleccionado.IdLaboratorio, fecha, horaInicio, horaFin);

                if (!disponible)
                {
                    //Obtener reservas que se solapan
                    List<Reserva_Entidad> reservasConflicto = cnReservas.ConsultarDisponibilidad(
                        labSeleccionado.IdLaboratorio, fecha
                    );

                    //Filtrar solo las que se solapan
                    List<Reserva_Entidad> solapadas = new List<Reserva_Entidad>();
                    foreach (var reserva in reservasConflicto)
                    {
                        if (reserva.HoraInicio < horaFin && reserva.HoraFin > horaInicio)
                        {
                            solapadas.Add(reserva);
                        }
                    }

                    //Mostrar advertencia
                    MostrarAdvertencia(lblAdvertenciaDisponibilidad,
                        $"Horario NO disponible. {solapadas.Count} reserva(s) en conflicto:");

                    //Muestra reservas en conflicto en el ListBox
                    foreach (var reserva in solapadas)
                    {
                        lstReservasConflicto.Items.Add(
                            $"{reserva.HorarioTexto} - {reserva.NombreUsuario} ({reserva.Motivo})"
                        );
                    }

                    lstReservasConflicto.Visible = true;
                }
                else
                {
                    //Disponible
                    lblAdvertenciaDisponibilidad.Text = "✓ Horario disponible";
                    lblAdvertenciaDisponibilidad.ForeColor = Color.Green;
                    lblAdvertenciaDisponibilidad.Visible = true;
                    lstReservasConflicto.Visible = false;
                }
            }
            catch (Exception ex)
            {
                //Error al verificar disponibilidad
                System.Diagnostics.Debug.WriteLine($"Error al validar disponibilidad: {ex.Message}");
            }
        }

        //Ver disponibilidad completa para el día
        private void btnVerDisponibilidad_Click(object sender, EventArgs e)
        {
            if (cmbLaboratorio.SelectedIndex < 0)
            {
                MessageBox.Show("Seleccione un laboratorio", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            try
            {
                Laboratorio_Entidad labSeleccionado = (Laboratorio_Entidad)cmbLaboratorio.SelectedItem;
                DateTime fecha = dtpFecha.Value.Date;

                //Obtener horarios libres
                List<string> horariosLibres = cnReservas.ObtenerHorariosLibres(labSeleccionado.IdLaboratorio, fecha);

                //Mostrar en un MessageBox
                if (horariosLibres.Count > 0)
                {
                    string mensaje = $"Horarios disponibles en {labSeleccionado.NombreLaboratorio} el {fecha:dd/MM/yyyy}:\n\n";
                    mensaje += string.Join("\n", horariosLibres);

                    MessageBox.Show(mensaje, "Disponibilidad",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("No hay horarios disponibles para este día", "Disponibilidad",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MostrarError("Error al consultar disponibilidad", ex.Message);
            }
        }


        //Guardar reserva
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                //Validaciones antes de guardar
                if (cmbLaboratorio.SelectedIndex < 0)
                {
                    MostrarError("Validación", "Debe seleccionar un laboratorio");
                    cmbLaboratorio.Focus();
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtMotivo.Text))
                {
                    MostrarError("Validación", "Debe ingresar el motivo de la reserva");
                    txtMotivo.Focus();
                    return;
                }

                //Verificar advertencias visibles
                if (lblAdvertenciaHorario.Visible || lblAdvertenciaCapacidad.Visible)
                {
                    MostrarError("Validación", "Corrija los errores indicados antes de guardar");
                    return;
                }

                //Confirmar si hay conflicto de disponibilidad
                if (lstReservasConflicto.Visible && lstReservasConflicto.Items.Count > 0)
                {
                    MostrarError("Horario no disponible", "Existe solapamiento de reservas");
                    return;
                }

                //Crea entidad reserva
                Laboratorio_Entidad labSeleccionado = (Laboratorio_Entidad)cmbLaboratorio.SelectedItem;

                Reserva_Entidad nuevaReserva = new Reserva_Entidad
                {
                    IdLaboratorio = labSeleccionado.IdLaboratorio,
                    IdUsuario = UsuarioLoginCache.idUsuario, //Usuario logueado
                    Fecha = dtpFecha.Value.Date,
                    HoraInicio = dtpHoraInicio.Value.TimeOfDay,
                    HoraFin = dtpHoraFin.Value.TimeOfDay,
                    CantidadUsuarios = (int)nudCantidadUsuarios.Value,
                    Motivo = txtMotivo.Text.Trim(),
                    IdEstadoReserva = 1 //Activa
                };

                //Guardar reserva en la base de datos
                int idReservaCreada = cnReservas.CrearReserva(nuevaReserva);

                if (idReservaCreada > 0)
                {
                    MessageBox.Show(
                        $"Reserva creada exitosamente\n\n" +
                        $"Laboratorio: {labSeleccionado.NombreLaboratorio}\n" +
                        $"Fecha: {nuevaReserva.Fecha:dd/MM/yyyy}\n" +
                        $"Horario: {nuevaReserva.HorarioTexto}\n" +
                        $"ID Reserva: {idReservaCreada}",
                        "Éxito",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                    );

                    DialogResult = DialogResult.OK;
                    Close();
                }
                else
                {
                    MostrarError("Error", "No se pudo crear la reserva");
                }
            }
            catch (Exception ex)
            {
                MostrarError("Error al guardar", ex.Message);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult resultado = MessageBox.Show(
                "¿Está seguro de que desea cancelar?",
                "Confirmar",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (resultado == DialogResult.Yes)
            {
                DialogResult = DialogResult.Cancel;
                Close();
            }
        }

        //Métodos auxiliares para mostrar mensajes
        private void MostrarAdvertencia(Label label, string mensaje)
        {
            label.Text = mensaje;
            label.ForeColor = Color.Red;
            label.Visible = true;
        }

        private void MostrarError(string titulo, string mensaje)
        {
            MessageBox.Show(mensaje, titulo, MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }
}
