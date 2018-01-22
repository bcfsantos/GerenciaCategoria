using Cadastro.Domain.Entities;
using Cadastro.Domain.Interfaces.Repositories;
using Cadastro.Infra.Repositories;

namespace Cadastro.Infra.Repositories
{
    public class TipoRepository : RepositoryBase<Tipo>, ITipoRepository
    {
    }
}
