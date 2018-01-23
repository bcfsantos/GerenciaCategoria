using Cadastro.Domain.Entities;

namespace Cadastro.Domain.Interfaces.Repositories
{
    public interface ISubCategoriaRepository : IRepositoryBase<SubCategoria>
    {
        SubCategoria GetSubCategoriaSlug(string slugSubCategoria, string slugCategoria);
    }
}
