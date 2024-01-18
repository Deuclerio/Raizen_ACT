using UPD8.Data.Domain.DTOs.Request;
using UPD8.Data.Domain.Entity;
using UPD8.Data.Domain.Filter;

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
    }
}