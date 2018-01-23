using System;
using Cadastro.Domain.Entities;
using Cadastro.Domain.Interfaces.Repositories;
using Cadastro.Infra.Repositories;
using System.Linq;

namespace Cadastro.Infra.Repositories
{
    public class SubCategoriaRepository : RepositoryBase<SubCategoria>, ISubCategoriaRepository
    {
        public SubCategoria GetSubCategoriaSlug(string slugSubCategoria, string slugCategoria)
        {
            return Db.SubCategorias.Where(c => c.Slug == slugSubCategoria && c.Categoria.Slug == slugCategoria).FirstOrDefault();
        }
    }
}
