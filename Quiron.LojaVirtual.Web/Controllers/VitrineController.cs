using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Quiron.LojaVirtual.Dominio.Repositorio;
using Quiron.LojaVirtual.Web.Models;
using Quiron.LojaVirtual.Dominio.Entidades;

namespace Quiron.LojaVirtual.Web.Controllers
{
    public class VitrineController : Controller
    {
        private ProdutosRepositorio _repositorio;

        //paginação
        public int ProdutoPorPagina = 3;
        //
        // GET: /Vitrine/
        public ActionResult ListaProdutos(string categoria, int pagina = 1 )
        {

            _repositorio = new ProdutosRepositorio();

            ProdutosViewModel model = new ProdutosViewModel
            {
                Produtos = _repositorio.Produtos.Where(p => categoria == null || p.Categoria == categoria)
                .OrderBy(p => p.Descricao)
                    .Skip((pagina - 1)*ProdutoPorPagina)
                    .Take(ProdutoPorPagina),

                Paginacao = new Paginacao
                {
                    PaginaAtual = pagina,
                    ItensPorPargina = ProdutoPorPagina,
                    ItensTotal = _repositorio.Produtos.Count()
                },

                CategoriaAtual = categoria


            };

           
                

            return View(model);
        }

        [Route("Produto/ObterImagem/{produtoId}")]
        public FileContentResult ObterImagem(int produtoId)
        {
            _repositorio = new ProdutosRepositorio();
            Produto prod = _repositorio.Produtos.FirstOrDefault(p => p.ProdutoId == produtoId);

            if (prod != null)
            {
                return File(prod.Imagem, prod.ImageMimeType);

            }

            return null;



        }
	}
}