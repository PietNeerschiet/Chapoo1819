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
using ChapooLogic;
using ChapooModel;

namespace Chapoo1819
{
    public partial class LoginUI : Form
    {
        private Employee_Service employeeService;
        private List<Employee> employees;

        public LoginUI()
        {
            InitializeComponent();
            employeeService = new Employee_Service();
            employees = employeeService.GetEmployees();
            textBoxPassword.PasswordChar = '*';
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string enteredEmployeeID = textBoxUsername.Text;
            string enteredPassword = textBoxPassword.Text;
            bool loginSuccess = false;

            foreach (Employee employee in employees)
            {
                if (employee.EmployeeID.ToString() == enteredEmployeeID && employee.Password == enteredPassword)
                {
                    this.Hide();

                    WaiterDashboardUI dashboard = new WaiterDashboardUI(employee);
                    dashboard.Show();

                    lblError.Hide();
                    loginSuccess = true;
                }
            }

            if (!loginSuccess)
            {
                textBoxUsername.Text = string.Empty;
                textBoxPassword.Text = string.Empty;

                lblError.Show();
            }
        }

        private void btn_ShowOrderUI_Click(object sender, EventArgs e) {
            Employee employee = new Employee() {
                EmployeeID = 29991,
                Name = "Betsy"
            };

            OrderUI orderUI = new OrderUI(employee);
            orderUI.Show();
        }
    }
}
