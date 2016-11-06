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
    public class NegocioFamilia
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
            this.Conec1.NombreTabla = "Familia";
        }

        public ArrayList entregaFamiliaArray()
        {
            ArrayList listaFamilias = new ArrayList();
            this.configuraConexion();
            this.Conec1.IntruccioneSQL = "Select * FROM " + this.Conec1.NombreTabla;
            this.Conec1.EsSelect = true;
            this.Conec1.conectar();

            foreach (System.Data.DataRow dr in this.Conec1.DbDat.Tables[this.Conec1.NombreTabla].Rows)
            {
                Familia auxPaises = new Familia();
                auxPaises.Id = Convert.ToInt32(dr["id"]);
                auxPaises.Nombre = (String)dr["nombre"];
                listaFamilias.Add(auxPaises);
            }
            return listaFamilias;
        } // Fin metodo entrega Arraylist de Familias


        public DataSet entregaFamiliaDataSet()
        {
            this.configuraConexion();
            this.Conec1.IntruccioneSQL = "Select * FROM " + this.Conec1.NombreTabla;
            this.Conec1.EsSelect = true;
            this.Conec1.conectar();

            return this.Conec1.DbDat;
        } // Fin metodo entrega Familias DataSet... Todas las familias en Base de Datos

        public Boolean ingresaFamilia(Familia familia)
        {
            try
            {
                this.configuraConexion();
                this.Conec1.IntruccioneSQL = "INSERT INTO " + this.Conec1.NombreTabla + "(nombre) VALUES ('" + familia.Nombre + "')";
                this.Conec1.EsSelect = false;
                this.Conec1.conectar();
                return true;
                //Ingresa Familias a Base de Datos
            }
            catch(Exception e)
            {
                return false;
            }
        }


        public Familia buscaFamilia(int idFamilia)
        {
            Familia auxFamilia = new Familia();
            this.configuraConexion();
            this.Conec1.IntruccioneSQL = "SELECT * FROM " + this.Conec1.NombreTabla + " WHERE id=" + idFamilia;
            this.Conec1.EsSelect = true;
            this.Conec1.conectar();


            System.Data.DataTable dt = new System.Data.DataTable();
            dt = this.Conec1.DbDat.Tables[0];

            try
            {
                auxFamilia.Id = Convert.ToInt32(dt.Rows[0]["id"]);
                auxFamilia.Nombre = (String)dt.Rows[0]["nombre"];
            }
            catch (Exception e)
            {
                auxFamilia.Id = 0;
                auxFamilia.Nombre = e.Message + " Mas info: " + e.StackTrace;
            }
            return auxFamilia;
        } // Fin metodo buscarFamilias por ID

        public Boolean actualizaFamilia(Familia familia)
        {
            Familia auxFamilia = new Familia();
            auxFamilia.Id = familia.Id;
            auxFamilia.Nombre = familia.Nombre;

            try
            {
                this.configuraConexion();
                this.Conec1.IntruccioneSQL = "UPDATE " + this.Conec1.NombreTabla + " SET nombre ='" + auxFamilia.Nombre + "' WHERE id=" + auxFamilia.Id;
                this.Conec1.EsSelect = true;
                this.Conec1.conectar();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public Boolean eliminaFamilia(int idFamilia)
        {
            try
            {
                this.configuraConexion();
                this.Conec1.IntruccioneSQL = "DELETE FROM " + this.Conec1.NombreTabla + " WHERE id=" + idFamilia;
                this.Conec1.EsSelect = true;
                this.Conec1.conectar();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public Familia retornaElementoPorFila(int fila)
        {
            Familia auxFamilia = new Familia();
            this.configuraConexion();
            this.Conec1.IntruccioneSQL = "Select * FROM " + this.Conec1.NombreTabla;
            this.Conec1.EsSelect = true;
            this.Conec1.conectar();


            System.Data.DataTable dt = new System.Data.DataTable();
            dt = this.Conec1.DbDat.Tables[0];

            try
            {
                auxFamilia.Id = Convert.ToInt32(dt.Rows[0]["id"]);
                auxFamilia.Nombre = (String)dt.Rows[fila]["nombre"];
            }
            catch
            {
                auxFamilia.Nombre = "";
            }


            return auxFamilia;
        } // Fin metodo retorna Familia por numero de Fila
    }
}
