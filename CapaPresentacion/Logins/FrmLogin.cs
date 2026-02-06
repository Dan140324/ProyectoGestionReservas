using CapaPresentacion.FormulariosPrincipales;
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
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();

        }
        private void FrmLogin_Load(object sender, EventArgs e)
        {
        }
        private void btnLogin_Click(object sender, EventArgs e)
        {
            //Validar si el usuario llenó los campos.
            if (string.IsNullOrWhiteSpace(txtUsuario.Text))
    {
                msjError("Por favor ingrese su usuario.");
                txtUsuario.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtContrasena.Text))
            {
                msjError("Por favor ingrese su contraseña.");
                txtContrasena.Focus();
                return;
            }

            //Si todo está bien, ocultamos el mensaje de error y continuamos login.
            lblMensajeError.Visible = false;

            CapaNegocio.CN_Usuario cnUsuario = new CapaNegocio.CN_Usuario();
            bool loginExitoso = cnUsuario.Login(txtUsuario.Text, txtContrasena.Text);
            if (loginExitoso)
            {
                //Login exitoso
                FrmPrincipal frmPrincipal = new FrmPrincipal();
                this.Hide();
                frmPrincipal.ShowDialog();

            }
            else
            {
                //Login fallido
                msjError("Usuario o contraseña incorrectos.");
            }

        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnCrearUsuario_Click(object sender, EventArgs e)
        {
            FrmRegistroUsuario frm = new FrmRegistroUsuario();
            frm.ShowDialog();
        }

        private void msjError(string mensaje)
        {
            lblMensajeError.Text = mensaje;
            lblMensajeError.Visible = true;
        }

    }
}
