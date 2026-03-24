using Infrastructure.Domain.Entities.Interfaces.Standard;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Infrastructure.Domain.Entities
{
    public class ResponsavelFinanceiro : IIdentityEntity
    {
        public ResponsavelFinanceiro()
        {
            PlanoPagamento = new HashSet<PlanoPagamento>();
        }

        [Column("id")]
        public int Id { get; set; }

        [Column("nome_responsavel")]
        public string NomeResponsavel { get; set; }

        [Column("data_criacao")]
        public DateTime DataCriacao { get; set; }

        public virtual ICollection<PlanoPagamento> PlanoPagamento { get; set; }
    }
}
