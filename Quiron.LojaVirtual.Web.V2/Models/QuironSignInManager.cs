using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Microsoft.Owin.Security;
using Quiron.LojaVirtual.Dominio.Entidades;


namespace Quiron.LojaVirtual.Web.V2.Models
{
    public class QuironSignInManager : SignInManager<Cliente, string>
    {
        public QuironSignInManager(QuironUserManager userManager, IAuthenticationManager authenticationManager) : base(userManager, authenticationManager) { }

        public static QuironSignInManager Create(IdentityFactoryOptions<QuironSignInManager> option, IOwinContext context)
        {
            var manager = context.GetUserManager<QuironUserManager>();
            var sign = new QuironSignInManager(manager, context.Authentication);
            return sign;
        }

    }
}