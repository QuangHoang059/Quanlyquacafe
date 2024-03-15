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
    public class Dangnhap
    {
        public Dangnhap(string usname,string dlname,int loai,string pw)
        {
            this.Usname = usname;
            this.Dlname = dlname;
            this.Loai = loai;
            this.Pw = pw;
        }

        public Dangnhap(DataRow row)
        {
            this.Usname = row["usename"].ToString();
            this.Dlname = row["dlname"].ToString();
            this.Loai = (int)row["loai"];
            this.Pw = row["pw"].ToString();
        }

        string dlname;
        string usname;
        int loai;
        string pw;

        public string Usname { get => usname; set => usname = value; }
        public string Dlname { get => dlname; set => dlname = value; }
        public string Pw { get => pw; set => pw = value; }
        public int Loai { get => loai; set => loai = value; }
    }
}
