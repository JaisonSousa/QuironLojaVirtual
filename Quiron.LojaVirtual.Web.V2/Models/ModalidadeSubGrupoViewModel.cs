using Quiron.LojaVirtual.Dominio.Dto;
using Quiron.LojaVirtual.Dominio.Entidades;
using System.Collections.Generic;



namespace Quiron.LojaVirtual.Web.V2.Models
{
    public class ModalidadeSubGrupoViewModel
    {
        public Modalidade Modalidade { get; set; }
        public IEnumerable<SubGrupoDto> SubGrupos { get; set; }

    }
}