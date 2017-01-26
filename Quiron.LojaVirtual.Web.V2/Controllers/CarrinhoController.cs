using Quiron.LojaVirtual.Dominio.Entidades;
using Quiron.LojaVirtual.Dominio.Repositorio;
using Quiron.LojaVirtual.Web.V2.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web.Mvc;

namespace Quiron.LojaVirtual.Web.V2.Controllers
{
    public class CarrinhoController : Controller
    {
        private QuironProdutosRepositorio _repositorio = new QuironProdutosRepositorio();

        //Aula 81 sem sessão
        public ViewResult Index(Carrinho carrinho,string returnUrl)
        {
            return View(new CarrinhoViewModel
            {
                Carrinho = carrinho,
                ReturnUrl = returnUrl
            });


        }
        //Aula 81
        public PartialViewResult Resumo(Carrinho carrinho)
        {

            return PartialView(carrinho);
        }

        public RedirectToRouteResult Adicionar(Carrinho carrinho, int quantidade,
            string produto, string Cor, string Tamanho, string returnUrl)
        {
            QuironProduto prod = _repositorio.ObterProduto(produto, Cor, Tamanho);

            if (prod != null)
            {
                carrinho.AdicionarItem(prod, quantidade);
                

            }

            return RedirectToAction("Index", "Nav");

        }

        public RedirectToRouteResult Remover(Carrinho carrinho, int produtoId, string returnUrl)
        {
            QuironProduto produto = _repositorio.Produtos
                .FirstOrDefault(p => p.ProdutoId == produtoId);

            if (produto != null)
            {
                carrinho.RemoverItemCarrinho(produto);
            }

            return RedirectToAction("Index", new { returnUrl });
        }


        //Aula 81 sem sessão
        public ViewResult FecharPedido()
        {
            return View(new Pedido());

        }

        //Aula 48
        [HttpPost]
        public ViewResult FecharPedido(Carrinho carrinho,Pedido pedido)
        {
            
            EmailConfiguracoes email = new EmailConfiguracoes
            {
                EscreverArquivo = bool.Parse(ConfigurationManager.AppSettings["Email.EscreverArquivo"] ?? "falso")
            };
            EmailPedido emailPedido = new EmailPedido(email);

            if (!carrinho.ItensCarrinhos.Any())
            {
                ModelState.AddModelError("", "Não foi possivel concluir o pedido, seu carrinho está vazio!");

            }

            if (ModelState.IsValid)
            {
                emailPedido.ProcessarPedido(carrinho, pedido);
                carrinho.LimpaCarrinho();
                return View("PedidoConcluido");
            }
            else
            {
                return View(pedido);

            }


        }

        

        public ViewResult PedidoConcluido()
        {
            return View();
        }

	}
}