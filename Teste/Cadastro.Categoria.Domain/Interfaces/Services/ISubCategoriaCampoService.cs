using Cadastro.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cadastro.Domain.Interfaces.Services
{
    public interface ISubCategoriaCampoService : IServiceBase<SubCategoriaCampo>
    {
        IList<SubCategoriaCampo> GetIdSubCategoria(int IdSubcategoria);

        void AddSubCategoriaCampoOrdem(SubCategoriaCampo subCategoriaCampo);
        SubCategoriaCampo GetIdSubCategoriaCampoOrdem(int IdSubCategoria, int IdCampo, int Ordem);
    }
}
