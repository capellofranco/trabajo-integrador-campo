namespace trabajo_integrador
{
    partial class FRMGestionRoles
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
            this.txtNombreRol = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtDescRol = new System.Windows.Forms.TextBox();
            this.btnCrearRol = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnQuitarPermiso = new System.Windows.Forms.Button();
            this.btnAgregarPermiso = new System.Windows.Forms.Button();
            this.cmbPermiso = new System.Windows.Forms.ComboBox();
            this.cmbRolParaPermiso = new System.Windows.Forms.ComboBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnQuitarSubRol = new System.Windows.Forms.Button();
            this.btnAgregarSubRol = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.cmbRolHijo = new System.Windows.Forms.ComboBox();
            this.cmbRolPadre = new System.Windows.Forms.ComboBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.btnQuitarRol = new System.Windows.Forms.Button();
            this.btnAsignarRol = new System.Windows.Forms.Button();
            this.cmbRolUsuario = new System.Windows.Forms.ComboBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.label8 = new System.Windows.Forms.Label();
            this.btnQuitarPermisoDirecto = new System.Windows.Forms.Button();
            this.btnAgregarPermisoDirecto = new System.Windows.Forms.Button();
            this.cmbPermisoDirecto = new System.Windows.Forms.ComboBox();
            this.lstPermisosDirectos = new System.Windows.Forms.ListBox();
            this.treeViewRoles = new System.Windows.Forms.TreeView();
            this.cmbUsuario = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtNombreRol
            // 
            this.txtNombreRol.Location = new System.Drawing.Point(85, 30);
            this.txtNombreRol.Name = "txtNombreRol";
            this.txtNombreRol.Size = new System.Drawing.Size(215, 22);
            this.txtNombreRol.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 84);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "Permiso";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(0, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "Nombre";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(0, 70);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 16);
            this.label3.TabIndex = 4;
            this.label3.Text = "Descripción";
            // 
            // txtDescRol
            // 
            this.txtDescRol.Location = new System.Drawing.Point(85, 67);
            this.txtDescRol.Name = "txtDescRol";
            this.txtDescRol.Size = new System.Drawing.Size(304, 22);
            this.txtDescRol.TabIndex = 3;
            // 
            // btnCrearRol
            // 
            this.btnCrearRol.Location = new System.Drawing.Point(3, 112);
            this.btnCrearRol.Name = "btnCrearRol";
            this.btnCrearRol.Size = new System.Drawing.Size(154, 31);
            this.btnCrearRol.TabIndex = 5;
            this.btnCrearRol.Text = "Cargar";
            this.btnCrearRol.UseVisualStyleBackColor = true;
            this.btnCrearRol.Click += new System.EventHandler(this.btnCrearRol_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtNombreRol);
            this.groupBox1.Controls.Add(this.btnCrearRol);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtDescRol);
            this.groupBox1.Location = new System.Drawing.Point(15, 205);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(407, 174);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Crear Roles";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.btnQuitarPermiso);
            this.groupBox2.Controls.Add(this.btnAgregarPermiso);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.cmbPermiso);
            this.groupBox2.Controls.Add(this.cmbRolParaPermiso);
            this.groupBox2.Location = new System.Drawing.Point(470, 205);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(404, 174);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Permisos para roles";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 42);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(111, 16);
            this.label4.TabIndex = 4;
            this.label4.Text = "Rol para permiso";
            // 
            // btnQuitarPermiso
            // 
            this.btnQuitarPermiso.Location = new System.Drawing.Point(228, 129);
            this.btnQuitarPermiso.Name = "btnQuitarPermiso";
            this.btnQuitarPermiso.Size = new System.Drawing.Size(145, 23);
            this.btnQuitarPermiso.TabIndex = 3;
            this.btnQuitarPermiso.Text = "Quitar permiso";
            this.btnQuitarPermiso.UseVisualStyleBackColor = true;
            this.btnQuitarPermiso.Click += new System.EventHandler(this.btnQuitarPermiso_Click);
            // 
            // btnAgregarPermiso
            // 
            this.btnAgregarPermiso.Location = new System.Drawing.Point(9, 129);
            this.btnAgregarPermiso.Name = "btnAgregarPermiso";
            this.btnAgregarPermiso.Size = new System.Drawing.Size(145, 23);
            this.btnAgregarPermiso.TabIndex = 2;
            this.btnAgregarPermiso.Text = "Agregar permiso";
            this.btnAgregarPermiso.UseVisualStyleBackColor = true;
            this.btnAgregarPermiso.Click += new System.EventHandler(this.btnAgregarPermiso_Click);
            // 
            // cmbPermiso
            // 
            this.cmbPermiso.FormattingEnabled = true;
            this.cmbPermiso.Location = new System.Drawing.Point(123, 76);
            this.cmbPermiso.Name = "cmbPermiso";
            this.cmbPermiso.Size = new System.Drawing.Size(250, 24);
            this.cmbPermiso.TabIndex = 1;
            // 
            // cmbRolParaPermiso
            // 
            this.cmbRolParaPermiso.FormattingEnabled = true;
            this.cmbRolParaPermiso.Location = new System.Drawing.Point(123, 34);
            this.cmbRolParaPermiso.Name = "cmbRolParaPermiso";
            this.cmbRolParaPermiso.Size = new System.Drawing.Size(250, 24);
            this.cmbRolParaPermiso.TabIndex = 0;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.btnQuitarSubRol);
            this.groupBox3.Controls.Add(this.btnAgregarSubRol);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.cmbRolHijo);
            this.groupBox3.Controls.Add(this.cmbRolPadre);
            this.groupBox3.Location = new System.Drawing.Point(18, 402);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(404, 174);
            this.groupBox3.TabIndex = 8;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Sub-rol (composite)";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 42);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(67, 16);
            this.label5.TabIndex = 4;
            this.label5.Text = "Rol padre";
            // 
            // btnQuitarSubRol
            // 
            this.btnQuitarSubRol.Location = new System.Drawing.Point(228, 129);
            this.btnQuitarSubRol.Name = "btnQuitarSubRol";
            this.btnQuitarSubRol.Size = new System.Drawing.Size(145, 23);
            this.btnQuitarSubRol.TabIndex = 3;
            this.btnQuitarSubRol.Text = "Quitar subrol";
            this.btnQuitarSubRol.UseVisualStyleBackColor = true;
            this.btnQuitarSubRol.Click += new System.EventHandler(this.btnQuitarSubRol_Click_1);
            // 
            // btnAgregarSubRol
            // 
            this.btnAgregarSubRol.Location = new System.Drawing.Point(9, 129);
            this.btnAgregarSubRol.Name = "btnAgregarSubRol";
            this.btnAgregarSubRol.Size = new System.Drawing.Size(145, 23);
            this.btnAgregarSubRol.TabIndex = 2;
            this.btnAgregarSubRol.Text = "Agregar subrol";
            this.btnAgregarSubRol.UseVisualStyleBackColor = true;
            this.btnAgregarSubRol.Click += new System.EventHandler(this.btnAgregarSubRol_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 84);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(52, 16);
            this.label6.TabIndex = 1;
            this.label6.Text = "Rol hijo";
            // 
            // cmbRolHijo
            // 
            this.cmbRolHijo.FormattingEnabled = true;
            this.cmbRolHijo.Location = new System.Drawing.Point(123, 76);
            this.cmbRolHijo.Name = "cmbRolHijo";
            this.cmbRolHijo.Size = new System.Drawing.Size(250, 24);
            this.cmbRolHijo.TabIndex = 1;
            // 
            // cmbRolPadre
            // 
            this.cmbRolPadre.FormattingEnabled = true;
            this.cmbRolPadre.Location = new System.Drawing.Point(123, 34);
            this.cmbRolPadre.Name = "cmbRolPadre";
            this.cmbRolPadre.Size = new System.Drawing.Size(250, 24);
            this.cmbRolPadre.TabIndex = 0;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.label7);
            this.groupBox4.Controls.Add(this.btnQuitarRol);
            this.groupBox4.Controls.Add(this.btnAsignarRol);
            this.groupBox4.Controls.Add(this.cmbRolUsuario);
            this.groupBox4.Location = new System.Drawing.Point(470, 402);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(404, 116);
            this.groupBox4.TabIndex = 9;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Asignar rol a usuario";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(51, 37);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(28, 16);
            this.label7.TabIndex = 4;
            this.label7.Text = "Rol";
            // 
            // btnQuitarRol
            // 
            this.btnQuitarRol.Location = new System.Drawing.Point(228, 76);
            this.btnQuitarRol.Name = "btnQuitarRol";
            this.btnQuitarRol.Size = new System.Drawing.Size(145, 23);
            this.btnQuitarRol.TabIndex = 3;
            this.btnQuitarRol.Text = "Quitar rol";
            this.btnQuitarRol.UseVisualStyleBackColor = true;
            this.btnQuitarRol.Click += new System.EventHandler(this.btnQuitarRol_Click);
            // 
            // btnAsignarRol
            // 
            this.btnAsignarRol.Location = new System.Drawing.Point(9, 76);
            this.btnAsignarRol.Name = "btnAsignarRol";
            this.btnAsignarRol.Size = new System.Drawing.Size(145, 23);
            this.btnAsignarRol.TabIndex = 2;
            this.btnAsignarRol.Text = "Agregar rol";
            this.btnAsignarRol.UseVisualStyleBackColor = true;
            this.btnAsignarRol.Click += new System.EventHandler(this.btnAsignarRol_Click);
            // 
            // cmbRolUsuario
            // 
            this.cmbRolUsuario.FormattingEnabled = true;
            this.cmbRolUsuario.Location = new System.Drawing.Point(123, 34);
            this.cmbRolUsuario.Name = "cmbRolUsuario";
            this.cmbRolUsuario.Size = new System.Drawing.Size(250, 24);
            this.cmbRolUsuario.TabIndex = 0;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.label8);
            this.groupBox5.Controls.Add(this.btnQuitarPermisoDirecto);
            this.groupBox5.Controls.Add(this.btnAgregarPermisoDirecto);
            this.groupBox5.Controls.Add(this.cmbPermisoDirecto);
            this.groupBox5.Location = new System.Drawing.Point(470, 531);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(404, 116);
            this.groupBox5.TabIndex = 10;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Asignar permiso a usuario";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(51, 37);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(57, 16);
            this.label8.TabIndex = 4;
            this.label8.Text = "Permiso";
            // 
            // btnQuitarPermisoDirecto
            // 
            this.btnQuitarPermisoDirecto.Location = new System.Drawing.Point(228, 76);
            this.btnQuitarPermisoDirecto.Name = "btnQuitarPermisoDirecto";
            this.btnQuitarPermisoDirecto.Size = new System.Drawing.Size(145, 23);
            this.btnQuitarPermisoDirecto.TabIndex = 3;
            this.btnQuitarPermisoDirecto.Text = "Quitar permiso";
            this.btnQuitarPermisoDirecto.UseVisualStyleBackColor = true;
            this.btnQuitarPermisoDirecto.Click += new System.EventHandler(this.btnQuitarPermisoDirecto_Click);
            // 
            // btnAgregarPermisoDirecto
            // 
            this.btnAgregarPermisoDirecto.Location = new System.Drawing.Point(9, 76);
            this.btnAgregarPermisoDirecto.Name = "btnAgregarPermisoDirecto";
            this.btnAgregarPermisoDirecto.Size = new System.Drawing.Size(145, 23);
            this.btnAgregarPermisoDirecto.TabIndex = 2;
            this.btnAgregarPermisoDirecto.Text = "Agregar permiso";
            this.btnAgregarPermisoDirecto.UseVisualStyleBackColor = true;
            this.btnAgregarPermisoDirecto.Click += new System.EventHandler(this.btnAgregarPermisoDirecto_Click);
            // 
            // cmbPermisoDirecto
            // 
            this.cmbPermisoDirecto.FormattingEnabled = true;
            this.cmbPermisoDirecto.Location = new System.Drawing.Point(123, 34);
            this.cmbPermisoDirecto.Name = "cmbPermisoDirecto";
            this.cmbPermisoDirecto.Size = new System.Drawing.Size(250, 24);
            this.cmbPermisoDirecto.TabIndex = 0;
            // 
            // lstPermisosDirectos
            // 
            this.lstPermisosDirectos.FormattingEnabled = true;
            this.lstPermisosDirectos.ItemHeight = 16;
            this.lstPermisosDirectos.Location = new System.Drawing.Point(903, 546);
            this.lstPermisosDirectos.Name = "lstPermisosDirectos";
            this.lstPermisosDirectos.Size = new System.Drawing.Size(383, 100);
            this.lstPermisosDirectos.TabIndex = 11;
            // 
            // treeViewRoles
            // 
            this.treeViewRoles.Location = new System.Drawing.Point(18, 60);
            this.treeViewRoles.Name = "treeViewRoles";
            this.treeViewRoles.Size = new System.Drawing.Size(639, 139);
            this.treeViewRoles.TabIndex = 12;
            // 
            // cmbUsuario
            // 
            this.cmbUsuario.FormattingEnabled = true;
            this.cmbUsuario.Location = new System.Drawing.Point(75, 22);
            this.cmbUsuario.Name = "cmbUsuario";
            this.cmbUsuario.Size = new System.Drawing.Size(221, 24);
            this.cmbUsuario.TabIndex = 13;
            this.cmbUsuario.SelectedIndexChanged += new System.EventHandler(this.cmbUsuario_SelectedIndexChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(15, 22);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(54, 16);
            this.label9.TabIndex = 14;
            this.label9.Text = "Usuario";
            // 
            // FRMGestionRoles
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1311, 675);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.cmbUsuario);
            this.Controls.Add(this.treeViewRoles);
            this.Controls.Add(this.lstPermisosDirectos);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "FRMGestionRoles";
            this.Text = "FRMGestionRoles";
            this.Load += new System.EventHandler(this.FRMGestionRoles_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtNombreRol;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtDescRol;
        private System.Windows.Forms.Button btnCrearRol;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox cmbPermiso;
        private System.Windows.Forms.ComboBox cmbRolParaPermiso;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnQuitarPermiso;
        private System.Windows.Forms.Button btnAgregarPermiso;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnQuitarSubRol;
        private System.Windows.Forms.Button btnAgregarSubRol;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cmbRolHijo;
        private System.Windows.Forms.ComboBox cmbRolPadre;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnQuitarRol;
        private System.Windows.Forms.Button btnAsignarRol;
        private System.Windows.Forms.ComboBox cmbRolUsuario;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnQuitarPermisoDirecto;
        private System.Windows.Forms.Button btnAgregarPermisoDirecto;
        private System.Windows.Forms.ComboBox cmbPermisoDirecto;
        private System.Windows.Forms.ListBox lstPermisosDirectos;
        private System.Windows.Forms.TreeView treeViewRoles;
        private System.Windows.Forms.ComboBox cmbUsuario;
        private System.Windows.Forms.Label label9;
    }
}