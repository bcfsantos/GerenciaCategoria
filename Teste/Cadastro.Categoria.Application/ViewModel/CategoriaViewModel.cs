﻿using System.Collections.Generic;

namespace Cadastro.Application.ViewModel
{
    public class CategoriaViewModel
    {
        public CategoriaViewModel()
        {
        }
        public int IdCategoria { get; set; }

        public string Descricao { get; set; }
        public string Slug { get; set; }
    }
}
