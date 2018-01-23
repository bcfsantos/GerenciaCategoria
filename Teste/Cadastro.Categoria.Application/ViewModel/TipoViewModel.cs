using Cadastro.Domain.Entities;
using System.Collections.Generic;

namespace Cadastro.Application.ViewModel
{
    public class TipoViewModel
    {
        public TipoViewModel()
        {
            this.Campos = new List<CampoViewModel>();
        }
        public int IdTipo { get; set; }
        public string Descricao { get; set; }
        public virtual ICollection<CampoViewModel> Campos { get; set; }

    }
}
