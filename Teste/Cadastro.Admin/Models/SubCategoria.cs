using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cadastro.Admin.Models
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