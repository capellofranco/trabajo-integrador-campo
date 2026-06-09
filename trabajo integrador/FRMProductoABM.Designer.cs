namespace trabajo_integrador
{
    partial class FRMProductoABM
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
            this.dgwProductoABM = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtPrecio = new System.Windows.Forms.TextBox();
            this.btnEliminarProducto = new System.Windows.Forms.Button();
            this.btnModificarProducto = new System.Windows.Forms.Button();
            this.lblProducto = new System.Windows.Forms.Label();
            this.btnAgregarProducto = new System.Windows.Forms.Button();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.lblNombrePreducto = new System.Windows.Forms.Label();
            this.lblPrecioProducto = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgwProductoABM)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgwProductoABM
            // 
            this.dgwProductoABM.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgwProductoABM.Location = new System.Drawing.Point(407, 12);
            this.dgwProductoABM.Name = "dgwProductoABM";
            this.dgwProductoABM.Size = new System.Drawing.Size(444, 359);
            this.dgwProductoABM.TabIndex = 10;
            this.dgwProductoABM.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // panel1
            // 
            this.panel1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.txtPrecio);
            this.panel1.Controls.Add(this.btnEliminarProducto);
            this.panel1.Controls.Add(this.btnModificarProducto);
            this.panel1.Controls.Add(this.lblProducto);
            this.panel1.Controls.Add(this.btnAgregarProducto);
            this.panel1.Controls.Add(this.txtNombre);
            this.panel1.Controls.Add(this.lblNombrePreducto);
            this.panel1.Controls.Add(this.lblPrecioProducto);
            this.panel1.Location = new System.Drawing.Point(35, 65);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(353, 262);
            this.panel1.TabIndex = 14;
            // 
            // txtPrecio
            // 
            this.txtPrecio.Location = new System.Drawing.Point(86, 115);
            this.txtPrecio.Margin = new System.Windows.Forms.Padding(2);
            this.txtPrecio.Name = "txtPrecio";
            this.txtPrecio.Size = new System.Drawing.Size(228, 20);
            this.txtPrecio.TabIndex = 12;
            this.txtPrecio.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPrecio_KeyPress);
            // 
            // btnEliminarProducto
            // 
            this.btnEliminarProducto.BackColor = System.Drawing.Color.White;
            this.btnEliminarProducto.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEliminarProducto.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEliminarProducto.ForeColor = System.Drawing.Color.Navy;
            this.btnEliminarProducto.Location = new System.Drawing.Point(204, 202);
            this.btnEliminarProducto.Margin = new System.Windows.Forms.Padding(2);
            this.btnEliminarProducto.Name = "btnEliminarProducto";
            this.btnEliminarProducto.Size = new System.Drawing.Size(134, 33);
            this.btnEliminarProducto.TabIndex = 11;
            this.btnEliminarProducto.Text = "ELIMINAR";
            this.btnEliminarProducto.UseVisualStyleBackColor = false;
            this.btnEliminarProducto.Click += new System.EventHandler(this.button3_Click);
            this.btnEliminarProducto.MouseEnter += new System.EventHandler(this.button3_MouseEnter);
            this.btnEliminarProducto.MouseLeave += new System.EventHandler(this.button3_MouseLeave);
            // 
            // btnModificarProducto
            // 
            this.btnModificarProducto.BackColor = System.Drawing.Color.White;
            this.btnModificarProducto.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnModificarProducto.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnModificarProducto.ForeColor = System.Drawing.Color.Navy;
            this.btnModificarProducto.Location = new System.Drawing.Point(57, 202);
            this.btnModificarProducto.Margin = new System.Windows.Forms.Padding(2);
            this.btnModificarProducto.Name = "btnModificarProducto";
            this.btnModificarProducto.Size = new System.Drawing.Size(134, 33);
            this.btnModificarProducto.TabIndex = 10;
            this.btnModificarProducto.Text = "MODIFICAR";
            this.btnModificarProducto.UseVisualStyleBackColor = false;
            this.btnModificarProducto.Click += new System.EventHandler(this.button1_Click);
            this.btnModificarProducto.MouseEnter += new System.EventHandler(this.button1_MouseEnter);
            this.btnModificarProducto.MouseLeave += new System.EventHandler(this.button1_MouseLeave);
            // 
            // lblProducto
            // 
            this.lblProducto.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProducto.ForeColor = System.Drawing.Color.Navy;
            this.lblProducto.Location = new System.Drawing.Point(38, 24);
            this.lblProducto.Name = "lblProducto";
            this.lblProducto.Size = new System.Drawing.Size(300, 36);
            this.lblProducto.TabIndex = 9;
            this.lblProducto.Text = "PRODUCTOS";
            this.lblProducto.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnAgregarProducto
            // 
            this.btnAgregarProducto.BackColor = System.Drawing.Color.White;
            this.btnAgregarProducto.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAgregarProducto.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAgregarProducto.ForeColor = System.Drawing.Color.Navy;
            this.btnAgregarProducto.Location = new System.Drawing.Point(102, 154);
            this.btnAgregarProducto.Margin = new System.Windows.Forms.Padding(2);
            this.btnAgregarProducto.Name = "btnAgregarProducto";
            this.btnAgregarProducto.Size = new System.Drawing.Size(186, 33);
            this.btnAgregarProducto.TabIndex = 5;
            this.btnAgregarProducto.Text = "AGREGRA";
            this.btnAgregarProducto.UseVisualStyleBackColor = false;
            this.btnAgregarProducto.Click += new System.EventHandler(this.button2_Click);
            this.btnAgregarProducto.MouseEnter += new System.EventHandler(this.button2_MouseEnter);
            this.btnAgregarProducto.MouseLeave += new System.EventHandler(this.button2_MouseLeave);
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(86, 78);
            this.txtNombre.Margin = new System.Windows.Forms.Padding(2);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(228, 20);
            this.txtNombre.TabIndex = 3;
            // 
            // lblNombrePreducto
            // 
            this.lblNombrePreducto.AutoSize = true;
            this.lblNombrePreducto.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNombrePreducto.Location = new System.Drawing.Point(23, 78);
            this.lblNombrePreducto.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblNombrePreducto.Name = "lblNombrePreducto";
            this.lblNombrePreducto.Size = new System.Drawing.Size(59, 16);
            this.lblNombrePreducto.TabIndex = 7;
            this.lblNombrePreducto.Text = "Nombre:";
            // 
            // lblPrecioProducto
            // 
            this.lblPrecioProducto.AutoSize = true;
            this.lblPrecioProducto.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPrecioProducto.Location = new System.Drawing.Point(33, 115);
            this.lblPrecioProducto.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblPrecioProducto.Name = "lblPrecioProducto";
            this.lblPrecioProducto.Size = new System.Drawing.Size(49, 16);
            this.lblPrecioProducto.TabIndex = 8;
            this.lblPrecioProducto.Text = "Precio:";
            // 
            // FRMProductoABM
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(880, 386);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.dgwProductoABM);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Name = "FRMProductoABM";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FRMProductoABM";
            this.Load += new System.EventHandler(this.FRMProductoABM_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgwProductoABM)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.DataGridView dgwProductoABM;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblProducto;
        private System.Windows.Forms.Button btnAgregarProducto;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Label lblNombrePreducto;
        private System.Windows.Forms.Label lblPrecioProducto;
        private System.Windows.Forms.Button btnEliminarProducto;
        private System.Windows.Forms.Button btnModificarProducto;
        private System.Windows.Forms.TextBox txtPrecio;
    }
}