using System;

namespace TestVita
{
    public class Order
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public decimal Amount { get; set; }
        public decimal PaymentAmount { get; set; }
        public string Version { get; set; }
    }
}
