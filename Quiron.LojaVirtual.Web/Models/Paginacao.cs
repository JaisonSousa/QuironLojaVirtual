using System;


namespace Quiron.LojaVirtual.Web.Models
{
    public class Paginacao
    {
        //Quantos itens tenho no banco
        public int ItensTotal { get; set; }
        //Quantos itens quero por pagina
        public int ItensPorPargina { get; set; }
        //Qual página esta exibida no momento
        public int PaginaAtual { get; set; }
        //Quantas página tem
        public int TotalPagina
        {
            get { return (int) Math.Ceiling((decimal) ItensTotal/ItensPorPargina); }
        }


    }
}