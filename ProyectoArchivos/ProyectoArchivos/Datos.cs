﻿using System;
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
    public partial class Datos : Form
    {
        private List<Entidad> entidades;
        private archivoDatos archDat;
        private ArchivoBin dic;
        private Entidad selEntidad;
        private String ruta, carpeta;
        private List<List<string>> todosDatos;
        private List<Atributo> atributos;
        private ArchIndiceSec archidxS;
        private ArchivoIndicePri archIdxP;
        private ArboolB_ ArbolPri;
        private long dirPrimDat;
        private int rowIdx;
        bool clave;
        int campocve;

        public Datos(List<Entidad> Entidades, ArchivoBin dicionario, String car)
        {
            InitializeComponent();
            entidades = new List<Entidad>(Entidades);
            dic = dicionario;
            for (int i = 0; i < entidades.Count; i++)
            {
                cb_SelEnt.Items.Add(entidades[i].NombreEnt);
            }
            carpeta = car;

        }
        private void entidadesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Program.fore1.Show();
            this.Close();
        }

        public void ordena()
        {
            List<string> aux = new List<string>();
            for (int i = 0; i < todosDatos.Count; i++)
            {
                aux.Add(todosDatos[i][campocve].Replace("\0",""));
            }
            int antDat = -1;
            aux.Sort();
            if (clave)
            {
                for (int i = 0; i < aux.Count; i++)
                {
                    for (int j = 0; j < todosDatos.Count; j++)
                    {
                        if (aux[i].Replace("\0", "") == todosDatos[j][campocve].Replace("\0", ""))
                        {
                            if (i == 0)
                            {
                                entidades[sele].DirDatos = Convert.ToInt64(todosDatos[j][0]);
                                dic.escribeEntidad(entidades[sele].DirEnt, entidades[sele]);
                            }
                            else
                            {
                                todosDatos[antDat][todosDatos[antDat].Count-1] = todosDatos[j][0];
                            }
                            antDat = j;
                            j = todosDatos.Count + 1;
                        }
                    }
                }

               for(int i = 0; i < aux.Count; i++)
                {
                    if(aux[aux.Count-1].Replace("\0","") == todosDatos[i][campocve].Replace("\0", ""))
                    {
                        todosDatos[i][todosDatos[i].Count - 1] = "-1";
                        break;
                    }
                }

            }
            else
            {
                for (int j = 0; j < todosDatos.Count; j++)
                {
                    if(todosDatos.Count -1 == j)
                    {
                        todosDatos[j][todosDatos[j].Count - 1] = "-1";
                        break;
                    }else
                    {
                        todosDatos[j][todosDatos[j].Count - 1] = todosDatos[j+1][0];
                    }
                }
            }
            sobreEscribe();
        }

        public void sobreEscribe()
        {
            for (int j = 0; j < todosDatos.Count; j++)
            {
                archDat.scribeDato(Convert.ToInt64(todosDatos[j][0]), todosDatos[j]);
            }
        }
        public void last()
        {
            if(todosDatos.Count != 0)
                archivoDatos.dir = Convert.ToInt64(todosDatos[todosDatos.Count - 1][0]) + archDat.Longitudtotal;
        }
        public bool borrarDat()
        {
            if (selEntidad.DirDatos != -1)
                return false;
            return true;
        }
        public void llenadgvDatosEstatica()
        {
            dataGridView1.Columns.Add("DirDato", "Direccion Dato");
            for(int i = 0; i < atributos.Count; i++)
            {
                dataGridView1.Columns.Add(atributos[i].NombreAt, atributos[i].NombreAt);
            }
            dataGridView1.Columns.Add("DirSigDato", "Direccion Siguiente Dato");
        }

        int sele;
        public void buscacve()
        {
            for(int i = 0; i < atributos.Count; i++)
            {
                if(atributos[i].TipoIdxAt == 1)
                {
                    campocve = i+1;
                    clave = true;
                    break;
                }
            }
           
        }
        bool idxP;
        int campoidx;
        public void buscaidxP()
        {
            for (int i = 0; i < atributos.Count; i++)
            {
                if (atributos[i].TipoIdxAt == 2)
                {
                    campoidx = i + 1;
                    idxP = true;
                    break;
                }
            }

        }

        public void buscaidxS()
        {
            for (int i = 0; i < atributos.Count; i++)
            {
                if (atributos[i].TipoIdxAt == 3)
                {
                    campoidxS = i + 1;
                    idxS = true;
                    break;
                }
            }

        }
        int campoArbolS;
        bool arbolS;
        public void buscaArbolS()
        {
            for (int i = 0; i < atributos.Count; i++)
            {
                if (atributos[i].TipoIdxAt == 5)
                {
                    campoArbolS = i + 1;
                    arbolS = true;
                    break;
                }
            }

        }
        int campoArbPri;
        bool arbolpri;
        public void buscarArbolP()
        {
            for (int i = 0; i < atributos.Count; i++)
            {
                if (atributos[i].TipoIdxAt == 4)
                {
                    campoArbPri = i + 1;
                    arbolpri = true;
                    break;
                }
            }

        }

        public void actualizaDataidxp()
        {
            int i;
            dataGridView2.Rows.Clear();
            for(i = 0;i < archIdxP.Listaview1.Count-1; i+=2)
            {
                dataGridView2.Rows.Add(archIdxP.Listaview1[i],archIdxP.Listaview1[i+1]);
            }
            dataGridView2.Rows.Add(archIdxP.Listaview1[i - 1]);
        }

        public void actualizaDataidxs()
        {
            dataGridView4.Rows.Clear();
            dataGridView4.Columns.Clear();
            dataGridView3.Rows.Clear();
            int j = 0;
            for(int i = 0; i <archidxS.numBloqus; i++)
            {
                if (archidxS.bloque_vista[j + 1].Replace("\0","") == "-1")
                {
                    break;
                }
                dataGridView3.Rows.Add(archidxS.bloque_vista[j], archidxS.bloque_vista[j + 1]);
                j++;
                j++;
            }
            int sum;
            for(int i = 0; i < archidxS.cuentaDatosBP(); i++)
            {
                sum = (i + 1) * (2048);
                dataGridView4.Columns.Add(sum.ToString(), sum.ToString());
                for(j = 0; j < 256; j++)
                {
                    dataGridView4.Rows.Add();
                    dataGridView4.Rows[j].Cells[i].Value = archidxS.secundario_vista[i][j];
                }
            }
            
        }

        public void insertaidxP(string cve,string dir)
        {
            int pos = archIdxP.regresaPos(cve);
            archIdxP.escribeUno(cve, dir, pos);
            archIdxP.escribeLista();
        }
        


        private void cb_SelEnt_SelectedIndexChanged(object sender, EventArgs e)
        {
            dGV_AgregarDat.Rows.Clear();
            dataGridView1.Columns.Clear();
            for (int i = 0; i < entidades.Count; i++)
            {
                if (entidades[i].NombreEnt == cb_SelEnt.SelectedItem.ToString())
                {
                    sele = i;
                    selEntidad = entidades[i];
                    dirPrimDat = selEntidad.DirDatos;
                    ruta = carpeta + @"\" + selEntidad.IdHex + ".dat";
                    atributos = dic.leerAts(selEntidad.DirPriAt);
                    llenaDatagrid();
                    todosDatos = new List<List<string>>();
                    archDat = new archivoDatos(ruta, atributos);
                    llenadgvDatosEstatica();
                    break;
                }
            }
            buscacve();
            buscaidxP();
            buscaidxS();
            buscarArbolP();
            buscaArbolS();

            
            
            if (idxP)
            {
                ruta = carpeta + @"\" + atributos[campoidx - 1].IdHex + ".idx";
                archIdxP = new ArchivoIndicePri(ruta, atributos[campoidx - 1].LongAt);
                if (atributos[campoidx - 1].DirIndice == 0)
                {
                    archIdxP.leeLista();
                    archIdxP.update();
                    actualizaDataidxp();
                }
            }
            if (idxS)
            {
                ruta = carpeta + @"\" + atributos[campoidxS - 1].IdHex + ".idx";
                archidxS = new ArchIndiceSec(ruta, atributos[campoidxS - 1].LongAt);
                
                if(atributos[campoidxS-1].DirIndice == 0)
                {
                    archidxS.GenerabloquePrin();
                    archidxS.leeBP();
                    archidxS.leeSC();
                    actualizaDataidxs();
                }else
                {
                    File.Delete(archidxS.nombreArch);
                    using (FileStream archivo = new FileStream(archidxS.nombreArch, FileMode.Create))
                    {
                        archivo.Close();
                    }
                }
                
            }
            todosDatos.Clear();
            todosDatos = archDat.leeDatos(entidades[sele].DirDatos);
            if (arbolpri)
            {
                ruta = carpeta + @"\" + atributos[campoArbPri - 1].IdHex + ".idx";
                ArbolPri = new ArboolB_(5, ruta, atributos[campoArbPri - 1].LongAt);

                if (atributos[campoArbPri - 1].DirIndice != -1)
                {
                    ArbolPri.raiz = Convert.ToInt32(atributos[campoArbPri - 1].DirIndice);
                    ArbolPri.leeDatos(Convert.ToInt32(atributos[campoArbPri - 1].DirIndice), atributos[campoArbPri - 1].LongAt);
                    escribeArbolPrim();
                }
            }

            if (arbolS)
            {
                ruta = carpeta + @"\" + atributos[campoArbolS - 1].IdHex + ".idx";
                ArbolSec = new ArbolSec(5, ruta, atributos[campoArbolS - 1].LongAt);

                if (atributos[campoArbolS - 1].DirIndice != -1)
                {
                    ArbolSec.raiz = Convert.ToInt32(atributos[campoArbolS - 1].DirIndice);
                    ArbolSec.leeDatos(Convert.ToInt32(atributos[campoArbolS - 1].DirIndice), atributos[campoArbolS - 1].LongAt);
                    escribeArbolS();
                }
            }
            last();
            llenaDgvEst();
        }
        ArbolSec ArbolSec;

        bool idxS;
        int campoidxS;

        private void bt_nuevoDato_Click(object sender, EventArgs e)
        {
            generaLista();
            if (borrarDat())
            {
                File.Delete(archDat.NombreArch);
                using (FileStream archivo = new FileStream(archDat.NombreArch, FileMode.Create))
                {
                    archivo.Close();
                }
                if (idxP)
                {
                    File.Delete(archIdxP.NombreArch);
                    using (FileStream archivo = new FileStream(archIdxP.NombreArch, FileMode.Create))
                    {
                        archivo.Close();
                    }
                }

                if (idxS)
                {
                    File.Delete(archidxS.nombreArch);
                    using (FileStream archivo = new FileStream(archidxS.nombreArch, FileMode.Create))
                    {
                        archivo.Close();
                    }
                }
                if (arbolpri)
                {
                    File.Delete(ArbolPri.nombreArch);
                    using (FileStream archivo = new FileStream(ArbolPri.nombreArch, FileMode.Create))
                    {
                        archivo.Close();
                    }
                }
                if (arbolS)
                {
                    File.Delete(ArbolSec.nombreArch);
                    using (FileStream archivo = new FileStream(ArbolSec.nombreArch, FileMode.Create))
                    {
                        archivo.Close();
                    }
                }
                entidades[sele].DirDatos = archivoDatos.dir;
            }
            if (idxP)
            {
                if (archIdxP.existe(datosAux[campoidx]))
                {
                    MessageBox.Show("Ya existe el indice primario");
                    return;
                }
            }
            archDat.escribeDato(archivoDatos.dir, datosAux);
            todosDatos.Add(datosAux);
            ordena();
            buscaAux();
            if (idxP)
            {
                insertaidxP(datosAux[campoidx], datosAux[0]);
                actualizaDataidxp();
                atributos[campoidx-1].DirIndice = 0;
                dic.escribeAtributo(atributos[campoidx - 1].DirAt, atributos[campoidx - 1]);
            }
            if (idxS)
            {
                archidxS.insertaEnBP(datosAux[campoidxS], datosAux[0]);
                archidxS.escribeBP();
                archidxS.escribeSC();
                actualizaDataidxs();
               
                dic.escribeAtributo(atributos[campoidxS - 1].DirAt, atributos[campoidxS - 1]);
            }
            if (arbolpri)
            {
                ArbolPri.inserta(datosAux[campoArbPri], Convert.ToInt64(datosAux[0]));
                escribeArbolPrim();
                atributos[campoArbPri - 1].DirIndice = ArbolPri.raiz;
                dic.escribeAtributo(atributos[campoArbPri - 1].DirAt, atributos[campoArbPri - 1]);
                ArbolPri.escribetodo();
            }
            if (arbolS)
            {
                ArbolSec.inserta(datosAux[campoArbolS], Convert.ToInt64(datosAux[0]));
                escribeArbolS();
                atributos[campoArbolS - 1].DirIndice = ArbolSec.raiz;
                dic.escribeAtributo(atributos[campoArbolS - 1].DirAt, atributos[campoArbolS - 1]);
                ArbolSec.escribetodo();
            }
            dic.escribeEntidad(entidades[sele].DirEnt, entidades[sele]);
            llenaDgvEst();
        }

        public void escribeArbolPrim()
        {
            int cnt = 2;
            dataGridView5.Rows.Clear();
            for(int i = 0; i< ArbolPri.Nodos.Count; i++)
            {
                dataGridView5.Rows.Add();
                dataGridView5.Rows[dataGridView5.Rows.Count - 2].Cells[0].Value = ArbolPri.Nodos[i].Tipo.ToString();
                dataGridView5.Rows[dataGridView5.Rows.Count - 2].Cells[1].Value = ArbolPri.Nodos[i].DirNodo1.ToString();
                for (int j = 0; j < ArbolPri.Nodos[i].Claves.Count; j++)
                {
                    dataGridView5.Rows[dataGridView5.Rows.Count - 2].Cells[cnt].Value = ArbolPri.Nodos[i].Apuntadores1[j].ToString();
                    cnt++;
                    dataGridView5.Rows[dataGridView5.Rows.Count - 2].Cells[cnt].Value = ArbolPri.Nodos[i].Claves[j].ToString();
                    cnt++;
                }
                if(ArbolPri.Nodos[i].Tipo == 'H')
                {
                    dataGridView5.Rows[dataGridView5.Rows.Count - 2].Cells[dataGridView5.Rows[dataGridView5.Rows.Count - 2].Cells.Count-1].Value = ArbolPri.Nodos[i].Apuntadores1[ArbolPri.Nodos[i].Apuntadores1.Count-1].ToString();
                }else
                {
                    dataGridView5.Rows[dataGridView5.Rows.Count - 2].Cells[cnt].Value = ArbolPri.Nodos[i].Apuntadores1[ArbolPri.Nodos[i].Apuntadores1.Count - 1].ToString();
                }
                cnt = 2;
            }
        }

        public void escribeArbolS()
        {
            int cnt = 2;
            dataGridView6.Rows.Clear();
            for (int i = 0; i < ArbolSec.Nodos.Count; i++)
            {
                dataGridView6.Rows.Add();
                dataGridView6.Rows[dataGridView6.Rows.Count - 2].Cells[0].Value = ArbolSec.Nodos[i].Tipo.ToString();
                dataGridView6.Rows[dataGridView6.Rows.Count - 2].Cells[1].Value = ArbolSec.Nodos[i].DirNodo1.ToString();
                for (int j = 0; j < ArbolSec.Nodos[i].Claves.Count; j++)
                {
                    dataGridView6.Rows[dataGridView6.Rows.Count - 2].Cells[cnt].Value = ArbolSec.Nodos[i].Apuntadores1[j].ToString();
                    cnt++;
                    dataGridView6.Rows[dataGridView6.Rows.Count - 2].Cells[cnt].Value = ArbolSec.Nodos[i].Claves[j].ToString();
                    cnt++;
                }
                if (ArbolSec.Nodos[i].Tipo == 'H')
                {
                    dataGridView6.Rows[dataGridView6.Rows.Count - 2].Cells[dataGridView6.Rows[dataGridView6.Rows.Count - 2].Cells.Count - 1].Value = ArbolSec.Nodos[i].Apuntadores1[ArbolSec.Nodos[i].Apuntadores1.Count - 1].ToString();
                }
                else
                {
                    dataGridView6.Rows[dataGridView6.Rows.Count - 2].Cells[cnt].Value = ArbolSec.Nodos[i].Apuntadores1[ArbolSec.Nodos[i].Apuntadores1.Count - 1].ToString();
                }
                cnt = 2;
            }
        }



        public void buscaAux()
        {
            for (int i = 0; i < todosDatos.Count; i++)
            {
                if (todosDatos[i][campoidx] == datosAux[campoidx])
                {
                    datosAux[0] = todosDatos[i][0];
                }
            }
        }

        private void llenaDgvEst()
        {
            dataGridView1.Rows.Clear();
            for(int i = 0; i < todosDatos.Count; i++)
            {
                dataGridView1.Rows.Add();
                for (int j = 0; j < todosDatos[i].Count; j++)
                {
                    dataGridView1.Rows[i].Cells[j].Value = todosDatos[i][j];
                }
            }
        }
        private List<string> datosAux;

        private void generaLista()
        {
            datosAux = new List<string>();
            datosAux.Add(archivoDatos.dir.ToString());
            for (int i = 0; i < dGV_AgregarDat.Rows.Count-1; i++)
            {
                datosAux.Add(dGV_AgregarDat.Rows[i].Cells[2].Value.ToString());
            }
            datosAux.Add("-1");
        }

        private void datosToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        string rowselec="";
        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            
        }
        int cntmodifi;
        private void bt_modDato_Click(object sender, EventArgs e)
        {
            int i;
            int cnt = 0;
            rowselec = dataGridView1.SelectedCells[0].Value.ToString().Replace("\0", "");
            for (i = 0; i < todosDatos.Count; i++)
            {
                if (todosDatos[i][0].Replace("\0", "").Equals(rowselec))
                {
                    for(int j = 1; j < todosDatos[i].Count-1; j++)
                    {
                        dGV_AgregarDat.Rows[cnt].Cells[2].Value = todosDatos[i][j];
                        cnt++;
                    }
                    cntmodifi = i;
                    break;
                }
            }
        }

        private void bt_eliminaDato_Click(object sender, EventArgs e)
        {
            string borra = "";
            int i;
            buscacve();
            rowselec = dataGridView1.SelectedCells[0].Value.ToString().Replace("\0","");
            for(i =0; i<todosDatos.Count; i++)
            {
                if (todosDatos[i][0].Replace("\0", "").Equals(rowselec))
                {
                    if (idxP)
                    {
                        archIdxP.eliminarDato(todosDatos[i][campoidx].Replace("\0", ""), todosDatos[i][0].Replace("\0", ""));
                        actualizaDataidxp();
                    }

                    if (idxS)
                    {
                        archidxS.eliminarDato(todosDatos[i][campoidxS],todosDatos[i][0]);
                        actualizaDataidxs();
                    }
                    if (arbolpri)
                    {                        
                        ArbolPri.elimina(todosDatos[i][campoArbPri].Replace("\0", ""), Convert.ToInt64(todosDatos[i][0].Replace("\0", "")));
                        ArbolPri.escribetodo();
                        if (todosDatos.Count == 4)
                        {
                            ArbolPri.Nodos[ArbolPri.lugarLista(ArbolPri.raiz)].Tipo = 'H';
                        }
                        ArbolPri.escribetodo();
                        ArbolPri.leeDatos(Convert.ToInt64(ArbolPri.raiz), 4);
                        atributos[campoArbPri - 1].DirIndice = ArbolPri.raiz;
                        dic.escribeAtributo(atributos[campoArbPri - 1].DirAt, atributos[campoArbPri - 1]);
                        escribeArbolPrim();
                    }

                    if (arbolS)
                    {
                        ArbolSec.elimina(todosDatos[i][campoArbolS].Replace("\0", ""), Convert.ToInt64(todosDatos[i][0].Replace("\0", "")));
                        ArbolSec.escribetodo();
                        if (todosDatos.Count == 4)
                        {
                            ArbolSec.Nodos[ArbolSec.lugarLista(ArbolSec.raiz)].Tipo = 'H';
                        }
                        ArbolSec.escribetodo();
                        ArbolSec.leeDatos(Convert.ToInt64(ArbolSec.raiz), 4);
                        atributos[campoArbolS - 1].DirIndice = ArbolSec.raiz;
                        dic.escribeAtributo(atributos[campoArbolS - 1].DirAt, atributos[campoArbolS - 1]);
                        escribeArbolS();
                    }

                    borra = todosDatos[i][0].Replace("\0", "");
                    todosDatos.RemoveAt(i);
                    if (todosDatos.Count < 4 && arbolpri)
                    {
                       ArbolPri.Nodos[ArbolPri.lugarLista(ArbolPri.raiz)].Tipo = 'H';
                       for(int j = 0; j< ArbolPri.Nodos.Count; j++)
                        {
                            if(ArbolPri.Nodos[j].DirNodo1 != ArbolPri.raiz)
                            {
                                ArbolPri.Nodos.Remove(ArbolPri.Nodos[j]);
                            }
                        }
                    }
                    if(todosDatos.Count == 0 && arbolpri)
                    {
                        atributos[campoArbPri - 1].DirIndice = -1;
                        dic.escribeAtributo(atributos[campoArbPri - 1].DirAt, atributos[campoArbPri - 1]);
                    }
                    if (todosDatos.Count == 0 && arbolS)
                    {
                        atributos[campoArbolS - 1].DirIndice = -1;
                        dic.escribeAtributo(atributos[campoArbolS - 1].DirAt, atributos[campoArbolS - 1]);
                    }
                    break;
                }
            }
          
            for (i = 0; i < todosDatos.Count; i++)
            {
                if (todosDatos[i][todosDatos[i].Count-1].Replace("\0", "") == borra)
                {
                    todosDatos[i][todosDatos[i].Count - 1] = "-1";
                    break;
                }
            }
            if(todosDatos.Count == 0)
            {
                selEntidad.DirDatos = -1;
            }else
            {
                selEntidad.DirDatos = Convert.ToInt64(todosDatos[0][0]);
                dic.escribeEntidad(selEntidad.DirEnt, selEntidad);
            }
            ordena();           
            llenaDgvEst();       
       }

        private void button1_Click(object sender, EventArgs e)
        {
            buscaidxP();
            buscaidxS();
            buscacve();
            buscarArbolP();
            rowselec = dataGridView1.SelectedCells[0].Value.ToString().Replace("\0", "");
            for (int i=0; i < todosDatos.Count; i++)
            {
                if (todosDatos[i][0].Replace("\0", "").Equals(rowselec))
                {
                    if (idxP)
                    {
                        archIdxP.eliminarDato(todosDatos[i][campoidx].Replace("\0", ""), todosDatos[i][0].Replace("\0", ""));
                        actualizaDataidxp();
                    }

                    if (idxS)
                    {
                        archidxS.eliminarDato(todosDatos[i][campoidxS], todosDatos[i][0]);
                        actualizaDataidxs();
                    }
                    if (arbolpri)
                    {
                        ArbolPri.elimina(todosDatos[i][campoArbPri].Replace("\0", ""), Convert.ToInt64(todosDatos[i][0].Replace("\0", "")));
                        ArbolPri.escribetodo();
                        if (todosDatos.Count == 4)
                        {
                            ArbolPri.Nodos[ArbolPri.lugarLista(ArbolPri.raiz)].Tipo = 'H';
                        }
                        ArbolPri.escribetodo();
                        ArbolPri.leeDatos(Convert.ToInt64(ArbolPri.raiz), 4);
                        atributos[campoArbPri - 1].DirIndice = ArbolPri.raiz;
                        dic.escribeAtributo(atributos[campoArbPri - 1].DirAt, atributos[campoArbPri - 1]);
                        escribeArbolPrim();
                    }
                    if (todosDatos.Count < 4 && arbolpri)
                    {
                        ArbolPri.Nodos[ArbolPri.lugarLista(ArbolPri.raiz)].Tipo = 'H';
                        for (int j = 0; j < ArbolPri.Nodos.Count; j++)
                        {
                            if (ArbolPri.Nodos[j].DirNodo1 != ArbolPri.raiz)
                            {
                                ArbolPri.Nodos.Remove(ArbolPri.Nodos[j]);
                            }
                        }
                    }
                    if (todosDatos.Count == 0 && arbolpri)
                    {
                        atributos[campoArbPri - 1].DirIndice = -1;
                        dic.escribeAtributo(atributos[campoArbPri - 1].DirAt, atributos[campoArbPri - 1]);
                    }
                    if (arbolS)
                    {
                        ArbolSec.elimina(todosDatos[i][campoArbolS].Replace("\0", ""), Convert.ToInt64(todosDatos[i][0].Replace("\0", "")));
                        ArbolSec.escribetodo();
                        if (todosDatos.Count == 4)
                        {
                            ArbolSec.Nodos[ArbolSec.lugarLista(ArbolSec.raiz)].Tipo = 'H';
                        }
                        ArbolSec.escribetodo();
                        ArbolSec.leeDatos(Convert.ToInt64(ArbolSec.raiz), 4);
                        atributos[campoArbolS - 1].DirIndice = ArbolSec.raiz;
                        dic.escribeAtributo(atributos[campoArbolS - 1].DirAt, atributos[campoArbolS - 1]);
                        escribeArbolS();
                    }
                    if (todosDatos.Count == 0 && arbolS)
                    {
                        atributos[campoArbolS - 1].DirIndice = -1;
                        dic.escribeAtributo(atributos[campoArbolS - 1].DirAt, atributos[campoArbolS - 1]);
                    }

                    break;
                }
            }

            for (int i=0; i < todosDatos[cntmodifi].Count - 2; i++)
            {
                todosDatos[cntmodifi][i+1] = dGV_AgregarDat.Rows[i].Cells[2].Value.ToString();
            }
            datosAux = new List<string>(todosDatos[cntmodifi]);
            archDat.escribeDato(Convert.ToInt64(todosDatos[cntmodifi][0]), todosDatos[cntmodifi]);
            
            if (idxP)
            {
                insertaidxP(datosAux[campoidx], datosAux[0]);
                actualizaDataidxp();
                atributos[campoidx - 1].DirIndice = 0;
                dic.escribeAtributo(atributos[campoidx - 1].DirAt, atributos[campoidx - 1]);
            }
            if (idxS)
            {
                archidxS.insertaEnBP(datosAux[campoidxS], datosAux[0]);
                archidxS.escribeBP();
                archidxS.escribeSC();
                actualizaDataidxs();
                atributos[campoidxS - 1].DirIndice = 0;
                dic.escribeAtributo(atributos[campoidxS - 1].DirAt, atributos[campoidxS - 1]);
            }
            if (arbolpri)
            {
                ArbolPri.inserta(datosAux[campoArbPri], Convert.ToInt64(datosAux[0]));
                ArbolPri.escribetodo();
                atributos[campoArbPri - 1].DirIndice = ArbolPri.raiz;
                dic.escribeAtributo(atributos[campoArbPri - 1].DirAt, atributos[campoArbPri - 1]);
                escribeArbolPrim();
            }
            if (arbolS)
            {
                ArbolSec.inserta(datosAux[campoArbolS], Convert.ToInt64(datosAux[0]));
                escribeArbolS();
                atributos[campoArbolS - 1].DirIndice = ArbolSec.raiz;
                dic.escribeAtributo(atributos[campoArbolS - 1].DirAt, atributos[campoArbolS - 1]);
                ArbolSec.escribetodo();
            }

            ordena();
            
            llenaDgvEst();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void TabDatos_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView6_DoubleClick(object sender, EventArgs e)
        {
            //MessageBox.Show(dataGridView6.SelectedRows[0].ToString());
            if(dataGridView6.SelectedRows[0] == null)
            {
                return;
            }
            DatoDir.Rows.Clear();
            if (dataGridView6.SelectedRows[0].Cells[0].Value.ToString() == "H")
            {
                for(int i = 2; i< dataGridView6.SelectedRows[0].Cells.Count -1; i+=2)
                {
                    if(dataGridView6.SelectedRows[0].Cells[i].Value != null)
                    {
                        DatoDir.Rows.Add(dataGridView6.SelectedRows[0].Cells[i+1].Value.ToString(), dataGridView6.SelectedRows[0].Cells[i].Value.ToString());
                    }else
                    {
                        break;
                    }
                }
            }
        }

        private void direcciones_DoubleClick(object sender, EventArgs e)
        {
           
        }

        private void DatoDir_DoubleClick(object sender, EventArgs e)
        {
            ArbolSec.leeSC(Convert.ToInt64(DatoDir.SelectedRows[0].Cells[1].Value.ToString()));
            direcciones.Rows.Clear();
            for (int i = 0; i < ArbolSec.secundario.Count; i++)
            {
                direcciones.Rows.Add(ArbolSec.secundario[i]);
            }
        }

        private void llenaDatagrid()
        {
            string aux="";
            for(int i = 0; i < atributos.Count; i++)
            {
                switch (atributos[i].TipoAt)
                {
                    case 'e': aux = "Entero";
                        break;
                    case 'c':
                        aux = "Cadena";
                        break;
                }
                dGV_AgregarDat.Rows.Add(atributos[i].NombreAt,aux, "");
            }
        }
    }
}
