using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDTO
{
    public class Producto
    {
        private int id;
        private string nombre;
        private int familia;
        private string fotografia;
        private string descripcion;
        private int categoria;
        private int precio;

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

        public int Familia
        {
            get
            {
                return familia;
            }

            set
            {
                familia = value;
            }
        }

        public string Fotografia
        {
            get
            {
                return fotografia;
            }

            set
            {
                fotografia = value;
            }
        }

        public string Descripcion
        {
            get
            {
                return descripcion;
            }

            set
            {
                descripcion = value;
            }
        }

        public int Categoria
        {
            get
            {
                return categoria;
            }

            set
            {
                categoria = value;
            }
        }

        public int Precio
        {
            get
            {
                return precio;
            }

            set
            {
                precio = value;
            }
        }
    }
}
