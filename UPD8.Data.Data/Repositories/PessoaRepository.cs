using LinqKit;
using System.Data.Entity;
using UPD8.Data.Data.Context;
using UPD8.Data.Domain.Entity;
using UPD8.Data.Domain.Filter;
using UPD8.Data.Domain.Interfaces.Repository;

namespace UPD8.Data.Data.Repositories
{
    public class PessoaRepository : BasePersistenceRepository<PessoaEntity, int>, IPessoaRepository
    {
        public PessoaRepository(UPD8Context context) : base(context) { }

        public IQueryable<PessoaEntity> GetListAsync(PessoaEntity dto)
        {
            try
            {
                var predCast = PredicateBuilder.True<PessoaEntity>();

                //if (dto.Status != null)
                //    predCast = predCast.And(x => x.Status == dto.Status);

                if (!string.IsNullOrWhiteSpace(dto.Nome))
                    predCast = predCast.And(x => x.Nome.Contains(dto.Nome));

                if (!string.IsNullOrWhiteSpace(dto.Email))
                    predCast = predCast.And(x => x.Email.Contains(dto.Email));

                if (!string.IsNullOrWhiteSpace(dto.Cep))
                    predCast = predCast.And(x => x.Cep.Contains(dto.Cep));


                return _context.PessoasEntity.Where(predCast);
            }
            catch (Exception ex)
            {

                throw ex;
            }


        }
    }
}
