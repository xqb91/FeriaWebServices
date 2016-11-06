using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDTO
{
    public class Egreso
    {
        private int id;
        private TimeSpan fecha;
        private int cantidad;
        private int ingreso;
        private int orden;

        public TimeSpan Fecha
        {
            get
            {
                return fecha;
            }

            set
            {
                fecha = value;
            }
        }

        public int Cantidad
        {
            get
            {
                return cantidad;
            }

            set
            {
                cantidad = value;
            }
        }

        public int Ingreso
        {
            get
            {
                return ingreso;
            }

            set
            {
                ingreso = value;
            }
        }

        public int Orden
        {
            get
            {
                return orden;
            }

            set
            {
                orden = value;
            }
        }

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
    }
}
