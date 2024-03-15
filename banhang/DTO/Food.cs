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
    public class Food
    {
        public Food(int id, string name, int iDCreat, float gia)
        {
            this.ID = id;
            this.Name = name;
            this.IDCreat = iDCreat;
            this.Gia = gia;       
        }
        public Food(DataRow row)
        {
            this.ID = (int)row["id"];
            this.Name = row["name1"].ToString();
            this.IDCreat =(int)row["idcate"];
            this.Gia = (float)Convert.ToDouble(row["gia"]);
        }
        int iD;
        string name;
        int iDCreat;
        float gia;

        public string Name { get => name; set => name = value; }
        public int IDCreat { get => iDCreat; set => iDCreat = value; }
        public float Gia { get => gia; set => gia = value; }
        public int ID { get => iD; set => iD = value; }
    }
}
