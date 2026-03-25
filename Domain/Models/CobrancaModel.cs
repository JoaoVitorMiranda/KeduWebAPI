using System;
using System.Text.Json.Serialization;
using static Domain.Enumerados;

namespace Domain.Models
{
    [Serializable]
    public class CobrancaModel : Pagination
    {
        public decimal Valor { get; set; }

        public DateTime DataVencimento { get; set; }

        public MetodoPagamento MetodoPagamento { get; set; } //1- BOLETO 2- PIX

        [JsonPropertyName("metodoPagamentoNome")]
        public string MetodoPagamentoNome => MetodoPagamento.ToString();

        public StatusCobranca Status { get; set; } //1- EMITIDA 2 - PAGA 3 - CANCELADA - 4 - VENCIDA

        [JsonPropertyName("statusNome")]
        public string StatusNome => Status.ToString();

        public int IdPlanoPagamento { get; set; }

        public string CodigoPagamento { get; set; }

        [JsonIgnore]
        public PlanoPagamentoModel PlanoPagamento { get; set; }
    }
}
