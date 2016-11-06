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
    public class NegocioStock
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
            this.Conec1.NombreTabla = "Stock";
        }

        public ArrayList entregaStockArray()
        {
            ArrayList listaStock = new ArrayList();
            this.configuraConexion();
            this.Conec1.IntruccioneSQL = "Select * FROM " + this.Conec1.NombreTabla;
            this.Conec1.EsSelect = true;
            this.Conec1.conectar();

            foreach (System.Data.DataRow dr in this.Conec1.DbDat.Tables[this.Conec1.NombreTabla].Rows)
            {
                Stock auxStock = new Stock();
                auxStock.Id = Convert.ToInt32(dr["id"]);
                auxStock.Cantidad = Convert.ToInt32(dr["cantidad"]);
                auxStock.Producto = Convert.ToInt32(dr["producto"]);
                listaStock.Add(auxStock);
            }
            return listaStock;
        } // Fin metodo entrega Arraylist de stock


        public DataSet entregaStockDataSet()
        {
            this.configuraConexion();
            this.Conec1.IntruccioneSQL = "Select * FROM " + this.Conec1.NombreTabla;
            this.Conec1.EsSelect = true;
            this.Conec1.conectar();

            return this.Conec1.DbDat;
        } // Fin metodo entrega Stock DataSet... Todos los stock en Base de Datos

        public Boolean ingresaStock(Stock stock)
        {
            try
            {
                this.configuraConexion();
                this.Conec1.IntruccioneSQL = "INSERT INTO " + this.Conec1.NombreTabla + "(cantidad,producto) VALUES (" + stock.Cantidad + "," + stock.Producto + ")";
                this.Conec1.EsSelect = false;
                this.Conec1.conectar();
                return true;
                //Ingresa stock a Base de Datos
            }
            catch(Exception e)
            {
                return false;
            }
        }


        public Stock buscaStock(int idStock)
        {
            Stock auxStock = new Stock();
            this.configuraConexion();
            this.Conec1.IntruccioneSQL = "SELECT * FROM " + this.Conec1.NombreTabla + " WHERE id=" + idStock;
            this.Conec1.EsSelect = true;
            this.Conec1.conectar();


            System.Data.DataTable dt = new System.Data.DataTable();
            dt = this.Conec1.DbDat.Tables[0];

            try
            {
                auxStock.Id = Convert.ToInt32(dt.Rows[0]["id"]);
                auxStock.Cantidad = Convert.ToInt32(dt.Rows[0]["cantidad"]);
                auxStock.Producto = Convert.ToInt32(dt.Rows[0]["producto"]);
            }
            catch (Exception e)
            {
                auxStock.Id = 0;
                auxStock.Cantidad = 0;
                auxStock.Producto = 0;
            }
            return auxStock;
        } // Fin metodo buscarStock por ID

        public Boolean actualizaStock(Stock stock)
        {
            Stock auxStock = new Stock();
            auxStock.Id = stock.Id;
            auxStock.Cantidad = stock.Cantidad;
            auxStock.Producto = stock.Producto;

            try
            {
                this.configuraConexion();
                this.Conec1.IntruccioneSQL = "UPDATE " + this.Conec1.NombreTabla + " SET cantidad ='" + auxStock.Cantidad + "', set producto=" + auxStock.Producto + " WHERE id=" + auxStock.Id;
                this.Conec1.EsSelect = true;
                this.Conec1.conectar();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public Boolean eliminaStock(int idStock)
        {
            try
            {
                this.configuraConexion();
                this.Conec1.IntruccioneSQL = "DELETE FROM " + this.Conec1.NombreTabla + " WHERE id=" + idStock;
                this.Conec1.EsSelect = true;
                this.Conec1.conectar();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public Stock retornaElementoPorFila(int fila)
        {
            Stock auxStock = new Stock();
            this.configuraConexion();
            this.Conec1.IntruccioneSQL = "Select * FROM " + this.Conec1.NombreTabla;
            this.Conec1.EsSelect = true;
            this.Conec1.conectar();


            System.Data.DataTable dt = new System.Data.DataTable();
            dt = this.Conec1.DbDat.Tables[0];

            try
            {
                auxStock.Id = Convert.ToInt32(dt.Rows[0]["id"]);
                auxStock.Cantidad = Convert.ToInt32(dt.Rows[0]["cantidad"]);
                auxStock.Producto = Convert.ToInt32(dt.Rows[0]["producto"]);
            }
            catch
            {
                auxStock.Id = 0;
                auxStock.Cantidad = 0;
                auxStock.Producto = 0;
            }


            return auxStock;
        } // Fin metodo retorna stock por numero de Fila
    }
}
