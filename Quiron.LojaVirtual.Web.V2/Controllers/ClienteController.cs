using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Quiron.LojaVirtual.Dominio.Entidades;
using Quiron.LojaVirtual.Web.V2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Quiron.LojaVirtual.Web.V2.Controllers
{
    [RoutePrefix("cliente")]
    public class ClienteController : Controller
    {

        private QuironUserManager _userManager;
        private QuironSignInManager _signInManager;


        public ClienteController()
        {
        }

        public ClienteController(QuironUserManager userManager, QuironSignInManager signInManager)
        {
            UserManager = userManager;
            SignInManager = signInManager;
        }

        public QuironUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<QuironUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }

        public QuironSignInManager SignInManager
        {
            get
            {
                return _signInManager ?? HttpContext.GetOwinContext().Get<QuironSignInManager>();
            }
            private set
            {
                _signInManager = value;
            }
        }

        //
        // GET: /Cliente/
        public ActionResult Index()
        {
            return View();
        }

        [Route("cadastro")]
        public ActionResult CriaCliente()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("cadastro")]
        public async System.Threading.Tasks.Task<ActionResult> CriaCliente(Cliente model)
        {
            if (ModelState.IsValid)
            {
                model.Documento.Id = model.Id;
                model.Endereco.Id = model.Id;
                model.Telefone.Id = model.Id;
                var result = await UserManager.CreateAsync(model, model.Senha);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Nav");
                }
                ModelState.AddModelError("", result.Errors.FirstOrDefault());
            }

            return View(model);
        }
	}
}