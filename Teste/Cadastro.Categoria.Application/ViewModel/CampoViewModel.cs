using System.Collections.Generic;

namespace Cadastro.Application.ViewModel
{
    public class CampoViewModel
    {
        public CampoViewModel()
        {
            this.SubCategoria = new List<SubCategoriaViewModel>();
        }
        public int IdCategoria { get; set; }
        public string Descricao { get; set; }
        public string Slug { get; set; }

        public virtual ICollection<SubCategoriaViewModel> SubCategoria { get; set; }
    }
}
