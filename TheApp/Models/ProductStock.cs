using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Models
{
    internal class ProductStock
    {
        public string Barcode { get; set; }
        public int Quantity { get; set; }
        public string UnitOfMeasure { get; set; }
        public DateTime SupplyDate { get; set; }
        public DateTime ExpiryDate { get; set; }
        public decimal PurchasePrice { get; set; }
        public decimal SellingPrice { get; set; }
    }
}
