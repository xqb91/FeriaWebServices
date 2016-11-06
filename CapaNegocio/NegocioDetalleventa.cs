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
    public class NegocioDetalleventa
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
            this.Conec1.NombreTabla = "Detalleventa";
        }

        public ArrayList entregaDetalleventaArray()
        {
            ArrayList listaOrdenes = new ArrayList();
            this.configuraConexion();
            this.Conec1.IntruccioneSQL = "Select * FROM " + this.Conec1.NombreTabla;
            this.Conec1.EsSelect = true;
            this.Conec1.conectar();

            foreach (System.Data.DataRow dr in this.Conec1.DbDat.Tables[this.Conec1.NombreTabla].Rows)
            {
                Detalleventa auxDetalle = new Detalleventa();
                auxDetalle.Id = Convert.ToInt32(dr["id"]);
                auxDetalle.Orden = Convert.ToInt32(dr["orden"]);
                auxDetalle.Producto = Convert.ToInt32(dr["producto"]);
                auxDetalle.Cantidad = Convert.ToInt32(dr["cantidad"]);
                listaOrdenes.Add(auxDetalle);
            }
            return listaOrdenes;
        } // Fin metodo entrega Arraylist de Detalleventa


        public DataSet entregaDetalleventaDataSet()
        {
            this.configuraConexion();
            this.Conec1.IntruccioneSQL = "Select * FROM " + this.Conec1.NombreTabla;
            this.Conec1.EsSelect = true;
            this.Conec1.conectar();

            return this.Conec1.DbDat;
        } // Fin metodo entrega Ordenes de venta DataSet... Todos los ordenes de venta en Base de Datos

        public Boolean ingresaDetalleventa(Detalleventa detalleventa)
        {
            try
            {
                this.configuraConexion();
                this.Conec1.IntruccioneSQL = "INSERT INTO " + this.Conec1.NombreTabla + "(orden,producto,cantidad) VALUES (" + detalleventa.Orden + "," + detalleventa.Producto + "," + detalleventa.Cantidad + ")";
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


        public Detalleventa buscaDetalleventa(int idDetalle)
        {
            Detalleventa auxDetalle = new Detalleventa();
            this.configuraConexion();
            this.Conec1.IntruccioneSQL = "SELECT * FROM " + this.Conec1.NombreTabla + " WHERE id=" + idDetalle;
            this.Conec1.EsSelect = true;
            this.Conec1.conectar();


            System.Data.DataTable dt = new System.Data.DataTable();
            dt = this.Conec1.DbDat.Tables[0];

            try
            {
                auxDetalle.Id = Convert.ToInt32(dt.Rows[0]["id"]);
                auxDetalle.Orden = Convert.ToInt32(dt.Rows[0]["orden"]);
                auxDetalle.Producto = Convert.ToInt32(dt.Rows[0]["producto"]);
                auxDetalle.Cantidad = Convert.ToInt32(dt.Rows[0]["cantidad"]);
            }
            catch (Exception e)
            {
                auxDetalle.Id = 0;
                auxDetalle.Orden = 0;
                auxDetalle.Producto = 0;
                auxDetalle.Cantidad = 0;
            }
            return auxDetalle;
        } // Fin metodo buscarDetalleventa por ID

        public Boolean actualizaDetalleventa(Detalleventa detalle)
        {
            Detalleventa auxDetalle = new Detalleventa();
            auxDetalle.Id = detalle.Id;
            auxDetalle.Orden = detalle.Orden;
            auxDetalle.Producto = detalle.Producto;
            auxDetalle.Cantidad = detalle.Cantidad;
            
            try
            {
                this.configuraConexion();
                this.Conec1.IntruccioneSQL = "UPDATE " + this.Conec1.NombreTabla + " SET orden=" + auxDetalle.Orden + ", SET producto=" + auxDetalle.Producto + ", SET cantidad=" + auxDetalle.Cantidad + " WHERE id=" + auxDetalle.Id;
                this.Conec1.EsSelect = true;
                this.Conec1.conectar();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public Boolean eliminaDetalleventa(int idDetalle)
        {
            try
            {
                this.configuraConexion();
                this.Conec1.IntruccioneSQL = "DELETE FROM " + this.Conec1.NombreTabla + " WHERE id=" + idDetalle;
                this.Conec1.EsSelect = true;
                this.Conec1.conectar();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public Detalleventa retornaElementoPorFila(int fila)
        {
            Detalleventa auxDetalle = new Detalleventa();
            this.configuraConexion();
            this.Conec1.IntruccioneSQL = "Select * FROM " + this.Conec1.NombreTabla;
            this.Conec1.EsSelect = true;
            this.Conec1.conectar();


            System.Data.DataTable dt = new System.Data.DataTable();
            dt = this.Conec1.DbDat.Tables[0];

            try
            {
                auxDetalle.Id = Convert.ToInt32(dt.Rows[0]["id"]);
                auxDetalle.Orden = Convert.ToInt32(dt.Rows[0]["orden"]);
                auxDetalle.Producto = Convert.ToInt32(dt.Rows[0]["producto"]);
                auxDetalle.Cantidad = Convert.ToInt32(dt.Rows[0]["cantidad"]);
            }
            catch
            {
                auxDetalle.Id = 0;
                auxDetalle.Orden = 0;
                auxDetalle.Producto = 0;
                auxDetalle.Cantidad = 0;
            }


            return auxDetalle;
        } // Fin metodo retorna Orden por numero de Fila
    }
}
