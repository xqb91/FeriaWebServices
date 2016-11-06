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
    public class NegocioCategoria
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
            this.Conec1.NombreTabla = "Categoria";
        }

        public ArrayList entregaCategoriaArray()
        {
            ArrayList listaCategorias = new ArrayList();
            this.configuraConexion();
            this.Conec1.IntruccioneSQL = "Select * FROM " + this.Conec1.NombreTabla;
            this.Conec1.EsSelect = true;
            this.Conec1.conectar();

            foreach (System.Data.DataRow dr in this.Conec1.DbDat.Tables[this.Conec1.NombreTabla].Rows)
            {
                Categoria auxCategoria = new Categoria();
                auxCategoria.Id = Convert.ToInt32(dr["id"]);
                auxCategoria.Nombre = (String)dr["nombre"];
                listaCategorias.Add(auxCategoria);
            }
            return listaCategorias;
        } // Fin metodo entrega Arraylist de Categorias


        public DataSet entregaCategoriaDataSet()
        {
            this.configuraConexion();
            this.Conec1.IntruccioneSQL = "Select * FROM " + this.Conec1.NombreTabla;
            this.Conec1.EsSelect = true;
            this.Conec1.conectar();

            return this.Conec1.DbDat;
        } // Fin metodo entrega Categoria DataSet... Todas las categorias en Base de Datos

        public Boolean ingresaCategoria(Categoria categoria)
        {
            try
            {
                this.configuraConexion();
                this.Conec1.IntruccioneSQL = "INSERT INTO " + this.Conec1.NombreTabla + "(nombre) VALUES ('" + categoria.Nombre + "')";
                this.Conec1.EsSelect = false;
                this.Conec1.conectar();
                return true;
                //Ingresa Categoria a Base de Datos
            }
            catch (Exception e)
            {
                return false;
            }
        }


        public Categoria buscaCategoria(int idCategoria)
        {
            Categoria auxCategoria = new Categoria();
            this.configuraConexion();
            this.Conec1.IntruccioneSQL = "SELECT * FROM " + this.Conec1.NombreTabla + " WHERE id=" + idCategoria;
            this.Conec1.EsSelect = true;
            this.Conec1.conectar();


            System.Data.DataTable dt = new System.Data.DataTable();
            dt = this.Conec1.DbDat.Tables[0];

            try
            {
                auxCategoria.Id = Convert.ToInt32(dt.Rows[0]["id"]);
                auxCategoria.Nombre = (String)dt.Rows[0]["nombre"];
            }
            catch (Exception e)
            {
                auxCategoria.Nombre = e.Message + " Mas info: " + e.StackTrace;
            }
            return auxCategoria;
        } // Fin metodo buscarCategoria por ID

        public Boolean actualizaCategoria(Categoria categoria)
        {
            Categoria auxCategoria = new Categoria();
            auxCategoria.Id = categoria.Id;
            auxCategoria.Nombre = categoria.Nombre;

            try
            {
                this.configuraConexion();
                this.Conec1.IntruccioneSQL = "UPDATE " + this.Conec1.NombreTabla + " SET nombre ='" + auxCategoria.Nombre + "' WHERE id=" + auxCategoria.Id;
                this.Conec1.EsSelect = true;
                this.Conec1.conectar();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }//Actualiza categoria

        public Boolean eliminaCategoria(int idCategoria)
        {
            try
            {
                this.configuraConexion();
                this.Conec1.IntruccioneSQL = "DELETE FROM " + this.Conec1.NombreTabla + " WHERE id=" + idCategoria;
                this.Conec1.EsSelect = true;
                this.Conec1.conectar();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }//Elimina categoria

        public Categoria retornaElementoPorFila(int fila)
        {
            Categoria auxCategoria = new Categoria();
            this.configuraConexion();
            this.Conec1.IntruccioneSQL = "Select * FROM " + this.Conec1.NombreTabla;
            this.Conec1.EsSelect = true;
            this.Conec1.conectar();


            System.Data.DataTable dt = new System.Data.DataTable();
            dt = this.Conec1.DbDat.Tables[0];

            try
            {
                auxCategoria.Id = Convert.ToInt32(dt.Rows[0]["id"]);
                auxCategoria.Nombre = (String)dt.Rows[fila]["nombre"];
            }
            catch
            {
                auxCategoria.Nombre = "";
            }


            return auxCategoria;
        } // Fin metodo retorna Categoria por numero de Fila

    }
}
