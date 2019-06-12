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
    public class Table_DAO : Base
    {
        // Requests table from the database
        public Table Db_Get_Table(int tableID)
        {
            string query = "SELECT Table_ID, Capacity, InUse FROM [Table] WHERE Table_ID = @tableID";
            SqlParameter[] sqlParameters = new SqlParameter[1];
            sqlParameters[0] = (new SqlParameter("@tableID", tableID));
            return ReadTables(ExecuteSelectQuery(query, sqlParameters));
        }
        // Adds current table to a class
        private Table ReadTables(DataTable dataTable)
        {
            Table table = new Table();

            foreach (DataRow dr in dataTable.Rows)
            {
                table = new Table()
                {
                    TableID = (int)dr["Table_ID"],
                    Capacity = (int)dr["Capacity"],
                    InUse = (bool)dr["InUse"]
                };
            }
            return table;
        }
        public List<int> Db_Get_InUse_Table()
        {
            List<int> tablesInUse = new List<int>();

            string query = "SELECT Table_ID FROM [Table] WHERE InUse = 1;";
            SqlParameter[] sqlParameters = new SqlParameter[0];

            DataTable dataTable = ExecuteSelectQuery(query, sqlParameters);

            foreach (DataRow dr in dataTable.Rows)
            {
                tablesInUse.Add((int)(dr["Table_ID"]));
            }

            return tablesInUse;
        }
    }
}
