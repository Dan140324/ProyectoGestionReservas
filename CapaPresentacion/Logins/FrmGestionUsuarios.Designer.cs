namespace CapaPresentacion.Logins
{
    partial class FrmGestionUsuarios
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
            dgvUsuarios = new DataGridView();
            txtFiltroUsuario = new TextBox();
            lblFiltroUsuario = new Label();
            lblFiltroNombreUsuario = new Label();
            txtFiltroNombreUsuario = new TextBox();
            cmbFiltroRol = new ComboBox();
            lblFiltroRol = new Label();
            label1 = new Label();
            cmbFiltroEstado = new ComboBox();
            btnFiltrar = new Button();
            btnLimpiar = new Button();
            lblTotal = new Label();
            btnEditarUsuario = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvUsuarios).BeginInit();
            SuspendLayout();
            // 
            // dgvUsuarios
            // 
            dgvUsuarios.AllowUserToAddRows = false;
            dgvUsuarios.AllowUserToDeleteRows = false;
            dgvUsuarios.Anchor = AnchorStyles.Bottom;
            dgvUsuarios.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvUsuarios.Location = new Point(178, 252);
            dgvUsuarios.MultiSelect = false;
            dgvUsuarios.Name = "dgvUsuarios";
            dgvUsuarios.ReadOnly = true;
            dgvUsuarios.RowHeadersWidth = 51;
            dgvUsuarios.Size = new Size(678, 186);
            dgvUsuarios.TabIndex = 0;
            // 
            // txtFiltroUsuario
            // 
            txtFiltroUsuario.Location = new Point(306, 65);
            txtFiltroUsuario.Name = "txtFiltroUsuario";
            txtFiltroUsuario.Size = new Size(151, 27);
            txtFiltroUsuario.TabIndex = 1;
            // 
            // lblFiltroUsuario
            // 
            lblFiltroUsuario.AutoSize = true;
            lblFiltroUsuario.Location = new Point(238, 68);
            lblFiltroUsuario.Name = "lblFiltroUsuario";
            lblFiltroUsuario.Size = new Size(62, 20);
            lblFiltroUsuario.TabIndex = 2;
            lblFiltroUsuario.Text = "Usuario:";
            // 
            // lblFiltroNombreUsuario
            // 
            lblFiltroNombreUsuario.AutoSize = true;
            lblFiltroNombreUsuario.Location = new Point(469, 68);
            lblFiltroNombreUsuario.Name = "lblFiltroNombreUsuario";
            lblFiltroNombreUsuario.Size = new Size(67, 20);
            lblFiltroNombreUsuario.TabIndex = 4;
            lblFiltroNombreUsuario.Text = "Nombre:";
            // 
            // txtFiltroNombreUsuario
            // 
            txtFiltroNombreUsuario.Location = new Point(542, 65);
            txtFiltroNombreUsuario.Name = "txtFiltroNombreUsuario";
            txtFiltroNombreUsuario.Size = new Size(151, 27);
            txtFiltroNombreUsuario.TabIndex = 3;
            // 
            // cmbFiltroRol
            // 
            cmbFiltroRol.FormattingEnabled = true;
            cmbFiltroRol.Location = new Point(542, 117);
            cmbFiltroRol.Name = "cmbFiltroRol";
            cmbFiltroRol.Size = new Size(151, 28);
            cmbFiltroRol.TabIndex = 5;
            // 
            // lblFiltroRol
            // 
            lblFiltroRol.AutoSize = true;
            lblFiltroRol.Location = new Point(502, 120);
            lblFiltroRol.Name = "lblFiltroRol";
            lblFiltroRol.Size = new Size(34, 20);
            lblFiltroRol.TabIndex = 6;
            lblFiltroRol.Text = "Rol:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(243, 120);
            label1.Name = "label1";
            label1.Size = new Size(57, 20);
            label1.TabIndex = 8;
            label1.Text = "Estado:";
            // 
            // cmbFiltroEstado
            // 
            cmbFiltroEstado.FormattingEnabled = true;
            cmbFiltroEstado.Location = new Point(306, 117);
            cmbFiltroEstado.Name = "cmbFiltroEstado";
            cmbFiltroEstado.Size = new Size(151, 28);
            cmbFiltroEstado.TabIndex = 7;
            // 
            // btnFiltrar
            // 
            btnFiltrar.Location = new Point(712, 64);
            btnFiltrar.Name = "btnFiltrar";
            btnFiltrar.Size = new Size(125, 35);
            btnFiltrar.TabIndex = 9;
            btnFiltrar.Text = "Aplicar filtros";
            btnFiltrar.UseVisualStyleBackColor = true;
            btnFiltrar.Click += btnFiltrar_Click;
            // 
            // btnLimpiar
            // 
            btnLimpiar.Location = new Point(712, 105);
            btnLimpiar.Name = "btnLimpiar";
            btnLimpiar.Size = new Size(125, 35);
            btnLimpiar.TabIndex = 10;
            btnLimpiar.Text = "Limpiar Filtros";
            btnLimpiar.UseVisualStyleBackColor = true;
            btnLimpiar.Click += btnLimpiar_Click;
            // 
            // lblTotal
            // 
            lblTotal.AutoSize = true;
            lblTotal.Location = new Point(178, 229);
            lblTotal.Name = "lblTotal";
            lblTotal.Size = new Size(124, 20);
            lblTotal.TabIndex = 11;
            lblTotal.Text = "Total de usuarios:";
            // 
            // btnEditarUsuario
            // 
            btnEditarUsuario.Location = new Point(731, 217);
            btnEditarUsuario.Name = "btnEditarUsuario";
            btnEditarUsuario.Size = new Size(125, 29);
            btnEditarUsuario.TabIndex = 12;
            btnEditarUsuario.Text = "Editar Usuario";
            btnEditarUsuario.UseVisualStyleBackColor = true;
            btnEditarUsuario.Click += btnEditarUsuario_Click;
            // 
            // FrmGestionUsuarios
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1020, 450);
            Controls.Add(btnEditarUsuario);
            Controls.Add(lblTotal);
            Controls.Add(btnLimpiar);
            Controls.Add(btnFiltrar);
            Controls.Add(label1);
            Controls.Add(cmbFiltroEstado);
            Controls.Add(lblFiltroRol);
            Controls.Add(cmbFiltroRol);
            Controls.Add(lblFiltroNombreUsuario);
            Controls.Add(txtFiltroNombreUsuario);
            Controls.Add(lblFiltroUsuario);
            Controls.Add(txtFiltroUsuario);
            Controls.Add(dgvUsuarios);
            Name = "FrmGestionUsuarios";
            Text = "Gestión de Usuarios";
            Load += FrmGestionUsuarios_Load;
            ((System.ComponentModel.ISupportInitialize)dgvUsuarios).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvUsuarios;
        private TextBox txtFiltroUsuario;
        private Label lblFiltroUsuario;
        private Label lblFiltroNombreUsuario;
        private TextBox txtFiltroNombreUsuario;
        private ComboBox cmbFiltroRol;
        private Label lblFiltroRol;
        private Label label1;
        private ComboBox cmbFiltroEstado;
        private Button btnFiltrar;
        private Button btnLimpiar;
        private Label lblTotal;
        private Button btnEditarUsuario;
    }
}