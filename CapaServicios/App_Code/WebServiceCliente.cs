using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;
using CapaNegocio;

/// <summary>
/// Descripción breve de WebServiceCliente
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
// [System.Web.Script.Services.ScriptService]
public class WebServiceCliente : System.Web.Services.WebService
{

    public WebServiceCliente()
    {

        //Elimine la marca de comentario de la línea siguiente si utiliza los componentes diseñados 
        //InitializeComponent(); 
    }

    [WebMethod]
    public ArrayList retornaTodosLosClientes()
    {
        CapaNegocio.NegocioClientes auxNegocio = new CapaNegocio.NegocioClientes();

        return auxNegocio.entregaClientesArray();
    }

    [WebMethod]
    public Boolean guardarCliente(CapaDTO.Clientes cliente)
    {
        CapaNegocio.NegocioClientes auxNegocio = new CapaNegocio.NegocioClientes();
        Boolean resultado = auxNegocio.ingresaCliente(cliente);
        return resultado;
    }

    [WebMethod]
    public CapaDTO.Clientes posicionPais(int posicion)
    {
        CapaNegocio.NegocioClientes auxNegocio = new CapaNegocio.NegocioClientes();
        return auxNegocio.retornaElementoPorFila(posicion);
    }


    [WebMethod]
    public CapaDTO.Clientes buscaClientePorId(int idCliente)
    {
        CapaNegocio.NegocioClientes auxNegocio = new CapaNegocio.NegocioClientes();
        return auxNegocio.buscaClientePorId(idCliente);
    }

    [WebMethod]
    public CapaDTO.Clientes buscaClientePorRun(string idCliente)
    {
        CapaNegocio.NegocioClientes auxNegocio = new CapaNegocio.NegocioClientes();
        return auxNegocio.buscaClientePorRun(idCliente);
    }

    [WebMethod]
    public ArrayList buscaClientePorNombres(string nombres)
    {
        CapaNegocio.NegocioClientes auxNegocio = new CapaNegocio.NegocioClientes();
        return auxNegocio.buscaClientePorNombres(nombres);
    }

    [WebMethod]
    public ArrayList buscaClientePorEmail(string email)
    {
        CapaNegocio.NegocioClientes auxNegocio = new CapaNegocio.NegocioClientes();
        return auxNegocio.buscaClientePorEmail(email);
    }

    [WebMethod]
    public ArrayList buscaClientePorComuna(string comuna)
    {
        CapaNegocio.NegocioClientes auxNegocio = new CapaNegocio.NegocioClientes();
        return auxNegocio.buscaClientePorComuna(comuna);
    }

    [WebMethod]
    public Boolean actualizaCliente(CapaDTO.Clientes cliente)
    {
        CapaNegocio.NegocioClientes auxNegocio = new CapaNegocio.NegocioClientes();
        Boolean resultado = auxNegocio.actualizaCliente(cliente);
        return resultado;
    }

    [WebMethod]
    public Boolean eliminaCliente(int idCliente)
    {
        CapaNegocio.NegocioClientes auxNegocio = new CapaNegocio.NegocioClientes();
        Boolean resultado = auxNegocio.eliminaCliente(idCliente);
        return resultado;
    }

    [WebMethod]
    public Boolean esActivo()
    {
        return true;
    }

}
