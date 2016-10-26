using Quiron.LojaVirtual.Web.V2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Quiron.LojaVirtual.Web.V2.Controllers
{
    public class NavController : Controller
    {
        //
        // GET: /Nav/
        public ActionResult Index()
        {
            return View();
        }

        [Route("nav/{id}/{marca}")]
        public ActionResult ObterProdutosPorMarcas(string id)
        {
            var _model = new ProdutosViewModel { Produtos = null };

            return View("Index", _model);
                 
        }
	}
}