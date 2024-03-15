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
     public class HoadonDAO
    {
        private static HoadonDAO instance = null;

        public static HoadonDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new HoadonDAO();
                    return instance;
                }

                return HoadonDAO.instance;
            }
            private set { HoadonDAO.instance = value; }
        }
        private HoadonDAO() { }
        public List<Hoadon> GetLisHoadon(int id)
        {
            List<Hoadon> listhoadon = new List<Hoadon>();
            DataTable data = DataProvider.Instance.ExecuteQuery("select f.name1, bi.sl, f.gia, f.gia*bi.sl as Thanhtien from Billist as bi, Bill as b, Food as f where bi.idbill = b.id and bi.idfool = f.id and b.stat=0 and b.idtable =" + id);
            foreach(DataRow item in data.Rows)
            {
                Hoadon hoadon = new Hoadon(item);
                listhoadon.Add(hoadon);
            }
            return listhoadon;
        }
    }
}
