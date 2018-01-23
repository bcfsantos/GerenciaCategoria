using AutoMapper;
using Cadastro.Admin.Models;
using Cadastro.Application.ViewModel;
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
    public class FormularioController : Controller
    {
        private readonly string ApiSubCategoria = string.Format("{0}{1}", ConfigurationManager.AppSettings["Api"], "/subcategoria");



        public ActionResult Index()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Index(string subCategoriaSlug, string categoriaSlug)
        {
            var listaSubCategoria = HelperSOA.CallApi(string.Format("{0}/{1}/{2}", ApiSubCategoria, subCategoriaSlug, categoriaSlug), WebRequestMethods.Http.Get, string.Empty, string.Empty);

            if (listaSubCategoria.StatusCode == HttpStatusCode.OK)
            {
                var subCategoria = JsonConvert.DeserializeObject<SubCategoria>(listaSubCategoria.Response);
                return View("Index",subCategoria);

            }
            else
                return View();

        }

    }
}