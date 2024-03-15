using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace banhang
{
    public  class DataProvider
    {
        private static DataProvider instance=null;
       private string connectionstr = "Data Source=msi\\sqlexpress;Initial Catalog=QuanBanhang;Integrated Security=True";
 

        public static DataProvider Instance {
            get{
                if (instance == null) {
                    instance = new DataProvider();
                    return instance; 
                }
        
                return DataProvider.instance; 
            }
            private set { DataProvider.instance = value; }
        }
        private DataProvider() { }
        public DataTable ExecuteQuery(string query)
        {
            DataTable dataTable = new DataTable();
            using (SqlConnection connection = new SqlConnection(connectionstr))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                adapter.Fill(dataTable);
                connection.Close();
            }    
            return dataTable;
        }
        public int ExecuteNumQuery(string query)
        {
            int num = 0;
            using (SqlConnection connection = new SqlConnection(connectionstr))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                num = command.ExecuteNonQuery();
            }
            
            return num;
        }
        public object ExecuteSalar(string query)
        {
            object num = 0;
            using (SqlConnection connection = new SqlConnection(connectionstr))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                num = command.ExecuteScalar();
            }

            return num;
        }
    }
}
