using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;
using CapaNegocio;

/// <summary>
/// Descripción breve de WebServiceEgreso
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
// [System.Web.Script.Services.ScriptService]
public class WebServiceEgreso : System.Web.Services.WebService
{

    public WebServiceEgreso()
    {

        //Elimine la marca de comentario de la línea siguiente si utiliza los componentes diseñados 
        //InitializeComponent(); 
    }

    [WebMethod]
    public ArrayList retornaTodosLosEgresos()
    {
        CapaNegocio.NegocioEgreso auxNegocio = new CapaNegocio.NegocioEgreso();

        return auxNegocio.entregaEgresoArray();
    }

    [WebMethod]
    public Boolean guardarEgreso(CapaDTO.Egreso egreso)
    {
        CapaNegocio.NegocioEgreso auxNegocio = new CapaNegocio.NegocioEgreso();
        Boolean resultado = auxNegocio.ingresaEgreso(egreso);
        return resultado;
    }

    [WebMethod]
    public CapaDTO.Egreso posicionEgreso(int posicion)
    {
        CapaNegocio.NegocioEgreso auxNegocio = new CapaNegocio.NegocioEgreso();
        return auxNegocio.retornaElementoPorFila(posicion);
    }


    [WebMethod]
    public CapaDTO.Egreso buscaEgreso(int idEgreso)
    {
        CapaNegocio.NegocioEgreso auxNegocio = new CapaNegocio.NegocioEgreso();
        return auxNegocio.buscaEgreso(idEgreso);
    }

    [WebMethod]
    public Boolean actualizaEgreso(CapaDTO.Egreso egreso)
    {
        CapaNegocio.NegocioEgreso auxNegocio = new CapaNegocio.NegocioEgreso();
        Boolean resultado = auxNegocio.actualizaEgreso(egreso);
        return resultado;
    }

    [WebMethod]
    public Boolean eliminaEgreso(int idEgreso)
    {
        CapaNegocio.NegocioEgreso auxNegocio = new CapaNegocio.NegocioEgreso();
        Boolean resultado = auxNegocio.eliminaEgreso(idEgreso);
        return resultado;
    }

    [WebMethod]
    public Boolean esActivo()
    {
        return true;
    }

}
