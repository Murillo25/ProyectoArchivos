using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoArchivos
{
    public partial class Datos : Form
    {
        public Datos(List<Entidad> Entidades, ArchivoBin dicionario)
        {
            InitializeComponent();
        }

        private void entidadesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Program.fore1.Show();
            this.Close();
        }
    }
}
