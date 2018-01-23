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

    [RoutePrefix("api/subcategoriacampo")]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class SubCategoriaCampoController : ApiController
    {
        private readonly ISubCategoriaCampoAppService _subCategoriaCampoApp;


        public SubCategoriaCampoController(ISubCategoriaCampoAppService subCategoriaCampoApp)
        {
            _subCategoriaCampoApp = subCategoriaCampoApp;
        }

        /// <summary>
        /// Lista todas SubCategoriaCampos cadatradas.
        /// </summary>
        /// <returns>Lista de SubCategoriaCampo</returns>
        [Route("")]
        [HttpGet]
        public HttpResponseMessage GetAll()
        {
            try
            {
                var subCategoriaCampoViewModel = Mapper.Map<IEnumerable<SubCategoriaCampo>, IEnumerable<SubCategoriaCampoViewModel>>(_subCategoriaCampoApp.GetAll());

                if (subCategoriaCampoViewModel != null)
                    return Request.CreateResponse(HttpStatusCode.OK, subCategoriaCampoViewModel);
                else
                    return Request.CreateResponse(HttpStatusCode.NoContent);

            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex);
            }

        }


        /// <summary>
        /// Retorna as informações de uma determinada subCategoriaCampo.
        /// </summary>
        /// <param name="IdsubCategoriaCampo">Id da subCategoriaCampo.</param>
        /// <returns>Lista de subCategoriaCampo</returns>
        [Route("{IdsubCategoriaCampo}")]
        [HttpGet]
        public HttpResponseMessage GetId(int IdsubCategoriaCampo)
        {
            try
            {
                var subCategoriaCampoViewModel = Mapper.Map<SubCategoriaCampo, SubCategoriaCampoViewModel>(_subCategoriaCampoApp.GetId(IdsubCategoriaCampo));

                if (subCategoriaCampoViewModel != null)
                    return Request.CreateResponse(HttpStatusCode.OK, subCategoriaCampoViewModel);
                else
                    return Request.CreateResponse(HttpStatusCode.NoContent);

            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex);
            }

        }


        /// <summary>
        /// Inclui uma nova subCategoriaCampo.
        /// </summary>
        /// <param name="subCategoriaCampo">Objeto preenchido de categoria.</param>
        /// <returns></returns>
        [Route("")]
        [HttpPost]
        public HttpResponseMessage Post(SubCategoriaCampoViewModel subCategoriaCampo)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var subCategoriaCampoViewModel = Mapper.Map<SubCategoriaCampoViewModel, SubCategoriaCampo>(subCategoriaCampo);
                    _subCategoriaCampoApp.AddSubCategoriaCampoOrdem(subCategoriaCampoViewModel);
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
        /// Deleta vinculo da subcategoria com o campo
        /// </summary>
        /// <param name="IdSubCategoria">Id subcategoria</param>
        /// <param name="IdCampo">Id do campo</param>
        /// <param name="Ordem">Ordem do campo</param>
        /// <returns></returns>
        [AllowAnonymous]
        [Route("{IdSubCategoria}/{IdCampo}/{Ordem}")]
        [HttpDelete]
        public HttpResponseMessage Delete(int IdSubCategoria, int IdCampo, int Ordem)
        {
            try
            {
                _subCategoriaCampoApp.RemoveSubcategoriaCampos(IdSubCategoria, IdCampo, Ordem);
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex);
            }

        }
    }
}
