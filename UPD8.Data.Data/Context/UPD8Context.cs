using Microsoft.EntityFrameworkCore;
using UPD8.Data.Domain.Entity;
using UPD8.Data.Domain.Mapping;

namespace UPD8.Data.Data.Context
{
    public class UPD8Context : DbContext
    {
        public UPD8Context(DbContextOptions<UPD8Context> options) : base(options) { }

        public DbSet<PessoaEntity> PessoasEntity { get; set; }

        protected override void OnModelCreating(ModelBuilder model)
        {
            base.OnModelCreating(model);
            model.Entity<PessoaEntity>(new PessoaMap().Configure);
        }   

    }
}