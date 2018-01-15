using System.Web.Http;
using WebActivatorEx;
using Cadastro.Categoria.WebApi;
using Swashbuckle.Application;
using System;
using System.Xml.XPath;

[assembly: PreApplicationStartMethod(typeof(SwaggerConfig), "Register")]

namespace Cadastro.Categoria.WebApi
{
    public class SwaggerConfig
    {
        public static void Register()
        {
            var thisAssembly = typeof(SwaggerConfig).Assembly;

            GlobalConfiguration.Configuration
                .EnableSwagger(c =>
                {
                    c.SingleApiVersion("v1", "WebApi");
                    c.IncludeXmlComments(GetXmlCommentsPath());
                })
                .EnableSwaggerUi();
        }
       

        private static string GetXmlCommentsPath()
        {
            return System.String.Format(@"{0}bin\Cadastro.Categoria.WebApi.XML", System.AppDomain.CurrentDomain.BaseDirectory);
        }
    }
}
