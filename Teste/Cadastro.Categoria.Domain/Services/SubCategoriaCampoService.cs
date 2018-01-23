using Cadastro.Domain.Entities;
using Cadastro.Domain.Interfaces.Repositories;
using Cadastro.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cadastro.Domain.Services
{
    public class SubCategoriaCampoService : ServiceBase<SubCategoriaCampo>, ISubCategoriaCampoService
    {
        private readonly ISubCategoriaCampoRepository _subCategoriaCampoRepository;

        public SubCategoriaCampoService(ISubCategoriaCampoRepository subCategoriaCampoRepository)
            : base(subCategoriaCampoRepository)
        {
            _subCategoriaCampoRepository = subCategoriaCampoRepository;
        }

        public void AddSubCategoriaCampoOrdem(SubCategoriaCampo subCategoriaCampo)
        {
            var ordem = GetIdSubCategoria(subCategoriaCampo.IdSubCategoria);
            if (ordem.Count() > 0)
            {
                subCategoriaCampo.Ordem = ordem.Max(c => c.Ordem) + 1;
                _subCategoriaCampoRepository.Add(subCategoriaCampo);
            }
            else
            {
                subCategoriaCampo.Ordem = 1;
                _subCategoriaCampoRepository.Add(subCategoriaCampo);
            }
        }

        public IList<SubCategoriaCampo> GetIdSubCategoria(int IdSubcategoria)
        {
            return _subCategoriaCampoRepository.GetIdSubCategoria(IdSubcategoria);
        }

        public SubCategoriaCampo GetIdSubCategoriaCampoOrdem(int IdSubCategoria, int IdCampo, int Ordem)
        {
            return _subCategoriaCampoRepository.GetIdSubCategoriaCampoOrdem(IdSubCategoria, IdCampo, Ordem);
        }
    }
}
