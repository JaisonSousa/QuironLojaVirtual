
using Microsoft.AspNet.Identity.EntityFramework;
using System.ComponentModel.DataAnnotations;


namespace Quiron.LojaVirtual.Dominio.Entidades
{
    public class Cliente : IdentityUser
    {
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
