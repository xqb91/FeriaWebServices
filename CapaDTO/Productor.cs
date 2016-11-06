﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDTO
{
    public class Productor
    {
        private int id;
        private string usuario;
        private string contrasena;
        private string nombres;
        private string apaterno;
        private string amaterno;
        private string email;
        private string telefono;
        private string celular;
        private string fax;
        private int agrupacion;

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

        public string Usuario
        {
            get
            {
                return usuario;
            }

            set
            {
                usuario = value;
            }
        }

        public string Contrasena
        {
            get
            {
                return contrasena;
            }

            set
            {
                contrasena = value;
            }
        }

        public string Nombres
        {
            get
            {
                return nombres;
            }

            set
            {
                nombres = value;
            }
        }

        public string Apaterno
        {
            get
            {
                return apaterno;
            }

            set
            {
                apaterno = value;
            }
        }

        public string Amaterno
        {
            get
            {
                return amaterno;
            }

            set
            {
                amaterno = value;
            }
        }

        public string Email
        {
            get
            {
                return email;
            }

            set
            {
                email = value;
            }
        }

        public string Telefono
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

        public string Celular
        {
            get
            {
                return celular;
            }

            set
            {
                celular = value;
            }
        }

        public string Fax
        {
            get
            {
                return fax;
            }

            set
            {
                fax = value;
            }
        }

        public int Agrupacion
        {
            get
            {
                return agrupacion;
            }

            set
            {
                agrupacion = value;
            }
        }
    }
}
