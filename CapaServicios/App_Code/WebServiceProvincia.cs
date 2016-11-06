using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;
using CapaNegocio;

/// <summary>
/// Descripción breve de WebServiceProvincia
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
// [System.Web.Script.Services.ScriptService]
public class WebServiceProvincia : System.Web.Services.WebService
{

    public WebServiceProvincia()
    {

        //Elimine la marca de comentario de la línea siguiente si utiliza los componentes diseñados 
        //InitializeComponent(); 
    }

    [WebMethod]
    public ArrayList retornaTodasLasProvincias()
    {
        CapaNegocio.NegocioProvincia auxNegocio = new CapaNegocio.NegocioProvincia();

        return auxNegocio.entregaProvinciaArray();
    }

    [WebMethod]
    public Boolean guardarProvincia(CapaDTO.Provincia provincia)
    {
        CapaNegocio.NegocioProvincia auxNegocio = new CapaNegocio.NegocioProvincia();
        Boolean resultado = auxNegocio.ingresaProvincia(provincia);
        return resultado;
    }

    [WebMethod]
    public CapaDTO.Provincia posicionProvincia(int posicion)
    {
        CapaNegocio.NegocioProvincia auxNegocio = new CapaNegocio.NegocioProvincia();
        return auxNegocio.retornaElementoPorFila(posicion);
    }


    [WebMethod]
    public CapaDTO.Provincia buscarProvincia(int idProvincia)
    {
        CapaNegocio.NegocioProvincia auxNegocio = new CapaNegocio.NegocioProvincia();
        return auxNegocio.buscaProvincia(idProvincia);
    }

    [WebMethod]
    public Boolean actualizaProvincia(CapaDTO.Provincia provincia)
    {
        CapaNegocio.NegocioProvincia auxNegocio = new CapaNegocio.NegocioProvincia();
        Boolean resultado = auxNegocio.actualizaProvincia(provincia);
        return resultado;
    }

    [WebMethod]
    public Boolean eliminaProvincia(int idProvincia)
    {
        CapaNegocio.NegocioProvincia auxNegocio = new CapaNegocio.NegocioProvincia();
        Boolean resultado = auxNegocio.eliminaProvincia(idProvincia);
        return resultado;
    }

    [WebMethod]
    public Boolean esActivo()
    {
        return true;
    }

}
