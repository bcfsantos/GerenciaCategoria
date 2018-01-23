using Cadastro.Domain.Entities;
using Cadastro.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cadastro.Infra.Repositories
{
    public class SubCategoriaCampoRepository : RepositoryBase<SubCategoriaCampo>, ISubCategoriaCampoRepository
    {
        public IList<SubCategoriaCampo> GetIdSubCategoria(int IdSubcategoria)
        {
            return Db.SubCategoriaCampos.Where(c => c.IdSubCategoria == IdSubcategoria).ToList();
        }

        public SubCategoriaCampo GetIdSubCategoriaCampoOrdem(int IdSubCategoria, int IdCampo, int Ordem)
        {
            return Db.SubCategoriaCampos.Where(c => c.IdSubCategoria == IdSubCategoria && c.IdCampo == IdCampo && c.Ordem == Ordem).FirstOrDefault();
        }
    }
}
