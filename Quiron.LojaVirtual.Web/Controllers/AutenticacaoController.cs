using Quiron.LojaVirtual.Dominio.Entidades;
using Quiron.LojaVirtual.Dominio.Repositorio;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Quiron.LojaVirtual.Web.Controllers
{
    public class AutenticacaoController : Controller
    {
        //
        // GET: /Autenticacao/
        public ActionResult Index()
        {
            return View();
        }

        public void Login()
        {
            Administrador administrador = new Administrador();
            administrador.Login = "aluno";

            AdiministradoresRepositorio repositorio = new AdiministradoresRepositorio();
            var adm = repositorio.ObterAdiministrador(administrador);

        }
	}
}