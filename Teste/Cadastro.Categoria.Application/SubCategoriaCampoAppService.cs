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
    public class SubCategoriaCampoAppService : AppServiceBase<SubCategoriaCampo>, ISubCategoriaCampoAppService
    {
        private readonly ISubCategoriaCampoService _subCategoriaCampoService;

    public SubCategoriaCampoAppService(ISubCategoriaCampoService subCategoriaCampoService)
            : base(subCategoriaCampoService)
        {
            _subCategoriaCampoService = subCategoriaCampoService;
    }
}
}
