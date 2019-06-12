using ChapooLogic;
using ChapooModel;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Microsoft.VisualBasic;

namespace Chapoo1819 {
    public partial class OrderUI : Form {

        private List<Button> tableButtons = new List<Button>();
        private Order_Service order_Service;
        private List<OrderItem> orderItems = new List<OrderItem>();
        private List<MenuProduct> products = new List<MenuProduct>();
        private Employee employee;

        private int TableNumber { get; set; }
        private string Comment { get; set; }

        public OrderUI(/*int table,*/ Employee employee) {
            InitializeComponent();

            this.order_Service = new Order_Service();
            this.TableNumber = 0;
            this.employee = employee;

            FillTableList();

            ShowPanel("menu");
        }

        private void HideAllPanels() {
            pnl_TableMenu.Hide();
            pnl_Menu.Hide();
            pnl_TakeOrder.Hide();
            pnl_OverviewOrder.Hide();
            pnl_ViewOrders.Hide();
        }

        private void ShowPanel(string panelName) {
            // Hide all panels
            HideAllPanels();

            //Show designated panel
            if (panelName == "menu") {
                SetTableColors();
                pnl_Menu.Show();
            } else if (panelName == "tableMenu") {
                pnl_TableMenu.Show();
                lbl_TableNumber.Text = "Tafel: " + TableNumber;

                if (tableButtons[TableNumber - 1].BackColor == Color.Red) {
                    btn_TableInUse.Text = "Zet tafel niet bezet";
                } else {
                    btn_TableInUse.Text = "Zet tafel bezet";
                }

            } else if (panelName == "takeOrder") {
                pnl_TakeOrder.Show();

                ResetButtons(true);

                cb_Quantity.SelectedIndex = 0;
                OverviewButtomText();

            } else if (panelName == "OverviewOrder") {
                pnl_OverviewOrder.Show();

                lbl_OrderOverQuantity.Hide();
                btn_AddQuantity.Hide();
                btn_RemoveQuantity.Hide();
                btn_RemoveItem.Hide();

                listViewOrderOverview.Items.Clear();

                foreach (OrderItem item in orderItems) {
                    ListViewItem lvItem = new ListViewItem(new string[] { item.MenuProduct.Name, item.Quantity.ToString(), item.Comment });
                    lvItem.Tag = item;
                    listViewOrderOverview.Items.Add(lvItem);
                }
            } else if (panelName == "ViewOrders") {
                pnl_ViewOrders.Show();

                lbl_OrdersQuantity.Hide();
                btn_OrdersDelete.Hide();
                btn_OrdersMinus.Hide();
                btn_OrdersPlus.Hide();

                btn_OrdersBackCancel.Text = "Terug";
                btn_OrdersChangeConfirm.Text = "Wijzig";

                orderItems = order_Service.GetOrderItems(TableNumber);

                listViewViewOrders.Items.Clear();

                ViewOrders viewOrders = ViewOrders.MakeInstances(orderItems);

                foreach (OrderItem item in viewOrders.GetSortedItems()) {
                    ListViewItem lvItem = new ListViewItem(new string[] { item.MenuProduct.Name, item.Quantity.ToString(), item.Comment });
                    lvItem.Tag = item;
                    listViewViewOrders.Items.Add(lvItem);
                }
            }

            //else if (panelName == "....")
            //{
            //    pnl_,,,.Show();
            //}
        }

        private void btn_LogUit_Click(object sender, EventArgs e) {
            OrderUI orderUI = this;
            orderUI.Dispose();
        }

        private void btn_Back_Click(object sender, EventArgs e) {
            TableNumber = 0;
            ShowPanel("menu");
        }

        #region Table buttons
        private void SetTableColors() {
            foreach (Button button in tableButtons) {
                button.BackColor = Color.Green;
            }

            foreach (int tafel in order_Service.GetInUseTables()) {
                tableButtons[tafel - 1].BackColor = Color.Red;
            }
        }

        private void btn_Tafel1_Click(object sender, EventArgs e) {
            TableNumber = 1;
            ShowPanel("tableMenu");
        }

        private void btn_Tafel2_Click(object sender, EventArgs e) {
            TableNumber = 2;
            ShowPanel("tableMenu");
        }

        private void btn_Tafel3_Click(object sender, EventArgs e) {
            TableNumber = 3;
            ShowPanel("tableMenu");
        }

        private void btn_Tafel4_Click(object sender, EventArgs e) {
            TableNumber = 4;
            ShowPanel("tableMenu");
        }

        private void btn_Tafel5_Click(object sender, EventArgs e) {
            TableNumber = 5;
            ShowPanel("tableMenu");
        }

        private void btn_Tafel6_Click(object sender, EventArgs e) {
            TableNumber = 6;
            ShowPanel("tableMenu");
        }

        private void btn_Tafel7_Click(object sender, EventArgs e) {
            TableNumber = 7;
            ShowPanel("tableMenu");
        }

        private void btn_Tafel8_Click(object sender, EventArgs e) {
            TableNumber = 8;
            ShowPanel("tableMenu");
        }

        private void btn_Tafel9_Click(object sender, EventArgs e) {
            TableNumber = 9;
            ShowPanel("tableMenu");
        }

        private void btn_Tafel10_Click(object sender, EventArgs e) {
            TableNumber = 10;
            ShowPanel("tableMenu");
        }

        private void FillTableList() {
            tableButtons.Add(btn_Tafel1);
            tableButtons.Add(btn_Tafel2);
            tableButtons.Add(btn_Tafel3);
            tableButtons.Add(btn_Tafel4);
            tableButtons.Add(btn_Tafel5);
            tableButtons.Add(btn_Tafel6);
            tableButtons.Add(btn_Tafel7);
            tableButtons.Add(btn_Tafel8);
            tableButtons.Add(btn_Tafel9);
            tableButtons.Add(btn_Tafel10);
        }
        #endregion
        
        #region Take order
        private void btn_TakeOrder_Click(object sender, EventArgs e) {
            ShowPanel("takeOrder");
            ResetButtons(true);
        }
       
        private void FillListViewProducts(string subCategory) {

            if (subCategory == "Alcoholic") {
                products = order_Service.GetMenuItems("Alcoholisch");
            } else if (subCategory == "nonAlcoholic") {
                products = order_Service.GetMenuItems("nietAlcoholisch");
            } else {
                if (btn_LunchCategory.BackColor == Color.LightSlateGray) {
                    products = order_Service.GetMenuItems("Lunch", subCategory);
                } else if (btn_DinerCategory.BackColor == Color.LightSlateGray) {
                    products = order_Service.GetMenuItems("Diner", subCategory);
                }
            }

            listViewMenuItems.Items.Clear();

            foreach (MenuProduct product in products) {
                ListViewItem lvItem = new ListViewItem(new string[] { product.Name, product.Description, product.Stock.ToString() });
                lvItem.Tag = product;
                listViewMenuItems.Items.Add(lvItem);
            }

            listViewMenuItems.Visible = true;
        }

        private void ResetButtons(bool all) {
            if (all) {
                btn_LunchCategory.BackColor = SystemColors.ControlLight;
                btn_DinerCategory.BackColor = SystemColors.ControlLight;
                btn_DrinkCategory.BackColor = SystemColors.ControlLight;

                gb_SubLunch.Hide();
                bg_SubDiner.Hide();
                gb_SubDrink.Hide();

                listViewMenuItems.Visible = false;
                btn_ItemComment.Visible = false;
                btn_AddItemToOrder.Visible = false;
                lbl_Quality.Visible = false;
                cb_Quantity.Visible = false;
            }

            btn_SubStarter.BackColor = SystemColors.ControlLight;
            btn_SubStarterDiner.BackColor = SystemColors.ControlLight;
            btn_SubSide.BackColor = SystemColors.ControlLight;
            btn_SubMain.BackColor = SystemColors.ControlLight;
            btn_SubMainDiner.BackColor = SystemColors.ControlLight;
            btn_SubDessert.BackColor = SystemColors.ControlLight;
            btn_SubDessertDiner.BackColor = SystemColors.ControlLight;

            btn_SubNonAlcholic.BackColor = SystemColors.ControlLight;
            btn_SubAlcoholic.BackColor = SystemColors.ControlLight;
        }

        #region Choose Category
        private void btn_LunchCategory_Click(object sender, EventArgs e) {
            ResetButtons(true);

            if(!(btn_LunchCategory.BackColor == Color.LightSlateGray)){
                btn_LunchCategory.BackColor = Color.LightSlateGray;
                gb_SubLunch.Show();
            }
        }

        private void btn_DinerCategory_Click(object sender, EventArgs e) {
            ResetButtons(true);

            if (!(btn_DinerCategory.BackColor == Color.LightSlateGray)) {
                btn_DinerCategory.BackColor = Color.LightSlateGray;
                bg_SubDiner.Show();
            }
        }

        private void btn_DrinkCategory_Click(object sender, EventArgs e) {
            ResetButtons(true);

            if (!(btn_DrinkCategory.BackColor == Color.LightSlateGray)) {
                btn_DrinkCategory.BackColor = Color.LightSlateGray;
                gb_SubDrink.Show();
            }
        }

        private void btn_SubStarter_Click(object sender, EventArgs e) {
            ResetButtons(false);
            btn_SubStarter.BackColor = Color.LightSlateGray;

            FillListViewProducts(btn_SubStarter.Text);
        }

        private void btn_SubMain_Click(object sender, EventArgs e) {
            ResetButtons(false);
            btn_SubMain.BackColor = Color.LightSlateGray;

            FillListViewProducts(btn_SubMain.Text);
        }

        private void btn_SubDessert_Click(object sender, EventArgs e) {
            ResetButtons(false);
            btn_SubDessert.BackColor = Color.LightSlateGray;

            FillListViewProducts(btn_SubDessert.Text);
        }

        private void btn_SubAlcoholic_Click(object sender, EventArgs e) {
            ResetButtons(false);
            btn_SubAlcoholic.BackColor = Color.LightSlateGray;

            FillListViewProducts("Alcoholic");
        }

        private void btn_SubNonAlcholic_Click(object sender, EventArgs e) {
            ResetButtons(false);
            btn_SubNonAlcholic.BackColor = Color.LightSlateGray;

            FillListViewProducts("nonAlcoholic");
        }

        private void btn_SubStarterDiner_Click(object sender, EventArgs e) {
            ResetButtons(false);
            btn_SubStarterDiner.BackColor = Color.LightSlateGray;

            FillListViewProducts(btn_SubStarterDiner.Text);
        }

        private void btn_SubSide_Click(object sender, EventArgs e) {
            ResetButtons(false);
            btn_SubSide.BackColor = Color.LightSlateGray;

            FillListViewProducts(btn_SubSide.Text);
        }

        private void btn_SubMainDiner_Click(object sender, EventArgs e) {
            ResetButtons(false);
            btn_SubMainDiner.BackColor = Color.LightSlateGray;

            FillListViewProducts(btn_SubMainDiner.Text);
        }

        private void btn_SubDessertDiner_Click(object sender, EventArgs e) {
            ResetButtons(false);
            btn_SubDessertDiner.BackColor = Color.LightSlateGray;

            FillListViewProducts(btn_SubDessertDiner.Text);
        }
        #endregion

        private void btn_ItemComment_Click(object sender, EventArgs e) {
            Comment = Interaction.InputBox("Enter comment", "Comment", Comment);
            cb_Quantity.Enabled = false;
        }

        private void listViewMenuItems_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e) {
            Comment = "Enter comment";
            cb_Quantity.Enabled = true;

            btn_ItemComment.Visible = true;
            btn_AddItemToOrder.Visible = true;
            lbl_Quality.Visible = true;
            cb_Quantity.Visible = true;
            cb_Quantity.SelectedIndex = 0;
        }

        private void btn_AddItemToOrder_Click(object sender, EventArgs e) {
            if (listViewMenuItems.SelectedItems.Count <= 0) return;

            foreach (OrderItem orderItem in orderItems) {
                if (orderItem.MenuProduct == (MenuProduct)listViewMenuItems.SelectedItems[0].Tag && orderItem.Comment == null) {
                    orderItem.Quantity += int.Parse(cb_Quantity.Text);
                    OverviewButtomText();
                    return;
                }
            }

            OrderItem item = new OrderItem();
            item.MenuProduct = (MenuProduct)listViewMenuItems.SelectedItems[0].Tag;
            item.Quantity = int.Parse(cb_Quantity.Text);
            if (!(Comment == "Enter comment")) {
                item.Comment = Comment;
            }
            item.Status = false;

            orderItems.Add(item);
            cb_Quantity.SelectedIndex = 0;

            OverviewButtomText();
        }

        private void OverviewButtomText() {
            int quantity = 0;

            foreach (OrderItem orderItem in orderItems) {
                quantity += orderItem.Quantity;
            }

            btn_OverviewOrder.Text = "Bestelling = " + quantity + " stuks";
        }

        private void btn_CancelOrder_Click(object sender, EventArgs e) {
            ShowPanel("tableMenu");
            orderItems = new List<OrderItem>();
        }

        private void btn_OverviewOrder_Click(object sender, EventArgs e) {
            ShowPanel("OverviewOrder");
        }

        private void listViewOderOverview_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e) {
            lbl_OrderOverQuantity.Show();
            btn_AddQuantity.Show();
            btn_RemoveQuantity.Show();
            btn_RemoveItem.Show();
        }

        private void btn_BackToOrder_Click(object sender, EventArgs e) {
            ShowPanel("takeOrder");
        }

        #region Edit OrderOverview
        private void btn_RemoveItem_Click(object sender, EventArgs e) {
            OrderItem item = (OrderItem)listViewOrderOverview.SelectedItems[0].Tag;
            orderItems.Remove(item);

            ShowPanel("OverviewOrder");
        }

        private void ChangeQuantity(int number) {
            int selectedItem = 0;
            bool removed = false;

            OrderItem item = (OrderItem)listViewOrderOverview.SelectedItems[0].Tag;
            item.Quantity += number;
            if (item.Quantity == 0) {
                orderItems.Remove(item);
                removed = true;
            }

            listViewOrderOverview.Items.Clear();

            ShowPanel("OverviewOrder");
            if (!removed) {
                foreach (ListViewItem lvItem in listViewOrderOverview.Items) {
                    if (lvItem.Tag == item) {
                        listViewOrderOverview.Items[selectedItem].Selected = true;
                        break;
                    }
                    selectedItem++;
                }
            }
        }

        private void btn_RemoveQuantity_Click(object sender, EventArgs e) {
            ChangeQuantity(-1);
        }

        private void btn_AddQuantity_Click(object sender, EventArgs e) {
            ChangeQuantity(1);
        }
        #endregion

        private void btn_ConfirmOrder_Click(object sender, EventArgs e) {
            int orderID = order_Service.GetOrderId(TableNumber, employee);

            if (orderID != 0) {
                foreach (OrderItem item in orderItems) {
                    order_Service.CreateOrderItem(orderID, item);
                }
            }

            orderItems = new List<OrderItem>();

            ShowPanel("tableMenu");
        }

        #endregion

        #region View Orders
        private void btn_SeeOrder_Click(object sender, EventArgs e) {
            ShowPanel("ViewOrders");
        }
        private void btn_OrdersBackCancel_Click(object sender, EventArgs e) {
            if (btn_OrdersBackCancel.Text == "Terug") {
                ShowPanel("tableMenu");
                orderItems = new List<OrderItem>();
            } else if (btn_OrdersBackCancel.Text == "Annuleer") {
                ShowPanel("ViewOrders");
            }
        }

        private void btn_OrdersChangeConfirm_Click(object sender, EventArgs e) {
            ViewOrders viewOrders = ViewOrders.GetInstances();

            if (btn_OrdersChangeConfirm.Text == "Wijzig") {
                btn_OrdersDelete.Show();
                btn_OrdersMinus.Show();
                btn_OrdersPlus.Show();

                btn_OrdersBackCancel.Text = "Annuleer";
                btn_OrdersChangeConfirm.Text = "Bevestig";
            } else if (btn_OrdersChangeConfirm.Text == "Bevestig") {
                order_Service.ChangeOrders(viewOrders.ConfirmChanges());
                ShowPanel("ViewOrders");
            }
        }

        private void btn_OrdersDelete_Click(object sender, EventArgs e) {
            ViewOrders viewOrders = ViewOrders.GetInstances();

            if (listViewViewOrders.SelectedItems.Count == 0) { return; }

            viewOrders.Delete((OrderItem)listViewViewOrders.SelectedItems[0].Tag);

            FillLVViewOrder();
        }

        private void btn_OrdersMinus_Click(object sender, EventArgs e) {
            ViewOrders viewOrders = ViewOrders.GetInstances();

            if (listViewViewOrders.SelectedItems.Count == 0) { return; }

            OrderItem orderItem = (OrderItem)listViewViewOrders.SelectedItems[0].Tag;
            viewOrders.MinusQuantity(orderItem);

            FillLVViewOrder(orderItem);
        }

        private void btn_OrdersPlus_Click(object sender, EventArgs e) {
            ViewOrders viewOrders = ViewOrders.GetInstances();

            if (listViewViewOrders.SelectedItems.Count == 0) { return; }

            OrderItem orderItem = (OrderItem)listViewViewOrders.SelectedItems[0].Tag;
            viewOrders.AddQuantity(orderItem);

            FillLVViewOrder(orderItem);
        }

        private void FillLVViewOrder() {
            ViewOrders viewOrders = ViewOrders.GetInstances();

            listViewViewOrders.Items.Clear();

            foreach (OrderItem item in viewOrders.changedSortedItems) {
                ListViewItem lvItem = new ListViewItem(new string[] { item.MenuProduct.Name, item.Quantity.ToString(), item.Comment });
                lvItem.Tag = item;
                listViewViewOrders.Items.Add(lvItem);
            }
        }

        private void FillLVViewOrder(OrderItem orderItem) {
            ViewOrders viewOrders = ViewOrders.GetInstances();
            int selectedItem = 0;

            listViewViewOrders.Items.Clear();

            foreach (OrderItem item in viewOrders.changedSortedItems) {
                ListViewItem lvItem = new ListViewItem(new string[] { item.MenuProduct.Name, item.Quantity.ToString(), item.Comment });
                lvItem.Tag = item;
                listViewViewOrders.Items.Add(lvItem);
            }

            foreach (ListViewItem lvItem in listViewViewOrders.Items) {
                if (lvItem.Tag == orderItem) {
                    listViewViewOrders.Items[selectedItem].Selected = true;
                    break;
                }
                selectedItem++;
            }
        }
        #endregion

        //private void btn_TableInUse_Click(object sender, EventArgs e) {
        //    order_Service.SetTableAvailability(TableNumber,);
        //}
    }
}
