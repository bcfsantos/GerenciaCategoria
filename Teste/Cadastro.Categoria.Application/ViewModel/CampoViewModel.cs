using System.Collections.Generic;

namespace Cadastro.Application.ViewModel
{
    public class CampoViewModel
    {
        public CampoViewModel()
        {
        }

        public int IdCampo { get; set; }
        public string Descricao { get; set; }
        public string Lista { get; set; }
        public int IdTipo { get; set; }
        public virtual TipoViewModel Tipo { get; set; }
        public virtual ICollection<SubCategoriaCampoViewModel> SubCategoriaCampos { get; set; }

    }
}
