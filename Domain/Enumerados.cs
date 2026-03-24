namespace Domain
{
    public class Enumerados
    {
        public enum CentroDeCusto
        {
            MATRICULA = 1,
            MENSALIDADE = 2,
            MATERIAL = 3
        }

        public enum StatusCobranca
        {
            EMITIDA = 1,
            PAGA = 2,
            CANCELADA = 3,
            VENCIDA = 4
        }

        public enum MetodoPagamento
        {
            BOLETO = 1,
            PIX = 2
        }
    }
}
