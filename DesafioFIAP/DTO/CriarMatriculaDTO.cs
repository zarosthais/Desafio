using System.ComponentModel.DataAnnotations;

namespace DesafioFIAP.DTO
{
    public class CriarMatriculaDTO
    {
        [Required(ErrorMessage = "O Id do aluno é obrigatório")]
        public int AlunoId { get; set; }
        [Required(ErrorMessage = "O Id da turma é obrigatório")]
        public int TurmaId { get; set; }
    }
}
