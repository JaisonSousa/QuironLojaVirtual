using Quiron.LojaVirtual.Dominio.Entidades;
using System.Web.Mvc;



namespace Quiron.LojaVirtual.Web.V2.InfraEstrutura
{
    public class CarrinhoModelBinder : IModelBinder
    {
        private const string SessionKey = "Carinho"; 

        //IModelBinder interface define o método BindModel
      
        public object BindModel(ControllerContext controlerContext, ModelBindingContext bindingContext)
        {
            //Obtenho o carrinho da sessão
            Carrinho carrinho = null;

            if (controlerContext.HttpContext.Session != null)
            {
                carrinho = (Carrinho) controlerContext.HttpContext.Session[SessionKey];
                
            }

            //Crio o carrinho se não tenho a sessão
            if (carrinho == null)
            {
                carrinho = new Carrinho();

                if (controlerContext.HttpContext.Session != null)
                {
                    controlerContext.HttpContext.Session[SessionKey] = carrinho;
                    
                }

            }

            //Retorno o carrinho
            return carrinho;

            
        }

       
    }
}