using Cadastro.Application.Interface;
using Cadastro.Domain.Entities;
using Cadastro.Domain.Interfaces.Services;

namespace Cadastro.Application
{
    public class CategoriaAppService : AppServiceBase<Categoria>, ICategoriaAppService
    {
        private readonly ICategoriaService _categoriaService;

        public CategoriaAppService(ICategoriaService categoriaService)
            : base(categoriaService)
        {
            _categoriaService = categoriaService;
        }
    }
}
