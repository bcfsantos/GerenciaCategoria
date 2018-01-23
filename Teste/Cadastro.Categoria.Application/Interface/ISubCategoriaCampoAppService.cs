using Cadastro.Application.Interface;
using Cadastro.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cadastro.Application.Interface
{
    public interface ISubCategoriaCampoAppService : IAppServiceBase<SubCategoriaCampo>
    {
        IList<SubCategoriaCampo> GetIdSubCategoria(int IdSubcategoria);

        void AddSubCategoriaCampoOrdem(SubCategoriaCampo subCategoriaCampo);

        SubCategoriaCampo GetIdSubCategoriaCampoOrdem(int IdSubCategoria, int IdCampo, int Ordem);

        void RemoveSubcategoriaCampos(int IdSubCategoria, int IdCampo, int Ordem);
    }
}
