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
    public class Stock_DAO : Base
    {
        // Requests stock data from the database
        public List<MenuProduct> Db_Get_All_Stock()
        {
            string query = "SELECT MenuItem_ID, Name, Description, Stock, Price, Category FROM MenuItem";
            SqlParameter[] sqlParameters = new SqlParameter[0];
            return ReadTables(ExecuteSelectQuery(query, sqlParameters));
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
    }
}
