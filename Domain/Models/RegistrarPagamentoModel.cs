using System;

namespace Domain.Models
{
    [Serializable]
    public class RegistrarPagamentoModel
    {
        public int IdCobranca { get; set; }

        public decimal Valor { get; set; }

        public DateTime Data { get; set; }
    }
}
