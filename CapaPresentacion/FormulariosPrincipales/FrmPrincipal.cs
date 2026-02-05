using CapaPresentacion.Logins;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaPresentacion.FormulariosPrincipales
{
    public partial class FrmPrincipal : Form
    {
        public FrmPrincipal()
        {
            InitializeComponent();
        }

        private void FrmPrincipal_Load(object sender, EventArgs e)
        {
            cargarUsuarioLogueado();
        }
        private void btnLaboratorios_Click(object sender, EventArgs e)
        {
            FrmLaboratorios frm = new FrmLaboratorios();
            frm.ShowDialog();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void cargarUsuarioLogueado()
        {
            // Cargar y mostrar la información del usuario logueado en el formulario principal.
            lblBienvenida.Text = $"Bienvenido, {CapaComun.UsuarioLoginCache.nombreUsuario}!";
            lblPerfilUsuario.Text = $"Perfil: {CapaComun.UsuarioLoginCache.rol}";

        }

        private void btnGestionUsuarios_Click(object sender, EventArgs e)
        {
            FrmGestionUsuarios frm = new FrmGestionUsuarios();
            frm.ShowDialog();
        }
    }
}
