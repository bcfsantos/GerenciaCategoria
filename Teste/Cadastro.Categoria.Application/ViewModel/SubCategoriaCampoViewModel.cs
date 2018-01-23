using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cadastro.Application.ViewModel
{
    public class SubCategoriaCampoViewModel
    {
        public int IdSubCategoria { get; set; }
        public int IdCampo { get; set; }
        public int Ordem { get; set; }
        public virtual CampoViewModel Campo { get; set; }
        public virtual SubCategoriaViewModel SubCategoria { get; set; }
    }
}
