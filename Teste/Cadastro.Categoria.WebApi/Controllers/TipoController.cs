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
    [RoutePrefix("api/tipo")]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class TipoController : ApiController
    {

        private readonly ITipoAppService _tipoApp;

        public TipoController(ITipoAppService tipoApp)
        {
            _tipoApp = tipoApp;
        }

        /// <summary>
        /// Lista todos tipos cadatrados.
        /// </summary>
        /// <returns></returns>
        [Route("")]
        [HttpGet]
        public HttpResponseMessage GetAll()
        {
            try
            {
                var tipoViewModel = Mapper.Map<IEnumerable<Tipo>, IEnumerable<TipoViewModel>>(_tipoApp.GetAll());

                if (tipoViewModel != null)
                    return Request.CreateResponse(HttpStatusCode.OK, tipoViewModel);
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
