using System.Collections.Generic;

namespace Cadastro.Domain.Entities
{
    public class Campo
    {
        public Campo()
        {
          // this.Tipo = new Tipo();
        }
        public int IdCampo { get; set; }
        public string Descricao { get; set; }
        public string Lista { get; set; }

        public virtual ICollection<SubCategoriaCampo> SubCategoriaCampos { get; set; }
        public int IdTipo { get; set; }
        public virtual Tipo Tipo { get; set; }
    }
}
