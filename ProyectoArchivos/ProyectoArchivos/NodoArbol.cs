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

        public NodoArbol(char t,Int64 dir, int g,int tam)
        {
            tipo = t;
            longitudCve = tam;
            DirNodo = dir;
            nodoBytes = new List<byte[]>();
            Apuntadores = new List<Int64>();
            claves = new List<String>();
            inicializaListas(g);
            inicializaBytes(g);
        }
        public void inicializaListas(int grado)
        {
            Apuntadores.Add(-1);
            for(int i =0; i < grado - 1; i++)
            {
                Apuntadores.Add(-1);
                claves.Add("");
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
            Encoding.ASCII.GetBytes(tipo.ToString(),0, 1, nodoBytes[0], 0);
            Encoding.ASCII.GetBytes(Apuntadores[0].ToString(), 0, Apuntadores[0].ToString().Length, nodoBytes[1], 0);
            for(int i =0; i < claves.Count; i++)
            {
                Encoding.ASCII.GetBytes(claves[i].ToString(), 0, claves[i].ToString().Length, nodoBytes[cnt], 0);
                cnt++;
                Encoding.ASCII.GetBytes(Apuntadores[i+1].ToString(), 0, Apuntadores[0].ToString().Length, nodoBytes[cnt], 0);
                cnt++;
            }
        }
        public void actualizaDatos()
        {
            int cnt = 2;
            tipo = Convert.ToChar(Encoding.ASCII.GetString(nodoBytes[0]));
            DirNodo = Convert.ToInt64(Encoding.ASCII.GetString(nodoBytes[1]));
            for (int i = 0; i < claves.Count; i++)
            {
                claves[cnt] = Encoding.ASCII.GetString(nodoBytes[cnt]);
                cnt++;
                Apuntadores[cnt] = Convert.ToInt64(Encoding.ASCII.GetString(nodoBytes[cnt]));
                cnt++;
            }
        }
    }
}
