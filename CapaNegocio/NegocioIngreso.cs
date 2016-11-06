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
    public class NegocioIngreso
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
            this.Conec1.NombreTabla = "Ingreso";
        }

        public ArrayList entregaIngresoArray()
        {
            ArrayList listaIngresos = new ArrayList();
            this.configuraConexion();
            this.Conec1.IntruccioneSQL = "Select * FROM " + this.Conec1.NombreTabla;
            this.Conec1.EsSelect = true;
            this.Conec1.conectar();

            foreach (System.Data.DataRow dr in this.Conec1.DbDat.Tables[this.Conec1.NombreTabla].Rows)
            {
                Ingreso auxIngreso = new Ingreso();
                auxIngreso.Id = Convert.ToInt32(dr["id"]);
                auxIngreso.Fecha = (TimeSpan)dr["fecha"];
                auxIngreso.Producto = Convert.ToInt32(dr["producto"]);
                auxIngreso.Ubicacion = Convert.ToInt32(dr["ubicacion"]);
                auxIngreso.Cantidad = Convert.ToInt32(dr["cantidad"]);
                auxIngreso.Precioventa = Convert.ToInt32(dr["precioventa"]);
                auxIngreso.Impuesto = Convert.ToInt32(dr["impuesto"]);
                auxIngreso.Total = Convert.ToInt32(dr["total"]);
                listaIngresos.Add(auxIngreso);
            }
            return listaIngresos;
        } // Fin metodo entrega Arraylist de Ingresos


        public DataSet entregaIngresosDataSet()
        {
            this.configuraConexion();
            this.Conec1.IntruccioneSQL = "Select * FROM " + this.Conec1.NombreTabla;
            this.Conec1.EsSelect = true;
            this.Conec1.conectar();

            return this.Conec1.DbDat;
        } // Fin metodo entrega Egreso DataSet... Todos los egresos en Base de Datos

        public Boolean ingresaIngreso(Ingreso ingreso)
        {
            try
            {
                this.configuraConexion();
                this.Conec1.IntruccioneSQL = "INSERT INTO " + this.Conec1.NombreTabla + "(fecha,producto,ubicacion,cantidad,precioventa,impuesto,total) VALUES ('" + ingreso.Fecha + "'," + ingreso.Producto + "," + ingreso.Ubicacion + "," + ingreso.Cantidad + ","+ ingreso.Precioventa +","+ ingreso.Impuesto +","+ ingreso.Total +")";
                this.Conec1.EsSelect = false;
                this.Conec1.conectar();
                return true;
                //Ingresa Egreso a Base de Datos
            }
            catch (Exception e)
            {
                return false;
            }
        }


        public Ingreso buscaIngreso(int idIngreso)
        {
            Ingreso auxIngreso = new Ingreso();
            this.configuraConexion();
            this.Conec1.IntruccioneSQL = "SELECT * FROM " + this.Conec1.NombreTabla + " WHERE id=" + idIngreso;
            this.Conec1.EsSelect = true;
            this.Conec1.conectar();


            System.Data.DataTable dt = new System.Data.DataTable();
            dt = this.Conec1.DbDat.Tables[0];

            try
            {
                auxIngreso.Id = Convert.ToInt32(dt.Rows[0]["id"]);
                auxIngreso.Fecha = (TimeSpan)dt.Rows[0]["fecha"];
                auxIngreso.Producto = Convert.ToInt32(dt.Rows[0]["producto"]);
                auxIngreso.Ubicacion = Convert.ToInt32(dt.Rows[0]["ubicacion"]);
                auxIngreso.Cantidad = Convert.ToInt32(dt.Rows[0]["cantidad"]);
                auxIngreso.Precioventa = Convert.ToInt32(dt.Rows[0]["precioventa"]);
                auxIngreso.Impuesto = Convert.ToInt32(dt.Rows[0]["impuesto"]);
                auxIngreso.Total = Convert.ToInt32(dt.Rows[0]["total"]);
            }
            catch (Exception e)
            {
                auxIngreso.Id = 0;
                auxIngreso.Fecha = TimeSpan.Zero;
                auxIngreso.Producto = 0;
                auxIngreso.Ubicacion = 0;
                auxIngreso.Cantidad = 0;
                auxIngreso.Precioventa = 0;
                auxIngreso.Impuesto = 0;
                auxIngreso.Total = 0;
            }
            return auxIngreso;
        } // Fin metodo buscarEgreso por ID

        public Boolean actualizaIngreso(Ingreso ingreso)
        {
            Ingreso auxIngreso = new Ingreso();
            auxIngreso.Id = ingreso.Id;
            auxIngreso.Fecha = ingreso.Fecha;
            auxIngreso.Producto = ingreso.Producto;
            auxIngreso.Ubicacion = ingreso.Ubicacion;
            auxIngreso.Cantidad = ingreso.Cantidad;
            auxIngreso.Precioventa = ingreso.Precioventa;
            auxIngreso.Impuesto = ingreso.Impuesto;
            auxIngreso.Total = ingreso.Total;

            try
            {
                this.configuraConexion();
                this.Conec1.IntruccioneSQL = "UPDATE " + this.Conec1.NombreTabla + " SET fecha ='" + auxIngreso.Fecha + "', set producto=" + auxIngreso.Cantidad + ", set ubicacion=" + auxIngreso.Ubicacion + ", set cantidad=" + auxIngreso.Cantidad + ", set precioventa="+ auxIngreso.Precioventa +", set impuesto="+ auxIngreso.Impuesto +", set total="+ auxIngreso.Total +" WHERE id=" + auxIngreso.Id;
                this.Conec1.EsSelect = true;
                this.Conec1.conectar();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public Boolean eliminaIngreso(int idIngreso)
        {
            try
            {
                this.configuraConexion();
                this.Conec1.IntruccioneSQL = "DELETE FROM " + this.Conec1.NombreTabla + " WHERE id=" + idIngreso;
                this.Conec1.EsSelect = true;
                this.Conec1.conectar();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public Ingreso retornaElementoPorFila(int fila)
        {
            Ingreso auxIngreso = new Ingreso();
            this.configuraConexion();
            this.Conec1.IntruccioneSQL = "Select * FROM " + this.Conec1.NombreTabla;
            this.Conec1.EsSelect = true;
            this.Conec1.conectar();


            System.Data.DataTable dt = new System.Data.DataTable();
            dt = this.Conec1.DbDat.Tables[0];

            try
            {
                auxIngreso.Id = Convert.ToInt32(dt.Rows[0]["id"]);
                auxIngreso.Fecha = (TimeSpan)dt.Rows[0]["fecha"];
                auxIngreso.Producto = Convert.ToInt32(dt.Rows[0]["producto"]);
                auxIngreso.Ubicacion = Convert.ToInt32(dt.Rows[0]["ubicacion"]);
                auxIngreso.Cantidad = Convert.ToInt32(dt.Rows[0]["cantidad"]);
                auxIngreso.Precioventa = Convert.ToInt32(dt.Rows[0]["precioventa"]);
                auxIngreso.Impuesto = Convert.ToInt32(dt.Rows[0]["impuesto"]);
                auxIngreso.Total = Convert.ToInt32(dt.Rows[0]["total"]);
            }
            catch
            {
                auxIngreso.Id = 0;
                auxIngreso.Fecha = TimeSpan.Zero;
                auxIngreso.Producto = 0;
                auxIngreso.Ubicacion = 0;
                auxIngreso.Cantidad = 0;
                auxIngreso.Precioventa = 0;
                auxIngreso.Impuesto = 0;
                auxIngreso.Total = 0;
            }


            return auxIngreso;
        } // Fin metodo retorna Egreso por numero de Fila
    }
}
