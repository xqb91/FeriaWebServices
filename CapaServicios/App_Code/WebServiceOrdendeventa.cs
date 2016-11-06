using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;
using CapaNegocio;

/// <summary>
/// Descripción breve de WebServiceOrdendeventa
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
// [System.Web.Script.Services.ScriptService]
public class WebServiceOrdendeventa : System.Web.Services.WebService
{

    public WebServiceOrdendeventa()
    {

        //Elimine la marca de comentario de la línea siguiente si utiliza los componentes diseñados 
        //InitializeComponent(); 
    }

    [WebMethod]
    public ArrayList retornaTodasLasOrdendenesVentas()
    {
        CapaNegocio.NegocioOrdendeventa auxNegocio = new CapaNegocio.NegocioOrdendeventa();

        return auxNegocio.entregaOrdendeventaArray();
    }

    [WebMethod]
    public Boolean guardarOrdendeventa(CapaDTO.Ordendeventa ordendeventa)
    {
        CapaNegocio.NegocioOrdendeventa auxNegocio = new CapaNegocio.NegocioOrdendeventa();
        Boolean resultado = auxNegocio.ingresaOrdendeventa(ordendeventa);
        return resultado;
    }

    [WebMethod]
    public CapaDTO.Ordendeventa posicionOrdendeventa(int posicion)
    {
        CapaNegocio.NegocioOrdendeventa auxNegocio = new CapaNegocio.NegocioOrdendeventa();
        return auxNegocio.retornaElementoPorFila(posicion);
    }


    [WebMethod]
    public CapaDTO.Ordendeventa buscaOrdendeveta(int idOrden)
    {
        CapaNegocio.NegocioOrdendeventa auxNegocio = new CapaNegocio.NegocioOrdendeventa();
        return auxNegocio.buscaOrden(idOrden);
    }

    [WebMethod]
    public Boolean actualizaOrdendeventa(CapaDTO.Ordendeventa orden)
    {
        CapaNegocio.NegocioOrdendeventa auxNegocio = new CapaNegocio.NegocioOrdendeventa();
        Boolean resultado = auxNegocio.actualizaOrden(orden);
        return resultado;
    }

    [WebMethod]
    public Boolean eliminaOrdendeventa(int idOrden)
    {
        CapaNegocio.NegocioOrdendeventa auxNegocio = new CapaNegocio.NegocioOrdendeventa();
        Boolean resultado = auxNegocio.eliminaOrden(idOrden);
        return resultado;
    }

    [WebMethod]
    public Boolean esActivo()
    {
        return true;
    }

}
