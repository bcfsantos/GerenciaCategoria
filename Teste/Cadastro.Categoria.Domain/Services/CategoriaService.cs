using Cadastro.Domain.Entities;
using Cadastro.Domain.Interfaces.Repositories;
using Cadastro.Domain.Interfaces.Services;

namespace Cadastro.Domain.Services
{
    public  class CategoriaService : ServiceBase<Categoria>, ICategoriaService
    {
        private readonly ICategoriaRepository _categoriaRepository;

        public CategoriaService(ICategoriaRepository categoriaRepository)
            : base(categoriaRepository)
        {
            _categoriaRepository = categoriaRepository;
        }
    }
}
