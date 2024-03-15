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
    public class Hoadon
    {
        public Hoadon(string foodname, int cout, float gia, float thanhtien=0)
        {
            this.Foodname = foodname;
            this.Cout = cout;
            this.Gia = gia;
            this.Thanhtien = thanhtien;
        }
        public Hoadon(DataRow row)
        {
            this.Foodname =row["name1"].ToString();
            this.Cout =(int) row["sl"];
            this.Gia = (float)Convert.ToDouble(row["gia"].ToString());
            this.Thanhtien = (float)Convert.ToDouble(row["Thanhtien"].ToString());
        }
        float thanhtien;
        float gia;
        int cout;
        string foodname;

     
        public int Cout { get => cout; set => cout = value; }
        public float Gia { get => gia; set => gia = value; }
        public float Thanhtien { get => thanhtien; set => thanhtien = value; }
        public string Foodname { get => foodname; set => foodname = value; }
    }
}
