using Cadastro.Domain.Entities;
using Cadastro.Infra.CrossCutting;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Site.Controllers
{
    public class FormularioController : Controller
    {
        private readonly string ApiSubCategoria = string.Format("{0}{1}", ConfigurationManager.AppSettings["Api"], "/subcategoria");

        public ActionResult Index(string categoriaSlug, string subCategoriaSlug)
        {
            var listaSubCategoria = HelperSOA.CallApi(string.Format("{0}/{1}/{2}", ApiSubCategoria, subCategoriaSlug, categoriaSlug), WebRequestMethods.Http.Get, string.Empty, string.Empty);

            if (listaSubCategoria.StatusCode == HttpStatusCode.OK)
            {
                var subCategoria = JsonConvert.DeserializeObject<SubCategoria>(listaSubCategoria.Response);
                return View(subCategoria);

            }
            else
                return View();

        }
    }
}