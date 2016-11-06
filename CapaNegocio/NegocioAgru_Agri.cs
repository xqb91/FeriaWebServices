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
    public class NegocioAgru_Agri
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
            this.Conec1.NombreTabla = "agrupacion_agricultores";
        }

        public ArrayList entregaAgrupacionArray()
        {
            ArrayList listaAgrupaciones = new ArrayList();
            this.configuraConexion();
            this.Conec1.IntruccioneSQL = "Select * FROM " + this.Conec1.NombreTabla;
            this.Conec1.EsSelect = true;
            this.Conec1.conectar();

            foreach (System.Data.DataRow dr in this.Conec1.DbDat.Tables[this.Conec1.NombreTabla].Rows)
            {
                Agrupacion_Agricultores auxAgrupacion = new Agrupacion_Agricultores();
                auxAgrupacion.Id = Convert.ToInt32(dr["id"]);
                auxAgrupacion.Rut = (String)dr["rut"];
                auxAgrupacion.RazonSocial = (String)dr["razonsocial"];
                auxAgrupacion.Direccion = (String)dr["direccion"];
                auxAgrupacion.Telefono = (Char)dr["telefono"];
                auxAgrupacion.Comuna = Convert.ToInt32(dr["comuna"]);
                listaAgrupaciones.Add(auxAgrupacion);
            }
            return listaAgrupaciones;
        } // Fin metodo entrega Arraylist de Agrupaciones


        public DataSet entregaAgrupacionDataSet()
        {
            this.configuraConexion();
            this.Conec1.IntruccioneSQL = "Select * FROM " + this.Conec1.NombreTabla;
            this.Conec1.EsSelect = true;
            this.Conec1.conectar();

            return this.Conec1.DbDat;
        } // Fin metodo entrega Agrupacion de Agricultores DataSet... Todos las agrupaciones en Base de Datos

        public Boolean ingresaAgrupacion(Agrupacion_Agricultores agrupacion)
        {
            try
            {
                this.configuraConexion();
                this.Conec1.IntruccioneSQL = "INSERT INTO " + this.Conec1.NombreTabla + "(rut,razonsocial,direccion,telefono,comuna) VALUES ('" + agrupacion.Rut + "','" + agrupacion.RazonSocial + "','" + agrupacion.Direccion + "','" + agrupacion.Telefono + "'," + agrupacion.Comuna + ")";
                this.Conec1.EsSelect = false;
                this.Conec1.conectar();
                return true;
                //Ingresa Agrupacion de Agricultores a Base de Datos
            }
            catch(Exception e)
            {
                return false;
            }
        }


        public Agrupacion_Agricultores buscaAgrupacion(int idAgrupacion)
        {
            Agrupacion_Agricultores auxAgrupacion = new Agrupacion_Agricultores();
            this.configuraConexion();
            this.Conec1.IntruccioneSQL = "SELECT * FROM " + this.Conec1.NombreTabla + " WHERE id=" + idAgrupacion;
            this.Conec1.EsSelect = true;
            this.Conec1.conectar();


            System.Data.DataTable dt = new System.Data.DataTable();
            dt = this.Conec1.DbDat.Tables[0];

            try
            {
                auxAgrupacion.Id = Convert.ToInt32(dt.Rows[0]["id"]);
                auxAgrupacion.Rut = (String)dt.Rows[0]["rut"];
                auxAgrupacion.RazonSocial = (String)dt.Rows[0]["razonsocial"];
                auxAgrupacion.Direccion = (String)dt.Rows[0]["direccion"];
                auxAgrupacion.Telefono = (Char)dt.Rows[0]["telefono"];
                auxAgrupacion.Comuna = Convert.ToInt32(dt.Rows[0]["comuna"]);
            }
            catch (Exception e)
            {
                auxAgrupacion.Id = 0;
                auxAgrupacion.Rut = e.Message + " Mas info: " + e.StackTrace;
                auxAgrupacion.RazonSocial = "";
                auxAgrupacion.Direccion = "";
                auxAgrupacion.Telefono = '\0';
                auxAgrupacion.Comuna = 0;
            }
            return auxAgrupacion;
        } // Fin metodo buscarAgrupacion por ID

        public Boolean actualizaAgrupacion(Agrupacion_Agricultores agrupacion)
        {
            Agrupacion_Agricultores auxAgrupacion = new Agrupacion_Agricultores();
            auxAgrupacion.Id = agrupacion.Id;
            auxAgrupacion.Rut = agrupacion.Rut;
            auxAgrupacion.RazonSocial = agrupacion.RazonSocial;
            auxAgrupacion.Direccion = agrupacion.Direccion;
            auxAgrupacion.Telefono = agrupacion.Telefono;
            auxAgrupacion.Comuna = agrupacion.Comuna;

            try
            {
                this.configuraConexion();
                this.Conec1.IntruccioneSQL = "UPDATE " + this.Conec1.NombreTabla + " SET direccion ='" + auxAgrupacion.Direccion + "', SET telefono ='"+ auxAgrupacion.Telefono +"' WHERE id=" + auxAgrupacion.Id;
                this.Conec1.EsSelect = true;
                this.Conec1.conectar();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public Boolean eliminaAgrupacion(int idAgrupacion)
        {
            try
            {
                this.configuraConexion();
                this.Conec1.IntruccioneSQL = "DELETE FROM " + this.Conec1.NombreTabla + " WHERE id=" + idAgrupacion;
                this.Conec1.EsSelect = true;
                this.Conec1.conectar();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public Agrupacion_Agricultores retornaElementoPorFila(int fila)
        {
            Agrupacion_Agricultores auxAgrupacion = new Agrupacion_Agricultores();
            this.configuraConexion();
            this.Conec1.IntruccioneSQL = "Select * FROM " + this.Conec1.NombreTabla;
            this.Conec1.EsSelect = true;
            this.Conec1.conectar();


            System.Data.DataTable dt = new System.Data.DataTable();
            dt = this.Conec1.DbDat.Tables[0];

            try
            {
                auxAgrupacion.Id = Convert.ToInt32(dt.Rows[fila]["id"]);
                auxAgrupacion.Rut = (String)dt.Rows[fila]["rut"];
                auxAgrupacion.RazonSocial = (String)dt.Rows[fila]["razonsocial"];
                auxAgrupacion.Direccion = (String)dt.Rows[fila]["direccion"];
                auxAgrupacion.Telefono = (Char)dt.Rows[fila]["telefono"];
                auxAgrupacion.Comuna = Convert.ToInt32(dt.Rows[fila]["comuna"]);
            }
            catch
            {
                auxAgrupacion.Id = 0;
                auxAgrupacion.Rut = "";
                auxAgrupacion.RazonSocial = "";
                auxAgrupacion.Direccion = "";
                auxAgrupacion.Telefono = '\0';
                auxAgrupacion.Comuna = 0;
            }


            return auxAgrupacion;
        } // Fin metodo retorna Agrupacion por numero de Fila
    }
}
