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
    public partial class FrmReporteReservas : Form
    {
        private CN_Reservas cnReservas = new CN_Reservas();
        private CN_Laboratorios cnLaboratorios = new CN_Laboratorios();

        public FrmReporteReservas()
        {
            InitializeComponent();
            ConfigurarDataGridView();
        }

        private void FrmReporteReservas_Load(object sender, EventArgs e)
        {
            CargarFiltros();
            CargarReservas();
        }

        //Configuración del DataGridView dgvReservas para mostrar las reservas con columnas personalizadas y formato adecuado.
        private void ConfigurarDataGridView()
        {
            dgvReservas.AutoGenerateColumns = false;
       
            //Definir columnas manualmente
            dgvReservas.Columns.Clear();

            //ID de reserva (oculto, pero útil para detalles o acciones futuras)
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
                Width = 120
            });

            //Horario (calculado)
            dgvReservas.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "HorarioTexto",
                HeaderText = "Horario",
                Name = "colHorario",
                Width = 100
            });

            //Usuario
            dgvReservas.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "NombreUsuario",
                HeaderText = "Usuario",
                Name = "colUsuario",
                Width = 120
            });

            //Cantidad Usuarios
            dgvReservas.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "CantidadUsuarios",
                HeaderText = "Cantidad",
                Name = "colCantidad",
                Width = 70
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
                Width = 90
            });
        }

        //Cargar filtros
        private void CargarFiltros()
        {
            try
            {
                //ComboBox de Laboratorios
                List<Laboratorio_Entidad> laboratorios = cnLaboratorios.getListaLaboratorios();
                cmbFiltroLaboratorio.Items.Clear();
                cmbFiltroLaboratorio.Items.Add("Todos");
                foreach (var lab in laboratorios)
                {
                    cmbFiltroLaboratorio.Items.Add(lab);
                }
                cmbFiltroLaboratorio.DisplayMember = "NombreLaboratorio";
                cmbFiltroLaboratorio.SelectedIndex = 0;

                //ComboBox de Estados
                cmbFiltroEstado.Items.Clear();
                cmbFiltroEstado.Items.Add("Todas");
                cmbFiltroEstado.Items.Add("Activas");
                cmbFiltroEstado.Items.Add("Canceladas");
                cmbFiltroEstado.Items.Add("Finalizadas");
                cmbFiltroEstado.SelectedIndex = 0;

                //ComboBox de Rango de Tiempo
                cmbFiltroTiempo.Items.Clear();
                cmbFiltroTiempo.Items.Add("Todas");
                cmbFiltroTiempo.Items.Add("Futuras");
                cmbFiltroTiempo.Items.Add("Pasadas");
                cmbFiltroTiempo.Items.Add("Hoy");
                cmbFiltroTiempo.Items.Add("Esta semana");
                cmbFiltroTiempo.Items.Add("Este mes");
                cmbFiltroTiempo.SelectedIndex = 0;

                //Configurar DateTimePickers
                dtpFechaDesde.Format = DateTimePickerFormat.Custom;
                dtpFechaDesde.CustomFormat = "dd/MM/yyyy";
                dtpFechaDesde.Value = DateTime.Now.AddMonths(-1); // Último mes por defecto

                dtpFechaHasta.Format = DateTimePickerFormat.Custom;
                dtpFechaHasta.CustomFormat = "dd/MM/yyyy";
                dtpFechaHasta.Value = DateTime.Now;

                //CheckBoxes para activar filtros de fecha
                chkUsarFechaDesde.Checked = false;
                chkUsarFechaHasta.Checked = false;
            }
            catch (Exception ex)
            {
                MostrarError("Error al cargar filtros", ex.Message);
            }
        }

        //Cargar reservas según filtros seleccionados
        private void CargarReservas()
        {
            try
            {
                dgvReservas.DataSource = null;

                //Obtener filtros
                DateTime? fechaDesde = chkUsarFechaDesde.Checked ? dtpFechaDesde.Value.Date : (DateTime?)null;
                DateTime? fechaHasta = chkUsarFechaHasta.Checked ? dtpFechaHasta.Value.Date : (DateTime?)null;

                int? idLaboratorio = null;
                if (cmbFiltroLaboratorio.SelectedIndex > 0)
                {
                    Laboratorio_Entidad lab = (Laboratorio_Entidad)cmbFiltroLaboratorio.SelectedItem;
                    idLaboratorio = lab.IdLaboratorio;
                }

                int? idEstado = null;
                switch (cmbFiltroEstado.SelectedItem?.ToString())
                {
                    case "Activas": idEstado = 1; break;
                    case "Canceladas": idEstado = 2; break;
                    case "Finalizadas": idEstado = 3; break;
                }

                //Cargar todas las reservas
                List<Reserva_Entidad> reservas = cnReservas.ListarReservas(
                    fechaDesde: fechaDesde,
                    fechaHasta: fechaHasta,
                    idLaboratorio: idLaboratorio,
                    idUsuario: null, //Null traerá a todos los usuarios
                    idEstadoReserva: idEstado
                );

                //Aplicar filtro de tiempo
                reservas = AplicarFiltroTiempo(reservas);

                //Ordenar por fecha descendente
                reservas.Sort((a, b) =>
                {
                    int compareFecha = b.Fecha.CompareTo(a.Fecha);
                    if (compareFecha != 0) return compareFecha;
                    return a.HoraInicio.CompareTo(b.HoraInicio);
                });

                dgvReservas.DataSource = reservas;
                dgvReservas.ClearSelection();

                //Pintar filas según estado
                PintarFilasPorEstado();

                ActualizarEstadisticas(reservas);
                ActualizarContador(reservas.Count);
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
                    return reservas.Where(r => r.EsFutura).ToList();

                case "Pasadas":
                    return reservas.Where(r => r.EsPasada).ToList();

                case "Hoy":
                    DateTime hoy = DateTime.Now.Date;
                    return reservas.Where(r => r.Fecha.Date == hoy).ToList();

                case "Esta semana":
                    DateTime inicioSemana = DateTime.Now.Date.AddDays(-(int)DateTime.Now.DayOfWeek + (int)DayOfWeek.Monday);
                    DateTime finSemana = inicioSemana.AddDays(6);
                    return reservas.Where(r => r.Fecha.Date >= inicioSemana && r.Fecha.Date <= finSemana).ToList();

                case "Este mes":
                    DateTime inicioMes = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
                    DateTime finMes = inicioMes.AddMonths(1).AddDays(-1);
                    return reservas.Where(r => r.Fecha.Date >= inicioMes && r.Fecha.Date <= finMes).ToList();

                default: //"Todas"
                    return reservas;
            }
        }

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

        //Estadísticas generales de las reservas mostradas, incluyendo totales, porcentajes y top laboratorios.
        private void ActualizarEstadisticas(List<Reserva_Entidad> reservas)
        {
            int total = reservas.Count;
            int activas = reservas.Count(r => r.EsActiva);
            int canceladas = reservas.Count(r => r.EsCancelada);
            int finalizadas = reservas.Count(r => r.EsFinalizada);

            lblTotalReservas.Text = $"Total: {total}";
            lblActivas.Text = $"Activas: {activas}";
            lblCanceladas.Text = $"Canceladas: {canceladas}";
            lblFinalizadas.Text = $"Finalizadas: {finalizadas}";

            //Porcentajes
            if (total > 0)
            {
                lblPorcentajeActivas.Text = $"({activas * 100.0 / total:0.0}%)";
                lblPorcentajeCanceladas.Text = $"({canceladas * 100.0 / total:0.0}%)";
                lblPorcentajeFinalizadas.Text = $"({finalizadas * 100.0 / total:0.0}%)";
            }
            else
            {
                lblPorcentajeActivas.Text = "(0%)";
                lblPorcentajeCanceladas.Text = "(0%)";
                lblPorcentajeFinalizadas.Text = "(0%)";
            }

            //Colores
            lblActivas.ForeColor = Color.Green;
            lblCanceladas.ForeColor = Color.Red;
            lblFinalizadas.ForeColor = Color.Gray;

            //Estadísticas por laboratorio
            if (reservas.Count > 0)
            {
                var porLab = reservas.GroupBy(r => r.NombreLaboratorio)
                                    .OrderByDescending(g => g.Count())
                                    .Take(3);

                string topLabs = "Top laboratorios: ";
                foreach (var grupo in porLab)
                {
                    topLabs += $"{grupo.Key} ({grupo.Count()}), ";
                }
                lblTopLaboratorios.Text = topLabs.TrimEnd(',', ' ');
            }
            else
            {
                lblTopLaboratorios.Text = "Top laboratorios: -";
            }
        }

        private void ActualizarContador(int total)
        {
            lblContador.Text = $"Mostrando {total} reserva(s)";
        }

        //Filtros y eventos
        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            CargarReservas();
        }

        private void btnLimpiarFiltros_Click(object sender, EventArgs e)
        {
            cmbFiltroLaboratorio.SelectedIndex = 0;
            cmbFiltroEstado.SelectedIndex = 0;
            cmbFiltroTiempo.SelectedIndex = 0;
            chkUsarFechaDesde.Checked = false;
            chkUsarFechaHasta.Checked = false;
            CargarReservas();
        }

        private void cmbFiltroLaboratorio_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarReservas();
        }

        private void cmbFiltroEstado_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarReservas();
        }

        private void cmbFiltroTiempo_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarReservas();
        }

        private void chkUsarFechaDesde_CheckedChanged(object sender, EventArgs e)
        {
            dtpFechaDesde.Enabled = chkUsarFechaDesde.Checked;
            if (chkUsarFechaDesde.Checked)
                CargarReservas();
        }

        private void chkUsarFechaHasta_CheckedChanged(object sender, EventArgs e)
        {
            dtpFechaHasta.Enabled = chkUsarFechaHasta.Checked;
            if (chkUsarFechaHasta.Checked)
                CargarReservas();
        }

        private void dtpFechaDesde_ValueChanged(object sender, EventArgs e)
        {
            if (chkUsarFechaDesde.Checked)
                CargarReservas();
        }

        private void dtpFechaHasta_ValueChanged(object sender, EventArgs e)
        {
            if (chkUsarFechaHasta.Checked)
                CargarReservas();
        }

        //Ver detalles de la reserva seleccionada en un MessageBox con formato legible.
        private void btnVerDetalles_Click(object sender, EventArgs e)
        {
            if (dgvReservas.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccione una reserva para ver detalles.",
                    "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            Reserva_Entidad reserva = (Reserva_Entidad)dgvReservas.CurrentRow.DataBoundItem;
            MostrarDetallesReserva(reserva);
        }

        private void MostrarDetallesReserva(Reserva_Entidad reserva)
        {
            string detalles = $"DETALLES DE LA RESERVA\n\n" +
                $"ID: {reserva.IdReserva}\n" +
                $"Laboratorio: {reserva.NombreLaboratorio}\n" +
                $"Capacidad: {reserva.CapacidadLaboratorio} usuarios\n\n" +
                $"Fecha: {reserva.Fecha:dddd, dd/MM/yyyy}\n" +
                $"Hora Inicio: {reserva.HoraInicio:hh\\:mm}\n" +
                $"Hora Fin: {reserva.HoraFin:hh\\:mm}\n" +
                $"Duración: {reserva.DuracionHoras:0.0} horas\n\n" +
                $"Usuario: {reserva.NombreUsuario}\n" +
                $"Cantidad de Usuarios: {reserva.CantidadUsuarios}\n" +
                $"Motivo: {reserva.Motivo}\n\n" +
                $"Estado: {reserva.NombreEstadoReserva}\n" +
                $"Creada: {reserva.FechaCreacion:dd/MM/yyyy HH:mm}";

            MessageBox.Show(detalles, "Detalles de Reserva",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        //Exportar el reporte actual a un archivo CSV, incluyendo los filtros aplicados y las estadísticas generales.
        private void btnExportar_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvReservas.Rows.Count == 0)
                {
                    MessageBox.Show("No hay reservas para exportar.", "Aviso",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                SaveFileDialog saveDialog = new SaveFileDialog
                {
                    Filter = "Archivo CSV (*.csv)|*.csv|Todos los archivos (*.*)|*.*",
                    FileName = $"Reporte_Reservas_{DateTime.Now:yyyyMMdd_HHmmss}.csv"
                };

                if (saveDialog.ShowDialog() == DialogResult.OK)
                {
                    List<Reserva_Entidad> reservas = (List<Reserva_Entidad>)dgvReservas.DataSource;

                    using (System.IO.StreamWriter file = new System.IO.StreamWriter(saveDialog.FileName))
                    {
                        //Encabezados
                        file.WriteLine("ID;Fecha;Hora Inicio;Hora Fin;Duración (hrs);Laboratorio;Usuario;Cantidad;Motivo;Estado");

                        // Datos
                        foreach (var r in reservas)
                        {
                            file.WriteLine($"{r.IdReserva};" +
                                          $"{r.Fecha:dd/MM/yyyy};" +
                                          $"{r.HoraInicio:hh\\:mm};" +
                                          $"{r.HoraFin:hh\\:mm};" +
                                          $"{r.DuracionHoras:0.0};" +
                                          $"\"{r.NombreLaboratorio}\";" +
                                          $"\"{r.NombreUsuario}\";" +
                                          $"{r.CantidadUsuarios};" +
                                          $"\"{r.Motivo}\";" +
                                          $"{r.NombreEstadoReserva}");
                        }
                    }

                    MessageBox.Show($"Reporte exportado exitosamente:\n{saveDialog.FileName}\n\n" +
                                   $"Total de registros: {reservas.Count}",
                        "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MostrarError("Error al exportar", ex.Message);
            }
        }


        //Refrescar el reporte con los datos más recientes de la base de datos, manteniendo los filtros aplicados.
        private void btnRefrescar_Click(object sender, EventArgs e)
        {
            CargarReservas();
        }

        private void MostrarError(string titulo, string mensaje)
        {
            MessageBox.Show(mensaje, titulo, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
