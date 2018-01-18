using Cadastro.Application.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Cadastro.Admin.App.Controllers
{
    public class CategoriaController : Controller
    {
        // GET: Categoria
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult IncluirCategoria(CategoriaViewModel novaCategoria)
        {
            return View();
        }
    }
}