namespace DesafioFIAP.DTO
{
    public class AlunosMatriculadosDTO
    {
        public int AlunoId { get; set; }
        public string NomeAluno { get; set; }
        public string Email { get; set; }
        public string Cpf { get; set; }

        public int TurmaId { get; set; }
        public string NomeTurma { get; set; }
        public string DescricaoTurma { get; set; }
    }
}
