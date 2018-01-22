
using System.ComponentModel.DataAnnotations;

namespace Cadastro.Admin.Models
{
    public class Categoria
    {
        public Categoria()
        {

        }
        public int IdCategoria { get; set; }
        [Required(ErrorMessage = "Preencha o campo Descrição", AllowEmptyStrings = false)]
        public string Descricao { get; set; }
        [Required(ErrorMessage = "Preencha o campo Slug", AllowEmptyStrings = false)]
        public string Slug { get; set; }

    }
}