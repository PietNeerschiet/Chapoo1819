using ChapooDAL;
using ChapooModel;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ChapooLogic {
    public class Order_Service {
        Table_DAO table_DAO = new Table_DAO();
        MenuProduct_DAO menuItem_DAO = new MenuProduct_DAO();
        Order_DAO order_DAO = new Order_DAO();
        OrderItem_DAO orderItem_DAO = new OrderItem_DAO();

        public List<int> GetInUseTables() {
            try {
                return table_DAO.Db_Get_InUse_Table();
            } catch (Exception) {

                MessageBox.Show("Someren couldn't retrieve table data from the database", "Something went wrong",
                  MessageBoxButtons.OK, MessageBoxIcon.Error);

                return new List<int>();
            }

        }

        public List<MenuProduct> GetMenuItems(string category) {
            try {
                return menuItem_DAO.Db_Get_Drink_MenuProducts(category);

            } catch (Exception) {

                MessageBox.Show("Couldn't retrieve menu data from the database", "Something went wrong",
                  MessageBoxButtons.OK, MessageBoxIcon.Error);

                return new List<MenuProduct>();
            }
        }

        public List<MenuProduct> GetMenuItems(string category, string subCategory) {
            try {
                List<MenuProduct> allProducts = menuItem_DAO.Db_Get_Food_MenuProducts();
                List<MenuProduct> products = new List<MenuProduct>();

                foreach (MenuProduct product in allProducts) {
                    List<String> categories = new List<string>(product.Category.Split(' '));
                    if (categories.Contains(category) && categories.Contains(subCategory)) {
                        products.Add(product);
                    }
                }


                return products;
            } catch (Exception) {

                MessageBox.Show("Couldn't retrieve menu data from the database", "Something went wrong",
                  MessageBoxButtons.OK, MessageBoxIcon.Error);

                return new List<MenuProduct>();
            }
        }

        public int GetOrderId(int table, Employee employee) {
            try {
                int orderID = order_DAO.Db_Get_OrderId(table);
                if (orderID == 0) {
                    return order_DAO.Db_Make_Order(table, employee.EmployeeID);
                }

                return orderID;
            } catch (Exception) {

                MessageBox.Show("Couldn't retrieve orderId from the database", "Something went wrong",
                  MessageBoxButtons.OK, MessageBoxIcon.Error);

                return 0;
            }
        }

        public void CreateOrderItem(int OrderID, OrderItem item) {
            try {
                orderItem_DAO.Db_Create_OrderItem(OrderID, item);
            } catch (Exception) {

                MessageBox.Show("Couldn't put orderitem in the database", "Something went wrong",
                  MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public List<OrderItem> GetOrderItems(int tableNumber) {
            try {
                List<OrderItem> orderItems =  orderItem_DAO.Db_get_OrderItems(tableNumber);

                //foreach (OrderItem item in orderItems) {
                //    item.MenuProduct = menuItem_DAO.Db_Get_MenuProduct(item.MenuProduct.MenuItemCode);
                //}

                return orderItems;
            } catch (Exception e ) {

                MessageBox.Show("Couldn't retrieve orderitems from the database", "Something went wrong",
                  MessageBoxButtons.OK, MessageBoxIcon.Error);

                return new List<OrderItem>();
            }
        }

        public void ChangeOrders(List<OrderItem> list) {
            try {
                if (list.Count != 0) {
                    foreach (OrderItem item in list) {
                        if (item.Quantity == 0) {
                            orderItem_DAO.Db_Delete_Item(item);
                        } else {
                            orderItem_DAO.Db_Change_Quantity(item);
                        }
                    }
                }


            } catch (Exception) {

                MessageBox.Show("Couldn't change orderitems in the database", "Something went wrong",
                  MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void SetTableAvailability(int tableNumber, bool inUse) {
            try {
                table_DAO.Db_Set_InUse_Table(tableNumber, inUse);
            } catch (Exception) {

                MessageBox.Show("Couldn't change table data in the database", "Something went wrong",
                  MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
