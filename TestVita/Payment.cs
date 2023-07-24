
namespace TestVita
{
    public class Payment
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int IncomeId { get; set; }
        public decimal PaymentAmount { get; set; }
        public string Version { get; set; }
    }
}
