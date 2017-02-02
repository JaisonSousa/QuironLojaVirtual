using Quiron.LojaVirtual.Dominio.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;

namespace Quiron.LojaVirtual.Web.V2.Controllers
{
    public class PedidosController : Controller
    {
        private PedidosRepositorio _repositorio = new PedidosRepositorio();
        //
        // GET: /Pedidos/
        public ActionResult Index()
        {

            string id = User.Identity.GetUserId();
            var pedidos = _repositorio.ObterPedidos(id);

            return View(pedidos);
        }

        public ActionResult Details(int id)
        {
            var pedido = _repositorio.ObterPedido(id);
            return View(pedido);
        }
	}
}