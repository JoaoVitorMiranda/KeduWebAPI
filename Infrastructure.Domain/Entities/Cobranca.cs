using Infrastructure.Domain.Entities.Interfaces.Standard;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Infrastructure.Domain.Entities
{
    public class Cobranca : IIdentityEntity
    {
        [Column("id")]
        public int Id { get; set; }

        [Column("valor")]
        public decimal Valor { get; set; }

        [Column("data_vencimento")]
        public DateTime DataVencimento { get; set; }

        [Column("metodo_pagamento")]
        public int MetodoPagamento { get; set; } //1- BOLETO 2- PIX

        [Column("status")]
        public int Status { get; set; } //1- EMITIDA 2 - PAGA 3 - CANCELADA

        [Column("id_plano_pagamento")]
        public int IdPlanoPagamento { get; set; }

        [Column("codigo_pagamento")]
        public string CodigoPagamento { get; set; }

        public virtual PlanoPagamento PlanoPagamento { get; set; }
    }
}
