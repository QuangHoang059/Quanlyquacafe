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
    public partial class Form3 : Form
    {
        BindingSource listfood;
        BindingSource listtable;
        BindingSource listcate;
        public Form3()
        {
            InitializeComponent();
            bindingdata();
            loadfood();
            loadtable();
            loadmuc(); loadmuccbb();
            AddFoodBinding();
            AddMucBinding();
            AddTableBinding();

        }
        #region funsion
        void bindingdata()
        {
            listfood = new BindingSource();
            viewfood.DataSource = listfood;
            listcate = new BindingSource();
            loadcr.DataSource = listcate;
            listtable = new BindingSource();
            viewtable.DataSource = listtable;
        }
        void loadfood()
        {
            listfood.DataSource = FoodDAO.Instance.GetFoodbyCreatn();
            viewfood.Columns[0].HeaderText = "Tên món";
            viewfood.Columns[1].HeaderText = "Mã mục";
            viewfood.Columns[2].HeaderText = "Giá";
            viewfood.Columns[3].HeaderText = "ID";
        }
        void loadtable()
        {
            listtable.DataSource = TableDAO.Instance.LoadTableList();
            viewtable.Columns[1].HeaderText = "Tên bàn";
            viewtable.Columns[2].HeaderText = "Trạng thái";
        }
        void loadmuc()
        {
            listcate.DataSource = CreatFoodDAO.Instance.LoadCreatFoodList();
            loadcr.Columns[0].HeaderText = "Tên mực";
            loadcr.Columns[1].HeaderText = "Mã mục";
        }
        void loadmuccbb()
        {
            cbbmuc.DataSource = CreatFoodDAO.Instance.LoadCreatFoodList();
            cbbmuc.DisplayMember = "Name";
        }
        void AddFoodBinding()
        {
            txbidfood.DataBindings.Add(new Binding("Text", viewfood.DataSource, "ID", true, DataSourceUpdateMode.Never));
            txbnamefood.DataBindings.Add(new Binding("Text", viewfood.DataSource, "Name", true, DataSourceUpdateMode.Never));
            tye.DataBindings.Add(new Binding("Value", viewfood.DataSource, "Gia", true, DataSourceUpdateMode.Never));
        }
        void AddMucBinding()
        {
            txbidcr.DataBindings.Add(new Binding("Text", loadcr.DataSource, "ID", true, DataSourceUpdateMode.Never));
            txbNamecate.DataBindings.Add(new Binding("Text", loadcr.DataSource, "Name", true, DataSourceUpdateMode.Never));

        }
        void AddTableBinding()
        {
            txbidtable.DataBindings.Add(new Binding("Text", viewtable.DataSource, "ID", true, DataSourceUpdateMode.Never));
            txbnametable.DataBindings.Add(new Binding("Text", viewtable.DataSource, "Name", true, DataSourceUpdateMode.Never));
            txbstat.DataBindings.Add(new Binding("Text", viewtable.DataSource, "Status", true, DataSourceUpdateMode.Never));
        }
        private void txbidfood_TextChanged(object sender, EventArgs e)
        {
         
                if (viewfood.SelectedCells.Count > 0)
                {
                    int id = (int)viewfood.SelectedCells[0].OwningRow.Cells["IDCreat"].Value;
                    Creatfood namecate = CreatFoodDAO.Instance.GetNamecatebyId(id);
                    int index = -1;
                    int i = 0;
                    foreach (Creatfood item in cbbmuc.Items)
                    {
                        if (item.ID == namecate.ID)
                        {
                            index = i;
                            break;
                        }
                        i++;
                    }
                    cbbmuc.SelectedIndex = index;
                }
           
        }
        #endregion
        #region event
        private void viewf_Click(object sender, EventArgs e)
        {
            loadfood();
        }

        private void viewb_Click(object sender, EventArgs e)
        {
            loadtable();
        }

        private void viewcr_Click(object sender, EventArgs e)
        {
            loadmuc();
        }
        private void findf_Click(object sender, EventArgs e)
        {
            listfood.DataSource = FoodDAO.Instance.SearchFood(txbviewf.Text);
        }

        private void findcr_Click(object sender, EventArgs e)
        {
            listcate.DataSource = CreatFoodDAO.Instance.SearchFoodCate(tbxcr.Text);
        }
        private void findb_Click(object sender, EventArgs e)
        {
            listtable.DataSource = TableDAO.Instance.SearchTable(txbtable.Text);
        }

        private void addfood_Click(object sender, EventArgs e)
        {
            string name = txbnamefood.Text;
            int idcate = (cbbmuc.SelectedItem as Creatfood).ID;
            float gia = (float)tye.Value;
            if (FoodDAO.Instance.ThemFood(name, idcate, gia))
            {
                MessageBox.Show("Thêm món thành công");
                loadfood();
                if (themFood != null) themFood(this, new EventArgs());
            }
            else MessageBox.Show("Có lỗi khi thêm món", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void addtb_Click(object sender, EventArgs e)
        {
            string name = txbnametable.Text;
            if (TableDAO.Instance.ThemTable(name))
            {
                MessageBox.Show("Thêm bàn thành công");
                loadtable();
                if (themTable != null) themTable(this, new EventArgs());
            }
            else MessageBox.Show("Có lỗi khi thêm bàn", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);

        }

        private void addcr_Click(object sender, EventArgs e)
        {
            string name = txbNamecate.Text;
            if (CreatFoodDAO.Instance.ThemCateFood(name))
            {
                MessageBox.Show("Thêm mục thành công");
                loadmuc();
                cbbmuc.DataSource = CreatFoodDAO.Instance.LoadCreatFoodList();
                if (themCate != null) themCate(this, new EventArgs());
            }
            else MessageBox.Show("Có lỗi khi thêm mục", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
        private void editfood_Click(object sender, EventArgs e)
        {
            string name = txbnamefood.Text;
            int idcate = (cbbmuc.SelectedItem as Creatfood).ID;
            float gia = (float)tye.Value;
            int id = Convert.ToInt32(txbidfood.Text);
            if (FoodDAO.Instance.SuaFood(id, name, idcate, gia))
            {
                MessageBox.Show("Sửa món thành công");
                loadfood();
                if (suaFood != null) suaFood(this, new EventArgs());
            }
            else MessageBox.Show("Có lỗi khi sửa món", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void editcr_Click(object sender, EventArgs e)
        {
            string name = txbNamecate.Text;
            int id = Convert.ToInt32(txbidcr.Text);
            if (CreatFoodDAO.Instance.SuaCateFood(id, name))
            {
                MessageBox.Show("Sửa mục thành công");
                loadmuc();
                cbbmuc.DataSource = CreatFoodDAO.Instance.LoadCreatFoodList();
                if (suaCate != null) suaCate(this, new EventArgs());
            }
            else MessageBox.Show("Có lỗi khi sửa mục", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void edittable_Click(object sender, EventArgs e)
        {
            string name = txbnametable.Text;
            int id = Convert.ToInt32(txbidtable.Text);
            if (TableDAO.Instance.SuaTable(id, name))
            {
                MessageBox.Show("Thêm bàn thành công");
                loadtable();
                if (suaTable != null) suaTable(this, new EventArgs());
            }
            else MessageBox.Show("Có lỗi khi thêm bàn", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }


        private void deletefood_Click(object sender, EventArgs e)
        {

            int id = Convert.ToInt32(txbidfood.Text);
            if (FoodDAO.Instance.DeleteFood(id))
            {
                MessageBox.Show("Xóa món thành công");
                loadfood();
                if (xoaFood != null) xoaFood(this, new EventArgs());
            }
            else MessageBox.Show("Có lỗi khi xóa món", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void deletecr_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(txbidcr.Text);
            if (CreatFoodDAO.Instance.DeleteCateFood(id))
            {
                MessageBox.Show("Xóa mục thành công");
                loadmuc();
                cbbmuc.DataSource = CreatFoodDAO.Instance.LoadCreatFoodList();
                viewfood.DataSource = FoodDAO.Instance.GetFoodbyCreatn();
                if (xoaCate != null) xoaCate(this, new EventArgs());

            }
            else MessageBox.Show("Có lỗi khi xóa mục", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void deletetable_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(txbidtable.Text);
            if (TableDAO.Instance.DelteTable(id))
            {
                MessageBox.Show("Xóa bàn thành công");
                loadtable();
                if (xoaTable != null) xoaTable(this, new EventArgs());
            }
            else MessageBox.Show("Có lỗi khi xóa bàn", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
        #endregion
        #region eventloadform2
        private event EventHandler themFood;
        public event EventHandler ThemFood
        {
            add { themFood += value; }
            remove { themFood -= value; }
        }
        private event EventHandler suaFood;
        public event EventHandler SuaFood
        {
            add { suaFood += value; }
            remove { suaFood -= value; }
        }
        private event EventHandler xoaFood;
        public event EventHandler XoaFood
        {
            add { xoaFood += value; }
            remove { xoaFood -= value; }
        }



        private event EventHandler themTable;
        public event EventHandler ThemTable
        {
            add { themTable += value; }
            remove { themTable -= value; }
        }
        private event EventHandler suaTable;
        public event EventHandler SuaTable
        {
            add { suaTable += value; }
            remove { suaTable -= value; }
        }
        private event EventHandler xoaTable;
        public event EventHandler XoaTable
        {
            add { xoaTable += value; }
            remove { xoaTable -= value; }
        }




        private event EventHandler themCate;
        public event EventHandler ThemCate
        {
            add { themCate += value; }
            remove { themCate -= value; }
        }
        private event EventHandler suaCate;
        public event EventHandler SuaCate
        {
            add { suaCate += value; }
            remove { suaCate -= value; }
        }
        private event EventHandler xoaCate;
        public event EventHandler XoaCate
        {
            add { xoaCate += value; }
            remove { xoaCate -= value; }
        }

        #endregion

        
    }
}
