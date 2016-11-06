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
    public class NegocioProducto
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
            this.Conec1.NombreTabla = "Producto";
        }

        public ArrayList entregaProductoArray()
        {
            ArrayList listaProducto = new ArrayList();
            this.configuraConexion();
            this.Conec1.IntruccioneSQL = "Select * FROM " + this.Conec1.NombreTabla;
            this.Conec1.EsSelect = true;
            this.Conec1.conectar();

            foreach (System.Data.DataRow dr in this.Conec1.DbDat.Tables[this.Conec1.NombreTabla].Rows)
            {
                Producto auxProducto = new Producto();
                auxProducto.Id = Convert.ToInt32(dr["id"]);
                auxProducto.Nombre = (String)dr["nombre"];
                auxProducto.Familia = Convert.ToInt32(dr["familia"]);
                auxProducto.Fotografia = (String)dr["fotografia"];
                auxProducto.Descripcion = (String)dr["descripcion"];
                auxProducto.Categoria = Convert.ToInt32(dr["categoria"]);
                auxProducto.Precio = Convert.ToInt32(dr["precio"]);
                listaProducto.Add(auxProducto);
            }
            return listaProducto;
        } // Fin metodo entrega Arraylist de Productos


        public DataSet entregaProductoDataSet()
        {
            this.configuraConexion();
            this.Conec1.IntruccioneSQL = "Select * FROM " + this.Conec1.NombreTabla;
            this.Conec1.EsSelect = true;
            this.Conec1.conectar();

            return this.Conec1.DbDat;
        } // Fin metodo entrega Producto DataSet... Todos los productos en Base de Datos

        public Boolean ingresaProducto(Producto producto)
        {
            try
            {
                this.configuraConexion();
                this.Conec1.IntruccioneSQL = "INSERT INTO " + this.Conec1.NombreTabla + "(nombre,familia,fotografia,descripcion,categoria,precio) VALUES ('" + producto.Nombre + "'," + producto.Familia + ",'" + producto.Fotografia + "','" + producto.Descripcion + "'," + producto.Categoria + ","+ producto.Precio +")";
                this.Conec1.EsSelect = false;
                this.Conec1.conectar();
                return true;
                //Ingresa Producto a Base de Datos
            }
            catch
            {
                return false;
            }
        }


        public Producto buscaProducto(int idProducto)
        {
            Producto auxProducto = new Producto();
            this.configuraConexion();
            this.Conec1.IntruccioneSQL = "SELECT * FROM " + this.Conec1.NombreTabla + " WHERE id=" + idProducto;
            this.Conec1.EsSelect = true;
            this.Conec1.conectar();


            System.Data.DataTable dt = new System.Data.DataTable();
            dt = this.Conec1.DbDat.Tables[0];

            try
            {
                auxProducto.Id = Convert.ToInt32(dt.Rows[0]["id"]);
                auxProducto.Nombre = (String)dt.Rows[0]["nombre"];
                auxProducto.Familia = Convert.ToInt32(dt.Rows[0]["familia"]);
                try
                {
                    auxProducto.Fotografia = (String)dt.Rows[0]["fotografia"];
                }
                catch
                {
                    auxProducto.Fotografia = "";
                }
                try
                {
                    auxProducto.Descripcion = (String)dt.Rows[0]["descripcion"];
                }
                catch
                {
                    auxProducto.Descripcion = "";
                }
                auxProducto.Categoria = Convert.ToInt32(dt.Rows[0]["categoria"]);
                auxProducto.Precio = Convert.ToInt32(dt.Rows[0]["precio"]);
            }
            catch (Exception e)
            {
                auxProducto.Id = 0;
                auxProducto.Nombre = "";
                auxProducto.Familia = 0;
                auxProducto.Fotografia = "";
                auxProducto.Descripcion = "";
                auxProducto.Categoria = 0;
                auxProducto.Precio = 0;
            }
            return auxProducto;
        } // Fin metodo buscarProducto por ID

        public Boolean actualizaProducto(Producto producto)
        {
            Producto auxProducto = new Producto();
            auxProducto.Id = producto.Id;
            auxProducto.Nombre = producto.Nombre;
            auxProducto.Familia = producto.Familia;
            auxProducto.Fotografia = producto.Fotografia;
            auxProducto.Descripcion = producto.Descripcion;
            auxProducto.Categoria = producto.Categoria;
            auxProducto.Precio = producto.Precio;

            try
            {
                this.configuraConexion();
                this.Conec1.IntruccioneSQL = "UPDATE " + this.Conec1.NombreTabla + " SET nombre ='" + auxProducto.Nombre + "', set familia=" + auxProducto.Familia + ", set fotografia='" + auxProducto.Fotografia + "', set descripcion='" + auxProducto.Descripcion + "', set categoria="+ auxProducto.Categoria +", set precio="+ auxProducto.Precio +" WHERE id=" + auxProducto.Id;
                this.Conec1.EsSelect = true;
                this.Conec1.conectar();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public Boolean eliminaProducto(int idProducto)
        {
            try
            {
                this.configuraConexion();
                this.Conec1.IntruccioneSQL = "DELETE FROM " + this.Conec1.NombreTabla + " WHERE id=" + idProducto;
                this.Conec1.EsSelect = true;
                this.Conec1.conectar();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public Producto retornaElementoPorFila(int fila)
        {
            Producto auxProducto = new Producto();
            this.configuraConexion();
            this.Conec1.IntruccioneSQL = "Select * FROM " + this.Conec1.NombreTabla;
            this.Conec1.EsSelect = true;
            this.Conec1.conectar();


            System.Data.DataTable dt = new System.Data.DataTable();
            dt = this.Conec1.DbDat.Tables[0];

            try
            {
                auxProducto.Id = Convert.ToInt32(dt.Rows[0]["id"]);
                auxProducto.Nombre = (String)dt.Rows[fila]["nombre"];
                auxProducto.Familia = Convert.ToInt32(dt.Rows[0]["familia"]);
                auxProducto.Fotografia = (String)dt.Rows[fila]["fotografia"];
                auxProducto.Descripcion = (String)dt.Rows[fila]["descripcion"];
                auxProducto.Categoria = Convert.ToInt32(dt.Rows[0]["categoria"]);
                auxProducto.Precio = Convert.ToInt32(dt.Rows[0]["precio"]);
            }
            catch
            {
                auxProducto.Id = 0;
                auxProducto.Nombre = "";
                auxProducto.Familia = 0;
                auxProducto.Fotografia = "";
                auxProducto.Descripcion = "";
                auxProducto.Categoria = 0;
                auxProducto.Precio = 0;
            }


            return auxProducto;
        } // Fin metodo retorna producto por numero de Fila
    }
}
