using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;
using CapaNegocio;

/// <summary>
/// Descripción breve de WebServiceComuna
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
// [System.Web.Script.Services.ScriptService]
public class WebServiceComuna : System.Web.Services.WebService
{

    public WebServiceComuna()
    {

        //Elimine la marca de comentario de la línea siguiente si utiliza los componentes diseñados 
        //InitializeComponent(); 
    }

    [WebMethod]
    public ArrayList retornaTodasLasComunas()
    {
        CapaNegocio.NegocioComuna auxNegocio = new CapaNegocio.NegocioComuna();

        return auxNegocio.entregaComunaArray();
    }

    [WebMethod]
    public Boolean guardarComuna(CapaDTO.Comuna comuna)
    {
        CapaNegocio.NegocioComuna auxNegocio = new CapaNegocio.NegocioComuna();
        Boolean resultado = auxNegocio.ingresaComuna(comuna);
        return resultado;
    }

    [WebMethod]
    public CapaDTO.Comuna posicionComuna(int posicion)
    {
        CapaNegocio.NegocioComuna auxNegocio = new CapaNegocio.NegocioComuna();
        return auxNegocio.retornaElementoPorFila(posicion);
    }


    [WebMethod]
    public CapaDTO.Comuna buscaComuna(int idComuna)
    {
        CapaNegocio.NegocioComuna auxNegocio = new CapaNegocio.NegocioComuna();
        return auxNegocio.buscaComuna(idComuna);
    }

    [WebMethod]
    public Boolean actualizaComuna(CapaDTO.Comuna comuna)
    {
        CapaNegocio.NegocioComuna auxNegocio = new CapaNegocio.NegocioComuna();
        Boolean resultado = auxNegocio.actualizaComuna(comuna);
        return resultado;
    }

    [WebMethod]
    public Boolean eliminaComuna(int idComuna)
    {
        CapaNegocio.NegocioComuna auxNegocio = new CapaNegocio.NegocioComuna();
        Boolean resultado = auxNegocio.eliminaComuna(idComuna);
        return resultado;
    }

    [WebMethod]
    public Boolean esActivo()
    {
        return true;
    }

}
