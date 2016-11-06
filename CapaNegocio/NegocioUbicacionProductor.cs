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
    public class NegocioUbicacionProductor
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
            this.Conec1.NombreTabla = "Ubicacionproductor";
        }

        public ArrayList entregaUbicacionProductorArray()
        {
            ArrayList listaUbicacionProductor = new ArrayList();
            this.configuraConexion();
            this.Conec1.IntruccioneSQL = "Select * FROM " + this.Conec1.NombreTabla;
            this.Conec1.EsSelect = true;
            this.Conec1.conectar();

            foreach (System.Data.DataRow dr in this.Conec1.DbDat.Tables[this.Conec1.NombreTabla].Rows)
            {
                UbicacionProductor auxUbicacionPro = new UbicacionProductor();
                auxUbicacionPro.Id = Convert.ToInt32(dr["id"]);
                auxUbicacionPro.Nombre = (String)dr["nombre"];
                auxUbicacionPro.Longitud = (String)dr["longitud"];
                auxUbicacionPro.Latitud = (String)dr["latitud"];
                auxUbicacionPro.Direccion = (String)dr["direccion"];
                auxUbicacionPro.Comuna = Convert.ToInt32(dr["comuna"]);
                auxUbicacionPro.Referencia = (String)dr["referencia"];
                auxUbicacionPro.Productor = Convert.ToInt32(dr["id"]);
                listaUbicacionProductor.Add(auxUbicacionPro);
            }
            return listaUbicacionProductor;
        } // Fin metodo entrega Arraylist de ubicacion de productor


        public DataSet entregaUbicacionProductorDataSet()
        {
            this.configuraConexion();
            this.Conec1.IntruccioneSQL = "Select * FROM " + this.Conec1.NombreTabla;
            this.Conec1.EsSelect = true;
            this.Conec1.conectar();

            return this.Conec1.DbDat;
        } // Fin metodo entrega ubicacion productor DataSet... Todos las ubicaciones de productores en Base de Datos

        public Boolean ingresaUbicacionPro(UbicacionProductor ubicacionPro)
        {
            try
            {
                this.configuraConexion();
                this.Conec1.IntruccioneSQL = "INSERT INTO " + this.Conec1.NombreTabla + "(nombre,longitud,latitud,direccion,comuna,referencia,productor) VALUES ('" + ubicacionPro.Nombre + "','" + ubicacionPro.Longitud + "','" + ubicacionPro.Latitud + "','" + ubicacionPro.Direccion + "'," + ubicacionPro.Comuna + ",'" + ubicacionPro.Referencia + "'," + ubicacionPro.Productor + ")";
                this.Conec1.EsSelect = false;
                this.Conec1.conectar();
                return true;
                //Ingresa ubicacion productor a Base de Datos
            }
            catch(Exception e)
            {
                return false;
            }
        }


        public UbicacionProductor buscaUbicacionProductor(int idUbicacionPro)
        {
            UbicacionProductor auxUbicacionPro = new UbicacionProductor();
            this.configuraConexion();
            this.Conec1.IntruccioneSQL = "SELECT * FROM " + this.Conec1.NombreTabla + " WHERE id=" + idUbicacionPro;
            this.Conec1.EsSelect = true;
            this.Conec1.conectar();


            System.Data.DataTable dt = new System.Data.DataTable();
            dt = this.Conec1.DbDat.Tables[0];

            try
            {
                auxUbicacionPro.Id = Convert.ToInt32(dt.Rows[0]["id"]);
                auxUbicacionPro.Nombre = (String)dt.Rows[0]["nombre"];
                auxUbicacionPro.Longitud = (String)dt.Rows[0]["longitud"];
                auxUbicacionPro.Latitud = (String)dt.Rows[0]["latitud"];
                auxUbicacionPro.Direccion = (String)dt.Rows[0]["direccion"];
                auxUbicacionPro.Comuna = Convert.ToInt32(dt.Rows[0]["comuna"]);
                auxUbicacionPro.Referencia = (String)dt.Rows[0]["referencia"];
                auxUbicacionPro.Productor = Convert.ToInt32(dt.Rows[0]["productor"]);
            }
            catch (Exception e)
            {
                auxUbicacionPro.Id = 0;
                auxUbicacionPro.Nombre = "";
                auxUbicacionPro.Longitud = "";
                auxUbicacionPro.Latitud = "";
                auxUbicacionPro.Direccion = "";
                auxUbicacionPro.Comuna = 0;
                auxUbicacionPro.Referencia = "";
                auxUbicacionPro.Productor = 0;
            }
            return auxUbicacionPro;
        } // Fin metodo buscarUbicacionProductor por ID

        public Boolean actualizaUbicacionPro(UbicacionProductor ubicacionPro)
        {
            UbicacionProductor auxUbicacionPro = new UbicacionProductor();
            auxUbicacionPro.Id = ubicacionPro.Id;
            auxUbicacionPro.Nombre = ubicacionPro.Nombre;
            auxUbicacionPro.Longitud = ubicacionPro.Longitud;
            auxUbicacionPro.Latitud = ubicacionPro.Latitud;
            auxUbicacionPro.Direccion = ubicacionPro.Direccion;
            auxUbicacionPro.Comuna = ubicacionPro.Comuna;
            auxUbicacionPro.Referencia = ubicacionPro.Referencia;
            auxUbicacionPro.Productor = ubicacionPro.Productor;

            try
            {
                this.configuraConexion();
                this.Conec1.IntruccioneSQL = "UPDATE " + this.Conec1.NombreTabla + " SET nombre ='" + auxUbicacionPro.Nombre + "', SET longitud ='" + auxUbicacionPro.Longitud + "', SET latitud ='" + auxUbicacionPro.Latitud + "', SET direccion ='" + auxUbicacionPro.Direccion + "', SET comuna =" + auxUbicacionPro.Comuna + ", SET referencia ='" + auxUbicacionPro.Referencia + "', SET productor =" + auxUbicacionPro.Productor + " WHERE id=" + auxUbicacionPro.Id;
                this.Conec1.EsSelect = true;
                this.Conec1.conectar();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public Boolean eliminaUbicacionProductor(int idUbicacionPro)
        {
            try
            {
                this.configuraConexion();
                this.Conec1.IntruccioneSQL = "DELETE FROM " + this.Conec1.NombreTabla + " WHERE id=" + idUbicacionPro;
                this.Conec1.EsSelect = true;
                this.Conec1.conectar();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public UbicacionProductor retornaElementoPorFila(int fila)
        {
            UbicacionProductor auxUbicacionPro = new UbicacionProductor();
            this.configuraConexion();
            this.Conec1.IntruccioneSQL = "Select * FROM " + this.Conec1.NombreTabla;
            this.Conec1.EsSelect = true;
            this.Conec1.conectar();


            System.Data.DataTable dt = new System.Data.DataTable();
            dt = this.Conec1.DbDat.Tables[0];

            try
            {
                auxUbicacionPro.Id = Convert.ToInt32(dt.Rows[0]["id"]);
                auxUbicacionPro.Nombre = (String)dt.Rows[0]["nombre"];
                auxUbicacionPro.Longitud = (String)dt.Rows[0]["longitud"];
                auxUbicacionPro.Latitud = (String)dt.Rows[0]["latitud"];
                auxUbicacionPro.Direccion = (String)dt.Rows[0]["direccion"];
                auxUbicacionPro.Comuna = Convert.ToInt32(dt.Rows[0]["comuna"]);
                auxUbicacionPro.Referencia = (String)dt.Rows[0]["referencia"];
                auxUbicacionPro.Productor = Convert.ToInt32(dt.Rows[0]["productor"]);
            }
            catch
            {
                auxUbicacionPro.Id = 0;
                auxUbicacionPro.Nombre = "";
                auxUbicacionPro.Longitud = "";
                auxUbicacionPro.Latitud = "";
                auxUbicacionPro.Direccion = "";
                auxUbicacionPro.Comuna = 0;
                auxUbicacionPro.Referencia = "";
                auxUbicacionPro.Productor = 0;
            }


            return auxUbicacionPro;
        } // Fin metodo retorna ubicacion productor por numero de Fila
    }
}
