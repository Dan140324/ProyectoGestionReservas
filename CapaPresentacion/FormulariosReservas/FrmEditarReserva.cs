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
    public partial class FrmEditarReserva : Form
    {
        private CN_Reservas cnReservas = new CN_Reservas();
        private CN_Laboratorios cnLaboratorios = new CN_Laboratorios();
        private Reserva_Entidad reservaActual;

        public FrmEditarReserva(Reserva_Entidad reserva)
        {
            InitializeComponent();
            reservaActual = reserva;
        }

        private void FrmEditarReserva_Load(object sender, EventArgs e)
        {
            CargarLaboratorios();
            ConfigurarControles();
            CargarDatosReserva();
        }

        //Configura los controles del formulario (DateTimePickers, NumericUpDown, TextBox, Labels)
        private void ConfigurarControles()
        {
            dtpFecha.MinDate = DateTime.Now.Date;
            dtpFecha.MaxDate = DateTime.Now.AddMonths(3);
            dtpFecha.Format = DateTimePickerFormat.Custom;
            dtpFecha.CustomFormat = "dd/MM/yyyy";

            dtpHoraInicio.Format = DateTimePickerFormat.Custom;
            dtpHoraInicio.CustomFormat = "HH:mm";
            dtpHoraInicio.ShowUpDown = true;

            dtpHoraFin.Format = DateTimePickerFormat.Custom;
            dtpHoraFin.CustomFormat = "HH:mm";
            dtpHoraFin.ShowUpDown = true;

            nudCantidadUsuarios.Minimum = 1;
            nudCantidadUsuarios.Maximum = 100;

            txtMotivo.MaxLength = 200;

            lblAdvertenciaDisponibilidad.Visible = false;
            lblAdvertenciaCapacidad.Visible = false;
            lblAdvertenciaHorario.Visible = false;
            lblDuracion.Text = "";
        }

        //Carga la lista de laboratorios en el ComboBox
        private void CargarLaboratorios()
        {
            try
            {
                List<Laboratorio_Entidad> laboratorios = cnLaboratorios.getListaLaboratorios();

                cmbLaboratorio.DataSource = null;
                cmbLaboratorio.DataSource = laboratorios;
                cmbLaboratorio.DisplayMember = "NombreLaboratorio";
                cmbLaboratorio.ValueMember = "IdLaboratorio";
            }
            catch (Exception ex)
            {
                MostrarError("Error al cargar laboratorios", ex.Message);
            }
        }

        //Carga los datos de la reserva en los controles para su edición
        private void CargarDatosReserva()
        {
            try
            {
                lblIdReserva.Text = $"Editando Reserva #{reservaActual.IdReserva}";

                cmbLaboratorio.SelectedValue = reservaActual.IdLaboratorio;

                dtpFecha.Value = reservaActual.Fecha.Date;

                dtpHoraInicio.Value = DateTime.Today.Add(reservaActual.HoraInicio);
                dtpHoraFin.Value = DateTime.Today.Add(reservaActual.HoraFin);

                nudCantidadUsuarios.Value = reservaActual.CantidadUsuarios;

                txtMotivo.Text = reservaActual.Motivo;

                lblInfoOriginal.Text = $"Reserva original: {reservaActual.Fecha:dd/MM/yyyy} {reservaActual.HorarioTexto} - {reservaActual.NombreLaboratorio}";
            }
            catch (Exception ex)
            {
                MostrarError("Error al cargar datos", ex.Message);
            }
        }

        //Valida la disponibilidad del horario seleccionado en tiempo real, mostrando advertencias y conflictos si los hay
        private void cmbLaboratorio_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbLaboratorio.SelectedIndex >= 0)
            {
                Laboratorio_Entidad labSeleccionado = (Laboratorio_Entidad)cmbLaboratorio.SelectedItem;

                //Mostrar capacidad del laboratorio
                lblCapacidadLab.Text = $"Capacidad: {labSeleccionado.Capacidad} usuarios";

                //Actualizar máximo del NumericUpDown
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
            //Ajustar automáticamente la hora fin si es necesaria
            if (dtpHoraFin.Value <= dtpHoraInicio.Value)
            {
                dtpHoraFin.Value = dtpHoraInicio.Value.AddHours(1);
            }

            MostrarDuracion();

            ValidarHorario();

            ValidarDisponibilidadEnTiempoReal();
        }

        private void dtpHoraFin_ValueChanged(object sender, EventArgs e)
        {
            MostrarDuracion();

            ValidarHorario();

            ValidarDisponibilidadEnTiempoReal();
        }

        private void nudCantidadUsuarios_ValueChanged(object sender, EventArgs e)
        {
            ValidarCapacidad();
        }

        private void txtMotivo_TextChanged(object sender, EventArgs e)
        {
            //Mostrar contador de caracteres
            lblContadorMotivo.Text = $"{txtMotivo.Text.Length}/200";
        }

        //Métodos de validación y visualización de advertencias
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

            // Validar duración mínima (30 minutos)
            if (duracion.TotalHours < 0.5)
            {
                MostrarAdvertencia(lblAdvertenciaHorario, "La duración mínima es de 30 minutos");
                return;
            }

            // Validar duración máxima (8 horas)
            if (duracion.TotalHours > 8)
            {
                MostrarAdvertencia(lblAdvertenciaHorario, "La duración máxima es de 8 horas");
                return;
            }

            // Todo OK
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
                MostrarAdvertencia(lblAdvertenciaCapacidad,
                    $"La cantidad ({cantidadUsuarios}) excede la capacidad del laboratorio ({labSeleccionado.Capacidad})");
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

                //Verificar si está disponible
                bool disponible = cnReservas.EstaDisponible(
                    labSeleccionado.IdLaboratorio,
                    fecha,
                    horaInicio,
                    horaFin,
                    reservaActual.IdReserva //Excluir esta reserva de la validación
                );

                if (!disponible)
                {
                    //Obtener reservas que se solapan
                    List<Reserva_Entidad> reservasConflicto = cnReservas.ConsultarDisponibilidad(
                        labSeleccionado.IdLaboratorio, fecha
                    );

                    //Filtrar solo las que se solapan (excluyendo la actual)
                    List<Reserva_Entidad> solapadas = new List<Reserva_Entidad>();
                    foreach (var reserva in reservasConflicto)
                    {
                        //Excluir la reserva actual
                        if (reserva.IdReserva == reservaActual.IdReserva)
                            continue;

                        if (reserva.HoraInicio < horaFin && reserva.HoraFin > horaInicio)
                        {
                            solapadas.Add(reserva);
                        }
                    }

                    if (solapadas.Count > 0)
                    {
                        //Mostrar advertencia
                        MostrarAdvertencia(lblAdvertenciaDisponibilidad,
                            $"Horario NO disponible. {solapadas.Count} reserva(s) en conflicto:");

                        //Mostrar reservas en conflicto en el ListBox
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
                        //No hay conflictos reales
                        lblAdvertenciaDisponibilidad.Text = "✓ Horario disponible";
                        lblAdvertenciaDisponibilidad.ForeColor = Color.Green;
                        lblAdvertenciaDisponibilidad.Visible = true;
                        lstReservasConflicto.Visible = false;
                    }
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

        //Permite al usuario ver los horarios disponibles para el laboratorio y fecha seleccionados, mostrando un mensaje con la información
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
                List<string> horariosLibres = cnReservas.ObtenerHorariosLibres(
                    labSeleccionado.IdLaboratorio, fecha
                );

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

        //Valida los datos ingresados por el usuario, actualiza la entidad reserva y guarda
        //los cambios en la base de datos, mostrando mensajes de éxito o error según corresponda
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                //Validar campos obligatorios
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

                //Verificar advertencias visibles (validaciones fallidas)
                if (lblAdvertenciaHorario.Visible || lblAdvertenciaCapacidad.Visible)
                {
                    MostrarError("Validación", "Corrija los errores indicados antes de guardar");
                    return;
                }

                //Confirmar si no hay cambios
                if (!HayCambios())
                {
                    MessageBox.Show("No hay cambios para guardar", "Aviso",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                //Confirmar si hay conflicto de disponibilidad
                if (lstReservasConflicto.Visible && lstReservasConflicto.Items.Count > 0)
                {
                    MostrarError("Cruce de horarios", "Existe solapamiento entre reservas.");
                    return;
                }

                //Actualizar entidad reserva con los nuevos datos
                Laboratorio_Entidad labSeleccionado = (Laboratorio_Entidad)cmbLaboratorio.SelectedItem;

                reservaActual.IdLaboratorio = labSeleccionado.IdLaboratorio;
                reservaActual.Fecha = dtpFecha.Value.Date;
                reservaActual.HoraInicio = dtpHoraInicio.Value.TimeOfDay;
                reservaActual.HoraFin = dtpHoraFin.Value.TimeOfDay;
                reservaActual.CantidadUsuarios = (int)nudCantidadUsuarios.Value;
                reservaActual.Motivo = txtMotivo.Text.Trim();

                //Guardar cambios en la base de datos
                bool actualizado = cnReservas.ActualizarReserva(reservaActual);

                if (actualizado)
                {
                    MessageBox.Show(
                        $"Reserva actualizada exitosamente\n\n" +
                        $"Laboratorio: {labSeleccionado.NombreLaboratorio}\n" +
                        $"Fecha: {reservaActual.Fecha:dd/MM/yyyy}\n" +
                        $"Horario: {reservaActual.HorarioTexto}",
                        "Éxito",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                    );

                    DialogResult = DialogResult.OK;
                    Close();
                }
                else
                {
                    MostrarError("Error", "No se pudo actualizar la reserva");
                }
            }
            catch (Exception ex)
            {
                MostrarError("Error al guardar", ex.Message);
            }
        }

        private bool HayCambios()
        {
            Laboratorio_Entidad labSeleccionado = (Laboratorio_Entidad)cmbLaboratorio.SelectedItem;

            return reservaActual.IdLaboratorio != labSeleccionado.IdLaboratorio ||
                   reservaActual.Fecha.Date != dtpFecha.Value.Date ||
                   reservaActual.HoraInicio != dtpHoraInicio.Value.TimeOfDay ||
                   reservaActual.HoraFin != dtpHoraFin.Value.TimeOfDay ||
                   reservaActual.CantidadUsuarios != (int)nudCantidadUsuarios.Value ||
                   reservaActual.Motivo != txtMotivo.Text.Trim();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            if (HayCambios())
            {
                DialogResult resultado = MessageBox.Show(
                    "Hay cambios sin guardar. ¿Está seguro de que desea cancelar?",
                    "Confirmar",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

                if (resultado == DialogResult.No)
                    return;
            }

            DialogResult = DialogResult.Cancel;
            Close();
        }

        //Método auxiliar para mostrar advertencias en los Labels correspondientes
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
