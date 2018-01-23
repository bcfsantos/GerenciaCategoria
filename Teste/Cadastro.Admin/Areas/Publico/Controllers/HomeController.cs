﻿using Cadastro.Admin.Models;
using Cadastro.Infra.CrossCutting;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Cadastro.Admin.Areas.Publico.Controllers
{
    public class HomeController : Controller
    {
        private readonly string ApiCategoria = string.Format("{0}{1}", ConfigurationManager.AppSettings["Api"], "/subcategoria");
        List<SubCategoria> subcategorias;
        public ActionResult Index()
        {

            PreencheDropDrownListCategoria();
            return View();
        }

        public void PreencheDropDrownListCategoria()
        {
            subcategorias = new List<SubCategoria>();
            var listasubCategpria = HelperSOA.CallApi(ApiCategoria, WebRequestMethods.Http.Get, string.Empty, string.Empty);

            if (listasubCategpria.StatusCode == HttpStatusCode.OK)
                subcategorias = JsonConvert.DeserializeObject<List<SubCategoria>>(listasubCategpria.Response);

            ViewBag.ListaCategoria = new SelectList(subcategorias.Select(c => new { subCategoriaSlug = c.Slug, categoriaSlug = c.Categoria.Slug }), "subCategoriaSlug", "categoriaSlug");
        }
    }
}