using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;
using CapaNegocio;

/// <summary>
/// Descripción breve de WebServiceStock
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
// [System.Web.Script.Services.ScriptService]
public class WebServiceStock : System.Web.Services.WebService
{

    public WebServiceStock()
    {

        //Elimine la marca de comentario de la línea siguiente si utiliza los componentes diseñados 
        //InitializeComponent(); 
    }

    [WebMethod]
    public ArrayList retornaTodosLosStock()
    {
        CapaNegocio.NegocioStock auxNegocio = new CapaNegocio.NegocioStock();

        return auxNegocio.entregaStockArray();
    }

    [WebMethod]
    public Boolean guardarStock(CapaDTO.Stock stock)
    {
        CapaNegocio.NegocioStock auxNegocio = new CapaNegocio.NegocioStock();
        Boolean resultado = auxNegocio.ingresaStock(stock);
        return resultado;
    }

    [WebMethod]
    public CapaDTO.Stock posicionStock(int posicion)
    {
        CapaNegocio.NegocioStock auxNegocio = new CapaNegocio.NegocioStock();
        return auxNegocio.retornaElementoPorFila(posicion);
    }


    [WebMethod]
    public CapaDTO.Stock buscaStock(int idStock)
    {
        CapaNegocio.NegocioStock auxNegocio = new CapaNegocio.NegocioStock();
        return auxNegocio.buscaStock(idStock);
    }

    [WebMethod]
    public Boolean actualizaStock(CapaDTO.Stock stock)
    {
        CapaNegocio.NegocioStock auxNegocio = new CapaNegocio.NegocioStock();
        Boolean resultado = auxNegocio.actualizaStock(stock);
        return resultado;
    }

    [WebMethod]
    public Boolean eliminaStock(int idStock)
    {
        CapaNegocio.NegocioStock auxNegocio = new CapaNegocio.NegocioStock();
        Boolean resultado = auxNegocio.eliminaStock(idStock);
        return resultado;
    }

    [WebMethod]
    public Boolean esActivo()
    {
        return true;
    }

}
