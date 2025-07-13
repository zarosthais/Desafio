using System.ComponentModel.DataAnnotations;

namespace DesafioFIAP.DTO
{
    public class CriarAlunoDTO
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

        /// <summary>CPF do aluno, apenas números</summary>
        /// <example>12345678900</example>
        [Required(ErrorMessage = "O CPF é obrigatório")]
        [Length(11, 11, ErrorMessage = "O CPF do aluno deve conter 11 caracteres")]
        public string CPF { get; set; }

        /// <summary>E-mail do aluno</summary>
        /// <example>joao@email.com</example>
        [Required(ErrorMessage = "O E-mail é obrigatório")]
        [EmailAddress(ErrorMessage = "E-mail inválido")]
        public string Email { get; set; }

        [Required(ErrorMessage = "A senha é obrigatória")]
        [MinLength(8, ErrorMessage = "A senha deve ter no mínimo 8 caracteres")]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&.\-_#]).{8,}$",
        ErrorMessage = "A senha deve conter letras maiúsculas, minúsculas, números e caracteres especiais")]
        public string Senha { get; set; }
    }
}
