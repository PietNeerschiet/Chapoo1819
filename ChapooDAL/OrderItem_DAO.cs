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

<<<<<<< HEAD
=======
        public void Db_Create_OrderItem(int orderID, OrderItem item) {
            string query = "INSERT INTO OrderItem(Order_ID, MenuItem_ID, Quantity, Comment, [Time], [Status], Served) VALUES (@OrderID, @MenuItemID, @Quantity, @Comment, @Time, @Status, @Served)";
            SqlParameter[] sqlParameters = new SqlParameter[7];
            sqlParameters[0] = (new SqlParameter("@OrderID", orderID));
            sqlParameters[1] = (new SqlParameter("@MenuItemID", item.MenuProduct.MenuItemCode));
            sqlParameters[2] = (new SqlParameter("@Quantity", item.Quantity));
            if (item.Comment == null) {
                sqlParameters[3] = (new SqlParameter("@Comment", DBNull.Value));
            } else {
                sqlParameters[3] = (new SqlParameter("@Comment", item.Comment));
            }
            sqlParameters[4] = (new SqlParameter("@Time", DateTime.Now));
            sqlParameters[5] = (new SqlParameter("@Status", false));
            sqlParameters[6] = (new SqlParameter("@Served", false));

            ExecuteEditQuery(query, sqlParameters);
        }

        public List<OrderItem> Db_get_OrderItems(int tableNumber) {
            string query = "SELECT m.OrderItem_ID, m.Quantity, m.Comment, m.MenuItem_ID, p.[Name] FROM OrderItem m JOIN [Order] o ON m.Order_ID = o.Order_ID JOIN MenuItem p ON m.MenuItem_ID = p.MenuItem_ID WHERE o.Table_ID = @TableID AND o.Total_Paid IS NULL";
            SqlParameter[] sqlParameters = new SqlParameter[1];
            sqlParameters[0] = (new SqlParameter("@TableID", tableNumber));

            DataTable dataTable = ExecuteSelectQuery(query, sqlParameters);

            List<OrderItem> orderItems = new List<OrderItem>();

            foreach (DataRow dr in dataTable.Rows) {
                OrderItem item = new OrderItem();

                item.OrderItemID = (int)(dr["OrderItem_ID"]);
                item.Quantity = (int)(dr["Quantity"]);
                if (dr.IsNull("Comment")) {
                    item.Comment = null;
                } else {
                    item.Comment = (String)(dr["Comment"]);
                }

                MenuProduct product = new MenuProduct();
                product.MenuItemCode = (int)(dr["MenuItem_ID"]);
                product.Name = (String)(dr["Name"]);

                item.MenuProduct = product;
                orderItems.Add(item);
            }

            return orderItems;
        }

        public void Db_Delete_Item(OrderItem item) {
            string query = "DELETE FROM OrderItem WHERE OrderItem_ID = @OrderItemID";
            SqlParameter[] sqlParameters = new SqlParameter[1];
            sqlParameters[0] = (new SqlParameter("@OrderItemID", item.OrderItemID));
            ExecuteEditQuery(query, sqlParameters);
        }

        public void Db_Change_Quantity(OrderItem item) {
            string query = "UPDATE OrderItem SET Quantity = @Quantity WHERE OrderItem_ID = @OrderItemID";
            SqlParameter[] sqlParameters = new SqlParameter[2];
            sqlParameters[0] = (new SqlParameter("@Quantity", item.Quantity));
            sqlParameters[1] = (new SqlParameter("@OrderItemID", item.OrderItemID));
            ExecuteEditQuery(query, sqlParameters);
        }
>>>>>>> dadc583cba119b0cd0c27740dac0dd6996f08845
    }
}
