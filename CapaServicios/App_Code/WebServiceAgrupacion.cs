using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;
using CapaNegocio;

/// <summary>
/// Descripción breve de WebServiceAgrupacion
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
// [System.Web.Script.Services.ScriptService]
public class WebServiceAgrupacion : System.Web.Services.WebService
{

    public WebServiceAgrupacion()
    {

        //Elimine la marca de comentario de la línea siguiente si utiliza los componentes diseñados 
        //InitializeComponent(); 
    }

    [WebMethod]
    public ArrayList retornaTodasLasAgrupaciones()
    {
        CapaNegocio.NegocioAgru_Agri auxNegocio = new CapaNegocio.NegocioAgru_Agri();

        return auxNegocio.entregaAgrupacionArray();
    }

    [WebMethod]
    public Boolean guardarAgrupacion(CapaDTO.Agrupacion_Agricultores agrupacion)
    {
        CapaNegocio.NegocioAgru_Agri auxNegocio = new CapaNegocio.NegocioAgru_Agri();
        Boolean resultado = auxNegocio.ingresaAgrupacion(agrupacion);
        return resultado;
    }

    [WebMethod]
    public CapaDTO.Agrupacion_Agricultores posicionAgrupacion(int posicion)
    {
        CapaNegocio.NegocioAgru_Agri auxNegocio = new CapaNegocio.NegocioAgru_Agri();
        return auxNegocio.retornaElementoPorFila(posicion);
    }


    [WebMethod]
    public CapaDTO.Agrupacion_Agricultores buscaAgrupacion(int idAgrupacion)
    {
        CapaNegocio.NegocioAgru_Agri auxNegocio = new CapaNegocio.NegocioAgru_Agri();
        return auxNegocio.buscaAgrupacion(idAgrupacion);
    }

    [WebMethod]
    public Boolean actualizaAgrupacion(CapaDTO.Agrupacion_Agricultores agrupacion)
    {
        CapaNegocio.NegocioAgru_Agri auxNegocio = new CapaNegocio.NegocioAgru_Agri();
        Boolean resultado = auxNegocio.actualizaAgrupacion(agrupacion);
        return resultado;
    }

    [WebMethod]
    public Boolean eliminaPais(int idAgrupacion)
    {
        CapaNegocio.NegocioAgru_Agri auxNegocio = new CapaNegocio.NegocioAgru_Agri();
        Boolean resultado = auxNegocio.eliminaAgrupacion(idAgrupacion);
        return resultado;
    }

    [WebMethod]
    public Boolean esActivo()
    {
        return true;
    }

}
