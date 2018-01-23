using Cadastro.Domain.Entities;

namespace Cadastro.Application.Interface
{
    public interface ISubCategoriaAppService : IAppServiceBase<SubCategoria>
    {
        SubCategoria GetSubCategoriaSlug(string slugSubCategoria, string slugCategoria);
    }
}
