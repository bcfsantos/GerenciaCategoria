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
    [RoutePrefix("api/campo")]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class CampoController : ApiController
    {
        private readonly ICampoAppService _CampoApp;


        public CampoController(ICampoAppService CampoApp)
        {
            _CampoApp = CampoApp;
        }

        /// <summary>
        /// Lista todos Campos cadatrados.
        /// </summary>
        /// <returns>Lista de Campo</returns>
        [Route("")]
        [HttpGet]
        public HttpResponseMessage GetAll()
        {
            try
            {
                var CampoViewModel = Mapper.Map<IEnumerable<Campo>, IEnumerable<CampoViewModel>>(_CampoApp.GetAll());

                if (CampoViewModel != null)
                    return Request.CreateResponse(HttpStatusCode.OK, CampoViewModel);
                else
                    return Request.CreateResponse(HttpStatusCode.NoContent);

            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex);
            }

        }


        /// <summary>
        /// Retorna as informações de uma determinada Campo.
        /// </summary>
        /// <param name="IdCampo">Id da Campo.</param>
        /// <returns>Lista de Campo.</returns>
        [Route("{IdCampo}")]
        [HttpGet]
        public HttpResponseMessage GetId(int IdCampo)
        {
            try
            {
                var CampoViewModel = Mapper.Map<Campo, CampoViewModel>(_CampoApp.GetId(IdCampo));

                if (CampoViewModel != null)
                    return Request.CreateResponse(HttpStatusCode.OK, CampoViewModel);
                else
                    return Request.CreateResponse(HttpStatusCode.NoContent);

            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex);
            }

        }


        /// <summary>
        /// Inclui uma nova Campo.
        /// </summary>
        /// <param name="Campo">Objeto preenchido de Campo.</param>
        /// <returns></returns>
        [Route("")]
        [HttpPost]
        public HttpResponseMessage Post(CampoViewModel Campo)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var CampoViewModel = Mapper.Map<CampoViewModel, Campo>(Campo);
                    _CampoApp.Add(CampoViewModel);
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
        /// Deletea a Campo selecionada por id
        /// </summary>
        /// <param name="IdCampo">Id Campo a ser deletada</param>
        /// <returns></returns>
        [AllowAnonymous]
        [Route("{IdCampo}")]
        [HttpDelete]
        public HttpResponseMessage Delete(int IdCampo)
        {
            try
            {
                var CampoViewModel = _CampoApp.GetId(IdCampo);
                if (CampoViewModel != null)
                {
                    _CampoApp.Remove(CampoViewModel);
                    return Request.CreateResponse(HttpStatusCode.OK, CampoViewModel);
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
