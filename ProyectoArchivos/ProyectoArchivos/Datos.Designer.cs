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
            this.label4 = new System.Windows.Forms.Label();
            this.cb_SelEnt = new System.Windows.Forms.ComboBox();
            this.dGV_AgregarDat = new System.Windows.Forms.DataGridView();
            this.Nombre_Atributo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Tipo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Dato = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bt_eliminaDato = new System.Windows.Forms.Button();
            this.bt_modDato = new System.Windows.Forms.Button();
            this.bt_nuevoDato = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dGV_AgregarDat)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
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
            this.menuStrip1.Size = new System.Drawing.Size(965, 24);
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
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.DarkSlateBlue;
            this.label4.Location = new System.Drawing.Point(377, 44);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(98, 18);
            this.label4.TabIndex = 36;
            this.label4.Text = "Sel Entidad:";
            // 
            // cb_SelEnt
            // 
            this.cb_SelEnt.FormattingEnabled = true;
            this.cb_SelEnt.Location = new System.Drawing.Point(501, 41);
            this.cb_SelEnt.MaxLength = 35;
            this.cb_SelEnt.Name = "cb_SelEnt";
            this.cb_SelEnt.Size = new System.Drawing.Size(130, 21);
            this.cb_SelEnt.TabIndex = 35;
            // 
            // dGV_AgregarDat
            // 
            this.dGV_AgregarDat.AllowUserToDeleteRows = false;
            this.dGV_AgregarDat.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dGV_AgregarDat.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Nombre_Atributo,
            this.Tipo,
            this.Dato});
            this.dGV_AgregarDat.Location = new System.Drawing.Point(23, 99);
            this.dGV_AgregarDat.Margin = new System.Windows.Forms.Padding(4, 3, 3, 3);
            this.dGV_AgregarDat.Name = "dGV_AgregarDat";
            this.dGV_AgregarDat.Size = new System.Drawing.Size(344, 164);
            this.dGV_AgregarDat.TabIndex = 37;
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
            // bt_eliminaDato
            // 
            this.bt_eliminaDato.Location = new System.Drawing.Point(761, 299);
            this.bt_eliminaDato.Name = "bt_eliminaDato";
            this.bt_eliminaDato.Size = new System.Drawing.Size(107, 31);
            this.bt_eliminaDato.TabIndex = 40;
            this.bt_eliminaDato.Text = "Elimina Dato";
            this.bt_eliminaDato.UseVisualStyleBackColor = true;
            // 
            // bt_modDato
            // 
            this.bt_modDato.Location = new System.Drawing.Point(568, 299);
            this.bt_modDato.Name = "bt_modDato";
            this.bt_modDato.Size = new System.Drawing.Size(107, 31);
            this.bt_modDato.TabIndex = 39;
            this.bt_modDato.Text = "Modifica Dato";
            this.bt_modDato.UseVisualStyleBackColor = true;
            // 
            // bt_nuevoDato
            // 
            this.bt_nuevoDato.Location = new System.Drawing.Point(147, 269);
            this.bt_nuevoDato.Name = "bt_nuevoDato";
            this.bt_nuevoDato.Size = new System.Drawing.Size(107, 31);
            this.bt_nuevoDato.TabIndex = 38;
            this.bt_nuevoDato.Text = "Agregar Dato";
            this.bt_nuevoDato.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(433, 85);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(515, 201);
            this.dataGridView1.TabIndex = 41;
            // 
            // Datos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(965, 342);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.bt_eliminaDato);
            this.Controls.Add(this.bt_modDato);
            this.Controls.Add(this.bt_nuevoDato);
            this.Controls.Add(this.dGV_AgregarDat);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cb_SelEnt);
            this.Controls.Add(this.menuStrip1);
            this.Name = "Datos";
            this.Text = "Datos";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dGV_AgregarDat)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
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
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cb_SelEnt;
        private System.Windows.Forms.DataGridView dGV_AgregarDat;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nombre_Atributo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Tipo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Dato;
        private System.Windows.Forms.Button bt_eliminaDato;
        private System.Windows.Forms.Button bt_modDato;
        private System.Windows.Forms.Button bt_nuevoDato;
        private System.Windows.Forms.DataGridView dataGridView1;
    }
}