using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace UPD8.Data.Domain.Entity
{
    public class PessoaEntity : BaseEntity<int>
    {
        [Required(ErrorMessage = "O campo Nome é obrigatório.")]
        [StringLength(100, ErrorMessage = "O campo Nome deve ter no máximo 100 caracteres.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O campo E-mail é obrigatório.")]
        [EmailAddress(ErrorMessage = "O campo E-mail não é um endereço de e-mail válido.")]
        [StringLength(100, ErrorMessage = "O campo E-mail deve ter no máximo 100 caracteres.")]
        public string? Email { get; set; }

        [DataType(DataType.Date)]
        [Required(ErrorMessage = "O campo Data Nascimento é obrigatório.")]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = false)]
        [DisplayName("Data Nascimento")]
        public DateTime? DataNascimento { get; set; }
       
        [Required(ErrorMessage = "O campo Cep é obrigatório.")]
        [StringLength(9, ErrorMessage = "O campo Cep deve ter no máximo 8 caracteres.")]
        [DataType(DataType.PostalCode)]
        [DisplayFormat(DataFormatString = "{0:#####-###}", ApplyFormatInEditMode = true)]
        public string Cep { get; set; }
    }
}
