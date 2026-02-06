namespace CapaPresentacion.Logins
{
    partial class FrmEditarUsuario
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
            lblIdUsuario = new Label();
            label1 = new Label();
            txtUsuario = new TextBox();
            lblAdvertenciaUsuario = new Label();
            lblAdvertencia = new Label();
            txtNombreCompleto = new TextBox();
            label3 = new Label();
            txtContrasena = new TextBox();
            label4 = new Label();
            cmbRol = new ComboBox();
            label5 = new Label();
            label6 = new Label();
            cmbEstado = new ComboBox();
            btnGuardar = new Button();
            btnCancelar = new Button();
            SuspendLayout();
            // 
            // lblIdUsuario
            // 
            lblIdUsuario.AutoSize = true;
            lblIdUsuario.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold | FontStyle.Italic | FontStyle.Underline, GraphicsUnit.Point, 0);
            lblIdUsuario.Location = new Point(377, 24);
            lblIdUsuario.Name = "lblIdUsuario";
            lblIdUsuario.Size = new Size(31, 23);
            lblIdUsuario.TabIndex = 0;
            lblIdUsuario.Text = "ID:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 10.2F);
            label1.Location = new Point(251, 63);
            label1.Name = "label1";
            label1.Size = new Size(72, 23);
            label1.TabIndex = 1;
            label1.Text = "Usuario:";
            // 
            // txtUsuario
            // 
            txtUsuario.Location = new Point(251, 89);
            txtUsuario.Name = "txtUsuario";
            txtUsuario.Size = new Size(157, 27);
            txtUsuario.TabIndex = 2;
            // 
            // lblAdvertenciaUsuario
            // 
            lblAdvertenciaUsuario.AutoSize = true;
            lblAdvertenciaUsuario.BackColor = SystemColors.Control;
            lblAdvertenciaUsuario.Font = new Font("Segoe UI", 9F, FontStyle.Italic, GraphicsUnit.Point, 0);
            lblAdvertenciaUsuario.ForeColor = Color.Red;
            lblAdvertenciaUsuario.Location = new Point(251, 119);
            lblAdvertenciaUsuario.Name = "lblAdvertenciaUsuario";
            lblAdvertenciaUsuario.Size = new Size(137, 20);
            lblAdvertenciaUsuario.TabIndex = 3;
            lblAdvertenciaUsuario.Text = "Advertencia Usuario";
            lblAdvertenciaUsuario.Visible = false;
            // 
            // lblAdvertencia
            // 
            lblAdvertencia.AutoSize = true;
            lblAdvertencia.BackColor = SystemColors.Control;
            lblAdvertencia.Font = new Font("Segoe UI", 9F, FontStyle.Italic, GraphicsUnit.Point, 0);
            lblAdvertencia.ForeColor = Color.Red;
            lblAdvertencia.Location = new Point(449, 221);
            lblAdvertencia.Name = "lblAdvertencia";
            lblAdvertencia.Size = new Size(137, 20);
            lblAdvertencia.TabIndex = 6;
            lblAdvertencia.Text = "Advertencia Usuario";
            lblAdvertencia.Visible = false;
            // 
            // txtNombreCompleto
            // 
            txtNombreCompleto.Location = new Point(251, 288);
            txtNombreCompleto.Name = "txtNombreCompleto";
            txtNombreCompleto.Size = new Size(157, 27);
            txtNombreCompleto.TabIndex = 5;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 10.2F);
            label3.Location = new Point(251, 262);
            label3.Name = "label3";
            label3.Size = new Size(157, 23);
            label3.TabIndex = 4;
            label3.Text = "Nombre Completo:";
            // 
            // txtContrasena
            // 
            txtContrasena.Location = new Point(251, 190);
            txtContrasena.Name = "txtContrasena";
            txtContrasena.Size = new Size(157, 27);
            txtContrasena.TabIndex = 8;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 10.2F);
            label4.Location = new Point(251, 164);
            label4.Name = "label4";
            label4.Size = new Size(101, 23);
            label4.TabIndex = 7;
            label4.Text = "Contraseña:";
            // 
            // cmbRol
            // 
            cmbRol.FormattingEnabled = true;
            cmbRol.Location = new Point(449, 88);
            cmbRol.Name = "cmbRol";
            cmbRol.Size = new Size(151, 28);
            cmbRol.TabIndex = 9;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 10.2F);
            label5.Location = new Point(449, 62);
            label5.Name = "label5";
            label5.Size = new Size(38, 23);
            label5.TabIndex = 10;
            label5.Text = "Rol:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 10.2F);
            label6.Location = new Point(449, 164);
            label6.Name = "label6";
            label6.Size = new Size(65, 23);
            label6.TabIndex = 11;
            label6.Text = "Estado:";
            // 
            // cmbEstado
            // 
            cmbEstado.FormattingEnabled = true;
            cmbEstado.Location = new Point(449, 190);
            cmbEstado.Name = "cmbEstado";
            cmbEstado.Size = new Size(151, 28);
            cmbEstado.TabIndex = 12;
            // 
            // btnGuardar
            // 
            btnGuardar.Location = new Point(257, 447);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(121, 47);
            btnGuardar.TabIndex = 13;
            btnGuardar.Text = "Guardar";
            btnGuardar.UseVisualStyleBackColor = true;
            btnGuardar.Click += btnGuardar_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.Location = new Point(449, 447);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(121, 47);
            btnCancelar.TabIndex = 14;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // FrmEditarUsuario
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 576);
            Controls.Add(btnCancelar);
            Controls.Add(btnGuardar);
            Controls.Add(cmbEstado);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(cmbRol);
            Controls.Add(txtContrasena);
            Controls.Add(label4);
            Controls.Add(lblAdvertencia);
            Controls.Add(txtNombreCompleto);
            Controls.Add(label3);
            Controls.Add(lblAdvertenciaUsuario);
            Controls.Add(txtUsuario);
            Controls.Add(label1);
            Controls.Add(lblIdUsuario);
            Name = "FrmEditarUsuario";
            Text = "Editar Usuario";
            Load += FrmEditarUsuario_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblIdUsuario;
        private Label label1;
        private TextBox txtUsuario;
        private Label lblAdvertenciaUsuario;
        private Label lblAdvertencia;
        private TextBox txtNombreCompleto;
        private Label label3;
        private TextBox txtContrasena;
        private Label label4;
        private ComboBox cmbRol;
        private Label label5;
        private Label label6;
        private ComboBox cmbEstado;
        private Button btnGuardar;
        private Button btnCancelar;
    }
}