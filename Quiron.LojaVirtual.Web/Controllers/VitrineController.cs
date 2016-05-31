using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Quiron.LojaVirtual.Dominio.Repositorio;
using Quiron.LojaVirtual.Web.Models;

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

            ProdutosViewModel model = new ProdutosViewModel
            {
                Produtos = _repositorio.Produtos.OrderBy(p => p.Descricao)
                    .Skip((pagina - 1)*ProdutoPorPagina)
                    .Take(ProdutoPorPagina),

                Paginacao = new Paginacao
                {
                    PaginaAtual = pagina,
                    ItensPorPargina = ProdutoPorPagina,
                    ItensTotal = _repositorio.Produtos.Count()
                }


            };

           
                

            return View(model);
        }
	}
}