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
            Apuntadores1 = new List<Int64>();
            Apuntadores1.Add(-1);
            Claves = new List<String>();
        }
        public long buscaDato(string dat)
        {
            long aux = -1;
            if(tipo == 'I' || tipo == 'R')
            {
                for(int i = 0; i < claves.Count; i++)
                {
                    if (longitudCve > 4)
                    {
                        if (claves[i].Replace("\0", "").CompareTo(dat) < 0)
                        {
                            aux = Apuntadores[i];
                            break;
                        } else
                        {
                            if (claves[i].Replace("\0", "").CompareTo(dat) == 0)
                                {
                                    aux = Apuntadores[i+1];
                                    break;
                                }
                        }
                    }else
                    {
                        if(Convert.ToInt32(claves[i].Replace("\0","")) < Convert.ToInt32(dat))
                        {
                            aux = Apuntadores[i];
                            break;
                        }
                        else
                        {
                            if (Convert.ToInt32(claves[i].Replace("\0", "")) == Convert.ToInt32(dat))
                            {
                                aux = Apuntadores[i + 1];
                                break;
                            }
                        }
                    }
                }
            }else
            {
                for (int i = 0; i < claves.Count; i++)
                {
                    if (longitudCve > 4)
                    {
                        if (claves[i].Replace("\0", "").CompareTo(dat) == 0)
                            {
                                aux = DirNodo;
                                break;
                            }
                    }
                    else
                    {
                        if (Convert.ToInt32(claves[i].Replace("\0", "")) == Convert.ToInt32(dat))
                            {
                                aux = DirNodo;
                                break;
                            }
                    }
                }
            }
            return aux;
        }
        public long buscaDato2(string dat)
        {
            long aux = -1;
            if (tipo == 'I' || tipo == 'R')
            {
                for (int i = 0; i < claves.Count; i++)
                {
                    if (longitudCve > 4)
                    {
                        if (claves[i].Replace("\0", "").CompareTo(dat) < 0)
                        {
                            aux = Apuntadores[i+1];
                            break;
                        }
                        else
                        {
                            aux = Apuntadores[i];
                        }
                    }
                    else
                    {
                        
                        if (Convert.ToInt32(claves[i].Replace("\0", "")) < Convert.ToInt32(dat))
                        {
                            aux = Apuntadores[i+1];
                            break;
                        }else
                        {
                            aux = Apuntadores[i];
                        }
                    }
                }
            }
            else
            {
                for (int i = 0; i < claves.Count; i++)
                {
                    if (longitudCve > 4)
                    {
                            aux = DirNodo;
                            break;
                    }
                    else
                    {
                            aux = DirNodo;
                            break;
                    }
                }
            }
            return aux;
        }
        public void insertaDato(string dat, Int64 apun)
        {
            if (tipo == 'H')
            {
                if(claves.Count == 0)
                {
                    claves.Add(dat);
                    Apuntadores.Insert(0, apun);
                    return;
                }
                
                for (int i = 0; i < Claves.Count; i++)
                {
              
                    if (longitudCve > 4)
                    {
                        if (claves[i].Replace("\0", "").CompareTo(dat) > 0)
                        {
                            Claves.Insert(i,dat);
                            Apuntadores.Insert(i, apun);
                            break;
                        }else
                        {
                            Claves.Add(dat);
                            Apuntadores.Insert(Apuntadores.Count-2, apun);
                            break;
                        }
                    }
                    else
                    {
                        if (Convert.ToInt32(claves[i].Replace("\0", "")) > Convert.ToInt32(dat))
                        {
                            Claves.Insert(i, dat);
                            Apuntadores.Insert(i, apun);
                            break;
                        }else
                        {
                            if(i == Claves.Count - 1)
                            {
                                Claves.Add(dat);
                                Apuntadores.Insert(Apuntadores.Count - 1, apun);
                                break;
                            }
                        }
                    }
                }
            }else
            {
                for (int i = 0; i < Claves.Count; i++)
                {
                    if (longitudCve > 4)
                    {
                        if (claves[i].Replace("\0", "").CompareTo(dat) > 0)
                        {
                            Claves.Insert(i, dat);
                            Apuntadores.Insert(i+1, apun);
                            break;
                        }
                    }
                    else
                    {
                        if (Convert.ToInt32(claves[i].Replace("\0", "")) > Convert.ToInt32(dat))
                        {
                            Claves.Insert(i, dat);
                            Apuntadores.Insert(i+1, apun);
                            break;
                        }
                        if(i == Claves.Count - 1)
                        {
                                Claves.Add(dat);
                                Apuntadores.Add(apun);
                            break;
                        }
                        
                    }
                }
            }
        }
        
        public bool hayEspacio()
        {
            if (claves.Count < 4)
                return true;
            return false;
        }
        public bool limpiaMitad(string dat)
        {
            bool der = false; 
            if (tipo == 'I')
            {
                if (Convert.ToInt32(claves[1]) < Convert.ToInt32(dat))
                {
                    Claves.RemoveAt(2);
                    Claves.RemoveAt(2);
                    Apuntadores.RemoveAt(3);
                    Apuntadores.RemoveAt(3);
                }
                else
                {
                    Claves.RemoveAt(1);
                    Claves.RemoveAt(1);
                    Claves.RemoveAt(1);
                    Apuntadores.RemoveAt(3);
                    Apuntadores.RemoveAt(3);
                    der = true;
                }
            }
            else
            {
                if (Convert.ToInt32(claves[1]) < Convert.ToInt32(dat))
                {
                    Claves.RemoveAt(2);
                    Claves.RemoveAt(2);
                    Apuntadores.RemoveAt(2);
                    Apuntadores.RemoveAt(2);
                }else
                {
                    Claves.RemoveAt(1);
                    Claves.RemoveAt(1);
                    Claves.RemoveAt(1);
                    Apuntadores.RemoveAt(1);
                    Apuntadores.RemoveAt(1);
                    Apuntadores.RemoveAt(1);
                    der = true;
                }
            }
            return der;
        }

        public void recorreDatos(bool izq)
        {
            if (tipo == 'I' || tipo == 'R')
            {
                if (izq)
                {
                    Claves.RemoveAt(0);
                    Claves.RemoveAt(0);
                    Apuntadores.RemoveAt(1);
                    Apuntadores.RemoveAt(1);
                }
                else
                {
                    Claves.RemoveAt(1);
                    Claves.RemoveAt(1);
                    Claves.RemoveAt(1);
                    Apuntadores.RemoveAt(2);
                    Apuntadores.RemoveAt(2);
                    Apuntadores.RemoveAt(2);
                }
            }
            else
            {
                if (izq)
                {
                    Claves.RemoveAt(0);
                    Claves.RemoveAt(0);
                    Apuntadores.RemoveAt(0);
                    Apuntadores.RemoveAt(0);
                }
                else
                {
                    
                    Claves.RemoveAt(0);
                    Apuntadores.RemoveAt(0);
                }
            }
        }

        public void borraEntrada(string dat,long pointer)
        {
            Apuntadores.Remove(pointer);
            Claves.Remove(dat);
        }
        
    }
}
