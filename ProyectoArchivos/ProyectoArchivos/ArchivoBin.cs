using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ProyectoArchivos
{
    public class ArchivoBin
    {
        //Variable necesaria para abrir el archivo 
        private FileStream archivo;
        //Nombre del archivo
        private String nombresArch;
        //Cabecera del archivo
        private Int64 cabecera;
        public static long dir ;
        //Listas para guardar datos en las datagridview
        private List<Atributo> atributos;
        private List<Entidad> entidades;
        //Apuntadores auxiliares
        private Int64 posis, posAts, posMayorAt, posMayorAEnt, posMayor;
        //Variable del tamaño del archivo
        private long tamaño;

        public string NombresArch
        {
            get
            {
                return nombresArch;
            }

            set
            {
                nombresArch = value;
            }
        }

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

        public long Cabecera
        {
            get
            {
                return cabecera;
            }

            set
            {
                cabecera = value;
            }
        }

        internal List<Atributo> Atributos
        {
            get
            {
                return atributos;
            }

            set
            {
                atributos = value;
            }
        }

        internal List<Entidad> Entidades
        {
            get
            {
                return entidades;
            }

            set
            {
                entidades = value;
            }
        }

        public long Tamaño
        {
            get
            {
                return tamaño;
            }

            set
            {
                tamaño = value;
            }
        }

        public Int64 PosAts
        {
            get
            {
                return posAts;
            }

            set
            {
                posAts = value;
            }
        }

        public Int64 PosMayorAt
        {
            get
            {
                return posMayorAt;
            }

            set
            {
                posMayorAt = value;
            }
        }

        public Int64 PosMayor
        {
            get
            {
                return posMayor;
            }

            set
            {
                posMayor = value;
            }
        }


        //Constructor de la clase
        public ArchivoBin()
        {
            Entidades = new List<Entidad>();
            Atributos = new List<Atributo>();
            PosMayor = 0;
            PosMayorAt = 0;
            posMayorAEnt = 0;
            Tamaño = 0;
        }

        //Metodo que escribe la entidad en el diccionario de datos
        public void escribeEntidad(Int64 dir, Entidad ent)
        {
            using (Archivo = new FileStream(NombresArch, FileMode.Open))
            {
                Archivo.Position = dir;
                using (BinaryWriter bw = new BinaryWriter(Archivo))
                {
                    int j = 0;
                    bool flag = false;
                    char[] auxC = new char[35];
                    String auxS = ent.NombreEnt;
                    while (j < 30)
                    {
                        if (flag == false)
                        {
                            for (int i = 0; i < auxS.Length; i++)
                            {
                                auxC[j] = auxS[i];
                                j++;
                            }
                            flag = true;
                        }
                        if (j < 35)
                        {
                            auxC[j] = ' ';
                            j++;
                        }
                    }
                    string hex = ent.IdHex;
                    byte[] result = new byte[hex.Length / 2];
                    for (int i = 0; i < hex.Length; i+=2)
                    {
                        result[i / 2] = Convert.ToByte(hex.Substring(i, 2), 16);
                    }
                    for (int i = 0; i < 5; i++)
                    {
                        bw.Write(result[i]);
                    }
                    bw.Write(auxC);
                    bw.Write(ent.DirEnt);
                    bw.Write(ent.DirPriAt);
                    bw.Write(ent.DirDatos);
                    bw.Write(ent.DirSigEnt);
                }
            }
            Archivo.Close();
        }

        //Escribe atributo en el diccionario de datos
        public void escribeAtributo(Int64 dir, Atributo att)
        {
            using (Archivo = new FileStream(NombresArch, FileMode.Open))
            {
                Archivo.Position = dir;
                using (BinaryWriter bw = new BinaryWriter(Archivo))
                {
                    int j = 0;
                    bool flag = false;
                    char[] auxC = new char[35];
                    String auxS = att.NombreAt;
                    while (j < 35)
                    {
                        if (flag == false)
                        {
                            for (int i = 0; i < auxS.Length; i++)
                            {
                                auxC[j] = auxS[i];
                                j++;
                            }
                            flag = true;
                        }
                        if (j < 35)
                        {
                            auxC[j] = ' ';
                            j++;
                        }
                    }
                    string hex = att.IdHex;
                    byte[] result = new byte[hex.Length / 2];
                    for (int i = 0; i < hex.Length; i += 2)
                    {
                        result[i / 2] = Convert.ToByte(hex.Substring(i, 2), 16);
                    }
                    for (int i = 0; i < 5; i++)
                    {
                        bw.Write(result[i]);
                    }
                    bw.Write(auxC);
                    bw.Write(att.TipoAt);
                    bw.Write(att.LongAt);
                    bw.Write(att.TipoIdxAt);
                    bw.Write(att.DirAt);
                    bw.Write(att.DirIndice);
                    bw.Write(att.DirSigAt);
                }
            }
        }

        //Lee el archivo de diccionario de datos
        public bool leeArchivo()
        {
            bool b = false;
            Entidades.Clear();
            if (leeCabecera() == true)
            {
                Int64 aux = -1;
                posis = Cabecera;
                posMayorAEnt = 0;
                while (posis != aux)
                {
                    using (Archivo = new FileStream(NombresArch, FileMode.Open))
                    {
                        Archivo.Position = posis;
                        using (BinaryReader br = new BinaryReader(Archivo))
                        {
                            String auxS = "";
                            String hex = "";
                            byte[] result = new byte[5];
                            for (int i = 0; i < 5; i++)
                            {
                                result[i] += br.ReadByte();
                            }
                            hex = BitConverter.ToString(result).Replace("-", "").ToLower();
                            for (int i = 0; i < 35; i++)
                            {
                                auxS += br.ReadChar();
                            }
                            Int64 dirEnt = br.ReadInt64();
                            Int64 dirAt = br.ReadInt64();
                            Int64 dirD = br.ReadInt64();
                            Int64 dirSEn = br.ReadInt64();
                            String hexa = hex.TrimEnd();
                            String nameS = auxS.TrimEnd();
                            Entidades.Add(new Entidad(hexa,nameS, dirEnt, dirAt, dirD, dirSEn));
                            posis = dirSEn;
                            if (Archivo.Position > posMayorAEnt) posMayorAEnt = Archivo.Position;
                        }
                    }
                }
                leeAtributos();
                if (posMayorAEnt > PosMayorAt) PosMayor = posMayorAEnt;
                else PosMayor = PosMayorAt;
                return true;
            }
            return b;
        }

        //Lee la cabecera
        public bool leeCabecera()
        {
            try
            {
                using (Archivo = new FileStream(NombresArch, FileMode.Open))
                {
                    Archivo.Position = 0;
                    using (BinaryReader br = new BinaryReader(Archivo))
                    {
                        Cabecera = br.ReadInt64();
                        //MessageBox.Show(cabecera + " Posicion: " + archivo.Position);
                        return true;
                    }
                }
            }
            catch
            {
                return false;
            }
        }


        //genera la lista de atributos de la datagridview
        public List<Atributo> leerAts(long dirIniA)
        {
            List<Atributo> listaA = new List<Atributo>();
            long aux = -1;

            while (dirIniA != aux)
            {
                using (Archivo = new FileStream(NombresArch, FileMode.Open))
                {
                    Archivo.Position = dirIniA;
                    using (BinaryReader br = new BinaryReader(Archivo))
                    {
                        String hex = "";
                        String auxS = "";
                        byte[] result = new byte[5];
                        for (int i = 0; i < 5; i++)
                        {
                            result[i] += br.ReadByte();
                        }
                        hex = BitConverter.ToString(result).Replace("-", "").ToLower();
                        char[] cadena = new char[35];
                        cadena = br.ReadChars(35);
                        char tipo = br.ReadChar();
                        Int32 longitud = br.ReadInt32();
                        Int32 tipoIdx = br.ReadInt32();
                        Int64 dirAt = br.ReadInt64();
                        Int64 dirIdx = br.ReadInt64();
                        Int64 dirSAt = br.ReadInt64();
                        for (int j = 0; j < 30; j++)
                        {
                            auxS += cadena[j];
                        }
                        listaA.Add(new Atributo(hex,auxS, tipo, longitud, tipoIdx, dirAt, dirIdx, dirSAt));
                        dirIniA = dirSAt;
                    }

                }
            }
            return listaA;
        }

        /// <summary>
        /// Lee atributos del archivo
        /// </summary>
        private void leeAtributos()
        {
            Int64 aux = -1;
            Int64 posArch = 0;
            PosMayorAt = 0;
            for (int k = 0; k < Entidades.Count; k++)
            {
                PosAts = Entidades[k].DirPriAt;
                Atributos.Clear();
                while (PosAts != aux)
                {
                    using (Archivo = new FileStream(NombresArch, FileMode.Open))
                    {
                        Archivo.Position = PosAts;
                        using (BinaryReader br = new BinaryReader(Archivo))
                        {
                            String hex = "";
                            String auxS = "";
                            byte[] result = new byte[5];
                            for (int i = 0; i < 5; i++)
                            {
                                result[i] += br.ReadByte();
                            }
                            hex = BitConverter.ToString(result).Replace("-", "").ToLower();
                            char[] cadena = new char[35];
                            cadena = br.ReadChars(35);
                            char tipo = br.ReadChar();
                            Int32 longitud = br.ReadInt32();
                            Int32 tipoIdx = br.ReadInt32();
                            Int64 dirAt = br.ReadInt64();
                            Int64 dirIdx = br.ReadInt64();
                            Int64 dirSAt = br.ReadInt64();
                            for (int j = 0; j < 35; j++)
                            {
                                auxS += cadena[j];
                            }
                            Atributos.Add(new Atributo(hex,auxS, tipo, longitud, tipoIdx, dirAt, dirIdx, dirSAt));
                            PosAts = dirSAt;
                            posArch = Archivo.Position;
                        }

                    }
                }
                Entidades[k].AtsEnt=Atributos;
                if (posArch > PosMayorAt) PosMayorAt = posArch;
            }
        }
    }
}
