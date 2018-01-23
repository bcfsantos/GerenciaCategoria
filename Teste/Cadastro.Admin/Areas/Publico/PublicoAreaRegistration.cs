using System.Web.Mvc;

namespace Cadastro.Admin.Areas.Publico
{
    public class PublicoAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Publico";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {

            //context.MapRoute(
            //        "Caegoria",
            //        "{slugCategoria}/{slugSubCategoria}", 
            //        new { controller = "Formulario", action = "Index" },
            //        namespaces: new[] { "Cadastro.Admin.Areas.Publico.Controllers" }
            //        );

            context.MapRoute(
                "Publico_default",
                "Publico/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional },
                namespaces: new[] { "Cadastro.Admin.Areas.Publico.Controllers" }
            );
        }
    }
}