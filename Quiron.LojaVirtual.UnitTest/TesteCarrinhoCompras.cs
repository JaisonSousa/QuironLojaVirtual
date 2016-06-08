using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Quiron.LojaVirtual.Dominio.Entidades;

namespace Quiron.LojaVirtual.UnitTest
{
    [TestClass]
    public class TesteCarrinhoCompras
    {
        //Teste de adicionar itens ao carrinho
        [TestMethod]
        public void AdicionarItensCarrinho()
        {
            Produto produto1 = new Produto
            {
                ProdutoId = 1,
                Nome = "Teste 1",
            };

            Produto produto2 = new Produto
            {
                ProdutoId = 2,
                Nome = " Teste 2"
            };

            //Arrage
            Carrinho carrinho = new Carrinho();

            carrinho.AdicionarItem(produto1,2);
            carrinho.AdicionarItem(produto2,3);

            //Act
            ItemCarrinho[] itens = carrinho.ItensCarrinhos.ToArray();

            //Assert
            Assert.AreEqual(itens.Length, 2);

            Assert.AreEqual(itens[0].Produto, produto1);

            Assert.AreEqual(itens[1].Produto, produto2);



        }

        [TestMethod]
        public void AdicionarProdutoExistenteParaCarrinho()
        {
            Produto produto1 = new Produto
            {
                ProdutoId = 1,
                Nome = "Teste 1",
            };

            Produto produto2 = new Produto
            {
                ProdutoId = 2,
                Nome = " Teste 2"
            };

            //Produto produto3 = new Produto
            //{
            //    ProdutoId = 3,
            //    Nome = " Teste 3"
            //};

            //Arrage
            Carrinho carrinho = new Carrinho();

            carrinho.AdicionarItem(produto1, 1);
            carrinho.AdicionarItem(produto2, 1);
            carrinho.AdicionarItem(produto1, 10);

            //Act
            ItemCarrinho[] resultado = carrinho.ItensCarrinhos.OrderBy(c => c.Produto.ProdutoId).ToArray();

            Assert.AreEqual(resultado.Length, 2);

            Assert.AreEqual(resultado[0].Quantidade, 11);


        }

        [TestMethod]
        public void RremoverItensCarrinho()
        {
            Produto produto1 = new Produto
            {
                ProdutoId = 1,
                Nome = "Teste 1",
            };

            Produto produto2 = new Produto
            {
                ProdutoId = 2,
                Nome = " Teste 2"
            };

            Produto produto3 = new Produto
            {
                ProdutoId = 3,
                Nome = " Teste 3"
            };

            //Arrage
            Carrinho carrinho = new Carrinho();

            carrinho.AdicionarItem(produto1, 1);
            carrinho.AdicionarItem(produto2, 3);
            carrinho.AdicionarItem(produto3, 5);
            carrinho.AdicionarItem(produto2, 1);

            carrinho.RemoverItemCarrinho(produto2);

            Assert.AreEqual(carrinho.ItensCarrinhos.Where(c => c.Produto == produto2).Count(), 0);

            Assert.AreEqual(carrinho.ItensCarrinhos.Count(), 2);

            
        }

        [TestMethod]
        public void CalcularValorTotal()
        {
            Produto produto1 = new Produto
            {
                ProdutoId = 1,
                Nome = "Teste 1",
                Preco = 100M,
            };

            Produto produto2 = new Produto
            {
                ProdutoId = 2,
                Nome = " Teste 2",
                  Preco = 50M,
            };

            //Arrage
            Carrinho carrinho = new Carrinho();

            carrinho.AdicionarItem(produto1, 1);
            carrinho.AdicionarItem(produto2, 1);
            carrinho.AdicionarItem(produto1, 3);

            decimal resultado = carrinho.ObterValorTotal();

            Assert.AreEqual(resultado, 450);





        }

        [TestMethod]
        public void LimparItensDoCarrinho()
        {
            Produto produto1 = new Produto
            {
                ProdutoId = 1,
                Nome = "Teste 1",
            };

            Produto produto2 = new Produto
            {
                ProdutoId = 2,
                Nome = " Teste 2"
            };

            //Arrage
            Carrinho carrinho = new Carrinho();

            carrinho.AdicionarItem(produto1, 1);
            carrinho.AdicionarItem(produto2, 3);

            carrinho.LimpaCarrinho();

            Assert.AreEqual(carrinho.ItensCarrinhos.Count(), 0);
            
        }


         

       
    }
}
