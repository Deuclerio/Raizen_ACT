using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UPD8.Data.Domain.Entity;

namespace UPD8.Data.Domain.Mapping
{
    public class PessoaMap : IEntityTypeConfiguration<PessoaEntity>
    {
        public void Configure(EntityTypeBuilder<PessoaEntity> builder)
        {
            builder.ToTable("Pessoa");

            builder.HasKey(prop => prop.Id).HasName("Id");
            builder.Property(prop => prop.Id)
                   .HasColumnName("Id").ValueGeneratedOnAdd();


            builder.Property(prop => prop.Nome)
                    .HasConversion(prop => prop.ToString(), prop => prop)
                    .IsRequired()
                    .HasColumnName("Nome")
                    .HasColumnType("nvarchar(100)");

            builder.Property(prop => prop.Email)
                    .HasConversion(prop => prop.ToString(), prop => prop)
                    .IsRequired()
                    .HasColumnName("Email")
                    .HasColumnType("nvarchar(100)");

            builder.Property(prop => prop.DataNascimento)
                    .HasConversion(prop => prop, prop => prop)
                    .IsRequired()
                    .HasColumnName("Dt_Nascimento")
                    .HasColumnType("date");

            builder.Property(prop => prop.Cep)
                    .HasConversion(prop => prop.ToString(), prop => prop)
                    .IsRequired()
                    .HasColumnName("Cep")
                    .HasColumnType("nvarchar(8)");
        }
    }
}
