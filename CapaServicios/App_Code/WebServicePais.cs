using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;
using CapaNegocio;

/// <summary>
/// Descripción breve de WebServicePais
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
// [System.Web.Script.Services.ScriptService]
public class WebServicePais : System.Web.Services.WebService
{

    public WebServicePais()
    {

        //Elimine la marca de comentario de la línea siguiente si utiliza los componentes diseñados 
        //InitializeComponent(); 
    }

    [WebMethod]
    public ArrayList retornaTodosLosPaises()
    {
        CapaNegocio.NegocioPais auxNegocio = new CapaNegocio.NegocioPais();

        return auxNegocio.entregaPaisrray();
    }

    [WebMethod]
    public Boolean guardarPais(CapaDTO.Pais pais)
    {
        CapaNegocio.NegocioPais auxNegocio = new CapaNegocio.NegocioPais();
        Boolean resultado = auxNegocio.ingresaPais(pais);
        return resultado;
    }

    [WebMethod]
    public CapaDTO.Pais posicionPais(int posicion)
    {
        CapaNegocio.NegocioPais auxNegocio = new CapaNegocio.NegocioPais();
        return auxNegocio.retornaElementoPorFila(posicion);
    }


    [WebMethod]
    public CapaDTO.Pais buscaPais(int idPais)
    {
        CapaNegocio.NegocioPais auxNegocio = new CapaNegocio.NegocioPais();
        return auxNegocio.buscaPais(idPais);
    }

    [WebMethod]
    public Boolean actualizaPais(CapaDTO.Pais pais)
    {
        CapaNegocio.NegocioPais auxNegocio = new CapaNegocio.NegocioPais();
        Boolean resultado = auxNegocio.actualizaPais(pais);
        return resultado;
    }

    [WebMethod]
    public Boolean eliminaPais(int idPais)
    {
        CapaNegocio.NegocioPais auxNegocio = new CapaNegocio.NegocioPais();
        Boolean resultado = auxNegocio.eliminaPais(idPais);
        return resultado;
    }

    [WebMethod]
    public Boolean esActivo()
    {
        return true;
    }

}
