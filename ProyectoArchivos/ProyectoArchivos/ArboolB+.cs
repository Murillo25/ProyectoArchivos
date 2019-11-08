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
        private NodoArbol raiz;
        private List<NodoArbol> hojas;
        private List<NodoArbol> intermedios;
        private int dir;

        public ArboolB_(int g, String name)
        {
            dir = 0;
            nombreArch = name;
            grado = g;
            raiz = null;
            hojas = new List<NodoArbol>();
            intermedios = new List<NodoArbol>();
        }

    }
}
