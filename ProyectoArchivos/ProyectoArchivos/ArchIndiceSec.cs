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
        public FileStream archivo;
        //Nombre del archivo
        public int numBloqus, tamañoCve, desperdicio;
        public String nombreArch;
        public List<byte[]> bloquePrin;
        public List<string> bloque_vista;
        public List<List<byte[]>> secundario;
        public List<List<string>> secundario_vista;

        public ArchIndiceSec(String name, int tam)
        {
            nombreArch = name;
            tamañoCve = tam;
            calculaBloque();
            bloquePrin = new List<byte[]>();
            bloque_vista = new List<string>();
            secundario = new List<List<byte[]>>();
            secundario_vista = new List<List<string>>();
            GenerabloquePrin();
        }

        public bool existeCve(string clave)
        {
            bool ret = false;
            int j = 0;
            for (int i = 0; i < numBloqus; i++)
            {
                if (bloque_vista[j].Replace("\0", "").Equals(clave))
                {
                    ret = true;
                    break;
                }
                else
                {
                    if (bloque_vista[j + 1].Replace("\0", "").Equals("-1"))
                        break;
                }
                j += 2;
            }
            return ret;
        }

        public string regresaDirecSC(string clave)
        {
            int j = 0;
            string direc = "";
            for (int i = 0; i < numBloqus; i++)
            {
                if (bloque_vista[j].Replace("\0", "").Equals(clave))
                {
                    direc = bloque_vista[j + 1];
                    break;
                }
                j += 2;
            }
            return direc;
        }

        public int regresaPosBP(string clave)
        {
            int pos = -1;
            int j = 0;
            for (int i = 0; i < numBloqus; i++)
            {
                if (bloque_vista[j + 1].Replace("\0", "").Equals("-1"))
                {
                    pos = j;
                    break;
                } else
                {
                    if (tamañoCve == 4)
                    {
                        if (Convert.ToInt32(bloque_vista[j].Replace("\0", "").ToString()).CompareTo(Convert.ToInt32(clave)) > 0)
                        {
                            pos = j;
                            break;
                        }
                    }
                    else
                    {
                        if (bloque_vista[j].Replace("\0", "").ToString().CompareTo(clave) > 0)
                        {
                            pos = j;
                            break;
                        }
                    }
                }
                j++;
                j++;
            }

            return pos;
        }

        public void insertaEnBP(string cve, string dirDato)
        {
            if (existeCve(cve))
            {
                string dirSC = regresaDirecSC(cve);
                int lugarSC = Convert.ToInt32(dirSC) / 2048;
                insertaEnSC(lugarSC, dirDato);
            } else
            {
                int numDatos = cuentaDatosBP() + 1;
                int poscion = regresaPosBP(cve);
                bloque_vista.Insert(poscion, cve);
                bloque_vista.Insert(poscion + 1, (numDatos * 2048).ToString());
                generaListSC();
                secundario_vista[secundario_vista.Count - 1][0] = dirDato;
            }

            actualizaBytesBP();
            actualizaBytesSC();
        }

        public void generaListSC()
        {
            secundario.Add(new List<byte[]>());
            secundario_vista.Add(new List<string>());
            for (int i = 0; i < 256; i++)
            {
                secundario[secundario.Count - 1].Add(new byte[8]);
                secundario_vista[secundario_vista.Count - 1].Add("-1");
            }
        }

        public void generaTodasListSC()
        {
            for (int i = 0; i < cuentaDatosBP(); i++)
            {
                secundario_vista.Add(new List<string>());
                for (int j = 0; j < 256; j++)
                {
                    secundario_vista[i].Add("-1");
                }
            }
        }

        public void insertaEnSC(int pos, string dirDato)
        {
            for (int i = 0; i < 256; i++)
            {
                if (secundario_vista[pos - 1][i].Replace("\0", "").Equals("-1"))
                {
                    secundario_vista[pos - 1][i] = dirDato;
                    break;
                }
            }
        }

        public int generaDirecSC()
        {
            return ((cuentaDatosBP() + 1) * 2048);
        }

        public int cuentaDatosBP()
        {
            int j = 1;
            int numdatos = 0;
            for (int i = 0; i < numBloqus; i++)
            {
                if (bloque_vista[j].Replace("\0", "").Equals("-1"))
                {
                    break;
                } else
                {
                    numdatos++;
                }
                j++;
                j++;
            }
            return numdatos;
        }

        public void GenerabloquePrin()
        {
            for (int i = 0; i < numBloqus; i++)
            {
                bloquePrin.Add(new byte[tamañoCve]);
                bloque_vista.Add("");
                bloquePrin.Add(new byte[8]);
                bloque_vista.Add("-1");
            }
            bloquePrin.Add(new byte[8]);
            if (desperdicio > 0)
                bloquePrin.Add(new byte[desperdicio]);
        }

        private void calculaBloque()
        {
            numBloqus = 2040 / (tamañoCve + 8);
            desperdicio = 2040 % (tamañoCve + 8);
        }

        public void escribeBP()
        {
            actualizaBytesBP();
            using (archivo = new FileStream(nombreArch, FileMode.Open))
            {
                archivo.Position = 0;
                int i, j = 0; ;
                using (BinaryWriter bw = new BinaryWriter(archivo))
                {
                    for (i = 0; i < numBloqus; i++)
                    {
                        bw.Write(bloquePrin[j], 0, tamañoCve);
                        bw.Write(bloquePrin[j + 1], 0, 8);
                        j += 2;
                    }
                    bw.Write(bloquePrin[j], 0, 8);
                    if (desperdicio > 0)
                    {
                        bw.Write(new byte[desperdicio]);
                    }
                }
            }
            archivo.Close();
        }

        public void actualizaBytesBP()
        {
            int j = 0;
            for (int i = 0; i < numBloqus; i++)
            {
                bloquePrin[j] = new byte[tamañoCve];
                Encoding.ASCII.GetBytes(bloque_vista[j], 0, bloque_vista[j].Length, bloquePrin[j], 0);
                j++;
                bloquePrin[j] = new byte[8];
                Encoding.ASCII.GetBytes(bloque_vista[j], 0, bloque_vista[j].Length, bloquePrin[j], 0);
                j++;
            }
        }

        public void actualizaStringBP()
        {
            int j = 0;
            for (int i = 0; i < numBloqus; i++)
            {
                bloque_vista[j] = "";
                bloque_vista[j] = Encoding.ASCII.GetString(bloquePrin[j]);
                j++;
                bloque_vista[j] = "";
                bloque_vista[j] = Encoding.ASCII.GetString(bloquePrin[j]);
                j++;
            }
        }

        public void leeBP()
        {
            int j = 0;
            using (archivo = new FileStream(nombreArch, FileMode.Open))
            {
                archivo.Position = 0;
                using (BinaryReader rw = new BinaryReader(archivo))
                {
                    for (int i = 0; i < numBloqus; i++)
                    {
                        bloquePrin[j] = rw.ReadBytes(tamañoCve);
                        bloquePrin[j + 1] = rw.ReadBytes(8);
                        j += 2;
                    }
                    bloquePrin[j] = rw.ReadBytes(8);
                    j++;
                    if (desperdicio > 0)
                        bloquePrin[j] = rw.ReadBytes(8);
                }
            }
            archivo.Close();
            actualizaStringBP();
        }

        public void actualizaBytesSC()
        {
            for (int i = 0; i < cuentaDatosBP(); i++)
            {
                for (int j = 0; j < 256; j++)
                {
                    secundario[i][j] = new byte[8];
                    Encoding.ASCII.GetBytes(secundario_vista[i][j], 0, secundario_vista[i][j].Length, secundario[i][j], 0);
                }
            }
        }

        public void actualizaStringSC()
        {
            for (int i = 0; i < cuentaDatosBP(); i++)
            {
                for (int j = 0; j < 256; j++)
                {
                    secundario_vista[i][j] = "";
                    secundario_vista[i][j] = Encoding.ASCII.GetString(secundario[i][j]);
                }
            }
        }

        public void escribeSC()
        {
            actualizaBytesSC();
            using (archivo = new FileStream(nombreArch, FileMode.Open))
            {
                archivo.Position = 2048;
                using (BinaryWriter bw = new BinaryWriter(archivo))
                {
                    for (int i = 0; i < cuentaDatosBP(); i++)
                    {
                        for (int j = 0; j < 256; j++)
                        {
                            bw.Write(secundario[i][j]);
                        }
                    }
                }
            }
            archivo.Close();
        }

        public void leeSC()
        {
            secundario.Clear();
            secundario_vista.Clear();
            using (archivo = new FileStream(nombreArch, FileMode.Open))
            {
                archivo.Position = 2048;
                using (BinaryReader rw = new BinaryReader(archivo))
                {
                    for (int i = 0; i < cuentaDatosBP(); i++)
                    {
                        secundario.Add(new List<byte[]>());
                        for (int j = 0; j < 256; j++)
                        {
                            secundario[i].Add(rw.ReadBytes(8));
                        }
                    }
                }
            }
            archivo.Close();
            generaTodasListSC();
            actualizaStringSC();
        }
        
        public void eliminarDato(string clave,string dire)
        {
            string direc = "";
            for (int i = 0; i < bloque_vista.Count; i += 2)
            {
                if (bloque_vista[i].Replace("\0", "").Equals(clave.Replace("\0", "")))
                {
                    direc = bloque_vista[i+1];
                    break;
                }
            }
            int dir = Convert.ToInt32(direc) / 2048;
            secundario_vista[dir - 1].Remove(dire);
            secundario_vista[dir - 1].Add("-1");
            actualizaBytesBP();
            actualizaBytesSC();
            escribeBP();
            escribeSC();

        }
    }
}