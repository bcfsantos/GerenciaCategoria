using Cadastro.Domain.Entities;
using Cadastro.Domain.Interfaces.Repositories;
using Cadastro.Domain.Interfaces.Services;

namespace Cadastro.Domain.Services
{
    public class TipoService : ServiceBase<Tipo>, ITipoService
    {
        private readonly ITipoRepository _tipoRepository;

        public TipoService(ITipoRepository tipoRepository)
            : base(tipoRepository)
        {
            _tipoRepository = tipoRepository;
        }
    }
}
