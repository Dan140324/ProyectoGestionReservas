namespace CapaPresentacion.Logins
{
    partial class FrmRegistroUsuario
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
            lblContrasena = new Label();
            txtNuevaContrasena = new TextBox();
            lblUsuario = new Label();
            txtNuevoUsuario = new TextBox();
            btnRegistrarUsuario = new Button();
            btnVolver = new Button();
            lblNombreUsuario = new Label();
            txtNombreUsuario = new TextBox();
            lblMensajeError = new Label();
            SuspendLayout();
            // 
            // lblContrasena
            // 
            lblContrasena.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            lblContrasena.AutoSize = true;
            lblContrasena.Location = new Point(311, 136);
            lblContrasena.Name = "lblContrasena";
            lblContrasena.Size = new Size(129, 20);
            lblContrasena.TabIndex = 9;
            lblContrasena.Text = "Contraseña nueva:";
            // 
            // txtNuevaContrasena
            // 
            txtNuevaContrasena.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            txtNuevaContrasena.Location = new Point(311, 159);
            txtNuevaContrasena.Name = "txtNuevaContrasena";
            txtNuevaContrasena.Size = new Size(178, 27);
            txtNuevaContrasena.TabIndex = 8;
            // 
            // lblUsuario
            // 
            lblUsuario.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            lblUsuario.AutoSize = true;
            lblUsuario.Location = new Point(311, 71);
            lblUsuario.Name = "lblUsuario";
            lblUsuario.Size = new Size(106, 20);
            lblUsuario.TabIndex = 7;
            lblUsuario.Text = "Usuario nuevo:";
            // 
            // txtNuevoUsuario
            // 
            txtNuevoUsuario.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            txtNuevoUsuario.Location = new Point(311, 94);
            txtNuevoUsuario.Name = "txtNuevoUsuario";
            txtNuevoUsuario.Size = new Size(178, 27);
            txtNuevoUsuario.TabIndex = 6;
            // 
            // btnRegistrarUsuario
            // 
            btnRegistrarUsuario.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            btnRegistrarUsuario.Location = new Point(343, 345);
            btnRegistrarUsuario.Name = "btnRegistrarUsuario";
            btnRegistrarUsuario.Size = new Size(117, 29);
            btnRegistrarUsuario.TabIndex = 10;
            btnRegistrarUsuario.Text = "Registrarte";
            btnRegistrarUsuario.UseVisualStyleBackColor = true;
            btnRegistrarUsuario.Click += btnRegistrarUsuario_Click;
            // 
            // btnVolver
            // 
            btnVolver.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            btnVolver.Location = new Point(343, 390);
            btnVolver.Name = "btnVolver";
            btnVolver.Size = new Size(117, 29);
            btnVolver.TabIndex = 11;
            btnVolver.Text = "Volver";
            btnVolver.UseVisualStyleBackColor = true;
            btnVolver.Click += btnVolver_Click;
            // 
            // lblNombreUsuario
            // 
            lblNombreUsuario.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            lblNombreUsuario.AutoSize = true;
            lblNombreUsuario.Location = new Point(311, 195);
            lblNombreUsuario.Name = "lblNombreUsuario";
            lblNombreUsuario.Size = new Size(137, 20);
            lblNombreUsuario.TabIndex = 13;
            lblNombreUsuario.Text = "Nombre y apellido:";
            // 
            // txtNombreUsuario
            // 
            txtNombreUsuario.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            txtNombreUsuario.Location = new Point(311, 218);
            txtNombreUsuario.Name = "txtNombreUsuario";
            txtNombreUsuario.Size = new Size(178, 27);
            txtNombreUsuario.TabIndex = 12;
            // 
            // lblMensajeError
            // 
            lblMensajeError.AutoSize = true;
            lblMensajeError.Location = new Point(311, 265);
            lblMensajeError.Name = "lblMensajeError";
            lblMensajeError.Size = new Size(100, 20);
            lblMensajeError.TabIndex = 14;
            lblMensajeError.Text = "Mensaje Error";
            lblMensajeError.Visible = false;
            // 
            // FrmRegistroUsuario
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(792, 450);
            Controls.Add(lblMensajeError);
            Controls.Add(lblNombreUsuario);
            Controls.Add(txtNombreUsuario);
            Controls.Add(btnVolver);
            Controls.Add(btnRegistrarUsuario);
            Controls.Add(lblContrasena);
            Controls.Add(txtNuevaContrasena);
            Controls.Add(lblUsuario);
            Controls.Add(txtNuevoUsuario);
            Name = "FrmRegistroUsuario";
            Text = "Crear Usuario";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblContrasena;
        private TextBox txtNuevaContrasena;
        private Label lblUsuario;
        private TextBox txtNuevoUsuario;
        private Button btnRegistrarUsuario;
        private Button btnVolver;
        private Label lblNombreUsuario;
        private TextBox txtNombreUsuario;
        private Label lblMensajeError;
    }
}