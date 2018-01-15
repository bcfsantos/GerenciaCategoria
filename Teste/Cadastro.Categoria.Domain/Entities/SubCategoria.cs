using System.Collections.Generic;

namespace Cadastro.Domain.Entities
{
    public class SubCategoria
    {
        public SubCategoria()
        {
            this.Campos = new List<Campo>();
            this.Categoria = new Categoria();
        }
        public int IdSubCategoria { get; set; }
        public string Descricao { get; set; }
        public string Slug { get; set; }

        public int IdCategoria { get; set; }
        public virtual Categoria Categoria { get; set; }

        public virtual ICollection<Campo> Campos { get; set; }


    }
}
