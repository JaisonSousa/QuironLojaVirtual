using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Quiron.LojaVirtual.Dominio.Entidades;

namespace Quiron.LojaVirtual.Dominio.Repositorio
{
    public class ProdutosRepositorio
    {
        private readonly EfDbContext _context = new EfDbContext();

        public IEnumerable<Produto> Produtos
        {
            get { return _context.Produtos; }
        }

        //Aula 54
        public Produto ObterProduto(int id)
        {
            return _context.Produtos.Single(p => p.ProdutoId == id);

        }

        
        public void Salvar(Produto produto)
        {
            //Salvar Produto
            if (produto.ProdutoId == 0)
            {
                _context.Produtos.Add(produto);
                
            }

            //Alterar Produto
            else
            {
                Produto prod = _context.Produtos.Find(produto.ProdutoId);

                if (prod != null)
                {
                    prod.Nome = produto.Nome;
                    prod.Descricao = produto.Descricao;
                    prod.Preco = produto.Preco;
                    prod.Categoria = produto.Categoria;
                    prod.Imagem = produto.Imagem;
                    prod.ImageMimeType = produto.ImageMimeType;
                    
                }

                
            }

            _context.SaveChanges();

        }

        //Excluir
        public Produto Excluir(int produtoId)
        {
            Produto prod = _context.Produtos.Find(produtoId);

            if (prod != null)
            {
                _context.Produtos.Remove(prod);
                //_context.SaveChanges();
                
            }

            return prod;
        }

    }
}
