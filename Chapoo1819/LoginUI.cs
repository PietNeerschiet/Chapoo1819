using ChapooModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chapoo1819
{
    public partial class LoginUI : Form
    {
        public LoginUI()
        {
            InitializeComponent();

        }
        Employee currentUser;
        private void btnManagement_Click(object sender, EventArgs e)
        {
            // Temporary code before login is finished
            Employee manager = new Employee();
            manager.EmployeeType = EmployeeType.Manager;
            currentUser = manager;
            // ---------------------------

            ManagementUI managementUI = new ManagementUI(currentUser);
            managementUI.Show();
        }
    }
}
