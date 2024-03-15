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
    public class TableDAO
    {
        private static TableDAO instance = null;

        public static TableDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new TableDAO();
                    return instance;
                }

                return TableDAO.instance;
            }
            private set { TableDAO.instance = value; }
        }
        private TableDAO() { }
        public  List<Table> LoadTableList()
        {
            List<Table> tablelist = new List<Table>();
            DataTable data = DataProvider.Instance.ExecuteQuery("exec pro_GetTableList");
            foreach(DataRow item in data.Rows)
            {
                Table table = new Table(item);
                tablelist.Add(table);
            }    
            return tablelist;
        }

        public void swaptable(int idtable1,int idtable2)
        {
            DataProvider.Instance.ExecuteQuery("exec USP_SwapTable @idtable1=" + idtable1.ToString() + ", @idtable2=" + idtable2.ToString());
        }
        public List<Table> SearchTable(string nametable)
        {
            List<Table> listtalbe = new List<Table>();
            DataTable data = DataProvider.Instance.ExecuteQuery("exec pro_searchTableFood  @name=N'" + nametable + "'");
            foreach (DataRow item in data.Rows)
            {
                Table table = new Table(item);
                listtalbe.Add(table);
            }
            return listtalbe;
        }
        public bool ThemTable(string name)
        {
            int resul = DataProvider.Instance.ExecuteNumQuery(string.Format("insert  TableFood (name1) values (N'{0}') ", name));
            return resul > 0;
        }
        public bool SuaTable(int idtable,string name)
        {
            int resul = DataProvider.Instance.ExecuteNumQuery(string.Format("update TableFood set name1=N'{0}' where id={1} ", name,idtable));
            return resul > 0;
        }
        public bool DelteTable(int idtable)
        {
            int resul = DataProvider.Instance.ExecuteNumQuery(string.Format("exec  Pro_DeleteTable @idtable ={0}", idtable));
            return resul > 0;
        }
    }
}
