using Infrastructure.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.EFCore.Mapping
{
    public class PlanoPagamentoMapping : IEntityTypeConfiguration<PlanoPagamento>
    {
        public void Configure(EntityTypeBuilder<PlanoPagamento> builder)
        {
            builder.ToTable("planopagamento");
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Id).HasColumnName("id");
            builder.Property(c => c.IdResponsavelFinanceiro).HasColumnName("id_responsavel_financeiro").IsRequired();
            builder.Property(c => c.IdCentroDeCusto).HasColumnName("id_centro_de_custo").IsRequired();
            builder.Property(c => c.ValorTotalPlano).HasColumnName("valor_total_plano").IsRequired();

            builder.HasOne(x => x.ResponsavelFinanceiro)
                   .WithMany()
                   .HasForeignKey(x => x.IdResponsavelFinanceiro)
                   .IsRequired()
                   .OnDelete(DeleteBehavior.ClientNoAction);

            builder.HasOne(x => x.CentroDeCusto)
                   .WithMany()
                   .HasForeignKey(x => x.IdCentroDeCusto)
                   .IsRequired()
                   .OnDelete(DeleteBehavior.ClientNoAction);

            builder.HasMany(x => x.Cobranca)
                   .WithOne(x => x.PlanoPagamento)
                   .HasForeignKey(x => x.IdPlanoPagamento)
                   .OnDelete(DeleteBehavior.ClientCascade);
        }
    }
}
