using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoArchivos
{
    public class Entidad
    {
        //Id hexadecimal
        private String idHex;
        //Nombre de la entidad
        private String nombreEnt;
        //Dirección donde se localiza la tabla
        private Int64 dirEnt;
        //Dirección donde se localiza el primer atributo de la tabla
        private Int64 dirPriAt;
        //Dirección donde se localiza el primer dato de la tabla
        private Int64 dirDatos;
        //Dirección de la siguiente tabla
        private Int64 dirSigEnt;
        //Lista auxiliar para sus atributos
        private List<Atributo> atsEnt;
        private bool primaria;
        private bool cve_busqueda;
        private bool secundaria;

        private bool datos;
        //Constructor de la clase
        public Entidad(String name, Int64 dirE, Int64 dirPA, Int64 dirD, Int64 dirSE)
        {
            string caracPos = "0123456789abcdef";
            string azar = "";
            Random aleatorio = new Random();
            for(int i=0; i<10; i++)
            {
                azar += caracPos[aleatorio.Next(0, caracPos.Length)];
            }
            idHex = azar;
            nombreEnt = name;
            dirEnt = dirE;
            dirPriAt = dirPA;
            dirDatos = dirD;
            dirSigEnt = dirSE;
            atsEnt = new List<Atributo>();
        }

        //Constructor dos de la clase sirve para leer el archivo
        public Entidad(String hex,String name, Int64 dirE, Int64 dirPA, Int64 dirD, Int64 dirSE)
        {
            idHex = hex;
            nombreEnt = name;
            dirEnt = dirE;
            dirPriAt = dirPA;
            dirDatos = dirD;
            dirSigEnt = dirSE;
            atsEnt = new List<Atributo>();
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

        public string NombreEnt
        {
            get
            {
                return nombreEnt;
            }

            set
            {
                nombreEnt = value;
            }
        }

        public long DirEnt
        {
            get
            {
                return dirEnt;
            }

            set
            {
                dirEnt = value;
            }
        }

        public long DirPriAt
        {
            get
            {
                return dirPriAt;
            }

            set
            {
                dirPriAt = value;
            }
        }

        public long DirDatos
        {
            get
            {
                return dirDatos;
            }

            set
            {
                dirDatos = value;
            }
        }

        public long DirSigEnt
        {
            get
            {
                return dirSigEnt;
            }

            set
            {
                dirSigEnt = value;
            }
        }

        internal List<Atributo> AtsEnt
        {
            get
            {
                return atsEnt;
            }

            set
            {
                atsEnt = value;
            }
        }

        public bool Primaria
        {
            get
            {
                return Primaria1;
            }

            set
            {
                Primaria1 = value;
            }
        }

        public bool Primaria1
        {
            get
            {
                return primaria;
            }

            set
            {
                primaria = value;
            }
        }

        public bool Cve_busqueda
        {
            get
            {
                return cve_busqueda;
            }

            set
            {
                cve_busqueda = value;
            }
        }

        public bool Secundaria
        {
            get
            {
                return secundaria;
            }

            set
            {
                secundaria = value;
            }
        }

        public bool Datos
        {
            get
            {
                return datos;
            }

            set
            {
                datos = value;
            }
        }
    }
}
