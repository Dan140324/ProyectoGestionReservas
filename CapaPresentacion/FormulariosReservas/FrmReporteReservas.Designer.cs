namespace CapaPresentacion.FormulariosReservas
{
    partial class FrmReporteReservas
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
            label4 = new Label();
            cmbFiltroLaboratorio = new ComboBox();
            label1 = new Label();
            cmbFiltroEstado = new ComboBox();
            label2 = new Label();
            cmbFiltroTiempo = new ComboBox();
            chkUsarFechaDesde = new CheckBox();
            chkUsarFechaHasta = new CheckBox();
            dtpFechaDesde = new DateTimePicker();
            dtpFechaHasta = new DateTimePicker();
            btnFiltrar = new Button();
            btnLimpiarFiltros = new Button();
            btnRefrescar = new Button();
            groupBox1 = new GroupBox();
            lblTotalReservas = new Label();
            lblActivas = new Label();
            lblPorcentajeActivas = new Label();
            lblCanceladas = new Label();
            lblPorcentajeCanceladas = new Label();
            lblPorcentajeFinalizadas = new Label();
            lblFinalizadas = new Label();
            lblTopLaboratorios = new Label();
            groupBox2 = new GroupBox();
            dgvReservas = new DataGridView();
            groupBox3 = new GroupBox();
            lblContador = new Label();
            btnVerDetalles = new Button();
            btnExportar = new Button();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvReservas).BeginInit();
            groupBox3.SuspendLayout();
            SuspendLayout();
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(23, 32);
            label4.Name = "label4";
            label4.Size = new Size(90, 20);
            label4.TabIndex = 13;
            label4.Text = "Laboratorio:";
            // 
            // cmbFiltroLaboratorio
            // 
            cmbFiltroLaboratorio.FormattingEnabled = true;
            cmbFiltroLaboratorio.Location = new Point(23, 52);
            cmbFiltroLaboratorio.Name = "cmbFiltroLaboratorio";
            cmbFiltroLaboratorio.Size = new Size(151, 28);
            cmbFiltroLaboratorio.TabIndex = 12;
            cmbFiltroLaboratorio.SelectedIndexChanged += cmbFiltroLaboratorio_SelectedIndexChanged;
            cmbFiltroLaboratorio.Click += cmbFiltroLaboratorio_SelectedIndexChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(253, 32);
            label1.Name = "label1";
            label1.Size = new Size(57, 20);
            label1.TabIndex = 15;
            label1.Text = "Estado:";
            // 
            // cmbFiltroEstado
            // 
            cmbFiltroEstado.FormattingEnabled = true;
            cmbFiltroEstado.Location = new Point(253, 52);
            cmbFiltroEstado.Name = "cmbFiltroEstado";
            cmbFiltroEstado.Size = new Size(151, 28);
            cmbFiltroEstado.TabIndex = 14;
            cmbFiltroEstado.SelectedIndexChanged += cmbFiltroEstado_SelectedIndexChanged;
            cmbFiltroEstado.Click += cmbFiltroEstado_SelectedIndexChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(23, 112);
            label2.Name = "label2";
            label2.Size = new Size(128, 20);
            label2.TabIndex = 17;
            label2.Text = "Rango de tiempo:";
            // 
            // cmbFiltroTiempo
            // 
            cmbFiltroTiempo.FormattingEnabled = true;
            cmbFiltroTiempo.Location = new Point(23, 135);
            cmbFiltroTiempo.Name = "cmbFiltroTiempo";
            cmbFiltroTiempo.Size = new Size(381, 28);
            cmbFiltroTiempo.TabIndex = 16;
            cmbFiltroTiempo.SelectedIndexChanged += cmbFiltroTiempo_SelectedIndexChanged;
            cmbFiltroTiempo.Click += cmbFiltroTiempo_SelectedIndexChanged;
            // 
            // chkUsarFechaDesde
            // 
            chkUsarFechaDesde.AutoSize = true;
            chkUsarFechaDesde.Location = new Point(32, 191);
            chkUsarFechaDesde.Name = "chkUsarFechaDesde";
            chkUsarFechaDesde.Size = new Size(76, 24);
            chkUsarFechaDesde.TabIndex = 18;
            chkUsarFechaDesde.Text = "Desde:";
            chkUsarFechaDesde.UseVisualStyleBackColor = true;
            chkUsarFechaDesde.CheckedChanged += chkUsarFechaDesde_CheckedChanged;
            // 
            // chkUsarFechaHasta
            // 
            chkUsarFechaHasta.AutoSize = true;
            chkUsarFechaHasta.Location = new Point(32, 221);
            chkUsarFechaHasta.Name = "chkUsarFechaHasta";
            chkUsarFechaHasta.Size = new Size(72, 24);
            chkUsarFechaHasta.TabIndex = 19;
            chkUsarFechaHasta.Text = "Hasta:";
            chkUsarFechaHasta.UseVisualStyleBackColor = true;
            chkUsarFechaHasta.CheckedChanged += chkUsarFechaHasta_CheckedChanged;
            // 
            // dtpFechaDesde
            // 
            dtpFechaDesde.CustomFormat = "\"dd/MM/yyyy\"";
            dtpFechaDesde.Location = new Point(114, 188);
            dtpFechaDesde.Name = "dtpFechaDesde";
            dtpFechaDesde.Size = new Size(124, 27);
            dtpFechaDesde.TabIndex = 20;
            // 
            // dtpFechaHasta
            // 
            dtpFechaHasta.CustomFormat = "\"dd/MM/yyyy\"";
            dtpFechaHasta.Location = new Point(114, 221);
            dtpFechaHasta.Name = "dtpFechaHasta";
            dtpFechaHasta.Size = new Size(124, 27);
            dtpFechaHasta.TabIndex = 21;
            // 
            // btnFiltrar
            // 
            btnFiltrar.Location = new Point(31, 266);
            btnFiltrar.Name = "btnFiltrar";
            btnFiltrar.Size = new Size(117, 29);
            btnFiltrar.TabIndex = 22;
            btnFiltrar.Text = "Filtrar";
            btnFiltrar.UseVisualStyleBackColor = true;
            btnFiltrar.Click += btnFiltrar_Click;
            // 
            // btnLimpiarFiltros
            // 
            btnLimpiarFiltros.Location = new Point(154, 266);
            btnLimpiarFiltros.Name = "btnLimpiarFiltros";
            btnLimpiarFiltros.Size = new Size(117, 29);
            btnLimpiarFiltros.TabIndex = 23;
            btnLimpiarFiltros.Text = "Limpiar filtros";
            btnLimpiarFiltros.UseVisualStyleBackColor = true;
            btnLimpiarFiltros.Click += btnLimpiarFiltros_Click;
            // 
            // btnRefrescar
            // 
            btnRefrescar.Location = new Point(277, 266);
            btnRefrescar.Name = "btnRefrescar";
            btnRefrescar.Size = new Size(117, 29);
            btnRefrescar.TabIndex = 24;
            btnRefrescar.Text = "Refrescar";
            btnRefrescar.UseVisualStyleBackColor = true;
            btnRefrescar.Click += btnRefrescar_Click;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(btnRefrescar);
            groupBox1.Controls.Add(btnLimpiarFiltros);
            groupBox1.Controls.Add(btnFiltrar);
            groupBox1.Controls.Add(dtpFechaHasta);
            groupBox1.Controls.Add(dtpFechaDesde);
            groupBox1.Controls.Add(chkUsarFechaHasta);
            groupBox1.Controls.Add(chkUsarFechaDesde);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(cmbFiltroTiempo);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(cmbFiltroEstado);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(cmbFiltroLaboratorio);
            groupBox1.Location = new Point(59, 10);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(424, 330);
            groupBox1.TabIndex = 25;
            groupBox1.TabStop = false;
            groupBox1.Text = "Filtros";
            // 
            // lblTotalReservas
            // 
            lblTotalReservas.AutoSize = true;
            lblTotalReservas.Location = new Point(35, 34);
            lblTotalReservas.Name = "lblTotalReservas";
            lblTotalReservas.Size = new Size(57, 20);
            lblTotalReservas.TabIndex = 26;
            lblTotalReservas.Text = "Total: 0";
            // 
            // lblActivas
            // 
            lblActivas.AutoSize = true;
            lblActivas.ForeColor = Color.Green;
            lblActivas.Location = new Point(35, 66);
            lblActivas.Name = "lblActivas";
            lblActivas.Size = new Size(71, 20);
            lblActivas.TabIndex = 27;
            lblActivas.Text = "Activas: 0";
            // 
            // lblPorcentajeActivas
            // 
            lblPorcentajeActivas.AutoSize = true;
            lblPorcentajeActivas.ForeColor = Color.Green;
            lblPorcentajeActivas.Location = new Point(145, 66);
            lblPorcentajeActivas.Name = "lblPorcentajeActivas";
            lblPorcentajeActivas.Size = new Size(29, 20);
            lblPorcentajeActivas.TabIndex = 28;
            lblPorcentajeActivas.Text = "0%";
            // 
            // lblCanceladas
            // 
            lblCanceladas.AutoSize = true;
            lblCanceladas.ForeColor = Color.Red;
            lblCanceladas.Location = new Point(32, 95);
            lblCanceladas.Name = "lblCanceladas";
            lblCanceladas.Size = new Size(99, 20);
            lblCanceladas.TabIndex = 29;
            lblCanceladas.Text = "Canceladas: 0";
            // 
            // lblPorcentajeCanceladas
            // 
            lblPorcentajeCanceladas.AutoSize = true;
            lblPorcentajeCanceladas.ForeColor = Color.Red;
            lblPorcentajeCanceladas.Location = new Point(145, 95);
            lblPorcentajeCanceladas.Name = "lblPorcentajeCanceladas";
            lblPorcentajeCanceladas.Size = new Size(29, 20);
            lblPorcentajeCanceladas.TabIndex = 30;
            lblPorcentajeCanceladas.Text = "0%";
            // 
            // lblPorcentajeFinalizadas
            // 
            lblPorcentajeFinalizadas.AutoSize = true;
            lblPorcentajeFinalizadas.ForeColor = Color.Gray;
            lblPorcentajeFinalizadas.Location = new Point(145, 124);
            lblPorcentajeFinalizadas.Name = "lblPorcentajeFinalizadas";
            lblPorcentajeFinalizadas.Size = new Size(29, 20);
            lblPorcentajeFinalizadas.TabIndex = 32;
            lblPorcentajeFinalizadas.Text = "0%";
            // 
            // lblFinalizadas
            // 
            lblFinalizadas.AutoSize = true;
            lblFinalizadas.ForeColor = Color.Gray;
            lblFinalizadas.Location = new Point(34, 124);
            lblFinalizadas.Name = "lblFinalizadas";
            lblFinalizadas.Size = new Size(97, 20);
            lblFinalizadas.TabIndex = 31;
            lblFinalizadas.Text = "Finalizadas: 0";
            // 
            // lblTopLaboratorios
            // 
            lblTopLaboratorios.AutoSize = true;
            lblTopLaboratorios.ForeColor = Color.RoyalBlue;
            lblTopLaboratorios.Location = new Point(32, 155);
            lblTopLaboratorios.Name = "lblTopLaboratorios";
            lblTopLaboratorios.Size = new Size(122, 20);
            lblTopLaboratorios.TabIndex = 33;
            lblTopLaboratorios.Text = "Top laboratorios:";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(lblTopLaboratorios);
            groupBox2.Controls.Add(lblPorcentajeFinalizadas);
            groupBox2.Controls.Add(lblFinalizadas);
            groupBox2.Controls.Add(lblPorcentajeCanceladas);
            groupBox2.Controls.Add(lblCanceladas);
            groupBox2.Controls.Add(lblPorcentajeActivas);
            groupBox2.Controls.Add(lblActivas);
            groupBox2.Controls.Add(lblTotalReservas);
            groupBox2.Location = new Point(514, 12);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(424, 200);
            groupBox2.TabIndex = 34;
            groupBox2.TabStop = false;
            groupBox2.Text = "Estadísticas";
            // 
            // dgvReservas
            // 
            dgvReservas.AllowUserToAddRows = false;
            dgvReservas.AllowUserToDeleteRows = false;
            dgvReservas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvReservas.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvReservas.Location = new Point(6, 26);
            dgvReservas.MultiSelect = false;
            dgvReservas.Name = "dgvReservas";
            dgvReservas.ReadOnly = true;
            dgvReservas.RowHeadersWidth = 51;
            dgvReservas.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvReservas.Size = new Size(867, 222);
            dgvReservas.TabIndex = 35;
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(dgvReservas);
            groupBox3.Location = new Point(59, 355);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(879, 247);
            groupBox3.TabIndex = 36;
            groupBox3.TabStop = false;
            groupBox3.Text = "Reservas";
            // 
            // lblContador
            // 
            lblContador.AutoSize = true;
            lblContador.Font = new Font("Segoe UI", 9F, FontStyle.Italic, GraphicsUnit.Point, 0);
            lblContador.Location = new Point(65, 606);
            lblContador.Name = "lblContador";
            lblContador.Size = new Size(154, 20);
            lblContador.TabIndex = 37;
            lblContador.Text = "Mostrando (0) reservas";
            // 
            // btnVerDetalles
            // 
            btnVerDetalles.Location = new Point(386, 643);
            btnVerDetalles.Name = "btnVerDetalles";
            btnVerDetalles.Size = new Size(113, 42);
            btnVerDetalles.TabIndex = 38;
            btnVerDetalles.Text = "Ver detalles";
            btnVerDetalles.UseVisualStyleBackColor = true;
            btnVerDetalles.Click += btnVerDetalles_Click;
            // 
            // btnExportar
            // 
            btnExportar.Location = new Point(514, 643);
            btnExportar.Name = "btnExportar";
            btnExportar.Size = new Size(113, 42);
            btnExportar.TabIndex = 39;
            btnExportar.Text = "Exportar";
            btnExportar.UseVisualStyleBackColor = true;
            btnExportar.Click += btnExportar_Click;
            // 
            // FrmReporteReservas
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1021, 695);
            Controls.Add(btnExportar);
            Controls.Add(btnVerDetalles);
            Controls.Add(lblContador);
            Controls.Add(groupBox3);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Name = "FrmReporteReservas";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FrmReporteReservas";
            Load += FrmReporteReservas_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvReservas).EndInit();
            groupBox3.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label4;
        private ComboBox cmbFiltroLaboratorio;
        private Label label1;
        private ComboBox cmbFiltroEstado;
        private Label label2;
        private ComboBox cmbFiltroTiempo;
        private CheckBox chkUsarFechaDesde;
        private CheckBox chkUsarFechaHasta;
        private DateTimePicker dtpFechaDesde;
        private DateTimePicker dtpFechaHasta;
        private Button btnFiltrar;
        private Button btnLimpiarFiltros;
        private Button btnRefrescar;
        private GroupBox groupBox1;
        private Label lblTotalReservas;
        private Label lblActivas;
        private Label lblPorcentajeActivas;
        private Label lblCanceladas;
        private Label lblPorcentajeCanceladas;
        private Label lblPorcentajeFinalizadas;
        private Label lblFinalizadas;
        private Label lblTopLaboratorios;
        private GroupBox groupBox2;
        private DataGridView dgvReservas;
        private GroupBox groupBox3;
        private Label lblContador;
        private Button btnVerDetalles;
        private Button btnExportar;
    }
}