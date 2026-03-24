using Infrastructure.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.EFCore.Mapping
{
    public class CobrancaMapping : IEntityTypeConfiguration<Cobranca>
    {
        public void Configure(EntityTypeBuilder<Cobranca> builder)
        {
            builder.ToTable("cobranca");
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Id)
                   .HasColumnName("id");

            builder.Property(c => c.Valor)
                   .HasColumnName("valor")
                   .IsRequired();

            builder.Property(c => c.DataVencimento)
                   .HasColumnName("data_vencimento")
                   .IsRequired();

            builder.Property(c => c.MetodoPagamento)
                   .HasColumnName("metodo_pagamento")
                   .IsRequired();

            builder.Property(c => c.Status)
                   .HasColumnName("status")
                   .IsRequired();

            builder.Property(c => c.IdPlanoPagamento)
                   .HasColumnName("id_plano_pagamento")
                   .IsRequired();

            builder.Property(c => c.CodigoPagamento)
                   .HasColumnName("codigo_pagamento")
                   .HasMaxLength(250);

            builder.HasOne(x => x.PlanoPagamento)
                   .WithMany(x => x.Cobranca)
                   .HasForeignKey(x => x.IdPlanoPagamento)
                   .OnDelete(DeleteBehavior.ClientCascade);
        }
    }
}
