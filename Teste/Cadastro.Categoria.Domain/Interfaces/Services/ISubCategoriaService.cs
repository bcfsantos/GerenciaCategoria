using Cadastro.Domain.Entities;

namespace Cadastro.Domain.Interfaces.Services
{
    public interface ISubCategoriaService : IServiceBase<SubCategoria>
    {
        SubCategoria GetSubCategoriaSlug(string slugSubCategoria, string slugCategoria);
    }
}
