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
    public class NegocioPais
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
            this.Conec1.NombreTabla = "Pais";
        }

        public ArrayList entregaPaisrray()
        {
            ArrayList listaPaises = new ArrayList();
            this.configuraConexion();
            this.Conec1.IntruccioneSQL = "Select * FROM " + this.Conec1.NombreTabla;
            this.Conec1.EsSelect = true;
            this.Conec1.conectar();

            foreach (System.Data.DataRow dr in this.Conec1.DbDat.Tables[this.Conec1.NombreTabla].Rows)
            {
                Pais auxPaises = new Pais();
                auxPaises.Id = Convert.ToInt32(dr["id"]);
                auxPaises.Nombre = (String)dr["nombre"];
                listaPaises.Add(auxPaises);
            }
            return listaPaises;
        } // Fin metodo entrega Arraylist de Paises


        public DataSet entregaPaisDataSet()
        {
            this.configuraConexion();
            this.Conec1.IntruccioneSQL = "Select * FROM " + this.Conec1.NombreTabla;
            this.Conec1.EsSelect = true;
            this.Conec1.conectar();

            return this.Conec1.DbDat;
        } // Fin metodo entrega Pais DataSet... Todos los paises en Base de Datos

        public Boolean ingresaPais(Pais pais)
        {
            try
            {
                this.configuraConexion();
                this.Conec1.IntruccioneSQL = "INSERT INTO " + this.Conec1.NombreTabla + "(nombre) VALUES ('" + pais.Nombre + "')";
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


        public Pais buscaPais(int idPais)
        {
            Pais auxPais = new Pais();
            this.configuraConexion();
            this.Conec1.IntruccioneSQL = "SELECT * FROM " + this.Conec1.NombreTabla + " WHERE id=" + idPais;
            this.Conec1.EsSelect = true;
            this.Conec1.conectar();


            System.Data.DataTable dt = new System.Data.DataTable();
            dt = this.Conec1.DbDat.Tables[0];

            try
            {
                auxPais.Id = Convert.ToInt32(dt.Rows[0]["id"]);
                auxPais.Nombre = (String)dt.Rows[0]["nombre"];
            }
            catch(Exception e)
            {
                auxPais.Id = 0;
                auxPais.Nombre = e.Message + " Mas info: "+e.StackTrace;
            }
            return auxPais;
        } // Fin metodo buscarPais por ID

        public Boolean actualizaPais(Pais pais)
        {
            Pais auxPais = new Pais();
            auxPais.Id = pais.Id;
            auxPais.Nombre = pais.Nombre;

            try
            {
                this.configuraConexion();
                this.Conec1.IntruccioneSQL = "UPDATE " + this.Conec1.NombreTabla + " SET nombre ='" + auxPais.Nombre + "' WHERE id=" + auxPais.Id;
                this.Conec1.EsSelect = true;
                this.Conec1.conectar();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public Boolean eliminaPais(int idPais)
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

        public Pais retornaElementoPorFila(int fila)
        {
            Pais auxPais = new Pais();
            this.configuraConexion();
            this.Conec1.IntruccioneSQL = "Select * FROM " + this.Conec1.NombreTabla;
            this.Conec1.EsSelect = true;
            this.Conec1.conectar();


            System.Data.DataTable dt = new System.Data.DataTable();
            dt = this.Conec1.DbDat.Tables[0];

            try
            {
                auxPais.Id = Convert.ToInt32(dt.Rows[0]["id"]);
                auxPais.Nombre = (String)dt.Rows[fila]["nombre"];
            }
            catch
            {
                auxPais.Nombre = "";
            }


            return auxPais;
        } // Fin metodo retorna Pais por numero de Fila
    }
}
