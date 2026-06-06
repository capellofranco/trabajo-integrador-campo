namespace trabajo_integrador
{
    partial class FRMHistorico
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.btnRestaurar = new System.Windows.Forms.Button();
            this.btnAtras = new System.Windows.Forms.Button();
            this.btnAdelante = new System.Windows.Forms.Button();
            this.lblPrecioInfo = new System.Windows.Forms.Label();
            this.lblAuditoria = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(156, 79);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(919, 275);
            this.dataGridView1.TabIndex = 11;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // panel1
            // 
            this.panel1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.lblAuditoria);
            this.panel1.Controls.Add(this.lblPrecioInfo);
            this.panel1.Controls.Add(this.btnAdelante);
            this.panel1.Controls.Add(this.btnAtras);
            this.panel1.Controls.Add(this.btnRestaurar);
            this.panel1.Location = new System.Drawing.Point(251, 375);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(729, 121);
            this.panel1.TabIndex = 14;
            // 
            // lblTitulo
            // 
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.ForeColor = System.Drawing.Color.White;
            this.lblTitulo.Location = new System.Drawing.Point(465, 27);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(300, 36);
            this.lblTitulo.TabIndex = 9;
            this.lblTitulo.Text = "HISTORICO";
            this.lblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnRestaurar
            // 
            this.btnRestaurar.BackColor = System.Drawing.Color.White;
            this.btnRestaurar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRestaurar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRestaurar.ForeColor = System.Drawing.Color.Navy;
            this.btnRestaurar.Location = new System.Drawing.Point(271, 75);
            this.btnRestaurar.Margin = new System.Windows.Forms.Padding(2);
            this.btnRestaurar.Name = "btnRestaurar";
            this.btnRestaurar.Size = new System.Drawing.Size(186, 33);
            this.btnRestaurar.TabIndex = 5;
            this.btnRestaurar.Text = "RESTAURAR";
            this.btnRestaurar.UseVisualStyleBackColor = false;
            this.btnRestaurar.Click += new System.EventHandler(this.btnRestaurar_Click);
            this.btnRestaurar.MouseEnter += new System.EventHandler(this.btnRestaurar_MouseEnter);
            this.btnRestaurar.MouseLeave += new System.EventHandler(this.btnRestaurar_MouseLeave);
            // 
            // btnAtras
            // 
            this.btnAtras.BackColor = System.Drawing.Color.White;
            this.btnAtras.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAtras.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAtras.ForeColor = System.Drawing.Color.Navy;
            this.btnAtras.Location = new System.Drawing.Point(67, 75);
            this.btnAtras.Margin = new System.Windows.Forms.Padding(2);
            this.btnAtras.Name = "btnAtras";
            this.btnAtras.Size = new System.Drawing.Size(186, 33);
            this.btnAtras.TabIndex = 9;
            this.btnAtras.Text = "<---- ATRAS";
            this.btnAtras.UseVisualStyleBackColor = false;
            this.btnAtras.Click += new System.EventHandler(this.btnAtras_Click);
            this.btnAtras.MouseEnter += new System.EventHandler(this.btnAtras_MouseEnter);
            this.btnAtras.MouseLeave += new System.EventHandler(this.btnAtras_MouseLeave);
            // 
            // btnAdelante
            // 
            this.btnAdelante.BackColor = System.Drawing.Color.White;
            this.btnAdelante.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdelante.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdelante.ForeColor = System.Drawing.Color.Navy;
            this.btnAdelante.Location = new System.Drawing.Point(475, 75);
            this.btnAdelante.Margin = new System.Windows.Forms.Padding(2);
            this.btnAdelante.Name = "btnAdelante";
            this.btnAdelante.Size = new System.Drawing.Size(186, 33);
            this.btnAdelante.TabIndex = 10;
            this.btnAdelante.Text = "ADELANTE ---->";
            this.btnAdelante.UseVisualStyleBackColor = false;
            this.btnAdelante.Click += new System.EventHandler(this.btnAdelante_Click);
            this.btnAdelante.MouseEnter += new System.EventHandler(this.btnAdelante_MouseEnter);
            this.btnAdelante.MouseLeave += new System.EventHandler(this.btnAdelante_MouseLeave);
            // 
            // lblPrecioInfo
            // 
            this.lblPrecioInfo.AutoSize = true;
            this.lblPrecioInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPrecioInfo.ForeColor = System.Drawing.Color.Navy;
            this.lblPrecioInfo.Location = new System.Drawing.Point(150, 32);
            this.lblPrecioInfo.Name = "lblPrecioInfo";
            this.lblPrecioInfo.Size = new System.Drawing.Size(0, 16);
            this.lblPrecioInfo.TabIndex = 11;
            // 
            // lblAuditoria
            // 
            this.lblAuditoria.AutoSize = true;
            this.lblAuditoria.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAuditoria.ForeColor = System.Drawing.Color.Navy;
            this.lblAuditoria.Location = new System.Drawing.Point(415, 32);
            this.lblAuditoria.Name = "lblAuditoria";
            this.lblAuditoria.Size = new System.Drawing.Size(0, 16);
            this.lblAuditoria.TabIndex = 12;
            // 
            // FRMHistorico
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(1231, 523);
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.dataGridView1);
            this.Name = "FRMHistorico";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FRMHistorico";
            this.Load += new System.EventHandler(this.FRMHistorico_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Button btnRestaurar;
        private System.Windows.Forms.Button btnAdelante;
        private System.Windows.Forms.Button btnAtras;
        private System.Windows.Forms.Label lblAuditoria;
        private System.Windows.Forms.Label lblPrecioInfo;
    }
}