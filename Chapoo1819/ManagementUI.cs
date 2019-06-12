using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
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
        private Employee currentUser;
        public ManagementUI(Employee currentUser)
        {
            InitializeComponent();
            this.currentUser = currentUser;
        }
        private void ManagementUI_Load(object sender, EventArgs e)
        {
            menuProduct_Service = new ChapooLogic.MenuProduct_Service();
            employee_Service = new ChapooLogic.Employee_Service();
            revenue_Service = new ChapooLogic.Revenue_Service();
            ShowHome();
            

            lblIngelogdAls.Text = currentUser.EmployeeType.ToString();
        }

        // Creates the service for designated methods
        private ChapooLogic.MenuProduct_Service menuProduct_Service;
        private ChapooLogic.Employee_Service employee_Service;
        private ChapooLogic.Revenue_Service revenue_Service;

        // Method for hiding all panels //
        private void HideAllPanels()
        {
            pnl_Home.Hide();
            pnl_Stock.Hide();
            pnl_Employees.Hide();
            pnl_AddEmployee.Hide();
            pnl_EditEmployee.Hide();
            pnl_RemoveEmployee.Hide();
            pnl_ChangeMenu.Hide();
            pnl_AddMenuProduct.Hide();
            pnl_EditMenuProduct.Hide();
            pnl_RemoveMenuProduct.Hide();
            pnl_Revenue.Hide();
            pnl_RevenueKitchenBar.Hide();
        }

        // Method for showing home page //
        private void ShowHome()
        {
            HideAllPanels();
            pnl_Home.Show();
        }

        // Method for setting listview row height //
        private void SetLvHeight(ListView listView, int height)
        {
            ImageList imgList = new ImageList();
            imgList.ImageSize = new Size(1, height);
            listView.SmallImageList = imgList;
        }

        // Method for showing a certain panel and hiding the other panels //
        private void ShowPanel(string panelName)
        {
            // Hide all panels
            HideAllPanels();

            // Show designated panel
            if (panelName == "Stock")
            {
                pnl_Stock.Show();
            }
            else if (panelName == "Employees")
            {
                pnl_Employees.Show();
            }
            else if (panelName == "AddEmployee")
            {
                pnl_Employees.Show();
                pnl_AddEmployee.Show();

                // Confirmed bugfix for panels not showing
                pnl_AddEmployee.BringToFront();
            }
            else if (panelName == "EditEmployee")
            {
                pnl_Employees.Show();
                pnl_EditEmployee.Show();

                // Confirmed bugfix for panels not showing
                pnl_EditEmployee.BringToFront();
            }
            else if (panelName == "RemoveEmployee")
            {
                pnl_Employees.Show();
                pnl_RemoveEmployee.Show();

                // Confirmed bugfix for panels not showing
                pnl_RemoveEmployee.BringToFront();
            }
            else if (panelName == "ChangeMenu")
            {
                pnl_ChangeMenu.Show();
            }
            else if (panelName == "AddMenuProduct")
            {
                pnl_ChangeMenu.Show();
                pnl_AddMenuProduct.Show();

                // Confirmed bugfix for panels not showing
                pnl_AddMenuProduct.BringToFront();
            }
            else if (panelName == "EditMenuProduct")
            {
                pnl_ChangeMenu.Show();
                pnl_EditMenuProduct.Show();

                // Confirmed bugfix for panels not showing
                pnl_EditMenuProduct.BringToFront();
            }
            else if (panelName == "RemoveMenuProduct")
            {
                pnl_ChangeMenu.Show();
                pnl_RemoveMenuProduct.Show();

                // Confirmed bugfix for panels not showing
                pnl_RemoveMenuProduct.BringToFront();
            }
            else if (panelName == "Revenue")
            {
                pnl_Revenue.Show();
            }
            else if (panelName == "RevenueKitchenBar")
            {
                pnl_RevenueKitchenBar.Show();
            }
        }

        private void btnBackToHome_Click(object sender, EventArgs e)
        {
            ShowHome();
        }

        ///
        //----- Column sorter section -----//
        ///
        // The column we are currently using for sorting.
        private ColumnHeader SortingColumn = null;

        // Method for sorting a column in a ListView //
        private void SortColumn(ListView listView, ColumnClickEventArgs e)
        {
            // Get the new sorting column.
            ColumnHeader new_sorting_column = listView.Columns[e.Column];

            // Figure out the new sorting order.
            System.Windows.Forms.SortOrder sort_order;
            if (SortingColumn == null)
            {
                // New column. Sort ascending.
                sort_order = SortOrder.Ascending;
            }
            else
            {
                // See if this is the same column.
                if (new_sorting_column == SortingColumn)
                {
                    // Same column. Switch the sort order.
                    if (SortingColumn.Text.StartsWith("> "))
                    {
                        sort_order = SortOrder.Descending;
                    }
                    else
                    {
                        sort_order = SortOrder.Ascending;
                    }
                }
                else
                {
                    // New column. Sort ascending.
                    sort_order = SortOrder.Ascending;
                }

                // Remove the old sort indicator.
                SortingColumn.Text = SortingColumn.Text.Substring(2);
            }

            // Display the new sort order.
            SortingColumn = new_sorting_column;
            if (sort_order == SortOrder.Ascending)
            {
                SortingColumn.Text = "> " + SortingColumn.Text;
            }
            else
            {
                SortingColumn.Text = "< " + SortingColumn.Text;
            }

            // Create a comparer.
            listView.ListViewItemSorter =
                new ListViewComparer(e.Column, sort_order);

            // Sort.
            listView.Sort();
        }


        ///
        // ----- Stock section -----//
        /// 
        private void btnStock_Click(object sender, EventArgs e)
        {
            ShowPanel("Stock");

            AddStockToList("listViewStock");
        }

        // Sort on column for stock page
        private void listViewStock_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            SortColumn(listViewStock, e);
        }

        // Fills a listview that uses stock data
        private void FillStockListView(ListView listView, List<MenuProduct> productList)
        {
            // Clear the previous list items
            listView.Items.Clear();

            // Fill list with product items
            foreach (ChapooModel.MenuProduct p in productList)
            {
                ListViewItem li = new ListViewItem(p.MenuItemCode.ToString());
                li.SubItems.Add(p.Name);
                li.SubItems.Add(p.Description);
                li.SubItems.Add(p.Stock.ToString());
                li.SubItems.Add(p.Category);
                li.Tag = p; 

                listView.Items.Add(li);
            }

            SetLvHeight(listView, 60);
        }
        
        // Adds all stock to list
        private void AddStockToList(string listViewName)
        {
            List<MenuProduct> productList = menuProduct_Service.GetAllProducts();
            ListView listView = (ListView)(Controls.Find(listViewName, true).First());

            FillStockListView(listView, productList);
        }
        // Adds bar stock to list
        private void AddBarStockToList(string listViewName)
        {
            List<MenuProduct> productList = menuProduct_Service.GetBarProducts();
            ListView listView = (ListView)(Controls.Find(listViewName, true).First());

            FillStockListView(listView, productList);
        }
        // Adds kitchen stock to list
        private void AddKitchenStockToList(string listViewName)
        {
            List<MenuProduct> productList = menuProduct_Service.GetKitchenProducts();
            ListView listView = (ListView)(Controls.Find(listViewName, true).First());

            FillStockListView(listView, productList);
        }
        private void btnUpdateStock_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtNewStockValue.Text == "" || (listViewStock.SelectedItems.Count == 0 && listViewStock.CheckedItems.Count == 0))
                {
                    return;
                }
                else if (!double.TryParse(txtNewStockValue.Text, out double parsedValue))
                {
                    MessageBox.Show("Voer alleen nummers in voor voorraad!", "Foutmelding");
                }
                else
                {
                    MenuProduct_Service stockService = new MenuProduct_Service();
                    
                    // Update stock with the new data
                    foreach (ListViewItem selectedItem in listViewStock.SelectedItems)
                    {
                        MenuProduct p = (MenuProduct)selectedItem.Tag;

                        stockService.EditStock(p.MenuItemCode, int.Parse(txtNewStockValue.Text));
                    }
                    foreach (ListViewItem selectedItem in listViewStock.CheckedItems)
                    {
                        MenuProduct p = (MenuProduct)selectedItem.Tag;
                        stockService.EditStock(p.MenuItemCode, int.Parse(txtNewStockValue.Text));
                    }

                    // Notify user if adding product was succesful
                    //MessageBox.Show("Editing stock completed!");

                    // Updates listview
                    if (kitchenStockButtonClicked)
                    {
                        AddKitchenStockToList("listViewStock");
                        kitchenStockButtonClicked = false;
                    }
                    else if (barStockButtonClicked)
                    {
                        AddBarStockToList("listViewStock");
                        barStockButtonClicked = false;
                    }
                    else
                    {
                        AddStockToList("listViewStock");
                    }
                    txtNewStockValue.Clear();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        // Booleans to check which filter button was last clicked
        private bool kitchenStockButtonClicked;
        private bool barStockButtonClicked;

        // These button clicks filter the ListView content
        private void btnShowAllStock_Click(object sender, EventArgs e)
        {
            AddStockToList("listViewStock");
        }
        private void btnShowKitchenStock_Click(object sender, EventArgs e)
        {
            AddKitchenStockToList("listViewStock");
            kitchenStockButtonClicked = true;
            barStockButtonClicked = false;
        }
        private void btnShowBarStock_Click(object sender, EventArgs e)
        {
            AddBarStockToList("listViewStock");
            barStockButtonClicked = true;
            kitchenStockButtonClicked = false;
        }


        /// 
        // ----- Employee management section -----//
        /// 
        private void btnEmployeeManagement_Click(object sender, EventArgs e)
        {
            ShowPanel("Employees");

            AddEmployeesToList("listViewEmployees");
        }

        private void AddEmployeesToList(string listViewName)
        {
            List<Employee> employeeList = employee_Service.GetEmployees();
            ListView listView = (ListView)(Controls.Find(listViewName, true).First());

            // Clear the previous list items
            listView.Items.Clear();

            // Fill list with product items
            foreach (ChapooModel.Employee e in employeeList)
            {
                ListViewItem li = new ListViewItem(e.EmployeeID.ToString());
                li.SubItems.Add(e.Name);
                li.SubItems.Add(e.Password);
                li.SubItems.Add(e.EmployeeType.ToString());
                li.Tag = e;

                listView.Items.Add(li);
            }

            SetLvHeight(listView, 50);
        }
        // "Back to employee management panel" button
        private void btnBackToEmployees_Click(object sender, EventArgs e)
        {
            ShowPanel("Employees");

            txtEditEmployeeName.Clear();
            txtEditEmployeePassword.Clear();
            txtEditEmployeeType.Clear();
            listViewEmployees.SelectedItems.Clear();
        }
        // Button to show add employee panel
        private void btnAddEmployee_Click(object sender, EventArgs e)
        {
            ShowPanel("AddEmployee");
        }
        // Button to show edit employee panel
        private void btnEditEmployee_Click(object sender, EventArgs e)
        {
            ShowPanel("EditEmployee");

            if (listViewEmployees.SelectedItems.Count == 1)
            {
                txtEditEmployeeName.Text = listViewEmployees.SelectedItems[0].SubItems[1].Text;
                txtEditEmployeePassword.Text = listViewEmployees.SelectedItems[0].SubItems[2].Text;
                txtEditEmployeeType.Text = listViewEmployees.SelectedItems[0].SubItems[3].Text;
            }
            else if (listViewEmployees.CheckedItems.Count == 1)
            {
                txtEditEmployeeName.Text = listViewEmployees.CheckedItems[0].SubItems[1].Text;
                txtEditEmployeePassword.Text = listViewEmployees.CheckedItems[0].SubItems[2].Text;
                txtEditEmployeeType.Text = listViewEmployees.CheckedItems[0].SubItems[3].Text;
            }
        }
        // Button to show remove employee confirmation panel
        private void btnRemoveEmployee_Click(object sender, EventArgs e)
        {
            if (listViewEmployees.SelectedItems.Count > 0 || listViewEmployees.CheckedItems.Count > 0)
            {
                ShowPanel("RemoveEmployee");
            }
        }
        // Button to add a new employee to the database
        private void btnAddEmployeeToDatabase_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtAddEmployeeName.Text == "" || txtAddEmployeePassword.Text == "" || txtAddEmployeeType.Text == "")
                {
                    MessageBox.Show("Vul a.u.b alle velden in.", "Foutmelding");
                }
                else
                {
                    // Adds employee to the database
                    EmployeeType employeeType = (EmployeeType)Enum.Parse(typeof(EmployeeType), txtAddEmployeeType.Text);
                    employee_Service.AddEmployee(txtAddEmployeeName.Text, txtAddEmployeePassword.Text, (int)employeeType);

                    // Clears textboxes
                    txtAddEmployeeName.Clear();
                    txtAddEmployeePassword.Clear();
                    txtAddEmployeeType.Clear();

                    // Refreshes listview
                    AddEmployeesToList("listViewEmployees");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        // Button to edit existing employee
        private void btnEditExistingEmployee_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtEditEmployeeName.Text == "" || txtEditEmployeePassword.Text == "" || txtEditEmployeeType.Text == "")
                {
                    MessageBox.Show("Vul a.u.b alle velden in.", "Foutmelding");
                }
                else if (listViewEmployees.CheckedItems.Count > 1 || listViewEmployees.SelectedItems.Count > 1)
                {
                    MessageBox.Show("Selecteer één werknemer.", "Foutmelding");
                }
                else
                {
                    int employeeNumber = 0;
                    // Edits employee in the database
                    EmployeeType employeeType = (EmployeeType)Enum.Parse(typeof(EmployeeType), txtEditEmployeeType.Text);
                    Employee employee = (Employee)listViewEmployees.SelectedItems[0].Tag;

                    if (listViewEmployees.CheckedItems.Count == 1 || listViewEmployees.SelectedItems.Count == 1)
                    {
                        employeeNumber = employee.EmployeeID;
                    }

                    employee_Service.EditEmployee(employeeNumber, txtEditEmployeeName.Text, txtEditEmployeePassword.Text, (int)employeeType);

                    // Clears textboxes
                    txtEditEmployeeName.Clear();
                    txtEditEmployeePassword.Clear();
                    txtEditEmployeeType.Clear();

                    // Refreshes listview
                    AddEmployeesToList("listViewEmployees");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        // Button to confirm removing employee
        private void btnOkRemoveEmployee_Click(object sender, EventArgs e)
        {
            try
            {
                if (listViewEmployees.CheckedItems.Count > 1 || listViewEmployees.SelectedItems.Count > 1)
                {
                    MessageBox.Show("Selecteer één werknemer.", "Foutmelding");
                }
                else
                {
                    int employeeNumber = 0;
                    Employee employee = (Employee)listViewEmployees.SelectedItems[0].Tag;

                    if (listViewEmployees.CheckedItems.Count == 1 || listViewEmployees.SelectedItems.Count == 1)
                    {
                        employeeNumber = employee.EmployeeID;
                    }

                    // Removes selected employee from the database
                    employee_Service.RemoveEmployee(employeeNumber);

                    // Refreshes listview
                    AddEmployeesToList("listViewEmployees");

                    // Goes back to employee panel
                    ShowPanel("Employees");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        ///
        // ----- Menu management section ----- // 
        ///
        private void btnChangeMenu_Click(object sender, EventArgs e)
        {
            ShowPanel("ChangeMenu");

            AddMenuToList("listViewChangeMenu");
        }
        private void FillMenuListView(ListView listView, List<MenuProduct> productList)
        {
            // Clear the previous list items
            listView.Items.Clear();

            // Fill list with product items
            foreach (ChapooModel.MenuProduct p in productList)
            {
                ListViewItem li = new ListViewItem(p.Name);
                li.SubItems.Add(p.Description);
                li.SubItems.Add(p.Price.ToString("c"));
                li.SubItems.Add(p.Category);
                li.Tag = p;

                listView.Items.Add(li);
            }

            SetLvHeight(listView, 50);
        }

        // Adds all menu items to listview
        private void AddMenuToList(string listViewName)
        {
            List<MenuProduct> productList = menuProduct_Service.GetAllProducts();
            ListView listView = (ListView)(Controls.Find(listViewName, true).First());

            FillMenuListView(listView, productList);
        }
        // Adds bar menu items to listview
        private void AddBarMenuToList(string listViewName)
        {
            List<MenuProduct> productList = menuProduct_Service.GetBarProducts();
            ListView listView = (ListView)(Controls.Find(listViewName, true).First());

            FillMenuListView(listView, productList);
        }
        // Adds kitchen menu items to listview
        private void AddKitchenMenuToList(string listViewName)
        {
            List<MenuProduct> productList = menuProduct_Service.GetKitchenProducts();
            ListView listView = (ListView)(Controls.Find(listViewName, true).First());

            FillMenuListView(listView, productList);
        }

        // Sort on column for menu management page
        private void listViewMenu_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            SortColumn(listViewChangeMenu, e);
        }

        // Booleans to check which filter button was last clicked
        private bool kitchenMenuButtonClicked;
        private bool barMenuButtonClicked;

        // Button to filter on 'show all'
        private void btnShowAllMenu_Click(object sender, EventArgs e)
        {
            AddMenuToList("listViewChangeMenu");
        }
        // Button to filter on kitchen menu only
        private void btnShowKitchenMenu_Click(object sender, EventArgs e)
        {
            AddKitchenMenuToList("listViewChangeMenu");
            kitchenMenuButtonClicked = true;
            barMenuButtonClicked = false;
        }
        // Button to filter on bar menu only
        private void btnShowBarMenu_Click(object sender, EventArgs e)
        {
            AddBarMenuToList("listViewChangeMenu");
            barMenuButtonClicked = true;
            kitchenMenuButtonClicked = false;
        }
        // Show add menu product panel on button click
        private void btnAddMenuProduct_Click(object sender, EventArgs e)
        {
            ShowPanel("AddMenuProduct");
        }
        // Show edit menu product panel on button click
        private void btnEditMenuProduct_Click(object sender, EventArgs e)
        {
            ShowPanel("EditMenuProduct");

            // Fills textboxes with selected row information
            if (listViewChangeMenu.SelectedItems.Count == 1)
            {
                txtEditProductName.Text = listViewChangeMenu.SelectedItems[0].SubItems[0].Text;
                txtEditProductDescription.Text = listViewChangeMenu.SelectedItems[0].SubItems[1].Text;
                txtEditProductPrice.Text = double.Parse(listViewChangeMenu.SelectedItems[0].SubItems[2].Text, NumberStyles.Currency).ToString();
                cmBxEditMenuCategory.Text = listViewChangeMenu.SelectedItems[0].SubItems[3].Text;
            }
        }
        // Back to menu management panel on button click
        private void btnBackToChangeMenu_Click(object sender, EventArgs e)
        {
            ShowPanel("ChangeMenu");

            txtEditProductName.Clear();
            txtEditProductDescription.Clear();
            txtEditProductPrice.Clear();
            cmBxEditMenuCategory.ResetText();
            listViewEmployees.SelectedItems.Clear();
        }
        // Add new menu product to the database on button click
        private void btnAddProductToDatabase_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtAddProductName.Text == "" ||  txtAddProductPrice.Text == "" || cmBxAddToMenuCategory.Text == "")
                {
                    MessageBox.Show("Vul a.u.b alle velden in.", "Foutmelding");
                }
                else
                {
                    // Adds employee to the database
                    menuProduct_Service.AddMenuProduct(txtAddProductName.Text, txtAddProductDescription.Text, double.Parse(txtAddProductPrice.Text), cmBxAddToMenuCategory.Text);

                    // Clears textboxes
                    txtAddProductName.Clear();
                    txtAddProductDescription.Clear();
                    txtAddProductPrice.Clear();
                    cmBxEditMenuCategory.ResetText();

                    // Refreshes listview
                    AddMenuToList("listViewChangeMenu");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        // Edits selected existing menu product on button click
        private void btnEditExistingProduct_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtEditProductName.Text == "" || txtEditProductPrice.Text == "" || cmBxEditMenuCategory.Text == "")
                {
                    MessageBox.Show("Vul a.u.b alle velden in.", "Foutmelding");
                }
                else if (listViewEmployees.CheckedItems.Count > 1 || listViewEmployees.SelectedItems.Count > 1)
                {
                    MessageBox.Show("Selecteer één product.", "Foutmelding");
                }
                else
                {
                    List<MenuProduct> productList = menuProduct_Service.GetAllProducts();

                    // Edits product in the database
                    MenuProduct mp = (MenuProduct)listViewChangeMenu.SelectedItems[0].Tag;

                    menuProduct_Service.EditMenuProduct(mp.MenuItemCode, txtEditProductName.Text, txtEditProductDescription.Text, double.Parse(txtEditProductPrice.Text), cmBxEditMenuCategory.Text);

                    // Clears textboxes
                    txtEditProductName.Clear();
                    txtEditProductDescription.Clear();
                    txtEditProductPrice.Clear();
                    cmBxEditMenuCategory.ResetText();

                    // Refreshes listview
                    // Updates listview
                    if (kitchenMenuButtonClicked)
                    {
                        AddKitchenMenuToList("listViewChangeMenu");
                        kitchenStockButtonClicked = false;
                    }
                    else if (barMenuButtonClicked)
                    {
                        AddBarMenuToList("listViewChangeMenu");
                        barStockButtonClicked = false;
                    }
                    else
                    {
                        AddMenuToList("listViewChangeMenu");
                    }
                    ShowPanel("ChangeMenu");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        // Show delete menu product panel if one product is selected in the listview
        private void btnRemoveMenuProduct_Click(object sender, EventArgs e)
        {
            if (listViewChangeMenu.SelectedItems.Count == 1)
            {
                ShowPanel("RemoveMenuProduct");
            }
            else
            {
                MessageBox.Show("Selecteer één product.", "Foutmelding");
            }
        }
        // Button for confirmed menu product deletion from database
        private void btnOkRemoveProduct_Click(object sender, EventArgs e)
        {
            try
            {
                List<MenuProduct> productList = menuProduct_Service.GetAllProducts();

                // Edits product in the database
                MenuProduct mp = (MenuProduct)listViewChangeMenu.SelectedItems[0].Tag;

                menuProduct_Service.RemoveMenuProduct(mp.MenuItemCode);
                // Updates listview
                if (kitchenMenuButtonClicked)
                {
                    AddKitchenMenuToList("listViewChangeMenu");
                    kitchenStockButtonClicked = false;
                }
                else if (barMenuButtonClicked)
                {
                    AddBarMenuToList("listViewChangeMenu");
                    barStockButtonClicked = false;
                }
                else
                {
                    AddMenuToList("listViewChangeMenu");
                }

                // Goes back to Change Menu panel
                ShowPanel("ChangeMenu");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// 
        // ----- Revenue section ------
        /// 
        private void btnRevenue_Click(object sender, EventArgs e)
        {
            ShowPanel("Revenue");

            AddRevenueToList("listViewRevenue");
        }

        // Method for filling the revenue listview with all revenue
        private void FillAllRevenueListView(ListView listView, List<Order> revenueList)
        {
            // Clear the previous list items
            listView.Items.Clear();
            double totalRevenue = 0;
            // Fill list with product items
            foreach (ChapooModel.Order o in revenueList)
            {
                totalRevenue += o.TotalPaid;
                ListViewItem li = new ListViewItem(o.OrderID.ToString());
                li.SubItems.Add(o.Employee.EmployeeID.ToString());
                li.SubItems.Add(o.TotalPrice.ToString("c"));
                li.SubItems.Add(o.TotalPaid.ToString("c"));
                li.SubItems.Add(o.Tip.ToString("c"));
                li.SubItems.Add(o.OrderDate.ToString());

                listView.Items.Add(li);
            }

            SetLvHeight(listView, 40);
            lblTotalRevenue.Text = totalRevenue.ToString("c");
        }

        // Method for filling the kitchen and bar revenue listview with their respective transactions
        private void FillKitchenBarRevenueListView(ListView listView, List<Order> revenueList)
        {
            // Clear the previous list items
            listView.Items.Clear();
            double totalRevenue = 0;
            // Fill list with product items
            foreach (ChapooModel.Order o in revenueList)
            {
                totalRevenue += (o.Quantity * o.Price);
                ListViewItem li = new ListViewItem(o.OrderID.ToString());
                li.SubItems.Add(o.Employee.EmployeeID.ToString());
                li.SubItems.Add(o.ProductName);
                li.SubItems.Add(o.Quantity.ToString());
                li.SubItems.Add(o.Price.ToString("c"));
                li.SubItems.Add(o.OrderDate.ToString());

                listView.Items.Add(li);
            }

            SetLvHeight(listView, 40);
            lblTotalRevenueKitchenBar.Text = totalRevenue.ToString("c");
        }
        // Adds all revenue items to listview
        private void AddRevenueToList(string listViewName)
        {
            List<Order> orderList = revenue_Service.GetAllPaidOrders();
            ListView listView = (ListView)(Controls.Find(listViewName, true).First());

            FillAllRevenueListView(listView, orderList);
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            lblTotalRevenue.Text = "";

            AddRevenueToList("listViewRevenue");
        }
        // Adds bar menu items to listview
        private void AddBarRevenueToList(string listViewName)
        {
            List<Order> orderList = revenue_Service.GetBarPaidOrders();
            ListView listView = (ListView)(Controls.Find(listViewName, true).First());

            FillKitchenBarRevenueListView(listView, orderList);
        }
        // Adds kitchen menu items to listview
        private void AddKitchenRevenueToList(string listViewName)
        {
            List<Order> orderList = revenue_Service.GetKitchenPaidOrders();
            ListView listView = (ListView)(Controls.Find(listViewName, true).First());

            FillKitchenBarRevenueListView(listView, orderList);
        }

        // Boolean to check which filter button was last clicked
        private bool kitchenRevenueButtonClicked;
        
        // Filters revenue listview to show only kitchen revenue
        private void btnKitchenRevenue_Click(object sender, EventArgs e)
        {
            ShowPanel("RevenueKitchenBar");

            AddKitchenRevenueToList("listViewRevenueKitchenBar");

            kitchenRevenueButtonClicked = true;
        }

        // Filters revenue listview to show only bar revenue
        private void btnBarRevenue_Click(object sender, EventArgs e)
        {
            ShowPanel("RevenueKitchenBar");

            AddBarRevenueToList("listViewRevenueKitchenbar");
            
            kitchenRevenueButtonClicked = false;
        }

        // Refreshes the bar and kitchen revenue listview
        private void btnRefresh2_Click(object sender, EventArgs e)
        {
            lblTotalRevenueKitchenBar.Text = "";

            if (kitchenRevenueButtonClicked)
            {
                AddKitchenRevenueToList("listViewRevenueKitchenBar");
            }
            else
            {
                AddBarRevenueToList("listViewRevenueKitchenBar");
            }
        }
        // Method for sorting all revenue on column click
        private void listViewRevenue_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            SortColumn(listViewRevenue, e);
        }

        // Method for sorting kitchen or bar revenue on column click
        private void listViewRevenueKitchenBar_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            SortColumn(listViewRevenueKitchenBar, e);
        }
    }
}
