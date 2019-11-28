using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoArchivos
{
    class ArbolSec
    {
        public List<long> secundario;
        public FileStream archivo;
        public String nombreArch;
        private int grado;
        public List<NodoArbol> Nodos;
        public int raiz;
        public static long dirActual;
        private int tamañoNodo;
        public int tamCve;
        public ArbolSec(int g, String name, int tam)
        {
            tamCve = tam;
            tamañoNodo = 1 + (6 * 8) + (4 * tam);
            raiz = -1;
            dirActual = 0;
            nombreArch = name;
            grado = g;
            secundario = new List<long>();
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
                }
                else
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
                        if (Convert.ToInt32(dat) < Convert.ToInt32(Nodos[lugarLista(dir)].Claves[i]))
                        {
                            dire = buscaNodoHoja(dat, Nodos[lugarLista(dir)].Apuntadores1[i]);
                            break;
                        }
                        if (Nodos[lugarLista(dir)].Claves.Count - 1 == i)
                        {
                            dire = buscaNodoHoja(dat, Nodos[lugarLista(dir)].Apuntadores1[i + 1]);
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
                        }
                        else
                        {
                            dire = buscaNodoHoja(dat, Nodos[lugarLista(dir)].Apuntadores1[i + 1], true);
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
            }
            else
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
                for (int i = 0; i < tamCve; i++)
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

            }
            else
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
            long dirP = -1;
            for (int i = 0; i < Nodos.Count; i++)
            {
                if (Nodos[i].Tipo == 'I' || Nodos[i].Tipo == 'R')
                {
                    for (int j = 0; j < Nodos[i].Apuntadores1.Count; j++)
                    {
                        if (Nodos[i].Apuntadores1[j] == dir)
                        {
                            return Nodos[i].DirNodo1;
                        }
                    }
                }
            }

            return dirP;
        }
        public void InsertaEnPadre(long k1, string cve, long k2)
        {
            if (raiz == k1)
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
            }
            else
            {
                Nodos[lugarLista(pa)].Tipo = 'I';
                Nodos.Add(new NodoArbol(Nodos[lugarLista(pa)].Tipo, -1, 5, tamCve));
                Nodos[Nodos.Count - 1].Claves = new List<string>(Nodos[lugarLista(pa)].Claves);
                Nodos[Nodos.Count - 1].Apuntadores1 = new List<long>(Nodos[lugarLista(pa)].Apuntadores1);
                EscribeNodoAlFinal(Nodos[Nodos.Count - 1]);
                bool recorre = Nodos[lugarLista(pa)].limpiaMitad(cve);
                Nodos[Nodos.Count - 1].recorreDatos(!recorre);
                //Nodos[lugarLista(pa)].Apuntadores1[Nodos[lugarLista(pa)].Apuntadores1.Count - 1] = Nodos[Nodos.Count - 1].DirNodo1;
                int elim = -1;
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

            Nodos.Add(regresa);
            if (regresa.Tipo == 'R')
            {
                for (int i = 0; i < regresa.Apuntadores1.Count; i++)
                {
                    Nodos.Add(leeDatosNoraiz(regresa.Apuntadores1[i], ta));
                }
            }

            FileInfo n = new FileInfo(nombreArch);
            dirActual = n.Length;
            return regresa;
        }

        public bool RaizHoja(List<List<string>> nueva, NodoArbol n, int c)
        {
            bool sies = true;
            for (int i = 0; i < n.Claves.Count; i++)
            {
                if (n.Claves[i] != nueva[i][c].Replace("\0", ""))
                {
                    sies = false;
                    break;
                }
            }

            return sies;
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
            if (regresa.Tipo == 'I')
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
            long nodo = buscaNodoHoja(k, raiz, true);
            if (Nodos[lugarLista(raiz)].Tipo == 'H')
            {
                Nodos[lugarLista(raiz)].borraEntrada(k, p);
                return;
            }
            borra_entrada(nodo, k, p);
        }

        public void borra_entrada(long dir, string k, long p)
        {
            long vecino;
            string kPrima = "";
            long padre = buscaPapa(dir);
            Nodos[lugarLista(dir)].borraEntrada(k, p);
            SobreEscribeNodo(Nodos[lugarLista(dir)]);
            if (Nodos[lugarLista(dir)].DirNodo1 == raiz && Nodos[lugarLista(dir)].Apuntadores1.Count == 1)
            {
                raiz = Convert.ToInt32(Nodos[lugarLista(dir)].Apuntadores1[0]);
                Nodos[lugarLista(raiz)].Tipo = 'R';
                Nodos.Remove(Nodos[lugarLista(dir)]);
                return;
            }
            else
            {
                if (Nodos[lugarLista(dir)].Apuntadores1.Count <= 2 && Nodos[lugarLista(dir)].Tipo != 'R')
                {
                    vecino = buscaVecino(dir, k, true);
                    if (vecino != -1)
                    {
                        kPrima = buscaClavePapa(dir, vecino);
                        if ((Nodos[lugarLista(dir)].Apuntadores1.Count + Nodos[lugarLista(dir)].Apuntadores1.Count) <= 5)
                        {
                            juntaNodos(dir, kPrima, vecino);
                        }
                        else
                        {
                            Redistribuye(dir, kPrima, vecino);
                        }
                    }
                }
            }
        }

        public void juntaNodos(long nodo, string k, long vecino)
        {
            if (Nodos[lugarLista(nodo)].Tipo == 'H')
            {
                for (int i = 0; i < Nodos[lugarLista(nodo)].Claves.Count; i++)
                {
                    Nodos[lugarLista(vecino)].insertaDato(Nodos[lugarLista(nodo)].Claves[i], Nodos[lugarLista(nodo)].Apuntadores1[i]);
                }
                if (!buscapredecesor(nodo, vecino))
                    Nodos[lugarLista(vecino)].Apuntadores1[Nodos[lugarLista(vecino)].Apuntadores1.Count - 1] = Nodos[lugarLista(nodo)].Apuntadores1[Nodos[lugarLista(nodo)].Apuntadores1.Count - 1];

                SobreEscribeNodo(Nodos[lugarLista(vecino)]);
            }
            else
            {
                for (int i = 0; i < Nodos[lugarLista(nodo)].Claves.Count; i++)
                {
                    Nodos[lugarLista(vecino)].insertaDato(Nodos[lugarLista(nodo)].Claves[i], Nodos[lugarLista(nodo)].Apuntadores1[i + 1]);
                }
                Nodos[lugarLista(vecino)].insertaDato(k, Nodos[lugarLista(nodo)].Apuntadores1[0]); //Nodos[lugarLista(nodo)].Apuntadores1.Count-1

                SobreEscribeNodo(Nodos[lugarLista(vecino)]);
            }
            borra_entrada(buscaPapa(nodo), k, nodo);
        }
        public int contador()
        {
            int cnt = 0;
            for (int i = 0; i < Nodos.Count; i++)
            {
                if (Nodos[i].Tipo == 'R' || Nodos[i].Tipo == 'I')
                    cnt++;
            }
            return cnt;
        }

        public void Redistribuye(long nodo, string k, long vecino)
        {
            if (buscapredecesor(nodo, vecino))
            {
                if (Nodos[lugarLista(nodo)].Tipo != 'H')
                {
                    long m = (Nodos[lugarLista(vecino)].Apuntadores1[Nodos[lugarLista(vecino)].Apuntadores1.Count - 1]);
                    // Nodos[lugarLista(nodo)].Apuntadores1[Nodos[lugarLista(nodo)].Apuntadores1.Count - 1] = (Nodos[lugarLista(vecino)].Apuntadores1[Nodos[lugarLista(vecino)].Apuntadores1.Count - 1]);
                    Nodos[lugarLista(vecino)].borraEntrada(Nodos[lugarLista(vecino)].Claves[Nodos[lugarLista(vecino)].Claves.Count - 1], Nodos[lugarLista(vecino)].Apuntadores1[Nodos[lugarLista(vecino)].Apuntadores1.Count - 1]);
                    Nodos[lugarLista(nodo)].insertaDato(k, m);

                    long padre = buscaPapa(nodo);
                    string ja = buscaClavePapa(nodo, vecino);
                    int indx = Nodos[lugarLista(padre)].Claves.IndexOf(ja);
                    Nodos[lugarLista(padre)].Claves[indx] = k;
                    SobreEscribeNodo(Nodos[lugarLista(vecino)]);
                    SobreEscribeNodo(Nodos[lugarLista(padre)]);
                }
                else
                {
                    string mk = (Nodos[lugarLista(vecino)].Claves[Nodos[lugarLista(vecino)].Claves.Count - 1]);
                    long mp = (Nodos[lugarLista(vecino)].Apuntadores1[Nodos[lugarLista(vecino)].Apuntadores1.Count - 2]);
                    Nodos[lugarLista(vecino)].borraEntrada(mk, mp);
                    Nodos[lugarLista(nodo)].insertaDato(mk, mp);

                    long padre = buscaPapa(nodo);
                    string ja = buscaClavePapa(nodo, vecino);
                    int indx = Nodos[lugarLista(padre)].Claves.IndexOf(ja);
                    Nodos[lugarLista(padre)].Claves[indx] = Nodos[lugarLista(nodo)].Claves[0];
                    SobreEscribeNodo(Nodos[lugarLista(vecino)]);
                    SobreEscribeNodo(Nodos[lugarLista(padre)]);
                }
            }
            else
            {
                if (Nodos[lugarLista(nodo)].Tipo != 'H')
                {
                    long m = (Nodos[lugarLista(vecino)].Apuntadores1[0]);
                    // Nodos[lugarLista(nodo)].Apuntadores1[Nodos[lugarLista(nodo)].Apuntadores1.Count - 1] = (Nodos[lugarLista(vecino)].Apuntadores1[Nodos[lugarLista(vecino)].Apuntadores1.Count - 1]);
                    Nodos[lugarLista(vecino)].borraEntrada(Nodos[lugarLista(vecino)].Claves[0], Nodos[lugarLista(vecino)].Apuntadores1[0]);
                    Nodos[lugarLista(nodo)].insertaDato(k, m);

                    long padre = buscaPapa(nodo);
                    string ja = buscaClavePapa(nodo, vecino);
                    int indx = Nodos[lugarLista(padre)].Claves.IndexOf(ja);
                    Nodos[lugarLista(padre)].Claves[indx] = k;
                    SobreEscribeNodo(Nodos[lugarLista(vecino)]);
                    SobreEscribeNodo(Nodos[lugarLista(padre)]);
                }
                else
                {
                    string mk = (Nodos[lugarLista(vecino)].Claves[0]);
                    long mp = (Nodos[lugarLista(vecino)].Apuntadores1[0]);
                    Nodos[lugarLista(vecino)].borraEntrada(mk, mp);
                    Nodos[lugarLista(nodo)].insertaDato(mk, mp);

                    long padre = buscaPapa(nodo);
                    string ja = buscaClavePapa(nodo, vecino);
                    int indx = Nodos[lugarLista(padre)].Claves.IndexOf(ja);
                    Nodos[lugarLista(padre)].Claves[indx] = Nodos[lugarLista(nodo)].Claves[0];
                    SobreEscribeNodo(Nodos[lugarLista(vecino)]);
                    SobreEscribeNodo(Nodos[lugarLista(padre)]);
                }
            }
            //Nodos.Remove(Nodos[lugarLista(nodo)]);
        }

        public void escribetodo()
        {

            for (int i = 0; i < Nodos.Count; i++)
            {
                SobreEscribeNodo(Nodos[i]);
            }

        }

        public string buscaClavePapa(long nodo1, long nodo2)
        {
            string k = "";
            long padre = buscaPapa(nodo1);
            int indx = Nodos[lugarLista(padre)].Apuntadores1.IndexOf(nodo1);
            int indx2 = Nodos[lugarLista(padre)].Apuntadores1.IndexOf(nodo2);
            if (indx < indx2)
            {
                if (indx == -1)
                {
                    k = Nodos[lugarLista(padre)].Claves[indx2];
                }
                else
                {
                    k = Nodos[lugarLista(padre)].Claves[indx];
                }
            }
            else
            {
                if (indx2 == -1)
                {
                    k = Nodos[lugarLista(padre)].Claves[indx];
                }
                else
                {
                    k = Nodos[lugarLista(padre)].Claves[indx2];
                }
            }
            return k;
        }

        public bool buscapredecesor(long nodo1, long nodo2)
        {
            bool k;
            long padre = buscaPapa(nodo1);
            int indx = Nodos[lugarLista(padre)].Apuntadores1.IndexOf(nodo1);
            int indx2 = Nodos[lugarLista(padre)].Apuntadores1.IndexOf(nodo2);
            if (indx < indx2)
            {
                k = true;
            }
            else
            {
                k = false;
            }
            return k;
        }

        public void fucionaNodos(long Nodo1, long Nodo2)
        {
            for (int i = 0; i < Nodos[lugarLista(Nodo1)].Claves.Count - 1; i++)
            {
                Nodos[lugarLista(Nodo2)].Claves.Insert(i, Nodos[lugarLista(Nodo1)].Claves[i]);
                Nodos[lugarLista(Nodo2)].Apuntadores1.Insert(i, Nodos[lugarLista(Nodo1)].Apuntadores1[i]);
            }

        }

        public void fucionaNodosPadre(long Nodo1, long Nodo2, bool der)
        {
            if (der)
            {
                for (int i = 0; i < Nodos[lugarLista(Nodo1)].Claves.Count - 1; i++)
                {
                    Nodos[lugarLista(Nodo2)].Claves.Insert(i, Nodos[lugarLista(Nodo1)].Claves[i]);
                    Nodos[lugarLista(Nodo2)].Apuntadores1.Insert(i, Nodos[lugarLista(Nodo1)].Apuntadores1[i]);
                }
            }
            else
            {
                for (int i = 0; i < Nodos[lugarLista(Nodo2)].Claves.Count - 1; i++)
                {
                    Nodos[lugarLista(Nodo1)].Claves.Insert(Nodos[lugarLista(Nodo1)].Claves.Count - 1, Nodos[lugarLista(Nodo2)].Claves[i]);
                    Nodos[lugarLista(Nodo1)].Apuntadores1.Insert(Nodos[lugarLista(Nodo1)].Claves.Count - 2, Nodos[lugarLista(Nodo2)].Apuntadores1[i]);
                }
            }
        }

        public long buscaVecino(long nodo, string k)
        {
            long vecino = -1;
            if (Nodos[lugarLista(nodo)].Tipo == 'H')
            {
                if (lugarLista(Nodos[lugarLista(nodo)].Apuntadores1[Nodos[lugarLista(nodo)].Apuntadores1.Count - 1]) != -1)
                {
                    if (Nodos[lugarLista(Nodos[lugarLista(nodo)].Apuntadores1[Nodos[lugarLista(nodo)].Apuntadores1.Count - 1])].Apuntadores1.Count > 2)
                    {
                        vecino = Nodos[lugarLista(nodo)].Apuntadores1[Nodos[lugarLista(nodo)].Apuntadores1.Count - 1];
                    }
                    else
                    {
                        long padre = buscaPapa(nodo);
                        int index = Nodos[lugarLista(padre)].Claves.IndexOf(k);
                        if (Nodos[lugarLista(padre)].Apuntadores1[index] != Nodos[lugarLista(nodo)].Apuntadores1[Nodos[lugarLista(nodo)].Apuntadores1.Count - 1])
                        {
                            vecino = Nodos[lugarLista(padre)].Apuntadores1[index];
                        }
                    }
                }
            }
            else
            {
                long padre = buscaPapa(nodo);
                if (padre != -1)
                {
                    int index = Nodos[lugarLista(padre)].Claves.IndexOf(k);
                    if (index != -1)
                    {
                        if (Nodos[lugarLista(padre)].Apuntadores1[index] != Nodos[lugarLista(nodo)].Apuntadores1[Nodos[lugarLista(nodo)].Apuntadores1.Count - 1])
                        {
                            vecino = Nodos[lugarLista(padre)].Apuntadores1[index];
                        }
                        else
                        {
                            vecino = Nodos[lugarLista(padre)].Apuntadores1[index + 1];
                        }
                    }
                }
            }

            return vecino;
        }
        public long buscaVecino(long nodo, string k, bool t)
        {
            long vecino = -1;
            if (Nodos[lugarLista(nodo)].Tipo == 'H')
            {
                if (Nodos[lugarLista(nodo)].Apuntadores1[Nodos[lugarLista(nodo)].Apuntadores1.Count - 1] != -1)
                {
                    vecino = Nodos[lugarLista(nodo)].Apuntadores1[Nodos[lugarLista(nodo)].Apuntadores1.Count - 1];
                }
                else
                {
                    long padre = buscaPapa(nodo);
                    int index = Nodos[lugarLista(padre)].Apuntadores1.IndexOf(nodo);
                    if (Nodos[lugarLista(padre)].Apuntadores1[index - 1] != Nodos[lugarLista(nodo)].Apuntadores1[Nodos[lugarLista(nodo)].Apuntadores1.Count - 1])
                    {
                        vecino = Nodos[lugarLista(padre)].Apuntadores1[index - 1];
                    }
                    else
                    {
                        vecino = Nodos[lugarLista(padre)].Apuntadores1[index];
                    }
                }
            }
            else
            {
                long padre = buscaPapa(nodo);
                if (padre != -1)
                {
                    int index = Nodos[lugarLista(padre)].Apuntadores1.IndexOf(nodo);
                    if (index != -1)
                    {
                        if (Nodos[lugarLista(padre)].Apuntadores1[index] != Nodos[lugarLista(nodo)].Apuntadores1[Nodos[lugarLista(nodo)].Apuntadores1.Count - 1])
                        {
                            vecino = Nodos[lugarLista(padre)].Apuntadores1[index - 1];
                        }
                        else
                        {
                            vecino = Nodos[lugarLista(padre)].Apuntadores1[index];
                        }
                    }
                }
            }

            if (vecino == -1 && Nodos[lugarLista(nodo)].Apuntadores1[Nodos[lugarLista(nodo)].Apuntadores1.Count - 1] != -1)
            {
                vecino = Nodos[lugarLista(nodo)].Apuntadores1[Nodos[lugarLista(nodo)].Apuntadores1.Count - 1];
            }
            if (!existeDir(vecino) && Nodos[lugarLista(nodo)].Apuntadores1[Nodos[lugarLista(nodo)].Apuntadores1.Count - 1] != -1)
            {
                vecino = 65;
            }

            return vecino;
        }
        public bool existeDir(long dir)
        {
            bool a = false;

            for (int i = 0; i < Nodos.Count; i++)
            {
                if (dir == Nodos[i].DirNodo1)
                    return true;
            }
            return a;
        }

        //Metodos Para el secundario
        public bool existe(string k)
        {
            bool res = false;

            long nodo = buscaNodoHoja(k, -1, true);

            for (int i = 0; i < Nodos.Count; i++)
            {
                if (Nodos[i].Claves.Contains(k) && Nodos[i].Tipo == 'H')
                {
                    res = true;
                }
            }

            return res;
        }
        public long regresaDirLista(string k)
        {
            long res = -1;

            long nodo = buscaNodoHoja(k, -1, true);

            for (int i = 0; i < Nodos.Count; i++)
            {
                if (Nodos[i].Claves.Contains(k) && Nodos[i].Tipo == 'H')
                {
                    for(int j = 0; j < Nodos[i].Claves.Count; j++)
                    {
                        if (Nodos[i].Claves[j] == k)
                        {
                            res = Nodos[i].Apuntadores1[j];
                            break;
                        }
                    }
                    break;
                }
            }

            return res;
        }
        public void insertaLista(long dir)
        {
            for (int i = 0; i < 256; i++)
            {
                if(secundario[i] == -1)
                {
                    secundario[i] = dir;
                    break;
                }
            }
        }
        public void eliminaLista(long dir)
        {
            for (int i = 0; i < 256; i++)
            {
                if (secundario[i] == dir)
                {
                    secundario[i] = -1;
                    break;
                }
            }
        }
        public void inicializa()
        {
            secundario.Clear();
            for (int i = 0; i < 256; i++)
            {
                secundario[i] = -1;
            }
        }
        public void escribeSC()
        {
            using (archivo = new FileStream(nombreArch, FileMode.Open))
            {
                archivo.Position = dirActual;
                using (BinaryWriter bw = new BinaryWriter(archivo))
                {
                    for (int i = 0; i < 256; i++)
                    {
                        bw.Write(secundario[i]);
                    }
                }
            }
            archivo.Close();
            dirActual += 2048;
        }
        public void leeSC(long dir)
        {
            secundario.Clear();
            using (archivo = new FileStream(nombreArch, FileMode.Open))
            {
                archivo.Position = dir;
                using (BinaryReader rw = new BinaryReader(archivo))
                {
                    for (int i = 0; i < 256; i++)
                    {
                        secundario.Add(rw.ReadInt64()); ;

                    }

                }
            }
        }
    }
}
