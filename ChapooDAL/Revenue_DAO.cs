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
    public class Revenue_DAO : Base
    {
        OrderItem_DAO orderitemDAO = new OrderItem_DAO();
        Table_DAO tableDAO = new Table_DAO();
        Employee_DAO employeeDAO = new Employee_DAO();

        // Gets all paid orders from the database
        public List<Order> Db_Get_AllPaidOrders()
        {
            string query = "SELECT Order_ID, Employee_ID, Total_Price, Total_Paid, (Total_Paid - Total_Price) AS Tip, Order_Date FROM [Order] WHERE Total_Paid IS NOT NULL";
            SqlParameter[] sqlParameters = new SqlParameter[0];
            return ReadTables(ExecuteSelectQuery(query, sqlParameters));
        }
        // Gets all paid kitchen orders from the database
        public List<Order> Db_Get_KitchenPaidOrders()
        {
            string query = "SELECT o.Order_ID, o.Employee_ID, MenuItem.[Name], OrderItem.Quantity, MenuItem.Price, o.Order_Date FROM [Order] o INNER JOIN OrderItem ON o.Order_ID = OrderItem.Order_ID INNER JOIN MenuItem ON OrderItem.MenuItem_ID = MenuItem.MenuItem_ID WHERE (Category LIKE '%Lunch%' OR Category LIKE '%Diner%') AND o.Total_Paid IS NOT NULL";
            SqlParameter[] sqlParameters = new SqlParameter[0];
            return ReadTables2(ExecuteSelectQuery(query, sqlParameters));
        }
        // Gets all paid bar orders from the database
        public List<Order> Db_Get_BarPaidOrders()
        {
            string query = "SELECT o.Order_ID, o.Employee_ID, MenuItem.[Name], OrderItem.Quantity, MenuItem.Price, o.Order_Date FROM [Order] o INNER JOIN OrderItem ON o.Order_ID = OrderItem.Order_ID INNER JOIN MenuItem ON OrderItem.MenuItem_ID = MenuItem.MenuItem_ID WHERE Category LIKE '%Alcoholisch' AND o.Total_Paid IS NOT NULL";
            SqlParameter[] sqlParameters = new SqlParameter[0];
            return ReadTables2(ExecuteSelectQuery(query, sqlParameters));
        }
        private List<Order> ReadTables(DataTable dataTable)
        {
            List<Order> orders = new List<Order>();
            foreach (DataRow dr in dataTable.Rows)
            {
                Order request = new Order()
                {
                    OrderID = (int)dr["Order_ID"],
                    Employee = employeeDAO.Db_Get_Employee((int)dr["Employee_ID"]),
                    TotalPrice = (double)dr["Total_Price"],
                    TotalPaid = (double)dr["Total_Paid"],
                    Tip = (double)dr["Tip"],
                    OrderDate = (DateTime)dr["Order_Date"]
                };
                orders.Add(request);
            }
            return orders;
        }

        private List<Order> ReadTables2(DataTable dataTable)
        {
            List<Order> orders = new List<Order>();
            foreach (DataRow dr in dataTable.Rows)
            {
                Order request = new Order()
                {
                    OrderID = (int)dr["Order_ID"],
                    Employee = employeeDAO.Db_Get_Employee((int)dr["Employee_ID"]),
                    ProductName = (string)dr["Name"],
                    Quantity = (int)dr["Quantity"],
                    Price = (double)dr["Price"],
                    OrderDate = (DateTime)dr["Order_Date"]
                };
                orders.Add(request);
            }
            return orders;
        }
    }
}
