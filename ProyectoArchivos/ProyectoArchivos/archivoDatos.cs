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
        private List<byte[]> datosByte;
        private List<string> datos;
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
            inicializaDat();
        }

        public void escribeDato(Int64 direccion, List<string> registro)
        {
            datos = new List<string>(registro);
            codifica();

            using (archivo = new FileStream(NombreArch, FileMode.Open))
            {
                archivo.Position = dir;
                using (BinaryWriter bw = new BinaryWriter(archivo))
                {
                    for (int i = 0; i < datosByte.Count; i++)
                    {
                        bw.Write(datosByte[i]);
                    }
                }
            }
            dir += longitudtotal;
            archivo.Close();
        }

        public List<List<string>> leeDatos(long dirPriDat)
        {
            int i;
            List<List<string>> todos = new List<List<string>>();
            long aux = -1;
            long posicion = dirPriDat;
            while (dirPriDat != aux)
            {
                using (archivo = new FileStream(NombreArch, FileMode.Open))
                {
                    archivo.Position = posicion;
                    if (posicion != aux)
                    {
                        using (BinaryReader br = new BinaryReader(archivo))
                        {
                            datosByte[0] = br.ReadBytes(8);
                            for (i = 0; i < ListaAtrib.Count; i++)
                            {
                                datosByte[i + 1] = br.ReadBytes(ListaAtrib[i].LongAt);
                            }
                            datosByte[i + 1] = br.ReadBytes(8); ;

                        }
                        posicion += longitudtotal;
                        todos.Add(decodifica());
                    }
                }
            }
            return todos;
        }
        public List<string> decodifica()
        {
            List<string> aux = new List<string>();
            for (int i = 0; i < datosByte.Count; i++)
            {
                aux.Add( Encoding.ASCII.GetString(datosByte[i]));
            }
            return aux;
        }
        public void codifica()
        {
            for(int i = 0; i < datosByte.Count; i++)
            {
                datosByte[i] = Encoding.ASCII.GetBytes(datos[i]);
            }
        }
        public void inicializaDat()
        {
            datos = new List<string>();
            datosByte = new List<byte[]>();
            datosByte.Add(new byte[8]);
            datos.Add("-1");
            for(int i = 0; i < ListaAtrib.Count; i++)
            {
                datosByte.Add(new byte[ListaAtrib[i].LongAt]);
                datos.Add("");
            }
            datosByte.Add(new byte[8]);
            datos.Add("-1");
        }
        public void ObtenLongitud()
        {
            longitudtotal = 8;
            for(int i = 0; i < ListaAtrib.Count; i++)
            {
                longitudtotal += ListaAtrib[i].LongAt;
            }
            longitudtotal += 8;
        }
    }
}
