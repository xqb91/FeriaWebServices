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
    public class NegocioMetdoPago
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
            this.Conec1.NombreTabla = "Metodopago";
        }

        public ArrayList entregaMetodopagoArray()
        {
            ArrayList listaMetodos = new ArrayList();
            this.configuraConexion();
            this.Conec1.IntruccioneSQL = "Select * FROM " + this.Conec1.NombreTabla;
            this.Conec1.EsSelect = true;
            this.Conec1.conectar();

            foreach (System.Data.DataRow dr in this.Conec1.DbDat.Tables[this.Conec1.NombreTabla].Rows)
            {
                MetodoPago auxMetodopago = new MetodoPago();
                auxMetodopago.Id = Convert.ToInt32(dr["id"]);
                auxMetodopago.Nombre = (String)dr["nombre"];
                listaMetodos.Add(auxMetodopago);
            }
            return listaMetodos;
        } // Fin metodo entrega Arraylist de metodopago


        public DataSet entregaMetodoPagoDataSet()
        {
            this.configuraConexion();
            this.Conec1.IntruccioneSQL = "Select * FROM " + this.Conec1.NombreTabla;
            this.Conec1.EsSelect = true;
            this.Conec1.conectar();

            return this.Conec1.DbDat;
        } // Fin metodo entrega metodopago DataSet... Todos los metodos de pago en Base de Datos

        public Boolean ingresaMetodoPago(MetodoPago metodopago)
        {
            try
            {
                this.configuraConexion();
                this.Conec1.IntruccioneSQL = "INSERT INTO " + this.Conec1.NombreTabla + "(nombre) VALUES ('" + metodopago.Nombre + "')";
                this.Conec1.EsSelect = false;
                this.Conec1.conectar();
                return true;
                //Ingresa metodopago a Base de Datos
            }
            catch(Exception e)
            {
                return false;
            }
        }


        public MetodoPago buscaMetodoPago(int idMetodopago)
        {
            MetodoPago auxMetodo = new MetodoPago();
            this.configuraConexion();
            this.Conec1.IntruccioneSQL = "SELECT * FROM " + this.Conec1.NombreTabla + " WHERE id=" + idMetodopago;
            this.Conec1.EsSelect = true;
            this.Conec1.conectar();


            System.Data.DataTable dt = new System.Data.DataTable();
            dt = this.Conec1.DbDat.Tables[0];

            try
            {
                auxMetodo.Id = Convert.ToInt32(dt.Rows[0]["id"]);
                auxMetodo.Nombre = (String)dt.Rows[0]["nombre"];
            }
            catch (Exception e)
            {
                auxMetodo.Id = 0;
                auxMetodo.Nombre = e.Message + " Mas info: " + e.StackTrace;
            }
            return auxMetodo;
        } // Fin metodo buscarPais por ID

        public Boolean actualizaMetodoPago(MetodoPago metodopago)
        {
            MetodoPago auxMetodopago = new MetodoPago();
            auxMetodopago.Id = metodopago.Id;
            auxMetodopago.Nombre = metodopago.Nombre;

            try
            {
                this.configuraConexion();
                this.Conec1.IntruccioneSQL = "UPDATE " + this.Conec1.NombreTabla + " SET nombre ='" + auxMetodopago.Nombre + "' WHERE id=" + auxMetodopago.Id;
                this.Conec1.EsSelect = true;
                this.Conec1.conectar();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public Boolean eliminaMetodopago(int idMetodopago)
        {
            try
            {
                this.configuraConexion();
                this.Conec1.IntruccioneSQL = "DELETE FROM " + this.Conec1.NombreTabla + " WHERE id=" + idMetodopago;
                this.Conec1.EsSelect = true;
                this.Conec1.conectar();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public MetodoPago retornaElementoPorFila(int fila)
        {
            MetodoPago auxMetodopago = new MetodoPago();
            this.configuraConexion();
            this.Conec1.IntruccioneSQL = "Select * FROM " + this.Conec1.NombreTabla;
            this.Conec1.EsSelect = true;
            this.Conec1.conectar();


            System.Data.DataTable dt = new System.Data.DataTable();
            dt = this.Conec1.DbDat.Tables[0];

            try
            {
                auxMetodopago.Id = Convert.ToInt32(dt.Rows[0]["id"]);
                auxMetodopago.Nombre = (String)dt.Rows[fila]["nombre"];
            }
            catch
            {
                auxMetodopago.Nombre = "";
            }


            return auxMetodopago;
        } // Fin metodo retorna Pais por numero de Fila
    }
}
