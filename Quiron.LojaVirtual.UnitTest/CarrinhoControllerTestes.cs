using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Quiron.LojaVirtual.Dominio.Entidades;
using Quiron.LojaVirtual.Web.Controllers;
using System.Linq;
using System.Web.Mvc;
using Quiron.LojaVirtual.Web.Models;
using Quiron.LojaVirtual.Web.V2.Models;

namespace Quiron.LojaVirtual.UnitTest
{
    [TestClass]
    public class CarrinhoControllerTestes
    {
        [TestMethod]
        public void AdicionarItemAoCarrinho()
        {
            //preparação (Arrange) e o estímulo (Act), das verificações (Asserts)
            Produto produto1 = new Produto
            {
                ProdutoId = 1,
                Nome = "Teste1"

            };

            Produto produto2 = new Produto
            {
                ProdutoId = 2,
                Nome = "Teste2"

            };

            Carrinho carrinho = new Carrinho();

            carrinho.AdicionarItem(produto1, 3);
            carrinho.AdicionarItem(produto2, 4);

            CarrinhoController controller = new CarrinhoController();

            //Act

            controller.Adicionar(carrinho, 2,2, "");

            //Assert
            Assert.AreEqual(carrinho.ItensCarrinhos.Count(), 2);

            Assert.AreEqual(carrinho.ItensCarrinhos.ToArray()[0].Produto.ProdutoId, 1);



        }

        [TestMethod]
        public void Adiciono_Produto_No_Carrinho_Volto_Para_A_Categoria()
        {
            //preparação (Arrange) e o estímulo (Act), das verificações (Asserts)

            //Arrange
            Carrinho carrinho = new Carrinho();

            //A
            CarrinhoController controller = new CarrinhoController();


            //Act
            RedirectToRouteResult result = controller.Adicionar(carrinho, 2,2, "minhaUrl");

            Assert.AreEqual(result.RouteValues["action"], "Index");

            Assert.AreEqual(result.RouteValues["returnUrl"], "minhaUrl");


 
            

        }

        [TestMethod]
        public void Posso_Ver_O_Conteudo_Do_Carrinho()
        {
            //Arrange
            Carrinho carrinho = new Carrinho();

            //A
            CarrinhoController controller = new CarrinhoController();

            //Act
            CarrinhoViewModel resultado = (CarrinhoViewModel)controller.Index(carrinho, "minhaUrl").ViewData.Model;

            Assert.AreSame(resultado.Carrinho,carrinho);
            Assert.AreEqual(resultado.ReturnUrl, "minhaUrl");

        }
    }
}