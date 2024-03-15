using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace banhang
{
    public partial class doimkstaff : Form
    {
        public doimkstaff()
        {
            InitializeComponent();
            changtaikhoai();
        }

        void changtaikhoai()
        {
            txbacc.Text = DangnhapDAO.username1;
            txbdis.Text = DangnhapDAO.dlname1;    
        }
        private void thoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        void updatetaikhoan()
        {
            string dlname = txbdis.Text;
            string pw = txbmk.Text;
            string newpw = txbnewpw.Text;
            string pwagain = txbnhapmk.Text;
            string username = txbacc.Text;
            if (!newpw.Equals(pwagain))
            {
                MessageBox.Show("Vui lòng nhập lại mật khẩu trùng với mật khẩu mới");

            }
            else if (pw == "" || pw == null || pw != DangnhapDAO.pw1) MessageBox.Show("Mật khẩu chưa chính sác");
            else
            {
                if (DangnhapDAO.Instance.updatetaikhoan(username, dlname, pw, newpw))
                {
                    MessageBox.Show("Cập nhật thành công");
                    if (updatetaikhoan1 != null) updatetaikhoan1(this, new Taikhoanevent(DangnhapDAO.Instance.GetTaikhoan(username)));
                }
                else MessageBox.Show("Vui lòng nhập đúng mật khẩu");
            }
        }
        private void capnhat_Click(object sender, EventArgs e)
        {
            updatetaikhoan();

        }
        private event EventHandler<Taikhoanevent> updatetaikhoan1;
        public event EventHandler<Taikhoanevent> Updatetaikhoan1
        {
            add { updatetaikhoan1 += value; }
            remove { updatetaikhoan1 += value; }
        }
    }

}
