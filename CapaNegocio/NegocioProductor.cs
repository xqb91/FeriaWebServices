using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaConexion;
using CapaDTO;
using Oracle.ManagedDataAccess.Client;
using System.Windows.Forms;

namespace CapaNegocio
{
    public class NegocioProductor
    {
        private Conexion conec1;

        public Conexion Conec1
        {
            get { return conec1; }
            set { conec1 = value; }
        }

        public void configuraConexion()
        {
            this.Conec1 = new Conexion();
            this.Conec1.NombreTabla = "Productor";
        }

        public ArrayList entregaProductoresArray()
        {
            ArrayList listaProductores = new ArrayList();
            this.configuraConexion();
            this.Conec1.IntruccioneSQL = "Select * FROM " + this.Conec1.NombreTabla;
            this.Conec1.EsSelect = true;
            this.Conec1.conectar();

            foreach (System.Data.DataRow dr in this.Conec1.DbDat.Tables[this.Conec1.NombreTabla].Rows)
            {
                Productor auxProductor = new Productor();
                auxProductor.Id = Convert.ToInt32(dr["id"]);
                auxProductor.Usuario = (String)dr["usuario"];
                auxProductor.Contrasena = (String)dr["contrasena"];
                auxProductor.Nombres = (String)dr["nombres"];
                auxProductor.Apaterno = (String)dr["apaterno"];
                auxProductor.Amaterno = (String)dr["amaterno"];
                auxProductor.Email = (String)dr["email"];
                auxProductor.Telefono = (String)dr["email"];
                auxProductor.Celular = (String)dr["celular"];
                auxProductor.Fax = (String)dr["fax"];
                try
                {
                    auxProductor.Agrupacion = Convert.ToInt32(dr["agrupacion"]);
                }
                catch(Exception e)
                {
                    auxProductor.Agrupacion = 0;
                }
                listaProductores.Add(auxProductor);
            }
            return listaProductores;
        } // Fin metodo entrega Arraylist de Productores


        public DataSet entregaProductoresDataSet()
        {
            this.configuraConexion();
            this.Conec1.IntruccioneSQL = "Select * FROM " + this.Conec1.NombreTabla;
            this.Conec1.EsSelect = true;
            this.Conec1.conectar();

            return this.Conec1.DbDat;
        } // Fin metodo entrega productores DataSet... Todos los productores en Base de Datos

        public Boolean ingresaProductor(Productor productor)
        {
            try
            {
                this.configuraConexion();
                this.Conec1.IntruccioneSQL = "INSERT INTO " + this.Conec1.NombreTabla + "(usuario,contrasena,nombres,apaterno,amaterno,email,telefono,celular,fax,agrupacion) VALUES ('" + productor.Usuario + "','" + productor.Contrasena + "','" + productor.Nombres + "','" + productor.Apaterno + "','" + productor.Amaterno + "','" + productor.Email + "','" + productor.Telefono + "','" + productor.Celular + "','" + productor.Fax + "'," + productor.Agrupacion + ")";
                this.Conec1.EsSelect = false;
                this.Conec1.conectar();
                return true;
                //Ingresa productor a Base de Datos
            }
            catch(Exception e)
            {
                return false;
            }
        }


        public Productor buscaProductor(string usuarioProductor)
        {
            Productor auxProductor = new Productor();
            this.configuraConexion();
            this.Conec1.IntruccioneSQL = "SELECT * FROM " + this.Conec1.NombreTabla + " WHERE usuario='" + usuarioProductor+"'";
            this.Conec1.EsSelect = true;
            this.Conec1.conectar();


            System.Data.DataTable dt = new System.Data.DataTable();
            dt = this.Conec1.DbDat.Tables[0];

            try
            {
                auxProductor.Id = Convert.ToInt32(dt.Rows[0]["id"]);
                auxProductor.Usuario = (String)dt.Rows[0]["usuario"];
                auxProductor.Contrasena = (String)dt.Rows[0]["contrasena"];
                auxProductor.Nombres = (String)dt.Rows[0]["nombres"];
                auxProductor.Apaterno = (String)dt.Rows[0]["apaterno"];
                auxProductor.Amaterno = (String)dt.Rows[0]["amaterno"];
                auxProductor.Email = (String)dt.Rows[0]["email"];
                auxProductor.Telefono = (String)dt.Rows[0]["telefono"];
                auxProductor.Celular = (String)dt.Rows[0]["celular"];
                auxProductor.Fax = (String)dt.Rows[0]["fax"];

                try
                {
                    if (dt.Rows[0]["agrupacion"] != null)
                    {
                        auxProductor.Agrupacion = Convert.ToInt32(dt.Rows[0]["agrupacion"]);
                    }
                }
                catch (Exception e)
                {
                    auxProductor.Agrupacion = 0;
                }

                
            }
            catch (Exception e)
            {
                auxProductor.Id = 0;
                auxProductor.Usuario = ""+e.Message;
                auxProductor.Contrasena = "";
                auxProductor.Nombres = "";
                auxProductor.Apaterno = "";
                auxProductor.Amaterno = "";
                auxProductor.Email = "";
                auxProductor.Telefono = "";
                auxProductor.Celular = "";
                auxProductor.Fax = "";
                auxProductor.Agrupacion = 0;
            }
            return auxProductor;
        } // Fin metodo buscarProductor por ID

        public Boolean actualizaProductor(Productor productor)
        {
            Productor auxProductor = new Productor();
            auxProductor.Id = productor.Id;
            auxProductor.Usuario = productor.Usuario;
            auxProductor.Contrasena = productor.Contrasena;
            auxProductor.Nombres = productor.Nombres;
            auxProductor.Apaterno = productor.Apaterno;
            auxProductor.Amaterno = productor.Amaterno;
            auxProductor.Email = productor.Email;
            auxProductor.Telefono = productor.Telefono;
            auxProductor.Celular = productor.Celular;
            auxProductor.Fax = productor.Fax;
            auxProductor.Agrupacion = productor.Agrupacion;

            try
            {
                this.configuraConexion();
                this.Conec1.IntruccioneSQL = "UPDATE " + this.Conec1.NombreTabla + " SET usuario ='" + auxProductor.Usuario + "', SET contraena ='" + auxProductor.Contrasena + "', SET nombres ='" + auxProductor.Nombres + "', SET apaterno ='" + auxProductor.Apaterno + "', SET email ='" + auxProductor.Email + "', SET telefono ='" + auxProductor.Telefono + "', SET celular ='" + auxProductor.Celular + "', SET fax ='" + auxProductor.Fax + "', SET agrupacion="+ auxProductor.Agrupacion +" WHERE id=" + auxProductor.Id;
                this.Conec1.EsSelect = true;
                this.Conec1.conectar();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public Boolean eliminaProductor(int idProductor)
        {
            try
            {
                this.configuraConexion();
                this.Conec1.IntruccioneSQL = "DELETE FROM " + this.Conec1.NombreTabla + " WHERE id=" + idProductor;
                this.Conec1.EsSelect = true;
                this.Conec1.conectar();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public Productor retornaElementoPorFila(int fila)
        {
            Productor auxProductor = new Productor();
            this.configuraConexion();
            this.Conec1.IntruccioneSQL = "Select * FROM " + this.Conec1.NombreTabla;
            this.Conec1.EsSelect = true;
            this.Conec1.conectar();


            System.Data.DataTable dt = new System.Data.DataTable();
            dt = this.Conec1.DbDat.Tables[0];

            try
            {
                auxProductor.Id = Convert.ToInt32(dt.Rows[0]["id"]);
                auxProductor.Usuario = (String)dt.Rows[0]["usuario"];
                auxProductor.Contrasena = (String)dt.Rows[0]["contrasena"];
                auxProductor.Nombres = (String)dt.Rows[0]["nombres"];
                auxProductor.Apaterno = (String)dt.Rows[0]["apaterno"];
                auxProductor.Amaterno = (String)dt.Rows[0]["amaterno"];
                auxProductor.Email = (String)dt.Rows[0]["email"];
                auxProductor.Telefono = (String)dt.Rows[0]["telefono"];
                auxProductor.Celular = (String)dt.Rows[0]["celular"];
                auxProductor.Fax = (String)dt.Rows[0]["fax"];
                auxProductor.Agrupacion = Convert.ToInt32(dt.Rows[0]["agrupacion"]);
            }
            catch
            {
                auxProductor.Id = 0;
                auxProductor.Usuario = "";
                auxProductor.Contrasena = "";
                auxProductor.Nombres = "";
                auxProductor.Apaterno = "";
                auxProductor.Amaterno = "";
                auxProductor.Email = "";
                auxProductor.Telefono = "";
                auxProductor.Celular = "";
                auxProductor.Fax = "";
                auxProductor.Agrupacion = 0;
            }


            return auxProductor;
        } // Fin metodo retorna productor por numero de Fila
    }
}
