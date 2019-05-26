using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Collections.ObjectModel;
using System.Windows.Forms;

namespace ChapooDAL
{
    public class Transaction_DAO : Base
    {
        public void Db_Create_Order(double totalPrice, string comment, int tableID, int employeeID, double totalPaid, DateTime dateTime)
        {
            string query = "INSERT INTO ORDER(Total_Price, Comment, Table_ID, Employee_ID, Total_Paid) VALUES (@totalPrice, @comment, @tableID, @employeeID, @totalPaid)";
            SqlParameter[] sqlParameters = new SqlParameter[4];
            sqlParameters[0] = (new SqlParameter("@totalPrice", totalPrice));
            sqlParameters[1] = (new SqlParameter("@comment", comment));
            sqlParameters[2] = (new SqlParameter("@tableID", tableID));
            sqlParameters[3] = (new SqlParameter("@employeeID", employeeID));
            sqlParameters[4] = (new SqlParameter("@totalPaid", totalPaid));


            SqlConnection conn = OpenConnection();

            ExecuteEditQuery(query, sqlParameters);
            MessageBox.Show("Transaction saved into database!", "Transaction saving completed");
            
            conn.Close();
        }
    }
}
    
