using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;
using CapaNegocio;

/// <summary>
/// Descripción breve de WebServiceUbicacionProductor
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
// [System.Web.Script.Services.ScriptService]
public class WebServiceUbicacionProductor : System.Web.Services.WebService
{

    public WebServiceUbicacionProductor()
    {

        //Elimine la marca de comentario de la línea siguiente si utiliza los componentes diseñados 
        //InitializeComponent(); 
    }

    [WebMethod]
    public ArrayList retornaTodasUbicacionProductores()
    {
        CapaNegocio.NegocioUbicacionProductor auxNegocio = new CapaNegocio.NegocioUbicacionProductor();

        return auxNegocio.entregaUbicacionProductorArray();
    }

    [WebMethod]
    public Boolean guardarUbicacionProductor(CapaDTO.UbicacionProductor ubicacionPro)
    {
        CapaNegocio.NegocioUbicacionProductor auxNegocio = new CapaNegocio.NegocioUbicacionProductor();
        Boolean resultado = auxNegocio.ingresaUbicacionPro(ubicacionPro);
        return resultado;
    }

    [WebMethod]
    public CapaDTO.UbicacionProductor posicionStock(int posicion)
    {
        CapaNegocio.NegocioUbicacionProductor auxNegocio = new CapaNegocio.NegocioUbicacionProductor();
        return auxNegocio.retornaElementoPorFila(posicion);
    }


    [WebMethod]
    public CapaDTO.UbicacionProductor buscaUbicacionProductor(int idUbicacionPro)
    {
        CapaNegocio.NegocioUbicacionProductor auxNegocio = new CapaNegocio.NegocioUbicacionProductor();
        return auxNegocio.buscaUbicacionProductor(idUbicacionPro);
    }

    [WebMethod]
    public Boolean actualizaUbicacionProductor(CapaDTO.UbicacionProductor ubicacionPro)
    {
        CapaNegocio.NegocioUbicacionProductor auxNegocio = new CapaNegocio.NegocioUbicacionProductor();
        Boolean resultado = auxNegocio.actualizaUbicacionPro(ubicacionPro);
        return resultado;
    }

    [WebMethod]
    public Boolean eliminaUbicacionProductor(int idUbicacionPro)
    {
        CapaNegocio.NegocioUbicacionProductor auxNegocio = new CapaNegocio.NegocioUbicacionProductor();
        Boolean resultado = auxNegocio.eliminaUbicacionProductor(idUbicacionPro);
        return resultado;
    }

    [WebMethod]
    public Boolean esActivo()
    {
        return true;
    }

}
