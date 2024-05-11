using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Models
{
    internal class Receipt
    {
        public int ReceiptID { get; set; }
        public DateTime Date { get; set; }
        public string Cashier { get; set; }
        public decimal TotalAmount { get; set; }
    }
}
