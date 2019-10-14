using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoArchivos
{
    class ArchivoIndicePri
    {
        //Variable necesaria para abrir el archivo 
        private FileStream archivo;
        //Nombre del archivo
        private String nombreArch;
        //Listas para guardar datos en las datagridview
        private List<List<byte[]>> ListaDir;
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

        public ArchivoIndicePri(string name, int tam)
        {
            nombreArch = name;
            tamañoCve = tam;
            calculaBloque();
            ListaDir = new List<List<byte[]>>();
            Listaview1 = new List<string>();
            ListaDir.Add(new List<byte[]>());
            GeneraLista(true);
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
            for (int i = 1; i < ListaDir[0].Count-aux; i+=2)
            {
                ListaDir[0][i] = Encoding.ASCII.GetBytes("-1");
            }
                
        }

        private void ActualizaLista()
        {
            for (int i = 0; i < Listaview1.Count; i++)
            {
                ListaDir[0][i] = Encoding.ASCII.GetBytes(Listaview1[i]);
            }
        }

        private void escribeLista()
        {
            using (Archivo = new FileStream(NombreArch, FileMode.Open))
            {
                Archivo.Position = 0;
                using (BinaryWriter bw = new BinaryWriter(Archivo))
                {
                    for (int i = 0; i < ListaDir[0].Count; i++)
                    {
                        bw.Write(ListaDir[0][i]);
                    }
                }
            }
            Archivo.Close();
        }

        private void leeLista()
        {
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
        private void calculaBloque()
        {
            numBloqus = 2040 / (tamañoCve + 8);
            desperdicio = 2040 % (tamañoCve + 8);
        }

    }
}
