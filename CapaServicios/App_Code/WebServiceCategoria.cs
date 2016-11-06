using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;
using CapaNegocio;

/// <summary>
/// Descripción breve de WebServiceCategoria
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
// [System.Web.Script.Services.ScriptService]
public class WebServiceCategoria : System.Web.Services.WebService
{

    public WebServiceCategoria()
    {

        //Elimine la marca de comentario de la línea siguiente si utiliza los componentes diseñados 
        //InitializeComponent(); 
    }

    [WebMethod]
    public ArrayList retornaTodasLasCategoria()
    {
        CapaNegocio.NegocioCategoria auxNegocio = new CapaNegocio.NegocioCategoria();

        return auxNegocio.entregaCategoriaArray();
    }

    [WebMethod]
    public Boolean guardarCategoria(CapaDTO.Categoria categoria)
    {
        CapaNegocio.NegocioCategoria auxNegocio = new CapaNegocio.NegocioCategoria();
        Boolean resultado = auxNegocio.ingresaCategoria(categoria);
        return resultado;
    }

    [WebMethod]
    public CapaDTO.Categoria posicionCategoria(int posicion)
    {
        CapaNegocio.NegocioCategoria auxNegocio = new CapaNegocio.NegocioCategoria();
        return auxNegocio.retornaElementoPorFila(posicion);
    }


    [WebMethod]
    public CapaDTO.Categoria buscaCategoria(int idCategoria)
    {
        CapaNegocio.NegocioCategoria auxNegocio = new CapaNegocio.NegocioCategoria();
        return auxNegocio.buscaCategoria(idCategoria);
    }

    [WebMethod]
    public Boolean actualizaCategoria(CapaDTO.Categoria categoria)
    {
        CapaNegocio.NegocioCategoria auxNegocio = new CapaNegocio.NegocioCategoria();
        Boolean resultado = auxNegocio.actualizaCategoria(categoria);
        return resultado;
    }

    [WebMethod]
    public Boolean eliminaCategoria(int idCategoria)
    {
        CapaNegocio.NegocioCategoria auxNegocio = new CapaNegocio.NegocioCategoria();
        Boolean resultado = auxNegocio.eliminaCategoria(idCategoria);
        return resultado;
    }

    [WebMethod]
    public Boolean esActivo()
    {
        return true;
    }

}
