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
    public class BillistDAO
    {
        private static BillistDAO instance = null;

        public static BillistDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new BillistDAO();
                    return instance;
                }

                return BillistDAO.instance;
            }
            private set { BillistDAO.instance = value; }
        }
        private BillistDAO() { }
        public List<Billist> GetlistBillists(int id)
        {
            List<Billist> listbill = new List<Billist>();
            DataTable data=DataProvider.Instance.ExecuteQuery("select * from Billist where idbill =" + id);
            foreach(DataRow item in data.Rows)
            {
                Billist info = new Billist(item);
                listbill.Add(info);
            }
            return listbill;
        }
        public void ThemBillist(int idbill,int idfood,int cout)
        {
           DataProvider.Instance.ExecuteNumQuery("exec pro_ThemBillist @idbill=" + idbill.ToString()+ ","
                                                                + " @idfool =" + idfood.ToString() + ", "
                                                                + "@sl =" + cout.ToString() );
        }
        public void DeleteBillisstByIdfood(int idfood)
        {
            DataProvider.Instance.ExecuteQuery("delete Billist where idfool=" + idfood.ToString());
        }

    }
}
