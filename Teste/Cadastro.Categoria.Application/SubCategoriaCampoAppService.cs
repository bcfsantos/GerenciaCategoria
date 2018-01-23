using Cadastro.Application;
using Cadastro.Application.Interface;
using Cadastro.Domain.Entities;
using Cadastro.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cadastro.Application
{
    public class SubCategoriaCampoAppService : AppServiceBase<SubCategoriaCampo>, ISubCategoriaCampoAppService
    {
        private readonly ISubCategoriaCampoService _subCategoriaCampoService;

    public SubCategoriaCampoAppService(ISubCategoriaCampoService subCategoriaCampoService)
            : base(subCategoriaCampoService)
        {
            _subCategoriaCampoService = subCategoriaCampoService;
    }

        public void AddSubCategoriaCampoOrdem(SubCategoriaCampo subCategoriaCampo)
        {
            _subCategoriaCampoService.AddSubCategoriaCampoOrdem(subCategoriaCampo);
        }

        public IList<SubCategoriaCampo> GetIdSubCategoria(int IdSubcategoria)
        {
            return _subCategoriaCampoService.GetIdSubCategoria(IdSubcategoria);
        }

        public SubCategoriaCampo GetIdSubCategoriaCampoOrdem(int IdSubCategoria, int IdCampo, int Ordem)
        {
            return _subCategoriaCampoService.GetIdSubCategoriaCampoOrdem(IdSubCategoria, IdCampo, Ordem);
        }

        public void RemoveSubcategoriaCampos(int IdSubCategoria, int IdCampo, int Ordem)
        {
            var subcategoriacampo = GetIdSubCategoriaCampoOrdem(IdSubCategoria, IdCampo, Ordem);
            _subCategoriaCampoService.Remove(subcategoriacampo);
        }
    }
}
