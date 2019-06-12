using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Collections.ObjectModel;
using ChapooModel;

namespace ChapooDAL
{
    public class Employee_DAO : Base
    {
        // Requests employee data from the database
        public List<Employee> Db_Get_All_Employees()
        {
            string query = "SELECT Employee_ID, Name, Password, Type FROM Employee";
            SqlParameter[] sqlParameters = new SqlParameter[0];
            return ReadTables(ExecuteSelectQuery(query, sqlParameters));
        }
        // Requests employee from the database
        public Employee Db_Get_Employee(int employeeID)
        {
            string query = "SELECT Employee_ID, Name, Password, Type FROM Employee WHERE Employee_ID = @employeeID";
            SqlParameter[] sqlParameters = new SqlParameter[1];
            sqlParameters[0] = (new SqlParameter("@employeeID", employeeID));
            return ReadTableRow(ExecuteSelectQuery(query, sqlParameters));
        }

        // Adds all the employees to a list
        private List<Employee> ReadTables(DataTable dataTable)
        {
            List<Employee> employees = new List<Employee>();

            foreach (DataRow dr in dataTable.Rows)
            {
                Employee employee = new Employee()
                {
                    EmployeeID = (int)dr["Employee_ID"],
                    Name = (String)(dr["Name"].ToString()),
                    Password = (String)(dr["Password"].ToString()),
                    EmployeeType = (EmployeeType)dr["Type"]
                };
                employees.Add(employee);
            }
            return employees;
        }
        // Adds current table row to a class
        private Employee ReadTableRow(DataTable dataTable)
        {
            Employee employee = new Employee();

            foreach (DataRow dr in dataTable.Rows)
            {
                employee = new Employee()
                {
                    EmployeeID = (int)dr["Employee_ID"],
                    Name = (String)(dr["Name"].ToString()),
                    Password = (String)(dr["Password"].ToString()),
                    EmployeeType = (EmployeeType)(int)dr["Type"]
                };
            }
            return employee;
        }
        public void Db_Edit_Employee(int employeeNumber, string newName, string newPassword, int newType)
        {
            string query = "UPDATE Employee SET Name = @newName, Password = @newPassword, Type = @newType WHERE Employee_ID = @Employee_ID";
            SqlParameter[] sqlParameters = new SqlParameter[4];
            sqlParameters[0] = (new SqlParameter("@Employee_ID", employeeNumber));
            sqlParameters[1] = (new SqlParameter("@newName", newName));
            sqlParameters[2] = (new SqlParameter("@newPassword", newPassword));
            sqlParameters[3] = (new SqlParameter("@newType", newType));
            ExecuteEditQuery(query, sqlParameters);
        }
        public void Db_Create_Employee(string newName, string newPassword, int newType)
        {
            string query = "INSERT INTO Employee VALUES (@newName, @newPassword, @newType)";
            SqlParameter[] sqlParameters = new SqlParameter[3];
            sqlParameters[0] = (new SqlParameter("@newName", newName));
            sqlParameters[1] = (new SqlParameter("@newPassword", newPassword));
            sqlParameters[2] = (new SqlParameter("@newType", newType));
            ExecuteEditQuery(query, sqlParameters);
        }
        public void Db_Remove_Employee(int employeeNumber)
        {
            string query = "DELETE FROM Employee WHERE Employee_ID = @Employee_ID";
            SqlParameter[] sqlParameters = new SqlParameter[1];
            sqlParameters[0] = (new SqlParameter("@Employee_ID", employeeNumber));
            ExecuteEditQuery(query, sqlParameters);
        }
    }
}
