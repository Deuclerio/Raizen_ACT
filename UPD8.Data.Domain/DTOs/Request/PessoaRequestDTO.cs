
namespace UPD8.Data.Domain.DTOs.Request
{
    public class PessoaRequestDTO
    {
        public string Nome { get; set; }
        public string Email { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Cep { get; set; }
    }
}
