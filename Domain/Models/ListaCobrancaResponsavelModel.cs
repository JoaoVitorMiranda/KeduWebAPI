using System;
using System.Text.Json.Serialization;
using static Domain.Enumerados;

namespace Domain.Models
{
    [Serializable]
    public class ListaCobrancaResponsavelModel
    {
        public int Plano { get; set; }

        public decimal Valor { get; set; }

        public DateTime DataVencimento { get; set; }

        public MetodoPagamento MetodoPagamento { get; set; } //1- BOLETO 2- PIX

        [JsonPropertyName("metodoPagamentoNome")]
        public string MetodoPagamentoNome => MetodoPagamento.ToString();

        // Backing field used so we can compute an effective status on read without persisting changes.
        private StatusCobranca _status;

        /// <summary>
        /// Stored status. When read, returns VENCIDA if not PAGA/CANCELADA and the due date is past.
        /// This change is only in-memory for this DTO (no persistence).
        /// </summary>
        public StatusCobranca Status
        {
            get
            {
                // If no due date was provided, return the stored status.
                if (DataVencimento == default)
                    return _status;

                // If already PAGA or CANCELADA, keep it. Otherwise, if overdue, present VENCIDA.
                if (_status != StatusCobranca.PAGA && _status != StatusCobranca.CANCELADA)
                {
                    if (DataVencimento < DateTime.Now)
                        return StatusCobranca.VENCIDA;
                }

                return _status;
            }
            set => _status = value;
        } //1- EMITIDA 2 - PAGA 3 - CANCELADA - 4 - VENCIDA

        [JsonPropertyName("statusNome")]
        public string StatusNome => Status.ToString();

        public string CodigoPagamento { get; set; }
    }
}
