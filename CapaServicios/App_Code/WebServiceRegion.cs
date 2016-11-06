using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;
using CapaNegocio;

/// <summary>
/// Descripción breve de WebServiceRegion
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
// [System.Web.Script.Services.ScriptService]
public class WebServiceRegion : System.Web.Services.WebService
{

    public WebServiceRegion()
    {

        //Elimine la marca de comentario de la línea siguiente si utiliza los componentes diseñados 
        //InitializeComponent(); 
    }

    [WebMethod]
    public ArrayList retornaTodasLasRegiones()
    {
        CapaNegocio.NegocioRegion auxNegocio = new CapaNegocio.NegocioRegion();

        return auxNegocio.entregaRegionArray();
    }

    [WebMethod]
    public Boolean guardarRegion(CapaDTO.Region region)
    {
        CapaNegocio.NegocioRegion auxNegocio = new CapaNegocio.NegocioRegion();
        Boolean resultado = auxNegocio.ingresaRegion(region);
        return resultado;
    }

    [WebMethod]
    public CapaDTO.Region posicionRegion(int posicion)
    {
        CapaNegocio.NegocioRegion auxNegocio = new CapaNegocio.NegocioRegion();
        return auxNegocio.retornaElementoPorFila(posicion);
    }


    [WebMethod]
    public CapaDTO.Region buscaRegion(int idRegion)
    {
        CapaNegocio.NegocioRegion auxNegocio = new CapaNegocio.NegocioRegion();
        return auxNegocio.buscaRegion(idRegion);
    }

    [WebMethod]
    public Boolean actualizaRegion(CapaDTO.Region region)
    {
        CapaNegocio.NegocioRegion auxNegocio = new CapaNegocio.NegocioRegion();
        Boolean resultado = auxNegocio.actualizaRegion(region);
        return resultado;
    }

    [WebMethod]
    public Boolean eliminaRegion(int idRegion)
    {
        CapaNegocio.NegocioRegion auxNegocio = new CapaNegocio.NegocioRegion();
        Boolean resultado = auxNegocio.eliminaRegion(idRegion);
        return resultado;
    }

    [WebMethod]
    public Boolean esActivo()
    {
        return true;
    }

}
