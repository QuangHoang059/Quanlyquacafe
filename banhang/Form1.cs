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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
  
        private void button2_Click(object sender, EventArgs e)
        {
            string username = tk.Text;
            string pw = matkhau.Text;
          if (DangnhapDAO.Instance.Login(username, pw))
            {
                Form2 f = new Form2();
                this.Visible = false;
                f.ShowDialog();
                this.Close();
            }
            else
            {
                MessageBox.Show("Sai tên hoặc mật khẩu!", "Cảnh báo", MessageBoxButtons.OK,MessageBoxIcon.Warning);
            }
        }

    
    }
}
