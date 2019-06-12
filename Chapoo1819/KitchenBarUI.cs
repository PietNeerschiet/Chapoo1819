using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ChapooLogic;
using ChapooModel;

namespace Chapoo1819
{
    public partial class KitchenBarUI : Form
    {
        private int listviewcount = 6;
        ChapooLogic.OrderItem_Service orderitemService = new ChapooLogic.OrderItem_Service();
        ChapooLogic.Order_Service orderService = new ChapooLogic.Order_Service();
        public List<Order> orderList;
        private Employee currentUser;
        public KitchenBarUI(Employee user) /// employee
        {
           currentUser = user;
            InitializeComponent();
        }
        // Start timer & open orders 
        private void KitchenBarUI_Load(object sender, EventArgs e)
        {
            Timer MyTimer = new Timer();
            MyTimer.Interval = (60 * 1000);  // 1 mins
            MyTimer.Tick += new EventHandler(MyTimer_Tick);
            MyTimer.Start();
            AddOpenOrders();
            btn_Uncheck.Hide();
        }

        // Refresh every 10 mins
        private void MyTimer_Tick(object sender, EventArgs e)
        {
            if (orderList == orderService.Db_Get_OpenKitchenOrders() || orderList == orderService.Db_Get_OpenBarOrders())
            {
                ClearOrders();
                AddOpenOrders();
            }
            else if (orderList == orderService.Db_Get_ClosedKitchenOrders() || orderList == orderService.Db_Get_ClosedBarOrders())
            {
                ClearOrders();
                AddClosedOrders();
            }
        }
        // Open the closed orders
        private void btn_Done_Click(object sender, EventArgs e)
        {
            ClearOrders();
            AddClosedOrders();
            btn_Check.Hide();
            btn_Uncheck.Show();
        }
        // Clear the orders
        private void ClearOrders()
        {
            Label label;
            Label label2;
            Label label3;
            ListView listview;
            for (int i = 1; i <= listviewcount; i++)
            {
                label = Controls.Find($"lbl_TblNr{i}", true).OfType<Label>().FirstOrDefault();
                label.Text = "";
                label2 = Controls.Find($"lbl_OrderTime{i}", true).OfType<Label>().FirstOrDefault();
                label2.Text = "";
                listview = Controls.Find($"listViewOrderItems{i}", true).OfType<ListView>().FirstOrDefault();
                label3 = Controls.Find($"lbl_Comment{i}", true).OfType<Label>().FirstOrDefault();
                label3.Text = "";
                listview.Items.Clear();
            }
        }
        // Add open orders to form
        private void AddOpenOrders()
        {
          if (currentUser.EmployeeType == EmployeeType.Bartender)
          {
                orderList = orderService.Db_Get_OpenBarOrders();
          }
          else if (currentUser.EmployeeType == EmployeeType.Cook)
          {
              orderList = orderService.Db_Get_OpenKitchenOrders();
          }
            int ordercount = 0;
            Label label;
            Label label2;
            Label label3;
            ListView listview;

            foreach (Order order in orderList)
            {
                if (ordercount <= listviewcount)
                {
                    ++ordercount;
                    label = Controls.Find($"lbl_TblNr{ordercount}", true).OfType<Label>().FirstOrDefault();
                    label.Text = order.Table.TableID.ToString();
                    label2 = Controls.Find($"lbl_OrderTime{ordercount}", true).OfType<Label>().FirstOrDefault();
                    label2.Text = order.OrderItems[0].Time.ToString("HH:mm");
                    listview = Controls.Find($"listViewOrderItems{ordercount}", true).OfType<ListView>().FirstOrDefault();
                    label3 = Controls.Find($"lbl_Comment{ordercount}", true).OfType<Label>().FirstOrDefault();
                    foreach (OrderItem orderitem in order.OrderItems)
                    {
                        ListViewItem li = new ListViewItem(orderitem.MenuProduct.Name);
                        li.SubItems.Add(orderitem.Quantity.ToString());
                        li.BackColor = Color.Green;
                        li.ForeColor = Color.White;
                        li.Tag = orderitem;
                        if (orderitem.Comment != "")
                        {
                            label3.Text += "Voor " + orderitem.Quantity + " " + orderitem.MenuProduct.Name + ": \n" + orderitem.Comment + "\n";
                        }
                        listview.Items.Add(li);
                    }
                }
            }
        }
        // Add closed orders to form
        private void AddClosedOrders()
        {
            if (currentUser.EmployeeType == EmployeeType.Bartender)
            {
                orderList = orderService.Db_Get_ClosedBarOrders();
            }
            else if (currentUser.EmployeeType == EmployeeType.Cook)
            {
               orderList = orderService.Db_Get_ClosedKitchenOrders();
            }
            int ordercount = listviewcount;
            Label label;
            Label label2;
            Label label3;
            ListView listview;

            foreach (Order order in orderList)
            {
                if (ordercount > 0)
                {
                    label = Controls.Find($"lbl_TblNr{ordercount}", true).OfType<Label>().FirstOrDefault();
                    label.Text = order.Table.TableID.ToString();
                    label2 = Controls.Find($"lbl_OrderTime{ordercount}", true).OfType<Label>().FirstOrDefault();
                    label2.Text = order.OrderItems[0].Time.ToString("HH:mm");
                    listview = Controls.Find($"listViewOrderItems{ordercount}", true).OfType<ListView>().FirstOrDefault();
                    label3 = Controls.Find($"lbl_Comment{ordercount}", true).OfType<Label>().FirstOrDefault();
                    foreach (OrderItem orderitem in order.OrderItems)
                    {
                        ListViewItem li = new ListViewItem(orderitem.MenuProduct.Name);
                        li.SubItems.Add(orderitem.Quantity.ToString());
                        li.BackColor = Color.Red;
                        li.ForeColor = Color.White;
                        li.Tag = orderitem;
                        if (orderitem.Comment != "")
                        {
                            label3.Text += "Voor " + orderitem.Quantity + " " + orderitem.MenuProduct.Name + ": \n" + orderitem.Comment + "\n";
                        }
                        listview.Items.Add(li);
                    }
                    --ordercount;
                }
            }
           
        }
        // Open the open orders
        private void btn_Open_Click(object sender, EventArgs e)
        {
            ClearOrders();
            AddOpenOrders();
            btn_Uncheck.Hide();
            btn_Check.Show();
        }
        // Mark orderitems (and possibly order) as done
        private void btn_Check_Click(object sender, EventArgs e)
        {
            ListView listview;
            Label label;
            for (int i = 1; i <= listviewcount; i++)
            {
                listview = Controls.Find($"listViewOrderItems{i}", true).OfType<ListView>().FirstOrDefault();
                label = Controls.Find($"lbl_TblNr{i}", true).OfType<Label>().FirstOrDefault();
                foreach (ListViewItem item in listview.Items)
                {
                    if (item.Checked == true)
                    {
                        OrderItem oi = (OrderItem)item.Tag;
                        orderitemService.EditOrderItemStatus(true, oi.OrderItemID);
                    }
                }
            }
            ClearOrders();
            AddOpenOrders();
        }

        // Mark orderitems (and possibly order) as open
        private void btn_Uncheck_Click(object sender, EventArgs e)
        {
            ListView listview;
            Label label;
            for (int i = 1; i <= listviewcount; i++)
            {
                listview = Controls.Find($"listViewOrderItems{i}", true).OfType<ListView>().FirstOrDefault();
                label = Controls.Find($"lbl_TblNr{i}", true).OfType<Label>().FirstOrDefault();
                foreach (ListViewItem item in listview.Items)
                {
                    if (item.Checked == true)
                    {
                        OrderItem oi = (OrderItem)item.Tag;
                        orderitemService.EditOrderItemStatus(false, oi.OrderItemID);
                    }
                }
            }
            ClearOrders();
            AddClosedOrders();
        }
    }
}
