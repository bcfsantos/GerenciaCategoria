using Cadastro.Application.Interface;
using Cadastro.Domain.Entities;
using Cadastro.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cadastro.Application
{
    public class CampoAppService : AppServiceBase<Campo>, ICampoAppService
    {
        private readonly ICampoService _campoService;

        public CampoAppService(ICampoService campoService)
            : base(campoService)
        {
            _campoService = campoService;
        }
    }
}
