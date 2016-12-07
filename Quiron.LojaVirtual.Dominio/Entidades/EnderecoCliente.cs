

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Quiron.LojaVirtual.Dominio.Entidades
{
    public class EnderecoCliente
    {
        [Key, ForeignKey("Id")]
        public virtual Cliente Cliente { get; set; }

        public string Id { get; set; }
        public string Pais { get; set; }
        public string Estado { get; set; }
        public string Cidade { get; set; }
        public string CEP { get; set; }
        public string Bairro { get; set; }
        public string Rua { get; set; }
        public string Numero { get; set; }
        public string Complemento { get; set; }
    }
} 
