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
    public class Billist
    {
        public Billist(int id, int billid, int foodid, int cout)
        {
            this.Cout = cout;
            this.Id = id;
            this.Foodid = foodid;
            this.Billid = billid;
        }
        public Billist(DataRow row)
        {
            this.Cout = (int)row["sl"];
            this.Id = (int)row["id"];
            this.Foodid = (int)row["idfool"];
            this.Billid = (int)row["idbill"];
        }
        int cout;
        int foodid;
        int billid;
        int id;

        public int Id { get => id; set => id = value; }
        public int Billid { get => billid; set => billid = value; }
        public int Foodid { get => foodid; set => foodid = value; }
        public int Cout { get => cout; set => cout = value; }
    }
}
