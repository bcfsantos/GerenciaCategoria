using Cadastro.Admin.Models;
using Cadastro.Infra.CrossCutting;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Cadastro.Admin.Controllers
{
    public class SubCategoriaController : Controller
    {
        private readonly string Api = string.Format("{0}{1}", ConfigurationManager.AppSettings["Api"], "/subcategoria");
        private readonly string ApiCampo = string.Format("{0}{1}", ConfigurationManager.AppSettings["Api"], "/campo");
        private readonly string ApiSubCategoriaCampo = string.Format("{0}{1}", ConfigurationManager.AppSettings["Api"], "/subcategoriacampo");
        private readonly string ApiCategoria = string.Format("{0}{1}", ConfigurationManager.AppSettings["Api"], "/categoria");
        List<Campo> campos;
        List<Categoria> categorias;

        public ActionResult Index()
        {
            var listaSubCategoria = HelperSOA.CallApi(Api, WebRequestMethods.Http.Get, string.Empty, string.Empty);
            if (listaSubCategoria.StatusCode == HttpStatusCode.OK)
                return View(JsonConvert.DeserializeObject<IList<SubCategoria>>(listaSubCategoria.Response));
            else
                return View();

        }

        public ActionResult Cadastrar()
        {
            PreencheDropDrownListCategoria();
            return View();
        }

        [HttpPost]
        public ActionResult Cadastrar(SubCategoria subcategoria)
        {
            if (ModelState.IsValid)
            {
                var subcadastraCategoria = HelperSOA.CallApi(Api, WebRequestMethods.Http.Post, JsonConvert.SerializeObject(subcategoria), string.Empty);
                if (subcadastraCategoria.StatusCode == HttpStatusCode.Created)
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

            var excluiCategoria = HelperSOA.CallApi(string.Format("{0}/{1}", Api, Id), "DELETE", string.Empty, string.Empty);
            if (excluiCategoria.StatusCode == HttpStatusCode.OK)
                return RedirectToAction("Index");
            else
                return RedirectToAction("Index");

        }


        [AcceptVerbs("GET", "DELETE")]
        public ActionResult ExcluirSubCategoriaCampo(int idSubCategoria, int idCampo, int ordem)
        {

            var excluiCategoria = HelperSOA.CallApi(string.Format("{0}/{1}/{2}/{3}", ApiSubCategoriaCampo, idSubCategoria, idCampo, ordem), "DELETE", string.Empty, string.Empty);
            if (excluiCategoria.StatusCode == HttpStatusCode.OK)
                return RedirectToAction("SubCategoriaCampo", new { id = idSubCategoria });
            else
                return RedirectToAction("Index");

        }

        [HttpGet]
        public ActionResult SubCategoriaCampo(int id)
        {
            PreencheDropDrownListCampo();

            var listaSubCategoria = HelperSOA.CallApi(Api, WebRequestMethods.Http.Get, id.ToString(), string.Empty);
            if (listaSubCategoria.StatusCode == HttpStatusCode.OK)
            {
                var subCategoria = JsonConvert.DeserializeObject<List<SubCategoria>>(listaSubCategoria.Response);
                return View(subCategoria.FirstOrDefault());
            }
            return View();
        }

        [HttpPost]
        public ActionResult CadastraSubCategoriaCampo(SubCategoriaCampo subCategoriaCampo)
        {
            if (ModelState.IsValid)
            {
                var subcadastraCategoriaCampo = HelperSOA.CallApi(ApiSubCategoriaCampo, WebRequestMethods.Http.Post, JsonConvert.SerializeObject(subCategoriaCampo), string.Empty);
                if (subcadastraCategoriaCampo.StatusCode == HttpStatusCode.Created)
                    return RedirectToAction("SubCategoriaCampo", new { id = subCategoriaCampo.IdSubCategoria });
                else
                {
                    return View("Index");
                }
            }
            else
                return View();
        }

        public void PreencheDropDrownListCategoria()
        {
            categorias = new List<Categoria>();
            var listaCategpria = HelperSOA.CallApi(ApiCategoria, WebRequestMethods.Http.Get, string.Empty, string.Empty);
            if (listaCategpria.StatusCode == HttpStatusCode.OK)
                categorias = JsonConvert.DeserializeObject<List<Categoria>>(listaCategpria.Response);

            ViewBag.ListaCategoria = new SelectList(categorias.Select(c => new { c.IdCategoria, c.Descricao }).ToList(), "IdCategoria", "Descricao");
        }

        public void PreencheDropDrownListCampo()
        {
            campos = new List<Campo>();
            var listaCampos = HelperSOA.CallApi(ApiCampo, WebRequestMethods.Http.Get, string.Empty, string.Empty);
            if (listaCampos.StatusCode == HttpStatusCode.OK)
                campos = JsonConvert.DeserializeObject<List<Campo>>(listaCampos.Response);

            //ViewBag.ListaCampo = new SelectList(campos.Select(c => new { c.IdCampo, c.Descricao }).ToList(), "IdCampo", "Descricao");
            ViewBag.ListaCampo = new SelectList(campos, "IdCampo", "Descricao");
        }


    }
}