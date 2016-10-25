using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Quiron.LojaVirtual.Dominio.Entidades;
using Quiron.LojaVirtual.Dominio.Entidades.Vitrine;

namespace Quiron.LojaVirtual.Dominio.Repositorio
{
    public class EfDbContext : DbContext
    {
        public DbSet<Produto> Produtos { get; set; }

        //Aula 39
        public DbSet<Administrador> Administradores { get; set; }

        //Aula 55
        public DbSet<Categoria> Categorias { get; set; }

        //Aula 58
        public DbSet<MarcaVitrine> MarcaVitrine { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Entity<Produto>().ToTable("Produtos");
            //Aula 39
            modelBuilder.Entity<Administrador>().ToTable("Administradores");
            //base.OnModelCreating(modelBuilder);
        }
    }
}
