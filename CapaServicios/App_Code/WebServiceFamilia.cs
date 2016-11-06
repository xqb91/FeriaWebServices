using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;
using CapaNegocio;

/// <summary>
/// Descripción breve de WebServiceFamilia
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
// [System.Web.Script.Services.ScriptService]
public class WebServiceFamilia : System.Web.Services.WebService
{

    public WebServiceFamilia()
    {

        //Elimine la marca de comentario de la línea siguiente si utiliza los componentes diseñados 
        //InitializeComponent(); 
    }

    [WebMethod]
    public ArrayList retornaTodasLasFamilias()
    {
        CapaNegocio.NegocioFamilia auxNegocio = new CapaNegocio.NegocioFamilia();

        return auxNegocio.entregaFamiliaArray();
    }

    [WebMethod]
    public Boolean guardarFamilia(CapaDTO.Familia familia)
    {
        CapaNegocio.NegocioFamilia auxNegocio = new CapaNegocio.NegocioFamilia();
        Boolean resultado = auxNegocio.ingresaFamilia(familia);
        return resultado;
    }

    [WebMethod]
    public CapaDTO.Familia posicionFamilia(int posicion)
    {
        CapaNegocio.NegocioFamilia auxNegocio = new CapaNegocio.NegocioFamilia();
        return auxNegocio.retornaElementoPorFila(posicion);
    }


    [WebMethod]
    public CapaDTO.Familia buscaFamilia(int idFamilia)
    {
        CapaNegocio.NegocioFamilia auxNegocio = new CapaNegocio.NegocioFamilia();
        return auxNegocio.buscaFamilia(idFamilia);
    }

    [WebMethod]
    public Boolean actualizaFamilia(CapaDTO.Familia familia)
    {
        CapaNegocio.NegocioFamilia auxNegocio = new CapaNegocio.NegocioFamilia();
        Boolean resultado = auxNegocio.actualizaFamilia(familia);
        return resultado;
    }

    [WebMethod]
    public Boolean eliminaFamilia(int idFamilia)
    {
        CapaNegocio.NegocioFamilia auxNegocio = new CapaNegocio.NegocioFamilia();
        Boolean resultado = auxNegocio.eliminaFamilia(idFamilia);
        return resultado;
    }

    [WebMethod]
    public Boolean esActivo()
    {
        return true;
    }

}
