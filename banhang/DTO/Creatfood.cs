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
     public class Creatfood
    {
        public Creatfood(int id, string name)
        {
            this.Name = name;
            this.ID = id;
        }
        public Creatfood(DataRow row)
        {
            this.Name = row["name1"].ToString();
            this.ID = (int)row["id"];
        }
        public string name;
        public int iD;
        public string Name { get => name; set => name = value; }
        public int ID { get => iD; set => iD = value; }
    }
}
