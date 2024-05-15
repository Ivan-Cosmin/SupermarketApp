using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheApp.Models.EntityLayer;

namespace TheApp.Models.DataAccessLayer
{
    internal class ProductStockDAL
    {
        internal static bool VerifyExistentStock(ProductStock stock)
        {
            using (SqlConnection con = DALHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("VerifyExistentStock", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ID", stock.Id);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    return true;
                }
                return false;
            }
        }

        internal void AddStock(ProductStock stock)
        {
            using (SqlConnection con = DALHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("AddProductStock", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Barcode", stock.Product.Barcode);
                cmd.Parameters.AddWithValue("@Quantity", stock.Quantity);
                cmd.Parameters.AddWithValue("@UnitOfMeasure", stock.UnitOfMeasure);
                cmd.Parameters.AddWithValue("@SupplyDate", stock.SupplyDate);
                cmd.Parameters.AddWithValue("@ExpiryDate", stock.ExpiryDate);
                cmd.Parameters.AddWithValue("@PurchasePrice", stock.PurchasePrice);
                cmd.Parameters.AddWithValue("@SellingPrice", stock.SellingPrice);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        internal void DeleteStock(ProductStock stock)
        {
            throw new NotImplementedException();
        }

        internal ObservableCollection<Product> GetProductsList()
        {
            using (SqlConnection con = DALHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("GetAllProducts", con);
                ObservableCollection<Product> result = new ObservableCollection<Product>();
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    result.Add(
                        new Product()
                        {
                            Barcode = reader["Barcode"].ToString(),
                            Name = reader["ProductName"].ToString(),
                            Category = reader["CategoryName"].ToString(),
                            Manufacturer = reader["ManufacturerName"].ToString(),
                        }
                    );
                }
                reader.Close();
                return result;
            }
        }

        internal ObservableCollection<ProductStock> GetProductStockList()
        {
            using (SqlConnection con = DALHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("GetAllProductStocks", con);
                ObservableCollection<ProductStock> result = new ObservableCollection<ProductStock>();
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    result.Add(
                              new ProductStock()
                                               {
                            Id = Convert.ToInt32(reader["ID"]),
                            Product = new Product()
                            {
                                Barcode = reader["Barcode"].ToString(),
                                Name = reader["ProductName"].ToString(),
                                Category = reader["CategoryName"].ToString(),
                                Manufacturer = reader["ManufacturerName"].ToString(),
                            },
                            Quantity = Convert.ToInt32(reader["Quantity"]),
                            UnitOfMeasure = reader["UnitOfMeasure"].ToString(),
                            SupplyDate = Convert.ToDateTime(reader["SupplyDate"]),
                            ExpiryDate = Convert.ToDateTime(reader["ExpiryDate"]),
                            PurchasePrice = Convert.ToDecimal(reader["PurchasePrice"]),
                            SellingPrice = Convert.ToDecimal(reader["SellingPrice"]),
                        }
                                                                  );
                }
                reader.Close();
                return result;
            }
        }

        internal void ModifyStock(ProductStock stock)
        {
            throw new NotImplementedException();
        }
    }
}
