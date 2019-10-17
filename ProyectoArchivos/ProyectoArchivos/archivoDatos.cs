using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoArchivos
{
    class archivoDatos
    {
        private FileStream archivo;
        //Nombre del archivo
        private String nombreArch;
        private int longitudtotal;
        public static long dir;
        //Listas para guardar datos en las datagridview
        private List<Atributo> ListaAtrib;
        private List<List<string>> datos;
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
        public int Longitudtotal
        {
            get
            {
                return longitudtotal;
            }

            set
            {
                longitudtotal = value;
            }
        }

        public archivoDatos(string nombre, List<Atributo> copia)
        {
            nombreArch = nombre;
            ListaAtrib = new List<Atributo>(copia);
            ObtenLongitud();
            dir = 0;
        }

        public void ObtenLongitud()
        {
            longitudtotal = 0;
            for(int i = 0; i < ListaAtrib.Count; i++)
            {
                longitudtotal += ListaAtrib[i].LongAt;
            }
        }
    }
}
