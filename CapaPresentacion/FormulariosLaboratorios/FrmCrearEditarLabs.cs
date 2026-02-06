using CapaEntidad.Clases;
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
        private CN_Laboratorios cnLaboratorios = new CN_Laboratorios();
        private Laboratorio_Entidad laboratorioActual = null;
        private bool esEdicion = false;

        public FrmCrearEditarLabs()
        {
            InitializeComponent();
            lblAgregarLaboratorio.Text = "Agregar Laboratorio";
            esEdicion = false;

            //Inicializar nuevo laboratorio
            laboratorioActual = new Laboratorio_Entidad
            {
                IdLaboratorio = 0,
                IdEstado = 1 //Activo por defecto
            };
        }

        //Constructor para edición que recibe la entidad completa
        public FrmCrearEditarLabs(Laboratorio_Entidad laboratorio)
        {
            InitializeComponent();
            lblAgregarLaboratorio.Text = "Editar Laboratorio";
            esEdicion = true;

            //Guardar referencia a la entidad
            laboratorioActual = laboratorio;

            CargarDatos();
        }
        
        //Cargar datos de la entidad en controles
        private void CargarDatos()
        {
            if (laboratorioActual != null)
            {
                lblActualIdLab.Text = laboratorioActual.IdLaboratorio.ToString();
                txtNombreLab.Text = laboratorioActual.NombreLaboratorio;
                nudCapacidadLab.Value = laboratorioActual.Capacidad;
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                //Validaciones básicas de UI
                if (string.IsNullOrWhiteSpace(txtNombreLab.Text))
                {
                    MessageBox.Show("El nombre es obligatorio",
                        "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtNombreLab.Focus();
                    return;
                }

                if (nudCapacidadLab.Value <= 0)
                {
                    MessageBox.Show("La capacidad debe ser mayor a 0",
                        "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    nudCapacidadLab.Focus();
                    return;
                }

                //Validar nombre duplicado
                if (cnLaboratorios.existeLaboratorioConNombre(
                    txtNombreLab.Text.Trim(),
                    esEdicion ? laboratorioActual.IdLaboratorio : (int?)null))
                {
                    MessageBox.Show("Ya existe un laboratorio con ese nombre",
                        "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtNombreLab.Focus();
                    return;
                }

                //Actualizar datos de la entidad
                laboratorioActual.NombreLaboratorio = txtNombreLab.Text.Trim();
                laboratorioActual.Capacidad = (int)nudCapacidadLab.Value;
                laboratorioActual.IdEstado = 1; //Activo

                //Guardar usando la capa de negocio
                bool guardado = cnLaboratorios.guardarLaboratorio(laboratorioActual);

                if (guardado)
                {
                    string mensaje = esEdicion
                        ? "Laboratorio actualizado correctamente"
                        : "Laboratorio creado correctamente";

                    MessageBox.Show(mensaje, "Éxito",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    DialogResult = DialogResult.OK;
                    Close();
                }
                else
                {
                    MessageBox.Show("No se pudo guardar el laboratorio",
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "¿Está seguro de que desea cancelar? Los cambios no se guardarán.",
                "Confirmar cancelación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (result == DialogResult.Yes)
            {
                DialogResult = DialogResult.Cancel;
                Close();
            }
        }

    
    }
}
