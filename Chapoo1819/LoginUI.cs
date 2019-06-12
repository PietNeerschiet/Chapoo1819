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
    public partial class LoginUI : Form
    {
        public LoginUI()
        {
            InitializeComponent();
        }

        private void btnManagement_Click(object sender, EventArgs e)
        {
            KitchenBarUI kitchenBarUI = new KitchenBarUI();
            kitchenBarUI.Show();
            //ManagementUI managementUI = new ManagementUI();
            //managementUI.Show();
        }
    }
}
