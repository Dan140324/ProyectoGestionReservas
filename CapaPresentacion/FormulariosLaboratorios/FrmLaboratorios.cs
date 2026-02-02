using CapaNegocio.Laboratorios;
using System;
using System.Data;
using CapaPresentacion.Formularios;
namespace CapaPresentacion
{
    public partial class FrmLaboratorios : Form
    {
        private CN_Laboratorios cnLaboratorios = new CN_Laboratorios();

        public FrmLaboratorios()
        {
            InitializeComponent();
            cargarLaboratorios();

        }

        private void FrmLaboratorios_Load(object sender, EventArgs e)
        {
            cargarLaboratorios();

        }

        private void cargarLaboratorios()
        {
            try
            {
                dgvTablaLaboratorios.DataSource = null;
                DataTable dt = cnLaboratorios.getListaLaboratorios();
                dgvTablaLaboratorios.DataSource = dt;

                dgvTablaLaboratorios.Columns["idLaboratorio"].HeaderText = "ID";
                dgvTablaLaboratorios.Columns["nombre"].HeaderText = "Nombre del Laboratorio";
                dgvTablaLaboratorios.Columns["capacidad"].HeaderText = "Capacidad";

                dgvTablaLaboratorios.ClearSelection();


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
                MessageBox.Show("Seleccione un laboratorio para editar.");
                return;
            }
            int id = Convert.ToInt32(dgvTablaLaboratorios.CurrentRow.Cells["idLaboratorio"].Value);
            string nombre = dgvTablaLaboratorios.CurrentRow.Cells["nombre"].Value.ToString();
            int capacidad = Convert.ToInt32(dgvTablaLaboratorios.CurrentRow.Cells["capacidad"].Value);

            FrmCrearEditarLabs frm = new FrmCrearEditarLabs(id, nombre, capacidad);

            if (frm.ShowDialog() == DialogResult.OK)
            {
                cargarLaboratorios();
            }

        }

        private void btnEliminarLaboratorio_Click(object sender, EventArgs e)
        {
            if (dgvTablaLaboratorios.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccione un laboratorio para eliminar.");
                return;
            }
            int id = Convert.ToInt32(dgvTablaLaboratorios.CurrentRow.Cells["idLaboratorio"].Value);
            string nombre = dgvTablaLaboratorios.CurrentRow.Cells["nombre"].Value.ToString();
            DialogResult result = MessageBox.Show(
                $"¿Está seguro de que desea eliminar el laboratorio '{nombre}'?",
                "Confirmar eliminación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
            );
            if (result == DialogResult.Yes)
            {
                CN_Laboratorios cn = new CN_Laboratorios();
                cn.eliminarLaboratorio(id);

                MessageBox.Show("Laboratorio eliminado correctamente");
                cargarLaboratorios();
            }
        }
    }
}