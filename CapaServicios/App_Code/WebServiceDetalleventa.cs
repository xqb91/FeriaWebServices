using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;
using CapaNegocio;

/// <summary>
/// Descripción breve de WebServiceDetalleventa
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
// [System.Web.Script.Services.ScriptService]
public class WebServiceDetalleventa : System.Web.Services.WebService
{

    public WebServiceDetalleventa()
    {

        //Elimine la marca de comentario de la línea siguiente si utiliza los componentes diseñados 
        //InitializeComponent(); 
    }

    [WebMethod]
    public ArrayList retornaTodosLosDetalleVentas()
    {
        CapaNegocio.NegocioDetalleventa auxNegocio = new CapaNegocio.NegocioDetalleventa();

        return auxNegocio.entregaDetalleventaArray();
    }

    [WebMethod]
    public Boolean guardarDetalleventa(CapaDTO.Detalleventa detalleventa)
    {
        CapaNegocio.NegocioDetalleventa auxNegocio = new CapaNegocio.NegocioDetalleventa();
        Boolean resultado = auxNegocio.ingresaDetalleventa(detalleventa);
        return resultado;
    }

    [WebMethod]
    public CapaDTO.Detalleventa posicionDetalleventa(int posicion)
    {
        CapaNegocio.NegocioDetalleventa auxNegocio = new CapaNegocio.NegocioDetalleventa();
        return auxNegocio.retornaElementoPorFila(posicion);
    }


    [WebMethod]
    public CapaDTO.Detalleventa buscaDetalleventa(int idDetalle)
    {
        CapaNegocio.NegocioDetalleventa auxNegocio = new CapaNegocio.NegocioDetalleventa();
        return auxNegocio.buscaDetalleventa(idDetalle);
    }

    [WebMethod]
    public Boolean actualizaDetalleventa(CapaDTO.Detalleventa detalle)
    {
        CapaNegocio.NegocioDetalleventa auxNegocio = new CapaNegocio.NegocioDetalleventa();
        Boolean resultado = auxNegocio.actualizaDetalleventa(detalle);
        return resultado;
    }

    [WebMethod]
    public Boolean eliminaDetalleventa(int idDetalle)
    {
        CapaNegocio.NegocioDetalleventa auxNegocio = new CapaNegocio.NegocioDetalleventa();
        Boolean resultado = auxNegocio.eliminaDetalleventa(idDetalle);
        return resultado;
    }

    [WebMethod]
    public Boolean esActivo()
    {
        return true;
    }

}
