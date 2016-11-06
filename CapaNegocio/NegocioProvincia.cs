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
    public class NegocioProvincia
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
            this.Conec1.NombreTabla = "Provincia";
        }

        public ArrayList entregaProvinciaArray()
        {
            ArrayList listaProvincias = new ArrayList();
            this.configuraConexion();
            this.Conec1.IntruccioneSQL = "Select * FROM " + this.Conec1.NombreTabla;
            this.Conec1.EsSelect = true;
            this.Conec1.conectar();

            foreach (System.Data.DataRow dr in this.Conec1.DbDat.Tables[this.Conec1.NombreTabla].Rows)
            {
                Provincia auxProvincia = new Provincia();
                auxProvincia.Id = Convert.ToInt32(dr["id"]);
                auxProvincia.Nombre = (String)dr["nombre"];
                auxProvincia.Region = (int)dr["region"];

                listaProvincias.Add(auxProvincia);
            }
            return listaProvincias;
        } // Fin metodo entrega Arraylist de Provincias


        public DataSet entregaProvinciaDataSet()
        {
            this.configuraConexion();
            this.Conec1.IntruccioneSQL = "Select * FROM " + this.Conec1.NombreTabla;
            this.Conec1.EsSelect = true;
            this.Conec1.conectar();

            return this.Conec1.DbDat;
        } // Fin metodo entrega Provincia DataSet... Todos las provincias en Base de Datos

        public Boolean ingresaProvincia(Provincia provincia)
        {
            try
            {
                this.configuraConexion();
                this.Conec1.IntruccioneSQL = "INSERT INTO " + this.Conec1.NombreTabla + "(nombre,region) VALUES ('" + provincia.Nombre + "'," + provincia.Region + ")";
                this.Conec1.EsSelect = false;
                this.Conec1.conectar();
                return true;
                //Ingresa Pais a Base de Datos
            }
            catch(Exception e)
            {
                return false;
            }
        }


        public Provincia buscaProvincia(int idProvincia)
        {
            Provincia auxProvincia = new Provincia();
            this.configuraConexion();
            this.Conec1.IntruccioneSQL = "SELECT * FROM " + this.Conec1.NombreTabla + " WHERE id=" + idProvincia;
            this.Conec1.EsSelect = true;
            this.Conec1.conectar();


            System.Data.DataTable dt = new System.Data.DataTable();
            dt = this.Conec1.DbDat.Tables[0];

            try
            {
                auxProvincia.Id = Convert.ToInt32(dt.Rows[0]["id"]);
                auxProvincia.Nombre = (String)dt.Rows[0]["nombre"];
                auxProvincia.Region = Convert.ToInt32(dt.Rows[0]["region"]);
            }
            catch (Exception e)
            {
                auxProvincia.Nombre = e.Message + " Mas info: " + e.StackTrace;
                auxProvincia.Region = 0;
            }
            return auxProvincia;
        } // Fin metodo buscarProvincia por ID

        public Boolean actualizaProvincia(Provincia provincia)
        {
            Provincia auxProvincia = new Provincia();
            auxProvincia.Id = provincia.Id;
            auxProvincia.Nombre = provincia.Nombre;
            auxProvincia.Region = provincia.Region;

            try
            {
                this.configuraConexion();
                this.Conec1.IntruccioneSQL = "UPDATE " + this.Conec1.NombreTabla + " SET nombre ='" + auxProvincia.Nombre + "' WHERE id=" + auxProvincia.Id;
                this.Conec1.EsSelect = true;
                this.Conec1.conectar();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public Boolean eliminaProvincia(int idProvincia)
        {
            try
            {
                this.configuraConexion();
                this.Conec1.IntruccioneSQL = "DELETE FROM " + this.Conec1.NombreTabla + " WHERE id=" + idProvincia;
                this.Conec1.EsSelect = true;
                this.Conec1.conectar();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public Provincia retornaElementoPorFila(int fila)
        {
            Provincia auxProvincia = new Provincia();
            this.configuraConexion();
            this.Conec1.IntruccioneSQL = "Select * FROM " + this.Conec1.NombreTabla;
            this.Conec1.EsSelect = true;
            this.Conec1.conectar();


            System.Data.DataTable dt = new System.Data.DataTable();
            dt = this.Conec1.DbDat.Tables[0];

            try
            {
                auxProvincia.Id = Convert.ToInt32(dt.Rows[0]["id"]);
                auxProvincia.Nombre = (String)dt.Rows[fila]["nombre"];
                auxProvincia.Region = Convert.ToInt32(dt.Rows[fila]["region"]);
            }
            catch
            {
                auxProvincia.Nombre = "";
                auxProvincia.Region = 0;
            }


            return auxProvincia;
        } // Fin metodo retorna Provincia por numero de Fila
    }
}
