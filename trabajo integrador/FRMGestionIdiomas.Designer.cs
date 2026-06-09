namespace trabajo_integrador
{
    partial class FRMGestionIdiomas
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
            this.txtNombreIdioma = new System.Windows.Forms.TextBox();
            this.lblNombreIdioma = new System.Windows.Forms.Label();
            this.dgvTraducciones = new System.Windows.Forms.DataGridView();
            this.btnActualizar = new System.Windows.Forms.Button();
            this.btnCrearIdioma = new System.Windows.Forms.Button();
            this.cmbIdiomasEditar = new System.Windows.Forms.ComboBox();
            this.NombreControl = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Texto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblSeleccionarIdioma = new System.Windows.Forms.Label();
            this.lblGestiondeIdiomaTitulo = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTraducciones)).BeginInit();
            this.SuspendLayout();
            // 
            // txtNombreIdioma
            // 
            this.txtNombreIdioma.Location = new System.Drawing.Point(34, 207);
            this.txtNombreIdioma.Name = "txtNombreIdioma";
            this.txtNombreIdioma.Size = new System.Drawing.Size(132, 20);
            this.txtNombreIdioma.TabIndex = 0;
            // 
            // lblNombreIdioma
            // 
            this.lblNombreIdioma.AutoSize = true;
            this.lblNombreIdioma.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNombreIdioma.ForeColor = System.Drawing.Color.White;
            this.lblNombreIdioma.Location = new System.Drawing.Point(50, 188);
            this.lblNombreIdioma.Name = "lblNombreIdioma";
            this.lblNombreIdioma.Size = new System.Drawing.Size(100, 16);
            this.lblNombreIdioma.TabIndex = 1;
            this.lblNombreIdioma.Text = "Nombre Idioma";
            // 
            // dgvTraducciones
            // 
            this.dgvTraducciones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTraducciones.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.NombreControl,
            this.Texto});
            this.dgvTraducciones.Location = new System.Drawing.Point(195, 94);
            this.dgvTraducciones.Name = "dgvTraducciones";
            this.dgvTraducciones.Size = new System.Drawing.Size(318, 292);
            this.dgvTraducciones.TabIndex = 2;
            // 
            // btnActualizar
            // 
            this.btnActualizar.BackColor = System.Drawing.Color.White;
            this.btnActualizar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnActualizar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnActualizar.ForeColor = System.Drawing.Color.Navy;
            this.btnActualizar.Location = new System.Drawing.Point(264, 406);
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.Size = new System.Drawing.Size(159, 48);
            this.btnActualizar.TabIndex = 3;
            this.btnActualizar.Text = "ACTUALIZAR IDIOMA";
            this.btnActualizar.UseVisualStyleBackColor = false;
            this.btnActualizar.Click += new System.EventHandler(this.btnGuardar_Click);
            this.btnActualizar.MouseEnter += new System.EventHandler(this.btnActualizar_MouseEnter);
            this.btnActualizar.MouseLeave += new System.EventHandler(this.btnActualizar_MouseLeave);
            // 
            // btnCrearIdioma
            // 
            this.btnCrearIdioma.BackColor = System.Drawing.Color.White;
            this.btnCrearIdioma.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCrearIdioma.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCrearIdioma.ForeColor = System.Drawing.Color.Navy;
            this.btnCrearIdioma.Location = new System.Drawing.Point(34, 254);
            this.btnCrearIdioma.Name = "btnCrearIdioma";
            this.btnCrearIdioma.Size = new System.Drawing.Size(131, 42);
            this.btnCrearIdioma.TabIndex = 4;
            this.btnCrearIdioma.Text = "CREAR IDIOMA";
            this.btnCrearIdioma.UseVisualStyleBackColor = false;
            this.btnCrearIdioma.Click += new System.EventHandler(this.btnCrearIdioma_Click);
            this.btnCrearIdioma.MouseEnter += new System.EventHandler(this.btnCrearIdioma_MouseEnter);
            this.btnCrearIdioma.MouseLeave += new System.EventHandler(this.btnCrearIdioma_MouseLeave);
            // 
            // cmbIdiomasEditar
            // 
            this.cmbIdiomasEditar.FormattingEnabled = true;
            this.cmbIdiomasEditar.Location = new System.Drawing.Point(34, 127);
            this.cmbIdiomasEditar.Name = "cmbIdiomasEditar";
            this.cmbIdiomasEditar.Size = new System.Drawing.Size(132, 21);
            this.cmbIdiomasEditar.TabIndex = 5;
            this.cmbIdiomasEditar.SelectedIndexChanged += new System.EventHandler(this.cmbIdiomasEditar_SelectedIndexChanged);
            // 
            // NombreControl
            // 
            this.NombreControl.HeaderText = "NombreControl";
            this.NombreControl.Name = "NombreControl";
            // 
            // Texto
            // 
            this.Texto.HeaderText = "Texto";
            this.Texto.Name = "Texto";
            // 
            // lblSeleccionarIdioma
            // 
            this.lblSeleccionarIdioma.AutoSize = true;
            this.lblSeleccionarIdioma.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSeleccionarIdioma.ForeColor = System.Drawing.Color.White;
            this.lblSeleccionarIdioma.Location = new System.Drawing.Point(37, 108);
            this.lblSeleccionarIdioma.Name = "lblSeleccionarIdioma";
            this.lblSeleccionarIdioma.Size = new System.Drawing.Size(123, 16);
            this.lblSeleccionarIdioma.TabIndex = 7;
            this.lblSeleccionarIdioma.Text = "Seleccionar Idioma";
            // 
            // lblGestiondeIdiomaTitulo
            // 
            this.lblGestiondeIdiomaTitulo.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGestiondeIdiomaTitulo.ForeColor = System.Drawing.Color.White;
            this.lblGestiondeIdiomaTitulo.Location = new System.Drawing.Point(16, 23);
            this.lblGestiondeIdiomaTitulo.Name = "lblGestiondeIdiomaTitulo";
            this.lblGestiondeIdiomaTitulo.Size = new System.Drawing.Size(601, 36);
            this.lblGestiondeIdiomaTitulo.TabIndex = 14;
            this.lblGestiondeIdiomaTitulo.Text = "GESTION DE IDIOMAS";
            this.lblGestiondeIdiomaTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // FRMGestionIdiomas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(634, 482);
            this.Controls.Add(this.lblGestiondeIdiomaTitulo);
            this.Controls.Add(this.lblSeleccionarIdioma);
            this.Controls.Add(this.cmbIdiomasEditar);
            this.Controls.Add(this.btnCrearIdioma);
            this.Controls.Add(this.btnActualizar);
            this.Controls.Add(this.dgvTraducciones);
            this.Controls.Add(this.lblNombreIdioma);
            this.Controls.Add(this.txtNombreIdioma);
            this.Name = "FRMGestionIdiomas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FRMGestionIdiomas";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FRMGestionIdiomas_FormClosed_1);
            this.Load += new System.EventHandler(this.FRMGestionIdiomas_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTraducciones)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtNombreIdioma;
        private System.Windows.Forms.Label lblNombreIdioma;
        private System.Windows.Forms.DataGridView dgvTraducciones;
        private System.Windows.Forms.Button btnActualizar;
        private System.Windows.Forms.DataGridViewTextBoxColumn NombreControl;
        private System.Windows.Forms.DataGridViewTextBoxColumn Texto;
        private System.Windows.Forms.Button btnCrearIdioma;
        private System.Windows.Forms.ComboBox cmbIdiomasEditar;
        private System.Windows.Forms.Label lblSeleccionarIdioma;
        private System.Windows.Forms.Label lblGestiondeIdiomaTitulo;
    }
}