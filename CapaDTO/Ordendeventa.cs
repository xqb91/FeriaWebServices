using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDTO
{
    public class Ordendeventa
    {
        private int id;
        private DateTime fecha;
        private int cliente;
        private int metodopago;
        private int cuotas;
        private int subtotal;
        private int impuesto;
        private int total;
        private char confirmada;

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

        public DateTime Fecha
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

        public int Cliente
        {
            get
            {
                return cliente;
            }

            set
            {
                cliente = value;
            }
        }

        public int Metodopago
        {
            get
            {
                return metodopago;
            }

            set
            {
                metodopago = value;
            }
        }

        public int Cuotas
        {
            get
            {
                return cuotas;
            }

            set
            {
                cuotas = value;
            }
        }

        public int Subtotal
        {
            get
            {
                return subtotal;
            }

            set
            {
                subtotal = value;
            }
        }

        public int Impuesto
        {
            get
            {
                return impuesto;
            }

            set
            {
                impuesto = value;
            }
        }

        public int Total
        {
            get
            {
                return total;
            }

            set
            {
                total = value;
            }
        }

        public char Confirmada
        {
            get
            {
                return confirmada;
            }

            set
            {
                confirmada = value;
            }
        }
    }
}
