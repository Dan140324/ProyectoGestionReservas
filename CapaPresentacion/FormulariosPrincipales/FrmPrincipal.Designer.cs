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
            btnMisReservas = new Button();
            btnSalir = new Button();
            lblBienvenida = new Label();
            lblPerfilUsuario = new Label();
            btnGestionUsuarios = new Button();
            SuspendLayout();
            // 
            // btnLaboratorios
            // 
            btnLaboratorios.Location = new Point(250, 272);
            btnLaboratorios.Name = "btnLaboratorios";
            btnLaboratorios.Size = new Size(133, 51);
            btnLaboratorios.TabIndex = 0;
            btnLaboratorios.Text = "Gestionar Laboratorios";
            btnLaboratorios.UseVisualStyleBackColor = true;
            btnLaboratorios.Click += btnLaboratorios_Click;
            // 
            // btnReservas
            // 
            btnReservas.Location = new Point(250, 107);
            btnReservas.Name = "btnReservas";
            btnReservas.Size = new Size(133, 51);
            btnReservas.TabIndex = 1;
            btnReservas.Text = "Crear Reserva";
            btnReservas.UseVisualStyleBackColor = true;
            btnReservas.Click += btnReservas_Click;
            // 
            // btnReporteReservas
            // 
            btnReporteReservas.Location = new Point(327, 164);
            btnReporteReservas.Name = "btnReporteReservas";
            btnReporteReservas.Size = new Size(133, 51);
            btnReporteReservas.TabIndex = 2;
            btnReporteReservas.Text = "Reporte de Reservas";
            btnReporteReservas.UseVisualStyleBackColor = true;
            btnReporteReservas.Click += btnReporteReservas_Click;
            // 
            // btnMisReservas
            // 
            btnMisReservas.Location = new Point(405, 107);
            btnMisReservas.Name = "btnMisReservas";
            btnMisReservas.Size = new Size(133, 51);
            btnMisReservas.TabIndex = 4;
            btnMisReservas.Text = "Mis Reservas";
            btnMisReservas.UseVisualStyleBackColor = true;
            btnMisReservas.Click += btnMisReservas_Click;
            // 
            // btnSalir
            // 
            btnSalir.Location = new Point(327, 387);
            btnSalir.Name = "btnSalir";
            btnSalir.Size = new Size(133, 51);
            btnSalir.TabIndex = 5;
            btnSalir.Text = "Salir";
            btnSalir.UseVisualStyleBackColor = true;
            btnSalir.Click += btnSalir_Click;
            // 
            // lblBienvenida
            // 
            lblBienvenida.AutoSize = true;
            lblBienvenida.Location = new Point(22, 17);
            lblBienvenida.Name = "lblBienvenida";
            lblBienvenida.Size = new Size(82, 20);
            lblBienvenida.TabIndex = 6;
            lblBienvenida.Text = "Bienvenida";
            // 
            // lblPerfilUsuario
            // 
            lblPerfilUsuario.AutoSize = true;
            lblPerfilUsuario.Location = new Point(22, 37);
            lblPerfilUsuario.Name = "lblPerfilUsuario";
            lblPerfilUsuario.Size = new Size(42, 20);
            lblPerfilUsuario.TabIndex = 7;
            lblPerfilUsuario.Text = "Perfil";
            // 
            // btnGestionUsuarios
            // 
            btnGestionUsuarios.Location = new Point(405, 272);
            btnGestionUsuarios.Name = "btnGestionUsuarios";
            btnGestionUsuarios.Size = new Size(133, 51);
            btnGestionUsuarios.TabIndex = 8;
            btnGestionUsuarios.Text = "Gestionar Usuarios";
            btnGestionUsuarios.UseVisualStyleBackColor = true;
            btnGestionUsuarios.Click += btnGestionUsuarios_Click;
            // 
            // FrmPrincipal
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnGestionUsuarios);
            Controls.Add(lblPerfilUsuario);
            Controls.Add(lblBienvenida);
            Controls.Add(btnSalir);
            Controls.Add(btnMisReservas);
            Controls.Add(btnReporteReservas);
            Controls.Add(btnReservas);
            Controls.Add(btnLaboratorios);
            Name = "FrmPrincipal";
            Text = "Menú Principal";
            FormClosing += FrmPrincipal_FormClosing;
            Load += FrmPrincipal_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnLaboratorios;
        private Button btnReservas;
        private Button btnReporteReservas;
        private Button btnMisReservas;
        private Button btnSalir;
        private Label lblBienvenida;
        private Label lblPerfilUsuario;
        private Button btnGestionUsuarios;
    }
}