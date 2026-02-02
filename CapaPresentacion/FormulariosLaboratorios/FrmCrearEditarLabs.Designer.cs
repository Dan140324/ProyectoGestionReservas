namespace CapaPresentacion.Formularios
{
    partial class FrmCrearEditarLabs
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            txtNombreLab = new TextBox();
            lblAgregarLaboratorio = new Label();
            lblNombreLab = new Label();
            lblCapacidadMax = new Label();
            nudCapacidadLab = new NumericUpDown();
            lblIdLaboratorio = new Label();
            lblActualIdLab = new Label();
            btnGuardar = new Button();
            btnCancelar = new Button();
            ((System.ComponentModel.ISupportInitialize)nudCapacidadLab).BeginInit();
            SuspendLayout();
            // 
            // txtNombreLab
            // 
            txtNombreLab.Location = new Point(265, 166);
            txtNombreLab.Name = "txtNombreLab";
            txtNombreLab.Size = new Size(152, 27);
            txtNombreLab.TabIndex = 0;
            // 
            // lblAgregarLaboratorio
            // 
            lblAgregarLaboratorio.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblAgregarLaboratorio.AutoSize = true;
            lblAgregarLaboratorio.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblAgregarLaboratorio.Location = new Point(167, 21);
            lblAgregarLaboratorio.Name = "lblAgregarLaboratorio";
            lblAgregarLaboratorio.Size = new Size(204, 28);
            lblAgregarLaboratorio.TabIndex = 1;
            lblAgregarLaboratorio.Text = "Agregar Laboratorio";
            lblAgregarLaboratorio.TextAlign = ContentAlignment.TopCenter;
            // 
            // lblNombreLab
            // 
            lblNombreLab.AutoSize = true;
            lblNombreLab.Location = new Point(89, 169);
            lblNombreLab.Name = "lblNombreLab";
            lblNombreLab.Size = new Size(170, 20);
            lblNombreLab.TabIndex = 2;
            lblNombreLab.Text = "Nombre de Laboratorio:";
            // 
            // lblCapacidadMax
            // 
            lblCapacidadMax.AutoSize = true;
            lblCapacidadMax.Location = new Point(89, 218);
            lblCapacidadMax.Name = "lblCapacidadMax";
            lblCapacidadMax.Size = new Size(140, 20);
            lblCapacidadMax.TabIndex = 3;
            lblCapacidadMax.Text = "Capacidad Máxima:";
            // 
            // nudCapacidadLab
            // 
            nudCapacidadLab.Location = new Point(267, 216);
            nudCapacidadLab.Name = "nudCapacidadLab";
            nudCapacidadLab.Size = new Size(150, 27);
            nudCapacidadLab.TabIndex = 4;
            // 
            // lblIdLaboratorio
            // 
            lblIdLaboratorio.AutoSize = true;
            lblIdLaboratorio.Location = new Point(89, 122);
            lblIdLaboratorio.Name = "lblIdLaboratorio";
            lblIdLaboratorio.Size = new Size(109, 20);
            lblIdLaboratorio.TabIndex = 5;
            lblIdLaboratorio.Text = "ID Laboratorio:";
            // 
            // lblActualIdLab
            // 
            lblActualIdLab.AutoSize = true;
            lblActualIdLab.Location = new Point(265, 122);
            lblActualIdLab.Name = "lblActualIdLab";
            lblActualIdLab.Size = new Size(0, 20);
            lblActualIdLab.TabIndex = 6;
            // 
            // btnGuardar
            // 
            btnGuardar.Location = new Point(139, 326);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(107, 41);
            btnGuardar.TabIndex = 7;
            btnGuardar.Text = "Guardar";
            btnGuardar.UseVisualStyleBackColor = true;
            btnGuardar.Click += this.btnGuardar_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.Location = new Point(264, 326);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(107, 41);
            btnCancelar.TabIndex = 8;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // FrmCrearEditarLabs
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(511, 450);
            Controls.Add(btnCancelar);
            Controls.Add(btnGuardar);
            Controls.Add(lblActualIdLab);
            Controls.Add(lblIdLaboratorio);
            Controls.Add(nudCapacidadLab);
            Controls.Add(lblCapacidadMax);
            Controls.Add(lblNombreLab);
            Controls.Add(lblAgregarLaboratorio);
            Controls.Add(txtNombreLab);
            Name = "FrmCrearEditarLabs";
            Text = "Crear Laboratorio";
            ((System.ComponentModel.ISupportInitialize)nudCapacidadLab).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtNombreLab;
        private Label lblAgregarLaboratorio;
        private Label lblNombreLab;
        private Label lblCapacidadMax;
        private NumericUpDown nudCapacidadLab;
        private Label lblIdLaboratorio;
        private Label lblActualIdLab;
        private Button btnGuardar;
        private Button btnCancelar;
    }
}