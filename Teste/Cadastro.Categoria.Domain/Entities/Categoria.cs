using System.Collections.Generic;

namespace Cadastro.Domain.Entities
{
    public class Categoria
    {
        public Categoria()
        {
            this.SubCategoria = new List<SubCategoria>();
        }
        public int IdCategoria { get; set; }
        public string Descricao { get; set; }
        public string Slug { get; set; }

        public virtual ICollection<SubCategoria> SubCategoria { get; set; }
    }
}
