using Cadastro.Application.ViewModel;
using Cadastro.Categoria.Infra.CrossCutting;
using Newtonsoft.Json;
using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Mvc;

namespace Cadastro.Admin.App.Controllers
{
    public class CategoriaController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public JsonResult IncluiCategoria(CategoriaViewModel novaCategoria)
        {
            if (ModelState.IsValid)
            {
                var retorno = HelperSOA.CallApi("http://localhost:8081/api/categoria", WebRequestMethods.Http.Post, JsonConvert.SerializeObject(novaCategoria), "");
                if (retorno.StatusCode == HttpStatusCode.Created)
                    return Json(new { retorno = true }, JsonRequestBehavior.AllowGet);
                else
                    return Json(new { retorno = false, error = retorno.Response }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new
                {
                    retorno = false,
                    error = ModelState.Keys.SelectMany(i => ModelState[i].Errors).Select(m => m.ErrorMessage).ToArray()
                }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpGet]
        public JsonResult ListaCategoria()
        {

            var retorno = HelperSOA.CallApi("http://localhost:8081/api/categoria", WebRequestMethods.Http.Get, string.Empty, string.Empty);
            if (retorno.StatusCode == HttpStatusCode.OK)
                return Json(new { retorno = true, lista = retorno.Response }, JsonRequestBehavior.AllowGet);
            else
                return Json(new { retorno = false, error = retorno.Response }, JsonRequestBehavior.AllowGet);
        }

    }

}