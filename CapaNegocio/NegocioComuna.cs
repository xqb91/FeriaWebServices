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
    public class NegocioComuna
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
            this.Conec1.NombreTabla = "Comuna";
        }

        public ArrayList entregaComunaArray()
        {
            ArrayList listaComuna = new ArrayList();
            this.configuraConexion();
            this.Conec1.IntruccioneSQL = "Select * FROM " + this.Conec1.NombreTabla+" ORDER BY NOMBRE ASC";
            this.Conec1.EsSelect = true;
            this.Conec1.conectar();

            foreach (System.Data.DataRow dr in this.Conec1.DbDat.Tables[this.Conec1.NombreTabla].Rows)
            {
                Comuna auxComuna = new Comuna();
                auxComuna.Id = Convert.ToInt32(dr["id"]);
                auxComuna.Nombre = (String)dr["nombre"];
                auxComuna.Provincia = Convert.ToInt32(dr["provincia"]);
                listaComuna.Add(auxComuna);
            }
            return listaComuna;
        } // Fin metodo entrega Arraylist de Comuna


        public DataSet entregaComunaDataSet()
        {
            this.configuraConexion();
            this.Conec1.IntruccioneSQL = "Select * FROM " + this.Conec1.NombreTabla;
            this.Conec1.EsSelect = true;
            this.Conec1.conectar();

            return this.Conec1.DbDat;
        } // Fin metodo entrega Comuna DataSet... Todos las comunas en Base de Datos

        public Boolean ingresaComuna(Comuna comuna)
        {
            try
            {
                this.configuraConexion();
                this.Conec1.IntruccioneSQL = "INSERT INTO " + this.Conec1.NombreTabla + "(nombre,provincia) VALUES ('" + comuna.Nombre + "'," + comuna.Provincia + ")";
                this.Conec1.EsSelect = false;
                this.Conec1.conectar();
                return true;
                //Ingresa Comuna a Base de Datos
            }
            catch(Exception e)
            {
                return false;
            }
        }


        public Comuna buscaComuna(int idComuna)
        {
            Comuna auxComuna = new Comuna();
            this.configuraConexion();
            this.Conec1.IntruccioneSQL = "SELECT * FROM " + this.Conec1.NombreTabla + " WHERE id=" + idComuna;
            this.Conec1.EsSelect = true;
            this.Conec1.conectar();


            System.Data.DataTable dt = new System.Data.DataTable();
            dt = this.Conec1.DbDat.Tables[0];

            try
            {
                auxComuna.Id = Convert.ToInt32(dt.Rows[0]["id"]);
                auxComuna.Nombre = (String)dt.Rows[0]["nombre"];
                auxComuna.Provincia = Convert.ToInt32(dt.Rows[0]["provincia"]);
            }
            catch (Exception e)
            {
                auxComuna.Nombre = e.Message + " Mas info: " + e.StackTrace;
                auxComuna.Provincia = 0;
            }
            return auxComuna;
        } // Fin metodo buscarPais por ID

        public Boolean actualizaComuna(Comuna comuna)
        {
            Comuna auxComuna = new Comuna();
            auxComuna.Id = comuna.Id;
            auxComuna.Nombre = comuna.Nombre;
            auxComuna.Provincia = comuna.Provincia;

            try
            {
                this.configuraConexion();
                this.Conec1.IntruccioneSQL = "UPDATE " + this.Conec1.NombreTabla + " SET nombre ='" + auxComuna.Nombre + "' WHERE id=" + auxComuna.Id;
                this.Conec1.EsSelect = true;
                this.Conec1.conectar();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public Boolean eliminaComuna(int idComuna)
        {
            try
            {
                this.configuraConexion();
                this.Conec1.IntruccioneSQL = "DELETE FROM " + this.Conec1.NombreTabla + " WHERE id=" + idComuna;
                this.Conec1.EsSelect = true;
                this.Conec1.conectar();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public Comuna retornaElementoPorFila(int fila)
        {
            Comuna auxComuna = new Comuna();
            this.configuraConexion();
            this.Conec1.IntruccioneSQL = "Select * FROM " + this.Conec1.NombreTabla;
            this.Conec1.EsSelect = true;
            this.Conec1.conectar();


            System.Data.DataTable dt = new System.Data.DataTable();
            dt = this.Conec1.DbDat.Tables[0];

            try
            {
                auxComuna.Id = Convert.ToInt32(dt.Rows[0]["id"]);
                auxComuna.Nombre = (String)dt.Rows[fila]["nombre"];
                auxComuna.Provincia = Convert.ToInt32(dt.Rows[fila]["provincia"]);
            }
            catch
            {
                auxComuna.Id = 0;
                auxComuna.Nombre = "";
                auxComuna.Provincia = 0;
            }


            return auxComuna;
        } // Fin metodo retorna Pais por numero de Fila
    }
}
