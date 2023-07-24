using System;

namespace TestVita
{
    public class Income
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public decimal Amount { get; set; }
        public decimal Balance { get; set; }
        public string Version { get; set; }
    }
}
