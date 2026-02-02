namespace CapaPresentacion
{
    partial class FrmLaboratorios
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            lblListadeLaboratorios = new Label();
            dgvTablaLaboratorios = new DataGridView();
            btnAgregarLaboratorio = new Button();
            btnEliminarLaboratorio = new Button();
            btnEditarLaboratorio = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvTablaLaboratorios).BeginInit();
            SuspendLayout();
            // 
            // lblListadeLaboratorios
            // 
            lblListadeLaboratorios.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblListadeLaboratorios.AutoSize = true;
            lblListadeLaboratorios.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblListadeLaboratorios.ImageAlign = ContentAlignment.TopCenter;
            lblListadeLaboratorios.Location = new Point(246, 22);
            lblListadeLaboratorios.Name = "lblListadeLaboratorios";
            lblListadeLaboratorios.Size = new Size(210, 28);
            lblListadeLaboratorios.TabIndex = 1;
            lblListadeLaboratorios.Text = "Lista de Laboratorios";
            lblListadeLaboratorios.TextAlign = ContentAlignment.TopCenter;
            // 
            // dgvTablaLaboratorios
            // 
            dgvTablaLaboratorios.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvTablaLaboratorios.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvTablaLaboratorios.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvTablaLaboratorios.Location = new Point(12, 128);
            dgvTablaLaboratorios.MultiSelect = false;
            dgvTablaLaboratorios.Name = "dgvTablaLaboratorios";
            dgvTablaLaboratorios.ReadOnly = true;
            dgvTablaLaboratorios.RowHeadersVisible = false;
            dgvTablaLaboratorios.RowHeadersWidth = 51;
            dgvTablaLaboratorios.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvTablaLaboratorios.Size = new Size(677, 373);
            dgvTablaLaboratorios.TabIndex = 2;
            // 
            // btnAgregarLaboratorio
            // 
            btnAgregarLaboratorio.Location = new Point(12, 86);
            btnAgregarLaboratorio.Name = "btnAgregarLaboratorio";
            btnAgregarLaboratorio.Size = new Size(157, 36);
            btnAgregarLaboratorio.TabIndex = 3;
            btnAgregarLaboratorio.Text = "Agregar Laboratorio";
            btnAgregarLaboratorio.UseVisualStyleBackColor = true;
            btnAgregarLaboratorio.Click += btnAgregarLaboratorio_Click;
            // 
            // btnEliminarLaboratorio
            // 
            btnEliminarLaboratorio.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnEliminarLaboratorio.Location = new Point(595, 93);
            btnEliminarLaboratorio.Name = "btnEliminarLaboratorio";
            btnEliminarLaboratorio.Size = new Size(94, 29);
            btnEliminarLaboratorio.TabIndex = 4;
            btnEliminarLaboratorio.Text = "Eliminar";
            btnEliminarLaboratorio.UseVisualStyleBackColor = true;
            btnEliminarLaboratorio.Click += this.btnEliminarLaboratorio_Click;
            // 
            // btnEditarLaboratorio
            // 
            btnEditarLaboratorio.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnEditarLaboratorio.Location = new Point(495, 93);
            btnEditarLaboratorio.Name = "btnEditarLaboratorio";
            btnEditarLaboratorio.Size = new Size(94, 29);
            btnEditarLaboratorio.TabIndex = 5;
            btnEditarLaboratorio.Text = "Editar";
            btnEditarLaboratorio.UseVisualStyleBackColor = true;
            btnEditarLaboratorio.Click += btnEditarLaboratorio_Click;
            // 
            // FrmLaboratorios
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(701, 513);
            Controls.Add(btnEditarLaboratorio);
            Controls.Add(btnEliminarLaboratorio);
            Controls.Add(btnAgregarLaboratorio);
            Controls.Add(dgvTablaLaboratorios);
            Controls.Add(lblListadeLaboratorios);
            Name = "FrmLaboratorios";
            Text = "Laboratorios";
            ((System.ComponentModel.ISupportInitialize)dgvTablaLaboratorios).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label lblListadeLaboratorios;
        private DataGridView dgvTablaLaboratorios;
        private Button btnAgregarLaboratorio;
        private Button btnEliminarLaboratorio;
        private Button btnEditarLaboratorio;
    }
}
