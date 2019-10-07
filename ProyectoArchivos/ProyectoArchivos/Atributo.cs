using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoArchivos
{
    public class Atributo
    {
        //Id hexadecimal
        private String idHex;
        //Nombre del atributo
        private String nombreAt;
        //Tipo de Atributo
        private char tipoAt;
        //Longitud de atributo
        private Int32 longAt;
        //Tipo de índice
        private Int32 tipoIdxAt;
        //Dirección del atributo
        private Int64 dirAt;
        //Dirección del índice
        private Int64 dirIndice;
        //Dirección del siguiente atributo
        private Int64 dirSigAt;

        //Construtor de la clase 
        public Atributo(String nA, char tA, Int32 lA, Int32 tIA, Int64 dA, Int64 dI, Int64 dAS)
        {
            string caracPos = "0123456789abcdef";
            string azar = "";
            Random aleatorio = new Random();
            for (int i = 0; i < 10; i++)
            {
                azar += caracPos[aleatorio.Next(0, caracPos.Length)];
            }
            idHex = azar;
            nombreAt = nA;
            tipoAt = tA;
            longAt = lA;
            tipoIdxAt = tIA;
            dirAt = dA;
            dirIndice = dI;
            dirSigAt = dAS;
        }

        public Atributo(String hexa,String nA, char tA, Int32 lA, Int32 tIA, Int64 dA, Int64 dI, Int64 dAS)
        {
            idHex = hexa;
            nombreAt = nA;
            tipoAt = tA;
            longAt = lA;
            tipoIdxAt = tIA;
            dirAt = dA;
            dirIndice = dI;
            dirSigAt = dAS;
        }

        public Atributo()
        {

        }




        //get's y set's
        public string IdHex
        {
            get
            {
                return idHex;
            }

            set
            {
                idHex = value;
            }
        }

        public string NombreAt
        {
            get
            {
                return nombreAt;
            }

            set
            {
                nombreAt = value;
            }
        }

        public char TipoAt
        {
            get
            {
                return tipoAt;
            }

            set
            {
                tipoAt = value;
            }
        }

        public int LongAt
        {
            get
            {
                return longAt;
            }

            set
            {
                longAt = value;
            }
        }

        public int TipoIdxAt
        {
            get
            {
                return tipoIdxAt;
            }

            set
            {
                tipoIdxAt = value;
            }
        }

        public long DirAt
        {
            get
            {
                return dirAt;
            }

            set
            {
                dirAt = value;
            }
        }

        public long DirIndice
        {
            get
            {
                return dirIndice;
            }

            set
            {
                dirIndice = value;
            }
        }

        public long DirSigAt
        {
            get
            {
                return dirSigAt;
            }

            set
            {
                dirSigAt = value;
            }
        }
    }
}
