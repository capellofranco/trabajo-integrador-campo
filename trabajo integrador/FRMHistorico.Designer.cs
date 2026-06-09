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
            this.dgwHistoricoProducto = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblAuditoriaHistorico = new System.Windows.Forms.Label();
            this.lblPrecioInfoHistorico = new System.Windows.Forms.Label();
            this.btnAdelanteHistorico = new System.Windows.Forms.Button();
            this.btnAtrasHistorico = new System.Windows.Forms.Button();
            this.btnRestaurarHistorico = new System.Windows.Forms.Button();
            this.lblHistorico = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgwHistoricoProducto)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgwHistoricoProducto
            // 
            this.dgwHistoricoProducto.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgwHistoricoProducto.Location = new System.Drawing.Point(156, 79);
            this.dgwHistoricoProducto.Name = "dgwHistoricoProducto";
            this.dgwHistoricoProducto.Size = new System.Drawing.Size(919, 275);
            this.dgwHistoricoProducto.TabIndex = 11;
            this.dgwHistoricoProducto.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            this.dgwHistoricoProducto.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // panel1
            // 
            this.panel1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.lblAuditoriaHistorico);
            this.panel1.Controls.Add(this.lblPrecioInfoHistorico);
            this.panel1.Controls.Add(this.btnAdelanteHistorico);
            this.panel1.Controls.Add(this.btnAtrasHistorico);
            this.panel1.Controls.Add(this.btnRestaurarHistorico);
            this.panel1.Location = new System.Drawing.Point(251, 375);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(729, 121);
            this.panel1.TabIndex = 14;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // lblAuditoriaHistorico
            // 
            this.lblAuditoriaHistorico.AutoSize = true;
            this.lblAuditoriaHistorico.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAuditoriaHistorico.ForeColor = System.Drawing.Color.Navy;
            this.lblAuditoriaHistorico.Location = new System.Drawing.Point(415, 32);
            this.lblAuditoriaHistorico.Name = "lblAuditoriaHistorico";
            this.lblAuditoriaHistorico.Size = new System.Drawing.Size(0, 16);
            this.lblAuditoriaHistorico.TabIndex = 12;
            // 
            // lblPrecioInfoHistorico
            // 
            this.lblPrecioInfoHistorico.AutoSize = true;
            this.lblPrecioInfoHistorico.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPrecioInfoHistorico.ForeColor = System.Drawing.Color.Navy;
            this.lblPrecioInfoHistorico.Location = new System.Drawing.Point(150, 32);
            this.lblPrecioInfoHistorico.Name = "lblPrecioInfoHistorico";
            this.lblPrecioInfoHistorico.Size = new System.Drawing.Size(0, 16);
            this.lblPrecioInfoHistorico.TabIndex = 11;
            // 
            // btnAdelanteHistorico
            // 
            this.btnAdelanteHistorico.BackColor = System.Drawing.Color.White;
            this.btnAdelanteHistorico.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdelanteHistorico.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdelanteHistorico.ForeColor = System.Drawing.Color.Navy;
            this.btnAdelanteHistorico.Location = new System.Drawing.Point(475, 75);
            this.btnAdelanteHistorico.Margin = new System.Windows.Forms.Padding(2);
            this.btnAdelanteHistorico.Name = "btnAdelanteHistorico";
            this.btnAdelanteHistorico.Size = new System.Drawing.Size(186, 33);
            this.btnAdelanteHistorico.TabIndex = 10;
            this.btnAdelanteHistorico.Text = "ADELANTE ---->";
            this.btnAdelanteHistorico.UseVisualStyleBackColor = false;
            this.btnAdelanteHistorico.Click += new System.EventHandler(this.btnAdelante_Click);
            this.btnAdelanteHistorico.MouseEnter += new System.EventHandler(this.btnAdelante_MouseEnter);
            this.btnAdelanteHistorico.MouseLeave += new System.EventHandler(this.btnAdelante_MouseLeave);
            // 
            // btnAtrasHistorico
            // 
            this.btnAtrasHistorico.BackColor = System.Drawing.Color.White;
            this.btnAtrasHistorico.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAtrasHistorico.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAtrasHistorico.ForeColor = System.Drawing.Color.Navy;
            this.btnAtrasHistorico.Location = new System.Drawing.Point(67, 75);
            this.btnAtrasHistorico.Margin = new System.Windows.Forms.Padding(2);
            this.btnAtrasHistorico.Name = "btnAtrasHistorico";
            this.btnAtrasHistorico.Size = new System.Drawing.Size(186, 33);
            this.btnAtrasHistorico.TabIndex = 9;
            this.btnAtrasHistorico.Text = "<---- ATRAS";
            this.btnAtrasHistorico.UseVisualStyleBackColor = false;
            this.btnAtrasHistorico.Click += new System.EventHandler(this.btnAtras_Click);
            this.btnAtrasHistorico.MouseEnter += new System.EventHandler(this.btnAtras_MouseEnter);
            this.btnAtrasHistorico.MouseLeave += new System.EventHandler(this.btnAtras_MouseLeave);
            // 
            // btnRestaurarHistorico
            // 
            this.btnRestaurarHistorico.BackColor = System.Drawing.Color.White;
            this.btnRestaurarHistorico.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRestaurarHistorico.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRestaurarHistorico.ForeColor = System.Drawing.Color.Navy;
            this.btnRestaurarHistorico.Location = new System.Drawing.Point(271, 75);
            this.btnRestaurarHistorico.Margin = new System.Windows.Forms.Padding(2);
            this.btnRestaurarHistorico.Name = "btnRestaurarHistorico";
            this.btnRestaurarHistorico.Size = new System.Drawing.Size(186, 33);
            this.btnRestaurarHistorico.TabIndex = 5;
            this.btnRestaurarHistorico.Text = "RESTAURAR";
            this.btnRestaurarHistorico.UseVisualStyleBackColor = false;
            this.btnRestaurarHistorico.Click += new System.EventHandler(this.btnRestaurar_Click);
            this.btnRestaurarHistorico.MouseEnter += new System.EventHandler(this.btnRestaurar_MouseEnter);
            this.btnRestaurarHistorico.MouseLeave += new System.EventHandler(this.btnRestaurar_MouseLeave);
            // 
            // lblHistorico
            // 
            this.lblHistorico.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHistorico.ForeColor = System.Drawing.Color.White;
            this.lblHistorico.Location = new System.Drawing.Point(465, 27);
            this.lblHistorico.Name = "lblHistorico";
            this.lblHistorico.Size = new System.Drawing.Size(300, 36);
            this.lblHistorico.TabIndex = 9;
            this.lblHistorico.Text = "HISTORICO";
            this.lblHistorico.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // FRMHistorico
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(1231, 523);
            this.Controls.Add(this.lblHistorico);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.dgwHistoricoProducto);
            this.Name = "FRMHistorico";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FRMHistorico";
            this.Load += new System.EventHandler(this.FRMHistorico_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgwHistoricoProducto)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgwHistoricoProducto;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblHistorico;
        private System.Windows.Forms.Button btnRestaurarHistorico;
        private System.Windows.Forms.Button btnAdelanteHistorico;
        private System.Windows.Forms.Button btnAtrasHistorico;
        private System.Windows.Forms.Label lblAuditoriaHistorico;
        private System.Windows.Forms.Label lblPrecioInfoHistorico;
    }
}