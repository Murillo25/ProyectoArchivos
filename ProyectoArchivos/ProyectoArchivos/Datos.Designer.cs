namespace ProyectoArchivos
{
    partial class Datos
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.archivoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.crearToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.abrirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.entidadesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.atributosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.datosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.TabControl = new System.Windows.Forms.TabControl();
            this.TabDatos = new System.Windows.Forms.TabPage();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.bt_eliminaDato = new System.Windows.Forms.Button();
            this.bt_modDato = new System.Windows.Forms.Button();
            this.bt_nuevoDato = new System.Windows.Forms.Button();
            this.dGV_AgregarDat = new System.Windows.Forms.DataGridView();
            this.Nombre_Atributo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Tipo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Dato = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label4 = new System.Windows.Forms.Label();
            this.cb_SelEnt = new System.Windows.Forms.ComboBox();
            this.TabIdx = new System.Windows.Forms.TabPage();
            this.dataGridView4 = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.dataGridView3 = new System.Windows.Forms.DataGridView();
            this.ClaveS = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DireccionLista = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.Clave = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Direccion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.button1 = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.TabControl.SuspendLayout();
            this.TabDatos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dGV_AgregarDat)).BeginInit();
            this.TabIdx.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.SuspendLayout();
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
            this.menuStrip1.Size = new System.Drawing.Size(868, 24);
            this.menuStrip1.TabIndex = 34;
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
            // 
            // abrirToolStripMenuItem
            // 
            this.abrirToolStripMenuItem.Name = "abrirToolStripMenuItem";
            this.abrirToolStripMenuItem.Size = new System.Drawing.Size(102, 22);
            this.abrirToolStripMenuItem.Text = "Abrir";
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
            this.atributosToolStripMenuItem.Name = "atributosToolStripMenuItem";
            this.atributosToolStripMenuItem.Size = new System.Drawing.Size(68, 20);
            this.atributosToolStripMenuItem.Text = "Atributos";
            // 
            // datosToolStripMenuItem
            // 
            this.datosToolStripMenuItem.Enabled = false;
            this.datosToolStripMenuItem.Name = "datosToolStripMenuItem";
            this.datosToolStripMenuItem.Size = new System.Drawing.Size(49, 20);
            this.datosToolStripMenuItem.Text = "Datos";
            this.datosToolStripMenuItem.Click += new System.EventHandler(this.datosToolStripMenuItem_Click);
            // 
            // TabControl
            // 
            this.TabControl.Controls.Add(this.TabDatos);
            this.TabControl.Controls.Add(this.TabIdx);
            this.TabControl.Location = new System.Drawing.Point(0, 27);
            this.TabControl.Name = "TabControl";
            this.TabControl.SelectedIndex = 0;
            this.TabControl.ShowToolTips = true;
            this.TabControl.Size = new System.Drawing.Size(973, 362);
            this.TabControl.TabIndex = 35;
            // 
            // TabDatos
            // 
            this.TabDatos.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.TabDatos.Controls.Add(this.button1);
            this.TabDatos.Controls.Add(this.dataGridView1);
            this.TabDatos.Controls.Add(this.bt_eliminaDato);
            this.TabDatos.Controls.Add(this.bt_modDato);
            this.TabDatos.Controls.Add(this.bt_nuevoDato);
            this.TabDatos.Controls.Add(this.dGV_AgregarDat);
            this.TabDatos.Controls.Add(this.label4);
            this.TabDatos.Controls.Add(this.cb_SelEnt);
            this.TabDatos.Location = new System.Drawing.Point(4, 22);
            this.TabDatos.Name = "TabDatos";
            this.TabDatos.Padding = new System.Windows.Forms.Padding(3);
            this.TabDatos.Size = new System.Drawing.Size(965, 336);
            this.TabDatos.TabIndex = 0;
            this.TabDatos.Text = "Datos";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(415, 82);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(438, 160);
            this.dataGridView1.TabIndex = 48;
            this.dataGridView1.SelectionChanged += new System.EventHandler(this.dataGridView1_SelectionChanged);
            // 
            // bt_eliminaDato
            // 
            this.bt_eliminaDato.Location = new System.Drawing.Point(664, 252);
            this.bt_eliminaDato.Name = "bt_eliminaDato";
            this.bt_eliminaDato.Size = new System.Drawing.Size(107, 25);
            this.bt_eliminaDato.TabIndex = 47;
            this.bt_eliminaDato.Text = "Elimina Dato";
            this.bt_eliminaDato.UseVisualStyleBackColor = true;
            this.bt_eliminaDato.Click += new System.EventHandler(this.bt_eliminaDato_Click);
            // 
            // bt_modDato
            // 
            this.bt_modDato.Location = new System.Drawing.Point(483, 252);
            this.bt_modDato.Name = "bt_modDato";
            this.bt_modDato.Size = new System.Drawing.Size(107, 25);
            this.bt_modDato.TabIndex = 46;
            this.bt_modDato.Text = "Modifica Dato";
            this.bt_modDato.UseVisualStyleBackColor = true;
            this.bt_modDato.Click += new System.EventHandler(this.bt_modDato_Click);
            // 
            // bt_nuevoDato
            // 
            this.bt_nuevoDato.Location = new System.Drawing.Point(100, 252);
            this.bt_nuevoDato.Name = "bt_nuevoDato";
            this.bt_nuevoDato.Size = new System.Drawing.Size(107, 31);
            this.bt_nuevoDato.TabIndex = 45;
            this.bt_nuevoDato.Text = "Agregar Dato";
            this.bt_nuevoDato.UseVisualStyleBackColor = true;
            this.bt_nuevoDato.Click += new System.EventHandler(this.bt_nuevoDato_Click);
            // 
            // dGV_AgregarDat
            // 
            this.dGV_AgregarDat.AllowUserToDeleteRows = false;
            this.dGV_AgregarDat.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dGV_AgregarDat.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Nombre_Atributo,
            this.Tipo,
            this.Dato});
            this.dGV_AgregarDat.Location = new System.Drawing.Point(31, 82);
            this.dGV_AgregarDat.Margin = new System.Windows.Forms.Padding(4, 3, 3, 3);
            this.dGV_AgregarDat.Name = "dGV_AgregarDat";
            this.dGV_AgregarDat.Size = new System.Drawing.Size(344, 164);
            this.dGV_AgregarDat.TabIndex = 44;
            // 
            // Nombre_Atributo
            // 
            this.Nombre_Atributo.HeaderText = "Nombre Atributo";
            this.Nombre_Atributo.Name = "Nombre_Atributo";
            // 
            // Tipo
            // 
            this.Tipo.HeaderText = "Tipo de dato";
            this.Tipo.Name = "Tipo";
            // 
            // Dato
            // 
            this.Dato.HeaderText = "Datos";
            this.Dato.Name = "Dato";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.DarkSlateBlue;
            this.label4.Location = new System.Drawing.Point(336, 36);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(98, 18);
            this.label4.TabIndex = 43;
            this.label4.Text = "Sel Entidad:";
            // 
            // cb_SelEnt
            // 
            this.cb_SelEnt.FormattingEnabled = true;
            this.cb_SelEnt.Location = new System.Drawing.Point(460, 33);
            this.cb_SelEnt.MaxLength = 35;
            this.cb_SelEnt.Name = "cb_SelEnt";
            this.cb_SelEnt.Size = new System.Drawing.Size(130, 21);
            this.cb_SelEnt.TabIndex = 42;
            this.cb_SelEnt.SelectedIndexChanged += new System.EventHandler(this.cb_SelEnt_SelectedIndexChanged);
            // 
            // TabIdx
            // 
            this.TabIdx.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.TabIdx.Controls.Add(this.dataGridView4);
            this.TabIdx.Controls.Add(this.label2);
            this.TabIdx.Controls.Add(this.dataGridView3);
            this.TabIdx.Controls.Add(this.label1);
            this.TabIdx.Controls.Add(this.dataGridView2);
            this.TabIdx.Location = new System.Drawing.Point(4, 22);
            this.TabIdx.Name = "TabIdx";
            this.TabIdx.Padding = new System.Windows.Forms.Padding(3);
            this.TabIdx.Size = new System.Drawing.Size(965, 336);
            this.TabIdx.TabIndex = 1;
            this.TabIdx.Text = "Indices";
            // 
            // dataGridView4
            // 
            this.dataGridView4.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView4.Location = new System.Drawing.Point(577, 43);
            this.dataGridView4.Name = "dataGridView4";
            this.dataGridView4.Size = new System.Drawing.Size(243, 263);
            this.dataGridView4.TabIndex = 47;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.DarkSlateBlue;
            this.label2.Location = new System.Drawing.Point(458, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(156, 18);
            this.label2.TabIndex = 46;
            this.label2.Text = "Indice Secundario 1";
            // 
            // dataGridView3
            // 
            this.dataGridView3.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView3.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ClaveS,
            this.DireccionLista});
            this.dataGridView3.Location = new System.Drawing.Point(317, 43);
            this.dataGridView3.Name = "dataGridView3";
            this.dataGridView3.Size = new System.Drawing.Size(243, 263);
            this.dataGridView3.TabIndex = 45;
            // 
            // ClaveS
            // 
            this.ClaveS.HeaderText = "Clave";
            this.ClaveS.Name = "ClaveS";
            // 
            // DireccionLista
            // 
            this.DireccionLista.HeaderText = "Dirección Lista";
            this.DireccionLista.Name = "DireccionLista";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.DarkSlateBlue;
            this.label1.Location = new System.Drawing.Point(73, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(121, 18);
            this.label1.TabIndex = 44;
            this.label1.Text = "Indice Primario";
            // 
            // dataGridView2
            // 
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Clave,
            this.Direccion});
            this.dataGridView2.Location = new System.Drawing.Point(8, 43);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.Size = new System.Drawing.Size(245, 263);
            this.dataGridView2.TabIndex = 0;
            // 
            // Clave
            // 
            this.Clave.HeaderText = "Clave";
            this.Clave.Name = "Clave";
            // 
            // Direccion
            // 
            this.Direccion.HeaderText = "Dirección de Datos";
            this.Direccion.Name = "Direccion";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(339, 255);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(107, 25);
            this.button1.TabIndex = 49;
            this.button1.Text = "Aceptar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Datos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(868, 381);
            this.Controls.Add(this.TabControl);
            this.Controls.Add(this.menuStrip1);
            this.Name = "Datos";
            this.Text = "Datos";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.TabControl.ResumeLayout(false);
            this.TabDatos.ResumeLayout(false);
            this.TabDatos.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dGV_AgregarDat)).EndInit();
            this.TabIdx.ResumeLayout(false);
            this.TabIdx.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem archivoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem crearToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem abrirToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem entidadesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem atributosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem datosToolStripMenuItem;
        private System.Windows.Forms.TabControl TabControl;
        private System.Windows.Forms.TabPage TabDatos;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button bt_eliminaDato;
        private System.Windows.Forms.Button bt_modDato;
        private System.Windows.Forms.Button bt_nuevoDato;
        private System.Windows.Forms.DataGridView dGV_AgregarDat;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nombre_Atributo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Tipo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Dato;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cb_SelEnt;
        private System.Windows.Forms.TabPage TabIdx;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dataGridView3;
        private System.Windows.Forms.DataGridViewTextBoxColumn ClaveS;
        private System.Windows.Forms.DataGridViewTextBoxColumn DireccionLista;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Clave;
        private System.Windows.Forms.DataGridViewTextBoxColumn Direccion;
        private System.Windows.Forms.DataGridView dataGridView4;
        private System.Windows.Forms.Button button1;
    }
}