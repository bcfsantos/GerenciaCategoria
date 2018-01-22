using Cadastro.Application;
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
 public   class TipoAppService : AppServiceBase<Tipo>, ITipoAppService
    {
        private readonly ITipoService _tipoService;

        public TipoAppService(ITipoService tipoService)
            : base(tipoService)
        {
            _tipoService = tipoService;
        }
    }
}
