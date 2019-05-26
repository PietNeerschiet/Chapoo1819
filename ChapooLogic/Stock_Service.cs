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
    public class Stock_Service
    {
        Stock_DAO stock_db = new Stock_DAO();

        /// <summary>
        /// Get & return the list of teachers from the Teacher_DAO
        /// </summary>
        public List<MenuProduct> GetStock()
        {
            try
            {
                List<MenuProduct> menuItems = stock_db.Db_Get_All_Stock();
                return menuItems;
            }
            catch (Exception e)
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

                MessageBox.Show("Requesting list of teachers failed.", "Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return menuItem;
            }
        }
    }
}
