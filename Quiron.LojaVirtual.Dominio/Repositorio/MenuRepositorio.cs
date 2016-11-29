using Quiron.LojaVirtual.Dominio.Dto;
using Quiron.LojaVirtual.Dominio.Entidades;
using Quiron.LojaVirtual.Dominio.Entidades.Vitrine;
using System.Collections.Generic;
using System.Linq;
using FastMapper;
using System.Runtime.Remoting.Messaging;

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

        //Aula 70
        //Obtenho as categorias pré definidas através da query na tabela categoria
        public IEnumerable<Categoria> ObterTenisCategoria()
        {
            var categorias = new[] { "0005", "0082", "0112", "0010", "0006", "0063" };
            return _context.Categorias.Where(c => categorias.Contains(c.CategoriaCodigo)).OrderBy(c => c.CategoriaDescricao);


        }

        //Subgrupo tenis
        public SubGrupo SubGrupoTenis()
        {
            return _context.SubGrupo.FirstOrDefault(s => s.SubGrupoCodigo == "0084");

        }

        //Aula 71
        #region [Menu Lateral Casual]
        

        /// <summary>
        /// Retorno a modalidade Casual
        /// </summary>
        /// <returns></returns>
        public Modalidade ModalidadeCasual()
        {
            //Boa pratica
            const string CODIGOMODALIDADE = "0001";
            return _context.Modalidade.FirstOrDefault(m => m.ModalidadeCodigo == CODIGOMODALIDADE);
        }

        //Quando falamos de coleções temos 3 coleçoes principais
        //IEnumerable -> Lista somente leitus
        //IQueryable -> Lista leitura e pesquisa
        //IList -> Lista leitura, pesquisa, gravacao = DESDE O .NET 2.0
        //IColletion -> Alternativa mais RECENTE, MODERNA, LEVE AO ILIST = .NET 4.0

        //SubGrupoDto
        public IEnumerable<SubGrupoDto> ObterCasualSubgrupo()
        {
            var subGrupos = new[] { "0001", "0102", "0103", "0738", "0084", "0921" };

            var query = from s in _context.SubGrupo.Where(s => subGrupos.Contains(s.SubGrupoCodigo))
                        .Select(s => new {s.SubGrupoCodigo, s.SubGrupoDescricao})
                        .Distinct()
                        .OrderBy(s => s.SubGrupoDescricao)
                        
                        select new
                        {
                            s.SubGrupoCodigo,
                            s.SubGrupoDescricao
                            
                            
                        };

            return query.Project().To<SubGrupoDto>().ToList(); 



        }
        #endregion [Menu Lateral Casual]

        #region [Suplementos]
        public Categoria Suplemento()
        {
            var categoriaSumplementos = "0008";
            return _context.Categorias
                .FirstOrDefault(s => s.CategoriaCodigo == categoriaSumplementos );
        }

        public IEnumerable<SubGrupo> ObterSuplementos()
        {
            var subGrupos = new[]
            {
                "0162","0381","0557","0564","0565","1082","1083","1084","1085", "0977"
            };
            return _context.SubGrupo
                .Where(s => subGrupos.Contains(s.SubGrupoCodigo) && s.GrupoCodigo == "0012")
                .OrderBy(s => s.SubGrupoDescricao);

        }
       
        
        #endregion


    }
}
