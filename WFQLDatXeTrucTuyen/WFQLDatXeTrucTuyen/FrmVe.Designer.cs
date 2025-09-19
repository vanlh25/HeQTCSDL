namespace WFQLDatXeTrucTuyen
{
    partial class FrmVe
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
            this.dgvVe = new System.Windows.Forms.DataGridView();
            this.TenTuyen = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MaVe = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MaDonHang = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MaKhach = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HoTen = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MaGhe = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TenGhe = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TinhTrang = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnDong = new WFQLDatXeTrucTuyen.RJControls.RJButton();
            this.btnReLoad = new WFQLDatXeTrucTuyen.RJControls.RJButton();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVe)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvVe
            // 
            this.dgvVe.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvVe.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.TenTuyen,
            this.MaVe,
            this.MaDonHang,
            this.MaKhach,
            this.HoTen,
            this.MaGhe,
            this.TenGhe,
            this.TinhTrang});
            this.dgvVe.Location = new System.Drawing.Point(12, 43);
            this.dgvVe.Name = "dgvVe";
            this.dgvVe.RowHeadersWidth = 51;
            this.dgvVe.RowTemplate.Height = 24;
            this.dgvVe.Size = new System.Drawing.Size(1226, 538);
            this.dgvVe.TabIndex = 83;
            this.dgvVe.UseWaitCursor = true;
            this.dgvVe.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvVe_CellClick);
            // 
            // TenTuyen
            // 
            this.TenTuyen.DataPropertyName = "TenTuyen";
            this.TenTuyen.HeaderText = "Tên tuyến";
            this.TenTuyen.MinimumWidth = 6;
            this.TenTuyen.Name = "TenTuyen";
            this.TenTuyen.Width = 125;
            // 
            // MaVe
            // 
            this.MaVe.DataPropertyName = "MaVe";
            this.MaVe.HeaderText = "Mã Vé";
            this.MaVe.MinimumWidth = 6;
            this.MaVe.Name = "MaVe";
            this.MaVe.Width = 125;
            // 
            // MaDonHang
            // 
            this.MaDonHang.DataPropertyName = "MaDonHang";
            this.MaDonHang.HeaderText = "Mã Đơn Hàng";
            this.MaDonHang.MinimumWidth = 6;
            this.MaDonHang.Name = "MaDonHang";
            this.MaDonHang.Width = 125;
            // 
            // MaKhach
            // 
            this.MaKhach.DataPropertyName = "MaKhach";
            this.MaKhach.HeaderText = "Mã Khách";
            this.MaKhach.MinimumWidth = 6;
            this.MaKhach.Name = "MaKhach";
            this.MaKhach.Width = 125;
            // 
            // HoTen
            // 
            this.HoTen.DataPropertyName = "TenKhach";
            this.HoTen.HeaderText = "Tên Khách";
            this.HoTen.MinimumWidth = 6;
            this.HoTen.Name = "HoTen";
            this.HoTen.Width = 125;
            // 
            // MaGhe
            // 
            this.MaGhe.DataPropertyName = "MaGhe";
            this.MaGhe.HeaderText = "Mã Ghế";
            this.MaGhe.MinimumWidth = 6;
            this.MaGhe.Name = "MaGhe";
            this.MaGhe.Width = 125;
            // 
            // TenGhe
            // 
            this.TenGhe.DataPropertyName = "TenGhe";
            this.TenGhe.HeaderText = "Tên Ghế";
            this.TenGhe.MinimumWidth = 6;
            this.TenGhe.Name = "TenGhe";
            this.TenGhe.Width = 125;
            // 
            // TinhTrang
            // 
            this.TinhTrang.DataPropertyName = "TinhTrang";
            this.TinhTrang.HeaderText = "Tình trạng";
            this.TinhTrang.MinimumWidth = 6;
            this.TinhTrang.Name = "TinhTrang";
            this.TinhTrang.Width = 125;
            // 
            // btnDong
            // 
            this.btnDong.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnDong.BackColor = System.Drawing.SystemColors.Control;
            this.btnDong.BackgroundColor = System.Drawing.SystemColors.Control;
            this.btnDong.BorderColor = System.Drawing.Color.DodgerBlue;
            this.btnDong.BorderRadius = 20;
            this.btnDong.BorderSize = 2;
            this.btnDong.FlatAppearance.BorderSize = 0;
            this.btnDong.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDong.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDong.ForeColor = System.Drawing.Color.DodgerBlue;
            this.btnDong.Location = new System.Drawing.Point(1049, 587);
            this.btnDong.Name = "btnDong";
            this.btnDong.Size = new System.Drawing.Size(150, 40);
            this.btnDong.TabIndex = 133;
            this.btnDong.Text = "Đóng";
            this.btnDong.TextColor = System.Drawing.Color.DodgerBlue;
            this.btnDong.UseVisualStyleBackColor = false;
            this.btnDong.Click += new System.EventHandler(this.btnDong_Click);
            // 
            // btnReLoad
            // 
            this.btnReLoad.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnReLoad.BackColor = System.Drawing.SystemColors.Control;
            this.btnReLoad.BackgroundColor = System.Drawing.SystemColors.Control;
            this.btnReLoad.BorderColor = System.Drawing.Color.DodgerBlue;
            this.btnReLoad.BorderRadius = 20;
            this.btnReLoad.BorderSize = 2;
            this.btnReLoad.FlatAppearance.BorderSize = 0;
            this.btnReLoad.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReLoad.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReLoad.ForeColor = System.Drawing.Color.DodgerBlue;
            this.btnReLoad.Location = new System.Drawing.Point(881, 587);
            this.btnReLoad.Name = "btnReLoad";
            this.btnReLoad.Size = new System.Drawing.Size(150, 40);
            this.btnReLoad.TabIndex = 132;
            this.btnReLoad.Text = "Reload";
            this.btnReLoad.TextColor = System.Drawing.Color.DodgerBlue;
            this.btnReLoad.UseVisualStyleBackColor = false;
            this.btnReLoad.Click += new System.EventHandler(this.btnReLoad_Click);
            // 
            // FrmVe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Info;
            this.ClientSize = new System.Drawing.Size(1243, 647);
            this.ControlBox = false;
            this.Controls.Add(this.btnDong);
            this.Controls.Add(this.btnReLoad);
            this.Controls.Add(this.dgvVe);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmVe";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Vé";
            this.UseWaitCursor = true;
            this.Load += new System.EventHandler(this.FrmVe_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvVe)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvVe;
        private System.Windows.Forms.DataGridViewTextBoxColumn TenTuyen;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaVe;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaDonHang;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaKhach;
        private System.Windows.Forms.DataGridViewTextBoxColumn HoTen;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaGhe;
        private System.Windows.Forms.DataGridViewTextBoxColumn TenGhe;
        private System.Windows.Forms.DataGridViewTextBoxColumn TinhTrang;
        private RJControls.RJButton btnDong;
        private RJControls.RJButton btnReLoad;
    }
}