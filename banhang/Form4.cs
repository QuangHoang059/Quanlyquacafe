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
    public partial class Form4 : Form
    {
        BindingSource listTaikhoan;
        public Form4()
        {
            InitializeComponent();
            BindingData();
            loadDangnhap();
            AddBindingTaikhoan();
            
            changtaikhoai();
        }


        #region funtion
        void BindingData() {
            listTaikhoan = new BindingSource();
            viewtk1.DataSource = listTaikhoan;
        }
        void loadDangnhap()
        {
            listTaikhoan.DataSource = DangnhapDAO.Instance.loaddangnhap();
            viewtk1.Columns[0].HeaderText = "Tên đăng nhập";
            viewtk1.Columns[1].HeaderText = "Tên hiện thị";
            viewtk1.Columns[2].HeaderText = "Mật khẩu";
            viewtk1.Columns[3].HeaderText = "Phân loại";
        }
        void AddBindingTaikhoan()
        {
            txbuser.DataBindings.Add(new Binding("Text", viewtk1.DataSource, "Usname",true,DataSourceUpdateMode.Never));
            txbnametk.DataBindings.Add(new Binding("Text", viewtk1.DataSource, "Dlname", true, DataSourceUpdateMode.Never));
            tyetk.DataBindings.Add(new Binding("Value", viewtk1.DataSource, "Loai", true, DataSourceUpdateMode.Never));
        }
        void changtaikhoai()
        {
            txbacc.Text = DangnhapDAO.username1;
            txbdis.Text = DangnhapDAO.dlname1;
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
            else if (pw == "" || pw == null||pw!=DangnhapDAO.pw1) MessageBox.Show("Mật khẩu chưa chính sác");
            else
            {
                if (DangnhapDAO.Instance.updatetaikhoan(username, dlname, pw, newpw))
                {
                    MessageBox.Show("Cập nhật thành công");
                    if (updatetaikhoan1 != null) updatetaikhoan1(this,new Taikhoanevent( DangnhapDAO.Instance.GetTaikhoan(username)));
                }
                else MessageBox.Show("Vui lòng nhập đúng mật khẩu");
            }    
        }
        #endregion

        #region event

        private event EventHandler<Taikhoanevent> updatetaikhoan1;
        public event EventHandler<Taikhoanevent> Updatetaikhoan1
        {
            add { updatetaikhoan1 += value; }
            remove { updatetaikhoan1 += value; }
        }
        private void findtk_Click(object sender, EventArgs e)
        {
            listTaikhoan.DataSource = DangnhapDAO.Instance.SearchTaikhoan(txbviewtk.Text);
        }

        private void editmk_Click(object sender, EventArgs e)
        {
            string username = txbuser.Text;


            if (DangnhapDAO.Instance.SuaPassw(username))
            {
                MessageBox.Show("Đặt lại mật khẩu thành công");
                loadDangnhap();

            }
            else MessageBox.Show("Có lỗi khi đặt lại mật khẩu", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
        
        private void thoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void capnhat_Click(object sender, EventArgs e)
        {
            updatetaikhoan();
        }
        private void viewtk_Click(object sender, EventArgs e)
        {
            loadDangnhap();
        }
        private void addtk_Click(object sender, EventArgs e)
        {
                string username = txbuser.Text;
                string dlname = txbnametk.Text;
                int tye = (int)tyetk.Value;
                
                if (DangnhapDAO.Instance.ThemTaikhoan(username, dlname, tye))
                {
                    MessageBox.Show("Thêm tài khoản thành công");
                    loadDangnhap();

                }
                else MessageBox.Show("Có lỗi khi thêm tài khoản", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }


        private void edittk_Click(object sender, EventArgs e)
        {
            string username = txbuser.Text;
            string dlname = txbnametk.Text;
            int tye = (int)tyetk.Value;
            if (DangnhapDAO.Instance.SuaTaikhoan(username,dlname,tye))
            {
                MessageBox.Show("Sửa tài khoản thành công");
                loadDangnhap();
                if (updatetaikhoan1 != null) updatetaikhoan1(this, new Taikhoanevent(DangnhapDAO.Instance.GetTaikhoan(username)));
            }
            else MessageBox.Show("Tên đăng nhập không đúng", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
        private void deletetk_Click(object sender, EventArgs e)
        {
            string username = txbuser.Text;
           if (username!=DangnhapDAO.username1)
            {
                if (DangnhapDAO.Instance.DeleteTaikhoan(username))
                {
                    MessageBox.Show("Xóa tài khoản thành công");
                    loadDangnhap();
                }
                else MessageBox.Show("Tên đăng nhập không đúng", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else MessageBox.Show("Không thể xóa tài khoản đang sử dụng", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
        #endregion


    }

    public class Taikhoanevent:EventArgs
    {
        private Dangnhap acc;

        public Dangnhap Acc 
        { get { return acc; }
           set { acc = value; }
        }
        public Taikhoanevent(Dangnhap acc)
        {
            this.Acc=acc;
        }
    }
}
