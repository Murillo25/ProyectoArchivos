using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoArchivos
{
    class ArboolB_
    {
        public FileStream archivo;
        public String nombreArch;
        private int grado;
        private List<NodoArbol> Nodos;
        private int raiz;
        private int dir;

        public ArboolB_(int g, String name)
        {
            dir = 0;
            nombreArch = name;
            grado = g;
            Nodos = new List<NodoArbol>();
        }

        public bool buscacve(string dat,bool clave,int num,string dirNo)
        {
            int aux = buscaNodo(dirNo);
            if (Nodos.Count > 1)
            {
                if (Nodos[aux].Tipo == 'R' || Nodos[aux].Tipo == 'I')
                {
                    if (Nodos[aux].Claves[num].Replace("\0", "").CompareTo(dat) > 0)
                    {
                        int dir = buscaNodo(Nodos[aux].Apuntadores1[num].ToString());
                        clave = buscacve(dat, clave,0, dir.ToString());
                    }else
                    {
                        if(num < 4 && !Nodos[aux].Claves[num+1].Replace("\0", "").Equals(""))
                            clave = buscacve(dat, clave, num+1,dirNo);
                        else
                        {
                            int dir = buscaNodo(Nodos[aux].Apuntadores1[num+1].ToString());
                            clave = buscacve(dat, clave, num, dir.ToString());
                        }
                    }
                }else
                {
                    int ejemplo = Nodos[aux].buscaHoja(dat);
                    if (ejemplo > -1)
                        clave = false;
                    else
                        clave = true;
                }
            }else
            {
                clave = true;
            }
            return clave;
        }
        public int buscaNodo(string dir)
        {
            int num = -1;
            for(int i =0; i < Nodos.Count; i++)
            {
                if(dir.Equals(Nodos[i].DirNodo1.ToString()))
                {
                    num = i;
                    break;
                }
            }
            return num;
        }

    }
}
