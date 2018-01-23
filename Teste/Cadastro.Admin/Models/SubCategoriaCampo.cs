using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cadastro.Admin.Models
{
    public class SubCategoriaCampo
    {
        public int IdSubCategoria { get; set; }
        public int IdCampo { get; set; }
        public int Ordem { get; set; }
        public virtual Campo Campo { get; set; }
        public virtual SubCategoria SubCategoria { get; set; }
    }
}