using AutoMapper;
using Cadastro.Application.Interface;
using Cadastro.Application.ViewModel;
using Cadastro.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Cadastro.WebApi.Controllers
{
    [RoutePrefix("api/subcategoria")]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class SubCategoriaController : ApiController
    {
        private readonly ISubCategoriaAppService _subcategoriaApp;


        public SubCategoriaController(ISubCategoriaAppService subcategoriaApp)
        {
            _subcategoriaApp = subcategoriaApp;
        }

        /// <summary>
        /// Lista todas Subcategorias cadatradas.
        /// </summary>
        /// <returns>Lista de SubCategoria</returns>
        [Route("")]
        [HttpGet]
        public HttpResponseMessage GetAll()
        {
            try
            {
                var subcategoriaViewModel = Mapper.Map<IEnumerable<SubCategoria>, IEnumerable<SubCategoriaViewModel>>(_subcategoriaApp.GetAll());

                if (subcategoriaViewModel != null)
                    return Request.CreateResponse(HttpStatusCode.OK, subcategoriaViewModel);
                else
                    return Request.CreateResponse(HttpStatusCode.NoContent);

            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex);
            }

        }


        /// <summary>
        /// Retorna as informações de uma determinada subcategoria.
        /// </summary>
        /// <param name="Idsubcategoria">Id da subcategoria.</param>
        /// <returns>Lista de subcategoria</returns>
        [Route("{Idsubcategoria}")]
        [HttpGet]
        public HttpResponseMessage GetId(int Idsubcategoria)
        {
            try
            {
                var subcategoriaViewModel = Mapper.Map<SubCategoria, SubCategoriaViewModel>(_subcategoriaApp.GetId(Idsubcategoria));

                if (subcategoriaViewModel != null)
                    return Request.CreateResponse(HttpStatusCode.OK, subcategoriaViewModel);
                else
                    return Request.CreateResponse(HttpStatusCode.NoContent);

            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex);
            }

        }


        /// <summary>
        /// Inclui uma nova subcategoria.
        /// </summary>
        /// <param name="subcategoria">Objeto preenchido de categoria.</param>
        /// <returns></returns>
        [Route("")]
        [HttpPost]
        public HttpResponseMessage Post(SubCategoriaViewModel subcategoria)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var subcategoriaViewModel = Mapper.Map<SubCategoriaViewModel, SubCategoria>(subcategoria);
                    _subcategoriaApp.Add(subcategoriaViewModel);
                    return Request.CreateResponse(HttpStatusCode.Created);
                }
                else
                    return Request.CreateResponse(HttpStatusCode.PreconditionFailed);

            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex);
            }

        }



        /// <summary>
        /// Deletea a subcategoria selecionada por id
        /// </summary>
        /// <param name="IdSubCategoria">Id subcategoria a ser deletada</param>
        /// <returns></returns>
        [AllowAnonymous]
        [Route("{Idsubcategoria}")]
        [HttpDelete]
        public HttpResponseMessage Delete(int Idsubcategoria)
        {
            try
            {
                var subcategoriaViewModel = _subcategoriaApp.GetId(Idsubcategoria);
                if (subcategoriaViewModel != null)
                {
                    _subcategoriaApp.Remove(subcategoriaViewModel);
                    return Request.CreateResponse(HttpStatusCode.OK, subcategoriaViewModel);
                }
                else
                    return Request.CreateResponse(HttpStatusCode.NoContent);

            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex);
            }

        }
    }
}
