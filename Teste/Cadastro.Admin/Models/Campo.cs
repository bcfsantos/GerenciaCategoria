using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cadastro.Admin.Models
{
    public class Campo
    {
        public int IdCampo { get; set; }
        public string Descricao { get; set; }
        public int IdTipo { get; set; }
        public string Lista { get; set; }
    }
}