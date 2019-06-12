using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Collections.ObjectModel;
using ChapooModel;

namespace ChapooDAL
{
    public class MenuProduct_DAO : Base
    {
        // Requests all stock data from the database
        public List<MenuProduct> Db_Get_All_Products()
        {
            string query = "SELECT MenuItem_ID, Name, Description, Stock, Price, Category FROM MenuItem";
            SqlParameter[] sqlParameters = new SqlParameter[0];
            return ReadTables(ExecuteSelectQuery(query, sqlParameters));
        }
        // Requests bar stock data from the database
        public List<MenuProduct> Db_Get_Bar_Products()
        {
            string query = "SELECT MenuItem_ID, Name, Description, Stock, Price, Category FROM MenuItem WHERE Category LIKE '%Alcoholic'";
            SqlParameter[] sqlParameters = new SqlParameter[0];
            return ReadTables(ExecuteSelectQuery(query, sqlParameters));
        }
        //Requests kitchen stock data from the database
        public List<MenuProduct> Db_Get_Kitchen_Products()
        {
            string query = "SELECT MenuItem_ID, Name, Description, Stock, Price, Category FROM MenuItem WHERE (Category LIKE '%Lunch%' OR Category LIKE '%Diner%')";
            SqlParameter[] sqlParameters = new SqlParameter[0];
            return ReadTables(ExecuteSelectQuery(query, sqlParameters));
        }
        //Requests a menu product from the database
        public MenuProduct Db_Get_MenuProduct(int menuitemID)
        {
            string query = "SELECT MenuItem_ID, Name, Description, Stock, Price, Category FROM MenuItem WHERE MenuItem_ID = @menuitemID";
            SqlParameter[] sqlParameters = new SqlParameter[1];
            sqlParameters[0] = (new SqlParameter("@menuitemID", menuitemID));
            return ReadTableRow(ExecuteSelectQuery(query, sqlParameters));
        }
        // Adds current menuproduct to a class
        private MenuProduct ReadTableRow(DataTable dataTable)
        {
            MenuProduct menuproduct = new MenuProduct();

            foreach (DataRow dr in dataTable.Rows)
            {
                menuproduct = new MenuProduct()
                {
                    MenuItemCode = (int)dr["MenuItem_ID"],
                    Name = (string)(dr["Name"].ToString()),
                    Description = (string)(dr["Description"].ToString()),
                    Stock = (int)dr["Stock"],
                    Price = (double)dr["Price"],
                    Category = (string)(dr["Category"].ToString())
                };
            }
            return menuproduct;
        }
        // Adds all of stock to a list
        private List<MenuProduct> ReadTables(DataTable dataTable)
        {
            List<MenuProduct> stock = new List<MenuProduct>();

            foreach (DataRow dr in dataTable.Rows)
            {
                MenuProduct menuItem = new MenuProduct()
                {
                    MenuItemCode = (int)dr["MenuItem_ID"],
                    Name = (String)(dr["Name"].ToString()),
                    Description = (String)(dr["Description"].ToString()),
                    Stock = (int)dr["Stock"],
                    Price = (double)dr["Price"],
                    Category = (String)(dr["Category"].ToString())
                };
                stock.Add(menuItem);
            }
            return stock;
        }
        // Edits the stock of a menu product in the database
        public void Db_Edit_Stock(int productCode, int newStock)
        {
            string query = "UPDATE MenuItem SET Stock = @newStock WHERE MenuItem_ID = @MenuItem_ID";
            SqlParameter[] sqlParameters = new SqlParameter[2];
            sqlParameters[0] = (new SqlParameter("@MenuItem_ID", productCode));
            sqlParameters[1] = (new SqlParameter("@newStock", newStock));
            ExecuteEditQuery(query, sqlParameters);
        }
        // Adds a menu product to the database
        public void Db_Add_MenuProduct(string newName, string newDescription, double newPrice, string newCategory)
        {
            int newStock = 0;
            string query = "INSERT INTO MenuItem(Name, Description, Stock, Price, Category) VALUES (@newName, @newDescription, @newStock, @newPrice, @newCategory)";
            SqlParameter[] sqlParameters = new SqlParameter[5];
            sqlParameters[0] = (new SqlParameter("@newName", newName));
            sqlParameters[1] = (new SqlParameter("@newDescription", newDescription));
            sqlParameters[2] = (new SqlParameter("@newStock", newStock));
            sqlParameters[3] = (new SqlParameter("@newPrice", newPrice));
            sqlParameters[4] = (new SqlParameter("@newCategory", newCategory));
            ExecuteEditQuery(query, sqlParameters);
        }
        // Edits a menu product in the database
        public void Db_Edit_MenuProduct(int menuItemID, string newName, string newDescription, double newPrice, string newCategory)
        {
            int newStock = 0;
            string query = "UPDATE MenuItem SET Name = @newName, Description = @newDescription, Stock = @newStock, Price = @newPrice, Category = @newCategory WHERE MenuItem_ID = @MenuItem_ID";
            SqlParameter[] sqlParameters = new SqlParameter[6];
            sqlParameters[0] = (new SqlParameter("@MenuItem_ID", menuItemID));
            sqlParameters[1] = (new SqlParameter("@newName", newName));
            sqlParameters[2] = (new SqlParameter("@newDescription", newDescription));
            sqlParameters[3] = (new SqlParameter("@newStock", newStock));
            sqlParameters[4] = (new SqlParameter("@newPrice", newPrice));
            sqlParameters[5] = (new SqlParameter("@newCategory", newCategory));
            ExecuteEditQuery(query, sqlParameters);
        }
        // Removes a menu product from the database
        public void Db_Remove_MenuProduct(int menuProductID)
        {
            string query = "DELETE FROM MenuItem WHERE MenuItem_ID = @MenuItem_ID";
            SqlParameter[] sqlParameters = new SqlParameter[1];
            sqlParameters[0] = (new SqlParameter("@MenuItem_ID", menuProductID));
            ExecuteEditQuery(query, sqlParameters);
        }
        // Gets either alcholic or non alcoholic drinks from database
        public List<MenuProduct> Db_Get_Drink_MenuProducts(string category)
        {
            List<MenuProduct> menuProducts = new List<MenuProduct>();

            string query = "SELECT m.MenuItem_ID, m.Name, m.Description, m.stock FROM MenuItem m WHERE Category = @Category;";
            SqlParameter[] sqlParameters = new SqlParameter[1];
            sqlParameters[0] = new SqlParameter("@Category", category);

            DataTable dataTable = ExecuteSelectQuery(query, sqlParameters);

            foreach (DataRow dr in dataTable.Rows)
            {
                MenuProduct product = new MenuProduct();

                product.MenuItemCode = (int)(dr["MenuItem_ID"]);
                product.Name = (String)(dr["Name"]);
                if (dr.IsNull("Description"))
                {
                    product.Description = " ";
                }
                else
                {
                    product.Description = (String)(dr["Description"]);
                }
                product.Stock = (int)(dr["stock"]);

                menuProducts.Add(product);
            }

            return menuProducts;
        }
        // Gets food products from database
        public List<MenuProduct> Db_Get_Food_MenuProducts() {
            List<MenuProduct> menuProducts = new List<MenuProduct>();

            string query = "SELECT m.MenuItem_ID, m.Name, m.Description, m.stock, m.Category FROM MenuItem m WHERE Category NOT IN ('Alcoholic', 'nonAlcoholic');";
            SqlParameter[] sqlParameters = new SqlParameter[0];

            DataTable dataTable = ExecuteSelectQuery(query, sqlParameters);

            foreach (DataRow dr in dataTable.Rows) {
                MenuProduct product = new MenuProduct();

                product.MenuItemCode = (int)(dr["MenuItem_ID"]);
                product.Name = (String)(dr["Name"]);
                product.Description = (String)(dr["Description"]);
                product.Stock = (int)(dr["stock"]);
                product.Category = (String)(dr["Category"]);

                menuProducts.Add(product);
            }

            return menuProducts;
        }
    }
}
