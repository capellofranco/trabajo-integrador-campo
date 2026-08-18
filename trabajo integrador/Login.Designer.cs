namespace trabajo_integrador
{
    partial class Login
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.btnIniciarSesion = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblCambiarIdiomaLogin = new System.Windows.Forms.Label();
            this.cmbIdiomas = new System.Windows.Forms.ComboBox();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.lbUsuarioLogin = new System.Windows.Forms.Label();
            this.lblContraseñaLogin = new System.Windows.Forms.Label();
            this.lblAviso = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(97, 73);
            this.textBox1.Margin = new System.Windows.Forms.Padding(2);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(228, 20);
            this.textBox1.TabIndex = 3;
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
            // btnIniciarSesion
            // 
            this.btnIniciarSesion.BackColor = System.Drawing.Color.White;
            this.btnIniciarSesion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnIniciarSesion.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnIniciarSesion.ForeColor = System.Drawing.Color.Navy;
            this.btnIniciarSesion.Location = new System.Drawing.Point(109, 150);
            this.btnIniciarSesion.Margin = new System.Windows.Forms.Padding(2);
            this.btnIniciarSesion.Name = "btnIniciarSesion";
            this.btnIniciarSesion.Size = new System.Drawing.Size(186, 33);
            this.btnIniciarSesion.TabIndex = 5;
            this.btnIniciarSesion.Text = "INICIAR SESION";
            this.btnIniciarSesion.UseVisualStyleBackColor = false;
            this.btnIniciarSesion.Click += new System.EventHandler(this.button1_Click);
            this.btnIniciarSesion.MouseEnter += new System.EventHandler(this.button1_MouseEnter);
            this.btnIniciarSesion.MouseLeave += new System.EventHandler(this.button1_MouseLeave);
            // 
            // panel1
            // 
            this.panel1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.lblCambiarIdiomaLogin);
            this.panel1.Controls.Add(this.cmbIdiomas);
            this.panel1.Controls.Add(this.lblTitulo);
            this.panel1.Controls.Add(this.btnIniciarSesion);
            this.panel1.Controls.Add(this.textBox1);
            this.panel1.Controls.Add(this.lbUsuarioLogin);
            this.panel1.Controls.Add(this.textBox2);
            this.panel1.Controls.Add(this.lblContraseñaLogin);
            this.panel1.Location = new System.Drawing.Point(26, 34);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(383, 249);
            this.panel1.TabIndex = 13;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // lblCambiarIdiomaLogin
            // 
            this.lblCambiarIdiomaLogin.AutoSize = true;
            this.lblCambiarIdiomaLogin.ForeColor = System.Drawing.Color.Navy;
            this.lblCambiarIdiomaLogin.Location = new System.Drawing.Point(264, 199);
            this.lblCambiarIdiomaLogin.Name = "lblCambiarIdiomaLogin";
            this.lblCambiarIdiomaLogin.Size = new System.Drawing.Size(94, 13);
            this.lblCambiarIdiomaLogin.TabIndex = 11;
            this.lblCambiarIdiomaLogin.Text = "Cambiar de Idioma";
            // 
            // cmbIdiomas
            // 
            this.cmbIdiomas.FormattingEnabled = true;
            this.cmbIdiomas.Location = new System.Drawing.Point(248, 215);
            this.cmbIdiomas.Name = "cmbIdiomas";
            this.cmbIdiomas.Size = new System.Drawing.Size(121, 21);
            this.cmbIdiomas.TabIndex = 10;
            this.cmbIdiomas.SelectedIndexChanged += new System.EventHandler(this.cmbIdiomas_SelectedIndexChanged);
            // 
            // lblTitulo
            // 
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.ForeColor = System.Drawing.Color.Navy;
            this.lblTitulo.Location = new System.Drawing.Point(58, 26);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(300, 36);
            this.lblTitulo.TabIndex = 9;
            this.lblTitulo.Text = "LOGIN";
            this.lblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbUsuarioLogin
            // 
            this.lbUsuarioLogin.AutoSize = true;
            this.lbUsuarioLogin.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbUsuarioLogin.Location = new System.Drawing.Point(28, 73);
            this.lbUsuarioLogin.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbUsuarioLogin.Name = "lbUsuarioLogin";
            this.lbUsuarioLogin.Size = new System.Drawing.Size(57, 16);
            this.lbUsuarioLogin.TabIndex = 7;
            this.lbUsuarioLogin.Text = "Usuario:";
            // 
            // lblContraseñaLogin
            // 
            this.lblContraseñaLogin.AutoSize = true;
            this.lblContraseñaLogin.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblContraseñaLogin.Location = new System.Drawing.Point(6, 110);
            this.lblContraseñaLogin.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblContraseñaLogin.Name = "lblContraseñaLogin";
            this.lblContraseñaLogin.Size = new System.Drawing.Size(79, 16);
            this.lblContraseñaLogin.TabIndex = 8;
            this.lblContraseñaLogin.Text = "Contraseña:";
            // 
            // lblAviso
            // 
            this.lblAviso.AutoSize = true;
            this.lblAviso.Location = new System.Drawing.Point(23, 306);
            this.lblAviso.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblAviso.Name = "lblAviso";
            this.lblAviso.Size = new System.Drawing.Size(35, 13);
            this.lblAviso.TabIndex = 14;
            this.lblAviso.Text = "label1";
            this.lblAviso.Visible = false;
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(434, 329);
            this.Controls.Add(this.lblAviso);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Login";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Login_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Button btnIniciarSesion;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lbUsuarioLogin;
        private System.Windows.Forms.Label lblContraseñaLogin;
        private System.Windows.Forms.Label lblAviso;
        private System.Windows.Forms.Label lblCambiarIdiomaLogin;
        private System.Windows.Forms.ComboBox cmbIdiomas;
    }
}

