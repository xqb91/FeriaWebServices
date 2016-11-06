using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AplicacionDePrueba
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            string nombre = txtNombre.Text;

            ServicePais.WebServicePaisSoapClient auxMantenedor = new ServicePais.WebServicePaisSoapClient();
            ServicePais.Pais auxPais = new ServicePais.Pais();

            auxPais.Nombre = nombre;
            Boolean resultado;

            try
            {
                resultado = auxMantenedor.guardarPais(auxPais);
                if (resultado)
                {
                    MessageBox.Show("Pais Ingresado Exitosamente!");
                }
                else
                {
                    //MessageBox.Show("No se pudo ingresar Pais");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
