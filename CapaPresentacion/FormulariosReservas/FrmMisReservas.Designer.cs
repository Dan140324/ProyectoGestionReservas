namespace CapaPresentacion.FormulariosReservas
{
    partial class FrmMisReservas
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
            dgvReservas = new DataGridView();
            cmbFiltroEstado = new ComboBox();
            cmbFiltroTiempo = new ComboBox();
            label1 = new Label();
            label2 = new Label();
            dtpFechaDesde = new DateTimePicker();
            label3 = new Label();
            label4 = new Label();
            dtpFechaHasta = new DateTimePicker();
            btnFiltrar = new Button();
            btnLimpiarFiltros = new Button();
            btnNuevaReserva = new Button();
            btnEditarReserva = new Button();
            btnCancelarReserva = new Button();
            btnVerDetalles = new Button();
            btnRefrescar = new Button();
            lblInfoUsuario = new Label();
            lblContador = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvReservas).BeginInit();
            SuspendLayout();
            // 
            // dgvReservas
            // 
            dgvReservas.AllowUserToAddRows = false;
            dgvReservas.AllowUserToDeleteRows = false;
            dgvReservas.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvReservas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvReservas.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvReservas.Location = new Point(12, 327);
            dgvReservas.MultiSelect = false;
            dgvReservas.Name = "dgvReservas";
            dgvReservas.ReadOnly = true;
            dgvReservas.RowHeadersWidth = 51;
            dgvReservas.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvReservas.Size = new Size(665, 185);
            dgvReservas.TabIndex = 0;
            dgvReservas.CellDoubleClick += dgvReservas_CellDoubleClick;
            dgvReservas.SelectionChanged += dgvReservas_SelectionChanged;
            // 
            // cmbFiltroEstado
            // 
            cmbFiltroEstado.FormattingEnabled = true;
            cmbFiltroEstado.Location = new Point(63, 77);
            cmbFiltroEstado.Name = "cmbFiltroEstado";
            cmbFiltroEstado.Size = new Size(151, 28);
            cmbFiltroEstado.TabIndex = 1;
            // 
            // cmbFiltroTiempo
            // 
            cmbFiltroTiempo.FormattingEnabled = true;
            cmbFiltroTiempo.Location = new Point(63, 156);
            cmbFiltroTiempo.Name = "cmbFiltroTiempo";
            cmbFiltroTiempo.Size = new Size(151, 28);
            cmbFiltroTiempo.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(63, 133);
            label1.Name = "label1";
            label1.Size = new Size(63, 20);
            label1.TabIndex = 3;
            label1.Text = "Tiempo:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(63, 54);
            label2.Name = "label2";
            label2.Size = new Size(57, 20);
            label2.TabIndex = 4;
            label2.Text = "Estado:";
            // 
            // dtpFechaDesde
            // 
            dtpFechaDesde.Location = new Point(240, 75);
            dtpFechaDesde.Name = "dtpFechaDesde";
            dtpFechaDesde.Size = new Size(250, 27);
            dtpFechaDesde.TabIndex = 5;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(240, 52);
            label3.Name = "label3";
            label3.Size = new Size(94, 20);
            label3.TabIndex = 6;
            label3.Text = "Fecha desde:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(240, 134);
            label4.Name = "label4";
            label4.Size = new Size(89, 20);
            label4.TabIndex = 8;
            label4.Text = "Fecha hasta:";
            // 
            // dtpFechaHasta
            // 
            dtpFechaHasta.Location = new Point(240, 157);
            dtpFechaHasta.Name = "dtpFechaHasta";
            dtpFechaHasta.Size = new Size(250, 27);
            dtpFechaHasta.TabIndex = 7;
            // 
            // btnFiltrar
            // 
            btnFiltrar.Location = new Point(522, 68);
            btnFiltrar.Name = "btnFiltrar";
            btnFiltrar.Size = new Size(135, 29);
            btnFiltrar.TabIndex = 9;
            btnFiltrar.Text = "Aplicar filtros";
            btnFiltrar.UseVisualStyleBackColor = true;
            btnFiltrar.Click += btnFiltrar_Click;
            // 
            // btnLimpiarFiltros
            // 
            btnLimpiarFiltros.Location = new Point(522, 115);
            btnLimpiarFiltros.Name = "btnLimpiarFiltros";
            btnLimpiarFiltros.Size = new Size(135, 29);
            btnLimpiarFiltros.TabIndex = 10;
            btnLimpiarFiltros.Text = "Limpiar filtros";
            btnLimpiarFiltros.UseVisualStyleBackColor = true;
            btnLimpiarFiltros.Click += btnLimpiarFiltros_Click;
            // 
            // btnNuevaReserva
            // 
            btnNuevaReserva.Location = new Point(547, 220);
            btnNuevaReserva.Name = "btnNuevaReserva";
            btnNuevaReserva.Size = new Size(131, 29);
            btnNuevaReserva.TabIndex = 11;
            btnNuevaReserva.Text = "Nueva Reserva";
            btnNuevaReserva.UseVisualStyleBackColor = true;
            btnNuevaReserva.Click += btnNuevaReserva_Click;
            // 
            // btnEditarReserva
            // 
            btnEditarReserva.Location = new Point(547, 255);
            btnEditarReserva.Name = "btnEditarReserva";
            btnEditarReserva.Size = new Size(131, 29);
            btnEditarReserva.TabIndex = 12;
            btnEditarReserva.Text = "Editar Reserva";
            btnEditarReserva.UseVisualStyleBackColor = true;
            btnEditarReserva.Click += btnEditarReserva_Click;
            // 
            // btnCancelarReserva
            // 
            btnCancelarReserva.Location = new Point(410, 290);
            btnCancelarReserva.Name = "btnCancelarReserva";
            btnCancelarReserva.Size = new Size(131, 29);
            btnCancelarReserva.TabIndex = 13;
            btnCancelarReserva.Text = "Cancelar Reserva";
            btnCancelarReserva.UseVisualStyleBackColor = true;
            btnCancelarReserva.Click += btnCancelarReserva_Click;
            // 
            // btnVerDetalles
            // 
            btnVerDetalles.Location = new Point(547, 290);
            btnVerDetalles.Name = "btnVerDetalles";
            btnVerDetalles.Size = new Size(131, 29);
            btnVerDetalles.TabIndex = 14;
            btnVerDetalles.Text = "Ver detalles";
            btnVerDetalles.UseVisualStyleBackColor = true;
            btnVerDetalles.Click += btnVerDetalles_Click;
            // 
            // btnRefrescar
            // 
            btnRefrescar.Location = new Point(522, 158);
            btnRefrescar.Name = "btnRefrescar";
            btnRefrescar.Size = new Size(135, 29);
            btnRefrescar.TabIndex = 15;
            btnRefrescar.Text = "Refrescar";
            btnRefrescar.UseVisualStyleBackColor = true;
            btnRefrescar.Click += btnRefrescar_Click;
            // 
            // lblInfoUsuario
            // 
            lblInfoUsuario.AutoSize = true;
            lblInfoUsuario.Location = new Point(12, 9);
            lblInfoUsuario.Name = "lblInfoUsuario";
            lblInfoUsuario.Size = new Size(90, 20);
            lblInfoUsuario.TabIndex = 16;
            lblInfoUsuario.Text = "Info usuario:";
            // 
            // lblContador
            // 
            lblContador.AutoSize = true;
            lblContador.Location = new Point(12, 294);
            lblContador.Name = "lblContador";
            lblContador.Size = new Size(102, 20);
            lblContador.TabIndex = 17;
            lblContador.Text = "Total reservas:";
            // 
            // FrmMisReservas
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(689, 524);
            Controls.Add(lblContador);
            Controls.Add(lblInfoUsuario);
            Controls.Add(btnRefrescar);
            Controls.Add(btnVerDetalles);
            Controls.Add(btnCancelarReserva);
            Controls.Add(btnEditarReserva);
            Controls.Add(btnNuevaReserva);
            Controls.Add(btnLimpiarFiltros);
            Controls.Add(btnFiltrar);
            Controls.Add(label4);
            Controls.Add(dtpFechaHasta);
            Controls.Add(label3);
            Controls.Add(dtpFechaDesde);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(cmbFiltroTiempo);
            Controls.Add(cmbFiltroEstado);
            Controls.Add(dgvReservas);
            Name = "FrmMisReservas";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Mis reservas";
            Load += FrmMisReservas_Load;
            ((System.ComponentModel.ISupportInitialize)dgvReservas).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvReservas;
        private ComboBox cmbFiltroEstado;
        private ComboBox cmbFiltroTiempo;
        private Label label1;
        private Label label2;
        private DateTimePicker dtpFechaDesde;
        private Label label3;
        private Label label4;
        private DateTimePicker dtpFechaHasta;
        private Button btnFiltrar;
        private Button btnLimpiarFiltros;
        private Button btnNuevaReserva;
        private Button btnEditarReserva;
        private Button btnCancelarReserva;
        private Button btnVerDetalles;
        private Button btnRefrescar;
        private Label lblInfoUsuario;
        private Label lblContador;
    }
}