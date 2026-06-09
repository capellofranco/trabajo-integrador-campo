namespace trabajo_integrador
{
    partial class FRMUsuariosBloqueados
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
            this.dtwUsuarioBloqueado = new System.Windows.Forms.DataGridView();
            this.btnDesbloquearUsuarioBloqueado = new System.Windows.Forms.Button();
            this.lblUsuarioBloqueado = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dtwUsuarioBloqueado)).BeginInit();
            this.SuspendLayout();
            // 
            // dtwUsuarioBloqueado
            // 
            this.dtwUsuarioBloqueado.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtwUsuarioBloqueado.Location = new System.Drawing.Point(27, 84);
            this.dtwUsuarioBloqueado.Margin = new System.Windows.Forms.Padding(2);
            this.dtwUsuarioBloqueado.Name = "dtwUsuarioBloqueado";
            this.dtwUsuarioBloqueado.RowHeadersWidth = 51;
            this.dtwUsuarioBloqueado.RowTemplate.Height = 24;
            this.dtwUsuarioBloqueado.Size = new System.Drawing.Size(514, 244);
            this.dtwUsuarioBloqueado.TabIndex = 0;
            // 
            // btnDesbloquearUsuarioBloqueado
            // 
            this.btnDesbloquearUsuarioBloqueado.BackColor = System.Drawing.Color.White;
            this.btnDesbloquearUsuarioBloqueado.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDesbloquearUsuarioBloqueado.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDesbloquearUsuarioBloqueado.ForeColor = System.Drawing.Color.Navy;
            this.btnDesbloquearUsuarioBloqueado.Location = new System.Drawing.Point(177, 341);
            this.btnDesbloquearUsuarioBloqueado.Margin = new System.Windows.Forms.Padding(2);
            this.btnDesbloquearUsuarioBloqueado.Name = "btnDesbloquearUsuarioBloqueado";
            this.btnDesbloquearUsuarioBloqueado.Size = new System.Drawing.Size(190, 45);
            this.btnDesbloquearUsuarioBloqueado.TabIndex = 1;
            this.btnDesbloquearUsuarioBloqueado.Text = "DESBLOQUEAR";
            this.btnDesbloquearUsuarioBloqueado.UseVisualStyleBackColor = false;
            this.btnDesbloquearUsuarioBloqueado.Click += new System.EventHandler(this.button1_Click);
            this.btnDesbloquearUsuarioBloqueado.MouseEnter += new System.EventHandler(this.button1_MouseEnter);
            this.btnDesbloquearUsuarioBloqueado.MouseLeave += new System.EventHandler(this.button1_MouseLeave);
            // 
            // lblUsuarioBloqueado
            // 
            this.lblUsuarioBloqueado.BackColor = System.Drawing.Color.Transparent;
            this.lblUsuarioBloqueado.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUsuarioBloqueado.ForeColor = System.Drawing.Color.White;
            this.lblUsuarioBloqueado.Location = new System.Drawing.Point(83, 28);
            this.lblUsuarioBloqueado.Name = "lblUsuarioBloqueado";
            this.lblUsuarioBloqueado.Size = new System.Drawing.Size(403, 36);
            this.lblUsuarioBloqueado.TabIndex = 10;
            this.lblUsuarioBloqueado.Text = "USUARIO BLOQUEADO";
            this.lblUsuarioBloqueado.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // FRMUsuariosBloqueados
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(569, 415);
            this.Controls.Add(this.lblUsuarioBloqueado);
            this.Controls.Add(this.btnDesbloquearUsuarioBloqueado);
            this.Controls.Add(this.dtwUsuarioBloqueado);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "FRMUsuariosBloqueados";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FRMUsuariosBloqueados";
            this.Load += new System.EventHandler(this.FRMUsuariosBloqueados_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtwUsuarioBloqueado)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dtwUsuarioBloqueado;
        private System.Windows.Forms.Button btnDesbloquearUsuarioBloqueado;
        private System.Windows.Forms.Label lblUsuarioBloqueado;
    }
}