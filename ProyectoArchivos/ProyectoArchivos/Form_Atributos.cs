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
    public partial class Form_Atributos : Form
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
        private long direccion, dirCab;
        private bool flagCab, flagSelE;
        private ArchivoBin archBB;
        private List<Entidad> entidadT;
        private int numRow;
        private List<String> atributosL;
        private List<Atributo> atribT;

        private void bt_nuevaEntidad_Click(object sender, EventArgs e)
        {

        }
        

        private void Form_Principal_Load(object sender, EventArgs e)
        {

        }
        
        
        private void dataGridView1_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
        }

        private void Form_Atributos_FormClosing(object sender, FormClosingEventArgs e)
        {
            //Application.Exit();
        }

        private void entidadesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Program.fore1.Show();
            this.Close();
        }

        private bool comparaNombre(String nombreS)
        {
            bool band = true;
            for (int i = 0; i < atributosL.Count(); i++)
            {
                if (nombreS == atributosL[i])
                {
                    band = false;
                    if (i == numRow)
                    {
                        band = true;
                    }
                    i = atributosL.Count + 1;
                }
            }


            return band;
        }

        private void bt_nuevoAtrib_Click(object sender, EventArgs e)
        {

            String nameAuxiliar = tb_nombreAtrib.Text;
            String name = nameAuxiliar.ToLower();
            int nTab = 0;
            for (int j = 0; j < entidadT.Count; j++)
            {
                if (entidadActual == entidadT[j].NombreEnt.Replace("\0", " ").Replace(" ", ""))
                {
                    nTab = j;
                    j = entidadT.Count + 1;
                }
            }
            if (!entidadT[nTab].Datos )
            {
                if (!entidadT[nTab].Primaria|| Cb_Index.Text == "0(Sin_tipo)" || Cb_Index.Text == "1(Clave_de_busqueda)" || Cb_Index.Text == "3(Indice_secundario)")
                {
                    if (!entidadT[nTab].Cve_busqueda || Cb_Index.Text == "0(Sin_tipo)" || Cb_Index.Text == "2(Indice_primario)" || Cb_Index.Text == "3(Indice_secundario)")
                    {
                        if (!entidadT[nTab].Secundaria || Cb_Index.Text == "0(Sin_tipo)" || Cb_Index.Text == "2(Indice_primario)" || Cb_Index.Text == "1(Clave_de_busqueda)")
                        {
                            if (flagSelE == true)
                            {

                                if (comparaNombre(name) == true)
                                {
                                    string tipoS = Cb_Dato.Text;
                                    string tipo = Cb_Index.Text;
                                    int atlong = 0;
                                    int atIndice = 0;
                                    switch (Cb_Index.Text)
                                    {
                                        case "0(Sin_tipo)":
                                            atIndice = 0;
                                            break;
                                        case "1(Clave_de_busqueda)":
                                            atIndice = 1;
                                            entidadT[nTab].Cve_busqueda = true;
                                            break;
                                        case "2(Indice_primario)":
                                            atIndice = 2;
                                            entidadT[nTab].Primaria = true;
                                            break;
                                        case "3(Indice_secundario)":
                                            entidadT[nTab].Secundaria = true;
                                            atIndice = 3;
                                            break;
                                        case "4(Arbol_primario)":
                                            atIndice = 4;
                                            break;
                                        case "5(Arbol_secundario)":
                                            atIndice = 5;
                                            break;

                                    }

                                    
                                    char tipoo = ' ';

                                    switch (Cb_Dato.Text)
                                    {
                                        case "Entero":
                                            tipoo = 'e';
                                            atlong = 4;
                                            break;

                                        case "Cadena":
                                            tipoo = 'c';
                                            atlong = Convert.ToInt32(tb_Long.Text);
                                            break;
                                    }
                                    atributosL.Add(name);
                                    Atributo auxAt = new Atributo(name, tipoo, atlong, atIndice, Convert.ToInt32(ArchivoBin.dir), -1, -1);
                                    //dataGridView1.Rows.Add(auxAt.IdHex, name, tipoo, atlong, ArchivoBin.dir, atIndice, -1, -1);
                                    if(atIndice == 2)
                                    {
                                        String creaDatos = carpeta + @"\" + auxAt.IdHex + ".idx";
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
                                        }
                                    }

                                    if (atributosL.Count > 1)
                                    {
                                        atActual.DirSigAt = ArchivoBin.dir;
                                        archBB.escribeAtributo(atActual.DirAt, atActual);
                                    }
                                    else
                                    {
                                        entidadT[nTab].DirPriAt = ArchivoBin.dir;
                                        archBB.escribeEntidad(entidadT[nTab].DirEnt, entidadT[nTab]);
                                    }
                                    atActual = auxAt;
                                    archBB.escribeAtributo(atActual.DirAt, atActual);
                                    atribT.Add(atActual);
                                    ArchivoBin.dir += 73;
                                    actualizaTablas();
                                    comboBox1.Items.Add(atActual.NombreAt);
                                    tb_nombreAtrib.Clear();
                                    tb_Long.Clear();
                                    Cb_Dato.Text = "";
                                    Cb_Index.Text = "";
                                }

                                else
                                {
                                    MessageBox.Show("El atributo ya existe");
                                }
                            }

                            else
                            {
                                MessageBox.Show("No se ha seleccionado Entidad");
                            }
                        }
                        else
                            MessageBox.Show("Ya tiene un indice secundario");
                    }
                    else
                        MessageBox.Show("Ya tiene una Clave de busqueda");
                }
                else
                    MessageBox.Show("Ya tiene un indice primario");
            }
            else
                MessageBox.Show("No se pueden crear mas atributos ya existen datos");

        }

        private void Cb_Dato_TextChanged(object sender, EventArgs e)
        {
            if(Cb_Dato.Text == "Entero")
            {
                tb_Long.Text = "4";
            }
        }

        private void cb_SelEnt_SelectedIndexChanged(object sender, EventArgs e)
        {
            flagSelE = true;
            atributosL.Clear();
            atActual = null;
            comboBox1.Items.Clear();
            entidadActual = cb_SelEnt.Text;
            for (int i = 0; i < entidadT.Count; i++)
            {
                string s = entidadT[i].NombreEnt.Replace("\0", " ").Replace(" ", "");
                entidadActual = s;
                if (s == cb_SelEnt.Text.Replace(" ", ""))
                {
                    atribT = archBB.leerAts(entidadT[i].DirPriAt);
                    break;
                }
            }

            if (atribT.Count != 0)
                atActual = atribT[atribT.Count - 1];
            for(int i = 0; i < atribT.Count; i++){
                comboBox1.Items.Add(atribT[i].NombreAt);
            }
            actualizaTablas();
        }
        private Atributo obtieneAtributo(int row)
        {
            String hex = dataGridView1.Rows[row].Cells[0].Value.ToString();
            String name = dataGridView1.Rows[row].Cells[1].Value.ToString();
            char tipo = dataGridView1.Rows[row].Cells[2].Value.ToString()[0];
            int atlong = Convert.ToInt32(dataGridView1.Rows[row].Cells[3].Value.ToString());
            int atIndice = Convert.ToInt32(dataGridView1.Rows[row].Cells[4].Value.ToString());
            int dire = Convert.ToInt32(dataGridView1.Rows[row].Cells[5].Value.ToString());
            int direId = Convert.ToInt32(dataGridView1.Rows[row].Cells[6].Value.ToString());
            int direSig = Convert.ToInt32(dataGridView1.Rows[row].Cells[7].Value.ToString());

            Atributo nuevoAtrib = new Atributo(hex,name, tipo, atlong, atIndice, dire, direId, direSig);

            return nuevoAtrib;
        }
        private void bt_eliminaEntidad_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text  != "")
            {
                DialogResult boton = MessageBox.Show("¿Realmende desea eliminar el atributo?", "Alerta", MessageBoxButtons.OKCancel);
                if (boton == DialogResult.OK)
                {
                    Atributo auxAt1, auxAt2;
                    auxAt1 = new Atributo();
                    auxAt2 = new Atributo();
                    auxAt1 = obtieneAtributo(numRow);

                    int nTab = 0;
                    for (int j = 0; j < entidadT.Count; j++)
                    {
                        if (entidadActual == entidadT[j].NombreEnt.Replace("\0", "").Replace(" ", ""))
                        {
                            nTab = j;
                            j = entidadT.Count + 1;
                        }
                    }
                    //if (auxAt1.getTipoIdxAt() == 1) tablasT[nTab].setPrimaria(false);

                    if (numRow > 0)
                    {
                        auxAt2 = obtieneAtributo(numRow - 1);
                        auxAt2.DirSigAt= auxAt1.DirSigAt; //Se cambia dirección ya que se eliminará
                        if (auxAt1 == atActual)
                        {
                            atActual = auxAt2;
                        }

                        archBB.escribeAtributo(auxAt2.DirAt, auxAt2);
                        dataGridView1.Rows[numRow - 1].Cells[7].Value = auxAt2.DirSigAt;
                    }

                    else
                    {
                        if (dataGridView1.Rows.Count >= 2)
                        {
                            Int64 dirAtat = Convert.ToInt64(dataGridView1.Rows[numRow + 1].Cells[5].Value.ToString());
                            entidadT[nTab].DirPriAt =dirAtat;
                            archBB.escribeEntidad(entidadT[nTab].DirEnt, entidadT[nTab]);
                        }
                        else
                        {
                            long aux = -1;
                            entidadT[nTab].DirPriAt =aux;
                            archBB.escribeEntidad(entidadT[nTab].DirEnt, entidadT[nTab]);
                        }
                    }

                    atribT.RemoveAt(numRow);
                    comboBox1.Items.RemoveAt(numRow);
                    atributosL.RemoveAt(numRow);
                    dataGridView1.Rows.RemoveAt(numRow);
                    numRow = -1;
                    comboBox1.Text = "";
                    MessageBox.Show("Atributo eliminado");
                }
                else
                {
                    MessageBox.Show("Se conserva atributo");
                }
            }
            else
            {
                MessageBox.Show("Seleccione atributo a eliminar");
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < atribT.Count; i++)
            {
                if (atribT[i].NombreAt.Replace(" ","") == comboBox1.Text.Replace(" ",""))
                {
                    numRow = i;
                    break;
                }
            }
        }

        private void bt_modificaEntidad_Click(object sender, EventArgs e)
        {

            if (comboBox1.Text.ToString() != "")
            {
                Atributo aux = obtieneAtributo(numRow);
                tb_nombreAtrib.Text = comboBox1.Text.ToString();
                switch (aux.TipoAt.ToString())
                {
                    case "e":
                        Cb_Dato.Text = "Entero";
                        tb_Long.Text = "4";
                        break;
                    case "c":
                        Cb_Dato.Text = "Cadena";
                        tb_Long.Text = aux.LongAt.ToString();
                        break;

                }

                switch (aux.TipoIdxAt)
                {
                    case 0:
                        Cb_Index.Text = "0(Sin_tipo)";
                        break;
                    case 1:
                        Cb_Index.Text = "1(Clave_de_busqueda)";
                        break;
                    case 2:
                        Cb_Index.Text = "2(Indice_primario)";
                        break;
                    case 3:
                        Cb_Index.Text = "3(Indice_secundario)";
                        break;
                    case 4:
                        Cb_Index.Text = "4(Arbol_primario)";
                        break;
                    case 5:
                        Cb_Index.Text = "5(Arbol_secundario)";
                        break;
                }
                button1.Visible = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
                //MessageBox.Show("Atributo eliminado");
                String nameAuxiliar = tb_nombreAtrib.Text;
                String name = nameAuxiliar.ToLower();
            if (comparaNombre(name) == true)
            {
                char tipoS = ' ';
                string tipo = Cb_Index.Text;
                int atlong = 0;
                int atIndice = 0;
                switch (Cb_Index.Text)
                {
                    case "0(Sin_tipo)":
                        atIndice = 0;
                        break;
                    case "1(Clave_de_busqueda)":
                        atIndice = 1;
                        break;
                    case "2(Indice_primario)":
                        atIndice = 2;
                        break;
                    case "3(Indice_secundario)":
                        atIndice = 3;
                        break;
                    case "4(Arbol_primario)":
                        atIndice = 4;
                        break;
                    case "5(Arbol_secundario)":
                        atIndice = 5;
                        break;

                }
                int nTab = 0;
                for (int j = 0; j < entidadT.Count; j++)
                {
                    if (entidadActual == entidadT[j].NombreEnt.Replace("\0", " ").Replace(" ", ""))
                    {
                        nTab = j;
                        j = entidadT.Count + 1;
                    }
                }
                switch (Cb_Dato.Text)
                {
                    case "Entero":
                        atribT[nTab].TipoAt = 'e';
                        break;
                    case "Cadena":
                        atribT[nTab].TipoAt = 'c';
                        break;

                }
                
                atribT[nTab].NombreAt = tb_nombreAtrib.Text.TrimEnd();
                
                atribT[nTab].LongAt = Convert.ToInt32(tb_Long.Text);
                atribT[nTab].TipoIdxAt = atIndice;
                archBB.escribeAtributo(atribT[nTab].DirAt, atribT[nTab]);
                actualizaTablas();
                tb_nombreAtrib.Text = "";
                Cb_Dato.Text = "";
                Cb_Index.Text = "";
                tb_Long.Text = "";
            }
            else
            {
                MessageBox.Show("El atributo ya existe");
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void abrirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openDialog;
            openDialog = new OpenFileDialog();


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
                    //lb_cab.Text = entidadT[0].DirEnt.ToString();
                    actualizaTablas();
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

        //string carpeta;
        //inicialización de componentes
        public Form_Atributos(List<Entidad> entidades, ArchivoBin nuevo,string nombre,ref long dir,string carp)
        {
            InitializeComponent();
            atribT = new List<Atributo>();
            carpetaE = false;
            carpeta = carp;
            diccionario = "Dic.dd";
            entidadA = entidadActual = "";
            dirCab = -1;
            flagCab = false;
            archBB = nuevo;
            entidadT = entidades;
            atributosL = new List<String>();
            atActual = new Atributo();
            flagSelE = false;
            numRow = -1;
            for(int i = 0; i<entidadT.Count; i++)
            {
                cb_SelEnt.Items.Add( entidadT[i].NombreEnt);
            }
            tb_Archivo.Text = nombre;

        }

        //Actualiza la datagridview
        private void actualizaTablas()
        {
            dataGridView1.Rows.Clear();
            for (int i = 0; i < atribT.Count; i++)
            {
                Atributo auxE = atribT[i];
                atributosL.Add(auxE.NombreAt);
                dataGridView1.Rows.Add(auxE.IdHex, auxE.NombreAt, auxE.TipoAt, auxE.LongAt, auxE.TipoIdxAt,auxE.DirAt, auxE.DirIndice,auxE.DirSigAt);
            }
        }

        //modifica la cabecera del archivo
       

    }
}

// Icons made by="https://www.flaticon.es/autores/freepik" title="Freepik" from ="https://www.flaticon.es/"
