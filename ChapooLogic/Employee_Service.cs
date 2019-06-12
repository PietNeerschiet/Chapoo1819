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
    public class Employee_Service
    {
        Employee_DAO employee_db = new Employee_DAO();

        /// <summary>
        /// Get & return the list of teachers from the Teacher_DAO
        /// </summary>
        public List<Employee> GetEmployees()
        {
            try
            {
                List<Employee> employees = employee_db.Db_Get_All_Employees();
                return employees;
            }
            catch (Exception e)
            {
                StreamWriter writer = new StreamWriter("errorLog");
                writer.Write(e);
                writer.Close();

                List<Employee> employees = new List<Employee>();
                Employee a = new Employee
                {
                    Name = "Mr. Test Student",
                    EmployeeID = 474791
                };
                employees.Add(a);
                Employee b = new Employee
                {
                    Name = "Mrs. Test Student",
                    EmployeeID = 197474
                };
                employees.Add(b);

                MessageBox.Show("Requesting list of employees failed.", "Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return employees;
            }
        }

        public void EditEmployee(int employeeNumber, string name, string password, int type)
        {
            try
            {
                employee_db.Db_Edit_Employee(employeeNumber, name, password, type);
            }
            catch (Exception e)
            {
                StreamWriter writer = new StreamWriter("errorLog");
                writer.Write(e);
                writer.Close();

                MessageBox.Show("Editing employee failed!", "Updating Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void AddEmployee(string name, string password, int type)
        {
            try
            {
                employee_db.Db_Create_Employee(name, password, type);
            }
            catch (Exception e)
            {
                StreamWriter writer = new StreamWriter("errorLog");
                writer.Write(e);
                writer.Close();

                MessageBox.Show("Failed adding the employee to the database!", "Inserting Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void RemoveEmployee(int employeeID)
        {
            try
            {
                employee_db.Db_Remove_Employee(employeeID);
            }
            catch (Exception e)
            {
                StreamWriter writer = new StreamWriter("errorLog");
                writer.Write(e);
                writer.Close();

                MessageBox.Show("Cannot remove employee because the employee is tied to an order!", "Deleting Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
