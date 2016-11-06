using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;
using CapaNegocio;

/// <summary>
/// Descripción breve de WebServiceIngreso
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
// [System.Web.Script.Services.ScriptService]
public class WebServiceIngreso : System.Web.Services.WebService
{

    public WebServiceIngreso()
    {

        //Elimine la marca de comentario de la línea siguiente si utiliza los componentes diseñados 
        //InitializeComponent(); 
    }

    [WebMethod]
    public ArrayList retornaTodosLosEgresos()
    {
        CapaNegocio.NegocioIngreso auxNegocio = new CapaNegocio.NegocioIngreso();

        return auxNegocio.entregaIngresoArray();
    }

    [WebMethod]
    public Boolean guardarIngreso(CapaDTO.Ingreso ingreso)
    {
        CapaNegocio.NegocioIngreso auxNegocio = new CapaNegocio.NegocioIngreso();
        Boolean resultado = auxNegocio.ingresaIngreso(ingreso);
        return resultado;
    }

    [WebMethod]
    public CapaDTO.Ingreso posicionIngreso(int posicion)
    {
        CapaNegocio.NegocioIngreso auxNegocio = new CapaNegocio.NegocioIngreso();
        return auxNegocio.retornaElementoPorFila(posicion);
    }


    [WebMethod]
    public CapaDTO.Ingreso buscaIngreso(int idIngreso)
    {
        CapaNegocio.NegocioIngreso auxNegocio = new CapaNegocio.NegocioIngreso();
        return auxNegocio.buscaIngreso(idIngreso);
    }

    [WebMethod]
    public Boolean actualizaIngreso(CapaDTO.Ingreso Ingreso)
    {
        CapaNegocio.NegocioIngreso auxNegocio = new CapaNegocio.NegocioIngreso();
        Boolean resultado = auxNegocio.actualizaIngreso(Ingreso);
        return resultado;
    }

    [WebMethod]
    public Boolean eliminaIngreso(int idIngreso)
    {
        CapaNegocio.NegocioIngreso auxNegocio = new CapaNegocio.NegocioIngreso();
        Boolean resultado = auxNegocio.eliminaIngreso(idIngreso);
        return resultado;
    }

    [WebMethod]
    public Boolean esActivo()
    {
        return true;
    }

}
