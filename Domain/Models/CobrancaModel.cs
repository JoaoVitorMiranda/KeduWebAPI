using System;
using static Domain.Enumerados;

namespace Domain.Models
{
    [Serializable]
    public class CobrancaModel : Pagination
    {
        public decimal Valor { get; set; }

        public DateTime DataVencimento { get; set; }

        public MetodoPagamento MetodoPagamento { get; set; } //1- BOLETO 2- PIX

        public StatusCobranca Status { get; set; } //1- EMITIDA 2 - PAGA 3 - CANCELADA - 4 - VENCIDA

        public int IdPlanoPagamento { get; set; }

        public string CodigoPagamento { get; set; }

        public PlanoPagamentoModel PlanoPagamento { get; set; }
    }
}
