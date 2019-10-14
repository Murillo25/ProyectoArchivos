using System;
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
        //Cabecera del archivo
        public static long dir;
        //Listas para guardar datos en las datagridview
        private List<Byte> Lista;
        //Variable del tamaño del archivo
        private long tamaño;
    }
}
