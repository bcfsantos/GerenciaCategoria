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
   public class SubCategoriaAppService : AppServiceBase<SubCategoria>, ISubCategoriaAppService
    {
        private readonly ISubCategoriaService _subCategoria;

        public SubCategoriaAppService(ISubCategoriaService subCategoria)
            : base(subCategoria)
        {
            _subCategoria = subCategoria;
        }
    }
}
