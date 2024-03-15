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
using System.Security.Cryptography;
namespace banhang
{
   public class DangnhapDAO
    {
        private static DangnhapDAO instance = null;
        private string connectionstr = "Data Source=QUANGHOANG;Initial Catalog=QuanBanhang;Integrated Security=True";
        public static  bool role = true;
        public static string username1;
        public static string pw1;
        public static string dlname1;
        public static DangnhapDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new DangnhapDAO();
                    return instance;
                }

                return DangnhapDAO.instance;
            }
            private set { DangnhapDAO.instance = value; }
        }
        private DangnhapDAO() { }
        private string Format(string a)
        {
            return "'" + a + "'";
        }
        public bool Login(string username, string pw)
        {
            string query = "select *from Dangnhap where usename=" + Format(username)+"and pw="+Format(pw);
            DataTable resul = DataProvider.Instance.ExecuteQuery(query);
            if (resul.Rows.Count > 0)
            {
                DataRow row = resul.Rows[0];
                Dangnhap thongtin = new Dangnhap(row);
                pw1 = thongtin.Pw.ToString();
                username1 = thongtin.Usname;
                dlname1 = thongtin.Dlname;

                if (thongtin.Loai==0)
                    role = false;
                else role = true;
            }
            return resul.Rows.Count > 0;
        }
        public List<Dangnhap> loaddangnhap()
        {
           
                List<Dangnhap> listtaikhoan = new List<Dangnhap>();
                DataTable data = DataProvider.Instance.ExecuteQuery("select *from Dangnhap");
                foreach (DataRow item in data.Rows)
                {
                Dangnhap taikhoan = new Dangnhap(item);
                listtaikhoan.Add(taikhoan);
                }
                return listtaikhoan;
        }
        public bool updatetaikhoan(string username,string dlname,string pw,string newpw)
        {
           int resul = DataProvider.Instance.ExecuteNumQuery("exec pro_updatetaikhoai @username= N'" + username + "', @dlname =N'" + dlname + "', @pw=" + pw + ", @newpw=N'" + newpw+"'");
           
            return resul>0;
        }
        public Dangnhap GetTaikhoan(string username)
        {
            DataTable data = DataProvider.Instance.ExecuteQuery("select *from Dangnhap where usename=N'" + username + "'");
            foreach(DataRow item in data.Rows)
            {
                return new Dangnhap(item);
            }
            return null;
        }
        public List<Dangnhap> SearchTaikhoan(string nametk)
        {
            List<Dangnhap> listTk = new List<Dangnhap>();
            DataTable data = DataProvider.Instance.ExecuteQuery("EXec pro_searchUserName @username =N'" + nametk + "'");
            foreach (DataRow item in data.Rows)
            {
                Dangnhap tk = new Dangnhap(item);
                listTk.Add(tk);
            }
            return listTk;
        }
        public bool ThemTaikhoan(string username, string dlname, int stat)
        {
            int resul = DataProvider.Instance.ExecuteNumQuery(string.Format("insert  Dangnhap values (N'{0}', N'{1}', {2},0)", dlname,  username, stat));
            return resul > 0;
        }
        public bool SuaTaikhoan( string username, string dlname, int loai)
        {
            int resul = DataProvider.Instance.ExecuteNumQuery(string.Format("update Dangnhap set dlname=N'{1}',loai={2} where usename =N'{0}'", username, dlname, loai));
            return resul > 0;
        }
        public bool DeleteTaikhoan(string usname)
        {
            int resul = DataProvider.Instance.ExecuteNumQuery(string.Format("delete Dangnhap where usename =N'{0}'", usname));
            return resul > 0;
        }
        public bool SuaPassw(string usname)
        {
            int resul = DataProvider.Instance.ExecuteNumQuery(string.Format("update Dangnhap set pw=N'0' where usename =N'{0}'", usname));
            return resul > 0;
        }
    }
}
