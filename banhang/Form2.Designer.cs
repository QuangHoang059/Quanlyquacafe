
namespace banhang
{
    partial class Form2
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form2));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.datmon = new System.Windows.Forms.TabPage();
            this.cbbcreatfood = new System.Windows.Forms.ComboBox();
            this.tablebuton = new System.Windows.Forms.FlowLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.swaptable = new System.Windows.Forms.Button();
            this.themmon = new System.Windows.Forms.Button();
            this.chuyenban = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.sluong = new System.Windows.Forms.NumericUpDown();
            this.num = new System.Windows.Forms.NumericUpDown();
            this.hienthi = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.mua = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cantra = new System.Windows.Forms.TextBox();
            this.txbtien = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.menu = new System.Windows.Forms.ListView();
            this.imageList2 = new System.Windows.Forms.ImageList(this.components);
            this.label6 = new System.Windows.Forms.Label();
            this.thongke = new System.Windows.Forms.TabPage();
            this.label7 = new System.Windows.Forms.Label();
            this.sumtien = new System.Windows.Forms.TextBox();
            this.datathongke = new System.Windows.Forms.DataGridView();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.thongke1 = new System.Windows.Forms.Button();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.admin = new System.Windows.Forms.ToolStripMenuItem();
            this.chinhsua = new System.Windows.Forms.ToolStripMenuItem();
            this.taikhoan = new System.Windows.Forms.ToolStripMenuItem();
            this.dangxuat = new System.Windows.Forms.ToolStripMenuItem();
            this.staff = new System.Windows.Forms.ToolStripMenuItem();
            this.doimk1 = new System.Windows.Forms.ToolStripMenuItem();
            this.dxstaff = new System.Windows.Forms.ToolStripMenuItem();
            this.directoryEntry4 = new System.DirectoryServices.DirectoryEntry();
            this.directoryEntry3 = new System.DirectoryServices.DirectoryEntry();
            this.directoryEntry2 = new System.DirectoryServices.DirectoryEntry();
            this.directoryEntry1 = new System.DirectoryServices.DirectoryEntry();
            this.tabControl1.SuspendLayout();
            this.datmon.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sluong)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.num)).BeginInit();
            this.thongke.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.datathongke)).BeginInit();
            this.panel3.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.AccessibleRole = System.Windows.Forms.AccessibleRole.Sound;
            this.tabControl1.AllowDrop = true;
            this.tabControl1.Controls.Add(this.datmon);
            this.tabControl1.Controls.Add(this.thongke);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.ImageList = this.imageList1;
            this.tabControl1.Location = new System.Drawing.Point(0, 28);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(868, 448);
            this.tabControl1.TabIndex = 0;
            // 
            // datmon
            // 
            this.datmon.BackColor = System.Drawing.Color.Transparent;
            this.datmon.Controls.Add(this.cbbcreatfood);
            this.datmon.Controls.Add(this.tablebuton);
            this.datmon.Controls.Add(this.panel1);
            this.datmon.Controls.Add(this.label2);
            this.datmon.Controls.Add(this.menu);
            this.datmon.Controls.Add(this.label6);
            this.datmon.Font = new System.Drawing.Font("Times New Roman", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.World, ((byte)(0)));
            this.datmon.ImageKey = "Jamespeng-Cuisine-Pork-Chop-Set.ico";
            this.datmon.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.datmon.Location = new System.Drawing.Point(4, 32);
            this.datmon.Name = "datmon";
            this.datmon.Padding = new System.Windows.Forms.Padding(3);
            this.datmon.Size = new System.Drawing.Size(860, 412);
            this.datmon.TabIndex = 0;
            this.datmon.Text = "Đặt món";
            // 
            // cbbcreatfood
            // 
            this.cbbcreatfood.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbbcreatfood.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbbcreatfood.FormattingEnabled = true;
            this.cbbcreatfood.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.cbbcreatfood.Location = new System.Drawing.Point(299, 20);
            this.cbbcreatfood.Name = "cbbcreatfood";
            this.cbbcreatfood.Size = new System.Drawing.Size(147, 23);
            this.cbbcreatfood.TabIndex = 11;
            this.cbbcreatfood.Tag = "";
            this.cbbcreatfood.Text = "Tất cả";
            this.cbbcreatfood.SelectedValueChanged += new System.EventHandler(this.cbbcreatfood_SelectedValueChanged);
            // 
            // tablebuton
            // 
            this.tablebuton.AutoScroll = true;
            this.tablebuton.BackColor = System.Drawing.Color.Gainsboro;
            this.tablebuton.Location = new System.Drawing.Point(18, 46);
            this.tablebuton.Name = "tablebuton";
            this.tablebuton.Size = new System.Drawing.Size(199, 361);
            this.tablebuton.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Gainsboro;
            this.panel1.Controls.Add(this.swaptable);
            this.panel1.Controls.Add(this.themmon);
            this.panel1.Controls.Add(this.chuyenban);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.sluong);
            this.panel1.Controls.Add(this.num);
            this.panel1.Controls.Add(this.hienthi);
            this.panel1.Controls.Add(this.mua);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.cantra);
            this.panel1.Controls.Add(this.txbtien);
            this.panel1.Location = new System.Drawing.Point(491, 27);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(350, 380);
            this.panel1.TabIndex = 9;
            // 
            // swaptable
            // 
            this.swaptable.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.swaptable.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.swaptable.Location = new System.Drawing.Point(71, 294);
            this.swaptable.Name = "swaptable";
            this.swaptable.Size = new System.Drawing.Size(91, 32);
            this.swaptable.TabIndex = 13;
            this.swaptable.Text = "Chuyển bàn";
            this.swaptable.UseVisualStyleBackColor = true;
            this.swaptable.Click += new System.EventHandler(this.swaptable_Click);
            // 
            // themmon
            // 
            this.themmon.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.themmon.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.themmon.Location = new System.Drawing.Point(233, 3);
            this.themmon.Name = "themmon";
            this.themmon.Size = new System.Drawing.Size(59, 38);
            this.themmon.TabIndex = 12;
            this.themmon.Text = "Thêm món";
            this.themmon.UseVisualStyleBackColor = true;
            this.themmon.Click += new System.EventHandler(this.themmon_Click);
            // 
            // chuyenban
            // 
            this.chuyenban.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.chuyenban.FormattingEnabled = true;
            this.chuyenban.Location = new System.Drawing.Point(71, 330);
            this.chuyenban.Name = "chuyenban";
            this.chuyenban.Size = new System.Drawing.Size(91, 23);
            this.chuyenban.TabIndex = 11;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.World, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(56, 12);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(69, 19);
            this.label4.TabIndex = 10;
            this.label4.Text = "Số lượng";
            // 
            // sluong
            // 
            this.sluong.Location = new System.Drawing.Point(131, 12);
            this.sluong.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.sluong.Name = "sluong";
            this.sluong.Size = new System.Drawing.Size(61, 22);
            this.sluong.TabIndex = 9;
            this.sluong.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // num
            // 
            this.num.Location = new System.Drawing.Point(180, 328);
            this.num.Name = "num";
            this.num.Size = new System.Drawing.Size(61, 22);
            this.num.TabIndex = 8;
            this.num.ValueChanged += new System.EventHandler(this.num_ValueChanged);
            // 
            // hienthi
            // 
            this.hienthi.BackColor = System.Drawing.Color.White;
            this.hienthi.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4});
            this.hienthi.GridLines = true;
            this.hienthi.HideSelection = false;
            this.hienthi.Location = new System.Drawing.Point(0, 44);
            this.hienthi.Name = "hienthi";
            this.hienthi.Size = new System.Drawing.Size(344, 244);
            this.hienthi.TabIndex = 4;
            this.hienthi.UseCompatibleStateImageBehavior = false;
            this.hienthi.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Tên món ăn";
            this.columnHeader1.Width = 108;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Đơn giá";
            this.columnHeader2.Width = 86;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Số lượng";
            this.columnHeader3.Width = 62;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Thành tiền";
            this.columnHeader4.Width = 101;
            // 
            // mua
            // 
            this.mua.AutoSize = true;
            this.mua.BackgroundImage = global::banhang.Properties.Resources.shop_cart_add_icon1;
            this.mua.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.mua.Font = new System.Drawing.Font("Times New Roman", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.World, ((byte)(0)));
            this.mua.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.mua.ImageKey = "shop-cart-add-icon.png";
            this.mua.Location = new System.Drawing.Point(3, 295);
            this.mua.Name = "mua";
            this.mua.Size = new System.Drawing.Size(50, 29);
            this.mua.TabIndex = 5;
            this.mua.UseVisualStyleBackColor = true;
            this.mua.Click += new System.EventHandler(this.mua_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Times New Roman", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.World, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(176, 353);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(59, 19);
            this.label8.TabIndex = 7;
            this.label8.Text = "Cần trả";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.World, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(176, 300);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 19);
            this.label1.TabIndex = 7;
            this.label1.Text = "Giảm giá";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.World, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(251, 300);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(76, 19);
            this.label3.TabIndex = 7;
            this.label3.Text = "Tổng tiền ";
            // 
            // cantra
            // 
            this.cantra.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cantra.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.cantra.Location = new System.Drawing.Point(247, 356);
            this.cantra.Name = "cantra";
            this.cantra.ReadOnly = true;
            this.cantra.Size = new System.Drawing.Size(97, 21);
            this.cantra.TabIndex = 6;
            this.cantra.Text = "0";
            this.cantra.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txbtien
            // 
            this.txbtien.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbtien.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.txbtien.Location = new System.Drawing.Point(247, 330);
            this.txbtien.Name = "txbtien";
            this.txbtien.ReadOnly = true;
            this.txbtien.Size = new System.Drawing.Size(97, 21);
            this.txbtien.TabIndex = 6;
            this.txbtien.Text = "0";
            this.txbtien.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.label2.Font = new System.Drawing.Font("Times New Roman", 25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.World, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(206, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(0, 29);
            this.label2.TabIndex = 3;
            // 
            // menu
            // 
            this.menu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.menu.HideSelection = false;
            this.menu.LargeImageList = this.imageList2;
            this.menu.Location = new System.Drawing.Point(223, 46);
            this.menu.Name = "menu";
            this.menu.Size = new System.Drawing.Size(262, 361);
            this.menu.TabIndex = 2;
            this.menu.UseCompatibleStateImageBehavior = false;
            this.menu.View = System.Windows.Forms.View.Tile;
            // 
            // imageList2
            // 
            this.imageList2.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList2.ImageStream")));
            this.imageList2.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList2.Images.SetKeyName(0, "shop-cart-add-icon.png");
            this.imageList2.Images.SetKeyName(1, "images.jpg");
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Times New Roman", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.World, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(219, 24);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(58, 19);
            this.label6.TabIndex = 7;
            this.label6.Text = "MENU";
            // 
            // thongke
            // 
            this.thongke.BackColor = System.Drawing.Color.Transparent;
            this.thongke.Controls.Add(this.label7);
            this.thongke.Controls.Add(this.sumtien);
            this.thongke.Controls.Add(this.datathongke);
            this.thongke.Controls.Add(this.panel3);
            this.thongke.ImageKey = "Iconsmind-Outline-Money-2.ico";
            this.thongke.Location = new System.Drawing.Point(4, 32);
            this.thongke.Name = "thongke";
            this.thongke.Padding = new System.Windows.Forms.Padding(3);
            this.thongke.Size = new System.Drawing.Size(860, 412);
            this.thongke.TabIndex = 1;
            this.thongke.Text = "Thống kê";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.LightGray;
            this.label7.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.label7.Font = new System.Drawing.Font("Times New Roman", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(487, 364);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(166, 25);
            this.label7.TabIndex = 3;
            this.label7.Text = "Tổng toàn bộ tiền";
            // 
            // sumtien
            // 
            this.sumtien.Location = new System.Drawing.Point(659, 362);
            this.sumtien.Name = "sumtien";
            this.sumtien.ReadOnly = true;
            this.sumtien.Size = new System.Drawing.Size(119, 27);
            this.sumtien.TabIndex = 2;
            // 
            // datathongke
            // 
            this.datathongke.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.datathongke.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.datathongke.Location = new System.Drawing.Point(70, 59);
            this.datathongke.Name = "datathongke";
            this.datathongke.Size = new System.Drawing.Size(708, 297);
            this.datathongke.TabIndex = 1;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Gainsboro;
            this.panel3.Controls.Add(this.label5);
            this.panel3.Controls.Add(this.thongke1);
            this.panel3.Controls.Add(this.dateTimePicker2);
            this.panel3.Controls.Add(this.dateTimePicker1);
            this.panel3.Location = new System.Drawing.Point(70, 6);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(708, 47);
            this.panel3.TabIndex = 0;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(262, 11);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(72, 19);
            this.label5.TabIndex = 3;
            this.label5.Text = "Đến ngày";
            // 
            // thongke1
            // 
            this.thongke1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.thongke1.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.thongke1.Location = new System.Drawing.Point(604, 9);
            this.thongke1.Name = "thongke1";
            this.thongke1.Size = new System.Drawing.Size(89, 24);
            this.thongke1.TabIndex = 2;
            this.thongke1.Text = "Thống kê";
            this.thongke1.UseVisualStyleBackColor = true;
            this.thongke1.Click += new System.EventHandler(this.thongke1_Click);
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.CalendarFont = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePicker2.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePicker2.Location = new System.Drawing.Point(339, 7);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(241, 24);
            this.dateTimePicker2.TabIndex = 1;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.CalendarFont = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePicker1.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePicker1.Location = new System.Drawing.Point(15, 7);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(241, 24);
            this.dateTimePicker1.TabIndex = 0;
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.DimGray;
            this.imageList1.Images.SetKeyName(0, "Jamespeng-Cuisine-Pork-Chop-Set.ico");
            this.imageList1.Images.SetKeyName(1, "Iconsmind-Outline-Money-2.ico");
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.admin,
            this.staff});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.menuStrip1.Size = new System.Drawing.Size(868, 28);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // admin
            // 
            this.admin.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.chinhsua,
            this.taikhoan,
            this.dangxuat});
            this.admin.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.admin.Name = "admin";
            this.admin.Size = new System.Drawing.Size(71, 24);
            this.admin.Text = "ADMIN";
            // 
            // chinhsua
            // 
            this.chinhsua.Name = "chinhsua";
            this.chinhsua.Size = new System.Drawing.Size(137, 22);
            this.chinhsua.Text = "Chỉnh sửa";
            this.chinhsua.Click += new System.EventHandler(this.chinhsua_Click);
            // 
            // taikhoan
            // 
            this.taikhoan.Name = "taikhoan";
            this.taikhoan.Size = new System.Drawing.Size(137, 22);
            this.taikhoan.Text = "Tài khoản";
            this.taikhoan.Click += new System.EventHandler(this.taikhoan_Click);
            // 
            // dangxuat
            // 
            this.dangxuat.Name = "dangxuat";
            this.dangxuat.Size = new System.Drawing.Size(137, 22);
            this.dangxuat.Text = "Đăng xuất";
            this.dangxuat.Click += new System.EventHandler(this.dangxuat_Click);
            // 
            // staff
            // 
            this.staff.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.doimk1,
            this.dxstaff});
            this.staff.Font = new System.Drawing.Font("Segoe UI", 11.25F);
            this.staff.Name = "staff";
            this.staff.Size = new System.Drawing.Size(60, 24);
            this.staff.Text = "STAFF";
            // 
            // doimk1
            // 
            this.doimk1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.doimk1.Name = "doimk1";
            this.doimk1.Size = new System.Drawing.Size(147, 22);
            this.doimk1.Text = "Đổi mật khẩu";
            this.doimk1.Click += new System.EventHandler(this.doimk1_Click);
            // 
            // dxstaff
            // 
            this.dxstaff.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dxstaff.Name = "dxstaff";
            this.dxstaff.Size = new System.Drawing.Size(147, 22);
            this.dxstaff.Text = "Đăng xuât";
            this.dxstaff.Click += new System.EventHandler(this.dxstaff_Click);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.Moccasin;
            this.ClientSize = new System.Drawing.Size(868, 476);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("Times New Roman", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "Form2";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Đặt món";
            this.Load += new System.EventHandler(this.Form2_Load);
            this.tabControl1.ResumeLayout(false);
            this.datmon.ResumeLayout(false);
            this.datmon.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sluong)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.num)).EndInit();
            this.thongke.ResumeLayout(false);
            this.thongke.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.datathongke)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage datmon;
        private System.Windows.Forms.TabPage thongke;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.ListView menu;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button mua;
        private System.Windows.Forms.TextBox txbtien;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ImageList imageList2;
        private System.Windows.Forms.FlowLayoutPanel tablebuton;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.DataGridView datathongke;
        private System.Windows.Forms.Button thongke1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem admin;
        private System.Windows.Forms.ToolStripMenuItem chinhsua;
        private System.Windows.Forms.ToolStripMenuItem taikhoan;
        private System.Windows.Forms.ToolStripMenuItem dangxuat;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown sluong;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ToolStripMenuItem staff;
        private System.Windows.Forms.ToolStripMenuItem doimk1;
        private System.Windows.Forms.ToolStripMenuItem dxstaff;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ComboBox chuyenban;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cbbcreatfood;
        private System.Windows.Forms.Button themmon;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox cantra;
        private System.Windows.Forms.Button swaptable;
        private System.Windows.Forms.TextBox sumtien;
        private System.Windows.Forms.Label label7;
        private System.DirectoryServices.DirectoryEntry directoryEntry4;
        private System.DirectoryServices.DirectoryEntry directoryEntry3;
        private System.DirectoryServices.DirectoryEntry directoryEntry2;
        private System.DirectoryServices.DirectoryEntry directoryEntry1;
        private System.Windows.Forms.ListView hienthi;
        private System.Windows.Forms.NumericUpDown num;
    }
}