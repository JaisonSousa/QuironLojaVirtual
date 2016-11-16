﻿using Quiron.LojaVirtual.Dominio.Repositorio;
using Quiron.LojaVirtual.Web.V2.Models;
using System.Web.Mvc;

using Quiron.LojaVirtual.Web.V2.HtmlHelpers;

namespace Quiron.LojaVirtual.Web.V2.Controllers
{
    public class NavController : Controller
    {
        private ProdutoModeloRepositorio _repositorio;
        private ProdutosViewModel _model;
        private MenuRepositorio _menuRepositorio;

        //
        // GET: /Nav/
        public ActionResult Index()
        {
            _repositorio = new ProdutoModeloRepositorio();

            var produtos = _repositorio.ObterProdutosVitrine();
            _model = new ProdutosViewModel { Produtos = produtos };

            

            return View(_model);
        }

        public JsonResult TesteMetedoVetrine()
        {
            ProdutoModeloRepositorio repositorio = new ProdutoModeloRepositorio();
            var produtos = repositorio.ObterProdutosVitrine(categoria:"0003",marca:"0002");

            return Json(produtos, JsonRequestBehavior.AllowGet);

 

        }

        [Route("nav/{id}/{marca}")]
        public ActionResult ObterProdutosPorMarcas(string id, string marca)
        {
            //var _model = new ProdutosViewModel { Produtos = null };

            //return View("Index", _model);

            _repositorio = new ProdutoModeloRepositorio();
            var produtos = _repositorio.ObterProdutosVitrine(marca: id);
            _model = new ProdutosViewModel { Produtos = produtos, Titulo = marca };
            return View("Navegacao", _model);
                 
        }

        [Route("nav/{times}/{id}/{clube}")]
        public ActionResult ObterProdutosPorClubes(string id, string clube)
        {
            //var _model = new ProdutosViewModel { Produtos = null };

            //return View("Index", _model);

            _repositorio = new ProdutoModeloRepositorio();
            var produtos = _repositorio.ObterProdutosVitrine(linha: id);
            _model = new ProdutosViewModel { Produtos = produtos, Titulo = clube };
            return View("Navegacao", _model);

        }

        [Route("nav/genero/{id}/{genero}")]
        public ActionResult ObterProdutosPorGenero(string id, string genero)
        {
            //var _model = new ProdutosViewModel { Produtos = null };

            //return View("Index", _model);

            _repositorio = new ProdutoModeloRepositorio();
            var produtos = _repositorio.ObterProdutosVitrine(genero: id);
            _model = new ProdutosViewModel { Produtos = produtos, Titulo = genero };
            return View("Navegacao", _model);

        }


        #region [Tenis por Categoria]

        /// <summary>
        /// Obtem categoria de tenis exibido no menu
        /// </summary>
        /// <returns></returns>
        [ChildActionOnly]
        [OutputCache(Duration = 3600, VaryByParam = "*")]
        public ActionResult TenisCategoria()
        {
            _menuRepositorio = new MenuRepositorio();
            var categorias = _menuRepositorio.ObterTenisCategoria();
            var subGrupo = _menuRepositorio.SubGrupoTenis();

            SubGrupoCategoriasViewModel model = new SubGrupoCategoriasViewModel
            {
                Categorias = categorias,
                SubGrupo = subGrupo
            };
            return PartialView("_TenisCategoria", model);
        }

        /// <summary>
        /// Retorna uma vitrine com tenis por categoria
        /// </summary>
        /// <param name="subGrupoCodigo"></param>
        /// <param name="categoriaCodigo"></param>
        /// <param name="categoriaDescricao"></param>
        /// <returns></returns>
        [Route("calcados/{subGrupoCodigo}/tenis/{categoriaCodigo}/{categoriaDescricao}")]
        public ActionResult ObterTenisPorCategoria(string subGrupoCodigo, string categoriaCodigo, string categoriaDescricao)
        {
            _repositorio = new ProdutoModeloRepositorio();
            var produtos = _repositorio.ObterProdutosVitrine(categoriaCodigo, subgrupo: subGrupoCodigo);
            _model = new ProdutosViewModel { Produtos = produtos, Titulo = categoriaDescricao.UpperCaseFirst() };
            return View("Navegacao", _model);

        }




        #endregion
        //Aula 69
        //[Route("nav/{id}/{marca}")]
        //public ActionResult ObterChuteiraSociete(string id, string genero)
        //{
        //    //var _model = new ProdutosViewModel { Produtos = null };

        //    //return View("Index", _model);

        //    _repositorio = new ProdutoModeloRepositorio();
        //    var produtos = _repositorio.ObterProdutosVitrine(genero: id, grupo: id, subgrupo: id);
        //    _model = new ProdutosViewModel { Produtos = produtos, Titulo = genero };
        //    return View("Navegacao", _model);

        //}
	}
}