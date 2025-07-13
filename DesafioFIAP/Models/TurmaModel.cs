namespace DesafioFIAP.Models
{
    public class TurmaModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public DateTime DataInclusao { get; set; }
        public DateTime? DataEdicao { get; set; }
    }
}
