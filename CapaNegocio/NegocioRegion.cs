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
    public class NegocioRegion
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
            this.Conec1.NombreTabla = "Region";
        }

        public ArrayList entregaRegionArray()
        {
            ArrayList listadoRegiones = new ArrayList();
            this.configuraConexion();
            this.Conec1.IntruccioneSQL = "Select * FROM " + this.Conec1.NombreTabla;
            this.Conec1.EsSelect = true;
            this.Conec1.conectar();

            foreach (System.Data.DataRow dr in this.Conec1.DbDat.Tables[this.Conec1.NombreTabla].Rows)
            {
                Region auxRegiones = new Region();
                auxRegiones.Id = Convert.ToInt32(dr["id"]);
                auxRegiones.Nombre = (String)dr["nombre"];
                auxRegiones.Pais = (int)dr["pais"];
                listadoRegiones.Add(auxRegiones);
            }
            return listadoRegiones;
        } // Fin metodo entrega Arraylist de Regiones


        public DataSet entregaRegionDataSet()
        {
            this.configuraConexion();
            this.Conec1.IntruccioneSQL = "Select * FROM " + this.Conec1.NombreTabla;
            this.Conec1.EsSelect = true;
            this.Conec1.conectar();

            return this.Conec1.DbDat;
        } // Fin metodo entrega Region DataSet... Todos las regiones en Base de Datos

        public Boolean ingresaRegion(Region region)
        {
            try
            {
                this.configuraConexion();
                this.Conec1.IntruccioneSQL = "INSERT INTO " + this.Conec1.NombreTabla + "(nombre,pais) VALUES ('" + region.Nombre + "'," + region.Pais + ")";
                this.Conec1.EsSelect = false;
                this.Conec1.conectar();
                return true;
                //Ingresa Region a Base de Datos
            }
            catch(Exception e)
            {
                return false;
            }
        }


        public Region buscaRegion(int idRegion)
        {
            Region auxRegion = new Region();
            this.configuraConexion();
            this.Conec1.IntruccioneSQL = "SELECT * FROM " + this.Conec1.NombreTabla + " WHERE id=" + idRegion;
            this.Conec1.EsSelect = true;
            this.Conec1.conectar();


            System.Data.DataTable dt = new System.Data.DataTable();
            dt = this.Conec1.DbDat.Tables[0];

            try
            {
                auxRegion.Id = Convert.ToInt32(dt.Rows[0]["id"]);
                auxRegion.Nombre = (String)dt.Rows[0]["nombre"];
                auxRegion.Pais = Convert.ToInt32(dt.Rows[0]["pais"]);
            }
            catch (Exception e)
            {
                auxRegion.Id = 0;
                auxRegion.Nombre = e.Message + " Mas info: " + e.StackTrace;
                auxRegion.Pais = 0;
            }
            return auxRegion;
        } // Fin metodo buscarRegion por ID

        public Boolean actualizaRegion(Region region)
        {
            Region auxRegion = new Region();
            auxRegion.Id = region.Id;
            auxRegion.Nombre = region.Nombre;
            auxRegion.Pais = region.Pais;

            try
            {
                this.configuraConexion();
                this.Conec1.IntruccioneSQL = "UPDATE " + this.Conec1.NombreTabla + " SET nombre ='" + auxRegion.Nombre + "' WHERE id=" + auxRegion.Id;
                this.Conec1.EsSelect = true;
                this.Conec1.conectar();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public Boolean eliminaRegion(int idRegion)
        {
            try
            {
                this.configuraConexion();
                this.Conec1.IntruccioneSQL = "DELETE FROM " + this.Conec1.NombreTabla + " WHERE id=" + idRegion;
                this.Conec1.EsSelect = true;
                this.Conec1.conectar();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public Region retornaElementoPorFila(int fila)
        {
            Region auxRegion = new Region();
            this.configuraConexion();
            this.Conec1.IntruccioneSQL = "Select * FROM " + this.Conec1.NombreTabla;
            this.Conec1.EsSelect = true;
            this.Conec1.conectar();


            System.Data.DataTable dt = new System.Data.DataTable();
            dt = this.Conec1.DbDat.Tables[0];

            try
            {
                auxRegion.Id = Convert.ToInt32(dt.Rows[0]["id"]);
                auxRegion.Nombre = (String)dt.Rows[fila]["nombre"];
                auxRegion.Pais = Convert.ToInt32(dt.Rows[fila]["pais"]);
            }
            catch
            {
                auxRegion.Id = 0;
                auxRegion.Nombre = "";
                auxRegion.Pais = 0;
            }


            return auxRegion;
        } // Fin metodo retorna Region por numero de Fila
    }
}
