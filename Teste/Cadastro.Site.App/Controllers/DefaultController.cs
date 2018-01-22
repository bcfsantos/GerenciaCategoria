using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace Cadastro.Site.App.Controllers
{
    public class DefaultController : ApiController
    {
        // GET: Default
        public ActionResult Index()
        {
            return View();
        }
    }
}