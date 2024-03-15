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
    public class BillDAO
    {
        private static BillDAO instance = null;

        public static BillDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new BillDAO();
                    return instance;
                }

                return BillDAO.instance;
            }
            private set { BillDAO.instance = value; }
        }
        private BillDAO() { }
        public int GetUncheckBillIdByTableFood(int id)
        {
            DataTable data = DataProvider.Instance.ExecuteQuery("select * from Bill where idtable =" + id + " and stat = 0");
            if (data.Rows.Count > 0)
            {
                Bill bill = new Bill(data.Rows[0]);
                return bill.ID;
            }
            return -1;
        }
        public void thembill(int id)
        {
            DataProvider.Instance.ExecuteNumQuery("exec pro_ThemBill @idtable=N'" + id.ToString() + "'");

        }
        public int MaxIdBill()
        {
            try
            {
                return (int)DataProvider.Instance.ExecuteSalar("select max(id)  from Bill ");
            }
            catch
            {
                return 1;
            }
        }
        public void checkout(int id, int giamgia, float tongtien)
        {
            DataProvider.Instance.ExecuteNumQuery("update Bill set dateout=getdate(), stat =1 , giamgia = " + giamgia.ToString() + ",tongtien=" + tongtien.ToString() + "where id=" + id.ToString());
        }
     
        public List<Billthongke> loadthongke(DateTime datein, DateTime dateout)
        {
            List<Billthongke> listthongke = new List<Billthongke>();
            DataTable data = DataProvider.Instance.ExecuteQuery(" pro_Gethongke @datein='" + datein.ToString().Split(' ')[0] + "', @dateout='" + dateout.ToString().Split(' ')[0] + "'");
            foreach (DataRow item in data.Rows)
            {
                Billthongke bill = new Billthongke(item);
                listthongke.Add(bill);
            }
            return listthongke;
        }
        
    }
}