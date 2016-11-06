using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;
using CapaNegocio;

/// <summary>
/// Descripción breve de WebServiceMetodopago
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
// [System.Web.Script.Services.ScriptService]
public class WebServiceMetodopago : System.Web.Services.WebService
{

    public WebServiceMetodopago()
    {

        //Elimine la marca de comentario de la línea siguiente si utiliza los componentes diseñados 
        //InitializeComponent(); 
    }

    [WebMethod]
    public ArrayList retornaTodosLosMetodosPago()
    {
        CapaNegocio.NegocioMetdoPago auxNegocio = new CapaNegocio.NegocioMetdoPago();

        return auxNegocio.entregaMetodopagoArray();
    }

    [WebMethod]
    public Boolean guardarMetodoPago(CapaDTO.MetodoPago metodopago)
    {
        CapaNegocio.NegocioMetdoPago auxNegocio = new CapaNegocio.NegocioMetdoPago();
        Boolean resultado = auxNegocio.ingresaMetodoPago(metodopago);
        return resultado;
    }

    [WebMethod]
    public CapaDTO.MetodoPago posicionMetodopago(int posicion)
    {
        CapaNegocio.NegocioMetdoPago auxNegocio = new CapaNegocio.NegocioMetdoPago();
        return auxNegocio.retornaElementoPorFila(posicion);
    }


    [WebMethod]
    public CapaDTO.MetodoPago buscaMetodopago(int idMetodo)
    {
        CapaNegocio.NegocioMetdoPago auxNegocio = new CapaNegocio.NegocioMetdoPago();
        return auxNegocio.buscaMetodoPago(idMetodo);
    }

    [WebMethod]
    public Boolean actualizaMetodopago(CapaDTO.MetodoPago metodo)
    {
        CapaNegocio.NegocioMetdoPago auxNegocio = new CapaNegocio.NegocioMetdoPago();
        Boolean resultado = auxNegocio.actualizaMetodoPago(metodo);
        return resultado;
    }

    [WebMethod]
    public Boolean eliminaMetodopago(int idMetodo)
    {
        CapaNegocio.NegocioMetdoPago auxNegocio = new CapaNegocio.NegocioMetdoPago();
        Boolean resultado = auxNegocio.eliminaMetodopago(idMetodo);
        return resultado;
    }

    [WebMethod]
    public Boolean esActivo()
    {
        return true;
    }

}
