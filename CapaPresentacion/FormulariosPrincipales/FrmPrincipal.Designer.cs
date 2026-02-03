namespace CapaPresentacion.FormulariosPrincipales
{
    partial class FrmPrincipal
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
            btnLaboratorios = new Button();
            btnReservas = new Button();
            btnReporteReservas = new Button();
            btnReporteLaboratorios = new Button();
            btnUsuarios = new Button();
            btnSalir = new Button();
            SuspendLayout();
            // 
            // btnLaboratorios
            // 
            btnLaboratorios.Location = new Point(241, 84);
            btnLaboratorios.Name = "btnLaboratorios";
            btnLaboratorios.Size = new Size(133, 51);
            btnLaboratorios.TabIndex = 0;
            btnLaboratorios.Text = "Laboratorios";
            btnLaboratorios.UseVisualStyleBackColor = true;
            btnLaboratorios.Click += btnLaboratorios_Click;
            // 
            // btnReservas
            // 
            btnReservas.Location = new Point(405, 84);
            btnReservas.Name = "btnReservas";
            btnReservas.Size = new Size(133, 51);
            btnReservas.TabIndex = 1;
            btnReservas.Text = "Reservas";
            btnReservas.UseVisualStyleBackColor = true;
            // 
            // btnReporteReservas
            // 
            btnReporteReservas.Location = new Point(241, 266);
            btnReporteReservas.Name = "btnReporteReservas";
            btnReporteReservas.Size = new Size(133, 51);
            btnReporteReservas.TabIndex = 2;
            btnReporteReservas.Text = "Reporte de Reservas";
            btnReporteReservas.UseVisualStyleBackColor = true;
            // 
            // btnReporteLaboratorios
            // 
            btnReporteLaboratorios.Location = new Point(405, 266);
            btnReporteLaboratorios.Name = "btnReporteLaboratorios";
            btnReporteLaboratorios.Size = new Size(133, 51);
            btnReporteLaboratorios.TabIndex = 3;
            btnReporteLaboratorios.Text = "Reporte de Laboratorios";
            btnReporteLaboratorios.UseVisualStyleBackColor = true;
            // 
            // btnUsuarios
            // 
            btnUsuarios.Location = new Point(327, 209);
            btnUsuarios.Name = "btnUsuarios";
            btnUsuarios.Size = new Size(133, 51);
            btnUsuarios.TabIndex = 4;
            btnUsuarios.Text = "Gestión de Usuarios";
            btnUsuarios.UseVisualStyleBackColor = true;
            // 
            // btnSalir
            // 
            btnSalir.Location = new Point(327, 353);
            btnSalir.Name = "btnSalir";
            btnSalir.Size = new Size(133, 51);
            btnSalir.TabIndex = 5;
            btnSalir.Text = "Salir";
            btnSalir.UseVisualStyleBackColor = true;
            btnSalir.Click += btnSalir_Click;
            // 
            // FrmPrincipal
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnSalir);
            Controls.Add(btnUsuarios);
            Controls.Add(btnReporteLaboratorios);
            Controls.Add(btnReporteReservas);
            Controls.Add(btnReservas);
            Controls.Add(btnLaboratorios);
            Name = "FrmPrincipal";
            Text = "Menú Principal";
            ResumeLayout(false);
        }

        #endregion

        private Button btnLaboratorios;
        private Button btnReservas;
        private Button btnReporteReservas;
        private Button btnReporteLaboratorios;
        private Button btnUsuarios;
        private Button btnSalir;
    }
}