using System.ComponentModel.DataAnnotations;

namespace DesafioFIAP.DTO
{
    public class EditarMatriculaDTO
    {
        [Required(ErrorMessage = "O Id da turma é obrigatório")]
        public int TurmaId { get; set; }
    }
}
