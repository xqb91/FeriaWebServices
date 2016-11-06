using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;
using CapaNegocio;

/// <summary>
/// Descripción breve de WebServiceProductor
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
// [System.Web.Script.Services.ScriptService]
public class WebServiceProductor : System.Web.Services.WebService
{

    public WebServiceProductor()
    {

        //Elimine la marca de comentario de la línea siguiente si utiliza los componentes diseñados 
        //InitializeComponent(); 
    }

    [WebMethod]
    public ArrayList retornaTodosLosProductores()
    {
        CapaNegocio.NegocioProductor auxNegocio = new CapaNegocio.NegocioProductor();

        return auxNegocio.entregaProductoresArray();
    }

    [WebMethod]
    public Boolean guardarProductor(CapaDTO.Productor productor)
    {
        CapaNegocio.NegocioProductor auxNegocio = new CapaNegocio.NegocioProductor();
        Boolean resultado = auxNegocio.ingresaProductor(productor);
        return resultado;
    }

    [WebMethod]
    public CapaDTO.Productor posicionProductor(int posicion)
    {
        CapaNegocio.NegocioProductor auxNegocio = new CapaNegocio.NegocioProductor();
        return auxNegocio.retornaElementoPorFila(posicion);
    }


    [WebMethod]
    public CapaDTO.Productor buscaProductor(string usuarioProductor)
    {
        CapaNegocio.NegocioProductor auxNegocio = new CapaNegocio.NegocioProductor();
        return auxNegocio.buscaProductor(usuarioProductor);
    }

    [WebMethod]
    public Boolean actualizaProductor(CapaDTO.Productor productor)
    {
        CapaNegocio.NegocioProductor auxNegocio = new CapaNegocio.NegocioProductor();
        Boolean resultado = auxNegocio.actualizaProductor(productor);
        return resultado;
    }

    [WebMethod]
    public Boolean eliminaProductor(int idProductor)
    {
        CapaNegocio.NegocioProductor auxNegocio = new CapaNegocio.NegocioProductor();
        Boolean resultado = auxNegocio.eliminaProductor(idProductor);
        return resultado;
    }

    [WebMethod]
    public Boolean esActivo()
    {
        return true;
    }

}
