using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDTO
{
    public class Stock
    {
        private int id;
        private int cantidad;
        private int producto;

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

        public int Producto
        {
            get
            {
                return producto;
            }

            set
            {
                producto = value;
            }
        }
    }
}
