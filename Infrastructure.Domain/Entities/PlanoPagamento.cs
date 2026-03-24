using Infrastructure.Domain.Entities.Interfaces.Standard;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Infrastructure.Domain.Entities
{
    public class PlanoPagamento : IIdentityEntity
    {
        public PlanoPagamento()
        {
            Cobranca = new HashSet<Cobranca>();
        }

        [Column("id")]
        public int Id { get; set; }

        [Column("id_responsavel_financeiro")]
        public int IdResponsavelFinanceiro { get; set; }

        [Column("id_centro_de_custo")]
        public int IdCentroDeCusto { get; set; }

        [Column("valor_total_plano")]
        public decimal ValorTotalPlano { get; set; }

        public virtual ResponsavelFinanceiro ResponsavelFinanceiro { get; set; }
        public virtual CentroDeCusto CentroDeCusto { get; set; }
        public virtual ICollection<Cobranca> Cobranca { get; set; }
    }
}
