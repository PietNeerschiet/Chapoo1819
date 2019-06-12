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
    public partial class WaiterDashboardUI : Form
    {
        private Employee currentEmployee;

        public WaiterDashboardUI(Employee employee)
        {
            InitializeComponent();
            currentEmployee = employee;
        }

        private void btnRestaurantOverview_Click(object sender, EventArgs e)
        {
            this.Hide();
            TableOverviewUI tableOverview = new TableOverviewUI(currentEmployee);
            tableOverview.Show();
        }

        private void btnLogOff_Click(object sender, EventArgs e)
        {
            this.Close();
            LoginUI login = new LoginUI();
            login.Show();
        }
    }
}
