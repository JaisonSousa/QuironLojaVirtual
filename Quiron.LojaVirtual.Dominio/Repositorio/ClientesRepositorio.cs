using Quiron.LojaVirtual.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiron.LojaVirtual.Dominio.Repositorio
{
    public class ClientesRepositorio
    {
        private readonly EfDbContext _context = new EfDbContext();

        public Cliente ObterCliente(string id)
        {
            return _context.Users.Find(id);
        }
    }
}
