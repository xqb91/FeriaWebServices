using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDTO
{
    public class Provincia
    {
        private int id;
        private string nombre;
        private int region;

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

        public int Region
        {
            get
            {
                return region;
            }

            set
            {
                region = value;
            }
        }
    }
}
