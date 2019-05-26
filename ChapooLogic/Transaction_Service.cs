using ChapooDAL;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChapooLogic
{
    public class Transaction_Service
    {
        Transaction_DAO transaction = new Transaction_DAO();

        /// <summary>
        /// Register user with the values from the textboxes
        /// </summary>
        public void RegisterTransaction(double totalPrice, string comment, int tableID, int employeeID, double totalPaid, DateTime dateTime)
        {
            try
            {
                transaction.Db_Create_Order(totalPrice, comment, tableID, employeeID, totalPaid, dateTime);
            }
            catch (Exception e)
            {
                StreamWriter writer = new StreamWriter("errorLog");
                writer.Write(e);
                writer.Close();

                MessageBox.Show("Something went wrong trying to save the transaction.", "Inserting Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
