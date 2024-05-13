using System;

namespace TheApp.Models.EntityLayer
{
    internal class Receipt
    {
        public int ReceiptID { get; set; }
        public DateTime Date { get; set; }
        public string Cashier { get; set; }
        public decimal TotalAmount { get; set; }
    }
}
