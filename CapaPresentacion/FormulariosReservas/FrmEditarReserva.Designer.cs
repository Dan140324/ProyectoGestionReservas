namespace CapaPresentacion.FormulariosReservas
{
    partial class FrmEditarReserva
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
            lblIdReserva = new Label();
            lblInfoOriginal = new Label();
            cmbLaboratorio = new ComboBox();
            lblCapacidadLab = new Label();
            dtpHoraInicio = new DateTimePicker();
            label1 = new Label();
            label2 = new Label();
            dtpHoraFin = new DateTimePicker();
            nudCantidadUsuarios = new NumericUpDown();
            label3 = new Label();
            txtMotivo = new TextBox();
            label4 = new Label();
            label5 = new Label();
            lblDuracion = new Label();
            lblContadorMotivo = new Label();
            lblAdvertenciaHorario = new Label();
            lblAdvertenciaCapacidad = new Label();
            lblAdvertenciaDisponibilidad = new Label();
            btnGuardar = new Button();
            btnCancelar = new Button();
            dtpFecha = new DateTimePicker();
            label6 = new Label();
            lstReservasConflicto = new ListBox();
            ((System.ComponentModel.ISupportInitialize)nudCantidadUsuarios).BeginInit();
            SuspendLayout();
            // 
            // lblIdReserva
            // 
            lblIdReserva.AutoSize = true;
            lblIdReserva.Location = new Point(36, 29);
            lblIdReserva.Name = "lblIdReserva";
            lblIdReserva.Size = new Size(27, 20);
            lblIdReserva.TabIndex = 0;
            lblIdReserva.Text = "ID:";
            // 
            // lblInfoOriginal
            // 
            lblInfoOriginal.AutoSize = true;
            lblInfoOriginal.Location = new Point(36, 421);
            lblInfoOriginal.Name = "lblInfoOriginal";
            lblInfoOriginal.Size = new Size(93, 20);
            lblInfoOriginal.TabIndex = 1;
            lblInfoOriginal.Text = "Info original:";
            // 
            // cmbLaboratorio
            // 
            cmbLaboratorio.FormattingEnabled = true;
            cmbLaboratorio.Location = new Point(234, 45);
            cmbLaboratorio.Name = "cmbLaboratorio";
            cmbLaboratorio.Size = new Size(151, 28);
            cmbLaboratorio.TabIndex = 2;
            cmbLaboratorio.SelectedIndexChanged += cmbLaboratorio_SelectedIndexChanged;
            // 
            // lblCapacidadLab
            // 
            lblCapacidadLab.AutoSize = true;
            lblCapacidadLab.Font = new Font("Segoe UI", 7.8F, FontStyle.Italic, GraphicsUnit.Point, 0);
            lblCapacidadLab.Location = new Point(234, 76);
            lblCapacidadLab.Name = "lblCapacidadLab";
            lblCapacidadLab.Size = new Size(136, 17);
            lblCapacidadLab.TabIndex = 3;
            lblCapacidadLab.Text = "Capacidad laboratorio:";
            // 
            // dtpHoraInicio
            // 
            dtpHoraInicio.Format = DateTimePickerFormat.Short;
            dtpHoraInicio.Location = new Point(234, 207);
            dtpHoraInicio.Name = "dtpHoraInicio";
            dtpHoraInicio.Size = new Size(151, 27);
            dtpHoraInicio.TabIndex = 4;
            dtpHoraInicio.ValueChanged += dtpHoraInicio_ValueChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(234, 184);
            label1.Name = "label1";
            label1.Size = new Size(85, 20);
            label1.TabIndex = 5;
            label1.Text = "Hora inicio:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(234, 258);
            label2.Name = "label2";
            label2.Size = new Size(66, 20);
            label2.TabIndex = 7;
            label2.Text = "Hora fin:";
            // 
            // dtpHoraFin
            // 
            dtpHoraFin.Format = DateTimePickerFormat.Short;
            dtpHoraFin.Location = new Point(234, 281);
            dtpHoraFin.Name = "dtpHoraFin";
            dtpHoraFin.Size = new Size(151, 27);
            dtpHoraFin.TabIndex = 6;
            dtpHoraFin.ValueChanged += dtpHoraFin_ValueChanged;
            // 
            // nudCantidadUsuarios
            // 
            nudCantidadUsuarios.Location = new Point(460, 48);
            nudCantidadUsuarios.Name = "nudCantidadUsuarios";
            nudCantidadUsuarios.Size = new Size(150, 27);
            nudCantidadUsuarios.TabIndex = 8;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(460, 25);
            label3.Name = "label3";
            label3.Size = new Size(151, 20);
            label3.TabIndex = 9;
            label3.Text = "Cantidad de usuarios:";
            // 
            // txtMotivo
            // 
            txtMotivo.Location = new Point(460, 132);
            txtMotivo.Multiline = true;
            txtMotivo.Name = "txtMotivo";
            txtMotivo.Size = new Size(150, 34);
            txtMotivo.TabIndex = 10;
            txtMotivo.TextChanged += txtMotivo_TextChanged;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(234, 25);
            label4.Name = "label4";
            label4.Size = new Size(90, 20);
            label4.TabIndex = 11;
            label4.Text = "Laboratorio:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(460, 107);
            label5.Name = "label5";
            label5.Size = new Size(59, 20);
            label5.TabIndex = 12;
            label5.Text = "Motivo:";
            // 
            // lblDuracion
            // 
            lblDuracion.AutoSize = true;
            lblDuracion.Location = new Point(460, 207);
            lblDuracion.Name = "lblDuracion";
            lblDuracion.Size = new Size(72, 20);
            lblDuracion.TabIndex = 13;
            lblDuracion.Text = "Duración:";
            // 
            // lblContadorMotivo
            // 
            lblContadorMotivo.AutoSize = true;
            lblContadorMotivo.Font = new Font("Segoe UI", 7.8F, FontStyle.Italic, GraphicsUnit.Point, 0);
            lblContadorMotivo.Location = new Point(460, 169);
            lblContadorMotivo.Name = "lblContadorMotivo";
            lblContadorMotivo.Size = new Size(41, 17);
            lblContadorMotivo.TabIndex = 14;
            lblContadorMotivo.Text = "0/200";
            // 
            // lblAdvertenciaHorario
            // 
            lblAdvertenciaHorario.AutoSize = true;
            lblAdvertenciaHorario.Location = new Point(234, 324);
            lblAdvertenciaHorario.Name = "lblAdvertenciaHorario";
            lblAdvertenciaHorario.Size = new Size(143, 20);
            lblAdvertenciaHorario.TabIndex = 15;
            lblAdvertenciaHorario.Text = "Advertencia horario:";
            // 
            // lblAdvertenciaCapacidad
            // 
            lblAdvertenciaCapacidad.AutoSize = true;
            lblAdvertenciaCapacidad.Location = new Point(234, 356);
            lblAdvertenciaCapacidad.Name = "lblAdvertenciaCapacidad";
            lblAdvertenciaCapacidad.Size = new Size(164, 20);
            lblAdvertenciaCapacidad.TabIndex = 16;
            lblAdvertenciaCapacidad.Text = "Advertencia capacidad:";
            // 
            // lblAdvertenciaDisponibilidad
            // 
            lblAdvertenciaDisponibilidad.AutoSize = true;
            lblAdvertenciaDisponibilidad.Location = new Point(460, 281);
            lblAdvertenciaDisponibilidad.Name = "lblAdvertenciaDisponibilidad";
            lblAdvertenciaDisponibilidad.Size = new Size(191, 20);
            lblAdvertenciaDisponibilidad.TabIndex = 17;
            lblAdvertenciaDisponibilidad.Text = "Advertencia disponibilidad:";
            // 
            // btnGuardar
            // 
            btnGuardar.Location = new Point(539, 401);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(113, 37);
            btnGuardar.TabIndex = 18;
            btnGuardar.Text = "Guardar";
            btnGuardar.UseVisualStyleBackColor = true;
            btnGuardar.Click += btnGuardar_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.Location = new Point(675, 401);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(113, 37);
            btnCancelar.TabIndex = 19;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // dtpFecha
            // 
            dtpFecha.Location = new Point(234, 132);
            dtpFecha.Name = "dtpFecha";
            dtpFecha.Size = new Size(151, 27);
            dtpFecha.TabIndex = 20;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(234, 109);
            label6.Name = "label6";
            label6.Size = new Size(50, 20);
            label6.TabIndex = 21;
            label6.Text = "Fecha:";
            // 
            // lstReservasConflicto
            // 
            lstReservasConflicto.FormattingEnabled = true;
            lstReservasConflicto.Location = new Point(460, 247);
            lstReservasConflicto.Name = "lstReservasConflicto";
            lstReservasConflicto.Size = new Size(245, 24);
            lstReservasConflicto.TabIndex = 22;
            // 
            // FrmEditarReserva
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(lstReservasConflicto);
            Controls.Add(label6);
            Controls.Add(dtpFecha);
            Controls.Add(btnCancelar);
            Controls.Add(btnGuardar);
            Controls.Add(lblAdvertenciaDisponibilidad);
            Controls.Add(lblAdvertenciaCapacidad);
            Controls.Add(lblAdvertenciaHorario);
            Controls.Add(lblContadorMotivo);
            Controls.Add(lblDuracion);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(txtMotivo);
            Controls.Add(label3);
            Controls.Add(nudCantidadUsuarios);
            Controls.Add(label2);
            Controls.Add(dtpHoraFin);
            Controls.Add(label1);
            Controls.Add(dtpHoraInicio);
            Controls.Add(lblCapacidadLab);
            Controls.Add(cmbLaboratorio);
            Controls.Add(lblInfoOriginal);
            Controls.Add(lblIdReserva);
            Name = "FrmEditarReserva";
            Text = "Editar reserva";
            Load += FrmEditarReserva_Load;
            ((System.ComponentModel.ISupportInitialize)nudCantidadUsuarios).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblIdReserva;
        private Label lblInfoOriginal;
        private ComboBox cmbLaboratorio;
        private Label lblCapacidadLab;
        private DateTimePicker dtpHoraInicio;
        private Label label1;
        private Label label2;
        private DateTimePicker dtpHoraFin;
        private NumericUpDown nudCantidadUsuarios;
        private Label label3;
        private TextBox txtMotivo;
        private Label label4;
        private Label label5;
        private Label lblDuracion;
        private Label lblContadorMotivo;
        private Label lblAdvertenciaHorario;
        private Label lblAdvertenciaCapacidad;
        private Label lblAdvertenciaDisponibilidad;
        private Button btnGuardar;
        private Button btnCancelar;
        private DateTimePicker dtpFecha;
        private Label label6;
        private ListBox lstReservasConflicto;
    }
}