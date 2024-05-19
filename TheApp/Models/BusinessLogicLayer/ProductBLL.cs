using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheApp.Models.DataAccessLayer;
using TheApp.Models.EntityLayer;

namespace TheApp.Models.BusinessLogicLayer
{
    internal class ProductBLL
    {
        public ObservableCollection<Product> ProductsList = new ObservableCollection<Product>();
        public ObservableCollection<Category> CategoriesList = new ObservableCollection<Category>();
        public ObservableCollection<Manufacturer> ManufacturersList = new ObservableCollection<Manufacturer>();
        ProductDAL productDAL = new ProductDAL();

        internal void AddProduct(Product product)
        {
            throw new NotImplementedException();
        }

        internal void DeleteProduct(Product selectedProduct)
        {
            throw new NotImplementedException();
        }

        internal void ActivateProduct(Product selectedProduct)
        {
            throw new NotImplementedException();
        }

        internal void ModifyProduct(Product selectedProduct, Product product)
        {
            throw new NotImplementedException();
        }

        internal void GetCategoriesList()
        {
            CategoryDAL categoryDAL = new CategoryDAL();
            CategoriesList = categoryDAL.GetCategoriesList();
        }

        internal void GetManufacturersList()
        {
            ManufacturersDAL manufacturerDAL = new ManufacturersDAL();
            ManufacturersList = manufacturerDAL.GetManufacturersList();
        }
    }
}
