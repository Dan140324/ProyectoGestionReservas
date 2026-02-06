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

namespace CapaPresentacion.Logins
{
    public partial class FrmGestionUsuarios : Form
    {
        private CN_Usuario cnUsuario = new CN_Usuario();

        public FrmGestionUsuarios()
        {
            InitializeComponent();
            ConfigurarDataGridView();
        }

        private void FrmGestionUsuarios_Load(object sender, EventArgs e)
        {
            CargarCombos();
            CargarUsuarios();
        }

        //Método para configurar el DataGridView dgvUsuarios y sus columnas
        private void ConfigurarDataGridView()
        {
            dgvUsuarios.AutoGenerateColumns = false;
     
            //Definir columnas manualmente
            dgvUsuarios.Columns.Clear();

            dgvUsuarios.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "IdUsuario",
                HeaderText = "ID",
                Name = "colIdUsuario",
                Width = 50,
                Visible = false
            });

            dgvUsuarios.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Usuario",
                HeaderText = "Usuario",
                Name = "colUsuario",
                Width = 120
            });

            dgvUsuarios.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "NombreUsuario",
                HeaderText = "Nombre Completo",
                Name = "colNombreUsuario",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            });

            dgvUsuarios.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "NombreRol",
                HeaderText = "Rol",
                Name = "colRol",
                Width = 120
            });

            dgvUsuarios.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "NombreEstado",
                HeaderText = "Estado",
                Name = "colEstado",
                Width = 100
            });

            //Columnas de ID ocultas para uso interno
            dgvUsuarios.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "IdRol",
                HeaderText = "IdRol",
                Name = "colIdRol",
                Visible = false
            });

            dgvUsuarios.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "IdEstado",
                HeaderText = "IdEstado",
                Name = "colIdEstado",
                Visible = false
            });
        }


        //Método para cargar los combos de filtro
        private void CargarCombos()
        {
            cmbFiltroEstado.Items.Clear();
            cmbFiltroEstado.Items.Add("Todos");
            cmbFiltroEstado.Items.Add("Activo");
            cmbFiltroEstado.Items.Add("Inactivo");
            cmbFiltroEstado.SelectedIndex = 0;

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
                dgvUsuarios.DataSource = null;
                List<Usuario_Entidad> listaUsuarios = cnUsuario.ListarUsuarios();
                dgvUsuarios.DataSource = listaUsuarios;
                dgvUsuarios.ClearSelection();
                ActualizarContador();
            }
            catch (Exception ex)
            {
                MostrarError("Error al cargar usuarios", ex.Message);
            }
        }

        //Aplicar filtros según los valores seleccionados en los controles de filtro
        private void AplicarFiltros()
        {
            try
            {
                string filtroUsuario = string.IsNullOrWhiteSpace(txtFiltroUsuario.Text) ? null : txtFiltroUsuario.Text;
                string filtroNombre = string.IsNullOrWhiteSpace(txtFiltroNombreUsuario.Text) ? null : txtFiltroNombreUsuario.Text;
                string filtroEstado = (cmbFiltroEstado.SelectedItem?.ToString() == "Todos") ? null : cmbFiltroEstado.SelectedItem?.ToString();
                string filtroRol = (cmbFiltroRol.SelectedItem?.ToString() == "Todos") ? null : cmbFiltroRol.SelectedItem?.ToString();

                List<Usuario_Entidad> listaUsuarios = cnUsuario.ListarUsuarios(filtroUsuario, filtroNombre, filtroEstado, filtroRol);
                dgvUsuarios.DataSource = null;
                dgvUsuarios.DataSource = listaUsuarios;
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

        private void btnEditarUsuario_Click(object sender, EventArgs e)
        {
            if (dgvUsuarios.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccione un usuario para editar.",
                    "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            try
            {
                Usuario_Entidad usuarioSeleccionado = (Usuario_Entidad)dgvUsuarios.CurrentRow.DataBoundItem;

                Usuario_Entidad usuarioCompleto = cnUsuario.ObtenerUsuarioPorId(usuarioSeleccionado.IdUsuario);

                //Abrir formulario de edición con el usuario completo
                FrmEditarUsuario frm = new FrmEditarUsuario(usuarioCompleto);

                if (frm.ShowDialog() == DialogResult.OK)
                {
                    CargarUsuarios();
                    MessageBox.Show("Usuario actualizado correctamente",
                        "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MostrarError("Error al editar usuario", ex.Message);
            }
        }
       
        private void MostrarError(string titulo, string mensaje)
        {
            MessageBox.Show(mensaje, titulo, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
