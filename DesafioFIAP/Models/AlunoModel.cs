using System.ComponentModel.DataAnnotations;

namespace DesafioFIAP.Models
{
    public class AlunoModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public DateTime DataNascimento { get; set; }
        public string CPF { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public DateTime DataInclusao { get; set; }
        public DateTime? DataEdicao { get; set; }
    }
}
