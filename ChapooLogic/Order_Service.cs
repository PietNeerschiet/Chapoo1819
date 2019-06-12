using ChapooDAL;
using ChapooModel;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ChapooLogic {
    public class Order_Service {
        Table_DAO table_DAO = new Table_DAO();
        MenuProduct_DAO menuItem_DAO = new MenuProduct_DAO();
        Order_DAO order_db = new Order_DAO();
        
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

                MessageBox.Show("Someren couldn't retrieve menu data from the database", "Something went wrong",
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

                MessageBox.Show("Someren couldn't retrieve menu data from the database", "Something went wrong",
                  MessageBoxButtons.OK, MessageBoxIcon.Error);

                return new List<MenuProduct>();
            }
        }
        public List<Order> Db_Get_OpenBarOrders()
        {
            try
            {
                return order_db.Db_Get_OpenBarOrders();
            }
            catch (Exception)
            {

                MessageBox.Show("Someren couldn't retrieve menu data from the database", "Something went wrong",
                  MessageBoxButtons.OK, MessageBoxIcon.Error);

                return new List<Order>();
            }
        }
        public List<Order> Db_Get_ClosedBarOrders()
        {
            try
            {
                return order_db.Db_Get_ClosedBarOrders();
            }
            catch (Exception)
            {

                MessageBox.Show("Someren couldn't retrieve menu data from the database", "Something went wrong",
                  MessageBoxButtons.OK, MessageBoxIcon.Error);

                return new List<Order>();
            }
        }
        public List<Order> Db_Get_OpenKitchenOrders()
        {
            try
            {
                return order_db.Db_Get_OpenKitchenOrders();
            }
            catch (Exception)
            {

                MessageBox.Show("Someren couldn't retrieve menu data from the database", "Something went wrong",
                  MessageBoxButtons.OK, MessageBoxIcon.Error);

                return new List<Order>();
            }
        }
        public List<Order> Db_Get_ClosedKitchenOrders()
        {
            try
            {
                return order_db.Db_Get_ClosedKitchenOrders();
            }
            catch (Exception)
            {

                MessageBox.Show("Someren couldn't retrieve menu data from the database", "Something went wrong",
                  MessageBoxButtons.OK, MessageBoxIcon.Error);

                return new List<Order>();
            }
        }
    }
}
