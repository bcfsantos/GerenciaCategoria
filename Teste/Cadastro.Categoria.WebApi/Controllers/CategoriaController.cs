using AutoMapper;
using Cadastro.Application.Interface;
using Cadastro.Application.ViewModel;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;


namespace Cadastro.Categoria.WebApi.Controllers
{
    [RoutePrefix("api/categoria")]
    public class CategoriaController : ApiController
    {
        private readonly ICategoriaAppService _categoriaApp;
        private readonly ISubCategoriaAppService _subcategoriaApp;

        public CategoriaController(ICategoriaAppService categoriaApp, ISubCategoriaAppService subcategoriaApp)
        {
            _categoriaApp = categoriaApp;
            _subcategoriaApp = subcategoriaApp;
        }
        /// <summary>
        /// Lista todas categorias cadatradas.
        /// </summary>
        /// <returns>Lista de Categoria, SubCategoria e Campos da SubCategoria.</returns>
        [Route("")]
        [HttpGet]
        public HttpResponseMessage Index()
        {
            try
            {
                //var clienteViewModel = Mapper.Map<IEnumerable<Cadastro.Categoria.Domain.Entities.Categoria>, IEnumerable<CategoriaViewModel>>(_categoriaApp.GetAll());
                var clienteViewModel = _subcategoriaApp.GetAll();

                if (clienteViewModel != null)
                    return Request.CreateResponse(HttpStatusCode.OK, clienteViewModel);
                else
                    return Request.CreateResponse(HttpStatusCode.NoContent, clienteViewModel);

            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex);
            }

        }



    }
}