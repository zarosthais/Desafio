using System.ComponentModel.DataAnnotations;

namespace DesafioFIAP.DTO
{
    public class EditarAlunoDTO
    {        
        /// <summary>Nome completo do aluno</summary>    
        /// <example>João da Silva</example>
        [Required(ErrorMessage = "O nome do aluno é obrigatório")]
        [Length(3, 100, ErrorMessage = "O nome do aluno deve ter pelo menos 3 caracteres")]
        public string Nome { get; set; }

        /// <summary>Data de nascimento no formato YYYY-MM-DD</summary>
        /// <example>2000-01-01</example>
        [Required(ErrorMessage = "A data de nascimento é obrigatória")]
        public DateTime DataNascimento { get; set; }
    }
}
