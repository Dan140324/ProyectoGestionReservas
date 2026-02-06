using CapaNegocio;
using CapaPresentacion.Formularios;
using CapaPresentacion.FormulariosReservas;
using CapaPresentacion.Logins;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CapaPresentacion.FormulariosPrincipales
{
    public partial class FrmPrincipal : Form
    {

        private System.Windows.Forms.Timer timerFinalizarReservas;
        private CN_Reservas cnReservas = new CN_Reservas();
        public FrmPrincipal()
        {
            InitializeComponent();
        }

        private void FrmPrincipal_Load(object sender, EventArgs e)
        {
            cargarUsuarioLogueado();
            ConfigurarTimerFinalizarReservas();
            FinalizarReservasPasadas(); // Ejecutar una vez al iniciar
        }
        private void btnLaboratorios_Click(object sender, EventArgs e)
        {
            //Validar que solo los usuarios con rol "Administrador" o "Usuario" puedan acceder a la gestión de laboratorios.
            if (CapaComun.UsuarioLoginCache.rol != "Administrador")
            {
                MessageBox.Show("No tienes permisos para acceder a esta sección.", "Acceso Denegado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            FrmLaboratorios frm = new FrmLaboratorios();
            frm.ShowDialog();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void cargarUsuarioLogueado()
        {
            //Cargar y mostrar la información del usuario logueado en el formulario principal.
            lblBienvenida.Text = $"Bienvenido, {CapaComun.UsuarioLoginCache.nombreUsuario}!";
            lblPerfilUsuario.Text = $"Perfil: {CapaComun.UsuarioLoginCache.rol}";

        }

        private void btnGestionUsuarios_Click(object sender, EventArgs e)
        {
            //Validar que solo los usuarios con rol "Administrador" puedan acceder a la gestión de usuarios.
            if (CapaComun.UsuarioLoginCache.rol != "Administrador")
            {
                MessageBox.Show("No tienes permisos para acceder a esta sección.", "Acceso Denegado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            FrmGestionUsuarios frm = new FrmGestionUsuarios();
            frm.ShowDialog();
        }

        private void btnReservas_Click(object sender, EventArgs e)
        {
            FrmCrearReserva frm = new FrmCrearReserva();
            frm.ShowDialog();
        }

        private void btnMisReservas_Click(object sender, EventArgs e)
        {
            FrmMisReservas frm = new FrmMisReservas();
            frm.ShowDialog();
        }

        private void ConfigurarTimerFinalizarReservas()
        {
            timerFinalizarReservas = new System.Windows.Forms.Timer();
            timerFinalizarReservas.Interval = 300000; //5 minutos
            timerFinalizarReservas.Tick += TimerFinalizarReservas_Tick;
            timerFinalizarReservas.Start();
        }

        private void TimerFinalizarReservas_Tick(object sender, EventArgs e)
        {
            FinalizarReservasPasadas();
        }

        private void FinalizarReservasPasadas()
        {
            try
            {
                int finalizadas = cnReservas.FinalizarReservasPasadasAutomaticamente();

                if (finalizadas > 0)
                {
                    System.Diagnostics.Debug.WriteLine(
                        $"[{DateTime.Now:HH:mm:ss}] Finalizadas: {finalizadas}"
                    );
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error: {ex.Message}");
            }
        }

        private void FrmPrincipal_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (timerFinalizarReservas != null)
            {
                timerFinalizarReservas.Stop();
                timerFinalizarReservas.Dispose();
            }
        }

        private void btnReporteReservas_Click(object sender, EventArgs e)
        {
            FrmReporteReservas frm = new FrmReporteReservas();
            frm.ShowDialog();
        }
    }
}
