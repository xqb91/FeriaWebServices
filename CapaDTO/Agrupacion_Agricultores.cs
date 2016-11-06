using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDTO
{
    public class Agrupacion_Agricultores
    {
        private int id;
        private string rut;
        private string razonSocial;
        private string direccion;
        private char telefono;
        private int comuna;

        public int Id
        {
            get
            {
                return id;
            }

            set
            {
                id = value;
            }
        }

        public string Rut
        {
            get
            {
                return rut;
            }

            set
            {
                rut = value;
            }
        }

        public string RazonSocial
        {
            get
            {
                return razonSocial;
            }

            set
            {
                razonSocial = value;
            }
        }

        public string Direccion
        {
            get
            {
                return direccion;
            }

            set
            {
                direccion = value;
            }
        }

        public char Telefono
        {
            get
            {
                return telefono;
            }

            set
            {
                telefono = value;
            }
        }

        public int Comuna
        {
            get
            {
                return comuna;
            }

            set
            {
                comuna = value;
            }
        }
    }
}
