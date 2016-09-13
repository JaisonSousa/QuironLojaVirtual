using Quiron.LojaVirtual.Dominio.Entidades;
using Quiron.LojaVirtual.Dominio.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Quiron.LojaVirtual.Web.Controllers
{
    public class AutenticacaoController : Controller
    {

        private AdiministradoresRepositorio _repositorio;

        //Aula 40
        // GET: /Autenticacao/
        public ActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View(new Administrador());
        }

        [HttpPost]
        public ActionResult Login(Administrador administrador, string returnUrl)
        {
            _repositorio = new AdiministradoresRepositorio();

            if (ModelState.IsValid)
            {
                Administrador admin = _repositorio.ObterAdiministrador(administrador);

                if (admin != null)
                {
                    if (!Equals(administrador.Senha, admin.Senha))
                    {
                        ModelState.AddModelError("","Senha não confere!");


                    }
                    else
                    {
                        FormsAuthentication.SetAuthCookie(admin.Login, false);
                        //retorna um booleano tru ou false
                        if (Url.IsLocalUrl(returnUrl)
                           && returnUrl.Length > 1
                           && returnUrl.StartsWith("/")
                           && !returnUrl.StartsWith("//")
                           && !returnUrl.StartsWith("/\\"))

                            return Redirect(returnUrl);
                    }

                }
                else
                {
                    ModelState.AddModelError("", "Administrador não localizado");
                }
            }

            return View(new Administrador());


        }
    }


}