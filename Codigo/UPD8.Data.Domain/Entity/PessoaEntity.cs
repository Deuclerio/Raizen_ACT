
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace UPD8.Data.Domain.Entity
{
    public class PessoaEntity : BaseEntity<int>
    {
        [Required(ErrorMessage = "O campo Nome é obrigatório.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O campo Email é obrigatório.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "O campo Data Nascimento é obrigatório.")]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        [DisplayName("Data Nascimento")]
        public DateTime DataNascimento { get; set; }
       
        [Required(ErrorMessage = "O campo Cep é obrigatório.")]
        public string Cep { get; set; }
    }
}
