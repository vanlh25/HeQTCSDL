namespace WFQLDatXeTrucTuyen
{
    partial class FrmKhuyenMai
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
            this.date_NgayAD = new System.Windows.Forms.DateTimePicker();
            this.date_NgayKT = new System.Windows.Forms.DateTimePicker();
            this.txt_MucGiam = new System.Windows.Forms.TextBox();
            this.label_MucGiam = new System.Windows.Forms.Label();
            this.label_NgayKT = new System.Windows.Forms.Label();
            this.dgvKhuyenMai = new System.Windows.Forms.DataGridView();
            this.MaKM = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TenChuongTrinh = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NgayAD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NgayKT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MucGiam = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txt_TenChuongTrinh = new System.Windows.Forms.TextBox();
            this.panel_KhuyenMai = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label_TenChuongTrinh = new System.Windows.Forms.Label();
            this.txt_MaKM = new System.Windows.Forms.TextBox();
            this.label_NgayAD = new System.Windows.Forms.Label();
            this.label_MaKM = new System.Windows.Forms.Label();
            this.txtTimKiem = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnTimKiem = new System.Windows.Forms.Button();
            this.rjButton1 = new WFQLDatXeTrucTuyen.RJControls.RJButton();
            this.btnLuu = new WFQLDatXeTrucTuyen.RJControls.RJButton();
            this.btnHuyBo = new WFQLDatXeTrucTuyen.RJControls.RJButton();
            this.btnXoa = new WFQLDatXeTrucTuyen.RJControls.RJButton();
            this.btnThem = new WFQLDatXeTrucTuyen.RJControls.RJButton();
            this.btnSua = new WFQLDatXeTrucTuyen.RJControls.RJButton();
            this.btnReload = new WFQLDatXeTrucTuyen.RJControls.RJButton();
            ((System.ComponentModel.ISupportInitialize)(this.dgvKhuyenMai)).BeginInit();
            this.panel_KhuyenMai.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // date_NgayAD
            // 
            this.date_NgayAD.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.date_NgayAD.Location = new System.Drawing.Point(272, 71);
            this.date_NgayAD.Name = "date_NgayAD";
            this.date_NgayAD.Size = new System.Drawing.Size(279, 22);
            this.date_NgayAD.TabIndex = 43;
            // 
            // date_NgayKT
            // 
            this.date_NgayKT.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.date_NgayKT.Location = new System.Drawing.Point(834, 71);
            this.date_NgayKT.Name = "date_NgayKT";
            this.date_NgayKT.Size = new System.Drawing.Size(344, 22);
            this.date_NgayKT.TabIndex = 40;
            // 
            // txt_MucGiam
            // 
            this.txt_MucGiam.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_MucGiam.Location = new System.Drawing.Point(272, 115);
            this.txt_MucGiam.Multiline = true;
            this.txt_MucGiam.Name = "txt_MucGiam";
            this.txt_MucGiam.Size = new System.Drawing.Size(279, 25);
            this.txt_MucGiam.TabIndex = 39;
            // 
            // label_MucGiam
            // 
            this.label_MucGiam.AutoSize = true;
            this.label_MucGiam.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F);
            this.label_MucGiam.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label_MucGiam.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label_MucGiam.Location = new System.Drawing.Point(3, 105);
            this.label_MucGiam.Name = "label_MucGiam";
            this.label_MucGiam.Padding = new System.Windows.Forms.Padding(90, 0, 0, 0);
            this.label_MucGiam.Size = new System.Drawing.Size(210, 27);
            this.label_MucGiam.TabIndex = 38;
            this.label_MucGiam.Text = "Mức Giảm: ";
            this.label_MucGiam.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label_NgayKT
            // 
            this.label_NgayKT.AutoSize = true;
            this.label_NgayKT.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F);
            this.label_NgayKT.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label_NgayKT.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label_NgayKT.Location = new System.Drawing.Point(557, 59);
            this.label_NgayKT.Name = "label_NgayKT";
            this.label_NgayKT.Padding = new System.Windows.Forms.Padding(70, 0, 0, 0);
            this.label_NgayKT.Size = new System.Drawing.Size(220, 27);
            this.label_NgayKT.TabIndex = 37;
            this.label_NgayKT.Text = "Ngày kết thúc:";
            // 
            // dgvKhuyenMai
            // 
            this.dgvKhuyenMai.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvKhuyenMai.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvKhuyenMai.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MaKM,
            this.TenChuongTrinh,
            this.NgayAD,
            this.NgayKT,
            this.MucGiam});
            this.dgvKhuyenMai.Location = new System.Drawing.Point(12, 106);
            this.dgvKhuyenMai.Name = "dgvKhuyenMai";
            this.dgvKhuyenMai.RowHeadersWidth = 51;
            this.dgvKhuyenMai.RowTemplate.Height = 24;
            this.dgvKhuyenMai.Size = new System.Drawing.Size(1181, 241);
            this.dgvKhuyenMai.TabIndex = 119;
            this.dgvKhuyenMai.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvKhuyenMai_CellClick);
            // 
            // MaKM
            // 
            this.MaKM.DataPropertyName = "MaKM";
            this.MaKM.HeaderText = "Mã Khuyến Mãi";
            this.MaKM.MinimumWidth = 6;
            this.MaKM.Name = "MaKM";
            this.MaKM.Width = 125;
            // 
            // TenChuongTrinh
            // 
            this.TenChuongTrinh.DataPropertyName = "TenChuongTrinh";
            this.TenChuongTrinh.HeaderText = "Tên Chương trình";
            this.TenChuongTrinh.MinimumWidth = 6;
            this.TenChuongTrinh.Name = "TenChuongTrinh";
            this.TenChuongTrinh.Width = 125;
            // 
            // NgayAD
            // 
            this.NgayAD.DataPropertyName = "NgayAD";
            this.NgayAD.HeaderText = "Ngày áp dụng";
            this.NgayAD.MinimumWidth = 6;
            this.NgayAD.Name = "NgayAD";
            this.NgayAD.Width = 125;
            // 
            // NgayKT
            // 
            this.NgayKT.DataPropertyName = "NgayKT";
            this.NgayKT.HeaderText = "Ngày kết thúc";
            this.NgayKT.MinimumWidth = 6;
            this.NgayKT.Name = "NgayKT";
            this.NgayKT.Width = 125;
            // 
            // MucGiam
            // 
            this.MucGiam.DataPropertyName = "MucGiam";
            this.MucGiam.HeaderText = "Mức Giảm";
            this.MucGiam.MinimumWidth = 6;
            this.MucGiam.Name = "MucGiam";
            this.MucGiam.Width = 125;
            // 
            // txt_TenChuongTrinh
            // 
            this.txt_TenChuongTrinh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_TenChuongTrinh.Location = new System.Drawing.Point(834, 26);
            this.txt_TenChuongTrinh.Multiline = true;
            this.txt_TenChuongTrinh.Name = "txt_TenChuongTrinh";
            this.txt_TenChuongTrinh.Size = new System.Drawing.Size(344, 27);
            this.txt_TenChuongTrinh.TabIndex = 34;
            // 
            // panel_KhuyenMai
            // 
            this.panel_KhuyenMai.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel_KhuyenMai.BackColor = System.Drawing.Color.DodgerBlue;
            this.panel_KhuyenMai.Controls.Add(this.tableLayoutPanel1);
            this.panel_KhuyenMai.Location = new System.Drawing.Point(12, 353);
            this.panel_KhuyenMai.Name = "panel_KhuyenMai";
            this.panel_KhuyenMai.Size = new System.Drawing.Size(1181, 150);
            this.panel_KhuyenMai.TabIndex = 116;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 22.86198F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 24.21677F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 23.53937F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 29.55123F));
            this.tableLayoutPanel1.Controls.Add(this.date_NgayKT, 3, 2);
            this.tableLayoutPanel1.Controls.Add(this.date_NgayAD, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.txt_TenChuongTrinh, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.label_NgayKT, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.txt_MucGiam, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.label_TenChuongTrinh, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.txt_MaKM, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.label_NgayAD, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.label_MucGiam, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.label_MaKM, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 35.38462F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 34.25926F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1181, 150);
            this.tableLayoutPanel1.TabIndex = 130;
            // 
            // label_TenChuongTrinh
            // 
            this.label_TenChuongTrinh.AutoSize = true;
            this.label_TenChuongTrinh.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F);
            this.label_TenChuongTrinh.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label_TenChuongTrinh.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label_TenChuongTrinh.Location = new System.Drawing.Point(557, 20);
            this.label_TenChuongTrinh.Name = "label_TenChuongTrinh";
            this.label_TenChuongTrinh.Padding = new System.Windows.Forms.Padding(70, 0, 0, 0);
            this.label_TenChuongTrinh.Size = new System.Drawing.Size(246, 27);
            this.label_TenChuongTrinh.TabIndex = 1;
            this.label_TenChuongTrinh.Text = "Tên chương trình:";
            // 
            // txt_MaKM
            // 
            this.txt_MaKM.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_MaKM.Location = new System.Drawing.Point(272, 26);
            this.txt_MaKM.Multiline = true;
            this.txt_MaKM.Name = "txt_MaKM";
            this.txt_MaKM.Size = new System.Drawing.Size(279, 27);
            this.txt_MaKM.TabIndex = 2;
            // 
            // label_NgayAD
            // 
            this.label_NgayAD.AutoSize = true;
            this.label_NgayAD.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F);
            this.label_NgayAD.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label_NgayAD.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label_NgayAD.Location = new System.Drawing.Point(3, 59);
            this.label_NgayAD.Name = "label_NgayAD";
            this.label_NgayAD.Padding = new System.Windows.Forms.Padding(90, 0, 0, 0);
            this.label_NgayAD.Size = new System.Drawing.Size(243, 27);
            this.label_NgayAD.TabIndex = 3;
            this.label_NgayAD.Text = "Ngày áp dụng:";
            this.label_NgayAD.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label_MaKM
            // 
            this.label_MaKM.AutoSize = true;
            this.label_MaKM.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F);
            this.label_MaKM.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label_MaKM.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label_MaKM.Location = new System.Drawing.Point(3, 20);
            this.label_MaKM.Name = "label_MaKM";
            this.label_MaKM.Padding = new System.Windows.Forms.Padding(90, 0, 0, 0);
            this.label_MaKM.Size = new System.Drawing.Size(177, 27);
            this.label_MaKM.TabIndex = 26;
            this.label_MaKM.Text = "Mã KM:";
            this.label_MaKM.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtTimKiem
            // 
            this.txtTimKiem.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTimKiem.ForeColor = System.Drawing.Color.Gray;
            this.txtTimKiem.Location = new System.Drawing.Point(12, 9);
            this.txtTimKiem.Margin = new System.Windows.Forms.Padding(4);
            this.txtTimKiem.Multiline = true;
            this.txtTimKiem.Name = "txtTimKiem";
            this.txtTimKiem.Size = new System.Drawing.Size(414, 36);
            this.txtTimKiem.TabIndex = 127;
            this.txtTimKiem.Text = "Search";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(254)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label2.Location = new System.Drawing.Point(14, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(0, 25);
            this.label2.TabIndex = 128;
            // 
            // btnTimKiem
            // 
            this.btnTimKiem.BackColor = System.Drawing.SystemColors.Control;
            this.btnTimKiem.BackgroundImage = global::WFQLDatXeTrucTuyen.Properties.Resources.Very_Basic_Search_icon2;
            this.btnTimKiem.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnTimKiem.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control;
            this.btnTimKiem.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(254)));
            this.btnTimKiem.Location = new System.Drawing.Point(433, 8);
            this.btnTimKiem.Name = "btnTimKiem";
            this.btnTimKiem.Size = new System.Drawing.Size(41, 39);
            this.btnTimKiem.TabIndex = 129;
            this.btnTimKiem.UseVisualStyleBackColor = false;
            this.btnTimKiem.Click += new System.EventHandler(this.btnTimKiem_Click_1);
            // 
            // rjButton1
            // 
            this.rjButton1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rjButton1.BackColor = System.Drawing.Color.Blue;
            this.rjButton1.BackgroundColor = System.Drawing.Color.Blue;
            this.rjButton1.BorderColor = System.Drawing.Color.Crimson;
            this.rjButton1.BorderRadius = 10;
            this.rjButton1.BorderSize = 0;
            this.rjButton1.FlatAppearance.BorderSize = 0;
            this.rjButton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rjButton1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rjButton1.ForeColor = System.Drawing.Color.White;
            this.rjButton1.Location = new System.Drawing.Point(12, 60);
            this.rjButton1.Name = "rjButton1";
            this.rjButton1.Size = new System.Drawing.Size(1181, 40);
            this.rjButton1.TabIndex = 136;
            this.rjButton1.Text = "Danh Sách Khuyến Mãi";
            this.rjButton1.TextColor = System.Drawing.Color.White;
            this.rjButton1.UseVisualStyleBackColor = false;
            // 
            // btnLuu
            // 
            this.btnLuu.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnLuu.BackColor = System.Drawing.SystemColors.Control;
            this.btnLuu.BackgroundColor = System.Drawing.SystemColors.Control;
            this.btnLuu.BorderColor = System.Drawing.Color.DodgerBlue;
            this.btnLuu.BorderRadius = 20;
            this.btnLuu.BorderSize = 2;
            this.btnLuu.FlatAppearance.BorderSize = 0;
            this.btnLuu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLuu.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLuu.ForeColor = System.Drawing.Color.DodgerBlue;
            this.btnLuu.Location = new System.Drawing.Point(725, 522);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(150, 40);
            this.btnLuu.TabIndex = 135;
            this.btnLuu.Text = "Lưu";
            this.btnLuu.TextColor = System.Drawing.Color.DodgerBlue;
            this.btnLuu.UseVisualStyleBackColor = false;
            this.btnLuu.Click += new System.EventHandler(this.btnLuu_Click);
            // 
            // btnHuyBo
            // 
            this.btnHuyBo.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnHuyBo.BackColor = System.Drawing.SystemColors.Control;
            this.btnHuyBo.BackgroundColor = System.Drawing.SystemColors.Control;
            this.btnHuyBo.BorderColor = System.Drawing.Color.DodgerBlue;
            this.btnHuyBo.BorderRadius = 20;
            this.btnHuyBo.BorderSize = 2;
            this.btnHuyBo.FlatAppearance.BorderSize = 0;
            this.btnHuyBo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHuyBo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHuyBo.ForeColor = System.Drawing.Color.DodgerBlue;
            this.btnHuyBo.Location = new System.Drawing.Point(569, 522);
            this.btnHuyBo.Name = "btnHuyBo";
            this.btnHuyBo.Size = new System.Drawing.Size(150, 40);
            this.btnHuyBo.TabIndex = 134;
            this.btnHuyBo.Text = "Hủy Bỏ";
            this.btnHuyBo.TextColor = System.Drawing.Color.DodgerBlue;
            this.btnHuyBo.UseVisualStyleBackColor = false;
            this.btnHuyBo.Click += new System.EventHandler(this.btnHuyBo_Click);
            // 
            // btnXoa
            // 
            this.btnXoa.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnXoa.BackColor = System.Drawing.Color.Red;
            this.btnXoa.BackgroundColor = System.Drawing.Color.Red;
            this.btnXoa.BorderColor = System.Drawing.Color.DodgerBlue;
            this.btnXoa.BorderRadius = 10;
            this.btnXoa.BorderSize = 0;
            this.btnXoa.FlatAppearance.BorderSize = 0;
            this.btnXoa.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXoa.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXoa.ForeColor = System.Drawing.Color.White;
            this.btnXoa.Location = new System.Drawing.Point(899, 9);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(144, 36);
            this.btnXoa.TabIndex = 133;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.TextColor = System.Drawing.Color.White;
            this.btnXoa.UseVisualStyleBackColor = false;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // btnThem
            // 
            this.btnThem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnThem.BackColor = System.Drawing.Color.Blue;
            this.btnThem.BackgroundColor = System.Drawing.Color.Blue;
            this.btnThem.BorderColor = System.Drawing.Color.DodgerBlue;
            this.btnThem.BorderRadius = 10;
            this.btnThem.BorderSize = 0;
            this.btnThem.FlatAppearance.BorderSize = 0;
            this.btnThem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThem.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThem.ForeColor = System.Drawing.Color.White;
            this.btnThem.Location = new System.Drawing.Point(1049, 9);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(144, 36);
            this.btnThem.TabIndex = 132;
            this.btnThem.Text = "Thêm";
            this.btnThem.TextColor = System.Drawing.Color.White;
            this.btnThem.UseVisualStyleBackColor = false;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // btnSua
            // 
            this.btnSua.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnSua.BackColor = System.Drawing.SystemColors.Control;
            this.btnSua.BackgroundColor = System.Drawing.SystemColors.Control;
            this.btnSua.BorderColor = System.Drawing.Color.DodgerBlue;
            this.btnSua.BorderRadius = 20;
            this.btnSua.BorderSize = 2;
            this.btnSua.FlatAppearance.BorderSize = 0;
            this.btnSua.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSua.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSua.ForeColor = System.Drawing.Color.DodgerBlue;
            this.btnSua.Location = new System.Drawing.Point(413, 522);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(150, 40);
            this.btnSua.TabIndex = 131;
            this.btnSua.Text = "Sửa";
            this.btnSua.TextColor = System.Drawing.Color.DodgerBlue;
            this.btnSua.UseVisualStyleBackColor = false;
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // btnReload
            // 
            this.btnReload.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnReload.BackColor = System.Drawing.SystemColors.Control;
            this.btnReload.BackgroundColor = System.Drawing.SystemColors.Control;
            this.btnReload.BorderColor = System.Drawing.Color.DodgerBlue;
            this.btnReload.BorderRadius = 20;
            this.btnReload.BorderSize = 2;
            this.btnReload.FlatAppearance.BorderSize = 0;
            this.btnReload.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReload.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReload.ForeColor = System.Drawing.Color.DodgerBlue;
            this.btnReload.Location = new System.Drawing.Point(257, 522);
            this.btnReload.Name = "btnReload";
            this.btnReload.Size = new System.Drawing.Size(150, 40);
            this.btnReload.TabIndex = 130;
            this.btnReload.Text = "Reload";
            this.btnReload.TextColor = System.Drawing.Color.DodgerBlue;
            this.btnReload.UseVisualStyleBackColor = false;
            this.btnReload.Click += new System.EventHandler(this.btnReLoad_Click);
            // 
            // FrmKhuyenMai
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Info;
            this.ClientSize = new System.Drawing.Size(1210, 583);
            this.Controls.Add(this.rjButton1);
            this.Controls.Add(this.btnLuu);
            this.Controls.Add(this.btnHuyBo);
            this.Controls.Add(this.btnXoa);
            this.Controls.Add(this.btnThem);
            this.Controls.Add(this.btnSua);
            this.Controls.Add(this.btnReload);
            this.Controls.Add(this.btnTimKiem);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtTimKiem);
            this.Controls.Add(this.dgvKhuyenMai);
            this.Controls.Add(this.panel_KhuyenMai);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmKhuyenMai";
            this.Text = "Khuyến Mãi";
            this.Load += new System.EventHandler(this.FrmKhuyenMai_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvKhuyenMai)).EndInit();
            this.panel_KhuyenMai.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DateTimePicker date_NgayAD;
        private System.Windows.Forms.DateTimePicker date_NgayKT;
        private System.Windows.Forms.TextBox txt_MucGiam;
        private System.Windows.Forms.Label label_MucGiam;
        private System.Windows.Forms.Label label_NgayKT;
        private System.Windows.Forms.DataGridView dgvKhuyenMai;
        private System.Windows.Forms.TextBox txt_TenChuongTrinh;
        private System.Windows.Forms.Panel panel_KhuyenMai;
        private System.Windows.Forms.Label label_MaKM;
        private System.Windows.Forms.Label label_NgayAD;
        private System.Windows.Forms.TextBox txt_MaKM;
        private System.Windows.Forms.Label label_TenChuongTrinh;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaKM;
        private System.Windows.Forms.DataGridViewTextBoxColumn TenChuongTrinh;
        private System.Windows.Forms.DataGridViewTextBoxColumn NgayAD;
        private System.Windows.Forms.DataGridViewTextBoxColumn NgayKT;
        private System.Windows.Forms.DataGridViewTextBoxColumn MucGiam;
        private System.Windows.Forms.TextBox txtTimKiem;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnTimKiem;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private RJControls.RJButton btnReload;
        private RJControls.RJButton btnSua;
        private RJControls.RJButton btnThem;
        private RJControls.RJButton btnXoa;
        private RJControls.RJButton btnHuyBo;
        private RJControls.RJButton btnLuu;
        private RJControls.RJButton rjButton1;
    }
}