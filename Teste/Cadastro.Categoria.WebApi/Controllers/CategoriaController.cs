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

        public CategoriaController(ICategoriaAppService categoriaApp)
        {
            _categoriaApp = categoriaApp;
        }

        /// <summary>
        /// Lista todas categorias cadatradas.
        /// </summary>
        /// <returns>Lista de Categoria, SubCategoria e Campos da SubCategoria.</returns>
        [Route("")]
        [HttpGet]
        public HttpResponseMessage GetAll()
        {
            try
            {
                var categoriaViewModel = Mapper.Map<IEnumerable<Cadastro.Domain.Entities.Categoria>, IEnumerable<CategoriaViewModel>>(_categoriaApp.GetAll());

                if (categoriaViewModel != null)
                    return Request.CreateResponse(HttpStatusCode.OK, categoriaViewModel);
                else
                    return Request.CreateResponse(HttpStatusCode.NoContent);

            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex);
            }

        }


        /// <summary>
        /// Retorna as informações de uma determinada categoria.
        /// </summary>
        /// <param name="id">Id da categoria.</param>
        /// <returns>Lista de Categoria, SubCategoria e Campos da SubCategoria.</returns>
        [Route("{id}")]
        [HttpGet]
        public HttpResponseMessage GetId(int id)
        {
            try
            {
                var categoriaViewModel = Mapper.Map<Cadastro.Domain.Entities.Categoria, CategoriaViewModel>(_categoriaApp.GetId(id));

                if (categoriaViewModel != null)
                    return Request.CreateResponse(HttpStatusCode.OK, categoriaViewModel);
                else
                    return Request.CreateResponse(HttpStatusCode.NoContent);

            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex);
            }

        }


        /// <summary>
        /// Inclui uma nova categoria.
        /// </summary>
        /// <param name="categoria">Objeto preenchido de categoria.</param>
        /// <returns></returns>
        [Route("")]
        [HttpPost]
        public HttpResponseMessage Post(CategoriaViewModel categoria)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var categoriaViewModel = Mapper.Map<CategoriaViewModel, Cadastro.Domain.Entities.Categoria>(categoria);
                    _categoriaApp.Add(categoriaViewModel);
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


        [Route("{id}")]
        [HttpDelete]
        public HttpResponseMessage Delete(int id)
        {
            try
            {
                var categoriaViewModel = _categoriaApp.GetId(id);
                if (categoriaViewModel != null)
                {
                    _categoriaApp.Remove(categoriaViewModel);
                    return Request.CreateResponse(HttpStatusCode.OK, categoriaViewModel);
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