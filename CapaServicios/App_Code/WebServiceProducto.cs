using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;
using CapaNegocio;

/// <summary>
/// Descripción breve de WebServiceProducto
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
// [System.Web.Script.Services.ScriptService]
public class WebServiceProducto : System.Web.Services.WebService
{

    public WebServiceProducto()
    {

        //Elimine la marca de comentario de la línea siguiente si utiliza los componentes diseñados 
        //InitializeComponent(); 
    }

    [WebMethod]
    public ArrayList retornaTodosLosProductos()
    {
        CapaNegocio.NegocioProducto auxNegocio = new CapaNegocio.NegocioProducto();

        return auxNegocio.entregaProductoArray();
    }

    [WebMethod]
    public Boolean guardarProducto(CapaDTO.Producto producto)
    {
        CapaNegocio.NegocioProducto auxNegocio = new CapaNegocio.NegocioProducto();
        Boolean resultado = auxNegocio.ingresaProducto(producto);
        return resultado;
    }

    [WebMethod]
    public CapaDTO.Producto posicionProducto(int posicion)
    {
        CapaNegocio.NegocioProducto auxNegocio = new CapaNegocio.NegocioProducto();
        return auxNegocio.retornaElementoPorFila(posicion);
    }


    [WebMethod]
    public CapaDTO.Producto buscaProducto(int idProducto)
    {
        CapaNegocio.NegocioProducto auxNegocio = new CapaNegocio.NegocioProducto();
        return auxNegocio.buscaProducto(idProducto);
    }

    [WebMethod]
    public Boolean actualizaProducto(CapaDTO.Producto producto)
    {
        CapaNegocio.NegocioProducto auxNegocio = new CapaNegocio.NegocioProducto();
        Boolean resultado = auxNegocio.actualizaProducto(producto);
        return resultado;
    }

    [WebMethod]
    public Boolean eliminaProducto(int idProducto)
    {
        CapaNegocio.NegocioProducto auxNegocio = new CapaNegocio.NegocioProducto();
        Boolean resultado = auxNegocio.eliminaProducto(idProducto);
        return resultado;
    }

    [WebMethod]
    public Boolean esActivo()
    {
        return true;
    }

}
