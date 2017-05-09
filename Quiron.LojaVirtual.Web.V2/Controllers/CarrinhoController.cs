using Quiron.LojaVirtual.Dominio.Entidades;
using Quiron.LojaVirtual.Dominio.Repositorio;
using Quiron.LojaVirtual.Web.V2.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web.Mvc;

using Microsoft.AspNet.Identity;
using System.Xml.Serialization;
using System.Xml;
using System.IO;
using System.Net.Http;
using Quiron.LojaVirtual.Dominio.Entidades.Pagamento;

namespace Quiron.LojaVirtual.Web.V2.Controllers
{
    public class CarrinhoController : Controller
    {
        private QuironProdutosRepositorio _repositorio = new QuironProdutosRepositorio();
        private ClientesRepositorio _clientesRepositorio = new ClientesRepositorio();
        private PedidosRepositorio _pedidosRepositorio = new PedidosRepositorio();


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

            return RedirectToAction("Index", "Nav");
        }


        //Aula 81 sem sessão
        [Authorize]
        public ViewResult FecharPedido()
        {
            Pedido novoPedido = new Pedido();
            novoPedido.ClienteId = User.Identity.GetUserId();
            novoPedido.cliente = _clientesRepositorio.ObterCliente(User.Identity.GetUserId());
            return View(novoPedido);

        }

        //Aula 48
        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult FecharPedido(Carrinho carrinho,Pedido pedido)
        {
            
         
            if (!carrinho.ItensCarrinhos.Any())
            {
                ModelState.AddModelError("", "Não foi possivel concluir o pedido, seu carrinho está vazio!");

            }

            if (ModelState.IsValid)
            {
                pedido.ProdutosPedido = new List<ProdutoPedido>();
                foreach (var item in carrinho.ItensCarrinhos)
                {
                    pedido.ProdutosPedido.Add(new ProdutoPedido()
                    {
                        Quantidade = item.Quantidade,
                        ProdutoId = item.Produto.ProdutoId
                    });
                }
                pedido.Pago = false;
                pedido = _pedidosRepositorio.SalvarPedido(pedido);
                pedido.cliente = _clientesRepositorio.ObterCliente(pedido.ClienteId);
                foreach (var produto in pedido.ProdutosPedido)
                {
                    produto.Produto = _repositorio.Produtos
                        .Where(p => p.ProdutoId == produto.ProdutoId)
                        .FirstOrDefault();
                }

                using (var client = new HttpClient())
                {
                    client.BaseAddress = new System.Uri("https://ws.sandbox.pagseguro.uol.com.br");
                    client.DefaultRequestHeaders.Clear();

                    var pedidoPagSeguro = new PagamentoPagSeguro(
                        pedido,
                        "http://localhost:42028/Carrinho/PedidoConcluido?pedidoId=" + pedido.Id,
                        Request.UserHostAddress);
                    XmlSerializer serializer = new XmlSerializer(typeof(PagamentoPagSeguro));

                    StreamContent content;
                    using (var stream = new MemoryStream())
                    {
                        using (XmlWriter textWriter = XmlWriter.Create(stream))
                        {
                            serializer.Serialize(textWriter, pedidoPagSeguro);
                        }

                        stream.Seek(0, SeekOrigin.Begin);
                        content = new StreamContent(stream);
                        var test = await content.ReadAsByteArrayAsync();
                            //await content.ReadAsStringAsync();

                        content.Headers.Add("Content-Type", "application/xml");

                        var response = await client.PostAsync(
                            "v2/checkouts-qrcode/?email=hmgasparotto@hotmail.com&token=8BF8F5C11A214599912ED733EC4C885D",
                            content);
                        if (response.IsSuccessStatusCode)
                        {
                            string resultContent = await response.Content.ReadAsStringAsync();
                            XmlSerializer returnSerializer = new XmlSerializer(typeof(ReceivedPagSeguro));
                            using (TextReader reader = new StringReader(resultContent))
                            {
                                var retorno = (ReceivedPagSeguro)returnSerializer.Deserialize(reader);
                                return Redirect("https://sandbox.pagseguro.uol.com.br/v2/checkout/payment.html?code=" + retorno.Code);
                            }
                        }
                    }
                }


                return RedirectToAction("PedidoConcluido", new { pedidoId = pedido.Id });
            }
            else
            {
                return View(pedido);

            }
          }


        



        public ViewResult PedidoConcluido(Carrinho carrinho, int pedidoId)
        {
            EmailConfiguracoes email = new EmailConfiguracoes
            {
                EscreverArquivo = bool.Parse(ConfigurationManager.AppSettings["Email.EscreverArquivo"] ?? "false")
            };
            EmailPedido emailPedido = new EmailPedido(email);

            var pedido = _pedidosRepositorio.ObterPedido(pedidoId);

            emailPedido.ProcessarPedido(carrinho, pedido);
            carrinho.LimpaCarrinho();

            return View(pedido);
        }

	}
}