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
    public class Billthongke
    {
        public Billthongke(string name, DateTime? datacheckin, DateTime? datacheckout, int giamgia, float tongtien)
        {
            this.Name=name;
            this.Datacheckin = datacheckin;
            this.Datacheckout = datacheckout;
            this.Giamgia = giamgia;
            this.Tongtien = tongtien;
        }
        public Billthongke(DataRow row)
        {
            this.Name = row["name1"].ToString();
            var datacheckintemp = row["datein"];
            if (datacheckintemp.ToString() != "")
                this.Datacheckin = (DateTime?)row["datein"];
            var datacheckoutemp = row["dateout"];
            if (datacheckoutemp.ToString() != "")
                this.Datacheckout = (DateTime?)row["dateout"];;
            this.Giamgia = (int)row["giamgia"];
            this.Tongtien = (float)Convert.ToDouble(row["tongtien"].ToString());
        }

        string name;
        DateTime? datacheckout;
        DateTime? datacheckin;
        int giamgia;
        float tongtien;
        public string Name { get => name; set => name = value; }
        public DateTime? Datacheckin { get => datacheckin; set => datacheckin = value; }
        public DateTime? Datacheckout { get => datacheckout; set => datacheckout = value; }
        public int Giamgia { get => giamgia; set => giamgia = value; }
        public float Tongtien { get => tongtien; set => tongtien = value; }
       
    }
}
