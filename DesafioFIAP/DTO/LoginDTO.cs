using System.ComponentModel.DataAnnotations;

namespace DesafioFIAP.DTO
{
    public class LoginDTO
    {
        [Required]
        [EmailAddress(ErrorMessage = "E-mail inválido")]
        public string Email { get; set; }

        [Required]
        public string Senha { get; set; }
    }
}
