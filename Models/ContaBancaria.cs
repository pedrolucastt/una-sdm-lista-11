namespace GlobalBankApi.Models
{
    public class ContaBancaria
    {
        public int Id { get; set; }
        public string Titular { get; set; } = string.Empty;
        public string NumeroConta { get; set; } = string.Empty;
        public decimal Saldo { get; set; }
        public string TipoConta { get; set; } = string.Empty;
    }
}