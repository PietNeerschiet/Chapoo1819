﻿using System;
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

        private void btnManagement_Click(object sender, EventArgs e)
        {
            ManagementUI managementUI = new ManagementUI();
            managementUI.Show();
        }
    }
}
