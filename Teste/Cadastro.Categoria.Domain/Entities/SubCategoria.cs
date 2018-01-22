using System.Collections.Generic;

namespace Cadastro.Domain.Entities
{
    public class SubCategoria
    {
        public SubCategoria()
        {
            this.SubCategoriaCampos = new List<SubCategoriaCampo>();
        }
        public int IdSubCategoria { get; set; }
        public string Descricao { get; set; }
        public string Slug { get; set; }

        public int IdCategoria { get; set; }
        public virtual Categoria Categoria { get; set; }

        public virtual ICollection<SubCategoriaCampo> SubCategoriaCampos { get; set; }


    }
}
