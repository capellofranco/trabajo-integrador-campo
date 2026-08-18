namespace trabajo_integrador
{
    partial class FRMRegistrar
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
            this.btnRegistrarRegistrar = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblRegistrar = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.lblUsuarioRegistrar = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.lblContraseñaRegistrar = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnRegistrarRegistrar
            // 
            this.btnRegistrarRegistrar.BackColor = System.Drawing.Color.White;
            this.btnRegistrarRegistrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRegistrarRegistrar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRegistrarRegistrar.ForeColor = System.Drawing.Color.Navy;
            this.btnRegistrarRegistrar.Location = new System.Drawing.Point(116, 146);
            this.btnRegistrarRegistrar.Margin = new System.Windows.Forms.Padding(2);
            this.btnRegistrarRegistrar.Name = "btnRegistrarRegistrar";
            this.btnRegistrarRegistrar.Size = new System.Drawing.Size(186, 33);
            this.btnRegistrarRegistrar.TabIndex = 11;
            this.btnRegistrarRegistrar.Text = "REGISTRAR";
            this.btnRegistrarRegistrar.UseVisualStyleBackColor = false;
            this.btnRegistrarRegistrar.Click += new System.EventHandler(this.button1_Click);
            this.btnRegistrarRegistrar.MouseEnter += new System.EventHandler(this.button1_MouseEnter);
            this.btnRegistrarRegistrar.MouseLeave += new System.EventHandler(this.button1_MouseLeave);
            // 
            // panel1
            // 
            this.panel1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.lblRegistrar);
            this.panel1.Controls.Add(this.textBox1);
            this.panel1.Controls.Add(this.btnRegistrarRegistrar);
            this.panel1.Controls.Add(this.lblUsuarioRegistrar);
            this.panel1.Controls.Add(this.textBox2);
            this.panel1.Controls.Add(this.lblContraseñaRegistrar);
            this.panel1.Location = new System.Drawing.Point(24, 27);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(383, 208);
            this.panel1.TabIndex = 14;
            // 
            // lblRegistrar
            // 
            this.lblRegistrar.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
            this.lblRegistrar.ForeColor = System.Drawing.Color.Navy;
            this.lblRegistrar.Location = new System.Drawing.Point(58, 26);
            this.lblRegistrar.Name = "lblRegistrar";
            this.lblRegistrar.Size = new System.Drawing.Size(300, 36);
            this.lblRegistrar.TabIndex = 9;
            this.lblRegistrar.Text = "REGISTRAR";
            this.lblRegistrar.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(97, 73);
            this.textBox1.Margin = new System.Windows.Forms.Padding(2);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(228, 20);
            this.textBox1.TabIndex = 3;
            // 
            // lblUsuarioRegistrar
            // 
            this.lblUsuarioRegistrar.AutoSize = true;
            this.lblUsuarioRegistrar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUsuarioRegistrar.Location = new System.Drawing.Point(28, 73);
            this.lblUsuarioRegistrar.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblUsuarioRegistrar.Name = "lblUsuarioRegistrar";
            this.lblUsuarioRegistrar.Size = new System.Drawing.Size(57, 16);
            this.lblUsuarioRegistrar.TabIndex = 7;
            this.lblUsuarioRegistrar.Text = "Usuario:";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(97, 109);
            this.textBox2.Margin = new System.Windows.Forms.Padding(2);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(228, 20);
            this.textBox2.TabIndex = 4;
            this.textBox2.UseSystemPasswordChar = true;
            // 
            // lblContraseñaRegistrar
            // 
            this.lblContraseñaRegistrar.AutoSize = true;
            this.lblContraseñaRegistrar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblContraseñaRegistrar.Location = new System.Drawing.Point(6, 110);
            this.lblContraseñaRegistrar.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblContraseñaRegistrar.Name = "lblContraseñaRegistrar";
            this.lblContraseñaRegistrar.Size = new System.Drawing.Size(79, 16);
            this.lblContraseñaRegistrar.TabIndex = 8;
            this.lblContraseñaRegistrar.Text = "Contraseña:";
            // 
            // FRMRegistrar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(430, 263);
            this.Controls.Add(this.panel1);
            this.Name = "FRMRegistrar";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FRMRegistrar";
            this.Load += new System.EventHandler(this.FRMRegistrar_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnRegistrarRegistrar;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblRegistrar;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label lblUsuarioRegistrar;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label lblContraseñaRegistrar;
    }
}