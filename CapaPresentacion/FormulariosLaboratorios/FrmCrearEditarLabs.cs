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

namespace CapaPresentacion.Formularios
{
    public partial class FrmCrearEditarLabs : Form
    {
        private int? idLaboratorio = null;
        public FrmCrearEditarLabs()
        {
            InitializeComponent();
            lblAgregarLaboratorio.Text = "Agregar Laboratorio";
        }

        public FrmCrearEditarLabs(int id, string nombre, int capacidad)
        {
            InitializeComponent();

            lblAgregarLaboratorio.Text = "Editar Laboratorio";
            
            idLaboratorio = id;
            lblActualIdLab.Text = id.ToString();
            txtNombreLab.Text = nombre;
            nudCapacidadLab.Value = capacidad;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrWhiteSpace(txtNombreLab.Text))
            {
                MessageBox.Show("El nombre es obligatorio");
                return;
            }

            CN_Laboratorios cn = new CN_Laboratorios();

            bool ok = cn.guardarLaboratorio(
                idLaboratorio,
                txtNombreLab.Text.Trim(),
                (int)nudCapacidadLab.Value,
                1 // Activo
            );

            if (ok)
            {
                MessageBox.Show("Laboratorio guardado correctamente");
                DialogResult = DialogResult.OK;
                Close();
            }
        }


        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
