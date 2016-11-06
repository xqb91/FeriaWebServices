using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDTO
{
    public class UbicacionProductor
    {
        private int id;
        private string nombre;
        private string longitud;
        private string latitud;
        private string direccion;
        private int comuna;
        private string referencia;
        private int productor;

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

        public string Nombre
        {
            get
            {
                return nombre;
            }

            set
            {
                nombre = value;
            }
        }

        public string Longitud
        {
            get
            {
                return longitud;
            }

            set
            {
                longitud = value;
            }
        }

        public string Latitud
        {
            get
            {
                return latitud;
            }

            set
            {
                latitud = value;
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

        public string Referencia
        {
            get
            {
                return referencia;
            }

            set
            {
                referencia = value;
            }
        }

        public int Productor
        {
            get
            {
                return productor;
            }

            set
            {
                productor = value;
            }
        }
    }
}
