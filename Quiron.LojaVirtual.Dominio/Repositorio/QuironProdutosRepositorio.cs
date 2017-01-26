using Quiron.LojaVirtual.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiron.LojaVirtual.Dominio.Repositorio
{
    public class QuironProdutosRepositorio
    {
        private readonly EfDbContext _context = new EfDbContext();

        //Retorna todos os produtos
        public IEnumerable<QuironProduto> Produtos
        {
            get { return _context.QuironProdutos; }
        }

        public QuironProduto ObterProduto(string codigo, string corCodigo, string tamanhoCodigo)
        {
            return _context.QuironProdutos.Single(p => p.ProdutoModeloCodigo == codigo
                    && p.CorCodigo == corCodigo && p.TamanhoCodigo == tamanhoCodigo);
        }


        //Salvar Produto - Alterar Produto
        public void Salvar(QuironProduto produto)
        {
            if (produto.ProdutoId == 0)
            {
                //Salvado
                _context.QuironProdutos.Add(produto);
            }
            else
            {
                //Alteração
                _context.Entry(produto).State = System.Data.Entity.EntityState.Modified;
            }

            _context.SaveChanges();
        }

        //Excluir

        public QuironProduto Excluir(int produtoId)
        {

            QuironProduto prod = _context.QuironProdutos.Find(produtoId);

            if (prod != null)
            {
                _context.QuironProdutos.Remove(prod);
                _context.SaveChanges();
            }

            return prod;
        }



    }
}
