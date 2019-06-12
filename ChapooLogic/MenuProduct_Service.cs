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
    public class MenuProduct_Service
    {
        MenuProduct_DAO menuProduct_db = new MenuProduct_DAO();

        /// <summary>
        /// Get & return the list of teachers from the Teacher_DAO
        /// </summary>
        /// 
        // Method that handles the errors and returns Test Items //
        private List<MenuProduct> ErrorHandling(Exception e)
        {
            StreamWriter writer = new StreamWriter("errorLog");
            writer.Write(e);
            writer.Close();

            List<MenuProduct> menuItem = new List<MenuProduct>();
            MenuProduct a = new MenuProduct
            {
                Name = "Test menu item 1",
                MenuItemCode = 999
            };
            menuItem.Add(a);
            MenuProduct b = new MenuProduct
            {
                Name = "Test menu item 2",
                MenuItemCode = 998
            };
            menuItem.Add(b);

            MessageBox.Show("Requesting stock from database failed.", "Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return menuItem;
        }

        public List<MenuProduct> GetAllProducts()
        {
            try
            {
                List<MenuProduct> menuItems = menuProduct_db.Db_Get_All_Products();
                return menuItems;
            }
            catch (Exception e)
            {
                return ErrorHandling(e);
            }
        }
        public List<MenuProduct> GetBarProducts()
        {
            try
            {
                List<MenuProduct> menuItems = menuProduct_db.Db_Get_Bar_Products();
                return menuItems;
            }
            catch (Exception e)
            {
                return ErrorHandling(e);
            }
        }
        public List<MenuProduct> GetKitchenProducts()
        {
            try
            {
                List<MenuProduct> menuItems = menuProduct_db.Db_Get_Kitchen_Products();
                return menuItems;
            }
            catch (Exception e)
            {
                return ErrorHandling(e);
            }
        }

        public void EditStock(int productCode, int newStock)
        {
            try
            {
                menuProduct_db.Db_Edit_Stock(productCode, newStock);
            }
            catch (Exception e)
            {
                StreamWriter writer = new StreamWriter("errorLog");
                writer.Write(e);
                writer.Close();

                MessageBox.Show("Edititing stock failed!", "Updating Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void AddMenuProduct(string name, string description, double price, string category)
        {
            try
            {
                menuProduct_db.Db_Add_MenuProduct(name, description, price, category);
            }
            catch (Exception e)
            {
                StreamWriter writer = new StreamWriter("errorLog");
                writer.Write(e);
                writer.Close();

                MessageBox.Show("Adding menu product failed!", "Inserting Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void EditMenuProduct(int menuItemID, string name, string description, double price, string category)
        {
            try
            {
                menuProduct_db.Db_Edit_MenuProduct(menuItemID, name, description, price, category);
            }
            catch (Exception e)
            {
                StreamWriter writer = new StreamWriter("errorLog");
                writer.Write(e);
                writer.Close();

                MessageBox.Show("Editing menu product failed!", "Inserting Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void RemoveMenuProduct(int menuItemID)
        {
            try
            {
                menuProduct_db.Db_Remove_MenuProduct(menuItemID);
            }
            catch (Exception e)
            {
                StreamWriter writer = new StreamWriter("errorLog");
                writer.Write(e);
                writer.Close();

                MessageBox.Show("Removing menu product failed!", "Deleting Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
