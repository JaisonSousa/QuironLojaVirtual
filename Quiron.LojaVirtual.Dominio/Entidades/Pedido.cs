using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiron.LojaVirtual.Dominio.Entidades
{
    public class Pedido
    {
        //Aula 82
        [Key]
        public int Id { get; set; }

        public string ClienteId { get; set; }

        public virtual ICollection<ProdutoPedido> ProdutosPedido { get; set; }

        [ForeignKey("ClienteId")]
        public virtual Cliente cliente { get; set; }
        //--Fim aqui ---------------------------

        //[Required(ErrorMessage = "Informe seu nome")]
        //public string NomeCliente { get; set; }


        //[Display(Name = "Cep:")]
        //public string Cep { get; set; }

        //[Required(ErrorMessage = "Informe seu endereço")]
        //[Display(Name = "Endereço:")]
        //public string Endereco { get; set; }

        //[Display(Name = "Complemento:")]
        //public string Complemento { get; set; }

        //[Required(ErrorMessage = "Informe sua cidade")]
        //[Display(Name = "Cidade:")]
        //public string Cidade { get; set; }

        //[Required(ErrorMessage = "Informe seu bairro")]
        //[Display(Name = "Bairro:")]
        //public string Bairro { get; set; }

        //[Required(ErrorMessage = "Informe seu estado")]
        //[Display(Name = "Estado:")]
        //public string Estado { get; set; }

        //[Required(ErrorMessage = "Informe seu email")]
        //[EmailAddress(ErrorMessage = "E-mail invalido")]
        //[Display(Name = "Email:")]
        //public string Email { get; set; }

       public bool EmbrulhaPresente { get; set; }

       public bool Pago { get; set; }

       

    }
}
