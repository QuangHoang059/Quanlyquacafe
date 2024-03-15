using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;
using System.Drawing.Printing;
using COMExcel = Microsoft.Office.Interop.Excel;
namespace banhang
{

    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            loadTable();
            loai();
            showCreatFood();
            loadcbbtable();
          
        }

        #region function

        private void loadTable()
        {
            tablebuton.Controls.Clear();
          List<Table> tablelist=  TableDAO.Instance.LoadTableList();
            foreach(Table item in tablelist)
            {
                Button btn = new Button();
                btn.Width = 60;
                btn.Height = 60;
                btn.Text = item.Name + Environment.NewLine + item.Status;
                btn.Click += Btn_Click;
                btn.Tag = item;
                switch(item.Status)
                {
                    case "Trống": btn.BackColor = Color.Aqua;break;
                    default: btn.BackColor = Color.LightBlue;break;
                }    
                tablebuton.Controls.Add(btn);
            }   
        }

        private void loai()
        {
            if (DangnhapDAO.role)
            {
                staff.Visible = false;
                admin.Text = DangnhapDAO.dlname1 + "( ADMIN)";
            }
            else 
            {
                admin.Visible = false;
                staff.Text = DangnhapDAO.dlname1 + "( Nhân viên)";
            }
           
        }
        float sumbill ;
        private void showbill(int id)
        {
            sumbill = 0;
            CultureInfo culture = new CultureInfo("vi-VN");
            hienthi.Items.Clear();
            List<Hoadon> listbill = HoadonDAO.Instance.GetLisHoadon(id);
            foreach(Hoadon item in listbill)
            {
                ListViewItem listitem = new ListViewItem(item.Foodname.ToString());
                listitem.SubItems.Add(item.Gia.ToString("c",culture));
                listitem.SubItems.Add(item.Cout.ToString());
                listitem.SubItems.Add(item.Thanhtien.ToString("c", culture));
                sumbill += item.Thanhtien;
                hienthi.Items.Add(listitem);
            }
            txbtien.Text = sumbill.ToString("c", culture);
            double tiensau = sumbill - (sumbill / 100) * (int)num.Value;
            cantra.Text = tiensau.ToString("c", culture);
        }

        void loadcbbtable()
        {
            chuyenban.DataSource = TableDAO.Instance.LoadTableList();
            chuyenban.DisplayMember = "Name";
        }
        void showCreatFood()
        {
            cbbcreatfood.Items.Clear();
            List<Creatfood> creatlist = CreatFoodDAO.Instance.LoadCreatFoodList();
            cbbcreatfood.Items.Add("Tất cả");
            foreach(Creatfood item in creatlist)
            {
                cbbcreatfood.Items.Add(item.Name.ToString());
            }    
        }

        void showFood(int id)
        {
            menu.Items.Clear();
            CultureInfo culture = new CultureInfo("vi-VN");
            List<Food> listfood = FoodDAO.Instance.GetFoodbyCreat(id);
            foreach (Food item in listfood)
            {
                ListViewItem listitem = new ListViewItem();
                listitem.Text = item.Name.ToString()+": "+item.Gia.ToString("c", culture);
                menu.Items.Add(listitem);
            }
        }
        void showFood()
        {
            menu.Items.Clear();
            CultureInfo culture = new CultureInfo("vi-VN");
            List<Food> listfood = FoodDAO.Instance.GetFoodbyCreatn();
            foreach (Food item in listfood)
            {
                ListViewItem listitem = new ListViewItem();
                listitem.Text = item.Name.ToString() + ": " + item.Gia.ToString("c", culture);
                menu.Items.Add(listitem);
            }
        }
        void loadthongke(DateTime datein,DateTime dateout)
        {
            CultureInfo culture = new CultureInfo("vi-VN");
            List<Billthongke> listthongke = BillDAO.Instance.loadthongke(datein, dateout);
            datathongke.DataSource = listthongke;
            float tongtienthanhtoan=0;
            foreach (Billthongke item in listthongke)
            {
                tongtienthanhtoan += item.Tongtien;
            }
            sumtien.Text = tongtienthanhtoan.ToString("c", culture);
            datathongke.Columns[0].HeaderText = "Tên bàn";
            datathongke.Columns[1].HeaderText = "Ngày vào";
            datathongke.Columns[2].HeaderText = "Ngày ra";
            datathongke.Columns[3].HeaderText = "Giảm giá";
            datathongke.Columns[4].HeaderText = "Tổng tiền";
        }
        private void Inhoadon()
        {
            COMExcel.Application exApp = new COMExcel.Application();
            COMExcel.Workbook exBook; //Trong 1 chương trình Excel có nhiều Workbook
            COMExcel.Worksheet exSheet; //Trong 1 Workbook có nhiều Worksheet
            COMExcel.Range exRange;
            int hang = 0, cot = 0;
            DataTable tblThongtinHD, tblThongtinHang;
            exBook = exApp.Workbooks.Add(COMExcel.XlWBATemplate.xlWBATWorksheet);
            exSheet = exBook.Worksheets[1];
            // Định dạng chung
            exRange = exSheet.Cells[1, 1];
            exRange.Range["A1:Z300"].Font.Name = "Times new roman"; //Font chữ
            exRange.Range["A1:B3"].Font.Size = 10;
            exRange.Range["A1:B3"].Font.Bold = true;
            exRange.Range["A1:B3"].Font.ColorIndex = 5; //Màu xanh da trời
            exRange.Range["A1:A1"].ColumnWidth = 7;
            exRange.Range["B1:B1"].ColumnWidth = 15;
            exRange.Range["A1:B1"].MergeCells = true;
            exRange.Range["A1:B1"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["A1:B1"].Value = "Quán Cafe";
            exRange.Range["A2:B2"].MergeCells = true;
            exRange.Range["A2:B2"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["A2:B2"].Value = "Đức cơ-Gia lai";
            exRange.Range["A3:B3"].MergeCells = true;
            exRange.Range["A3:B3"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["A3:B3"].Value = "Điện thoại: (09)1234565678";
            exRange.Range["C2:E2"].Font.Size = 16;
            exRange.Range["C2:E2"].Font.Bold = true;
            exRange.Range["C2:E2"].Font.ColorIndex = 3; //Màu đỏ
            exRange.Range["C2:E2"].MergeCells = true;
            exRange.Range["C2:E2"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["C2:E2"].Value = "HÓA ĐƠN BÁN";
            //Thông tin hóa đơn
            exRange.Range["A5:F5"].Font.Bold = true;
            exRange.Range["A5:F5"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["C5:F5"].ColumnWidth = 12;
            exRange.Range["A5:A5"].Value = "STT";
            exRange.Range["B5:B5"].Value = "Tên món ăn";
            exRange.Range["C5:C5"].Value = "Đơn giá";
            exRange.Range["D5:D5"].Value = "Số lượng";
            exRange.Range["E5:E5"].Value = "Thành tiền";
            for (hang = 0; hang < hienthi.Items.Count; hang++)
            {
                //Điền số thứ tự vào cột 1 từ dòng 12
                exSheet.Cells[1][hang + 6] = hang + 1;

                for (cot = 0; cot < hienthi.Columns.Count; cot++)
                //Điền thông tin hàng từ cột thứ 2, dòng 12
                {
                    exSheet.Cells[cot + 2][hang + 6] = hienthi.Items[hang].SubItems[cot].ToString().Split('{', '}')[1];
                }
            }
            exRange = exSheet.Cells[cot][hang + 8];
            exRange.Font.Bold = true;
            exRange.Value2 = "Tổng tiền:";
            exRange = exSheet.Cells[cot + 1][hang + 8];
            exRange.Font.Bold = true;
            exRange.Value2 = txbtien.Text;
            exRange = exSheet.Cells[cot][hang + 9];
            exRange.Font.Bold = true;
            exRange.Value2 = "Giảm giá:";
            exRange = exSheet.Cells[cot + 1][hang + 9];
            exRange.Font.Bold = true;
            exRange.Value2 = num.Value + "%";
            exRange = exSheet.Cells[cot][hang + 10];
            exRange.Font.Bold = true;
            exRange.Value2 = "Số tiền trả:";
            exRange = exSheet.Cells[cot + 1][hang + 10];
            exRange.Font.Bold = true;
            exRange.Value2 = cantra.Text;
            exRange = exSheet.Cells[4][hang + 12]; //Ô A1 
            exRange.Range["A1:C1"].MergeCells = true;
            exRange.Range["A1:C1"].Font.Italic = true;
            exRange.Range["A1:C1"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            DateTime d = DateTime.Now;
            exRange.Range["A1:C1"].Value = "Gia lai, ngày " + d.Day + " tháng " + d.Month + " năm " + d.Year;
            exRange.Range["A2:C2"].MergeCells = true;
            exRange.Range["A2:C2"].Font.Italic = true;
            exRange.Range["A2:C2"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["A2:C2"].Value = "Nhân viên bán hàng";
            exRange.Range["A6:C6"].MergeCells = true;
            exRange.Range["A6:C6"].Font.Italic = true;
            exRange.Range["A6:C6"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            if (DangnhapDAO.role)
                exRange.Range["A6:C6"].Value = admin.Text.ToString().Split('(')[0];
            else exRange.Range["A6:C6"].Value = staff.Text.ToString().Split('(')[0];
            exSheet.Name = "Hóa đơn nhập";
            exApp.Visible = true;
        }
        #endregion
        #region event

        private void cbbcreatfood_SelectedValueChanged(object sender, EventArgs e)
        {
    
            ComboBox a=sender as ComboBox;
            if(a.SelectedItem==null)
            {
                return;
            }
            if (a.SelectedItem.ToString() == "Tất cả") showFood();
            else
            {
                DataTable data = DataProvider.Instance.ExecuteQuery("select *from FoodCate  where name1=N'" + a.SelectedItem.ToString()+"'");
               if(data.Rows.Count>0)
                { 
                    Creatfood fod = new Creatfood(data.Rows[0]);
                    showFood(fod.ID);
                }    
            }
        }
        bool check=false;
        private void Btn_Click(object sender, EventArgs e)
        {
                int tableid = ((sender as Button).Tag as Table).ID;
                hienthi.Tag = (sender as Button).Tag;
                showbill(tableid);
            check = true;
        }

        private void chinhsua_Click(object sender, EventArgs e)
        {
            Form3 f = new Form3();
            f.ThemFood += F_ThemFood;
            f.SuaFood += F_SuaFood;
            f.XoaFood += F_XoaFood;
            f.ThemCate += F_ThemCate;
            f.SuaCate += F_SuaCate;
            f.XoaCate += F_XoaCate;
            f.ThemTable += F_ThemTable;
            f.SuaTable += F_SuaTable;
            f.XoaTable += F_XoaTable;
            f.ShowDialog();
            
        }

 

        private void taikhoan_Click(object sender, EventArgs e)
        {
            Form4 f = new Form4();
            f.Updatetaikhoan1 += F_Updatetaikhoan1;
            f.ShowDialog();
        }


        private void dangxuat_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có muốn đăng xuất không!", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                Form1 f = new Form1();
                this.Visible = false;
                f.ShowDialog();
                this.Close();
            }
        }
        private void dxstaff_Click(object sender, EventArgs e)
        {
           DialogResult result = MessageBox.Show("Bạn có muốn đăng xuất không!", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                Form1 f = new Form1();
                this.Visible = false;
                f.ShowDialog();
                this.Close();
            }
        }
        private void doimk1_Click(object sender, EventArgs e)
        {
            doimkstaff f = new doimkstaff();
            f.Updatetaikhoan1 += F_Updatetaikhoan11;
            f.ShowDialog();
        }

        private void F_Updatetaikhoan1(object sender, Taikhoanevent e)
        {
            admin.Text = e.Acc.Dlname + " (ADMIN)";
        }
        private void F_Updatetaikhoan11(object sender, Taikhoanevent e)
        {
            staff.Text = e.Acc.Dlname + " (Nhân viên)";
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            showFood();

        }

        private void themmon_Click(object sender, EventArgs e)
        {
            if (check)
            {
                string[] cut1 = new string[10];
                if (menu.SelectedItems.Count != 0)
                {

                    ListViewItem item = menu.SelectedItems[0];
                    string[] cut = item.ToString().Split('{');
                    cut1 = cut[1].Split(':');
                    Table table = hienthi.Tag as Table;
                    int idbill = BillDAO.Instance.GetUncheckBillIdByTableFood(table.ID);
                    int idfood1 = -1;
                    DataTable data = DataProvider.Instance.ExecuteQuery("select *from Food  where name1=N'" + cut1[0] + "'");
                    if (data.Rows.Count > 0)
                    {
                        Food fod = new Food(data.Rows[0]);
                        idfood1 = fod.ID;
                    }
                    int sl = (int)sluong.Value;
                    if (idbill == -1)
                    {
                        BillDAO.Instance.thembill(table.ID);
                        BillistDAO.Instance.ThemBillist(BillDAO.Instance.MaxIdBill(), idfood1, sl);
                    }
                    else
                    {
                        BillistDAO.Instance.ThemBillist(idbill, idfood1, sl);
                    }
                    showbill(table.ID);

                }
                else MessageBox.Show("Vui lòng chọn món ăn", "Thống báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                loadTable();
            }
            else MessageBox.Show("Vui lòng chọn bàn","Lỗi",MessageBoxButtons.OK,MessageBoxIcon.Error);
           
        }

        private void mua_Click(object sender, EventArgs e)
        {
            Table table = hienthi.Tag as Table;
            int giamgia = (int)num.Value;
            double tongtien = sumbill;
            double tiensau = tongtien - (tongtien / 100) * giamgia;
            int idbill = BillDAO.Instance.GetUncheckBillIdByTableFood(table.ID);
            if (idbill > -1)
            {
               if( MessageBox.Show(string.Format("Bạn có muốn thanh toán hóa đơn cho bàn {0}\n tổng tiền-(tổng tiền/100) x giảm giá= {1}-({1}/100)*{2}={3} ",table.Name,tongtien,giamgia,tiensau),"Question", MessageBoxButtons.OKCancel, MessageBoxIcon.Question)==DialogResult.OK)
               { 
                        Inhoadon();
                        BillDAO.Instance.checkout(idbill, giamgia, (float)tongtien);
                        showbill(table.ID); 
               }
            }
            loadTable();
           
        }
        private void num_ValueChanged(object sender, EventArgs e)
        {
            CultureInfo culture = new CultureInfo("vi-VN");
            double tiensau = sumbill - (sumbill / 100) * (int)num.Value;
            cantra.Text = tiensau.ToString("c", culture);
        }

        private void swaptable_Click(object sender, EventArgs e)
        {
            int idtable1 = (hienthi.Tag as Table).ID;
            int idtable2 = (chuyenban.SelectedItem as Table).ID;
            if (MessageBox.Show(string.Format("Bạn có muốn chuyển bàn {0} sang bàn {1}", (hienthi.Tag as Table).name, (chuyenban.SelectedItem as Table).Name), "Question", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {   
                TableDAO.Instance.swaptable(idtable1, idtable2);
                loadTable();
            }
        }

        private void thongke1_Click(object sender, EventArgs e)
        {
            loadthongke(dateTimePicker1.Value, dateTimePicker2.Value);
        }
        #endregion
        #region truyendulieutuform3toiform2
     

        private void F_ThemFood(object sender, EventArgs e)
        {

            showFood();
            if (hienthi.Tag != null)
                showbill((hienthi.Tag as Table).ID);
            ComboBox a = sender as ComboBox;
            if (a==null)
            {
                return;
            }
            if (a.SelectedItem.ToString() == "Tất cả") showFood();
            else
            {
                DataTable data = DataProvider.Instance.ExecuteQuery("select *from FoodCate  where name1=N'" + a.SelectedItem.ToString() + "'");
                if (data.Rows.Count > 0)
                {
                    Creatfood fod = new Creatfood(data.Rows[0]);
                    showFood(fod.ID);
                }
            }
      
        }
        private void F_SuaFood(object sender, EventArgs e)
        {

            showFood();
            if (hienthi.Tag != null)
                showbill((hienthi.Tag as Table).ID);
            ComboBox a = sender as ComboBox;
            if (a == null)
            {
                return;
            }
            if (a.SelectedItem.ToString() == "Tất cả") showFood();
            else
            {
                DataTable data = DataProvider.Instance.ExecuteQuery("select *from FoodCate  where name1=N'" + a.SelectedItem.ToString() + "'");
                if (data.Rows.Count > 0)
                {
                    Creatfood fod = new Creatfood(data.Rows[0]);
                    showFood(fod.ID);
                }
            }
       
        }
        private void F_XoaFood(object sender, EventArgs e)
        {

            showFood();
            ComboBox a = sender as ComboBox;
            if (hienthi.Tag != null)
            { showbill((hienthi.Tag as Table).ID); }
            loadTable();
            if (a == null)
            {
                return;
            }
            if (a.SelectedItem.ToString() == "Tất cả") showFood();
            else
            {
                DataTable data = DataProvider.Instance.ExecuteQuery("select *from FoodCate  where name1=N'" + a.SelectedItem.ToString() + "'");
                if (data.Rows.Count > 0)
                {
                    Creatfood fod = new Creatfood(data.Rows[0]);
                    showFood(fod.ID);
                }
            }
           
        }
        private void F_ThemCate(object sender, EventArgs e)
        {
            showCreatFood();
        }
        private void F_SuaCate(object sender, EventArgs e)
        {
            showCreatFood();
        }
        private void F_XoaCate(object sender, EventArgs e)
        {
            showCreatFood();
            loadTable();

            showFood();
            ComboBox a = sender as ComboBox;
            if (hienthi.Tag != null)
            { showbill((hienthi.Tag as Table).ID); }
            if (a == null)
            {
                return;
            }
            if (a.SelectedItem.ToString() == "Tất cả") showFood();
            else
            {
                DataTable data = DataProvider.Instance.ExecuteQuery("select *from FoodCate  where name1=N'" + a.SelectedItem.ToString() + "'");
                if (data.Rows.Count > 0)
                {
                    Creatfood fod = new Creatfood(data.Rows[0]);
                    showFood(fod.ID);
                }
            }
        }
        private void F_ThemTable(object sender, EventArgs e)
        {
            loadthongke(dateTimePicker1.Value, dateTimePicker2.Value);
            loadTable();
            loadcbbtable();
        }
        private void F_SuaTable(object sender, EventArgs e)
        {
            loadthongke(dateTimePicker1.Value, dateTimePicker2.Value);
            loadTable();
            loadcbbtable();

        }
        private void F_XoaTable(object sender, EventArgs e)
        {
            loadthongke(dateTimePicker1.Value, dateTimePicker2.Value);
            loadTable();
            loadcbbtable();

        }



        #endregion



    }
}
