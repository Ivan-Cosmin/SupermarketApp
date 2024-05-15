using System;
using System.Collections.ObjectModel;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Input;
using TheApp.Models.BusinessLogicLayer;
using TheApp.Models.EntityLayer;
using TheApp.ViewModels.Commands;

namespace TheApp.ViewModels
{
    internal class ProductStockVM : BasePropertyChanged
    {
        public ProductStockVM()
        {
            try
            {
            ProductsList = productStockBLL.GetProductsList();
            ProductStocksList = productStockBLL.GetProductStocksList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            Stock = new ProductStock()
            {
                SupplyDate = DateTime.Now,
                ExpiryDate = DateTime.Now
            };
        }

        ProductStockBLL productStockBLL = new ProductStockBLL();

        public ObservableCollection<Product> ProductsList
        {
            get => productStockBLL.ProductsList;
            set => productStockBLL.ProductsList = value;
        }
        public ObservableCollection<ProductStock> ProductStocksList
        {
            get => productStockBLL.ProductStocksList;
            set => productStockBLL.ProductStocksList = value;
        }

        private ProductStock _stock;
        public ProductStock Stock
        {
            get => _stock;
            set
            {
                _stock = value;
                NotifyPropertyChanged("Stock");
            }
        }

        private ICommand addCommand;
        public ICommand AddCommand
        {
            get
            {
                if (addCommand == null)
                {
                    addCommand = new RelayCommand(AddStock);
                }
                return addCommand;
            }
        }

        private ICommand updateCommand;
        public ICommand UpdateCommand
        {
            get
            {
                if (updateCommand == null)
                {
                    updateCommand = new RelayCommand(ModifyStock);
                }
                return updateCommand;
            }
        }

        private ICommand deleteCommand;
        public ICommand DeleteCommand
        {
            get
            {
                if (deleteCommand == null)
                {
                    deleteCommand = new RelayCommand(DeleteStock);
                }
                return deleteCommand;
            }
        }

        private ICommand clearCommand;
        public ICommand ClearCommand
        {
            get
            {
                if (clearCommand == null)
                {
                    clearCommand = new RelayCommand(Clear);
                }
                return clearCommand;
            }
        }

        public void AddStock(object parameter)
        {
            try
            {
                productStockBLL.AddStock(Stock);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void ModifyStock(object parameter)
        {
            try
            {
                productStockBLL.ModifyStock(Stock);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void DeleteStock(object parameter)
        {
            try
            {
                productStockBLL.DeleteStock(Stock);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void Clear(object parameter)
        {
            Stock = null;
            Stock = new ProductStock()
            {
                SupplyDate = DateTime.Now,
                ExpiryDate = DateTime.Now
            };
        }
        
        public void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !OnlyDigitsAllowed(e.Text);
        }

        private bool OnlyDigitsAllowed(string text)
        {
            return Regex.IsMatch(text, @"^[0-9]+$");
        }
    }
}
