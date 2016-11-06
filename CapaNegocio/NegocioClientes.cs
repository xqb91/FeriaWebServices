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
    public class NegocioClientes
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
            this.Conec1.NombreTabla = "Clientes";
        }

        public ArrayList entregaClientesArray()
        {
            ArrayList listaClientes = new ArrayList();
            this.configuraConexion();
            this.Conec1.IntruccioneSQL = "Select * FROM " + this.Conec1.NombreTabla;
            this.Conec1.EsSelect = true;
            this.Conec1.conectar();

            foreach (System.Data.DataRow dr in this.Conec1.DbDat.Tables[this.Conec1.NombreTabla].Rows)
            {
                Clientes auxClientes = new Clientes();
                auxClientes.Id = Convert.ToInt32(dr["id"]);
                auxClientes.Usuario = (String)dr["usuario"];
                auxClientes.Contrasena = (String)dr["contrasena"];
                auxClientes.Nombres = (String)dr["nombres"];
                auxClientes.Apaterno = (String)dr["apaterno"];
                auxClientes.Amaterno = (String)dr["amaterno"];
                auxClientes.Email = (String)dr["email"];
                auxClientes.Telefono = (string)dr["telefono"];
                auxClientes.Celular = ((string)dr["celular"]);
                auxClientes.Fax = ((string)dr["fax"]);
                auxClientes.Direccion = (String)dr["direccion"];
                auxClientes.Comuna = Convert.ToInt32(dr["comuna"]);
                auxClientes.Longitud = (String)dr["longitud"];
                auxClientes.Latitud = (String)dr["latitud"];
                listaClientes.Add(auxClientes);

                
            }
            return listaClientes;
        } // Fin metodo entrega Arraylist de Clientes


        public DataSet entregaClientesDataSet()
        {
            this.configuraConexion();
            this.Conec1.IntruccioneSQL = "Select * FROM " + this.Conec1.NombreTabla;
            this.Conec1.EsSelect = true;
            this.Conec1.conectar();

            return this.Conec1.DbDat;
        } // Fin metodo entrega Clientes DataSet... Todos los clientes en Base de Datos

        public Boolean ingresaCliente(Clientes cliente)
        {
            try
            {
                this.configuraConexion();
                this.Conec1.IntruccioneSQL = "INSERT INTO " + this.Conec1.NombreTabla + "(usuario,contrasena,nombres,apaterno,amaterno,email,telefono,celular,fax,direccion,comuna,logitud,latitud) VALUES ('" + cliente.Usuario + "','" + cliente.Contrasena + "','" + cliente.Nombres + "','" + cliente.Apaterno + "','" + cliente.Email + "','" + cliente.Telefono + "','" + cliente.Celular + "','" + cliente.Fax + "','" + cliente.Direccion + "'," + cliente.Comuna + ",'" + cliente.Longitud + "','" + cliente.Latitud + "')";
                this.Conec1.EsSelect = false;
                this.Conec1.conectar();
                return true;
                //Ingresa cliente a Base de Datos
            }
            catch (Exception e)
            {
                return false;
            }
        }


        public Clientes buscaClientePorId(int idCliente)
        {
            Clientes auxCliente = new Clientes();
            this.configuraConexion();
            this.Conec1.IntruccioneSQL = "SELECT * FROM " + this.Conec1.NombreTabla + " WHERE id=" + idCliente;
            this.Conec1.EsSelect = true;
            this.Conec1.conectar();


            System.Data.DataTable dt = new System.Data.DataTable();
            dt = this.Conec1.DbDat.Tables[0];

            try
            {
                auxCliente.Id = Convert.ToInt32(dt.Rows[0]["id"]);
                auxCliente.Usuario = (String)dt.Rows[0]["usuario"];
                auxCliente.Contrasena = (String)dt.Rows[0]["contrasena"];
                auxCliente.Nombres = (String)dt.Rows[0]["nombres"];
                auxCliente.Apaterno = (String)dt.Rows[0]["apaterno"];
                auxCliente.Amaterno = (String)dt.Rows[0]["amaterno"];
                auxCliente.Email = (String)dt.Rows[0]["email"];
                auxCliente.Telefono = (string)dt.Rows[0]["telefono"];
                auxCliente.Celular = (string)dt.Rows[0]["celular"];
                auxCliente.Fax = (string)dt.Rows[0]["fax"];
                auxCliente.Direccion = (String)dt.Rows[0]["direccion"];
                auxCliente.Comuna = Convert.ToInt32(dt.Rows[0]["comuna"]);
                auxCliente.Longitud = (String)dt.Rows[0]["longitud"];
                auxCliente.Latitud = (String)dt.Rows[0]["latitud"];
            }
            catch (Exception e)
            {
                auxCliente.Id = 0;
                auxCliente.Usuario = e.Message + " Mas info: " + e.StackTrace;
                auxCliente.Contrasena = "";
                auxCliente.Nombres = "";
                auxCliente.Apaterno = "";
                auxCliente.Amaterno = "";
                auxCliente.Email = "";
                auxCliente.Telefono = "";
                auxCliente.Celular = "";
                auxCliente.Fax = "";
                auxCliente.Direccion = "";
                auxCliente.Longitud = "";
                auxCliente.Latitud = "";
            }
            return auxCliente;
        } // Fin metodo buscarCliente por ID

        public Clientes buscaClientePorRun(string run)
        {
            Clientes auxCliente = new Clientes();
            this.configuraConexion();
            this.Conec1.IntruccioneSQL = "SELECT * FROM " + this.Conec1.NombreTabla + " WHERE usuario='"+ run+"'";
            this.Conec1.EsSelect = true;
            this.Conec1.conectar();


            System.Data.DataTable dt = new System.Data.DataTable();
            dt = this.Conec1.DbDat.Tables[0];

            try
            {
                auxCliente.Id = Convert.ToInt32(dt.Rows[0]["id"]);
                auxCliente.Usuario = (String)dt.Rows[0]["usuario"];
                auxCliente.Contrasena = (String)dt.Rows[0]["contrasena"];
                auxCliente.Nombres = (String)dt.Rows[0]["nombres"];
                auxCliente.Apaterno = (String)dt.Rows[0]["apaterno"];
                auxCliente.Amaterno = (String)dt.Rows[0]["amaterno"];
                auxCliente.Email = (String)dt.Rows[0]["email"];
                auxCliente.Telefono = (string)dt.Rows[0]["telefono"];
                auxCliente.Celular = (string)dt.Rows[0]["celular"];
                auxCliente.Fax = (string)dt.Rows[0]["fax"];
                auxCliente.Direccion = (String)dt.Rows[0]["direccion"];
                auxCliente.Comuna = Convert.ToInt32(dt.Rows[0]["comuna"]);
                auxCliente.Longitud = (String)dt.Rows[0]["longitud"];
                auxCliente.Latitud = (String)dt.Rows[0]["latitud"];
            }
            catch (Exception e)
            {
                auxCliente.Id = 0;
                auxCliente.Usuario = e.Message + " Mas info: " + e.StackTrace;
                auxCliente.Contrasena = "";
                auxCliente.Nombres = "";
                auxCliente.Apaterno = "";
                auxCliente.Amaterno = "";
                auxCliente.Email = "";
                auxCliente.Telefono = "";
                auxCliente.Celular = "";
                auxCliente.Fax = "";
                auxCliente.Direccion = "";
                auxCliente.Longitud = "";
                auxCliente.Latitud = "";
            }
            return auxCliente;
        } // Fin metodo buscarCliente por RUN

        public ArrayList buscaClientePorNombres(string n)
        {
            ArrayList listaClientes = new ArrayList();
            this.configuraConexion();
            //determinando tipo de consulta con numero de variables
            string[] array = n.Split(' ');
            if(array.Length == 1)
            {
                this.Conec1.IntruccioneSQL = "SELECT * FROM " + this.Conec1.NombreTabla + " WHERE UPPER(NOMBRES) LIKE UPPER('%"+n+"%') OR UPPER(APATERNO) LIKE UPPER('%"+n+"%') OR UPPER(AMATERNO) LIKE UPPER('%"+n+"%') ";
            }else if(array.Length == 2){
                string nombre = array[0];
                string apellido = array[1];
                this.Conec1.IntruccioneSQL = "SELECT * FROM " + this.Conec1.NombreTabla + " WHERE UPPER(NOMBRES) LIKE UPPER('%" + nombre + "%') OR UPPER(NOMBRES) LIKE UPPER('%" + apellido + "%') OR UPPER(APATERNO) LIKE UPPER('%" + apellido + "%')  OR UPPER(APATERNO) LIKE UPPER('%" + nombre + "%') OR UPPER(AMATERNO) LIKE UPPER('%" + apellido + "%') OR UPPER(AMATERNO) LIKE UPPER('%" + nombre + "%')";
            }else if(array.Length == 3){
                string nombre = array[0];
                string apaterno = array[1];
                string amaterno = array[2];
                this.Conec1.IntruccioneSQL = "SELECT * FROM " + this.Conec1.NombreTabla + " WHERE UPPER(NOMBRES) LIKE UPPER('%" + nombre + "%') OR UPPER(NOMBRES) LIKE UPPER('%" + nombre + " "+apaterno+"%') OR UPPER(APATERNO) LIKE UPPER('%" + apaterno + "%')  OR UPPER(AMATERNO) LIKE UPPER('%" + amaterno + "%') ";
            }else if(array.Length == 4){
                string nombre = array[0] + " " + array[1];
                string apaterno = array[2];
                string amaterno = array[3];
                this.Conec1.IntruccioneSQL = "SELECT * FROM " + this.Conec1.NombreTabla + " WHERE UPPER(NOMBRES) LIKE UPPER('%" + nombre + "%') OR UPPER(NOMBRES) OR UPPER(APATERNO) LIKE UPPER('%" + apaterno + "%') OR UPPER(AMATERNO) LIKE UPPER('%" + amaterno + "%') ";
            }else{
                string nombre = array[0];
                this.Conec1.IntruccioneSQL = "SELECT * FROM " + this.Conec1.NombreTabla + " WHERE UPPER(NOMBRES) LIKE UPPER('%" + nombre + "%') OR UPPER(NOMBRES) OR UPPER(APATERNO) LIKE UPPER('%" + nombre + "%') OR UPPER(AMATERNO) LIKE UPPER('%" + nombre + "%') ";
            }
            this.Conec1.EsSelect = true;
            this.Conec1.conectar();


            System.Data.DataTable dt = new System.Data.DataTable();
            dt = this.Conec1.DbDat.Tables[0];

            foreach (System.Data.DataRow dr in this.Conec1.DbDat.Tables[this.Conec1.NombreTabla].Rows)
            {
                Clientes auxClientes = new Clientes();
                auxClientes.Id = Convert.ToInt32(dr["id"]);
                auxClientes.Usuario = (String)dr["usuario"];
                auxClientes.Contrasena = (String)dr["contrasena"];
                auxClientes.Nombres = (String)dr["nombres"];
                auxClientes.Apaterno = (String)dr["apaterno"];
                auxClientes.Amaterno = (String)dr["amaterno"];
                auxClientes.Email = (String)dr["email"];
                auxClientes.Telefono = (string)dr["telefono"];
                auxClientes.Celular = ((string)dr["celular"]);
                auxClientes.Fax = ((string)dr["fax"]);
                auxClientes.Direccion = (String)dr["direccion"];
                auxClientes.Comuna = Convert.ToInt32(dr["comuna"]);
                auxClientes.Longitud = (String)dr["longitud"];
                auxClientes.Latitud = (String)dr["latitud"];
                listaClientes.Add(auxClientes);


            }
            return listaClientes;
        } // Fin metodo buscarCliente por Nombres

        public ArrayList buscaClientePorEmail(string email)
        {
            ArrayList listaClientes = new ArrayList();
            this.configuraConexion();
            this.Conec1.IntruccioneSQL = "SELECT * FROM CLIENTES WHERE UPPER(EMAIL) = UPPER('"+email+"') ";
            this.Conec1.EsSelect = true;
            this.Conec1.conectar();


            System.Data.DataTable dt = new System.Data.DataTable();
            dt = this.Conec1.DbDat.Tables[0];
            foreach (System.Data.DataRow dr in this.Conec1.DbDat.Tables[this.Conec1.NombreTabla].Rows)
            {
                Clientes auxClientes = new Clientes();
                auxClientes.Id = Convert.ToInt32(dr["id"]);
                auxClientes.Usuario = (String)dr["usuario"];
                auxClientes.Contrasena = (String)dr["contrasena"];
                auxClientes.Nombres = (String)dr["nombres"];
                auxClientes.Apaterno = (String)dr["apaterno"];
                auxClientes.Amaterno = (String)dr["amaterno"];
                auxClientes.Email = (String)dr["email"];
                auxClientes.Telefono = (string)dr["telefono"];
                auxClientes.Celular = ((string)dr["celular"]);
                auxClientes.Fax = ((string)dr["fax"]);
                auxClientes.Direccion = (String)dr["direccion"];
                auxClientes.Comuna = Convert.ToInt32(dr["comuna"]);
                auxClientes.Longitud = (String)dr["longitud"];
                auxClientes.Latitud = (String)dr["latitud"];
                listaClientes.Add(auxClientes);


            }
            return listaClientes;
        } // Fin metodo buscarCliente por RUN

        public ArrayList buscaClientePorComuna(string comuna)
        {
            ArrayList listaClientes = new ArrayList();
            this.configuraConexion();
            this.Conec1.IntruccioneSQL = "SELECT cli.ID, cli.USUARIO, cli.CONTRASENA, cli.NOMBRES, cli.APATERNO, cli.AMATERNO, cli.EMAIL, cli.TELEFONO, cli.CELULAR, cli.FAX, cli.DIRECCION, cli.COMUNA, cli.LONGITUD, cli.LATITUD FROM CLIENTES cli INNER JOIN COMUNA com ON cli.COMUNA = com.ID WHERE UPPER(com.NOMBRE) = UPPER('"+comuna+"') ";
            this.Conec1.EsSelect = true;
            this.Conec1.conectar();


            System.Data.DataTable dt = new System.Data.DataTable();
            dt = this.Conec1.DbDat.Tables[0];
            foreach (System.Data.DataRow dr in this.Conec1.DbDat.Tables[this.Conec1.NombreTabla].Rows)
            {
                Clientes auxClientes = new Clientes();
                auxClientes.Id = Convert.ToInt32(dr["id"]);
                auxClientes.Usuario = (String)dr["usuario"];
                auxClientes.Contrasena = (String)dr["contrasena"];
                auxClientes.Nombres = (String)dr["nombres"];
                auxClientes.Apaterno = (String)dr["apaterno"];
                auxClientes.Amaterno = (String)dr["amaterno"];
                auxClientes.Email = (String)dr["email"];
                auxClientes.Telefono = (string)dr["telefono"];
                auxClientes.Celular = ((string)dr["celular"]);
                auxClientes.Fax = ((string)dr["fax"]);
                auxClientes.Direccion = (String)dr["direccion"];
                auxClientes.Comuna = Convert.ToInt32(dr["comuna"]);
                auxClientes.Longitud = (String)dr["longitud"];
                auxClientes.Latitud = (String)dr["latitud"];
                listaClientes.Add(auxClientes);


            }
            return listaClientes;
        } // Fin metodo buscarCliente por RUN

        public Boolean actualizaCliente(Clientes cliente)
        {
            Clientes auxCliente = new Clientes();
            auxCliente.Id = cliente.Id;
            auxCliente.Usuario = cliente.Usuario;
            auxCliente.Contrasena = cliente.Contrasena;
            auxCliente.Nombres = cliente.Nombres;
            auxCliente.Apaterno = cliente.Apaterno;
            auxCliente.Amaterno = cliente.Amaterno;
            auxCliente.Email = cliente.Email;
            auxCliente.Telefono = cliente.Telefono;
            auxCliente.Celular = cliente.Celular;
            auxCliente.Fax = cliente.Fax;
            auxCliente.Direccion = cliente.Direccion;
            auxCliente.Comuna = cliente.Comuna;
            auxCliente.Longitud = cliente.Longitud;
            auxCliente.Latitud = cliente.Latitud;

            try
            {
                this.configuraConexion();
                this.Conec1.IntruccioneSQL = "UPDATE " + this.Conec1.NombreTabla + " SET usuario ='" + auxCliente.Usuario + "', SET contrasena ='"+ auxCliente.Contrasena +"', SET email ='"+ auxCliente.Email +"', SET telefono ='"+ auxCliente.Telefono +"', SET celular ='"+ auxCliente.Celular +"', SET fax ='"+ auxCliente.Fax +"', SET direccion ='"+ auxCliente.Direccion +"', SET comuna ='"+ auxCliente.Comuna +"', SET logitud ='"+ auxCliente.Longitud +"', SET latitud ='"+ auxCliente.Latitud +"' WHERE id=" + auxCliente.Id;
                this.Conec1.EsSelect = true;
                this.Conec1.conectar();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public Boolean eliminaCliente(int idCliente)
        {
            try
            {
                this.configuraConexion();
                this.Conec1.IntruccioneSQL = "DELETE FROM " + this.Conec1.NombreTabla + " WHERE id=" + idCliente;
                this.Conec1.EsSelect = true;
                this.Conec1.conectar();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public Clientes retornaElementoPorFila(int fila)
        {
            Clientes auxCliente = new Clientes();
            this.configuraConexion();
            this.Conec1.IntruccioneSQL = "Select * FROM " + this.Conec1.NombreTabla;
            this.Conec1.EsSelect = true;
            this.Conec1.conectar();


            System.Data.DataTable dt = new System.Data.DataTable();
            dt = this.Conec1.DbDat.Tables[0];

            try
            {
                auxCliente.Id = Convert.ToInt32(dt.Rows[0]["id"]);
                auxCliente.Usuario = (String)dt.Rows[fila]["usuario"];
                auxCliente.Contrasena = (String)dt.Rows[fila]["contrasena"];
                auxCliente.Nombres = (String)dt.Rows[fila]["nombre"];
                auxCliente.Apaterno = (String)dt.Rows[fila]["apaterno"];
                auxCliente.Amaterno = (String)dt.Rows[fila]["amaterno"];
                auxCliente.Email = (String)dt.Rows[fila]["email"];
                auxCliente.Telefono = (string)dt.Rows[fila]["telefono"];
                auxCliente.Celular = (string)dt.Rows[fila]["celular"];
                auxCliente.Fax = (string)dt.Rows[fila]["fax"];
                auxCliente.Direccion = (String)dt.Rows[fila]["direccion"];
                auxCliente.Comuna = Convert.ToInt32(dt.Rows[0]["comuna"]);
                auxCliente.Longitud = (String)dt.Rows[fila]["longitud"];
                auxCliente.Latitud = (String)dt.Rows[fila]["latitud"];
            }
            catch
            {
                auxCliente.Id = 0;
                auxCliente.Usuario = "";
                auxCliente.Contrasena = "";
                auxCliente.Nombres = "";
                auxCliente.Apaterno = "";
                auxCliente.Amaterno = "";
                auxCliente.Email = "";
                auxCliente.Telefono = "";
                auxCliente.Celular = "";
                auxCliente.Fax = "";
                auxCliente.Direccion = "";
                auxCliente.Comuna = 0;
                auxCliente.Longitud = "";
                auxCliente.Latitud = "";
            }


            return auxCliente;
        } // Fin metodo retorna Cliente por numero de Fila

    }
}
