using CapaEntidad.Clases;
using CapaNegocio.Laboratorios;
using CapaPresentacion.Formularios;
using System;
using System.Data;
namespace CapaPresentacion
{
    public partial class FrmLaboratorios : Form
    {
        private CN_Laboratorios cnLaboratorios = new CN_Laboratorios();

        public FrmLaboratorios()
        {
            InitializeComponent();
        }

        private void FrmLaboratorios_Load(object sender, EventArgs e)
        {
            cargarLaboratorios();
            ConfigurarDataGridView();

        }

        private void ConfigurarDataGridView()
        {
            // Configuración general
            dgvTablaLaboratorios.AutoGenerateColumns = false;
            dgvTablaLaboratorios.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvTablaLaboratorios.MultiSelect = false;
            dgvTablaLaboratorios.ReadOnly = true;
            dgvTablaLaboratorios.AllowUserToAddRows = false;
            dgvTablaLaboratorios.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // Definir columnas manualmente
            dgvTablaLaboratorios.Columns.Clear();

            // Columna ID
            dgvTablaLaboratorios.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "IdLaboratorio",
                HeaderText = "ID",
                Name = "colIdLaboratorio",
                Width = 50,
            });

            // Columna Nombre
            dgvTablaLaboratorios.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "NombreLaboratorio",
                HeaderText = "Nombre del Laboratorio",
                Name = "colNombre",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            });

            // Columna Capacidad
            dgvTablaLaboratorios.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Capacidad",
                HeaderText = "Capacidad",
                Name = "colCapacidad",
                Width = 100
            });

            /*
            dgvTablaLaboratorios.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "NombreEstado",
                HeaderText = "Estado",
                Name = "colEstado",
                Width = 100
            });
            */
        }

        private void cargarLaboratorios()
        {
            try
            {
                dgvTablaLaboratorios.DataSource = null;

                //Obtener lista de entidades
                List<Laboratorio_Entidad> listaLaboratorios = cnLaboratorios.getListaLaboratorios();
                dgvTablaLaboratorios.DataSource = listaLaboratorios;
                dgvTablaLaboratorios.ClearSelection();

                //Contador de laboratorios.
                lblTotalLaboratorios.Text = $"Total: {listaLaboratorios.Count} laboratorios";
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private void btnAgregarLaboratorio_Click(object sender, EventArgs e)
        {
            FrmCrearEditarLabs frm = new FrmCrearEditarLabs();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                cargarLaboratorios();
            }
        }

        private void btnEditarLaboratorio_Click(object sender, EventArgs e)
        {
            if (dgvTablaLaboratorios.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccione un laboratorio para editar.",
                    "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            try
            {
                //Obtiene la entidad del DataBoundItem.
                Laboratorio_Entidad laboratorio = (Laboratorio_Entidad)dgvTablaLaboratorios.CurrentRow.DataBoundItem;

                //Abrir formulario de edición pasando la entidad.
                FrmCrearEditarLabs frm = new FrmCrearEditarLabs(laboratorio);

                if (frm.ShowDialog() == DialogResult.OK)
                {
                    cargarLaboratorios();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al editar laboratorio: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEliminarLaboratorio_Click(object sender, EventArgs e)
        {
            if (dgvTablaLaboratorios.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccione un laboratorio para eliminar.",
                    "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            try
            {
                //Obtener la entidad seleccionada
                Laboratorio_Entidad laboratorio = (Laboratorio_Entidad)dgvTablaLaboratorios.CurrentRow.DataBoundItem;

                DialogResult result = MessageBox.Show(
                    $"¿Está seguro de que desea eliminar el laboratorio '{laboratorio.NombreLaboratorio}'?",
                    "Confirmar eliminación",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning
                );

                if (result == DialogResult.Yes)
                {
                    bool eliminado = cnLaboratorios.eliminarLaboratorio(laboratorio.IdLaboratorio);

                    if (eliminado)
                    {
                        MessageBox.Show("Laboratorio eliminado correctamente",
                            "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        cargarLaboratorios();
                    }
                    else
                    {
                        MessageBox.Show("No se pudo eliminar el laboratorio",
                            "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al eliminar: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}