namespace ProyectoArchivos
{
    partial class Form_Principal
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_Principal));
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.bt_nuevaEntidad = new System.Windows.Forms.Button();
            this.bt_modificaEntidad = new System.Windows.Forms.Button();
            this.bt_eliminaEntidad = new System.Windows.Forms.Button();
            this.tb_nombreEnt = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tb_Archivo = new System.Windows.Forms.TextBox();
            this.cb_SelEnt = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.lb_cab = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.archivoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.crearToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.abrirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reiniciarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.entidadesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.atributosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.datosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.button1 = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.Id_Ent = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nombre_Ent = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Dir_Ent = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Dir_Atributo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Dir_dar = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Dir_sig_Ent = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id_Ent,
            this.Nombre_Ent,
            this.Dir_Ent,
            this.Dir_Atributo,
            this.Dir_dar,
            this.Dir_sig_Ent});
            this.dataGridView1.Location = new System.Drawing.Point(35, 155);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(643, 250);
            this.dataGridView1.TabIndex = 2;
            this.dataGridView1.RowsRemoved += new System.Windows.Forms.DataGridViewRowsRemovedEventHandler(this.dataGridView1_RowsRemoved);
            // 
            // bt_nuevaEntidad
            // 
            this.bt_nuevaEntidad.Enabled = false;
            this.bt_nuevaEntidad.Location = new System.Drawing.Point(33, 97);
            this.bt_nuevaEntidad.Name = "bt_nuevaEntidad";
            this.bt_nuevaEntidad.Size = new System.Drawing.Size(107, 31);
            this.bt_nuevaEntidad.TabIndex = 3;
            this.bt_nuevaEntidad.Text = "Nueva Tabla";
            this.bt_nuevaEntidad.UseVisualStyleBackColor = true;
            this.bt_nuevaEntidad.Click += new System.EventHandler(this.bt_nuevaEntidad_Click);
            // 
            // bt_modificaEntidad
            // 
            this.bt_modificaEntidad.Enabled = false;
            this.bt_modificaEntidad.Location = new System.Drawing.Point(373, 118);
            this.bt_modificaEntidad.Name = "bt_modificaEntidad";
            this.bt_modificaEntidad.Size = new System.Drawing.Size(107, 31);
            this.bt_modificaEntidad.TabIndex = 4;
            this.bt_modificaEntidad.Text = "Modifica Tabla";
            this.bt_modificaEntidad.UseVisualStyleBackColor = true;
            this.bt_modificaEntidad.Click += new System.EventHandler(this.bt_modificaEntidad_Click);
            // 
            // bt_eliminaEntidad
            // 
            this.bt_eliminaEntidad.Enabled = false;
            this.bt_eliminaEntidad.Location = new System.Drawing.Point(486, 118);
            this.bt_eliminaEntidad.Name = "bt_eliminaEntidad";
            this.bt_eliminaEntidad.Size = new System.Drawing.Size(107, 31);
            this.bt_eliminaEntidad.TabIndex = 5;
            this.bt_eliminaEntidad.Text = "Elimina Tabla";
            this.bt_eliminaEntidad.UseVisualStyleBackColor = true;
            this.bt_eliminaEntidad.Click += new System.EventHandler(this.bt_eliminaEntidad_Click);
            // 
            // tb_nombreEnt
            // 
            this.tb_nombreEnt.Location = new System.Drawing.Point(157, 103);
            this.tb_nombreEnt.Name = "tb_nombreEnt";
            this.tb_nombreEnt.Size = new System.Drawing.Size(100, 20);
            this.tb_nombreEnt.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(29, 60);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 20);
            this.label1.TabIndex = 8;
            this.label1.Text = "Tablas";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.DarkSlateBlue;
            this.label2.Location = new System.Drawing.Point(390, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 24);
            this.label2.TabIndex = 9;
            this.label2.Text = "Ruta:";
            // 
            // tb_Archivo
            // 
            this.tb_Archivo.Location = new System.Drawing.Point(454, 27);
            this.tb_Archivo.Name = "tb_Archivo";
            this.tb_Archivo.ReadOnly = true;
            this.tb_Archivo.Size = new System.Drawing.Size(276, 20);
            this.tb_Archivo.TabIndex = 10;
            // 
            // cb_SelEnt
            // 
            this.cb_SelEnt.FormattingEnabled = true;
            this.cb_SelEnt.Location = new System.Drawing.Point(474, 81);
            this.cb_SelEnt.Name = "cb_SelEnt";
            this.cb_SelEnt.Size = new System.Drawing.Size(130, 21);
            this.cb_SelEnt.TabIndex = 16;
            this.cb_SelEnt.SelectedIndexChanged += new System.EventHandler(this.cb_SelEnt_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.DarkSlateBlue;
            this.label4.Location = new System.Drawing.Point(370, 84);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(78, 18);
            this.label4.TabIndex = 17;
            this.label4.Text = "Sel Tabla";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.DarkSlateBlue;
            this.label9.Location = new System.Drawing.Point(76, 131);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(85, 18);
            this.label9.TabIndex = 31;
            this.label9.Text = "Cabecera:";
            // 
            // lb_cab
            // 
            this.lb_cab.AutoSize = true;
            this.lb_cab.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_cab.ForeColor = System.Drawing.Color.DarkSlateBlue;
            this.lb_cab.Location = new System.Drawing.Point(163, 131);
            this.lb_cab.Name = "lb_cab";
            this.lb_cab.Size = new System.Drawing.Size(23, 18);
            this.lb_cab.TabIndex = 32;
            this.lb_cab.Text = "-1";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.archivoToolStripMenuItem,
            this.entidadesToolStripMenuItem,
            this.atributosToolStripMenuItem,
            this.datosToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(730, 24);
            this.menuStrip1.TabIndex = 33;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // archivoToolStripMenuItem
            // 
            this.archivoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.crearToolStripMenuItem,
            this.abrirToolStripMenuItem,
            this.reiniciarToolStripMenuItem});
            this.archivoToolStripMenuItem.Name = "archivoToolStripMenuItem";
            this.archivoToolStripMenuItem.Size = new System.Drawing.Size(60, 20);
            this.archivoToolStripMenuItem.Text = "Archivo";
            // 
            // crearToolStripMenuItem
            // 
            this.crearToolStripMenuItem.Name = "crearToolStripMenuItem";
            this.crearToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.crearToolStripMenuItem.Text = "Crear";
            this.crearToolStripMenuItem.Click += new System.EventHandler(this.crearToolStripMenuItem_Click);
            // 
            // abrirToolStripMenuItem
            // 
            this.abrirToolStripMenuItem.Name = "abrirToolStripMenuItem";
            this.abrirToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.abrirToolStripMenuItem.Text = "Abrir";
            this.abrirToolStripMenuItem.Click += new System.EventHandler(this.abrirToolStripMenuItem_Click);
            // 
            // reiniciarToolStripMenuItem
            // 
            this.reiniciarToolStripMenuItem.Name = "reiniciarToolStripMenuItem";
            this.reiniciarToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.reiniciarToolStripMenuItem.Text = "Reiniciar";
            this.reiniciarToolStripMenuItem.Click += new System.EventHandler(this.reiniciarToolStripMenuItem_Click);
            // 
            // entidadesToolStripMenuItem
            // 
            this.entidadesToolStripMenuItem.Enabled = false;
            this.entidadesToolStripMenuItem.Name = "entidadesToolStripMenuItem";
            this.entidadesToolStripMenuItem.Size = new System.Drawing.Size(51, 20);
            this.entidadesToolStripMenuItem.Text = "Tablas";
            // 
            // atributosToolStripMenuItem
            // 
            this.atributosToolStripMenuItem.Name = "atributosToolStripMenuItem";
            this.atributosToolStripMenuItem.Size = new System.Drawing.Size(68, 20);
            this.atributosToolStripMenuItem.Text = "Atributos";
            this.atributosToolStripMenuItem.Click += new System.EventHandler(this.atributosToolStripMenuItem_Click);
            // 
            // datosToolStripMenuItem
            // 
            this.datosToolStripMenuItem.Name = "datosToolStripMenuItem";
            this.datosToolStripMenuItem.Size = new System.Drawing.Size(49, 20);
            this.datosToolStripMenuItem.Text = "Datos";
            this.datosToolStripMenuItem.Click += new System.EventHandler(this.datosToolStripMenuItem_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(263, 97);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(71, 31);
            this.button1.TabIndex = 34;
            this.button1.Text = "Aceptar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Visible = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Id_Ent
            // 
            this.Id_Ent.HeaderText = "ID_Tabla";
            this.Id_Ent.Name = "Id_Ent";
            this.Id_Ent.ReadOnly = true;
            // 
            // Nombre_Ent
            // 
            this.Nombre_Ent.HeaderText = "Nombre Tabla";
            this.Nombre_Ent.Name = "Nombre_Ent";
            this.Nombre_Ent.ReadOnly = true;
            // 
            // Dir_Ent
            // 
            this.Dir_Ent.HeaderText = "Dir. Tabla";
            this.Dir_Ent.Name = "Dir_Ent";
            this.Dir_Ent.ReadOnly = true;
            // 
            // Dir_Atributo
            // 
            this.Dir_Atributo.HeaderText = "Dir. Atributo";
            this.Dir_Atributo.Name = "Dir_Atributo";
            this.Dir_Atributo.ReadOnly = true;
            // 
            // Dir_dar
            // 
            this.Dir_dar.HeaderText = "Dir. Datos";
            this.Dir_dar.Name = "Dir_dar";
            this.Dir_dar.ReadOnly = true;
            // 
            // Dir_sig_Ent
            // 
            this.Dir_sig_Ent.HeaderText = "Dir. siguiente Tabla";
            this.Dir_sig_Ent.Name = "Dir_sig_Ent";
            this.Dir_sig_Ent.ReadOnly = true;
            // 
            // Form_Principal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(730, 457);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.lb_cab);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cb_SelEnt);
            this.Controls.Add(this.tb_Archivo);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tb_nombreEnt);
            this.Controls.Add(this.bt_eliminaEntidad);
            this.Controls.Add(this.bt_modificaEntidad);
            this.Controls.Add(this.bt_nuevaEntidad);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.menuStrip1);
            this.ForeColor = System.Drawing.Color.MediumBlue;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "Form_Principal";
            this.Text = "Manejador de Bases de datos";
            this.Activated += new System.EventHandler(this.Form_Principal_Activated);
            this.Deactivate += new System.EventHandler(this.Form_Principal_Deactivate);
            this.Load += new System.EventHandler(this.Form_Principal_Load);
            this.VisibleChanged += new System.EventHandler(this.Form_Principal_VisibleChanged);
            this.Enter += new System.EventHandler(this.Form_Principal_Enter);
            this.ChangeUICues += new System.Windows.Forms.UICuesEventHandler(this.Form_Principal_ChangeUICues);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button bt_nuevaEntidad;
        private System.Windows.Forms.Button bt_modificaEntidad;
        private System.Windows.Forms.Button bt_eliminaEntidad;
        private System.Windows.Forms.TextBox tb_nombreEnt;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tb_Archivo;
        private System.Windows.Forms.ComboBox cb_SelEnt;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label lb_cab;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem archivoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem crearToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem abrirToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem entidadesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem atributosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem datosToolStripMenuItem;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ToolStripMenuItem reiniciarToolStripMenuItem;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id_Ent;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nombre_Ent;
        private System.Windows.Forms.DataGridViewTextBoxColumn Dir_Ent;
        private System.Windows.Forms.DataGridViewTextBoxColumn Dir_Atributo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Dir_dar;
        private System.Windows.Forms.DataGridViewTextBoxColumn Dir_sig_Ent;
    }
}

