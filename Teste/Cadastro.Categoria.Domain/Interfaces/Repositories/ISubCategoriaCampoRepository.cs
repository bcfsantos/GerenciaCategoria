using Cadastro.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cadastro.Domain.Interfaces.Repositories
{
    public interface ISubCategoriaCampoRepository : IRepositoryBase<SubCategoriaCampo>
    {
        IList<SubCategoriaCampo> GetIdSubCategoria(int IdSubcategoria);

        SubCategoriaCampo GetIdSubCategoriaCampoOrdem(int IdSubCategoria, int IdCampo, int Ordem);
    }
}
