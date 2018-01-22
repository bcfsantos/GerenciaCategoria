using Cadastro.Infra.CrossCutting;
using System.Configuration;
using System.Net;
using System.Web.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using Cadastro.Admin.Models;
using System.Linq;

namespace Cadastro.Admin.Controllers
{
    public class CampoController : Controller
    {
        private readonly string Api = string.Format("{0}{1}", ConfigurationManager.AppSettings["Api"], "/campo");
        private readonly string ApiTipo = string.Format("{0}{1}", ConfigurationManager.AppSettings["Api"], "/tipo");
        List<Tipo> tipos;
      

        public ActionResult Index()
        {
            var listaCampo = HelperSOA.CallApi(Api, WebRequestMethods.Http.Get, string.Empty, string.Empty);
            if (listaCampo.StatusCode == HttpStatusCode.OK)
                return View(JsonConvert.DeserializeObject<IList<Campo>>(listaCampo.Response));
            else
                return View();

        }

        public ActionResult Cadastrar()
        {
            PreencheDropDrownListTipo();
            return View();
        }

        [HttpPost]
        public ActionResult Cadastrar(Campo campo)
        {
            if (ModelState.IsValid)
            {
                var campoCadastrar = HelperSOA.CallApi(Api, WebRequestMethods.Http.Post, JsonConvert.SerializeObject(campo), string.Empty);
                if (campoCadastrar.StatusCode == HttpStatusCode.Created)
                    return RedirectToAction("Index");
                else
                {
                    return View("Index");
                }

            }
            else
                return View();
        }

        [AcceptVerbs("GET", "DELETE")]
        public ActionResult Excluir(int Id)
        {

            var excluiCampo = HelperSOA.CallApi(string.Format("{0}/{1}", Api, Id), "DELETE", string.Empty, string.Empty);
            if (excluiCampo.StatusCode == HttpStatusCode.OK)
                return RedirectToAction("Index");
            else
                return RedirectToAction("Index");

        }

        public ActionResult AdiconarCampo()
        {
            PreencheDropDrownListTipo();
            return PartialView("_Campo");
        }

        public void PreencheDropDrownListTipo()
        {
            tipos = new List<Tipo>();

            var listaTipo = HelperSOA.CallApi(ApiTipo, WebRequestMethods.Http.Get, string.Empty, string.Empty);
            if (listaTipo.StatusCode == HttpStatusCode.OK)
                tipos = JsonConvert.DeserializeObject<List<Tipo>>(listaTipo.Response);

            ViewBag.ListaTipo = new SelectList(tipos.Select(c => new { c.IdTipo, c.Descricao }).ToList(), "IdTipo", "Descricao");
        }
    }
}
