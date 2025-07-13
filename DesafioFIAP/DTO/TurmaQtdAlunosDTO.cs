namespace DesafioFIAP.DTO
{
    public class TurmaQtdAlunosDTO
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public DateTime DataInclusao { get; set; }
        public DateTime? DataEdicao { get; set; }
        public int QuantidadeAlunos { get; set; }
    }
}
