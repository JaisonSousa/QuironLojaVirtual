using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiron.LojaVirtual.Dominio.Entidades
{
    public class Carrinho
    {
        private readonly List<ItemCarrinho> _itemCarrinhos = new List<ItemCarrinho>();

        //Adicionar
        public void AdicionarItem(Produto produto, int quantidade)
        {
            ItemCarrinho item = _itemCarrinhos.FirstOrDefault(p => p.Produto.ProdutoId == produto.ProdutoId);

            if (item == null)
            {
                _itemCarrinhos.Add(new ItemCarrinho
                {
                    Produto = produto,
                    Quantidade = quantidade,
                }
                    );
           
            }

            else
            {
                item.Quantidade += quantidade;
            }

        }

        //Remover
        public void RemoverItemCarrinho(Produto produto)
        {
            _itemCarrinhos.RemoveAll(l => l.Produto.ProdutoId == produto.ProdutoId);
        }

        //Obter o valor total
        public decimal ObterValorTotal()
        {
            return _itemCarrinhos.Sum(e => e.Produto.Preco*e.Quantidade);
        }

        //Limpar carrinho
        public void LimpaCarrinho()
        {
            _itemCarrinhos.Clear();
        }

        //Itens do carrinho
        public IEnumerable<ItemCarrinho> ItensCarrinhos
        {
            get { return _itemCarrinhos; }
        }
    }

    public class ItemCarrinho
    {
        public Produto Produto { get; set; }

        public int Quantidade { get; set; }

        
    }
}
