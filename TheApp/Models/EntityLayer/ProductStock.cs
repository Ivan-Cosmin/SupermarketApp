using System;
using System.Configuration;

namespace TheApp.Models.EntityLayer
{
    internal class ProductStock : BasePropertyChanged
    {
        private int _id;
        private Product _product;
        private int _quantity;
        private string _unitOfMeasure;
        private DateTime _supplyDate;
        private DateTime _expiryDate;
        private decimal _purchasePrice;
        private decimal _sellingPrice;

        public int Id
        {
            get { return _id; }
            set
            {
                _id = value;
                NotifyPropertyChanged("Id");
            }
        }
        public Product Product
        {
            get { return _product; }
            set
            {
                _product = value;
                NotifyPropertyChanged("Product");
            }
        }

        public int Quantity
        {
            get { return _quantity; }
            set
            {
                _quantity = value;
                NotifyPropertyChanged("Quantity");
            }
        }

        public string UnitOfMeasure
        {
            get { return _unitOfMeasure; }
            set
            {
                _unitOfMeasure = value;
                NotifyPropertyChanged("UnitOfMeasure");
            }
        }

        public DateTime SupplyDate
        {
            get { return _supplyDate; }
            set
            {
                _supplyDate = value;
                NotifyPropertyChanged("SupplyDate");
            }
        }

        public DateTime ExpiryDate
        {
            get { return _expiryDate; }
            set
            {
                _expiryDate = value;
                NotifyPropertyChanged("ExpiryDate");
            }
        }

        public decimal PurchasePrice
        {
            get { return _purchasePrice; }
            set
            {
                _purchasePrice = value;
                CalculateSellingPrice();
                NotifyPropertyChanged("PurchasePrice");
            }
        }

        public decimal SellingPrice
        {
            get { return _sellingPrice; }
            set
            {
                _sellingPrice = value;
                NotifyPropertyChanged("SellingPrice");
            }
        }

        private void CalculateSellingPrice()
        {
            string vatValue = ConfigurationManager.AppSettings["VAT"];
            decimal vat = decimal.Parse(vatValue);

            decimal profitMargin = PurchasePrice * vat /100; 
            SellingPrice = PurchasePrice + profitMargin;
        }
    }
}
