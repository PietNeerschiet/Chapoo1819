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
            string query = "SELECT oi.OrderItem_ID, oi.Quantity, oi.Comment, oi.Status, oi.MenuItem_ID, oi.Time FROM OrderItem oi JOIN MenuItem mi ON oi.MenuItem_ID = mi.MenuItem_ID WHERE Order_ID = @OrderID AND Category LIKE '%gerecht%'";
            SqlParameter[] sqlParameters = new SqlParameter[1];
            sqlParameters[0] = (new SqlParameter("@OrderID", orderID));
            return ReadTables(ExecuteSelectQuery(query, sqlParameters));
        }
        // Requests orderitem drink data from the database
        public List<OrderItem> Db_Get_DrinkItems(int orderID)
        {
            string query = "SELECT oi.OrderItem_ID, oi.Quantity, oi.Comment, oi.Status, oi.MenuItem_ID, oi.Time FROM OrderItem oi JOIN MenuItem mi ON oi.MenuItem_ID = mi.MenuItem_ID WHERE Order_ID = @OrderID AND Category LIKE '%Alcoholi%'";
            SqlParameter[] sqlParameters = new SqlParameter[1];
            sqlParameters[0] = (new SqlParameter("@OrderID", orderID));
            return ReadTables(ExecuteSelectQuery(query, sqlParameters));
        }
        // Changes the status of an orderitem
        public void Db_Edit_OrderItemStatus(bool newStatus, int orderitemID)
        {
            string query = "UPDATE ORDERITEM SET Status = @newStatus WHERE OrderItem_ID = @OrderItemID";
            SqlParameter[] sqlParameters = new SqlParameter[2];
            sqlParameters[0] = (new SqlParameter("@newStatus", newStatus));
            sqlParameters[1] = (new SqlParameter("@OrderItemID", orderitemID));
            ExecuteEditQuery(query, sqlParameters);
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
