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
    public partial class ManagementUI : Form
    {
        public ManagementUI()
        {
            InitializeComponent();
        }
        private void ManagementUI_Load(object sender, EventArgs e)
        {
            pnl_Stock.Hide();
            pnl_Home.Show();
        }

        private void ShowPanel(string panelName)
        {
            // Hide all panels
            pnl_Home.Hide();
            pnl_Stock.Hide();

            //Show designated panel
            if (panelName == "Stock")
            {
                pnl_Stock.Show();
            }

            //else if (panelName == "....")
            //{
            //    pnl_,,,.Show();
            //}
        }
        private void AddStockToList(string listViewName)
        {
            ChapooLogic.Stock_Service stockService = new ChapooLogic.Stock_Service();
            List<MenuProduct> productList = stockService.GetStock();
            ListView listView = (ListView)(Controls.Find(listViewName, true).First());

            // Clear the previous list items
            listView.Items.Clear();

            // Fill list with product items
            foreach (ChapooModel.MenuProduct p in productList)
            {
                // Create and fill image list
                ImageList list = new ImageList();
                list.Images.Add("pic1", Image.FromFile("Imgs/pic1.png"));
                list.Images.Add("pic2", Image.FromFile("Imgs/pic2.png"));
                listView.SmallImageList = list;

                ListViewItem li = new ListViewItem(p.MenuItemCode.ToString());
                li.SubItems.Add(p.Name);
                li.SubItems.Add(p.Stock.ToString());
                li.SubItems.Add(p.Price.ToString("€ 0.00"));
                li.SubItems.Add(p.Category);


                // Show caution sign and stock status
                if (p.Stock < 10)
                {
                    li.ImageKey = "pic1";
                    li.ToolTipText = "Stock almost empty";
                }
                else
                {
                    li.ImageKey = "pic2";
                    li.ToolTipText = "Enough stock";
                }

                if (p.Category == "Alcoholic")
                {
                    li.SubItems.Add("Yes");
                }
                else
                {
                    li.SubItems.Add("No");
                }

                listView.Items.Add(li);
            }
        }

        private void btnTakeOrder_Click(object sender, EventArgs e)
        {

        }

        

        private void btnStock_Click(object sender, EventArgs e)
        {
            ShowPanel("Stock");

            AddStockToList("listViewStock");
        }
    }
}
