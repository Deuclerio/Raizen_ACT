using UPD8.Data.Domain.DTOs;
using UPD8.Data.Domain.Entity;

namespace UPD8.Data.Domain.Interfaces.Services
{
    public interface IPessoaService
    {
        Task InsertAsync(PessoaEntity dto);

        Task UpdateAsync(PessoaEntity dto);

        Task<IEnumerable<PessoaEntity>> GetListAsync(PessoaEntity filter);
        Task DeleteAsync(int id);
        Task<IEnumerable<PessoaEntity>> GetListAsync();
        Task<PessoaEntity> GetAsync(int id);
        Task<Endereco> ConsultarCep(string cep);
    }
}