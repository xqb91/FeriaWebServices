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
    public class NegocioOrdendeventa
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
            this.Conec1.NombreTabla = "Ordendeventa";
        }

        public ArrayList entregaOrdendeventaArray()
        {
            ArrayList listaOrdenes = new ArrayList();
            this.configuraConexion();
            this.Conec1.IntruccioneSQL = "Select * FROM " + this.Conec1.NombreTabla;
            this.Conec1.EsSelect = true;
            this.Conec1.conectar();

            foreach (System.Data.DataRow dr in this.Conec1.DbDat.Tables[this.Conec1.NombreTabla].Rows)
            {
                Ordendeventa auxOrden = new Ordendeventa();
                auxOrden.Id = Convert.ToInt32(dr["id"]);
                auxOrden.Fecha = (DateTime)dr["usuario"];
                auxOrden.Cliente = Convert.ToInt32(dr["cliente"]);
                auxOrden.Metodopago = Convert.ToInt32(dr["metodopago"]);
                auxOrden.Cuotas = Convert.ToInt32(dr["cuotas"]);
                auxOrden.Subtotal = Convert.ToInt32(dr["subtotal"]);
                auxOrden.Impuesto = Convert.ToInt32(dr["impuesto"]);
                auxOrden.Total = Convert.ToInt32(dr["total"]);
                auxOrden.Confirmada = (Char)dr["confirmada"];
                listaOrdenes.Add(auxOrden);
            }
            return listaOrdenes;
        } // Fin metodo entrega Arraylist de Ordendeventa


        public DataSet entregaOrdenesdeventaDataSet()
        {
            this.configuraConexion();
            this.Conec1.IntruccioneSQL = "Select * FROM " + this.Conec1.NombreTabla;
            this.Conec1.EsSelect = true;
            this.Conec1.conectar();

            return this.Conec1.DbDat;
        } // Fin metodo entrega Ordenes de venta DataSet... Todos los ordenes de venta en Base de Datos

        public Boolean ingresaOrdendeventa(Ordendeventa ordendeventa)
        {
            try
            {
                this.configuraConexion();
                this.Conec1.IntruccioneSQL = "INSERT INTO " + this.Conec1.NombreTabla + "(fecha,cliente,metodopago,cuotas,subtotal,impuesto,total,confirmada) VALUES ('" + ordendeventa.Fecha + "'," + ordendeventa.Cliente + "," + ordendeventa.Metodopago + "," + ordendeventa.Cuotas + "," + ordendeventa.Subtotal + "," + ordendeventa.Impuesto + "," + ordendeventa.Total + ",'" + ordendeventa.Confirmada + "')";
                this.Conec1.EsSelect = false;
                this.Conec1.conectar();
                return true;
                //Ingresa cliente a Base de Datos
            }
            catch(Exception e)
            {
                return false;
            }
        }


        public Ordendeventa buscaOrden(int idOrden)
        {
            Ordendeventa auxOrden = new Ordendeventa();
            this.configuraConexion();
            this.Conec1.IntruccioneSQL = "SELECT * FROM " + this.Conec1.NombreTabla + " WHERE id=" + idOrden;
            this.Conec1.EsSelect = true;
            this.Conec1.conectar();


            System.Data.DataTable dt = new System.Data.DataTable();
            dt = this.Conec1.DbDat.Tables[0];

            try
            {
                auxOrden.Id = Convert.ToInt32(dt.Rows[0]["id"]);
                auxOrden.Fecha = (DateTime)dt.Rows[0]["fecha"];
                auxOrden.Cliente = Convert.ToInt32(dt.Rows[0]["cliente"]);
                auxOrden.Metodopago = Convert.ToInt32(dt.Rows[0]["metodopago"]);
                auxOrden.Cuotas = Convert.ToInt32(dt.Rows[0]["cuotas"]);
                auxOrden.Subtotal = Convert.ToInt32(dt.Rows[0]["subtotal"]);
                auxOrden.Impuesto = Convert.ToInt32(dt.Rows[0]["impuesto"]);
                auxOrden.Total = Convert.ToInt32(dt.Rows[0]["total"]);
                auxOrden.Confirmada = (Char)dt.Rows[0]["confirmada"];
            }
            catch (Exception e)
            {
                auxOrden.Id = 0;
                auxOrden.Fecha = DateTime.Now;
                auxOrden.Cliente = 0;
                auxOrden.Metodopago = 0;
                auxOrden.Cuotas = 0;
                auxOrden.Subtotal = 0;
                auxOrden.Impuesto = 0;
                auxOrden.Total = 0;
                auxOrden.Confirmada = '\0';
            }
            return auxOrden;
        } // Fin metodo buscarOrden por ID

        public Boolean actualizaOrden(Ordendeventa Orden)
        {
            Ordendeventa auxOrden = new Ordendeventa();
            auxOrden.Id = Orden.Id;
            auxOrden.Fecha = Orden.Fecha;
            auxOrden.Cliente = Orden.Cliente;
            auxOrden.Metodopago = Orden.Metodopago;
            auxOrden.Cuotas = Orden.Cuotas;
            auxOrden.Subtotal = Orden.Subtotal;
            auxOrden.Impuesto = Orden.Impuesto;
            auxOrden.Total = Orden.Total;
            auxOrden.Confirmada = Orden.Confirmada;

            try
            {
                this.configuraConexion();
                this.Conec1.IntruccioneSQL = "UPDATE " + this.Conec1.NombreTabla + " SET fecha ='" + auxOrden.Fecha + "', SET cliente =" + auxOrden.Cliente + ", SET metodopago =" + auxOrden.Metodopago + ", SET cuotas =" + auxOrden.Cuotas + ", SET subtotal =" + auxOrden.Subtotal + ", SET impuesto =" + auxOrden.Impuesto + ", SET total =" + auxOrden.Total + ", SET confirmada ='" + auxOrden.Confirmada + "' WHERE id=" + auxOrden.Id;
                this.Conec1.EsSelect = true;
                this.Conec1.conectar();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public Boolean eliminaOrden(int idOrden)
        {
            try
            {
                this.configuraConexion();
                this.Conec1.IntruccioneSQL = "DELETE FROM " + this.Conec1.NombreTabla + " WHERE id=" + idOrden;
                this.Conec1.EsSelect = true;
                this.Conec1.conectar();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public Ordendeventa retornaElementoPorFila(int fila)
        {
            Ordendeventa auxOrden = new Ordendeventa();
            this.configuraConexion();
            this.Conec1.IntruccioneSQL = "Select * FROM " + this.Conec1.NombreTabla;
            this.Conec1.EsSelect = true;
            this.Conec1.conectar();


            System.Data.DataTable dt = new System.Data.DataTable();
            dt = this.Conec1.DbDat.Tables[0];

            try
            {
                auxOrden.Id = Convert.ToInt32(dt.Rows[0]["id"]);
                auxOrden.Fecha = (DateTime)dt.Rows[0]["fecha"];
                auxOrden.Cliente = Convert.ToInt32(dt.Rows[0]["cliente"]);
                auxOrden.Metodopago = Convert.ToInt32(dt.Rows[0]["metodopago"]);
                auxOrden.Cuotas = Convert.ToInt32(dt.Rows[0]["cuotas"]);
                auxOrden.Subtotal = Convert.ToInt32(dt.Rows[0]["subtotal"]);
                auxOrden.Impuesto = Convert.ToInt32(dt.Rows[0]["impuesto"]);
                auxOrden.Total = Convert.ToInt32(dt.Rows[0]["total"]);
                auxOrden.Confirmada = (Char)dt.Rows[0]["confirmada"];
            }
            catch
            {
                auxOrden.Id = 0;
                auxOrden.Fecha = DateTime.Now;
                auxOrden.Cliente = 0;
                auxOrden.Metodopago = 0;
                auxOrden.Cuotas = 0;
                auxOrden.Subtotal = 0;
                auxOrden.Impuesto = 0;
                auxOrden.Total = 0;
                auxOrden.Confirmada = '\0';
            }


            return auxOrden;
        } // Fin metodo retorna Orden por numero de Fila
    }
}
