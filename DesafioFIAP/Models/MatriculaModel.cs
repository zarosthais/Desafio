namespace DesafioFIAP.Models
{
    public class MatriculaModel
    {
        public int Id { get; set; }
        public int AlunoId { get; set; }
        public int TurmaId { get; set; }
        public DateTime DataInclusao { get; set; }
        public DateTime? DataEdicao { get; set; }
    }
}
