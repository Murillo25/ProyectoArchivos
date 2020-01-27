using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoArchivos
{
    public partial class Form_Principal : Form
    {
        //Rutas de las carpetas
        private String carpeta, carTablas, entidadA, entidadActual;
        //Bandera de que se ha creado/leído la BD
        private bool carpetaE;
        private String diccionario;
        //Guarda cabecera de dato actual
        private long cabecera;
        //Atributos en memoria
        private Atributo atActual;
        
        public long direccion, dirCab;
        private bool flagCab, flagSelE;
        private ArchivoBin archBB;
        public List<Entidad> entidadT;
        private int numRow;
        private List<String> atributosL;
        
        private void bt_nuevaEntidad_Click(object sender, EventArgs e)
        {
            if (carpetaE == true)
            {
                if (tb_nombreEnt.Text != "")
                {
                    crearEntidad();
                }
                else
                {
                    MessageBox.Show("Ingrese nombre para la entidad");
                }
            }
            else
            {
                MessageBox.Show("Primero debe crear o cargar un Diccionario de datos");
            }
        }

        private void crearEntidad()
        {
            flagSelE = false;
            string auxtablaa = tb_nombreEnt.Text;
            entidadA = auxtablaa.ToLower(); ;
            
            Entidad tentidad = new Entidad(entidadA, ArchivoBin.dir, -1, -1, -1);
            entidadT.Add(tentidad);
            String creaDatos = carpeta + @"\" + tentidad.IdHex + ".dat";
            if (File.Exists(@creaDatos))
                {
                    MessageBox.Show("La Entidad existe");
                }
                else
                {
                    using (FileStream archivo = new FileStream(creaDatos, FileMode.Create))
                    {
                        archivo.Close();
                    }
                    

                    if (flagCab == false)
                    {
                        dirCab = ArchivoBin.dir;
                        escribeCabecera(ArchivoBin.dir);
                        flagCab = true;
                    }

                    archBB.escribeEntidad(ArchivoBin.dir, tentidad);
                    cb_SelEnt.Items.Add(tb_nombreEnt.Text);
                    ordenaEntidades();
                    MessageBox.Show("Entidad creada");
                    actualizaTablas();
                    ArchivoBin.dir += 72;
                    
                }

        }

        private void ordenaEntidades()
        {
            List<String> entidadN = new List<String>();
            for (int l = 0; l < entidadT.Count; l++)
            {
                entidadN.Add(entidadT[l].NombreEnt);
            }


            int antEnt = -1;
            List<String> ss = new List<String>(entidadN);
            ss.Sort();

            for (int i = 0; i < ss.Count; i++)
            {
                for (int j = 0; j < entidadT.Count; j++)
                {
                    if (ss[i].Replace(" ","").Replace("\0","") == entidadT[j].NombreEnt.Replace(" ", "").Replace("\0", ""))
                    {
                        
                        if (i == 0)
                        {
                            dirCab = entidadT[j].DirEnt;
                            lb_cab.Text = dirCab.ToString();
                            escribeCabecera(dirCab);
                            //antEnt = 0;
                        }
                        else
                        {
                            entidadT[antEnt].DirSigEnt = entidadT[j].DirEnt;
                        }
                        antEnt = j;
                        j = entidadT.Count + 1;
                    }
                }
            }

            for (int j = 0; j < entidadT.Count; j++)
            {
                if(ss[ss.Count-1].Replace(" ", "").Replace("\0", "") == entidadT[j].NombreEnt.Replace(" ", "").Replace("\0", ""))
                {
                    entidadT[j].DirSigEnt = -1;
                    break;
                }

            }

            for (int k = 0; k < entidadT.Count; k++)
            {
                archBB.escribeEntidad(entidadT[k].DirEnt, entidadT[k]);
            }
        }

        private void bt_eliminaEntidad_Click(object sender, EventArgs e)
        {
            entidadActual = cb_SelEnt.Text.ToString();
            if (entidadActual != "")
            {
                DialogResult boton = MessageBox.Show("¿Realmende desea eliminar la entidad?", "Alerta", MessageBoxButtons.OKCancel);
                if (boton == DialogResult.OK)
                {
                    String del = entidadActual.TrimEnd();
                    int nItems = 0, nTab = 0; ;

                    for (int j = 0; j < entidadT.Count; j++)
                    {
                        if (entidadActual.Replace(" ","") == entidadT[j].NombreEnt.Replace(" ", "").Replace("\0",""))
                        {
                            nTab = j;
                            j = entidadT.Count + 1;
                        }
                    }
                    Int64 borra = entidadT[nTab].DirEnt;
                    for(int i = 0; i < entidadT.Count; i++)
                    {
                        if(entidadT[i].DirSigEnt == borra)
                        {
                            entidadT[i].DirSigEnt = -1;
                            break;
                        }
                    } 
                    entidadT.RemoveAt(nTab);
                    dataGridView1.Rows.RemoveAt(nTab);

                    for (int i = 0; i < cb_SelEnt.Items.Count; i++)
                    {
                        if (cb_SelEnt.Items[i].ToString() == entidadActual)
                        {
                            nItems = i;
                        }
                    }
                    cb_SelEnt.Items.RemoveAt(nItems);
                    ordenaEntidades();
                    actualizaTablas();
                    entidadActual += ".dat";
                    String borraDatos = carpeta + @"\" + entidadActual;
                    File.Delete(borraDatos);
                    MessageBox.Show("Se eliminó entidad");
                    entidadActual = "";
                    cb_SelEnt.Text = "";
                }
                else
                {
                    MessageBox.Show("Se conserva entidad");
                }
            }
            else
            {
                MessageBox.Show("No ha seleccionado una entidad");
            }
        }

        private void Form_Principal_Load(object sender, EventArgs e)
        {

        }

        int modifi = 0;
        private void bt_modificaEntidad_Click(object sender, EventArgs e)
        {
            entidadActual = cb_SelEnt.Text.ToString().TrimEnd();
            
            if (entidadActual != "")
            {
                tb_nombreEnt.Text = entidadActual;
                button1.Visible = true;
                for (int j = 0; j < entidadT.Count; j++)
                {
                    if (entidadActual.Replace(" ", "") == entidadT[j].NombreEnt.Replace("\0", "").Replace(" ", ""))
                    {
                        modifi = j;
                        j = entidadT.Count + 1;
                    }
                }
                
            }else
            {
                MessageBox.Show("Primero debe seleccionar una entidad");
            }
            
        }

        private void dataGridView1_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            if(entidadT.Count == 0)
            {
                lb_cab.Text = "-1";
            }
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            button1.Visible = false;
            bt_eliminaEntidad.Visible = true;
            bt_modificaEntidad.Visible = true;
            bt_nuevaEntidad.Visible = true;
                //Insercción
            String creaDatos = carpeta + @"\" + tb_nombreEnt.Text + ".dat";

                if (File.Exists(@creaDatos))
                {
                    MessageBox.Show("La Entidad existe");
                }
                else
                {
                    using (FileStream archivo = new FileStream(creaDatos, FileMode.Create))
                    {
                        archivo.Close();
                    }
                    entidadT[modifi].NombreEnt = tb_nombreEnt.Text.TrimEnd();
                    entidadT[modifi].DirDatos = -1;
                    archBB.escribeEntidad(entidadT[modifi].DirEnt, entidadT[modifi]);
                    cb_SelEnt.Items.Add(tb_nombreEnt.Text);
                    ordenaEntidades();
                    MessageBox.Show("Entidad modificada");
                    actualizaTablas();
                }
        }

        private void atributosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form_Atributos Prueba = new Form_Atributos(entidadT,archBB,tb_Archivo.Text,ref direccion,carpeta);
            timer1.Start();
            this.Hide();
            Prueba.Show();
        }

        private void cb_SelEnt_SelectedIndexChanged(object sender, EventArgs e)
        {
            entidadActual = cb_SelEnt.Text.Replace(" ", "");
            

        }

        private void reiniciarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }

        private void Form_Principal_VisibleChanged(object sender, EventArgs e)
        {
            actualizaTablas();
        }

        private void Form_Principal_ChangeUICues(object sender, UICuesEventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            archBB.leeArchivo();
            entidadT = archBB.Entidades;
        }

        private void Form_Principal_Activated(object sender, EventArgs e)
        {
           
        }

        private void Form_Principal_Enter(object sender, EventArgs e)
        {

        }

        private void Form_Principal_Deactivate(object sender, EventArgs e)
        {
           /* cb_SelEnt.Items.Clear();
            dataGridView1.Rows.Clear();

            //String aux = openDialog.FileName;
            //carpeta = Path.GetDirectoryName(@aux);

            //carTablas = carpeta + @"\" + diccionario;
            archBB.NombresArch = carTablas;
            tb_Archivo.Text = carpeta;

            if (archBB.leeArchivo() == true)
            {
                entidadT = new List<Entidad>();
                entidadT = archBB.Entidades;
                lb_cab.Text = entidadT[0].DirEnt.ToString();
                actualizaTablas();
                carpetaE = true;
                //MessageBox.Show("Lectura completada");
                ArchivoBin.dir = archBB.PosMayor;
            }
            */
        }

        private void datosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Datos nuevo = new Datos(entidadT, archBB,carpeta);
            this.Hide();
            nuevo.Show();
        }

        private void abrirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openDialog;
            openDialog = new OpenFileDialog();
            bt_eliminaEntidad.Enabled = true;
            bt_modificaEntidad.Enabled = true;
            bt_nuevaEntidad.Enabled = true;
            if (openDialog.ShowDialog() == DialogResult.OK)
            {
                cb_SelEnt.Items.Clear();
                dataGridView1.Rows.Clear();

                String aux = openDialog.FileName;
                carpeta = Path.GetDirectoryName(@aux);

                carTablas = carpeta + @"\" + diccionario;
                archBB.NombresArch = carTablas;
                tb_Archivo.Text = carpeta;

                if (archBB.leeArchivo() == true)
                {
                    entidadT = new List<Entidad>();
                    entidadT = archBB.Entidades;
                    FileInfo nuevo = new FileInfo(archBB.NombresArch);
                    if (nuevo.Length == 8)
                    {
                        lb_cab.Text = "-1";
                    }
                    else
                    {
                        lb_cab.Text = entidadT[0].DirEnt.ToString();
                        actualizaTablas();
                    }
                    carpetaE = true;
                    MessageBox.Show("Lectura completada");
                    ArchivoBin.dir = archBB.PosMayor;
                }

                else
                {
                    MessageBox.Show("Hubo un error al leer");
                }

            }
        }

        private void crearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bt_eliminaEntidad.Enabled = true;
            bt_modificaEntidad.Enabled = true;
            bt_nuevaEntidad.Enabled = true;
            //Obtener ruta y nombre para la carpeta principal
            SaveFileDialog saveAsDialog;
            saveAsDialog = new SaveFileDialog();
            if (saveAsDialog.ShowDialog() != DialogResult.OK) return;
            carpeta = saveAsDialog.FileName;
            tb_Archivo.Text = carpeta;
            cb_SelEnt.Items.Clear();
            dataGridView1.Rows.Clear();

            try
            {
                if (Directory.Exists(carpeta))
                {
                    MessageBox.Show("La carpeta existe");
                }
                else
                {
                    Directory.CreateDirectory(@carpeta);
                    //Crear archivos dentro de la carpeta
                    carTablas = carpeta + @"\" + diccionario;
                    long auxL = -1;
                    using (FileStream archivo = new FileStream(carTablas, FileMode.Create))
                    {
                        archivo.Position = 0;
                        using (BinaryWriter bw = new BinaryWriter(archivo))
                        {
                            bw.Write(auxL);
                        }
                        archivo.Close();
                    }
                    archBB.NombresArch = carTablas;
                    carpetaE = true;
                    MessageBox.Show("Carpeta creada");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error\n" + ex.Message);
            }
        }

        //inicialización de componentes
        public Form_Principal()
        {
            InitializeComponent();

            carpetaE = false;
            ArchivoBin.dir = 0;
            diccionario = "Dic.dd";
            entidadA = entidadActual = "";
            ArchivoBin.dir = 8;
            dirCab = -1;
            flagCab = false;
            archBB = new ArchivoBin();
            entidadT = new List<Entidad>();
            atributosL = new List<String>();
            atActual = new Atributo();
            flagSelE = false;
            numRow = -1;
            tb_Archivo.Text = "-1";
            timer1.Interval = 20000;
        }

        //Actualiza la datagridview
        public void actualizaTablas()
        {
            dataGridView1.Rows.Clear();
            cb_SelEnt.Items.Clear();
            for (int i = 0; i < entidadT.Count; i++)
            {
                Entidad auxE = entidadT[i];
                cb_SelEnt.Items.Add(auxE.NombreEnt);
                dataGridView1.Rows.Add(auxE.IdHex, auxE.NombreEnt, auxE.DirEnt, auxE.DirPriAt, auxE.DirDatos, auxE.DirSigEnt);
            }
        }

        //modifica la cabecera del archivo
        public void escribeCabecera(Int64 dire)
        {

            using (FileStream archivo = new FileStream(carTablas, FileMode.Open))
            {
                archivo.Position = 0;
                using (BinaryWriter bw = new BinaryWriter(archivo))
                {
                    bw.Write(dire);
                }
            }

        }

    }
}

// Icons made by="https://www.flaticon.es/autores/freepik" title="Freepik" from ="https://www.flaticon.es/"
