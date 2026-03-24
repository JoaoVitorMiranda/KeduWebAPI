using Infrastructure.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.EFCore.Mapping
{
    public class ResponsavelFinanceiroMapping : IEntityTypeConfiguration<ResponsavelFinanceiro>
    {
        public void Configure(EntityTypeBuilder<ResponsavelFinanceiro> builder)
        {
            builder.ToTable("responsavelfinanceiro");
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Id)
                   .HasColumnName("id");

            builder.Property(x => x.NomeResponsavel)
                   .HasColumnName("nome_responsavel")
                   .IsRequired()
                   .HasMaxLength(100);

            builder.Property(x => x.DataCriacao)
                   .HasColumnName("data_criacao")
                   .IsRequired();
        }
    }
}
