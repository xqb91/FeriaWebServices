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
    public class NegocioEgreso
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
            this.Conec1.NombreTabla = "Egreso";
        }

        public ArrayList entregaEgresoArray()
        {
            ArrayList listaEgresos = new ArrayList();
            this.configuraConexion();
            this.Conec1.IntruccioneSQL = "Select * FROM " + this.Conec1.NombreTabla;
            this.Conec1.EsSelect = true;
            this.Conec1.conectar();

            foreach (System.Data.DataRow dr in this.Conec1.DbDat.Tables[this.Conec1.NombreTabla].Rows)
            {
                Egreso auxEgreso = new Egreso();
                auxEgreso.Id = Convert.ToInt32(dr["id"]);
                auxEgreso.Fecha = (TimeSpan)dr["fecha"];
                auxEgreso.Cantidad = Convert.ToInt32(dr["cantidad"]);
                auxEgreso.Ingreso = Convert.ToInt32(dr["ingreso"]);
                auxEgreso.Orden = Convert.ToInt32(dr["orden"]);
                listaEgresos.Add(auxEgreso);
            }
            return listaEgresos;
        } // Fin metodo entrega Arraylist de Egresos


        public DataSet entregaEgresosDataSet()
        {
            this.configuraConexion();
            this.Conec1.IntruccioneSQL = "Select * FROM " + this.Conec1.NombreTabla;
            this.Conec1.EsSelect = true;
            this.Conec1.conectar();

            return this.Conec1.DbDat;
        } // Fin metodo entrega Egreso DataSet... Todos los egresos en Base de Datos

        public Boolean ingresaEgreso(Egreso egreso)
        {
            try
            {
                this.configuraConexion();
                this.Conec1.IntruccioneSQL = "INSERT INTO " + this.Conec1.NombreTabla + "(fecha,cantidad,ingreso,orden) VALUES ('" + egreso.Fecha + "'," + egreso.Cantidad + "," + egreso.Ingreso + "," + egreso.Orden + ")";
                this.Conec1.EsSelect = false;
                this.Conec1.conectar();
                return true;
                //Ingresa Egreso a Base de Datos
            }
            catch(Exception e)
            {
                return false;
            }
        }


        public Egreso buscaEgreso(int idEgreso)
        {
            Egreso auxEgreso = new Egreso();
            this.configuraConexion();
            this.Conec1.IntruccioneSQL = "SELECT * FROM " + this.Conec1.NombreTabla + " WHERE id=" + idEgreso;
            this.Conec1.EsSelect = true;
            this.Conec1.conectar();


            System.Data.DataTable dt = new System.Data.DataTable();
            dt = this.Conec1.DbDat.Tables[0];

            try
            {
                auxEgreso.Id = Convert.ToInt32(dt.Rows[0]["id"]);
                auxEgreso.Fecha = (TimeSpan)dt.Rows[0]["fecha"];
                auxEgreso.Cantidad = Convert.ToInt32(dt.Rows[0]["cantidad"]);
                auxEgreso.Ingreso = Convert.ToInt32(dt.Rows[0]["ingreso"]);
                auxEgreso.Orden = Convert.ToInt32(dt.Rows[0]["orden"]);
            }
            catch (Exception e)
            {
                auxEgreso.Id = 0;
                auxEgreso.Fecha = TimeSpan.Zero;
                auxEgreso.Cantidad = 0;
                auxEgreso.Ingreso = 0;
                auxEgreso.Orden = 0;
            }
            return auxEgreso;
        } // Fin metodo buscarEgreso por ID

        public Boolean actualizaEgreso(Egreso egreso)
        {
            Egreso auxEgreso = new Egreso();
            auxEgreso.Id = egreso.Id;
            auxEgreso.Fecha = egreso.Fecha;
            auxEgreso.Cantidad = egreso.Cantidad;
            auxEgreso.Ingreso = egreso.Ingreso;
            auxEgreso.Orden = egreso.Orden;

            try
            {
                this.configuraConexion();
                this.Conec1.IntruccioneSQL = "UPDATE " + this.Conec1.NombreTabla + " SET fecha ='" + auxEgreso.Fecha + "', set cantidad="+ auxEgreso.Cantidad +", set ingreso="+ auxEgreso.Ingreso +", set orden="+ auxEgreso.Orden +" WHERE id=" + auxEgreso.Id;
                this.Conec1.EsSelect = true;
                this.Conec1.conectar();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public Boolean eliminaEgreso(int idPais)
        {
            try
            {
                this.configuraConexion();
                this.Conec1.IntruccioneSQL = "DELETE FROM " + this.Conec1.NombreTabla + " WHERE id=" + idPais;
                this.Conec1.EsSelect = true;
                this.Conec1.conectar();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public Egreso retornaElementoPorFila(int fila)
        {
            Egreso auxEgreso = new Egreso();
            this.configuraConexion();
            this.Conec1.IntruccioneSQL = "Select * FROM " + this.Conec1.NombreTabla;
            this.Conec1.EsSelect = true;
            this.Conec1.conectar();


            System.Data.DataTable dt = new System.Data.DataTable();
            dt = this.Conec1.DbDat.Tables[0];

            try
            {
                auxEgreso.Id = Convert.ToInt32(dt.Rows[0]["id"]);
                auxEgreso.Fecha = (TimeSpan)dt.Rows[fila]["fecha"];
                auxEgreso.Cantidad = Convert.ToInt32(dt.Rows[0]["cantidad"]);
                auxEgreso.Ingreso = Convert.ToInt32(dt.Rows[0]["ingreso"]);
                auxEgreso.Orden = Convert.ToInt32(dt.Rows[0]["orden"]);
            }
            catch
            {
                auxEgreso.Id = 0;
                auxEgreso.Fecha = TimeSpan.Zero;
                auxEgreso.Cantidad = 0;
                auxEgreso.Ingreso = 0;
                auxEgreso.Orden = 0;
            }


            return auxEgreso;
        } // Fin metodo retorna Egreso por numero de Fila
    }
}
