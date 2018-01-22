using Cadastro.Domain.Entities;
using Cadastro.Domain.Interfaces.Repositories;
using Cadastro.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cadastro.Domain.Services
{
   public class SubCategoriaCampoService : ServiceBase<SubCategoriaCampo>, ISubCategoriaCampoService
    {
        private readonly ISubCategoriaCampoRepository _subCategoriaCampoRepository;

        public SubCategoriaCampoService(ISubCategoriaCampoRepository subCategoriaCampoRepository)
            : base(subCategoriaCampoRepository)
        {
            _subCategoriaCampoRepository = subCategoriaCampoRepository;
        }
    }
}
