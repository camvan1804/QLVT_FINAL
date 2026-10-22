namespace ktv_quanlikiemke
{
    partial class frmkhohang
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
            this.grphanghoa = new System.Windows.Forms.GroupBox();
            this.btnxoa = new Guna.UI2.WinForms.Guna2Button();
            this.btnsua = new Guna.UI2.WinForms.Guna2Button();
            this.btnlammoi = new Guna.UI2.WinForms.Guna2Button();
            this.btnthem = new Guna.UI2.WinForms.Guna2Button();
            this.pichanghoa = new System.Windows.Forms.PictureBox();
            this.txtghichu = new System.Windows.Forms.TextBox();
            this.lblghichu = new System.Windows.Forms.Label();
            this.cbonhacungcap = new System.Windows.Forms.ComboBox();
            this.txttenhanghoa = new System.Windows.Forms.TextBox();
            this.txtsoluong = new System.Windows.Forms.TextBox();
            this.txtdonvitinh = new System.Windows.Forms.TextBox();
            this.lblten = new System.Windows.Forms.Label();
            this.lblncc = new System.Windows.Forms.Label();
            this.lblsoluong = new System.Windows.Forms.Label();
            this.lbldonvi = new System.Windows.Forms.Label();
            this.txtmahanghoa = new System.Windows.Forms.TextBox();
            this.lblma = new System.Windows.Forms.Label();
            this.btntimkiem = new Guna.UI2.WinForms.Guna2Button();
            this.lblquanlivattu = new System.Windows.Forms.Label();
            this.grptimkiem = new System.Windows.Forms.GroupBox();
            this.txttimkiemten = new System.Windows.Forms.TextBox();
            this.txttimkiemma = new System.Windows.Forms.TextBox();
            this.rdotimtheoten = new System.Windows.Forms.RadioButton();
            this.rdotimtheoma = new System.Windows.Forms.RadioButton();
            this.dgvhanghoa = new System.Windows.Forms.DataGridView();
            this.btnquaylai = new Guna.UI2.WinForms.Guna2Button();
            this.grphanghoa.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pichanghoa)).BeginInit();
            this.grptimkiem.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvhanghoa)).BeginInit();
            this.SuspendLayout();
            // 
            // grphanghoa
            // 
            this.grphanghoa.BackColor = System.Drawing.Color.Transparent;
            this.grphanghoa.Controls.Add(this.btnxoa);
            this.grphanghoa.Controls.Add(this.btnsua);
            this.grphanghoa.Controls.Add(this.btnlammoi);
            this.grphanghoa.Controls.Add(this.btnthem);
            this.grphanghoa.Controls.Add(this.pichanghoa);
            this.grphanghoa.Controls.Add(this.txtghichu);
            this.grphanghoa.Controls.Add(this.lblghichu);
            this.grphanghoa.Controls.Add(this.cbonhacungcap);
            this.grphanghoa.Controls.Add(this.txttenhanghoa);
            this.grphanghoa.Controls.Add(this.txtsoluong);
            this.grphanghoa.Controls.Add(this.txtdonvitinh);
            this.grphanghoa.Controls.Add(this.lblten);
            this.grphanghoa.Controls.Add(this.lblncc);
            this.grphanghoa.Controls.Add(this.lblsoluong);
            this.grphanghoa.Controls.Add(this.lbldonvi);
            this.grphanghoa.Controls.Add(this.txtmahanghoa);
            this.grphanghoa.Controls.Add(this.lblma);
            this.grphanghoa.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grphanghoa.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.grphanghoa.Location = new System.Drawing.Point(802, 12);
            this.grphanghoa.Name = "grphanghoa";
            this.grphanghoa.Size = new System.Drawing.Size(361, 627);
            this.grphanghoa.TabIndex = 1;
            this.grphanghoa.TabStop = false;
            this.grphanghoa.Text = "Thông tin hàng hóa";
            // 
            // btnxoa
            // 
            this.btnxoa.BorderRadius = 15;
            this.btnxoa.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnxoa.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnxoa.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnxoa.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnxoa.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btnxoa.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnxoa.ForeColor = System.Drawing.Color.White;
            this.btnxoa.Location = new System.Drawing.Point(22, 558);
            this.btnxoa.Name = "btnxoa";
            this.btnxoa.Size = new System.Drawing.Size(133, 45);
            this.btnxoa.TabIndex = 17;
            this.btnxoa.Text = "Xóa";
            this.btnxoa.Click += new System.EventHandler(this.btnxoa_Click);
            // 
            // btnsua
            // 
            this.btnsua.BorderRadius = 15;
            this.btnsua.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnsua.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnsua.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnsua.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnsua.FillColor = System.Drawing.Color.Green;
            this.btnsua.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnsua.ForeColor = System.Drawing.Color.White;
            this.btnsua.Location = new System.Drawing.Point(192, 497);
            this.btnsua.Name = "btnsua";
            this.btnsua.Size = new System.Drawing.Size(132, 45);
            this.btnsua.TabIndex = 16;
            this.btnsua.Text = "Sửa";
            this.btnsua.Click += new System.EventHandler(this.btnsua_Click);
            // 
            // btnlammoi
            // 
            this.btnlammoi.BorderRadius = 15;
            this.btnlammoi.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnlammoi.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnlammoi.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnlammoi.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnlammoi.FillColor = System.Drawing.Color.Silver;
            this.btnlammoi.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnlammoi.ForeColor = System.Drawing.Color.White;
            this.btnlammoi.Location = new System.Drawing.Point(192, 558);
            this.btnlammoi.Name = "btnlammoi";
            this.btnlammoi.Size = new System.Drawing.Size(132, 45);
            this.btnlammoi.TabIndex = 15;
            this.btnlammoi.Text = "Làm mới";
            this.btnlammoi.Click += new System.EventHandler(this.btnlammoi_Click);
            // 
            // btnthem
            // 
            this.btnthem.BorderRadius = 15;
            this.btnthem.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnthem.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnthem.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnthem.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnthem.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnthem.ForeColor = System.Drawing.Color.White;
            this.btnthem.Location = new System.Drawing.Point(22, 497);
            this.btnthem.Name = "btnthem";
            this.btnthem.Size = new System.Drawing.Size(133, 45);
            this.btnthem.TabIndex = 13;
            this.btnthem.Text = "+ Thêm";
            this.btnthem.Click += new System.EventHandler(this.btnthem_Click);
            // 
            // pichanghoa
            // 
            this.pichanghoa.Image = global::BTLnhom6_quanlybattu.Properties.Resources.Screenshot_2026_10_08_113828;
            this.pichanghoa.Location = new System.Drawing.Point(22, 21);
            this.pichanghoa.Name = "pichanghoa";
            this.pichanghoa.Size = new System.Drawing.Size(302, 155);
            this.pichanghoa.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pichanghoa.TabIndex = 12;
            this.pichanghoa.TabStop = false;
            // 
            // txtghichu
            // 
            this.txtghichu.Location = new System.Drawing.Point(140, 436);
            this.txtghichu.Name = "txtghichu";
            this.txtghichu.Size = new System.Drawing.Size(197, 22);
            this.txtghichu.TabIndex = 11;
            // 
            // lblghichu
            // 
            this.lblghichu.AutoSize = true;
            this.lblghichu.Location = new System.Drawing.Point(16, 442);
            this.lblghichu.Name = "lblghichu";
            this.lblghichu.Size = new System.Drawing.Size(58, 16);
            this.lblghichu.TabIndex = 10;
            this.lblghichu.Text = "Ghi chú";
            // 
            // cbonhacungcap
            // 
            this.cbonhacungcap.FormattingEnabled = true;
            this.cbonhacungcap.Location = new System.Drawing.Point(140, 288);
            this.cbonhacungcap.Name = "cbonhacungcap";
            this.cbonhacungcap.Size = new System.Drawing.Size(197, 24);
            this.cbonhacungcap.TabIndex = 9;
            // 
            // txttenhanghoa
            // 
            this.txttenhanghoa.Location = new System.Drawing.Point(140, 244);
            this.txttenhanghoa.Name = "txttenhanghoa";
            this.txttenhanghoa.Size = new System.Drawing.Size(197, 22);
            this.txttenhanghoa.TabIndex = 8;
            // 
            // txtsoluong
            // 
            this.txtsoluong.Location = new System.Drawing.Point(140, 339);
            this.txtsoluong.Name = "txtsoluong";
            this.txtsoluong.Size = new System.Drawing.Size(197, 22);
            this.txtsoluong.TabIndex = 7;
            // 
            // txtdonvitinh
            // 
            this.txtdonvitinh.Location = new System.Drawing.Point(140, 389);
            this.txtdonvitinh.Name = "txtdonvitinh";
            this.txtdonvitinh.Size = new System.Drawing.Size(197, 22);
            this.txtdonvitinh.TabIndex = 6;
            // 
            // lblten
            // 
            this.lblten.AutoSize = true;
            this.lblten.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.lblten.Location = new System.Drawing.Point(16, 250);
            this.lblten.Name = "lblten";
            this.lblten.Size = new System.Drawing.Size(102, 16);
            this.lblten.TabIndex = 5;
            this.lblten.Text = "Tên hàng hóa";
            // 
            // lblncc
            // 
            this.lblncc.AutoSize = true;
            this.lblncc.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.lblncc.Location = new System.Drawing.Point(19, 296);
            this.lblncc.Name = "lblncc";
            this.lblncc.Size = new System.Drawing.Size(102, 16);
            this.lblncc.TabIndex = 4;
            this.lblncc.Text = "Nhà cung cấp";
            // 
            // lblsoluong
            // 
            this.lblsoluong.AutoSize = true;
            this.lblsoluong.Location = new System.Drawing.Point(19, 345);
            this.lblsoluong.Name = "lblsoluong";
            this.lblsoluong.Size = new System.Drawing.Size(68, 16);
            this.lblsoluong.TabIndex = 3;
            this.lblsoluong.Text = "Số lượng";
            // 
            // lbldonvi
            // 
            this.lbldonvi.AutoSize = true;
            this.lbldonvi.Location = new System.Drawing.Point(16, 395);
            this.lbldonvi.Name = "lbldonvi";
            this.lbldonvi.Size = new System.Drawing.Size(78, 16);
            this.lbldonvi.TabIndex = 2;
            this.lbldonvi.Text = "Đơn vị tính";
            // 
            // txtmahanghoa
            // 
            this.txtmahanghoa.Location = new System.Drawing.Point(140, 207);
            this.txtmahanghoa.Name = "txtmahanghoa";
            this.txtmahanghoa.Size = new System.Drawing.Size(197, 22);
            this.txtmahanghoa.TabIndex = 1;
            // 
            // lblma
            // 
            this.lblma.AutoSize = true;
            this.lblma.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.lblma.Location = new System.Drawing.Point(19, 210);
            this.lblma.Name = "lblma";
            this.lblma.Size = new System.Drawing.Size(96, 16);
            this.lblma.TabIndex = 0;
            this.lblma.Text = "Mã hàng hóa";
            // 
            // btntimkiem
            // 
            this.btntimkiem.BorderRadius = 15;
            this.btntimkiem.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btntimkiem.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btntimkiem.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btntimkiem.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btntimkiem.FillColor = System.Drawing.Color.Teal;
            this.btntimkiem.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btntimkiem.ForeColor = System.Drawing.Color.White;
            this.btntimkiem.Location = new System.Drawing.Point(479, 30);
            this.btntimkiem.Name = "btntimkiem";
            this.btntimkiem.Size = new System.Drawing.Size(174, 45);
            this.btntimkiem.TabIndex = 14;
            this.btntimkiem.Text = "Tìm kiếm";
            this.btntimkiem.Click += new System.EventHandler(this.btntimkiem_Click);
            // 
            // lblquanlivattu
            // 
            this.lblquanlivattu.AutoSize = true;
            this.lblquanlivattu.BackColor = System.Drawing.Color.Transparent;
            this.lblquanlivattu.Font = new System.Drawing.Font("Mongolian Baiti", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblquanlivattu.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblquanlivattu.Location = new System.Drawing.Point(223, 33);
            this.lblquanlivattu.Name = "lblquanlivattu";
            this.lblquanlivattu.Size = new System.Drawing.Size(291, 35);
            this.lblquanlivattu.TabIndex = 8;
            this.lblquanlivattu.Text = "QUẢN LÝ VẬT TƯ";
            // 
            // grptimkiem
            // 
            this.grptimkiem.BackColor = System.Drawing.Color.Transparent;
            this.grptimkiem.Controls.Add(this.txttimkiemten);
            this.grptimkiem.Controls.Add(this.txttimkiemma);
            this.grptimkiem.Controls.Add(this.rdotimtheoten);
            this.grptimkiem.Controls.Add(this.btntimkiem);
            this.grptimkiem.Controls.Add(this.rdotimtheoma);
            this.grptimkiem.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grptimkiem.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.grptimkiem.Location = new System.Drawing.Point(31, 71);
            this.grptimkiem.Name = "grptimkiem";
            this.grptimkiem.Size = new System.Drawing.Size(722, 99);
            this.grptimkiem.TabIndex = 9;
            this.grptimkiem.TabStop = false;
            this.grptimkiem.Text = "Tìm kiếm hàng";
            // 
            // txttimkiemten
            // 
            this.txttimkiemten.Location = new System.Drawing.Point(194, 67);
            this.txttimkiemten.Name = "txttimkiemten";
            this.txttimkiemten.Size = new System.Drawing.Size(183, 22);
            this.txttimkiemten.TabIndex = 13;
            // 
            // txttimkiemma
            // 
            this.txttimkiemma.Location = new System.Drawing.Point(194, 30);
            this.txttimkiemma.Name = "txttimkiemma";
            this.txttimkiemma.Size = new System.Drawing.Size(183, 22);
            this.txttimkiemma.TabIndex = 12;
            // 
            // rdotimtheoten
            // 
            this.rdotimtheoten.AutoSize = true;
            this.rdotimtheoten.Location = new System.Drawing.Point(20, 67);
            this.rdotimtheoten.Name = "rdotimtheoten";
            this.rdotimtheoten.Size = new System.Drawing.Size(150, 20);
            this.rdotimtheoten.TabIndex = 1;
            this.rdotimtheoten.TabStop = true;
            this.rdotimtheoten.Text = "Tìm kiếm theo tên";
            this.rdotimtheoten.UseVisualStyleBackColor = true;
            // 
            // rdotimtheoma
            // 
            this.rdotimtheoma.AutoSize = true;
            this.rdotimtheoma.Location = new System.Drawing.Point(20, 32);
            this.rdotimtheoma.Name = "rdotimtheoma";
            this.rdotimtheoma.Size = new System.Drawing.Size(150, 20);
            this.rdotimtheoma.TabIndex = 0;
            this.rdotimtheoma.TabStop = true;
            this.rdotimtheoma.Text = "Tìm kiếm theo mã";
            this.rdotimtheoma.UseVisualStyleBackColor = true;
            // 
            // dgvhanghoa
            // 
            this.dgvhanghoa.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dgvhanghoa.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvhanghoa.Location = new System.Drawing.Point(28, 194);
            this.dgvhanghoa.Name = "dgvhanghoa";
            this.dgvhanghoa.RowHeadersVisible = false;
            this.dgvhanghoa.RowHeadersWidth = 51;
            this.dgvhanghoa.RowTemplate.Height = 24;
            this.dgvhanghoa.Size = new System.Drawing.Size(725, 445);
            this.dgvhanghoa.TabIndex = 10;
            this.dgvhanghoa.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvhanghoa_CellClick);
            // 
            // btnquaylai
            // 
            this.btnquaylai.BackColor = System.Drawing.Color.Transparent;
            this.btnquaylai.BorderRadius = 15;
            this.btnquaylai.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnquaylai.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnquaylai.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnquaylai.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnquaylai.FillColor = System.Drawing.Color.Olive;
            this.btnquaylai.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnquaylai.ForeColor = System.Drawing.Color.White;
            this.btnquaylai.Location = new System.Drawing.Point(994, 648);
            this.btnquaylai.Name = "btnquaylai";
            this.btnquaylai.Size = new System.Drawing.Size(132, 45);
            this.btnquaylai.TabIndex = 11;
            this.btnquaylai.Text = "Quay lại";
            this.btnquaylai.Click += new System.EventHandler(this.btnquaylai_Click);
            // 
            // frmkhohang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::BTLnhom6_quanlybattu.Properties.Resources._1791567112102_4097022809652839946_g7491982391230708265_aa0ecd5958cc05397fc2d9ba7314df6f___Copy;
            this.ClientSize = new System.Drawing.Size(1198, 705);
            this.Controls.Add(this.btnquaylai);
            this.Controls.Add(this.dgvhanghoa);
            this.Controls.Add(this.grptimkiem);
            this.Controls.Add(this.lblquanlivattu);
            this.Controls.Add(this.grphanghoa);
            this.Name = "frmkhohang";
            this.Text = "frmkhohang";
            this.Load += new System.EventHandler(this.frmkhohang_Load);
            this.grphanghoa.ResumeLayout(false);
            this.grphanghoa.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pichanghoa)).EndInit();
            this.grptimkiem.ResumeLayout(false);
            this.grptimkiem.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvhanghoa)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox grphanghoa;
        private System.Windows.Forms.PictureBox pichanghoa;
        private System.Windows.Forms.TextBox txtghichu;
        private System.Windows.Forms.Label lblghichu;
        private System.Windows.Forms.ComboBox cbonhacungcap;
        private System.Windows.Forms.TextBox txttenhanghoa;
        private System.Windows.Forms.TextBox txtsoluong;
        private System.Windows.Forms.TextBox txtdonvitinh;
        private System.Windows.Forms.Label lblten;
        private System.Windows.Forms.Label lblncc;
        private System.Windows.Forms.Label lblsoluong;
        private System.Windows.Forms.Label lbldonvi;
        private System.Windows.Forms.TextBox txtmahanghoa;
        private System.Windows.Forms.Label lblma;
        private Guna.UI2.WinForms.Guna2Button btnxoa;
        private Guna.UI2.WinForms.Guna2Button btnsua;
        private Guna.UI2.WinForms.Guna2Button btnlammoi;
        private Guna.UI2.WinForms.Guna2Button btnthem;
        private Guna.UI2.WinForms.Guna2Button btntimkiem;
        private System.Windows.Forms.Label lblquanlivattu;
        private System.Windows.Forms.GroupBox grptimkiem;
        private System.Windows.Forms.TextBox txttimkiemten;
        private System.Windows.Forms.TextBox txttimkiemma;
        private System.Windows.Forms.RadioButton rdotimtheoten;
        private System.Windows.Forms.RadioButton rdotimtheoma;
        private System.Windows.Forms.DataGridView dgvhanghoa;
        private Guna.UI2.WinForms.Guna2Button btnquaylai;
    }
}