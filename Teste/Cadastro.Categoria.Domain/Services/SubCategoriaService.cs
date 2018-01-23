using System;
using Cadastro.Domain.Entities;
using Cadastro.Domain.Interfaces.Repositories;
using Cadastro.Domain.Interfaces.Services;

namespace Cadastro.Domain.Services
{
    public   class SubCategoriaService : ServiceBase<SubCategoria>, ISubCategoriaService
    {
        private readonly ISubCategoriaRepository _subCategoriaRepository;

        public SubCategoriaService(ISubCategoriaRepository subCategoriaRepository)
            : base(subCategoriaRepository)
        {
            _subCategoriaRepository = subCategoriaRepository;
        }

        public SubCategoria GetSubCategoriaSlug(string slugSubCategoria, string slugCategoria)
        {
            return _subCategoriaRepository.GetSubCategoriaSlug(slugSubCategoria, slugCategoria);
        }
    }
}
