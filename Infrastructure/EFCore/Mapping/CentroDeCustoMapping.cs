using Infrastructure.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.EFCore.Mapping
{
    public class CentroDeCustoMapping : IEntityTypeConfiguration<CentroDeCusto>
    {
        public void Configure(EntityTypeBuilder<CentroDeCusto> builder)
        {
            builder.ToTable("centrodecusto");
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Id)
                   .HasColumnName("id");

            builder.Property(x => x.Nome)
                   .HasColumnName("nome")
                   .IsRequired()
                   .HasMaxLength(120);
        }
    }
}
