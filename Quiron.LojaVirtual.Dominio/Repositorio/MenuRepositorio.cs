using Quiron.LojaVirtual.Dominio.Entidades;
using Quiron.LojaVirtual.Dominio.Entidades.Vitrine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiron.LojaVirtual.Dominio.Repositorio
{
    public class MenuRepositorio
    {
        private readonly EfDbContext _context = new EfDbContext();

      
        public IEnumerable<Categoria> ObterCategorias()
        {
            return _context.Categorias.OrderBy(c => c.CategoriaDescricao);
        }

        //Aula 58
        public IEnumerable<MarcaVitrine> ObterMarcas()
        {
            return _context.MarcaVitrine.OrderBy(c => c.MarcaDescricao);
        }

        //Aula 59
        public IEnumerable<ClubesNacionais> ObterClubesNacionais()
        {
            return _context.ClubesNacionais.OrderBy(c => c.LinhaDescricao);
        }

        //Aula 59
        public IEnumerable<ClubesInternacionais> ObterClubesInternacionais()
        {
            return _context.ClubesInternacionais.OrderBy(c => c.LinhaDescricao);
        }

        //Aula 60
        public IEnumerable<Selecoes> ObterSelecoes()
        {
            return _context.Selecoes.OrderBy(c => c.LinhaDescricao);
        }

    }
}
