using Cadastro.Application.ViewModel;
using Cadastro.Domain.Entities;
using System.Collections.Generic;

namespace Cadastro.Application.ViewModel
{
    public class SubCategoriaViewModel
    {

        public SubCategoriaViewModel()
        {
            this.SubCategoriaCampos = new List<SubCategoriaCampoViewModel>();
        }

        public int IdSubCategoria { get; set; }
        public string Descricao { get; set; }
        public string Slug { get; set; }
        public int IdCategoria { get; set; }
        public virtual CategoriaViewModel Categoria { get; set; }
        public virtual ICollection<SubCategoriaCampoViewModel> SubCategoriaCampos { get; set; }
    }
}
