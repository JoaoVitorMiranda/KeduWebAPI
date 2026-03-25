using System;

namespace Domain.Models
{
    [Serializable]
    public class ValorTotalPagamentoModel
    {
        public int IdPlanoPagamento { get; set; }

        public decimal ValorTotalPagamento { get; set; }
    }
}
