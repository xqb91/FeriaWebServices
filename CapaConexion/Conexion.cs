using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oracle.ManagedDataAccess.Client;
using System.Windows.Forms;

namespace CapaConexion
{
    public class Conexion
    {
        private String nombreBaseDeDatos;
        private String nombreTabla;
        private String cadenaConexion;
        private String intruccioneSQL;
        private OracleConnection dbConnection;
        private System.Data.DataSet dbDat;
        private OracleDataAdapter dbDataAdapter;
        private Boolean esSelect;

        public Conexion()
        {
            this.cadenaConexion = "Data Source=(DESCRIPTION= (ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=LOCALHOST)(PORT=1521))) (CONNECT_DATA=(SERVER=DEDICATED)(SERVICE_NAME=XE))); User Id=portafolio;Password=portafolio;";
            this.nombreBaseDeDatos = "XE";
        }

        public String NombreTabla
        {
            get { return nombreTabla; }
            set { nombreTabla = value; }
        }

        public String NombreBaseDeDatos
        {
            get { return nombreBaseDeDatos; }
            set { nombreBaseDeDatos = value; }
        }


        public String CadenaConexion
        {
            get { return cadenaConexion; }
            set { cadenaConexion = value; }
        }


        public String IntruccioneSQL
        {
            get { return intruccioneSQL; }
            set { intruccioneSQL = value; }
        }


        public OracleConnection DbConnection
        {
            get { return dbConnection; }
            set { dbConnection = value; }
        }


        public System.Data.DataSet DbDat
        {
            get { return dbDat; }
            set { dbDat = value; }
        }


        public OracleDataAdapter DbDataAdapter
        {
            get { return dbDataAdapter; }
            set { dbDataAdapter = value; }
        }


        public Boolean EsSelect
        {
            get { return esSelect; }
            set { esSelect = value; }
        }

        public void abrirConexion()
        {
            try
            {
                this.DbConnection.Open();
            }
            catch (OracleException ex)
            {
                MessageBox.Show("Error al abrir la conexion " + ex.Message);
                return;
            }
        }

        public void cerrarConexion()
        {
            try
            {
                this.DbConnection.Close();
            }
            catch (OracleException ex)
            {
                MessageBox.Show("Error al cerrar la conexion " + ex.Message);
                return;
            }
        }

        public void conectar()
        {
            if (this.NombreBaseDeDatos == "")
            {
                MessageBox.Show("Base de datos en blanco");
                return;
            }

            if (this.NombreTabla == "")
            {
                MessageBox.Show("Tablaen blanco");
                return;
            }

            if (this.CadenaConexion == "")
            {
                MessageBox.Show("Cadena Conexion en blanco");
                return;
            }

            if (this.IntruccioneSQL == "")
            {
                MessageBox.Show("SQL en blanco");
                return;
            }

            try
            {
                this.DbConnection = new OracleConnection(this.CadenaConexion);
            }

            catch (OracleException ex)
            {
                MessageBox.Show("Error al conectar " + ex.Message);
                return;
            }

            this.abrirConexion();

            //if(this.EsSelect == true)

            if (this.EsSelect)
            {
                this.DbDat = new System.Data.DataSet();
                try
                {

                    this.DbDataAdapter = new OracleDataAdapter(this.IntruccioneSQL, this.DbConnection);
                    this.DbDataAdapter.Fill(this.DbDat, this.NombreTabla);
                }
                catch (OracleException ex)
                {
                    MessageBox.Show("Error en el SQL " + ex.Message);
                    return;
                }
            }
            else
            {
                try
                {
                    OracleCommand variableSQL = new OracleCommand(this.IntruccioneSQL, this.DbConnection);
                    variableSQL.ExecuteNonQuery();
                }
                catch (OracleException ex)
                {
                    MessageBox.Show("Error en el SQL " + ex.Message);
                    return;
                }

            }
            this.cerrarConexion();
        }


    }
}
