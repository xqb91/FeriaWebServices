using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDTO
{
    public class Region
    {
        private int id;
        private string nombre;
        private int pais;

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

        public int Pais
        {
            get
            {
                return pais;
            }

            set
            {
                pais = value;
            }
        }
    }
}
