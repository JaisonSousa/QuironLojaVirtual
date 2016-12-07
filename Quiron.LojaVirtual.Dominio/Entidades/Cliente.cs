
using Microsoft.AspNet.Identity.EntityFramework;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Quiron.LojaVirtual.Dominio.Entidades
{
    public class Cliente : IdentityUser
    {
        [NotMapped]
        public string Senha { get; set; }

        // Telefone
        [Required]
        public virtual TelefoneCliente Telefone { get; set; }

        // Documento
        [Required]
        public virtual DocumentoCliente Documento { get; set; }

        // Endereço
        [Required]
        public virtual EnderecoCliente Endereco { get; set; }


    }
}
