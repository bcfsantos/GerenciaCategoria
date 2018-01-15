using System.Collections.Generic;

namespace Cadastro.Application.ViewModel
{
    public class SubCategoriaViewModel
    {
        public SubCategoriaViewModel()
        {
            this.Campos = new List<CampoViewModel>();
        }
        public int IdSubCategoria { get; set; }
        public string Descricao { get; set; }
        public string Slug { get; set; }

        public int IdCategoria { get; set; }
        public virtual CategoriaViewModel Categoria { get; set; }

        public virtual ICollection<CampoViewModel> Campos { get; set; }
    }
}
