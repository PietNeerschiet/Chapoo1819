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
    public class OrderItem_DAO : Base
    {
        // Requests orderitem food data from the database
        public List<OrderItem> Db_Get_FoodItems(int orderID)
        {
            string query = "SELECT OrderItem_ID, Quantity, Comment, Status, MenuItem_ID, Time FROM OrderItem WHERE Order_ID = @OrderID AND MenuItem_ID < 19";
            SqlParameter[] sqlParameters = new SqlParameter[1];
            sqlParameters[0] = (new SqlParameter("@OrderID", orderID));
            return ReadTables(ExecuteSelectQuery(query, sqlParameters));
        }

        // Adds all orderitems to a list
        private List<OrderItem> ReadTables(DataTable dataTable)
        {
            MenuProduct_DAO menuproductDAO = new MenuProduct_DAO();
            List<OrderItem> requests = new List<OrderItem>();

            foreach (DataRow dr in dataTable.Rows)
            {
                OrderItem request = new OrderItem()
                {
                    OrderItemID = (int)dr["OrderItem_ID"],
                    Quantity = (int)dr["Quantity"],
                    Comment = (string)(dr["Comment"].ToString()),
                    Status = (bool)dr["Status"],
                    Time = (DateTime)dr["Time"],
                    MenuProduct = menuproductDAO.Db_Get_MenuProduct((int)dr["MenuItem_ID"])
                };
                requests.Add(request);
            }
            return requests;
        }

    }
}
