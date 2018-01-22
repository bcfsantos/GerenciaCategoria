using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cadastro.Domain.Entities
{
    public class Tipo
    {
        public Tipo()
        {
            this.Campos = new List<Campo>();
        }

        public int IdTipo { get; set; }
        public string Descricao { get; set; }

        public int IdCampo { get; set; }
        public ICollection<Campo> Campos { get; set; }
    }
}
