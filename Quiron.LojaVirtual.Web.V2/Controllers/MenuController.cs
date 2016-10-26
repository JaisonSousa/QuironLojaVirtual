using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Quiron.LojaVirtual.Web.V2.HtmlHelpers;
using Quiron.LojaVirtual.Dominio.Repositorio;
using System.Web.UI;

namespace Quiron.LojaVirtual.Web.V2.Controllers
{
    public class MenuController : Controller
    {
        private MenuRepositorio _repositorio;

        [OutputCache(Duration = 3600, Location = OutputCacheLocation.Server, VaryByParam = "none")]
        public JsonResult ObterEsportes()
        {
            _repositorio = new MenuRepositorio();
            var cat = _repositorio.ObterCategorias();

            var categoria = from c in cat
                            select new
                            {
                                c.CategoriaDescricao,
                                CategoriaDescricaoSeo = c.CategoriaDescricao.ToSeoUrl(),
                                c.CategoriaCodigo
                            };

            return Json(categoria, JsonRequestBehavior.AllowGet);
        }

        [OutputCache(Duration = 3600, Location = OutputCacheLocation.Server, VaryByParam = "none")]
        public JsonResult ObterMarcas()
        {
            _repositorio = new MenuRepositorio();
            var listaMarcas = _repositorio.ObterMarcas();

            var marcas = from m in listaMarcas
                         select new
                         {
                             m.MarcaDescricao,
                             MarcaDescricaoSeo = m.MarcaDescricao.ToSeoUrl(),
                             m.MarcaCodigo
                         };
            return Json(marcas, JsonRequestBehavior.AllowGet);


        }

        [OutputCache(Duration = 3600, Location = OutputCacheLocation.Server, VaryByParam = "none")]
        public JsonResult ObterClubesNacionais()
        {
            _repositorio = new MenuRepositorio();
            var clubesRepositorio = _repositorio.ObterClubesNacionais();

            var clubes = from c in clubesRepositorio
                         select new
                         {
                             ClubeCodigo = c.LinhaCodigo,
                             ClubeSeo = c.LinhaDescricao.ToSeoUrl(),
                             Clube = c.LinhaDescricao

                         };
            return Json(clubes, JsonRequestBehavior.AllowGet);
        }

        [OutputCache(Duration = 3600, Location = OutputCacheLocation.Server, VaryByParam = "none")]
        public JsonResult ObterClubesInternacionais()
        {
            _repositorio = new MenuRepositorio();
            var clubesRepositorio = _repositorio.ObterClubesInternacionais();

            var clubes = from c in clubesRepositorio
                         select new
                         {
                             ClubeCodigo = c.LinhaCodigo,
                             ClubeSeo = c.LinhaDescricao.ToSeoUrl(),
                             Clube = c.LinhaDescricao

                         };
            return Json(clubes, JsonRequestBehavior.AllowGet);
        }


        //Aula 60
        [OutputCache(Duration = 3600, Location = OutputCacheLocation.Server, VaryByParam = "none")]
        public JsonResult ObterSelecoes()
        {
            _repositorio = new MenuRepositorio();
            var selecoesRepositorio = _repositorio.ObterSelecoes();

            var selecoes = from s in selecoesRepositorio
                         select new
                         {
                             SelecaoCodigo = s.LinhaCodigo,
                             SelecaoSeo = s.LinhaDescricao.ToSeoUrl(),
                             Selecao = s.LinhaDescricao

                         };
            return Json(selecoes, JsonRequestBehavior.AllowGet);
        }

	}

    
}