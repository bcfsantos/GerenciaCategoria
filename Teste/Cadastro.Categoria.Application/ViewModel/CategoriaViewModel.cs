using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Cadastro.Application.ViewModel
{
    public class CategoriaViewModel
    {
        public CategoriaViewModel()
        {
            this.SubCategoria = new List<SubCategoriaViewModel>();
        }


        public int IdCategoria { get; set; }
        public string Descricao { get; set; }
        public string Slug { get; set; }
        public virtual ICollection<SubCategoriaViewModel> SubCategoria { get; set; }
    }
}
