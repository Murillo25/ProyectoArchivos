﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoArchivos
{
    class ArchIndiceSec
    {
        //Variable necesaria para abrir el archivo 
        private FileStream archivo;
        //Nombre del archivo
        private String nombreArch;
        List<List<byte[]>> listas;
        public List<List<string>> muestralistas;
        //Listas para guardar datos en las datagridview
        public List<List<byte[]>> ListaDir;
        private List<String> Listaview;
        //Variable del tamaño del archivo
        private int numBloqus;
        private int desperdicio;
        private int tamañoCve;
        public FileStream Archivo
        {
            get
            {
                return archivo;
            }

            set
            {
                archivo = value;
            }
        }
        public string NombreArch
        {
            get
            {
                return nombreArch;
            }

            set
            {
                nombreArch = value;
            }
        }
        public int TamañoCve
        {
            get
            {
                return tamañoCve;
            }

            set
            {
                tamañoCve = value;
            }
        }
        public List<string> Listaview1
        {
            get
            {
                return Listaview;
            }

            set
            {
                Listaview = value;
            }
        }
        public ArchIndiceSec(string name, int tam)
        {
            nombreArch = name;
            tamañoCve = tam;
            calculaBloque();
            listas = new List<List<byte[]>>();
            muestralistas = new List<List<string>>();
            ListaDir = new List<List<byte[]>>();
            Listaview1 = new List<string>();
            ListaDir.Add(new List<byte[]>());
            GeneraLista(true);
        }

        public void agregaLista()
        {
            listas.Add(new List<byte[]>());
            muestralistas.Add(new List<string>());
            for (int i = 0; i < 256; i++)
            {
                listas[listas.Count - 1].Add(new byte[8]);
                muestralistas[muestralistas.Count - 1].Add("-1");
            }
        }
        public bool existe(string cve)
        {
            for (int i = 0; i < Listaview.Count - 1; i += 2)
            {
                if (Listaview[i + 1] == "-1")
                {
                    return false;
                }
                else
                {
                    if (Listaview[i].Equals(cve))
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public int existepos(string cve)
        {
            for (int i = 0; i < Listaview.Count - 1; i += 2)
            {
                if (Listaview[i].Replace("\0","").Equals(cve))
                 {
                        return i;
                  }
            }
            return 0;
        }
        public int regresaPos(string cve)
        {
            for (int i = 0; i < Listaview.Count; i += 2)
            {
                if (Listaview[i + 1].Replace("\0", "") == "-1")
                {
                    return i;
                }
                else
                {
                    if (tamañoCve == 4)
                    {
                        if (Convert.ToInt32(Listaview[i].ToString()).CompareTo(Convert.ToInt32(cve)) > 0)
                        {
                            return i;
                        }
                    }
                    else
                    {
                        if (Listaview[i].ToString().CompareTo(cve) > 0)
                        {
                            return i;
                        }
                    }
                }
            }
            return 0;
        }
        public void escribeUno(string cve, string dir, int pos)
        {
            Listaview.Insert(pos, cve);
            Listaview.Insert(pos + 1, dir);
            ActualizaLista();
        }

        public void insertaLista(string dir,int direc)
        {

            for(int i = 0; i < muestralistas.Count; i++)
            {
                if (direc < 2048)
                {
                    muestralistas[0][i] = dir;
                    break;
                }
                else
                {
                    if (muestralistas[(direc / 2048-1)][i].Replace("\0", "") == "-1")
                    {
                        muestralistas[(direc / 2048-1)][i] = dir;
                        break;
                    }
                }
            }
        }

        private void GeneraLista(bool inicio)
        {
            if (inicio)
            {
                for (int i = 0; i < numBloqus; i++)
                {
                    ListaDir[0].Add(new byte[tamañoCve]);
                    Listaview1.Add("");
                    ListaDir[0].Add(new byte[8]);
                    Listaview1.Add("-1");
                }
                ListaDir[0].Add(new byte[8]);
                Listaview1.Add("-1");
                if (desperdicio > 0)
                    ListaDir[0].Add(new byte[desperdicio]);
            }
        }

        private void llenaLista()
        {
            int aux = 0;
            if (desperdicio > 0)
                aux++;
            for (int i = 1; i < ListaDir[0].Count - aux; i += 2)
            {
                Encoding.ASCII.GetBytes("-1", 0, "-1".Length, ListaDir[0][i], 0);
            }
        }

        public void update()
        {
            for (int i = 0; i < Listaview.Count; i++)
            {
                Listaview[i] = Encoding.ASCII.GetString(ListaDir[0][i]);
            }

            for (int i = 0; i < listas.Count; i++)
            {
                for (int j = 0; j < listas[i].Count; j++)
                {
                    muestralistas[i][j] = Encoding.ASCII.GetString(listas[i][j]);
                }
            }
        }

        public void ActualizaLista()
        {
            int i;
            for (i = 0; i < ListaDir[0].Count - 2; i++)
            {
                Encoding.ASCII.GetBytes(Listaview1[i], 0, Listaview1[i].Length, ListaDir[0][i], 0);
            }
        }

        public void ActualizaListas()
        {
            int i,j;
            for (i = 0; i < listas.Count ; i++)
            {
                for (j = 0; j < listas[i].Count; j++)
                {
                    Encoding.ASCII.GetBytes(muestralistas[i][j], 0, muestralistas[i][j].Length, listas[i][j], 0);
                }
            }
        }

        public void escribeLista()
        {
            ActualizaLista();
            using (Archivo = new FileStream(NombreArch, FileMode.Open))
            {
                Archivo.Position = 0;
                int i, j = 0; ;
                using (BinaryWriter bw = new BinaryWriter(Archivo))
                {
                    for (i = 0; i < numBloqus; i++)
                    {
                        bw.Write(ListaDir[0][j], 0, tamañoCve);
                        bw.Write(ListaDir[0][j + 1], 0, 8);
                        j += 2;
                    }
                    bw.Write(ListaDir[0][j], 0, 8);
                    if (desperdicio > 0)
                        bw.Write(new byte[desperdicio]);

                    for(i = 0; i < listas.Count; i++)
                    {
                        for (j = 0; j < listas[i].Count; j++)
                        {
                            bw.Write(listas[i][j]);
                        }
                    }
                }
            }
            Archivo.Close();
        }

        public void leeLista()
        {
            ListaDir[0].Clear();
            listas.Clear();
            using (Archivo = new FileStream(NombreArch, FileMode.Open))
            {
                Archivo.Position = 0;
                using (BinaryReader rw = new BinaryReader(Archivo))
                {
                    for (int i = 0; i < numBloqus; i++)
                    {
                        ListaDir[0].Add(rw.ReadBytes(tamañoCve));
                        ListaDir[0].Add(rw.ReadBytes(8));
                    }
                    ListaDir[0].Add(rw.ReadBytes(8));
                    if (desperdicio > 0)
                        ListaDir[0].Add(rw.ReadBytes(8));
                }
            }
            Archivo.Close();
        }

        public void leeListaa()
        {
            listas.Clear();
            using (Archivo = new FileStream(NombreArch, FileMode.Open))
            {
                Archivo.Position = 2048;
                using (BinaryReader rw = new BinaryReader(Archivo))
                {
                    for (int i = 0; i < cuentaDatos(); i++)
                    {
                        listas.Add(new List<byte[]>());
                        for (int j = 0; j < 256; j++)
                        {
                            listas[i].Add(rw.ReadBytes(8));
                        }
                    }
                }
            }
            Archivo.Close();
        }

        public int cuentaDatos()
        {
            int cnt = 0;

            for(int i = 1; i < numBloqus; i+=2)
            {
                if(Listaview[i].Replace("\0","").Equals("-1"))
                {
                    break;
                }else
                {
                    cnt++;
                }
            }
            return cnt;
        }
        private void calculaBloque()
        {
            numBloqus = 2040 / (tamañoCve + 8);
            desperdicio = 2040 % (tamañoCve + 8);
        }
    }
}