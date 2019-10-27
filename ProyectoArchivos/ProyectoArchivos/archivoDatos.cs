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

        public void scribeDato(Int64 direccion, List<string> registro)
        {
            datos = new List<string>(registro);
            codifica();
            using (archivo = new FileStream(NombreArch, FileMode.Open))
            {
                archivo.Position = direccion;
                using (BinaryWriter bw = new BinaryWriter(archivo))
                {
                    for (int i = 0; i < datosByte.Count; i++)
                    {
                        bw.Write(datosByte[i]);
                    }
                }
            }
            archivo.Close();
        }

        public List<List<string>> leeDatos(long dirPriDat)
        {
            int i,j=0;
            List<List<string>> todos = new List<List<string>>();
            long aux = -1;

            while (dirPriDat != aux)
            {
                using (archivo= new FileStream(NombreArch, FileMode.Open))
                {
                    archivo.Position = dirPriDat;
                    using (BinaryReader br = new BinaryReader(archivo))
                    {
                        for(i= 0; i < datosByte.Count; i++)
                        {
                            datosByte[i]=br.ReadBytes(datosByte[i].Length);
                        }
                        todos.Add(new List<string>(decodifica()));
                    }
                    dirPriDat = Convert.ToInt64(todos[j][todos[j].Count-1]);
                    j++;

                }
            }
            return todos;
        }
        public List<string> decodifica()
        {
            List<string> aux = new List<string>();
            for (int i = 0; i < datosByte.Count; i++)
            {
                aux.Add(Encoding.ASCII.GetString(datosByte[i]));
            }
            return aux;
        }
        public void codifica()
        {
            for (int i = 0; i < datosByte.Count; i++)
            {
                Encoding.ASCII.GetBytes(datos[i],0,datos[i].Length,datosByte[i],0);
            }
        }

       
        public void inicializaDat()
        {
            datos = new List<string>();
            datosByte = new List<byte[]>();
            datosByte.Add(new byte[8]);
            datos.Add("-1");
            for (int i = 0; i < ListaAtrib.Count; i++)
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
            for (int i = 0; i < ListaAtrib.Count; i++)
            {
                longitudtotal += ListaAtrib[i].LongAt;
            }
            longitudtotal += 8;
        }
    }
}
