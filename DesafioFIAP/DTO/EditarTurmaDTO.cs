using System.ComponentModel.DataAnnotations;

namespace DesafioFIAP.DTO
{
    public class EditarTurmaDTO
    {
        [Length(3, 100, ErrorMessage = "O nome da turma deve ter pelo menos 3 caracteres")]
        public string Nome { get; set; }
        public string Descricao { get; set; }
    }
}
