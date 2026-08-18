namespace trabajo_integrador
{
    partial class FRMProducto
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
            this.dgwProductos = new System.Windows.Forms.DataGridView();
            this.lblProductos = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgwProductos)).BeginInit();
            this.SuspendLayout();
            // 
            // dgwProductos
            // 
            this.dgwProductos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgwProductos.Location = new System.Drawing.Point(49, 116);
            this.dgwProductos.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dgwProductos.Name = "dgwProductos";
            this.dgwProductos.RowHeadersWidth = 51;
            this.dgwProductos.Size = new System.Drawing.Size(544, 335);
            this.dgwProductos.TabIndex = 0;
            this.dgwProductos.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgwProductos_CellContentClick);
            // 
            // lblProductos
            // 
            this.lblProductos.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProductos.ForeColor = System.Drawing.Color.White;
            this.lblProductos.Location = new System.Drawing.Point(128, 43);
            this.lblProductos.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblProductos.Name = "lblProductos";
            this.lblProductos.Size = new System.Drawing.Size(400, 44);
            this.lblProductos.TabIndex = 10;
            this.lblProductos.Text = "PRODUCTOS";
            this.lblProductos.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // FRMProducto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(643, 492);
            this.Controls.Add(this.lblProductos);
            this.Controls.Add(this.dgwProductos);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "FRMProducto";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FRMProducto";
            this.Load += new System.EventHandler(this.FRMProducto_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgwProductos)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgwProductos;
        private System.Windows.Forms.Label lblProductos;
    }
}