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
            string query = "SELECT Order_ID, Total_Price, Comment, Table_ID, Employee_ID FROM [Order] WHERE Order_Date IS NULL";
            SqlParameter[] sqlParameters = new SqlParameter[0];
            return ReadTablesKitchen(ExecuteSelectQuery(query, sqlParameters));
        }
        public List<Order> Db_Get_OpenBarOrders()
        {
            string query = "SELECT Order_ID, Total_Price, Comment, Table_ID, Employee_ID FROM [Order] WHERE Order_Date IS NULL";
            SqlParameter[] sqlParameters = new SqlParameter[0];
            return ReadTablesBar(ExecuteSelectQuery(query, sqlParameters));
        }
        public List<Order> Db_Get_ClosedKitchenOrders()
        {
            string query = "SELECT Order_ID, Total_Price, Comment, Table_ID, Employee_ID FROM [Order] WHERE Order_Date IS NOT NULL";
            SqlParameter[] sqlParameters = new SqlParameter[0];
            return ReadTablesKitchen(ExecuteSelectQuery(query, sqlParameters));
        }
        public List<Order> Db_Get_ClosedBarOrders()
        {
            string query = "SELECT Order_ID, Total_Price, Comment, Table_ID, Employee_ID FROM [Order] WHERE Order_Date IS NOT NULL";
            SqlParameter[] sqlParameters = new SqlParameter[0];
            return ReadTablesBar(ExecuteSelectQuery(query, sqlParameters));
        }
        private List<Order> ReadTablesKitchen(DataTable dataTable)
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
        private List<Order> ReadTablesBar(DataTable dataTable)
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
                    OrderItems = orderitemDAO.Db_Get_DrinkItems((int)dr["Order_ID"])
                };
                orders.Add(request);
            }
            return orders;
        }
        private Order ReadTableRow(DataTable dataTable)
        {
            OrderItem_DAO orderitemDAO = new OrderItem_DAO();
            Table_DAO tableDAO = new Table_DAO();
            Employee_DAO employeeDAO = new Employee_DAO();
            Order order = new Order();

            foreach (DataRow dr in dataTable.Rows)
            {
                order = new Order()
                {
                    OrderID = (int)dr["Order_ID"],
                    TotalPrice = (double)dr["Total_Price"],
                    Comment = (String)(dr["Comment"].ToString()),
                    Table = tableDAO.Db_Get_Table((int)dr["Table_ID"]),
                    Employee = employeeDAO.Db_Get_Employee((int)dr["Employee_ID"]),
                    OrderItems = orderitemDAO.Db_Get_FoodItems((int)dr["Order_ID"])
                };
            }
            return order;
        }
    }
}