using CapaComun;
using CapaDatos.DAO;
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
    public partial class FrmRegistroUsuario : Form
    {
        public FrmRegistroUsuario()
        {
            InitializeComponent();
        }
        private void btnRegistrarUsuario_Click(object sender, EventArgs e)
        {
            try
            {
                //Validar si el usuario llenó los campos.
                if (string.IsNullOrWhiteSpace(txtNuevoUsuario.Text))
                {
                    msjError("Por favor ingrese un nombre de usuario.");
                    txtNuevoUsuario.Focus();
                    return;
                }
                if (string.IsNullOrWhiteSpace(txtNuevaContrasena.Text))
                {
                    msjError("Por favor ingrese una contraseña.");
                    txtNuevaContrasena.Focus();
                    return;
                }
                if (string.IsNullOrWhiteSpace(txtNombreUsuario.Text))
                {
                    msjError("Por favor ingrese el nombre completo del usuario.");
                    txtNombreUsuario.Focus();
                    return;
                }
                //Si todo está bien, ocultamos el mensaje de error y continuamos con el registro.
                lblMensajeError.Visible = false;
                CN_Usuario cnUsuario = new CN_Usuario();
                bool registroExitoso = cnUsuario.CrearUsuario(txtNuevoUsuario.Text, txtNuevaContrasena.Text, txtNombreUsuario.Text);
                if (registroExitoso)
                {
                    MessageBox.Show("Usuario registrado exitosamente.");
                    this.Close();
                }
                else
                {
                    msjError("Error al registrar el usuario. Intente nuevamente.");
                }
            }
            catch (Exception ex)
            {
                msjError("Ocurrió un error: " + ex.Message);
            }
        }
        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void msjError(string mensaje)
        {
            lblMensajeError.Text = mensaje;
            lblMensajeError.Visible = true;
        }

    }
}
