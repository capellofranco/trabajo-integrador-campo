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
            this.lblPermiso = new System.Windows.Forms.Label();
            this.lblNombreGestionRoles = new System.Windows.Forms.Label();
            this.lblDescripcionGestionRoles = new System.Windows.Forms.Label();
            this.txtDescRol = new System.Windows.Forms.TextBox();
            this.btnCrearRol = new System.Windows.Forms.Button();
            this.gbCrearRolesGestionRoles = new System.Windows.Forms.GroupBox();
            this.gbPermisosParaRoles = new System.Windows.Forms.GroupBox();
            this.lblRolParaPermiso = new System.Windows.Forms.Label();
            this.btnQuitarPermiso = new System.Windows.Forms.Button();
            this.btnAgregarPermiso = new System.Windows.Forms.Button();
            this.cmbPermiso = new System.Windows.Forms.ComboBox();
            this.cmbRolParaPermiso = new System.Windows.Forms.ComboBox();
            this.gbSubRolGestionRoles = new System.Windows.Forms.GroupBox();
            this.lblRolPadreGestionRoles = new System.Windows.Forms.Label();
            this.btnQuitarSubRol = new System.Windows.Forms.Button();
            this.btnAgregarSubRol = new System.Windows.Forms.Button();
            this.cmbRolPadre = new System.Windows.Forms.ComboBox();
            this.cmbRolHijo = new System.Windows.Forms.ComboBox();
            this.lblRolHijo = new System.Windows.Forms.Label();
            this.gbAsignarRolAUsuario = new System.Windows.Forms.GroupBox();
            this.lblRol = new System.Windows.Forms.Label();
            this.btnQuitarRol = new System.Windows.Forms.Button();
            this.btnAsignarRol = new System.Windows.Forms.Button();
            this.cmbRolUsuario = new System.Windows.Forms.ComboBox();
            this.gbAsignarPermisoausuario = new System.Windows.Forms.GroupBox();
            this.lblPermisoAsignarPermisoaUsuario = new System.Windows.Forms.Label();
            this.btnQuitarPermisoDirecto = new System.Windows.Forms.Button();
            this.btnAgregarPermisoDirecto = new System.Windows.Forms.Button();
            this.cmbPermisoDirecto = new System.Windows.Forms.ComboBox();
            this.lstPermisosDirectos = new System.Windows.Forms.ListBox();
            this.tvrGestionRoles = new System.Windows.Forms.TreeView();
            this.cmbUsuario = new System.Windows.Forms.ComboBox();
            this.lblUsuarioGestionRoles = new System.Windows.Forms.Label();
            this.lblGestiondeRolesTitulo = new System.Windows.Forms.Label();
            this.gbCrearRolesGestionRoles.SuspendLayout();
            this.gbPermisosParaRoles.SuspendLayout();
            this.gbSubRolGestionRoles.SuspendLayout();
            this.gbAsignarRolAUsuario.SuspendLayout();
            this.gbAsignarPermisoausuario.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtNombreRol
            // 
            this.txtNombreRol.Location = new System.Drawing.Point(90, 28);
            this.txtNombreRol.Margin = new System.Windows.Forms.Padding(2);
            this.txtNombreRol.Name = "txtNombreRol";
            this.txtNombreRol.Size = new System.Drawing.Size(132, 22);
            this.txtNombreRol.TabIndex = 0;
            // 
            // lblPermiso
            // 
            this.lblPermiso.AutoSize = true;
            this.lblPermiso.ForeColor = System.Drawing.Color.Black;
            this.lblPermiso.Location = new System.Drawing.Point(60, 64);
            this.lblPermiso.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblPermiso.Name = "lblPermiso";
            this.lblPermiso.Size = new System.Drawing.Size(60, 16);
            this.lblPermiso.TabIndex = 1;
            this.lblPermiso.Text = "Permiso:";
            // 
            // lblNombreGestionRoles
            // 
            this.lblNombreGestionRoles.AutoSize = true;
            this.lblNombreGestionRoles.ForeColor = System.Drawing.Color.Black;
            this.lblNombreGestionRoles.Location = new System.Drawing.Point(27, 31);
            this.lblNombreGestionRoles.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblNombreGestionRoles.Name = "lblNombreGestionRoles";
            this.lblNombreGestionRoles.Size = new System.Drawing.Size(59, 16);
            this.lblNombreGestionRoles.TabIndex = 2;
            this.lblNombreGestionRoles.Text = "Nombre:";
            // 
            // lblDescripcionGestionRoles
            // 
            this.lblDescripcionGestionRoles.AutoSize = true;
            this.lblDescripcionGestionRoles.ForeColor = System.Drawing.Color.Black;
            this.lblDescripcionGestionRoles.Location = new System.Drawing.Point(4, 61);
            this.lblDescripcionGestionRoles.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblDescripcionGestionRoles.Name = "lblDescripcionGestionRoles";
            this.lblDescripcionGestionRoles.Size = new System.Drawing.Size(82, 16);
            this.lblDescripcionGestionRoles.TabIndex = 4;
            this.lblDescripcionGestionRoles.Text = "Descripción:";
            // 
            // txtDescRol
            // 
            this.txtDescRol.Location = new System.Drawing.Point(90, 58);
            this.txtDescRol.Margin = new System.Windows.Forms.Padding(2);
            this.txtDescRol.Name = "txtDescRol";
            this.txtDescRol.Size = new System.Drawing.Size(132, 22);
            this.txtDescRol.TabIndex = 3;
            // 
            // btnCrearRol
            // 
            this.btnCrearRol.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCrearRol.ForeColor = System.Drawing.Color.Navy;
            this.btnCrearRol.Location = new System.Drawing.Point(55, 90);
            this.btnCrearRol.Margin = new System.Windows.Forms.Padding(2);
            this.btnCrearRol.Name = "btnCrearRol";
            this.btnCrearRol.Size = new System.Drawing.Size(119, 33);
            this.btnCrearRol.TabIndex = 5;
            this.btnCrearRol.Text = "Cargar";
            this.btnCrearRol.UseVisualStyleBackColor = true;
            this.btnCrearRol.Click += new System.EventHandler(this.btnCrearRol_Click);
            this.btnCrearRol.MouseEnter += new System.EventHandler(this.btnCrearRol_MouseEnter);
            this.btnCrearRol.MouseLeave += new System.EventHandler(this.btnCrearRol_MouseLeave);
            // 
            // gbCrearRolesGestionRoles
            // 
            this.gbCrearRolesGestionRoles.BackColor = System.Drawing.Color.White;
            this.gbCrearRolesGestionRoles.Controls.Add(this.txtNombreRol);
            this.gbCrearRolesGestionRoles.Controls.Add(this.btnCrearRol);
            this.gbCrearRolesGestionRoles.Controls.Add(this.lblNombreGestionRoles);
            this.gbCrearRolesGestionRoles.Controls.Add(this.lblDescripcionGestionRoles);
            this.gbCrearRolesGestionRoles.Controls.Add(this.txtDescRol);
            this.gbCrearRolesGestionRoles.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbCrearRolesGestionRoles.Location = new System.Drawing.Point(82, 426);
            this.gbCrearRolesGestionRoles.Margin = new System.Windows.Forms.Padding(2);
            this.gbCrearRolesGestionRoles.Name = "gbCrearRolesGestionRoles";
            this.gbCrearRolesGestionRoles.Padding = new System.Windows.Forms.Padding(2);
            this.gbCrearRolesGestionRoles.Size = new System.Drawing.Size(237, 141);
            this.gbCrearRolesGestionRoles.TabIndex = 6;
            this.gbCrearRolesGestionRoles.TabStop = false;
            this.gbCrearRolesGestionRoles.Text = "Crear Roles";
            // 
            // gbPermisosParaRoles
            // 
            this.gbPermisosParaRoles.BackColor = System.Drawing.Color.White;
            this.gbPermisosParaRoles.Controls.Add(this.lblRolParaPermiso);
            this.gbPermisosParaRoles.Controls.Add(this.btnQuitarPermiso);
            this.gbPermisosParaRoles.Controls.Add(this.btnAgregarPermiso);
            this.gbPermisosParaRoles.Controls.Add(this.lblPermiso);
            this.gbPermisosParaRoles.Controls.Add(this.cmbPermiso);
            this.gbPermisosParaRoles.Controls.Add(this.cmbRolParaPermiso);
            this.gbPermisosParaRoles.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbPermisosParaRoles.Location = new System.Drawing.Point(613, 426);
            this.gbPermisosParaRoles.Margin = new System.Windows.Forms.Padding(2);
            this.gbPermisosParaRoles.Name = "gbPermisosParaRoles";
            this.gbPermisosParaRoles.Padding = new System.Windows.Forms.Padding(2);
            this.gbPermisosParaRoles.Size = new System.Drawing.Size(303, 141);
            this.gbPermisosParaRoles.TabIndex = 7;
            this.gbPermisosParaRoles.TabStop = false;
            this.gbPermisosParaRoles.Text = "Permisos para roles";
            // 
            // lblRolParaPermiso
            // 
            this.lblRolParaPermiso.AutoSize = true;
            this.lblRolParaPermiso.ForeColor = System.Drawing.Color.Black;
            this.lblRolParaPermiso.Location = new System.Drawing.Point(4, 30);
            this.lblRolParaPermiso.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblRolParaPermiso.Name = "lblRolParaPermiso";
            this.lblRolParaPermiso.Size = new System.Drawing.Size(116, 16);
            this.lblRolParaPermiso.TabIndex = 4;
            this.lblRolParaPermiso.Text = "Rol Para Permiso:";
            // 
            // btnQuitarPermiso
            // 
            this.btnQuitarPermiso.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnQuitarPermiso.ForeColor = System.Drawing.Color.Navy;
            this.btnQuitarPermiso.Location = new System.Drawing.Point(157, 91);
            this.btnQuitarPermiso.Margin = new System.Windows.Forms.Padding(2);
            this.btnQuitarPermiso.Name = "btnQuitarPermiso";
            this.btnQuitarPermiso.Size = new System.Drawing.Size(109, 33);
            this.btnQuitarPermiso.TabIndex = 3;
            this.btnQuitarPermiso.Text = "Quitar permiso";
            this.btnQuitarPermiso.UseVisualStyleBackColor = true;
            this.btnQuitarPermiso.Click += new System.EventHandler(this.btnQuitarPermiso_Click);
            this.btnQuitarPermiso.MouseEnter += new System.EventHandler(this.btnQuitarPermiso_MouseEnter);
            this.btnQuitarPermiso.MouseLeave += new System.EventHandler(this.btnQuitarPermiso_MouseLeave);
            // 
            // btnAgregarPermiso
            // 
            this.btnAgregarPermiso.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAgregarPermiso.ForeColor = System.Drawing.Color.Navy;
            this.btnAgregarPermiso.Location = new System.Drawing.Point(27, 91);
            this.btnAgregarPermiso.Margin = new System.Windows.Forms.Padding(2);
            this.btnAgregarPermiso.Name = "btnAgregarPermiso";
            this.btnAgregarPermiso.Size = new System.Drawing.Size(112, 33);
            this.btnAgregarPermiso.TabIndex = 2;
            this.btnAgregarPermiso.Text = "Agregar permiso";
            this.btnAgregarPermiso.UseVisualStyleBackColor = true;
            this.btnAgregarPermiso.Click += new System.EventHandler(this.btnAgregarPermiso_Click);
            this.btnAgregarPermiso.MouseEnter += new System.EventHandler(this.btnAgregarPermiso_MouseEnter);
            this.btnAgregarPermiso.MouseLeave += new System.EventHandler(this.btnAgregarPermiso_MouseLeave);
            // 
            // cmbPermiso
            // 
            this.cmbPermiso.FormattingEnabled = true;
            this.cmbPermiso.Location = new System.Drawing.Point(124, 61);
            this.cmbPermiso.Margin = new System.Windows.Forms.Padding(2);
            this.cmbPermiso.Name = "cmbPermiso";
            this.cmbPermiso.Size = new System.Drawing.Size(132, 24);
            this.cmbPermiso.TabIndex = 1;
            // 
            // cmbRolParaPermiso
            // 
            this.cmbRolParaPermiso.FormattingEnabled = true;
            this.cmbRolParaPermiso.Location = new System.Drawing.Point(124, 26);
            this.cmbRolParaPermiso.Margin = new System.Windows.Forms.Padding(2);
            this.cmbRolParaPermiso.Name = "cmbRolParaPermiso";
            this.cmbRolParaPermiso.Size = new System.Drawing.Size(132, 24);
            this.cmbRolParaPermiso.TabIndex = 0;
            // 
            // gbSubRolGestionRoles
            // 
            this.gbSubRolGestionRoles.BackColor = System.Drawing.Color.White;
            this.gbSubRolGestionRoles.Controls.Add(this.lblRolPadreGestionRoles);
            this.gbSubRolGestionRoles.Controls.Add(this.btnQuitarSubRol);
            this.gbSubRolGestionRoles.Controls.Add(this.btnAgregarSubRol);
            this.gbSubRolGestionRoles.Controls.Add(this.cmbRolPadre);
            this.gbSubRolGestionRoles.Controls.Add(this.cmbRolHijo);
            this.gbSubRolGestionRoles.Controls.Add(this.lblRolHijo);
            this.gbSubRolGestionRoles.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbSubRolGestionRoles.Location = new System.Drawing.Point(336, 426);
            this.gbSubRolGestionRoles.Margin = new System.Windows.Forms.Padding(2);
            this.gbSubRolGestionRoles.Name = "gbSubRolGestionRoles";
            this.gbSubRolGestionRoles.Padding = new System.Windows.Forms.Padding(2);
            this.gbSubRolGestionRoles.Size = new System.Drawing.Size(262, 141);
            this.gbSubRolGestionRoles.TabIndex = 8;
            this.gbSubRolGestionRoles.TabStop = false;
            this.gbSubRolGestionRoles.Text = "Sub-rol (composite)";
            // 
            // lblRolPadreGestionRoles
            // 
            this.lblRolPadreGestionRoles.AutoSize = true;
            this.lblRolPadreGestionRoles.BackColor = System.Drawing.Color.White;
            this.lblRolPadreGestionRoles.ForeColor = System.Drawing.Color.Black;
            this.lblRolPadreGestionRoles.Location = new System.Drawing.Point(21, 30);
            this.lblRolPadreGestionRoles.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblRolPadreGestionRoles.Name = "lblRolPadreGestionRoles";
            this.lblRolPadreGestionRoles.Size = new System.Drawing.Size(71, 16);
            this.lblRolPadreGestionRoles.TabIndex = 4;
            this.lblRolPadreGestionRoles.Text = "Rol Padre:";
            // 
            // btnQuitarSubRol
            // 
            this.btnQuitarSubRol.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnQuitarSubRol.ForeColor = System.Drawing.Color.Navy;
            this.btnQuitarSubRol.Location = new System.Drawing.Point(134, 92);
            this.btnQuitarSubRol.Margin = new System.Windows.Forms.Padding(2);
            this.btnQuitarSubRol.Name = "btnQuitarSubRol";
            this.btnQuitarSubRol.Size = new System.Drawing.Size(113, 34);
            this.btnQuitarSubRol.TabIndex = 3;
            this.btnQuitarSubRol.Text = "Quitar subrol";
            this.btnQuitarSubRol.UseVisualStyleBackColor = true;
            this.btnQuitarSubRol.Click += new System.EventHandler(this.btnQuitarSubRol_Click_1);
            this.btnQuitarSubRol.MouseEnter += new System.EventHandler(this.btnQuitarSubRol_MouseEnter);
            this.btnQuitarSubRol.MouseLeave += new System.EventHandler(this.btnQuitarSubRol_MouseLeave);
            // 
            // btnAgregarSubRol
            // 
            this.btnAgregarSubRol.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAgregarSubRol.ForeColor = System.Drawing.Color.Navy;
            this.btnAgregarSubRol.Location = new System.Drawing.Point(7, 92);
            this.btnAgregarSubRol.Margin = new System.Windows.Forms.Padding(2);
            this.btnAgregarSubRol.Name = "btnAgregarSubRol";
            this.btnAgregarSubRol.Size = new System.Drawing.Size(112, 34);
            this.btnAgregarSubRol.TabIndex = 2;
            this.btnAgregarSubRol.Text = "Agregar subrol";
            this.btnAgregarSubRol.UseVisualStyleBackColor = true;
            this.btnAgregarSubRol.Click += new System.EventHandler(this.btnAgregarSubRol_Click);
            this.btnAgregarSubRol.MouseEnter += new System.EventHandler(this.btnAgregarSubRol_MouseEnter);
            this.btnAgregarSubRol.MouseLeave += new System.EventHandler(this.btnAgregarSubRol_MouseLeave);
            // 
            // cmbRolPadre
            // 
            this.cmbRolPadre.FormattingEnabled = true;
            this.cmbRolPadre.Location = new System.Drawing.Point(96, 26);
            this.cmbRolPadre.Margin = new System.Windows.Forms.Padding(2);
            this.cmbRolPadre.Name = "cmbRolPadre";
            this.cmbRolPadre.Size = new System.Drawing.Size(132, 24);
            this.cmbRolPadre.TabIndex = 0;
            // 
            // cmbRolHijo
            // 
            this.cmbRolHijo.FormattingEnabled = true;
            this.cmbRolHijo.Location = new System.Drawing.Point(96, 61);
            this.cmbRolHijo.Margin = new System.Windows.Forms.Padding(2);
            this.cmbRolHijo.Name = "cmbRolHijo";
            this.cmbRolHijo.Size = new System.Drawing.Size(132, 24);
            this.cmbRolHijo.TabIndex = 1;
            // 
            // lblRolHijo
            // 
            this.lblRolHijo.AutoSize = true;
            this.lblRolHijo.ForeColor = System.Drawing.Color.Black;
            this.lblRolHijo.Location = new System.Drawing.Point(34, 64);
            this.lblRolHijo.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblRolHijo.Name = "lblRolHijo";
            this.lblRolHijo.Size = new System.Drawing.Size(58, 16);
            this.lblRolHijo.TabIndex = 1;
            this.lblRolHijo.Text = "Rol Hijo:";
            // 
            // gbAsignarRolAUsuario
            // 
            this.gbAsignarRolAUsuario.BackColor = System.Drawing.Color.White;
            this.gbAsignarRolAUsuario.Controls.Add(this.lblRol);
            this.gbAsignarRolAUsuario.Controls.Add(this.btnQuitarRol);
            this.gbAsignarRolAUsuario.Controls.Add(this.btnAsignarRol);
            this.gbAsignarRolAUsuario.Controls.Add(this.cmbRolUsuario);
            this.gbAsignarRolAUsuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbAsignarRolAUsuario.Location = new System.Drawing.Point(934, 426);
            this.gbAsignarRolAUsuario.Margin = new System.Windows.Forms.Padding(2);
            this.gbAsignarRolAUsuario.Name = "gbAsignarRolAUsuario";
            this.gbAsignarRolAUsuario.Padding = new System.Windows.Forms.Padding(2);
            this.gbAsignarRolAUsuario.Size = new System.Drawing.Size(252, 141);
            this.gbAsignarRolAUsuario.TabIndex = 9;
            this.gbAsignarRolAUsuario.TabStop = false;
            this.gbAsignarRolAUsuario.Text = "Asignar rol a usuario";
            // 
            // lblRol
            // 
            this.lblRol.AutoSize = true;
            this.lblRol.BackColor = System.Drawing.Color.White;
            this.lblRol.ForeColor = System.Drawing.Color.Black;
            this.lblRol.Location = new System.Drawing.Point(35, 50);
            this.lblRol.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblRol.Name = "lblRol";
            this.lblRol.Size = new System.Drawing.Size(31, 16);
            this.lblRol.TabIndex = 4;
            this.lblRol.Text = "Rol:";
            // 
            // btnQuitarRol
            // 
            this.btnQuitarRol.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnQuitarRol.ForeColor = System.Drawing.Color.Navy;
            this.btnQuitarRol.Location = new System.Drawing.Point(128, 89);
            this.btnQuitarRol.Margin = new System.Windows.Forms.Padding(2);
            this.btnQuitarRol.Name = "btnQuitarRol";
            this.btnQuitarRol.Size = new System.Drawing.Size(109, 34);
            this.btnQuitarRol.TabIndex = 3;
            this.btnQuitarRol.Text = "Quitar rol";
            this.btnQuitarRol.UseVisualStyleBackColor = true;
            this.btnQuitarRol.Click += new System.EventHandler(this.btnQuitarRol_Click);
            this.btnQuitarRol.MouseEnter += new System.EventHandler(this.btnQuitarRol_MouseEnter);
            this.btnQuitarRol.MouseLeave += new System.EventHandler(this.btnQuitarRol_MouseLeave);
            // 
            // btnAsignarRol
            // 
            this.btnAsignarRol.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAsignarRol.ForeColor = System.Drawing.Color.Navy;
            this.btnAsignarRol.Location = new System.Drawing.Point(12, 89);
            this.btnAsignarRol.Margin = new System.Windows.Forms.Padding(2);
            this.btnAsignarRol.Name = "btnAsignarRol";
            this.btnAsignarRol.Size = new System.Drawing.Size(109, 34);
            this.btnAsignarRol.TabIndex = 2;
            this.btnAsignarRol.Text = "Agregar rol";
            this.btnAsignarRol.UseVisualStyleBackColor = true;
            this.btnAsignarRol.Click += new System.EventHandler(this.btnAsignarRol_Click);
            this.btnAsignarRol.MouseEnter += new System.EventHandler(this.btnAsignarRol_MouseEnter);
            this.btnAsignarRol.MouseLeave += new System.EventHandler(this.btnAsignarRol_MouseLeave);
            // 
            // cmbRolUsuario
            // 
            this.cmbRolUsuario.FormattingEnabled = true;
            this.cmbRolUsuario.Location = new System.Drawing.Point(67, 47);
            this.cmbRolUsuario.Margin = new System.Windows.Forms.Padding(2);
            this.cmbRolUsuario.Name = "cmbRolUsuario";
            this.cmbRolUsuario.Size = new System.Drawing.Size(132, 24);
            this.cmbRolUsuario.TabIndex = 0;
            // 
            // gbAsignarPermisoausuario
            // 
            this.gbAsignarPermisoausuario.BackColor = System.Drawing.Color.White;
            this.gbAsignarPermisoausuario.Controls.Add(this.lblPermisoAsignarPermisoaUsuario);
            this.gbAsignarPermisoausuario.Controls.Add(this.btnQuitarPermisoDirecto);
            this.gbAsignarPermisoausuario.Controls.Add(this.btnAgregarPermisoDirecto);
            this.gbAsignarPermisoausuario.Controls.Add(this.cmbPermisoDirecto);
            this.gbAsignarPermisoausuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbAsignarPermisoausuario.ForeColor = System.Drawing.Color.Black;
            this.gbAsignarPermisoausuario.Location = new System.Drawing.Point(322, 585);
            this.gbAsignarPermisoausuario.Margin = new System.Windows.Forms.Padding(2);
            this.gbAsignarPermisoausuario.Name = "gbAsignarPermisoausuario";
            this.gbAsignarPermisoausuario.Padding = new System.Windows.Forms.Padding(2);
            this.gbAsignarPermisoausuario.Size = new System.Drawing.Size(276, 108);
            this.gbAsignarPermisoausuario.TabIndex = 10;
            this.gbAsignarPermisoausuario.TabStop = false;
            this.gbAsignarPermisoausuario.Text = "Asignar permiso a usuario";
            // 
            // lblPermisoAsignarPermisoaUsuario
            // 
            this.lblPermisoAsignarPermisoaUsuario.AutoSize = true;
            this.lblPermisoAsignarPermisoaUsuario.BackColor = System.Drawing.Color.Transparent;
            this.lblPermisoAsignarPermisoaUsuario.ForeColor = System.Drawing.Color.Black;
            this.lblPermisoAsignarPermisoaUsuario.Location = new System.Drawing.Point(25, 31);
            this.lblPermisoAsignarPermisoaUsuario.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblPermisoAsignarPermisoaUsuario.Name = "lblPermisoAsignarPermisoaUsuario";
            this.lblPermisoAsignarPermisoaUsuario.Size = new System.Drawing.Size(60, 16);
            this.lblPermisoAsignarPermisoaUsuario.TabIndex = 4;
            this.lblPermisoAsignarPermisoaUsuario.Text = "Permiso:";
            // 
            // btnQuitarPermisoDirecto
            // 
            this.btnQuitarPermisoDirecto.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnQuitarPermisoDirecto.ForeColor = System.Drawing.Color.Navy;
            this.btnQuitarPermisoDirecto.Location = new System.Drawing.Point(154, 60);
            this.btnQuitarPermisoDirecto.Margin = new System.Windows.Forms.Padding(2);
            this.btnQuitarPermisoDirecto.Name = "btnQuitarPermisoDirecto";
            this.btnQuitarPermisoDirecto.Size = new System.Drawing.Size(109, 35);
            this.btnQuitarPermisoDirecto.TabIndex = 3;
            this.btnQuitarPermisoDirecto.Text = "Quitar permiso";
            this.btnQuitarPermisoDirecto.UseVisualStyleBackColor = true;
            this.btnQuitarPermisoDirecto.Click += new System.EventHandler(this.btnQuitarPermisoDirecto_Click);
            this.btnQuitarPermisoDirecto.MouseEnter += new System.EventHandler(this.btnQuitarPermisoDirecto_MouseEnter);
            this.btnQuitarPermisoDirecto.MouseLeave += new System.EventHandler(this.btnQuitarPermisoDirecto_MouseLeave);
            // 
            // btnAgregarPermisoDirecto
            // 
            this.btnAgregarPermisoDirecto.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAgregarPermisoDirecto.ForeColor = System.Drawing.Color.Navy;
            this.btnAgregarPermisoDirecto.Location = new System.Drawing.Point(18, 60);
            this.btnAgregarPermisoDirecto.Margin = new System.Windows.Forms.Padding(2);
            this.btnAgregarPermisoDirecto.Name = "btnAgregarPermisoDirecto";
            this.btnAgregarPermisoDirecto.Size = new System.Drawing.Size(115, 35);
            this.btnAgregarPermisoDirecto.TabIndex = 2;
            this.btnAgregarPermisoDirecto.Text = "Agregar permiso";
            this.btnAgregarPermisoDirecto.UseVisualStyleBackColor = true;
            this.btnAgregarPermisoDirecto.Click += new System.EventHandler(this.btnAgregarPermisoDirecto_Click);
            this.btnAgregarPermisoDirecto.MouseEnter += new System.EventHandler(this.btnAgregarPermisoDirecto_MouseEnter);
            this.btnAgregarPermisoDirecto.MouseLeave += new System.EventHandler(this.btnAgregarPermisoDirecto_MouseLeave);
            // 
            // cmbPermisoDirecto
            // 
            this.cmbPermisoDirecto.FormattingEnabled = true;
            this.cmbPermisoDirecto.Location = new System.Drawing.Point(89, 28);
            this.cmbPermisoDirecto.Margin = new System.Windows.Forms.Padding(2);
            this.cmbPermisoDirecto.Name = "cmbPermisoDirecto";
            this.cmbPermisoDirecto.Size = new System.Drawing.Size(132, 24);
            this.cmbPermisoDirecto.TabIndex = 0;
            // 
            // lstPermisosDirectos
            // 
            this.lstPermisosDirectos.FormattingEnabled = true;
            this.lstPermisosDirectos.Location = new System.Drawing.Point(613, 585);
            this.lstPermisosDirectos.Margin = new System.Windows.Forms.Padding(2);
            this.lstPermisosDirectos.Name = "lstPermisosDirectos";
            this.lstPermisosDirectos.Size = new System.Drawing.Size(308, 108);
            this.lstPermisosDirectos.TabIndex = 11;
            // 
            // tvrGestionRoles
            // 
            this.tvrGestionRoles.Location = new System.Drawing.Point(202, 86);
            this.tvrGestionRoles.Margin = new System.Windows.Forms.Padding(2);
            this.tvrGestionRoles.Name = "tvrGestionRoles";
            this.tvrGestionRoles.Size = new System.Drawing.Size(819, 279);
            this.tvrGestionRoles.TabIndex = 12;
            // 
            // cmbUsuario
            // 
            this.cmbUsuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbUsuario.FormattingEnabled = true;
            this.cmbUsuario.Location = new System.Drawing.Point(534, 383);
            this.cmbUsuario.Margin = new System.Windows.Forms.Padding(2);
            this.cmbUsuario.Name = "cmbUsuario";
            this.cmbUsuario.Size = new System.Drawing.Size(167, 24);
            this.cmbUsuario.TabIndex = 13;
            this.cmbUsuario.SelectedIndexChanged += new System.EventHandler(this.cmbUsuario_SelectedIndexChanged);
            // 
            // lblUsuarioGestionRoles
            // 
            this.lblUsuarioGestionRoles.AutoSize = true;
            this.lblUsuarioGestionRoles.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUsuarioGestionRoles.ForeColor = System.Drawing.Color.White;
            this.lblUsuarioGestionRoles.Location = new System.Drawing.Point(473, 386);
            this.lblUsuarioGestionRoles.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblUsuarioGestionRoles.Name = "lblUsuarioGestionRoles";
            this.lblUsuarioGestionRoles.Size = new System.Drawing.Size(57, 16);
            this.lblUsuarioGestionRoles.TabIndex = 14;
            this.lblUsuarioGestionRoles.Text = "Usuario:";
            // 
            // lblGestiondeRolesTitulo
            // 
            this.lblGestiondeRolesTitulo.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGestiondeRolesTitulo.ForeColor = System.Drawing.Color.White;
            this.lblGestiondeRolesTitulo.Location = new System.Drawing.Point(334, 33);
            this.lblGestiondeRolesTitulo.Name = "lblGestiondeRolesTitulo";
            this.lblGestiondeRolesTitulo.Size = new System.Drawing.Size(601, 36);
            this.lblGestiondeRolesTitulo.TabIndex = 13;
            this.lblGestiondeRolesTitulo.Text = "GESTION DE ROLES";
            this.lblGestiondeRolesTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // FRMGestionRoles
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(1269, 726);
            this.Controls.Add(this.cmbUsuario);
            this.Controls.Add(this.lblUsuarioGestionRoles);
            this.Controls.Add(this.lstPermisosDirectos);
            this.Controls.Add(this.gbAsignarRolAUsuario);
            this.Controls.Add(this.gbSubRolGestionRoles);
            this.Controls.Add(this.tvrGestionRoles);
            this.Controls.Add(this.lblGestiondeRolesTitulo);
            this.Controls.Add(this.gbCrearRolesGestionRoles);
            this.Controls.Add(this.gbAsignarPermisoausuario);
            this.Controls.Add(this.gbPermisosParaRoles);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "FRMGestionRoles";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FRMGestionRoles";
            this.Load += new System.EventHandler(this.FRMGestionRoles_Load);
            this.gbCrearRolesGestionRoles.ResumeLayout(false);
            this.gbCrearRolesGestionRoles.PerformLayout();
            this.gbPermisosParaRoles.ResumeLayout(false);
            this.gbPermisosParaRoles.PerformLayout();
            this.gbSubRolGestionRoles.ResumeLayout(false);
            this.gbSubRolGestionRoles.PerformLayout();
            this.gbAsignarRolAUsuario.ResumeLayout(false);
            this.gbAsignarRolAUsuario.PerformLayout();
            this.gbAsignarPermisoausuario.ResumeLayout(false);
            this.gbAsignarPermisoausuario.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtNombreRol;
        private System.Windows.Forms.Label lblPermiso;
        private System.Windows.Forms.Label lblNombreGestionRoles;
        private System.Windows.Forms.Label lblDescripcionGestionRoles;
        private System.Windows.Forms.TextBox txtDescRol;
        private System.Windows.Forms.Button btnCrearRol;
        private System.Windows.Forms.GroupBox gbCrearRolesGestionRoles;
        private System.Windows.Forms.GroupBox gbPermisosParaRoles;
        private System.Windows.Forms.ComboBox cmbPermiso;
        private System.Windows.Forms.ComboBox cmbRolParaPermiso;
        private System.Windows.Forms.Label lblRolParaPermiso;
        private System.Windows.Forms.Button btnQuitarPermiso;
        private System.Windows.Forms.Button btnAgregarPermiso;
        private System.Windows.Forms.GroupBox gbSubRolGestionRoles;
        private System.Windows.Forms.Label lblRolPadreGestionRoles;
        private System.Windows.Forms.Button btnQuitarSubRol;
        private System.Windows.Forms.Button btnAgregarSubRol;
        private System.Windows.Forms.Label lblRolHijo;
        private System.Windows.Forms.ComboBox cmbRolHijo;
        private System.Windows.Forms.ComboBox cmbRolPadre;
        private System.Windows.Forms.GroupBox gbAsignarRolAUsuario;
        private System.Windows.Forms.Label lblRol;
        private System.Windows.Forms.Button btnQuitarRol;
        private System.Windows.Forms.Button btnAsignarRol;
        private System.Windows.Forms.ComboBox cmbRolUsuario;
        private System.Windows.Forms.GroupBox gbAsignarPermisoausuario;
        private System.Windows.Forms.Label lblPermisoAsignarPermisoaUsuario;
        private System.Windows.Forms.Button btnQuitarPermisoDirecto;
        private System.Windows.Forms.Button btnAgregarPermisoDirecto;
        private System.Windows.Forms.ComboBox cmbPermisoDirecto;
        private System.Windows.Forms.ListBox lstPermisosDirectos;
        private System.Windows.Forms.TreeView tvrGestionRoles;
        private System.Windows.Forms.ComboBox cmbUsuario;
        private System.Windows.Forms.Label lblUsuarioGestionRoles;
        private System.Windows.Forms.Label lblGestiondeRolesTitulo;
    }
}