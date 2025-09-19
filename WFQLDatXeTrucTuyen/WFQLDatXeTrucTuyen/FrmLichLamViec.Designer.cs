namespace WFQLDatXeTrucTuyen
{
    partial class FrmLichLamViec
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
            this.dataGridViewChuyenXe = new System.Windows.Forms.DataGridView();
            this.btnTimKiem = new System.Windows.Forms.Button();
            this.label_Search = new System.Windows.Forms.Label();
            this.txt_MaKhachHang = new System.Windows.Forms.TextBox();
            this.btnReload = new WFQLDatXeTrucTuyen.RJControls.RJButton();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewChuyenXe)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewChuyenXe
            // 
            this.dataGridViewChuyenXe.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewChuyenXe.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewChuyenXe.Location = new System.Drawing.Point(12, 65);
            this.dataGridViewChuyenXe.Name = "dataGridViewChuyenXe";
            this.dataGridViewChuyenXe.RowHeadersWidth = 51;
            this.dataGridViewChuyenXe.RowTemplate.Height = 24;
            this.dataGridViewChuyenXe.Size = new System.Drawing.Size(1186, 495);
            this.dataGridViewChuyenXe.TabIndex = 85;
            // 
            // btnTimKiem
            // 
            this.btnTimKiem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnTimKiem.BackColor = System.Drawing.SystemColors.Control;
            this.btnTimKiem.BackgroundImage = global::WFQLDatXeTrucTuyen.Properties.Resources.Very_Basic_Search_icon2;
            this.btnTimKiem.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnTimKiem.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control;
            this.btnTimKiem.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(254)));
            this.btnTimKiem.Location = new System.Drawing.Point(470, 9);
            this.btnTimKiem.Name = "btnTimKiem";
            this.btnTimKiem.Size = new System.Drawing.Size(42, 36);
            this.btnTimKiem.TabIndex = 133;
            this.btnTimKiem.UseVisualStyleBackColor = false;
            this.btnTimKiem.Click += new System.EventHandler(this.btnTimKiem_Click);
            // 
            // label_Search
            // 
            this.label_Search.AutoSize = true;
            this.label_Search.Font = new System.Drawing.Font("Microsoft YaHei UI", 11F);
            this.label_Search.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label_Search.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label_Search.Location = new System.Drawing.Point(14, 20);
            this.label_Search.Name = "label_Search";
            this.label_Search.Size = new System.Drawing.Size(0, 25);
            this.label_Search.TabIndex = 132;
            // 
            // txt_MaKhachHang
            // 
            this.txt_MaKhachHang.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_MaKhachHang.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_MaKhachHang.Location = new System.Drawing.Point(12, 7);
            this.txt_MaKhachHang.Multiline = true;
            this.txt_MaKhachHang.Name = "txt_MaKhachHang";
            this.txt_MaKhachHang.Size = new System.Drawing.Size(452, 38);
            this.txt_MaKhachHang.TabIndex = 131;
            this.txt_MaKhachHang.Text = "Search";
            // 
            // btnReload
            // 
            this.btnReload.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnReload.BackColor = System.Drawing.Color.Blue;
            this.btnReload.BackgroundColor = System.Drawing.Color.Blue;
            this.btnReload.BorderColor = System.Drawing.Color.DodgerBlue;
            this.btnReload.BorderRadius = 10;
            this.btnReload.BorderSize = 0;
            this.btnReload.FlatAppearance.BorderSize = 0;
            this.btnReload.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReload.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReload.ForeColor = System.Drawing.Color.White;
            this.btnReload.Location = new System.Drawing.Point(1054, 7);
            this.btnReload.Name = "btnReload";
            this.btnReload.Size = new System.Drawing.Size(144, 36);
            this.btnReload.TabIndex = 134;
            this.btnReload.Text = "Reload";
            this.btnReload.TextColor = System.Drawing.Color.White;
            this.btnReload.UseVisualStyleBackColor = false;
            this.btnReload.Click += new System.EventHandler(this.btnReLoad_Click);
            // 
            // FrmLichLamViec
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Info;
            this.ClientSize = new System.Drawing.Size(1210, 583);
            this.Controls.Add(this.btnReload);
            this.Controls.Add(this.btnTimKiem);
            this.Controls.Add(this.label_Search);
            this.Controls.Add(this.txt_MaKhachHang);
            this.Controls.Add(this.dataGridViewChuyenXe);
            this.Name = "FrmLichLamViec";
            this.Text = "Lịch Làm Việc";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewChuyenXe)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewChuyenXe;
        private System.Windows.Forms.Button btnTimKiem;
        private System.Windows.Forms.Label label_Search;
        private System.Windows.Forms.TextBox txt_MaKhachHang;
        private RJControls.RJButton btnReload;
    }
}