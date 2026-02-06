using CapaComun;
using CapaEntidad.Clases;
using CapaNegocio;
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
    public partial class FrmMisReservas : Form
    {
        private CN_Reservas cnReservas = new CN_Reservas();

        public FrmMisReservas()
        {
            InitializeComponent();
            ConfigurarDataGridView();
        }

        private void FrmMisReservas_Load(object sender, EventArgs e)
        {
            FinalizarReservasPasadas(); //Asegurar que las reservas pasadas se marquen como finalizadas al cargar el formulario
            CargarFiltros();
            CargarMisReservas();
            MostrarInfoUsuario();
        }

        //Confguración inicial
        //Configura el DataGridView para mostrar las reservas con las columnas necesarias y formato adecuado
        private void ConfigurarDataGridView()
        {
            dgvReservas.AutoGenerateColumns = false;
            
            //Definir columnas manualmente
            dgvReservas.Columns.Clear();

            //ID (oculto)
            dgvReservas.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "IdReserva",
                HeaderText = "ID",
                Name = "colIdReserva",
                Width = 50,
                Visible = false
            });

            //Fecha
            dgvReservas.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Fecha",
                HeaderText = "Fecha",
                Name = "colFecha",
                Width = 100,
                DefaultCellStyle = new DataGridViewCellStyle { Format = "dd/MM/yyyy" }
            });

            //Laboratorio
            dgvReservas.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "NombreLaboratorio",
                HeaderText = "Laboratorio",
                Name = "colLaboratorio",
                Width = 150
            });

            //Horario
            dgvReservas.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "HorarioTexto",
                HeaderText = "Horario",
                Name = "colHorario",
                Width = 120
            });

            //Cantidad Usuarios
            dgvReservas.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "CantidadUsuarios",
                HeaderText = "Usuarios",
                Name = "colCantidad",
                Width = 80
            });

            //Motivo
            dgvReservas.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Motivo",
                HeaderText = "Motivo",
                Name = "colMotivo",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            });

            //Estado
            dgvReservas.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "NombreEstadoReserva",
                HeaderText = "Estado",
                Name = "colEstado",
                Width = 100
            });

            //Columnas ocultas para uso interno
            dgvReservas.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "IdLaboratorio",
                Name = "colIdLaboratorio",
                Visible = false
            });

            dgvReservas.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "IdEstadoReserva",
                Name = "colIdEstado",
                Visible = false
            });
        }

        //Cargar filtros iniciales
        private void CargarFiltros()
        {
            //ComboBox de Estados
            cmbFiltroEstado.Items.Clear();
            cmbFiltroEstado.Items.Add("Todas");
            cmbFiltroEstado.Items.Add("Activas");
            cmbFiltroEstado.Items.Add("Canceladas");
            cmbFiltroEstado.Items.Add("Finalizadas");
            cmbFiltroEstado.SelectedIndex = 0;

            //ComboBox de Tiempo
            cmbFiltroTiempo.Items.Clear();
            cmbFiltroTiempo.Items.Add("Todas");
            cmbFiltroTiempo.Items.Add("Futuras");
            cmbFiltroTiempo.Items.Add("Pasadas");
            cmbFiltroTiempo.Items.Add("Hoy");
            cmbFiltroTiempo.SelectedIndex = 0;

            //Configurar DateTimePickers
            dtpFechaDesde.Format = DateTimePickerFormat.Custom;
            dtpFechaDesde.CustomFormat = "dd/MM/yyyy";
            dtpFechaDesde.Checked = false;

            dtpFechaHasta.Format = DateTimePickerFormat.Custom;
            dtpFechaHasta.CustomFormat = "dd/MM/yyyy";
            dtpFechaHasta.Checked = false;
        }

        private void MostrarInfoUsuario()
        {
            lblInfoUsuario.Text = $"Reservas de: {UsuarioLoginCache.nombreUsuario}";
        }


        //Carga reservas del usuario actual aplicando los filtros seleccionados
        private void CargarMisReservas()
        {
            try
            {
                dgvReservas.DataSource = null;

                //Obtener filtros
                DateTime? fechaDesde = dtpFechaDesde.Checked ? dtpFechaDesde.Value.Date : (DateTime?)null;
                DateTime? fechaHasta = dtpFechaHasta.Checked ? dtpFechaHasta.Value.Date : (DateTime?)null;

                int? idEstado = null;
                switch (cmbFiltroEstado.SelectedItem?.ToString())
                {
                    case "Activas": idEstado = 1; break;
                    case "Canceladas": idEstado = 2; break;
                    case "Finalizadas": idEstado = 3; break;
                }

                //Cargar reservas del usuario actual
                List<Reserva_Entidad> misReservas = cnReservas.ListarReservas(
                    fechaDesde: fechaDesde,
                    fechaHasta: fechaHasta,
                    idLaboratorio: null,
                    idUsuario: UsuarioLoginCache.idUsuario, //Filtrar por usuario actual
                    idEstadoReserva: idEstado
                );

                //Aplicar filtro de tiempo
                misReservas = AplicarFiltroTiempo(misReservas);

                //Ordenar por fecha
                misReservas.Sort((a, b) => b.Fecha.CompareTo(a.Fecha));

                dgvReservas.DataSource = misReservas;
                dgvReservas.ClearSelection();

                //Pintar filas según estado
                PintarFilasPorEstado();

                ActualizarContador();
                ActualizarEstadoBotones();
            }
            catch (Exception ex)
            {
                MostrarError("Error al cargar reservas", ex.Message);
            }
        }

        private List<Reserva_Entidad> AplicarFiltroTiempo(List<Reserva_Entidad> reservas)
        {
            string filtroTiempo = cmbFiltroTiempo.SelectedItem?.ToString();

            switch (filtroTiempo)
            {
                case "Futuras":
                    return reservas.FindAll(r => r.EsFutura);

                case "Pasadas":
                    return reservas.FindAll(r => r.EsPasada);

                case "Hoy":
                    DateTime hoy = DateTime.Now.Date;
                    return reservas.FindAll(r => r.Fecha.Date == hoy);

                default: //"Todas"
                    return reservas;
            }
        }

        //Pinta las filas del DataGridView según el estado de la reserva para mejorar la visualización
        private void PintarFilasPorEstado()
        {
            foreach (DataGridViewRow row in dgvReservas.Rows)
            {
                Reserva_Entidad reserva = (Reserva_Entidad)row.DataBoundItem;

                if (reserva.EsActiva)
                {
                    row.DefaultCellStyle.BackColor = Color.LightGreen;
                    row.DefaultCellStyle.ForeColor = Color.Black;
                }
                else if (reserva.EsCancelada)
                {
                    row.DefaultCellStyle.BackColor = Color.LightCoral;
                    row.DefaultCellStyle.ForeColor = Color.Black;
                }
                else if (reserva.EsFinalizada)
                {
                    row.DefaultCellStyle.BackColor = Color.LightGray;
                    row.DefaultCellStyle.ForeColor = Color.Black;
                }
            }
        }


        //Filtros
        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            CargarMisReservas();
        }

        private void btnLimpiarFiltros_Click(object sender, EventArgs e)
        {
            cmbFiltroEstado.SelectedIndex = 0;
            cmbFiltroTiempo.SelectedIndex = 0;
            dtpFechaDesde.Checked = false;
            dtpFechaHasta.Checked = false;
            CargarMisReservas();
        }

        private void cmbFiltroEstado_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Aplicar filtro automáticamente
            CargarMisReservas();
        }

        private void cmbFiltroTiempo_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Aplicar filtro automáticamente
            CargarMisReservas();
        }

        //Acciones sobre reservas
        private void btnEditarReserva_Click(object sender, EventArgs e)
        {
            if (dgvReservas.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccione una reserva para editar.",
                    "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            try
            {
                Reserva_Entidad reservaSeleccionada = (Reserva_Entidad)dgvReservas.CurrentRow.DataBoundItem;

                //Validar que esté activa
                if (!reservaSeleccionada.EsActiva)
                {
                    MessageBox.Show($"No se puede editar una reserva con estado: {reservaSeleccionada.NombreEstadoReserva}",
                        "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                //Validar que no sea pasada
                if (reservaSeleccionada.EsPasada)
                {
                    MessageBox.Show("No se puede editar una reserva que ya pasó.",
                        "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                //Obtener reserva completa de la BD
                Reserva_Entidad reservaCompleta = cnReservas.ObtenerReservaPorId(reservaSeleccionada.IdReserva);

                //Abrir formulario de edición
                FrmEditarReserva frm = new FrmEditarReserva(reservaCompleta);

                if (frm.ShowDialog() == DialogResult.OK)
                {
                    CargarMisReservas();
                    MessageBox.Show("Reserva actualizada correctamente",
                        "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MostrarError("Error al editar reserva", ex.Message);
            }
        }

        private void btnCancelarReserva_Click(object sender, EventArgs e)
        {
            if (dgvReservas.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccione una reserva para cancelar.",
                    "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            try
            {
                Reserva_Entidad reserva = (Reserva_Entidad)dgvReservas.CurrentRow.DataBoundItem;

                //Validar que esté activa
                if (!reserva.EsActiva)
                {
                    MessageBox.Show($"Solo se pueden cancelar reservas activas. Estado actual: {reserva.NombreEstadoReserva}",
                        "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                //Confirmar cancelación
                DialogResult resultado = MessageBox.Show(
                    $"¿Está seguro de que desea cancelar esta reserva?\n\n" +
                    $"Laboratorio: {reserva.NombreLaboratorio}\n" +
                    $"Fecha: {reserva.Fecha:dd/MM/yyyy}\n" +
                    $"Horario: {reserva.HorarioTexto}\n" +
                    $"Motivo: {reserva.Motivo}\n\n" +
                    $"Esta acción no se puede deshacer.",
                    "Confirmar Cancelación",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

                if (resultado == DialogResult.Yes)
                {
                    bool cancelado = cnReservas.CancelarReserva(reserva.IdReserva);

                    if (cancelado)
                    {
                        MessageBox.Show("Reserva cancelada correctamente",
                            "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        CargarMisReservas();
                    }
                    else
                    {
                        MostrarError("Error", "No se pudo cancelar la reserva");
                    }
                }
            }
            catch (Exception ex)
            {
                MostrarError("Error al cancelar reserva", ex.Message);
            }
        }

        //Abre formulario para crear nueva reserva
        private void btnNuevaReserva_Click(object sender, EventArgs e)
        {
            try
            {
                FrmCrearReserva frm = new FrmCrearReserva();

                if (frm.ShowDialog() == DialogResult.OK)
                {
                    CargarMisReservas();
                    MessageBox.Show("Reserva creada correctamente",
                        "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MostrarError("Error al crear reserva", ex.Message);
            }
        }


        //Muestra detalles de la reserva seleccionada
        private void btnVerDetalles_Click(object sender, EventArgs e)
        {
            if (dgvReservas.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccione una reserva para ver detalles.",
                    "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            try
            {
                Reserva_Entidad reserva = (Reserva_Entidad)dgvReservas.CurrentRow.DataBoundItem;

                string detalles = $"DETALLES DE LA RESERVA\n\n" +
                    $"ID: {reserva.IdReserva}\n" +
                    $"Laboratorio: {reserva.NombreLaboratorio}\n" +
                    $"Capacidad: {reserva.CapacidadLaboratorio} usuarios\n\n" +
                    $"Fecha: {reserva.Fecha:dddd, dd/MM/yyyy}\n" +
                    $"Hora Inicio: {reserva.HoraInicio:hh\\:mm}\n" +
                    $"Hora Fin: {reserva.HoraFin:hh\\:mm}\n" +
                    $"Duración: {reserva.DuracionHoras:0.0} horas\n\n" +
                    $"Cantidad de Usuarios: {reserva.CantidadUsuarios}\n" +
                    $"Motivo: {reserva.Motivo}\n\n" +
                    $"Estado: {reserva.NombreEstadoReserva}\n" +
                    $"Creada: {reserva.FechaCreacion:dd/MM/yyyy HH:mm}";

                MessageBox.Show(detalles, "Detalles de Reserva",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MostrarError("Error al ver detalles", ex.Message);
            }
        }

        //Eventos del DataGridView
        private void dgvReservas_SelectionChanged(object sender, EventArgs e)
        {
            ActualizarEstadoBotones();
        }

        private void dgvReservas_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                btnVerDetalles_Click(sender, e);
            }
        }

        //Métodos auxiliares
        //Finaliza automáticamente las reservas que ya pasaron al cargar el formulario
        private void FinalizarReservasPasadas()
        {
            try
            {
                cnReservas.FinalizarReservasPasadasAutomaticamente();
            }
            catch { }
        }

        private void ActualizarContador()
        {
            int total = dgvReservas.Rows.Count;
            int activas = 0, canceladas = 0, finalizadas = 0;

            foreach (DataGridViewRow row in dgvReservas.Rows)
            {
                Reserva_Entidad reserva = (Reserva_Entidad)row.DataBoundItem;
                if (reserva.EsActiva) activas++;
                else if (reserva.EsCancelada) canceladas++;
                else if (reserva.EsFinalizada) finalizadas++;
            }

            lblContador.Text = $"Total: {total} | Activas: {activas} | Canceladas: {canceladas} | Finalizadas: {finalizadas}";
        }

        private void ActualizarEstadoBotones()
        {
            if (dgvReservas.SelectedRows.Count == 0)
            {
                btnEditarReserva.Enabled = false;
                btnCancelarReserva.Enabled = false;
                btnVerDetalles.Enabled = false;
                return;
            }

            Reserva_Entidad reserva = (Reserva_Entidad)dgvReservas.CurrentRow.DataBoundItem;

            //Editar solo activas y futuras
            btnEditarReserva.Enabled = reserva.EsActiva && !reserva.EsPasada;

            //Cancelar solo activas
            btnCancelarReserva.Enabled = reserva.EsActiva;

            btnVerDetalles.Enabled = true;
        }

        private void btnRefrescar_Click(object sender, EventArgs e)
        {
            CargarMisReservas();
        }

        private void MostrarError(string titulo, string mensaje)
        {
            MessageBox.Show(mensaje, titulo, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
