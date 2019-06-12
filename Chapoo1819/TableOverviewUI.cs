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
    public partial class TableOverviewUI : Form
    {
        Employee currentEmployee;
        Table_Service table_Service = new Table_Service();

        private List<Table> tables;
        private List<Button> tableButtons;
        private List<Label> tableLabels;

        public TableOverviewUI(Employee employee)
        {
            InitializeComponent();

            currentEmployee = employee;

            tableButtons = new List<Button>
            {
                btnTable1, btnTable2, btnTable3, btnTable4, btnTable5, btnTable6, btnTable7, btnTable8, btnTable9, btnTable10
            };

            tableLabels = new List<Label>
            {
                lblTable1, lblTable2, lblTable3, lblTable4, lblTable5, lblTable6, lblTable7, lblTable8, lblTable9, lblTable10
            };

            tables = table_Service.GetTables();

            for (int i = 1; i < tables.Count; i++)
            {
                if (tables[i].InUse)
                {
                    tableButtons[i].BackColor = Color.Red;
                }
                else
                {
                    tableButtons[i].BackColor = Color.LightGreen;
                }
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Hide();
            WaiterDashboardUI dashboard = new WaiterDashboardUI(currentEmployee);
            dashboard.Show();
        }
    }
}
