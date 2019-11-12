using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoArchivos
{
    class NodoArbol
    {
        private char tipo;
        private int longitudCve;
        private Int64 DirNodo;
        private List<Int64> Apuntadores;
        private List<String> claves;
        private List<byte[]> nodoBytes;

        public long DirNodo1
        {
            get
            {
                return DirNodo;
            }

            set
            {
                DirNodo = value;
            }
        }
        public List<string> Claves
        {
            get
            {
                return claves;
            }

            set
            {
                claves = value;
            }
        }
        public List<long> Apuntadores1
        {
            get
            {
                return Apuntadores;
            }

            set
            {
                Apuntadores = value;
            }
        }
        public char Tipo
        {
            get
            {
                return tipo;
            }

            set
            {
                tipo = value;
            }
        }

        public NodoArbol(char t,Int64 dir, int g,int tam)
        {
            Tipo = t;
            longitudCve = tam;
            DirNodo1 = dir;
            nodoBytes = new List<byte[]>();
            Apuntadores1 = new List<Int64>();
            Claves = new List<String>();
            inicializaListas(g);
            inicializaBytes(g);
        }
        public void inicializaListas(int grado)
        {
            Apuntadores1.Add(-1);
            for(int i =0; i < grado - 1; i++)
            {
                Apuntadores1.Add(-1);
                Claves.Add("");
            }
        }
        public void inicializaBytes(int grado)
        {
            nodoBytes.Add(new byte[1]);
            nodoBytes.Add(new byte[8]);
            nodoBytes.Add(new byte[8]);
            for (int i = 0; i < grado - 1; i++)
            {
                nodoBytes.Add(new byte[longitudCve]);
                nodoBytes.Add(new byte[8]);
            }
        }
        public void actualizaBytes()
        {
            int cnt = 2;
            Encoding.ASCII.GetBytes(Tipo.ToString(),0, 1, nodoBytes[0], 0);
            Encoding.ASCII.GetBytes(Apuntadores1[0].ToString(), 0, Apuntadores1[0].ToString().Length, nodoBytes[1], 0);
            for(int i =0; i < Claves.Count; i++)
            {
                Encoding.ASCII.GetBytes(Claves[i].ToString(), 0, Claves[i].ToString().Length, nodoBytes[cnt], 0);
                cnt++;
                Encoding.ASCII.GetBytes(Apuntadores1[i+1].ToString(), 0, Apuntadores1[0].ToString().Length, nodoBytes[cnt], 0);
                cnt++;
            }
        }
        public void actualizaDatos()
        {
            int cnt = 2;
            Tipo = Convert.ToChar(Encoding.ASCII.GetString(nodoBytes[0]));
            DirNodo1 = Convert.ToInt64(Encoding.ASCII.GetString(nodoBytes[1]));
            for (int i = 0; i < Claves.Count; i++)
            {
                Claves[cnt] = Encoding.ASCII.GetString(nodoBytes[cnt]);
                cnt++;
                Apuntadores1[cnt] = Convert.ToInt64(Encoding.ASCII.GetString(nodoBytes[cnt]));
                cnt++;
            }
        }
        public int buscaHoja(string dat)
        {
            int search = -1;
            for(int i =0; i < Claves.Count; i++)
            {
                if (dat.Replace("\0", "").Equals(Claves[i].Replace("\0", "")))
                {
                    search = Convert.ToInt32(DirNodo1);
                    break;
                }else
                {
                    if (Claves[i].Replace("\0", "").Equals(""))
                    {
                        search = -1;
                        break;
                    }
                }
            }
            return search;
        }
        public void insertaHoja(string dat,string direccion)
        {
            for(int i =0; i < Claves.Count; i++)
            {
                if (Claves[i].Replace("\0", "").Equals(""))
                {
                    Claves[i] = dat;
                    Apuntadores1[i] = Convert.ToInt64(direccion);
                    break;
                }
            }
            ordenaNodo();
        }
        public void ordenaNodo()
        {
            List<Int64> auxp = new List<long>();
            List<String> auxcve = new List<string>(Claves);
            auxcve.Sort();
            for (int j = 0; j < auxcve.Count; j++)
            {
                for (int i = 0; i < Claves.Count; i++)
                {
                    if (auxcve[j].Replace("\0", "") == Claves[i].Replace("\0", ""))
                    {
                        auxp.Add(Apuntadores1[i]);
                        break;
                    }
                }
            }
            auxp.Add(Apuntadores1[4]);
            Claves.Sort();
            Apuntadores1 = new List<long>(auxp);
        }
    
    }
}
