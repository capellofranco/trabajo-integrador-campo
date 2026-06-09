namespace trabajo_integrador
{
    partial class FRMBitacora
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
            this.dgvBitacora = new System.Windows.Forms.DataGridView();
            this.dtpDesde = new System.Windows.Forms.DateTimePicker();
            this.dtpHasta = new System.Windows.Forms.DateTimePicker();
            this.btnFiltrarBitacora = new System.Windows.Forms.Button();
            this.lblDesdeBitacora = new System.Windows.Forms.Label();
            this.lblHastaBitacora = new System.Windows.Forms.Label();
            this.txtUsuario = new System.Windows.Forms.TextBox();
            this.cmbCriticidad = new System.Windows.Forms.ComboBox();
            this.cmbModulo = new System.Windows.Forms.ComboBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblCriticidadBitacora = new System.Windows.Forms.Label();
            this.lblModuloBitacora = new System.Windows.Forms.Label();
            this.lblUsuarioBitacora = new System.Windows.Forms.Label();
            this.lblBitacora = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBitacora)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvBitacora
            // 
            this.dgvBitacora.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBitacora.Location = new System.Drawing.Point(592, 78);
            this.dgvBitacora.Name = "dgvBitacora";
            this.dgvBitacora.Size = new System.Drawing.Size(644, 458);
            this.dgvBitacora.TabIndex = 0;
            // 
            // dtpDesde
            // 
            this.dtpDesde.Location = new System.Drawing.Point(24, 172);
            this.dtpDesde.Name = "dtpDesde";
            this.dtpDesde.Size = new System.Drawing.Size(200, 20);
            this.dtpDesde.TabIndex = 1;
            // 
            // dtpHasta
            // 
            this.dtpHasta.Location = new System.Drawing.Point(246, 172);
            this.dtpHasta.Name = "dtpHasta";
            this.dtpHasta.Size = new System.Drawing.Size(200, 20);
            this.dtpHasta.TabIndex = 2;
            // 
            // btnFiltrarBitacora
            // 
            this.btnFiltrarBitacora.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFiltrarBitacora.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFiltrarBitacora.ForeColor = System.Drawing.Color.Navy;
            this.btnFiltrarBitacora.Location = new System.Drawing.Point(154, 213);
            this.btnFiltrarBitacora.Margin = new System.Windows.Forms.Padding(2);
            this.btnFiltrarBitacora.Name = "btnFiltrarBitacora";
            this.btnFiltrarBitacora.Size = new System.Drawing.Size(162, 47);
            this.btnFiltrarBitacora.TabIndex = 6;
            this.btnFiltrarBitacora.Text = "FILTRAR";
            this.btnFiltrarBitacora.UseVisualStyleBackColor = true;
            this.btnFiltrarBitacora.Click += new System.EventHandler(this.button2_Click);
            this.btnFiltrarBitacora.MouseEnter += new System.EventHandler(this.button2_MouseEnter);
            this.btnFiltrarBitacora.MouseLeave += new System.EventHandler(this.button2_MouseLeave);
            // 
            // lblDesdeBitacora
            // 
            this.lblDesdeBitacora.AutoSize = true;
            this.lblDesdeBitacora.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDesdeBitacora.Location = new System.Drawing.Point(96, 153);
            this.lblDesdeBitacora.Name = "lblDesdeBitacora";
            this.lblDesdeBitacora.Size = new System.Drawing.Size(48, 16);
            this.lblDesdeBitacora.TabIndex = 7;
            this.lblDesdeBitacora.Text = "Desde";
            // 
            // lblHastaBitacora
            // 
            this.lblHastaBitacora.AutoSize = true;
            this.lblHastaBitacora.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHastaBitacora.Location = new System.Drawing.Point(326, 153);
            this.lblHastaBitacora.Name = "lblHastaBitacora";
            this.lblHastaBitacora.Size = new System.Drawing.Size(43, 16);
            this.lblHastaBitacora.TabIndex = 8;
            this.lblHastaBitacora.Text = "Hasta";
            // 
            // txtUsuario
            // 
            this.txtUsuario.Location = new System.Drawing.Point(125, 23);
            this.txtUsuario.Name = "txtUsuario";
            this.txtUsuario.Size = new System.Drawing.Size(254, 20);
            this.txtUsuario.TabIndex = 9;
            // 
            // cmbCriticidad
            // 
            this.cmbCriticidad.FormattingEnabled = true;
            this.cmbCriticidad.Location = new System.Drawing.Point(125, 100);
            this.cmbCriticidad.Name = "cmbCriticidad";
            this.cmbCriticidad.Size = new System.Drawing.Size(254, 21);
            this.cmbCriticidad.TabIndex = 11;
            // 
            // cmbModulo
            // 
            this.cmbModulo.FormattingEnabled = true;
            this.cmbModulo.Location = new System.Drawing.Point(125, 62);
            this.cmbModulo.Name = "cmbModulo";
            this.cmbModulo.Size = new System.Drawing.Size(254, 21);
            this.cmbModulo.TabIndex = 12;
            // 
            // panel1
            // 
            this.panel1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.lblCriticidadBitacora);
            this.panel1.Controls.Add(this.lblModuloBitacora);
            this.panel1.Controls.Add(this.lblUsuarioBitacora);
            this.panel1.Controls.Add(this.btnFiltrarBitacora);
            this.panel1.Controls.Add(this.txtUsuario);
            this.panel1.Controls.Add(this.lblDesdeBitacora);
            this.panel1.Controls.Add(this.lblHastaBitacora);
            this.panel1.Controls.Add(this.dtpDesde);
            this.panel1.Controls.Add(this.cmbCriticidad);
            this.panel1.Controls.Add(this.cmbModulo);
            this.panel1.Controls.Add(this.dtpHasta);
            this.panel1.Location = new System.Drawing.Point(69, 153);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(471, 282);
            this.panel1.TabIndex = 14;
            // 
            // lblCriticidadBitacora
            // 
            this.lblCriticidadBitacora.AutoSize = true;
            this.lblCriticidadBitacora.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCriticidadBitacora.Location = new System.Drawing.Point(54, 101);
            this.lblCriticidadBitacora.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblCriticidadBitacora.Name = "lblCriticidadBitacora";
            this.lblCriticidadBitacora.Size = new System.Drawing.Size(66, 16);
            this.lblCriticidadBitacora.TabIndex = 14;
            this.lblCriticidadBitacora.Text = "Criticidad:";
            // 
            // lblModuloBitacora
            // 
            this.lblModuloBitacora.AutoSize = true;
            this.lblModuloBitacora.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblModuloBitacora.Location = new System.Drawing.Point(65, 62);
            this.lblModuloBitacora.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblModuloBitacora.Name = "lblModuloBitacora";
            this.lblModuloBitacora.Size = new System.Drawing.Size(55, 16);
            this.lblModuloBitacora.TabIndex = 13;
            this.lblModuloBitacora.Text = "Modulo:";
            // 
            // lblUsuarioBitacora
            // 
            this.lblUsuarioBitacora.AutoSize = true;
            this.lblUsuarioBitacora.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUsuarioBitacora.Location = new System.Drawing.Point(63, 23);
            this.lblUsuarioBitacora.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblUsuarioBitacora.Name = "lblUsuarioBitacora";
            this.lblUsuarioBitacora.Size = new System.Drawing.Size(57, 16);
            this.lblUsuarioBitacora.TabIndex = 8;
            this.lblUsuarioBitacora.Text = "Usuario:";
            // 
            // lblBitacora
            // 
            this.lblBitacora.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBitacora.ForeColor = System.Drawing.Color.White;
            this.lblBitacora.Location = new System.Drawing.Point(433, 19);
            this.lblBitacora.Name = "lblBitacora";
            this.lblBitacora.Size = new System.Drawing.Size(300, 36);
            this.lblBitacora.TabIndex = 9;
            this.lblBitacora.Text = "BITACORA";
            this.lblBitacora.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // FRMBitacora
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(1265, 561);
            this.Controls.Add(this.lblBitacora);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.dgvBitacora);
            this.Name = "FRMBitacora";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FRMBitacora";
            this.Load += new System.EventHandler(this.FRMBitacora_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvBitacora)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvBitacora;
        private System.Windows.Forms.DateTimePicker dtpDesde;
        private System.Windows.Forms.DateTimePicker dtpHasta;
        private System.Windows.Forms.Button btnFiltrarBitacora;
        private System.Windows.Forms.Label lblDesdeBitacora;
        private System.Windows.Forms.Label lblHastaBitacora;
        private System.Windows.Forms.TextBox txtUsuario;
        private System.Windows.Forms.ComboBox cmbCriticidad;
        private System.Windows.Forms.ComboBox cmbModulo;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblBitacora;
        private System.Windows.Forms.Label lblCriticidadBitacora;
        private System.Windows.Forms.Label lblModuloBitacora;
        private System.Windows.Forms.Label lblUsuarioBitacora;
    }
}