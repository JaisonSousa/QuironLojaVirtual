using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Quiron.LojaVirtual.Dominio.Repositorio;

namespace Quiron.LojaVirtual.Web.Controllers
{
    public class VitrineController : Controller
    {
        private ProdutosRepositorio _repositorio;

        //paginação
        public int ProdutoPorPagina = 3;
        //
        // GET: /Vitrine/
        public ActionResult ListaProdutos(int pagina = 1 )
        {
            _repositorio = new ProdutosRepositorio();
            var produtos = _repositorio.Produtos.OrderBy(p => p.Descricao)
                .Skip((pagina - 1) * ProdutoPorPagina)
                .Take(ProdutoPorPagina);

            return View(produtos);
        }
	}
}