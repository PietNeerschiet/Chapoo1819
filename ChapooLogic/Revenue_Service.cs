using ChapooDAL;
using ChapooModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

namespace ChapooLogic
{
    public class Revenue_Service
    {
        Revenue_DAO revenue_db = new Revenue_DAO();

        private List<Order> ErrorHandling(Exception e)
        {
            StreamWriter writer = new StreamWriter("errorLog");
            writer.Write(e);
            writer.Close();

            List<Order> order = new List<Order>();
            Order a = new Order
            {
                Comment = "Test order 1",
                OrderID = 999
            };
            order.Add(a);
            Order b = new Order
            {
                Comment = "Test order 2",
                OrderID = 998
            };
            order.Add(b);

            MessageBox.Show("Requesting orders from database failed.", "Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return order;
        }

        public List<Order> GetAllPaidOrders()
        {
            try
            {
                List<Order> paidOrders = revenue_db.Db_Get_AllPaidOrders();
                return paidOrders;
            }
            catch (Exception e)
            {
                return ErrorHandling(e);
            }
        }
        public List<Order> GetKitchenPaidOrders()
        {
            try
            {
                List<Order> paidOrders = revenue_db.Db_Get_KitchenPaidOrders();
                return paidOrders;
            }
            catch (Exception e)
            {
                return ErrorHandling(e);
            }
        }
        public List<Order> GetBarPaidOrders()
        {
            try
            {
                List<Order> paidOrders = revenue_db.Db_Get_BarPaidOrders();
                return paidOrders;
            }
            catch (Exception e)
            {
                return ErrorHandling(e);
            }
        }
    }
}
