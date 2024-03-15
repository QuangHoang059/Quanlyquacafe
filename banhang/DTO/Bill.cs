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
    public class Bill
    {
        public Bill(int id, DateTime? datacheckin, DateTime? datacheckout, int status,int giamgia)
        {
            this.ID = id;
            this.Datacheckin = datacheckin;
            this.Datacheckout = datacheckout;
            this.Status = status;
            this.Giamgia = giamgia;
        }
        public Bill(DataRow row)
        {
            this.ID = (int)row["id"];
            var datacheckintemp = row["datein"];
            if (datacheckintemp.ToString() != "")
                this.Datacheckin =(DateTime?) row["datein"];
            var datacheckoutemp = row["dateout"];
            if(datacheckoutemp.ToString()!="")
                 this.Datacheckout = (DateTime?)row["dateout"];
            this.Status = (int)row["stat"];
            if(row["giamgia"].ToString()!="" )
                this.Giamgia = (int)row["giamgia"];
        }
        int iD;
        int status;
        DateTime? datacheckout;
        DateTime? datacheckin;
        int giamgia;
        float tongtien;
        public DateTime? Datacheckin { get => datacheckin; set => datacheckin = value; }
        public DateTime? Datacheckout { get => datacheckout; set => datacheckout = value; }
        public int Status { get => status; set => status = value; }
        public int ID { get => iD; set => iD = value; }
        public int Giamgia { get => giamgia; set => giamgia = value; }
    }
}
