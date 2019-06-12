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
        // Requests menuproduct from the database
        public MenuProduct Db_Get_MenuProduct(int menuitemID)
        {
            string query = "SELECT MenuItem_ID, Name, Description, Stock, Price, Category FROM MenuItem WHERE MenuItem_ID = @menuitemID";
            SqlParameter[] sqlParameters = new SqlParameter[1];
            sqlParameters[0] = (new SqlParameter("@menuitemID", menuitemID));
            return ReadTables(ExecuteSelectQuery(query, sqlParameters));
        }

        // Adds current menuproduct to a class
        private MenuProduct ReadTables(DataTable dataTable)
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
    }
}
