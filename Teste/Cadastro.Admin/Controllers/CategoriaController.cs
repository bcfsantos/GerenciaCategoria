using Cadastro.Infra.CrossCutting;
using System.Configuration;
using System.Net;
using System.Web.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using Cadastro.Admin.Models;

namespace Cadastro.Admin.Controllers
{
    public class CategoriaController : Controller
    {

        private readonly string Api = string.Format("{0}{1}",ConfigurationManager.AppSettings["Api"],"/categoria");

        public ActionResult Index()
        {

            var listaCategoria = HelperSOA.CallApi(Api, WebRequestMethods.Http.Get, string.Empty, string.Empty);
            if (listaCategoria.StatusCode == HttpStatusCode.OK)
                return View(JsonConvert.DeserializeObject<IList<Categoria>>(listaCategoria.Response));
            else
            {
                return View();
            }
        }

        public ActionResult Cadastrar()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Cadastrar(Categoria categoria)
        {
            if (ModelState.IsValid)
            {
                var cadastraCategoria = HelperSOA.CallApi(Api, WebRequestMethods.Http.Post, JsonConvert.SerializeObject(categoria), string.Empty);
                if (cadastraCategoria.StatusCode == HttpStatusCode.Created)
                    return RedirectToAction("Index");
                else
                {
                    return View("Index");
                }

            }
            else
                return View();
        }

        [AcceptVerbs("GET","DELETE")]
        public ActionResult Excluir(int Id)
        {

            var excluiCategoria = HelperSOA.CallApi(string.Format("{0}/{1}", Api, Id), "DELETE", string.Empty, string.Empty);
            if (excluiCategoria.StatusCode == HttpStatusCode.OK)
                return RedirectToAction("Index");
            else
                return RedirectToAction("Index");

        }
    }
}