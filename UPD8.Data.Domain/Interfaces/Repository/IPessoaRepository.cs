using UPD8.Data.Domain.Entity;
using UPD8.Data.Domain.Persistence;

namespace UPD8.Data.Domain.Interfaces.Repository
{
    public interface IPessoaRepository : IBasePersistenceRepository<PessoaEntity, int>
    {
        IQueryable<PessoaEntity> GetListAsync(PessoaEntity dto);
        Task<IEnumerable<PessoaEntity>> GetListAsync();
    }
}
