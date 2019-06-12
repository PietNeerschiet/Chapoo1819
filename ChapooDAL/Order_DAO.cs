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
    public class Order_DAO : Base
    {
        public List<Order> Db_Get_OpenKitchenOrders()
        {
            string query = "SELECT Order_ID, Total_Price, Comment, Table_ID, Employee_ID FROM [Order] WHERE Total_Paid IS NULL";
            SqlParameter[] sqlParameters = new SqlParameter[0];
            return ReadTables(ExecuteSelectQuery(query, sqlParameters));
        }

        private List<Order> ReadTables(DataTable dataTable)
        {
            OrderItem_DAO orderitemDAO = new OrderItem_DAO();
            Table_DAO tableDAO = new Table_DAO();
            Employee_DAO employeeDAO = new Employee_DAO();
            List<Order> orders = new List<Order>();

            foreach (DataRow dr in dataTable.Rows)
            {
                Order request = new Order()
                {
                    OrderID = (int)dr["Order_ID"],
                    TotalPrice = (double)dr["Total_Price"],
                    Comment = (String)(dr["Comment"].ToString()),
                    Table = tableDAO.Db_Get_Table((int)dr["Table_ID"]),
                    Employee = employeeDAO.Db_Get_Employee((int)dr["Employee_ID"]),
                    OrderItems = orderitemDAO.Db_Get_FoodItems((int)dr["Order_ID"])
                };
                orders.Add(request);
            }
            return orders;
        }

        public int Db_Get_OrderId(int tableID) {
            string query = "SELECT Order_ID FROM [Order] WHERE Total_Paid IS NULL AND Table_ID = @TableID";
            SqlParameter[] sqlParameters = new SqlParameter[1];
            sqlParameters[0] = (new SqlParameter("@TableID", tableID));

            DataTable datatable = ExecuteSelectQuery(query, sqlParameters);

            if (datatable.Rows.Count < 1) {
                return 0;
            }

            return (int)datatable.Rows[0]["Order_ID"];
        }

        public int Db_Make_Order(int tableID, int employeeID) {
            string query = "INSERT INTO [Order] VALUES (@Total_Price, @Comment, @Table_ID, @Employee_ID, @Total_Paid, @Order_Date)";
            SqlParameter[] sqlParameters = new SqlParameter[6];
            sqlParameters[0] = (new SqlParameter("@Total_Price", DBNull.Value));
            sqlParameters[1] = (new SqlParameter("@Comment", DBNull.Value));
            sqlParameters[2] = (new SqlParameter("@Table_ID", tableID));
            sqlParameters[3] = (new SqlParameter("@Employee_ID", employeeID));
            sqlParameters[4] = (new SqlParameter("@Total_Paid", DBNull.Value));
            sqlParameters[5] = (new SqlParameter("@Order_Date", DBNull.Value));

            ExecuteEditQuery(query, sqlParameters);

            return Db_Get_OrderId(tableID);
        }
    }
}