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

namespace CapaPresentacion.Logins
{
    public partial class FrmEditarUsuario : Form
    {
        private CN_Usuario cnUsuario = new CN_Usuario();
        private Usuario_Entidad usuarioActual;

        public FrmEditarUsuario(Usuario_Entidad usuario)
        {
            InitializeComponent();
            usuarioActual = usuario;
        }

        private void FrmEditarUsuario_Load(object sender, EventArgs e)
        {
            CargarCombos();
            CargarDatosUsuario();
        }

        private void CargarCombos()
        {
            cmbRol.Items.Clear();
            cmbRol.Items.Add("Administrador");
            cmbRol.Items.Add("Usuario");

            cmbEstado.Items.Clear();
            cmbEstado.Items.Add("Activo");
            cmbEstado.Items.Add("Inactivo");
        }

        private void CargarDatosUsuario()
        {
            try
            {
                lblIdUsuario.Text = $"ID: {usuarioActual.IdUsuario}";
                txtUsuario.Text = usuarioActual.Usuario;
                txtNombreCompleto.Text = usuarioActual.NombreUsuario;
                txtContrasena.Text = usuarioActual.Contrasena;
                cmbRol.SelectedIndex = usuarioActual.IdRol == 1 ? 0 : 1;
                cmbEstado.SelectedIndex = usuarioActual.IdEstado == 1 ? 0 : 1;

                if (usuarioActual.IdUsuario == UsuarioLoginCache.idUsuario)
                {
                    cmbEstado.Enabled = false;
                    lblAdvertencia.Text = "No puedes desactivar tu propia cuenta";
                    lblAdvertencia.Visible = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar datos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtUsuario.Text))
                {
                    MostrarError("El usuario es obligatorio");
                    txtUsuario.Focus();
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtNombreCompleto.Text))
                {
                    MostrarError("El nombre completo es obligatorio");
                    txtNombreCompleto.Focus();
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtContrasena.Text))
                {
                    MostrarError("La contraseña es obligatoria");
                    txtContrasena.Focus();
                    return;
                }

                if (txtContrasena.Text.Length < 4)
                {
                    MostrarError("La contraseña debe tener al menos 4 caracteres");
                    txtContrasena.Focus();
                    return;
                }

                if (cmbRol.SelectedIndex < 0 || cmbEstado.SelectedIndex < 0)
                {
                    MostrarError("Debe seleccionar rol y estado");
                    return;
                }

                usuarioActual.Usuario = txtUsuario.Text.Trim();
                usuarioActual.NombreUsuario = txtNombreCompleto.Text.Trim();
                usuarioActual.Contrasena = txtContrasena.Text;
                usuarioActual.IdRol = cmbRol.SelectedIndex == 0 ? 1 : 2;
                usuarioActual.IdEstado = cmbEstado.SelectedIndex == 0 ? 1 : 2;

                bool actualizado = cnUsuario.ActualizarUsuario(usuarioActual);

                if (actualizado)
                {
                    if (usuarioActual.IdUsuario == UsuarioLoginCache.idUsuario)
                    {
                        UsuarioLoginCache.nombreUsuario = usuarioActual.NombreUsuario;
                        UsuarioLoginCache.idRol = usuarioActual.IdRol;
                        UsuarioLoginCache.rol = usuarioActual.IdRol == 1 ? "Administrador" : "Usuario";
                    }

                    DialogResult = DialogResult.OK;
                    Close();
                }
                else
                {
                    MostrarError("No se pudo actualizar el usuario");
                }
            }
            catch (Exception ex)
            {
                MostrarError("Error al guardar: " + ex.Message);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("¿Cancelar cambios?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                DialogResult = DialogResult.Cancel;
                Close();
            }
        }

        private void MostrarError(string mensaje)
        {
            MessageBox.Show(mensaje, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }
}

