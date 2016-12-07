using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Quiron.LojaVirtual.Dominio.Entidades;
using Quiron.LojaVirtual.Dominio.Entidades.Vitrine;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Quiron.LojaVirtual.Dominio.Repositorio
{
    public class EfDbContext : IdentityDbContext<Cliente>
    {
        public EfDbContext() : base("EFDbContext") { }

        public DbSet<Produto> Produtos { get; set; }

        //Aula 39
        public DbSet<Administrador> Administradores { get; set; }

        //Aula 55
        public DbSet<Categoria> Categorias { get; set; }

        //Aula 58
        public DbSet<MarcaVitrine> MarcaVitrine { get; set; }

        //Aula 59
        public DbSet<ClubesNacionais> ClubesNacionais { get; set; }

        //Aula 59
        public DbSet<ClubesInternacionais> ClubesInternacionais { get; set; }

        //Aula 60
        public DbSet<Selecoes> Selecoes { get; set; }

        //Aula 63
        public DbSet<FaixaEtaria> FaixaEtaria { get; set; }

        //Aula 63
        public DbSet<Genero> Generos { get; set; }

        //Aula 63
        public DbSet<Grupo> Grupos { get; set; }

        //Aula 63
        public DbSet<Marca> Marcas { get; set; }

        //Aula 63
        public DbSet<Modalidade> Modalidade { get; set; }

        //Aula 64
        public DbSet<ProdutoVitrine> ProdutoVitrine { get; set; }

        //Aula 70
        public DbSet<SubGrupo> SubGrupo { get; set; }

        //Aula 75
        public DbSet<QuironProduto> QuironProdutos { get; set; }

        //Aula 75
        public DbSet<Cor> Cores { get; set; }

        //Aula 75
        public DbSet<Tamanho> Tamanhos { get; set; }

        //Aula 75
        public DbSet<Estoque> Estoque {get;set;}

        public DbSet<ProdutoModelo> ProdutoModelo { get; set; }



        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Entity<Produto>().ToTable("Produtos");
            //Aula 39
            modelBuilder.Entity<Administrador>().ToTable("Administradores");
            base.OnModelCreating(modelBuilder);
        }
    }
}
