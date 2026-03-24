using Infrastructure.Domain.Entities.Interfaces.Standard;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Infrastructure.Domain.Entities
{
    public class CentroDeCusto : IIdentityEntity
    {
        public CentroDeCusto()
        {
            PlanoPagamento = new HashSet<PlanoPagamento>();
        }

        [Column("id")]
        public int Id { get; set; }

        [Column("nome")]
        public string Nome { get; set; }

        public virtual ICollection<PlanoPagamento> PlanoPagamento { get; set; }
    }
}
