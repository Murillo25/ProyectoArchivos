namespace ProyectoArchivos
{
    partial class Form_Atributos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_Atributos));
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Id_Atributos = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nombre_Atributo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Tipo_Dato = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Longitud = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Tipo_Indice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Dir_Atrib = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Dir_Indice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Dir_sig_atributo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bt_nuevoAtrib = new System.Windows.Forms.Button();
            this.bt_modificaEntidad = new System.Windows.Forms.Button();
            this.bt_eliminaEntidad = new System.Windows.Forms.Button();
            this.tb_nombreAtrib = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tb_Archivo = new System.Windows.Forms.TextBox();
            this.cb_SelEnt = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.archivoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.crearToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.abrirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.entidadesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.atributosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.datosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.button1 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.Cb_Dato = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.tb_Long = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.Cb_Index = new System.Windows.Forms.ComboBox();
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
            this.Id_Atributos,
            this.Nombre_Atributo,
            this.Tipo_Dato,
            this.Longitud,
            this.Tipo_Indice,
            this.Dir_Atrib,
            this.Dir_Indice,
            this.Dir_sig_atributo});
            this.dataGridView1.Location = new System.Drawing.Point(33, 182);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(643, 250);
            this.dataGridView1.TabIndex = 2;
            this.dataGridView1.RowsRemoved += new System.Windows.Forms.DataGridViewRowsRemovedEventHandler(this.dataGridView1_RowsRemoved);
            // 
            // Id_Atributos
            // 
            this.Id_Atributos.HeaderText = "Id_Atributos";
            this.Id_Atributos.Name = "Id_Atributos";
            this.Id_Atributos.ReadOnly = true;
            // 
            // Nombre_Atributo
            // 
            this.Nombre_Atributo.HeaderText = "Nombre Atributo";
            this.Nombre_Atributo.Name = "Nombre_Atributo";
            this.Nombre_Atributo.ReadOnly = true;
            // 
            // Tipo_Dato
            // 
            this.Tipo_Dato.HeaderText = "Tipo de Dato";
            this.Tipo_Dato.Name = "Tipo_Dato";
            this.Tipo_Dato.ReadOnly = true;
            // 
            // Longitud
            // 
            this.Longitud.HeaderText = "Longitud";
            this.Longitud.Name = "Longitud";
            this.Longitud.ReadOnly = true;
            // 
            // Tipo_Indice
            // 
            this.Tipo_Indice.HeaderText = "Tipo Indice";
            this.Tipo_Indice.Name = "Tipo_Indice";
            this.Tipo_Indice.ReadOnly = true;
            // 
            // Dir_Atrib
            // 
            this.Dir_Atrib.HeaderText = "Dirección Atributo";
            this.Dir_Atrib.Name = "Dir_Atrib";
            this.Dir_Atrib.ReadOnly = true;
            // 
            // Dir_Indice
            // 
            this.Dir_Indice.HeaderText = "Dirección Indice";
            this.Dir_Indice.Name = "Dir_Indice";
            this.Dir_Indice.ReadOnly = true;
            // 
            // Dir_sig_atributo
            // 
            this.Dir_sig_atributo.HeaderText = "Dirección siguiente Atrib";
            this.Dir_sig_atributo.Name = "Dir_sig_atributo";
            this.Dir_sig_atributo.ReadOnly = true;
            // 
            // bt_nuevoAtrib
            // 
            this.bt_nuevoAtrib.Location = new System.Drawing.Point(33, 108);
            this.bt_nuevoAtrib.Name = "bt_nuevoAtrib";
            this.bt_nuevoAtrib.Size = new System.Drawing.Size(107, 31);
            this.bt_nuevoAtrib.TabIndex = 3;
            this.bt_nuevoAtrib.Text = "Nuevo Atributo";
            this.bt_nuevoAtrib.UseVisualStyleBackColor = true;
            this.bt_nuevoAtrib.Click += new System.EventHandler(this.bt_nuevoAtrib_Click);
            // 
            // bt_modificaEntidad
            // 
            this.bt_modificaEntidad.Location = new System.Drawing.Point(495, 135);
            this.bt_modificaEntidad.Name = "bt_modificaEntidad";
            this.bt_modificaEntidad.Size = new System.Drawing.Size(107, 31);
            this.bt_modificaEntidad.TabIndex = 4;
            this.bt_modificaEntidad.Text = "Modifica Atributo";
            this.bt_modificaEntidad.UseVisualStyleBackColor = true;
            this.bt_modificaEntidad.Click += new System.EventHandler(this.bt_modificaEntidad_Click);
            // 
            // bt_eliminaEntidad
            // 
            this.bt_eliminaEntidad.Location = new System.Drawing.Point(608, 135);
            this.bt_eliminaEntidad.Name = "bt_eliminaEntidad";
            this.bt_eliminaEntidad.Size = new System.Drawing.Size(107, 31);
            this.bt_eliminaEntidad.TabIndex = 5;
            this.bt_eliminaEntidad.Text = "Elimina Atributo";
            this.bt_eliminaEntidad.UseVisualStyleBackColor = true;
            this.bt_eliminaEntidad.Click += new System.EventHandler(this.bt_eliminaEntidad_Click);
            // 
            // tb_nombreAtrib
            // 
            this.tb_nombreAtrib.Location = new System.Drawing.Point(277, 85);
            this.tb_nombreAtrib.Name = "tb_nombreAtrib";
            this.tb_nombreAtrib.Size = new System.Drawing.Size(100, 20);
            this.tb_nombreAtrib.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(29, 60);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(156, 20);
            this.label1.TabIndex = 8;
            this.label1.Text = "Tabla de Atributos";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.DarkSlateBlue;
            this.label2.Location = new System.Drawing.Point(379, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 24);
            this.label2.TabIndex = 9;
            this.label2.Text = "Archivo:";
            // 
            // tb_Archivo
            // 
            this.tb_Archivo.Location = new System.Drawing.Point(461, 29);
            this.tb_Archivo.Name = "tb_Archivo";
            this.tb_Archivo.ReadOnly = true;
            this.tb_Archivo.Size = new System.Drawing.Size(269, 20);
            this.tb_Archivo.TabIndex = 10;
            // 
            // cb_SelEnt
            // 
            this.cb_SelEnt.FormattingEnabled = true;
            this.cb_SelEnt.Location = new System.Drawing.Point(240, 34);
            this.cb_SelEnt.MaxLength = 35;
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
            this.label4.Location = new System.Drawing.Point(136, 37);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(98, 18);
            this.label4.TabIndex = 17;
            this.label4.Text = "Sel Entidad:";
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
            this.abrirToolStripMenuItem});
            this.archivoToolStripMenuItem.Enabled = false;
            this.archivoToolStripMenuItem.Name = "archivoToolStripMenuItem";
            this.archivoToolStripMenuItem.Size = new System.Drawing.Size(60, 20);
            this.archivoToolStripMenuItem.Text = "Archivo";
            // 
            // crearToolStripMenuItem
            // 
            this.crearToolStripMenuItem.Name = "crearToolStripMenuItem";
            this.crearToolStripMenuItem.Size = new System.Drawing.Size(102, 22);
            this.crearToolStripMenuItem.Text = "Crear";
            this.crearToolStripMenuItem.Click += new System.EventHandler(this.crearToolStripMenuItem_Click);
            // 
            // abrirToolStripMenuItem
            // 
            this.abrirToolStripMenuItem.Name = "abrirToolStripMenuItem";
            this.abrirToolStripMenuItem.Size = new System.Drawing.Size(102, 22);
            this.abrirToolStripMenuItem.Text = "Abrir";
            this.abrirToolStripMenuItem.Click += new System.EventHandler(this.abrirToolStripMenuItem_Click);
            // 
            // entidadesToolStripMenuItem
            // 
            this.entidadesToolStripMenuItem.Name = "entidadesToolStripMenuItem";
            this.entidadesToolStripMenuItem.Size = new System.Drawing.Size(70, 20);
            this.entidadesToolStripMenuItem.Text = "Entidades";
            this.entidadesToolStripMenuItem.Click += new System.EventHandler(this.entidadesToolStripMenuItem_Click);
            // 
            // atributosToolStripMenuItem
            // 
            this.atributosToolStripMenuItem.Enabled = false;
            this.atributosToolStripMenuItem.Name = "atributosToolStripMenuItem";
            this.atributosToolStripMenuItem.Size = new System.Drawing.Size(68, 20);
            this.atributosToolStripMenuItem.Text = "Atributos";
            // 
            // datosToolStripMenuItem
            // 
            this.datosToolStripMenuItem.Name = "datosToolStripMenuItem";
            this.datosToolStripMenuItem.Size = new System.Drawing.Size(49, 20);
            this.datosToolStripMenuItem.Text = "Datos";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(383, 108);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(71, 31);
            this.button1.TabIndex = 34;
            this.button1.Text = "Aceptar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Visible = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.DarkSlateBlue;
            this.label3.Location = new System.Drawing.Point(481, 105);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 18);
            this.label3.TabIndex = 36;
            this.label3.Text = "Sel Atributo:";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(585, 102);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(130, 21);
            this.comboBox1.TabIndex = 35;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.DarkSlateBlue;
            this.label5.Location = new System.Drawing.Point(191, 86);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(67, 16);
            this.label5.TabIndex = 37;
            this.label5.Text = "Nombre:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.DarkSlateBlue;
            this.label6.Location = new System.Drawing.Point(168, 108);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(103, 16);
            this.label6.TabIndex = 38;
            this.label6.Text = "Tipo de Dato:";
            // 
            // Cb_Dato
            // 
            this.Cb_Dato.FormattingEnabled = true;
            this.Cb_Dato.Items.AddRange(new object[] {
            "Entero",
            "Cadena"});
            this.Cb_Dato.Location = new System.Drawing.Point(277, 107);
            this.Cb_Dato.Name = "Cb_Dato";
            this.Cb_Dato.Size = new System.Drawing.Size(100, 21);
            this.Cb_Dato.TabIndex = 39;
            this.Cb_Dato.TextChanged += new System.EventHandler(this.Cb_Dato_TextChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.DarkSlateBlue;
            this.label7.Location = new System.Drawing.Point(183, 133);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(71, 16);
            this.label7.TabIndex = 40;
            this.label7.Text = "Longitud:";
            // 
            // tb_Long
            // 
            this.tb_Long.Location = new System.Drawing.Point(277, 129);
            this.tb_Long.Name = "tb_Long";
            this.tb_Long.Size = new System.Drawing.Size(100, 20);
            this.tb_Long.TabIndex = 41;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.DarkSlateBlue;
            this.label8.Location = new System.Drawing.Point(167, 154);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(112, 16);
            this.label8.TabIndex = 42;
            this.label8.Text = "Tipo de Indice:";
            // 
            // Cb_Index
            // 
            this.Cb_Index.FormattingEnabled = true;
            this.Cb_Index.Items.AddRange(new object[] {
            "0(Sin_tipo)",
            "1(Clave_de_busqueda)",
            "2(Indice_primario)",
            "3(Indice_secundario)"});
            this.Cb_Index.Location = new System.Drawing.Point(277, 151);
            this.Cb_Index.Name = "Cb_Index";
            this.Cb_Index.Size = new System.Drawing.Size(100, 21);
            this.Cb_Index.TabIndex = 43;
            // 
            // Form_Atributos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(730, 457);
            this.Controls.Add(this.Cb_Index);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.tb_Long);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.Cb_Dato);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cb_SelEnt);
            this.Controls.Add(this.tb_Archivo);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tb_nombreAtrib);
            this.Controls.Add(this.bt_eliminaEntidad);
            this.Controls.Add(this.bt_modificaEntidad);
            this.Controls.Add(this.bt_nuevoAtrib);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.menuStrip1);
            this.ForeColor = System.Drawing.Color.MediumBlue;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "Form_Atributos";
            this.Text = "Manejador de Archivos";
            this.Load += new System.EventHandler(this.Form_Principal_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button bt_nuevoAtrib;
        private System.Windows.Forms.Button bt_modificaEntidad;
        private System.Windows.Forms.Button bt_eliminaEntidad;
        private System.Windows.Forms.TextBox tb_nombreAtrib;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tb_Archivo;
        private System.Windows.Forms.ComboBox cb_SelEnt;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem archivoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem crearToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem abrirToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem entidadesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem atributosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem datosToolStripMenuItem;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox Cb_Dato;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox tb_Long;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox Cb_Index;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id_Atributos;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nombre_Atributo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Tipo_Dato;
        private System.Windows.Forms.DataGridViewTextBoxColumn Longitud;
        private System.Windows.Forms.DataGridViewTextBoxColumn Tipo_Indice;
        private System.Windows.Forms.DataGridViewTextBoxColumn Dir_Atrib;
        private System.Windows.Forms.DataGridViewTextBoxColumn Dir_Indice;
        private System.Windows.Forms.DataGridViewTextBoxColumn Dir_sig_atributo;
    }
}

