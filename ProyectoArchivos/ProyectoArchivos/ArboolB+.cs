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
        public List<NodoArbol> Nodos;
        public int raiz;
        public static long dirActual;
        private int tamañoNodo;
        public int tamCve;
        public ArboolB_(int g, String name, int tam)
        {
            tamCve = tam;
            tamañoNodo = 1 + (6 * 8) + (4 * tam);
            raiz = -1;
            dirActual = 0;
            nombreArch = name;
            grado = g;
            Nodos = new List<NodoArbol>();
        }
        public int lugarLista(long dirNodo)
        {
            int aux = -1;
            for (int i = 0; i < Nodos.Count; i++)
            {
                if (Nodos[i].DirNodo1 == dirNodo)
                {
                    aux = i;
                    break;
                }
            }
            return aux;
        }
        public bool buscaDato(string dat, long dir)
        {
            bool auxi = false;
            if (raiz != -1)
            {
                if (Nodos[lugarLista(dir)].Tipo == 'R' || Nodos[lugarLista(dir)].Tipo == 'I')
                {
                    auxi = buscaDato(dat, Nodos[lugarLista(dir)].buscaDato(dat));
                } else
                {
                    if (Nodos[lugarLista(dir)].buscaDato(dat) != -1)
                    {
                        auxi = true;
                    }
                }
            }
            return auxi;
        }
        public long buscaNodoHoja(string dat, long dir)
        {
            long dire = -1;
            if (raiz != -1)
            {
                if (Nodos[lugarLista(dir)].Tipo == 'R' || Nodos[lugarLista(dir)].Tipo == 'I')
                {
                    for (int i = 0; i < Nodos[lugarLista(dir)].Claves.Count; i++)
                    {
                        if(Convert.ToInt32(dat) < Convert.ToInt32(Nodos[lugarLista(dir)].Claves[i]))
                        {
                            dire = buscaNodoHoja(dat, Nodos[lugarLista(dir)].Apuntadores1[i]);
                            break;
                        }
                        if(Nodos[lugarLista(dir)].Claves.Count-1 == i)
                        {
                            dire = buscaNodoHoja(dat, Nodos[lugarLista(dir)].Apuntadores1[i+1]);
                        }
                       
                    }
                }
                else
                {
                    if (Nodos[lugarLista(dir)].buscaDato2(dat) != -1)
                    {
                        dire = Nodos[lugarLista(dir)].DirNodo1;
                    }
                }
            }
            return dire;
        }
        public long buscaNodoHoja(string dat, long dir, bool auxxx)
        {
            long dire = -1;
            if (raiz != -1)
            {
                if (Nodos[lugarLista(dir)].Tipo == 'R' || Nodos[lugarLista(dir)].Tipo == 'I')
                {
                    for (int i = 0; i < Nodos[lugarLista(dir)].Claves.Count; i++)
                    {
                        if (Convert.ToInt32(Nodos[lugarLista(dir)].Claves[i]) > Convert.ToInt32(dat))
                        {
                            dire = buscaNodoHoja(dat, Nodos[lugarLista(dir)].Apuntadores1[i], true);
                            break;
                        } else
                        {
                            dire = buscaNodoHoja(dat, Nodos[lugarLista(dir)].Apuntadores1[i+1], true);
                        }
                    }
                }
                else
                {
                    dire = Nodos[lugarLista(dir)].DirNodo1;
                }
            }
            return dire;
        }
        public long divideNodos(long dNode, string dat, long direc)
        {
            long NodoDir = dirActual;
            int pos = lugarLista(dNode);
            NodoArbol auxi = new NodoArbol(Nodos[pos].Tipo, -1, 5, tamCve);
            Nodos.Add(auxi);
            EscribeNodoAlFinal(Nodos[Nodos.Count - 1]);
            Nodos[Nodos.Count - 1].recorreDatos(Nodos[pos].limpiaMitad(dat));
            if (Nodos[pos].limpiaMitad(dat))
            {
                Nodos[Nodos.Count - 1].insertaDato(dat, direc);
            } else
            {
                Nodos[pos].insertaDato(dat, direc);
            }

            return NodoDir;
        }
        public void EscribeNodoAlFinal(NodoArbol nodo)
        {
            using (archivo = new FileStream(nombreArch, FileMode.Open))
            {
                char[] mnm = new char[tamCve];
                for(int i = 0; i < tamCve; i++)
                {
                    mnm[i] = ' ';
                }
                nodo.DirNodo1 = dirActual;
                archivo.Position = dirActual;
                using (BinaryWriter bw = new BinaryWriter(archivo))
                {
                    bw.Write(nodo.Tipo);
                    bw.Write(nodo.DirNodo1);
                    bw.Write(Convert.ToInt64(-2));
                    for (int i = 0; i < 4; i++)
                    {
                        bw.Write(mnm);
                        bw.Write(Convert.ToInt64(-2));
                    }
                }
            }
            dirActual += tamañoNodo;
        }
        public void SobreEscribeNodo(NodoArbol nodo)
        {
            char[] mnm = new char[tamCve];
            for (int i = 0; i < tamCve; i++)
            {
                mnm[i] = ' ';
            }
            using (archivo = new FileStream(nombreArch, FileMode.Open))
            {
                archivo.Position = nodo.DirNodo1;
                using (BinaryWriter bw = new BinaryWriter(archivo))
                {

                    bw.Write(nodo.Tipo);
                    bw.Write(nodo.DirNodo1);
                    int aux = 5 - nodo.Claves.Count;

                    for (int i = 0; i < nodo.Claves.Count; i++)
                    {
                        bw.Write(nodo.Apuntadores1[i]);
                        int j = 0;
                        bool flag = false;
                        char[] auxC = new char[tamCve];
                        String auxS = nodo.Claves[i];
                        while (j < tamCve)
                        {
                            if (flag == false)
                            {
                                for (int k = 0; k < auxS.Length; k++)
                                {
                                    auxC[j] = auxS[j];
                                    j++;
                                }
                                flag = true;
                            }
                            if (j < tamCve)
                            {
                                auxC[j] = ' ';
                                j++;
                            }
                        }
                        bw.Write(auxC);
                    }
                    for (int i = 0; i < aux - 1; i++)
                    {
                        bw.Write(mnm);
                        bw.Write(Convert.ToInt64(-2));
                    }
                    bw.Write(nodo.Apuntadores1[nodo.Apuntadores1.Count - 1]);
                }
            }
        }
        public void inserta(string k, long p)
        {
            long nodoHoja;
            if (raiz == -1)
            {
                Nodos.Add(new NodoArbol('H', -1, 5, tamCve));
                EscribeNodoAlFinal(Nodos[0]);
                Nodos[0].insertaDato(k, p);
                raiz = Convert.ToInt32(Nodos[0].DirNodo1);
                SobreEscribeNodo(Nodos[0]);

            } else
            {
                nodoHoja = buscaNodoHoja(k, raiz, true);
                if (Nodos[lugarLista(nodoHoja)].hayEspacio())
                {
                    Nodos[lugarLista(nodoHoja)].insertaDato(k, p);
                    SobreEscribeNodo(Nodos[lugarLista(nodoHoja)]);
                }
                else
                {
                    Nodos.Add(new NodoArbol(Nodos[lugarLista(nodoHoja)].Tipo, -1, 5, tamCve));

                    EscribeNodoAlFinal(Nodos[Nodos.Count - 1]);
                    Nodos[Nodos.Count - 1].Apuntadores1 = new List<long>(Nodos[lugarLista(nodoHoja)].Apuntadores1);
                    Nodos[Nodos.Count - 1].Claves = new List<string>(Nodos[lugarLista(nodoHoja)].Claves);
                    bool recorre = Nodos[lugarLista(nodoHoja)].limpiaMitad(k);
                    Nodos[Nodos.Count - 1].recorreDatos(!recorre);
                    Nodos[lugarLista(nodoHoja)].Apuntadores1[Nodos[lugarLista(nodoHoja)].Apuntadores1.Count - 1] = Nodos[Nodos.Count - 1].DirNodo1;
                    if (recorre)
                    {
                        
                        //Nodos[lugarLista(nodoHoja)].Apuntadores1[Nodos[lugarLista(nodoHoja)].Apuntadores1.Count - 1] = Nodos[Nodos.Count - 1].DirNodo1;
                        Nodos[lugarLista(nodoHoja)].insertaDato(k, p);

                    }
                    else
                    {
                        
                        //Nodos[Nodos.Count - 1].Apuntadores1[Nodos[Nodos.Count - 1].Apuntadores1.Count - 1] = Nodos[lugarLista(nodoHoja)].DirNodo1;
                        Nodos[Nodos.Count - 1].insertaDato(k, p);
                    }
                    SobreEscribeNodo(Nodos[lugarLista(nodoHoja)]);
                    SobreEscribeNodo(Nodos[Nodos.Count - 1]);
                    InsertaEnPadre(Nodos[lugarLista(nodoHoja)].DirNodo1, Nodos[Nodos.Count - 1].Claves[0], Nodos[Nodos.Count - 1].DirNodo1);
                }
            }
        }
        public long buscaPapa(long dir)
        {
            long dirP= -1;
            for(int i = 0; i < Nodos.Count; i++)
            {
                if(Nodos[i].Tipo == 'I'|| Nodos[i].Tipo == 'R')
                {
                    for (int j = 0; j < Nodos[i].Apuntadores1.Count; j++)
                    {
                        if(Nodos[i].Apuntadores1[j] == dir)
                        {
                            return Nodos[i].DirNodo1;
                        }
                    }
                }
            }

            return dirP;
        }
        public void InsertaEnPadre(long k1,string cve, long k2)
        {
            if(raiz == k1)
            {
                NodoArbol NodoR = new NodoArbol('R', -1, 5, tamCve);
                EscribeNodoAlFinal(NodoR);
                Nodos.Add(NodoR);
                raiz = Convert.ToInt32(NodoR.DirNodo1);
                Nodos[lugarLista(raiz)].Apuntadores1[0] = k1;
                Nodos[lugarLista(raiz)].Claves.Add(cve);
                Nodos[lugarLista(raiz)].Apuntadores1.Add(k2);
                SobreEscribeNodo(Nodos[lugarLista(raiz)]);
                return;
            }
            long pa = buscaPapa(k1);
            if (Nodos[lugarLista(pa)].Apuntadores1.Count < 5)
            {
                Nodos[lugarLista(pa)].insertaDato(cve, k2);
            }else
            {
                Nodos[lugarLista(pa)].Tipo = 'I';
                Nodos.Add(new NodoArbol(Nodos[lugarLista(pa)].Tipo,-1,5,tamCve));
                Nodos[Nodos.Count - 1].Claves = new List<string>(Nodos[lugarLista(pa)].Claves);
                Nodos[Nodos.Count - 1].Apuntadores1 = new List<long>(Nodos[lugarLista(pa)].Apuntadores1);
                EscribeNodoAlFinal(Nodos[Nodos.Count - 1]);
                bool recorre = Nodos[lugarLista(pa)].limpiaMitad(cve);
                Nodos[Nodos.Count - 1].recorreDatos(!recorre);
                //Nodos[lugarLista(pa)].Apuntadores1[Nodos[lugarLista(pa)].Apuntadores1.Count - 1] = Nodos[Nodos.Count - 1].DirNodo1;
                int elim =-1;
                if (recorre)
                {
                    Nodos[lugarLista(pa)].insertaDato(cve, k2);
                    elim = lugarLista(pa);
                }
                else
                {
                    Nodos[Nodos.Count - 1].insertaDato(cve, k2);
                    elim = Nodos.Count - 1;
                }
                
                SobreEscribeNodo(Nodos[lugarLista(pa)]);
                SobreEscribeNodo(Nodos[Nodos.Count - 1]);
                InsertaEnPadre(Nodos[lugarLista(pa)].DirNodo1, Nodos[Nodos.Count - 1].Claves[0], Nodos[Nodos.Count - 1].DirNodo1);
                if (Nodos[elim].Tipo == 'I')
                {
                    Nodos[elim].Claves.RemoveAt(0);
                    Nodos[elim].Apuntadores1.RemoveAt(0);
                    SobreEscribeNodo(Nodos[elim]);
                }
            }
            SobreEscribeNodo(Nodos[lugarLista(raiz)]);
        }

        public NodoArbol leeDatos(long dir, int ta)
        {
            NodoArbol regresa = new NodoArbol('H', dir, 5, ta);
            Nodos.Clear();
            char[] nuevo;
            regresa.Apuntadores1.RemoveAt(0);
            using (archivo = new FileStream(nombreArch, FileMode.Open))
            {
                String cadena = "";
                archivo.Position = dir;
                
                using (BinaryReader rw = new BinaryReader(archivo))
                {
                    regresa.Tipo = rw.ReadChar();
                    regresa.DirNodo1 = rw.ReadInt64();
                    regresa.Apuntadores1.Add(rw.ReadInt64());
                    for (int i = 0; i < 4; i++)
                    {
                        nuevo = new char[ta];
                        nuevo = rw.ReadChars(ta);
                        for (int j = 0; j < ta; j++)
                        {
                            cadena += nuevo[j];
                        }
                        regresa.Claves.Add(cadena.Replace(" ", ""));
                        regresa.Apuntadores1.Add(rw.ReadInt64());
                        cadena = "";
                    }
                }
            }
            archivo.Close();
            for(int i = 0; i< regresa.Claves.Count; i++)
            {
                regresa.Claves[i] = regresa.Claves[i].Replace("\0", "");
            }
            int cnt = 5;
            for (int i = 0; i < regresa.Apuntadores1.Count; i++)
            {
                if (regresa.Apuntadores1[i] < -2)
                {
                    cnt = i;
                    break;
                }
            }
            for(int i = 0;cnt< regresa.Apuntadores1.Count-1; i++)
            {
                regresa.Apuntadores1.RemoveAt(cnt);
            }
            regresa.Claves.Remove("");
            regresa.Claves.Remove("����");
            regresa.Claves.Remove("����");
            regresa.Claves.Remove("����");
            regresa.Claves.Remove("����");
            if (regresa.Tipo == 'R')
            {
                Nodos.Add(regresa);
                for (int i = 0; i < regresa.Apuntadores1.Count; i++)
                {
                    Nodos.Add(leeDatosNoraiz(regresa.Apuntadores1[i],ta));
                }
            }
            FileInfo n = new FileInfo(nombreArch);
            dirActual = n.Length;
            return regresa;
        }

        public NodoArbol leeDatosNoraiz(long dir, int ta)
        {
            NodoArbol regresa = new NodoArbol('H', dir, 5, ta);
            char[] nuevo;
            regresa.Apuntadores1.RemoveAt(0);
            using (archivo = new FileStream(nombreArch, FileMode.Open))
            {
                String cadena = "";
                archivo.Position = dir;

                using (BinaryReader rw = new BinaryReader(archivo))
                {
                    regresa.Tipo = rw.ReadChar();
                    regresa.DirNodo1 = rw.ReadInt64();
                    regresa.Apuntadores1.Add(rw.ReadInt64());
                    for (int i = 0; i < 4; i++)
                    {
                        nuevo = new char[ta];
                        nuevo = rw.ReadChars(ta);
                        for (int j = 0; j < ta; j++)
                        {
                            cadena += nuevo[j];
                        }
                        regresa.Claves.Add(cadena.Replace(" ", ""));
                        regresa.Apuntadores1.Add(rw.ReadInt64());
                        cadena = "";
                    }
                }
            }
            archivo.Close();
            for (int i = 0; i < regresa.Claves.Count; i++)
            {
                regresa.Claves[i] = regresa.Claves[i].Replace("\0", "");
            }
            int cnt = 5;
            for (int i = 0; i < regresa.Apuntadores1.Count; i++)
            {
                if (regresa.Apuntadores1[i] < -2)
                {
                    cnt = i;
                    break;
                }
            }
            for (int i = 0; cnt < regresa.Apuntadores1.Count - 1; i++)
            {
                regresa.Apuntadores1.RemoveAt(cnt);
            }
            regresa.Claves.Remove("");
            regresa.Claves.Remove("����");
            regresa.Claves.Remove("����");
            regresa.Claves.Remove("����");
            regresa.Claves.Remove("����");
            if (regresa.Tipo == 'I' )
            {
                for (int i = 0; i < regresa.Apuntadores1.Count; i++)
                {
                    Nodos.Add(leeDatosNoraiz(regresa.Apuntadores1[i], ta));
                }
            }
            dirActual = dir + tamañoNodo;
            return regresa;
        }

        public void elimina(string k, long p)
        {
            long nodo = buscaNodoHoja(k,p,true);
            borra_entrada(nodo, k, p);
        }

        public void borra_entrada(long dir, string k, long p)
        {
            bool union = false;
            bool der = true;
            string kPrima = "";
            long vecino = -1;
            Nodos[lugarLista(dir)].borraEntrada(k, p);
            if (dir == raiz || Nodos[lugarLista(dir)].Apuntadores1.Count == 1)
            {
                raiz = Convert.ToInt32(Nodos[lugarLista(dir)].DirNodo1);
            }
            else
            {
                if(Nodos[lugarLista(dir)].Apuntadores1.Count < 2 || Nodos[lugarLista(dir)].Claves.Count <= 2)
                {
                    if(Nodos[lugarLista(dir)].Tipo == 'H')
                    {
                        vecino = Nodos[lugarLista(dir)].Apuntadores1[Nodos[lugarLista(dir)].Apuntadores1.Count - 1];
                        if(vecino != -1)
                        {
                            if(Nodos[lugarLista(vecino)].Claves.Count > 2)
                            {
                                kPrima = Nodos[lugarLista(vecino)].Claves[0];
                                union = true;
                            }else
                            {
                                long pa = buscaPapa(dir);
                                int index = Nodos[lugarLista(pa)].Claves.IndexOf(Nodos[lugarLista(dir)].Claves[0]);
                                vecino = Nodos[lugarLista(pa)].Apuntadores1[index];
                                if (Nodos[lugarLista(vecino)].Claves.Count > 2)
                                {
                                    kPrima = Nodos[lugarLista(dir)].Claves[0];
                                    union = true;
                                }
                            }
                        }
                    }else
                    {
                        long pa = buscaPapa(dir);
                        int index = Nodos[lugarLista(pa)].Claves.IndexOf(Nodos[lugarLista(dir)].Claves[0]);
                        vecino = Nodos[lugarLista(pa)].Apuntadores1[index+1];
                        if (Nodos[lugarLista(vecino)].Claves.Count > 2)
                        {
                            kPrima = Nodos[lugarLista(vecino)].Claves[0];
                            union = true;
                        }else
                        {
                            vecino = Nodos[lugarLista(pa)].Apuntadores1[index];
                            if (Nodos[lugarLista(vecino)].Claves.Count > 2)
                            {
                                kPrima = Nodos[lugarLista(dir)].Claves[0];
                                union = true;
                            }
                        }
                    }
                    if (union)
                    {
                        fucionaNodos(vecino, dir,der);
                    }
                }
            }
        }

        public void fucionaNodos(long Nodo1, long Nodo2,bool der)
        {
            if (der)
            {
                for (int i = 0; i < Nodos[lugarLista(Nodo1)].Claves.Count - 1; i++) {
                    Nodos[lugarLista(Nodo2)].Claves.Insert(i, Nodos[lugarLista(Nodo1)].Claves[i]);
                    Nodos[lugarLista(Nodo2)].Apuntadores1.Insert(i, Nodos[lugarLista(Nodo1)].Apuntadores1[i]);
                }
            }else
            {
                for (int i = 0; i < Nodos[lugarLista(Nodo2)].Claves.Count - 1; i++)
                {
                    Nodos[lugarLista(Nodo1)].Claves.Insert(Nodos[lugarLista(Nodo1)].Claves.Count-1, Nodos[lugarLista(Nodo2)].Claves[i]);
                    Nodos[lugarLista(Nodo1)].Apuntadores1.Insert(Nodos[lugarLista(Nodo1)].Claves.Count - 2, Nodos[lugarLista(Nodo2)].Apuntadores1[i]);
                }
            }
        }
    }
}
