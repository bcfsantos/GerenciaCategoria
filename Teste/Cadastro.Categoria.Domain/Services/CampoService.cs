using Cadastro.Domain.Entities;
using Cadastro.Domain.Interfaces.Repositories;
using Cadastro.Domain.Interfaces.Services;

namespace Cadastro.Domain.Services
{
    public class CampoService : ServiceBase<Campo>, ICampoService
    {
        private readonly ICampoRepository _campoRepository;

        public CampoService(ICampoRepository campoRepository)
            : base(campoRepository)
        {
            _campoRepository = campoRepository;
        }

    
    }
}
