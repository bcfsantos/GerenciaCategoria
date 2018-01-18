namespace Cadastro.Domain.Entities
{
    public class Campo
    {
        public Campo()
        {

        }
        public int IdCampo { get; set; }
        public int Ordem { get; set; }
        public string Descricao { get; set; }
        public string Tipo { get; set; }
        public string Lista { get; set; }

        public int IdSubCategoria { get; set; }
        public virtual SubCategoria SubCategoria { get; set; }
    }
}
