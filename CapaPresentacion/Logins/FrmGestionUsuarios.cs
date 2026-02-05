using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaNegocio;

namespace CapaPresentacion.Logins
{
    public partial class FrmGestionUsuarios : Form
    {
        private CN_Usuario cnUsuario = new CN_Usuario();

        public FrmGestionUsuarios()
        {
            InitializeComponent();
        }
        private void FrmGestionUsuarios_Load(object sender, EventArgs e)
        {
            CargarCombos();
            CargarUsuarios();

            dgvUsuarios.Columns["idUsuario"].HeaderText = "ID";
            dgvUsuarios.Columns["usuario"].HeaderText = "Usuario";
            dgvUsuarios.Columns["nombreUsuario"].HeaderText = "Nombres y apellidos";
            dgvUsuarios.Columns["idRol"].Visible = false;
            dgvUsuarios.Columns["idEstado"].Visible = false;

        }
        private void CargarCombos()
        {
            // ComboBox de Estados
            cmbFiltroEstado.Items.Clear();
            cmbFiltroEstado.Items.Add("Todos");
            cmbFiltroEstado.Items.Add("Activo");
            cmbFiltroEstado.Items.Add("Inactivo");
            cmbFiltroEstado.SelectedIndex = 0;

            // ComboBox de Roles
            cmbFiltroRol.Items.Clear();
            cmbFiltroRol.Items.Add("Todos");
            cmbFiltroRol.Items.Add("Administrador");
            cmbFiltroRol.Items.Add("Usuario");
            cmbFiltroRol.SelectedIndex = 0;
        }


        private void CargarUsuarios()
        {
            try
            {
                DataTable dt = cnUsuario.listarUsuarios();
                dgvUsuarios.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar usuarios: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void AplicarFiltros()
        {
            try
            {
                string filtroUsuario = string.IsNullOrWhiteSpace(txtFiltroUsuario.Text) ? null : txtFiltroUsuario.Text;
                string filtroNombre = string.IsNullOrWhiteSpace(txtFiltroNombreUsuario.Text) ? null : txtFiltroNombreUsuario.Text;
                string filtroEstado = (cmbFiltroEstado.SelectedItem?.ToString() == "Todos") ? null : cmbFiltroEstado.SelectedItem?.ToString();
                string filtroRol = (cmbFiltroRol.SelectedItem?.ToString() == "Todos") ? null : cmbFiltroRol.SelectedItem?.ToString();

                DataTable dt = cnUsuario.listarUsuarios(filtroUsuario, filtroNombre, filtroEstado, filtroRol);
                dgvUsuarios.DataSource = dt;

                ActualizarContador();
            }
            catch (Exception ex)
            {
                MostrarError("Error al filtrar usuarios", ex.Message);
            }
        }
        private void ActualizarContador()
        {
            int total = dgvUsuarios.Rows.Count;
            lblTotal.Text = $"Total de usuarios: {total}";
        }

        private void MostrarError(string titulo, string mensaje)
        {
            MessageBox.Show(mensaje, titulo, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            AplicarFiltros();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtFiltroNombreUsuario.Clear();
            txtFiltroUsuario.Clear();
            cmbFiltroEstado.SelectedIndex = 0;
            cmbFiltroRol.SelectedIndex = 0;
            CargarUsuarios();
        }


       
    }
}
