
namespace App.Models
{
    public class ProductOnReceipt
    {
        public int ReceiptID { get; set; }
        public string Barcode { get; set; }
        public int Quantity { get; set; }
        public decimal Subtotal { get; set; }
    }
}
