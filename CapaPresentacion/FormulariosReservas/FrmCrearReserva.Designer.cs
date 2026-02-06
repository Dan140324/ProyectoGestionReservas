namespace CapaPresentacion.FormulariosReservas
{
    partial class FrmCrearReserva
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
            lblLab = new Label();
            cmbLaboratorio = new ComboBox();
            lblCapacidadLab = new Label();
            label1 = new Label();
            dtpFecha = new DateTimePicker();
            label2 = new Label();
            label3 = new Label();
            dtpHoraInicio = new DateTimePicker();
            dtpHoraFin = new DateTimePicker();
            lblDuracion = new Label();
            lblAdvertenciaHorario = new Label();
            groupBox1 = new GroupBox();
            label4 = new Label();
            nudCantidadUsuarios = new NumericUpDown();
            lblAdvertenciaCapacidad = new Label();
            lblContadorMotivo = new Label();
            label6 = new Label();
            txtMotivo = new TextBox();
            groupBox2 = new GroupBox();
            btnVerDisponibilidad = new Button();
            lblReservConf = new Label();
            lblAdvertenciaDisponibilidad = new Label();
            lstReservasConflicto = new ListBox();
            label7 = new Label();
            btnGuardar = new Button();
            btnCancelar = new Button();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nudCantidadUsuarios).BeginInit();
            groupBox2.SuspendLayout();
            SuspendLayout();
            // 
            // lblLab
            // 
            lblLab.AutoSize = true;
            lblLab.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblLab.Location = new Point(237, 30);
            lblLab.Name = "lblLab";
            lblLab.Size = new Size(102, 23);
            lblLab.TabIndex = 0;
            lblLab.Text = "Laboratorio:";
            // 
            // cmbLaboratorio
            // 
            cmbLaboratorio.FormattingEnabled = true;
            cmbLaboratorio.Location = new Point(237, 56);
            cmbLaboratorio.Name = "cmbLaboratorio";
            cmbLaboratorio.Size = new Size(151, 28);
            cmbLaboratorio.TabIndex = 1;
            cmbLaboratorio.SelectedIndexChanged += cmbLaboratorio_SelectedIndexChanged;
            // 
            // lblCapacidadLab
            // 
            lblCapacidadLab.AutoSize = true;
            lblCapacidadLab.Font = new Font("Segoe UI", 9F, FontStyle.Italic, GraphicsUnit.Point, 0);
            lblCapacidadLab.Location = new Point(237, 87);
            lblCapacidadLab.Name = "lblCapacidadLab";
            lblCapacidadLab.Size = new Size(81, 20);
            lblCapacidadLab.TabIndex = 2;
            lblCapacidadLab.Text = "Capacidad:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(237, 133);
            label1.Name = "label1";
            label1.Size = new Size(58, 23);
            label1.TabIndex = 3;
            label1.Text = "Fecha:";
            // 
            // dtpFecha
            // 
            dtpFecha.Format = DateTimePickerFormat.Short;
            dtpFecha.Location = new Point(237, 159);
            dtpFecha.MinDate = new DateTime(2026, 2, 6, 0, 0, 0, 0);
            dtpFecha.Name = "dtpFecha";
            dtpFecha.Size = new Size(151, 27);
            dtpFecha.TabIndex = 4;
            dtpFecha.Value = new DateTime(2026, 2, 6, 2, 47, 53, 0);
            dtpFecha.ValueChanged += dtpFecha_ValueChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(21, 42);
            label2.Name = "label2";
            label2.Size = new Size(97, 23);
            label2.TabIndex = 5;
            label2.Text = "Hora Inicio:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(196, 42);
            label3.Name = "label3";
            label3.Size = new Size(78, 23);
            label3.TabIndex = 6;
            label3.Text = "Hora Fin:";
            // 
            // dtpHoraInicio
            // 
            dtpHoraInicio.Format = DateTimePickerFormat.Time;
            dtpHoraInicio.Location = new Point(21, 78);
            dtpHoraInicio.Name = "dtpHoraInicio";
            dtpHoraInicio.Size = new Size(130, 30);
            dtpHoraInicio.TabIndex = 7;
            dtpHoraInicio.Value = new DateTime(2026, 2, 6, 2, 51, 51, 0);
            dtpHoraInicio.ValueChanged += dtpHoraInicio_ValueChanged;
            // 
            // dtpHoraFin
            // 
            dtpHoraFin.Format = DateTimePickerFormat.Time;
            dtpHoraFin.Location = new Point(196, 78);
            dtpHoraFin.Name = "dtpHoraFin";
            dtpHoraFin.Size = new Size(130, 30);
            dtpHoraFin.TabIndex = 8;
            dtpHoraFin.Value = new DateTime(2026, 2, 6, 2, 52, 1, 0);
            dtpHoraFin.ValueChanged += dtpHoraFin_ValueChanged;
            // 
            // lblDuracion
            // 
            lblDuracion.AutoSize = true;
            lblDuracion.Font = new Font("Segoe UI", 9F, FontStyle.Italic, GraphicsUnit.Point, 0);
            lblDuracion.Location = new Point(21, 108);
            lblDuracion.Name = "lblDuracion";
            lblDuracion.Size = new Size(71, 20);
            lblDuracion.TabIndex = 9;
            lblDuracion.Text = "Duración:";
            // 
            // lblAdvertenciaHorario
            // 
            lblAdvertenciaHorario.AutoSize = true;
            lblAdvertenciaHorario.Font = new Font("Segoe UI", 9F, FontStyle.Italic, GraphicsUnit.Point, 0);
            lblAdvertenciaHorario.ForeColor = Color.Red;
            lblAdvertenciaHorario.Location = new Point(21, 128);
            lblAdvertenciaHorario.Name = "lblAdvertenciaHorario";
            lblAdvertenciaHorario.Size = new Size(87, 20);
            lblAdvertenciaHorario.TabIndex = 10;
            lblAdvertenciaHorario.Text = "Advertencia:";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(lblAdvertenciaHorario);
            groupBox1.Controls.Add(lblDuracion);
            groupBox1.Controls.Add(dtpHoraFin);
            groupBox1.Controls.Add(dtpHoraInicio);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(label2);
            groupBox1.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            groupBox1.Location = new Point(35, 271);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(355, 207);
            groupBox1.TabIndex = 11;
            groupBox1.TabStop = false;
            groupBox1.Text = "Horario";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.Location = new Point(433, 30);
            label4.Name = "label4";
            label4.Size = new Size(177, 23);
            label4.TabIndex = 12;
            label4.Text = "Cantidad de Usuarios:";
            // 
            // nudCantidadUsuarios
            // 
            nudCantidadUsuarios.Location = new Point(433, 56);
            nudCantidadUsuarios.Name = "nudCantidadUsuarios";
            nudCantidadUsuarios.Size = new Size(171, 27);
            nudCantidadUsuarios.TabIndex = 13;
            nudCantidadUsuarios.ValueChanged += nudCantidadUsuarios_ValueChanged;
            // 
            // lblAdvertenciaCapacidad
            // 
            lblAdvertenciaCapacidad.AutoSize = true;
            lblAdvertenciaCapacidad.Font = new Font("Segoe UI", 9F, FontStyle.Italic, GraphicsUnit.Point, 0);
            lblAdvertenciaCapacidad.ForeColor = Color.Red;
            lblAdvertenciaCapacidad.Location = new Point(433, 86);
            lblAdvertenciaCapacidad.Name = "lblAdvertenciaCapacidad";
            lblAdvertenciaCapacidad.Size = new Size(87, 20);
            lblAdvertenciaCapacidad.TabIndex = 14;
            lblAdvertenciaCapacidad.Text = "Advertencia:";
            // 
            // lblContadorMotivo
            // 
            lblContadorMotivo.AutoSize = true;
            lblContadorMotivo.Font = new Font("Segoe UI", 9F, FontStyle.Italic, GraphicsUnit.Point, 0);
            lblContadorMotivo.Location = new Point(432, 190);
            lblContadorMotivo.Name = "lblContadorMotivo";
            lblContadorMotivo.Size = new Size(47, 20);
            lblContadorMotivo.TabIndex = 17;
            lblContadorMotivo.Text = "0/200";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label6.Location = new Point(432, 133);
            label6.Name = "label6";
            label6.Size = new Size(172, 23);
            label6.TabIndex = 15;
            label6.Text = "Motivo de la Reserva:";
            // 
            // txtMotivo
            // 
            txtMotivo.Location = new Point(433, 159);
            txtMotivo.MaxLength = 200;
            txtMotivo.Name = "txtMotivo";
            txtMotivo.Size = new Size(171, 27);
            txtMotivo.TabIndex = 18;
            txtMotivo.TextChanged += txtMotivo_TextChanged;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(btnVerDisponibilidad);
            groupBox2.Controls.Add(lblReservConf);
            groupBox2.Controls.Add(lblAdvertenciaDisponibilidad);
            groupBox2.Controls.Add(lstReservasConflicto);
            groupBox2.Controls.Add(label7);
            groupBox2.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            groupBox2.Location = new Point(433, 271);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(355, 207);
            groupBox2.TabIndex = 19;
            groupBox2.TabStop = false;
            groupBox2.Text = "Disponibilidad";
            // 
            // btnVerDisponibilidad
            // 
            btnVerDisponibilidad.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnVerDisponibilidad.Location = new Point(70, 156);
            btnVerDisponibilidad.Name = "btnVerDisponibilidad";
            btnVerDisponibilidad.Size = new Size(225, 32);
            btnVerDisponibilidad.TabIndex = 12;
            btnVerDisponibilidad.Text = "Ver Horarios Disponibles";
            btnVerDisponibilidad.UseVisualStyleBackColor = true;
            btnVerDisponibilidad.Click += btnVerDisponibilidad_Click;
            // 
            // lblReservConf
            // 
            lblReservConf.AutoSize = true;
            lblReservConf.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblReservConf.Location = new Point(21, 55);
            lblReservConf.Name = "lblReservConf";
            lblReservConf.Size = new Size(173, 23);
            lblReservConf.TabIndex = 11;
            lblReservConf.Text = "Reservas en conflicto:";
            // 
            // lblAdvertenciaDisponibilidad
            // 
            lblAdvertenciaDisponibilidad.AutoSize = true;
            lblAdvertenciaDisponibilidad.Font = new Font("Segoe UI", 9F, FontStyle.Italic, GraphicsUnit.Point, 0);
            lblAdvertenciaDisponibilidad.ForeColor = SystemColors.Highlight;
            lblAdvertenciaDisponibilidad.Location = new Point(21, 29);
            lblAdvertenciaDisponibilidad.Name = "lblAdvertenciaDisponibilidad";
            lblAdvertenciaDisponibilidad.Size = new Size(87, 20);
            lblAdvertenciaDisponibilidad.TabIndex = 10;
            lblAdvertenciaDisponibilidad.Text = "Advertencia:";
            // 
            // lstReservasConflicto
            // 
            lstReservasConflicto.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lstReservasConflicto.FormattingEnabled = true;
            lstReservasConflicto.Location = new Point(21, 81);
            lstReservasConflicto.Name = "lstReservasConflicto";
            lstReservasConflicto.Size = new Size(317, 24);
            lstReservasConflicto.TabIndex = 10;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 9F, FontStyle.Italic, GraphicsUnit.Point, 0);
            label7.Location = new Point(21, 111);
            label7.Name = "label7";
            label7.Size = new Size(71, 20);
            label7.TabIndex = 9;
            label7.Text = "Duración:";
            // 
            // btnGuardar
            // 
            btnGuardar.Location = new Point(273, 530);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(117, 45);
            btnGuardar.TabIndex = 20;
            btnGuardar.Text = "Reservar";
            btnGuardar.UseVisualStyleBackColor = true;
            btnGuardar.Click += btnGuardar_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.Location = new Point(430, 530);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(117, 45);
            btnCancelar.TabIndex = 21;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // FrmCrearReserva
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(820, 611);
            Controls.Add(btnCancelar);
            Controls.Add(btnGuardar);
            Controls.Add(groupBox2);
            Controls.Add(txtMotivo);
            Controls.Add(lblContadorMotivo);
            Controls.Add(label6);
            Controls.Add(lblAdvertenciaCapacidad);
            Controls.Add(nudCantidadUsuarios);
            Controls.Add(label4);
            Controls.Add(groupBox1);
            Controls.Add(dtpFecha);
            Controls.Add(label1);
            Controls.Add(lblCapacidadLab);
            Controls.Add(cmbLaboratorio);
            Controls.Add(lblLab);
            Name = "FrmCrearReserva";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Crear Nueva Reserva";
            Load += FrmCrearReserva_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)nudCantidadUsuarios).EndInit();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblLab;
        private ComboBox cmbLaboratorio;
        private Label lblCapacidadLab;
        private Label label1;
        private DateTimePicker dtpFecha;
        private Label label2;
        private Label label3;
        private DateTimePicker dtpHoraInicio;
        private DateTimePicker dtpHoraFin;
        private Label lblDuracion;
        private Label lblAdvertenciaHorario;
        private GroupBox groupBox1;
        private Label label4;
        private NumericUpDown nudCantidadUsuarios;
        private Label lblAdvertenciaCapacidad;
        private Label lblContadorMotivo;
        private Label label6;
        private TextBox txtMotivo;
        private GroupBox groupBox2;
        private Label label7;
        private Label lblAdvertenciaDisponibilidad;
        private Button btnVerDisponibilidad;
        private Label lblReservConf;
        private ListBox lstReservasConflicto;
        private Button btnGuardar;
        private Button btnCancelar;
    }
}