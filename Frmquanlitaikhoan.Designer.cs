namespace BTL_QLKVT
{
    partial class Frmquanlitaikhoan
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
            this.grpthongtin = new System.Windows.Forms.GroupBox();
            this.btnxoa = new Guna.UI2.WinForms.Guna2Button();
            this.btnsua = new Guna.UI2.WinForms.Guna2Button();
            this.btnlammoi = new Guna.UI2.WinForms.Guna2Button();
            this.btnthem = new Guna.UI2.WinForms.Guna2Button();
            this.btneye = new System.Windows.Forms.Button();
            this.cbotrangthai = new System.Windows.Forms.ComboBox();
            this.cbovaitro = new System.Windows.Forms.ComboBox();
            this.txtmatkhau = new System.Windows.Forms.TextBox();
            this.lblmatkhau = new System.Windows.Forms.Label();
            this.lblhoten = new System.Windows.Forms.Label();
            this.lblvaitro = new System.Windows.Forms.Label();
            this.lbltrangthai = new System.Windows.Forms.Label();
            this.txttendangnhap = new System.Windows.Forms.TextBox();
            this.lbltendangnhap = new System.Windows.Forms.Label();
            this.btntimkiem = new Guna.UI2.WinForms.Guna2Button();
            this.grptimkiem = new System.Windows.Forms.GroupBox();
            this.txttimkiem = new System.Windows.Forms.TextBox();
            this.dgvtaikhoan = new System.Windows.Forms.DataGridView();
            this.lbltieude = new System.Windows.Forms.Label();
            this.btnquaylai = new Guna.UI2.WinForms.Guna2Button();
            this.cbomahanvien = new System.Windows.Forms.ComboBox();
            this.grpthongtin.SuspendLayout();
            this.grptimkiem.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvtaikhoan)).BeginInit();
            this.SuspendLayout();
            // 
            // grpthongtin
            // 
            this.grpthongtin.BackColor = System.Drawing.Color.Transparent;
            this.grpthongtin.Controls.Add(this.cbomahanvien);
            this.grpthongtin.Controls.Add(this.btnxoa);
            this.grpthongtin.Controls.Add(this.btnsua);
            this.grpthongtin.Controls.Add(this.btnlammoi);
            this.grpthongtin.Controls.Add(this.btnthem);
            this.grpthongtin.Controls.Add(this.btneye);
            this.grpthongtin.Controls.Add(this.cbotrangthai);
            this.grpthongtin.Controls.Add(this.cbovaitro);
            this.grpthongtin.Controls.Add(this.txtmatkhau);
            this.grpthongtin.Controls.Add(this.lblmatkhau);
            this.grpthongtin.Controls.Add(this.lblhoten);
            this.grpthongtin.Controls.Add(this.lblvaitro);
            this.grpthongtin.Controls.Add(this.lbltrangthai);
            this.grpthongtin.Controls.Add(this.txttendangnhap);
            this.grpthongtin.Controls.Add(this.lbltendangnhap);
            this.grpthongtin.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpthongtin.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.grpthongtin.Location = new System.Drawing.Point(788, 80);
            this.grpthongtin.Name = "grpthongtin";
            this.grpthongtin.Size = new System.Drawing.Size(355, 437);
            this.grpthongtin.TabIndex = 4;
            this.grpthongtin.TabStop = false;
            this.grpthongtin.Text = "Thông tin tài khoản";
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
            this.btnxoa.Location = new System.Drawing.Point(29, 365);
            this.btnxoa.Name = "btnxoa";
            this.btnxoa.Size = new System.Drawing.Size(133, 45);
            this.btnxoa.TabIndex = 21;
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
            this.btnsua.Location = new System.Drawing.Point(193, 301);
            this.btnsua.Name = "btnsua";
            this.btnsua.Size = new System.Drawing.Size(133, 45);
            this.btnsua.TabIndex = 20;
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
            this.btnlammoi.FillColor = System.Drawing.Color.DarkKhaki;
            this.btnlammoi.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnlammoi.ForeColor = System.Drawing.Color.White;
            this.btnlammoi.Location = new System.Drawing.Point(193, 365);
            this.btnlammoi.Name = "btnlammoi";
            this.btnlammoi.Size = new System.Drawing.Size(133, 45);
            this.btnlammoi.TabIndex = 19;
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
            this.btnthem.Location = new System.Drawing.Point(29, 301);
            this.btnthem.Name = "btnthem";
            this.btnthem.Size = new System.Drawing.Size(133, 45);
            this.btnthem.TabIndex = 17;
            this.btnthem.Text = "+ Thêm";
            this.btnthem.Click += new System.EventHandler(this.btnthem_Click);
            // 
            // btneye
            // 
            this.btneye.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btneye.Location = new System.Drawing.Point(315, 98);
            this.btneye.Name = "btneye";
            this.btneye.Size = new System.Drawing.Size(27, 23);
            this.btneye.TabIndex = 16;
            this.btneye.Text = "👁";
            this.btneye.UseVisualStyleBackColor = true;
            this.btneye.Click += new System.EventHandler(this.btneye_Click);
            // 
            // cbotrangthai
            // 
            this.cbotrangthai.BackColor = System.Drawing.SystemColors.HighlightText;
            this.cbotrangthai.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbotrangthai.ForeColor = System.Drawing.SystemColors.InfoText;
            this.cbotrangthai.FormattingEnabled = true;
            this.cbotrangthai.Location = new System.Drawing.Point(158, 250);
            this.cbotrangthai.Name = "cbotrangthai";
            this.cbotrangthai.Size = new System.Drawing.Size(187, 26);
            this.cbotrangthai.TabIndex = 11;
            // 
            // cbovaitro
            // 
            this.cbovaitro.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbovaitro.FormattingEnabled = true;
            this.cbovaitro.Location = new System.Drawing.Point(158, 197);
            this.cbovaitro.Name = "cbovaitro";
            this.cbovaitro.Size = new System.Drawing.Size(187, 26);
            this.cbovaitro.TabIndex = 10;
            // 
            // txtmatkhau
            // 
            this.txtmatkhau.Location = new System.Drawing.Point(158, 98);
            this.txtmatkhau.Name = "txtmatkhau";
            this.txtmatkhau.Size = new System.Drawing.Size(184, 24);
            this.txtmatkhau.TabIndex = 9;
            this.txtmatkhau.UseSystemPasswordChar = true;
            // 
            // lblmatkhau
            // 
            this.lblmatkhau.AutoSize = true;
            this.lblmatkhau.Location = new System.Drawing.Point(26, 104);
            this.lblmatkhau.Name = "lblmatkhau";
            this.lblmatkhau.Size = new System.Drawing.Size(77, 18);
            this.lblmatkhau.TabIndex = 7;
            this.lblmatkhau.Text = "Mật khẩu";
            // 
            // lblhoten
            // 
            this.lblhoten.AutoSize = true;
            this.lblhoten.Location = new System.Drawing.Point(26, 153);
            this.lblhoten.Name = "lblhoten";
            this.lblhoten.Size = new System.Drawing.Size(80, 18);
            this.lblhoten.TabIndex = 6;
            this.lblhoten.Text = "Họ và tên";
            // 
            // lblvaitro
            // 
            this.lblvaitro.AutoSize = true;
            this.lblvaitro.Location = new System.Drawing.Point(26, 205);
            this.lblvaitro.Name = "lblvaitro";
            this.lblvaitro.Size = new System.Drawing.Size(57, 18);
            this.lblvaitro.TabIndex = 5;
            this.lblvaitro.Text = "Vai trò";
            // 
            // lbltrangthai
            // 
            this.lbltrangthai.AutoSize = true;
            this.lbltrangthai.Location = new System.Drawing.Point(26, 258);
            this.lbltrangthai.Name = "lbltrangthai";
            this.lbltrangthai.Size = new System.Drawing.Size(83, 18);
            this.lbltrangthai.TabIndex = 4;
            this.lbltrangthai.Text = "Trạng thái";
            // 
            // txttendangnhap
            // 
            this.txttendangnhap.Location = new System.Drawing.Point(158, 48);
            this.txttendangnhap.Name = "txttendangnhap";
            this.txttendangnhap.Size = new System.Drawing.Size(184, 24);
            this.txttendangnhap.TabIndex = 3;
            // 
            // lbltendangnhap
            // 
            this.lbltendangnhap.AutoSize = true;
            this.lbltendangnhap.Location = new System.Drawing.Point(20, 54);
            this.lbltendangnhap.Name = "lbltendangnhap";
            this.lbltendangnhap.Size = new System.Drawing.Size(118, 18);
            this.lbltendangnhap.TabIndex = 2;
            this.lbltendangnhap.Text = "Tên đăng nhập";
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
            this.btntimkiem.Location = new System.Drawing.Point(541, 22);
            this.btntimkiem.Name = "btntimkiem";
            this.btntimkiem.Size = new System.Drawing.Size(162, 40);
            this.btntimkiem.TabIndex = 18;
            this.btntimkiem.Text = "Tìm kiếm";
            this.btntimkiem.Click += new System.EventHandler(this.btntimkiem_Click);
            // 
            // grptimkiem
            // 
            this.grptimkiem.BackColor = System.Drawing.Color.Transparent;
            this.grptimkiem.Controls.Add(this.txttimkiem);
            this.grptimkiem.Controls.Add(this.btntimkiem);
            this.grptimkiem.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grptimkiem.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.grptimkiem.Location = new System.Drawing.Point(24, 107);
            this.grptimkiem.Name = "grptimkiem";
            this.grptimkiem.Size = new System.Drawing.Size(736, 103);
            this.grptimkiem.TabIndex = 5;
            this.grptimkiem.TabStop = false;
            this.grptimkiem.Text = "Tìm kiếm";
            // 
            // txttimkiem
            // 
            this.txttimkiem.Location = new System.Drawing.Point(20, 40);
            this.txttimkiem.Name = "txttimkiem";
            this.txttimkiem.Size = new System.Drawing.Size(498, 22);
            this.txttimkiem.TabIndex = 0;
            // 
            // dgvtaikhoan
            // 
            this.dgvtaikhoan.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dgvtaikhoan.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvtaikhoan.Location = new System.Drawing.Point(24, 216);
            this.dgvtaikhoan.Name = "dgvtaikhoan";
            this.dgvtaikhoan.RowHeadersVisible = false;
            this.dgvtaikhoan.RowHeadersWidth = 51;
            this.dgvtaikhoan.RowTemplate.Height = 24;
            this.dgvtaikhoan.Size = new System.Drawing.Size(736, 342);
            this.dgvtaikhoan.TabIndex = 6;
            this.dgvtaikhoan.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvtaikhoan_CellClick);
            // 
            // lbltieude
            // 
            this.lbltieude.AutoSize = true;
            this.lbltieude.BackColor = System.Drawing.Color.Transparent;
            this.lbltieude.Font = new System.Drawing.Font("Perpetua Titling MT", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbltieude.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lbltieude.Location = new System.Drawing.Point(305, 39);
            this.lbltieude.Name = "lbltieude";
            this.lbltieude.Size = new System.Drawing.Size(341, 33);
            this.lbltieude.TabIndex = 7;
            this.lbltieude.Text = "QUẢN LÝ TÀI KHOẢN";
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
            this.btnquaylai.Location = new System.Drawing.Point(982, 535);
            this.btnquaylai.Name = "btnquaylai";
            this.btnquaylai.Size = new System.Drawing.Size(132, 45);
            this.btnquaylai.TabIndex = 12;
            this.btnquaylai.Text = "Quay lại";
            this.btnquaylai.Click += new System.EventHandler(this.btnquaylai_Click);
            // 
            // cbomahanvien
            // 
            this.cbomahanvien.FormattingEnabled = true;
            this.cbomahanvien.Location = new System.Drawing.Point(158, 145);
            this.cbomahanvien.Name = "cbomahanvien";
            this.cbomahanvien.Size = new System.Drawing.Size(184, 26);
            this.cbomahanvien.TabIndex = 22;
            // 
            // Frmquanlitaikhoan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::BTLnhom6_quanlybattu.Properties.Resources._1791567112102_4097022809652839946_g7491982391230708265_aa0ecd5958cc05397fc2d9ba7314df6f___Copy;
            this.ClientSize = new System.Drawing.Size(1200, 629);
            this.Controls.Add(this.btnquaylai);
            this.Controls.Add(this.lbltieude);
            this.Controls.Add(this.dgvtaikhoan);
            this.Controls.Add(this.grptimkiem);
            this.Controls.Add(this.grpthongtin);
            this.Name = "Frmquanlitaikhoan";
            this.Text = "Frmquanlitaikhoan";
            this.Load += new System.EventHandler(this.Frmquanlitaikhoan_Load);
            this.grpthongtin.ResumeLayout(false);
            this.grpthongtin.PerformLayout();
            this.grptimkiem.ResumeLayout(false);
            this.grptimkiem.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvtaikhoan)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox grpthongtin;
        private System.Windows.Forms.Button btneye;
        private System.Windows.Forms.ComboBox cbotrangthai;
        private System.Windows.Forms.ComboBox cbovaitro;
        private System.Windows.Forms.TextBox txtmatkhau;
        private System.Windows.Forms.Label lblmatkhau;
        private System.Windows.Forms.Label lblhoten;
        private System.Windows.Forms.Label lblvaitro;
        private System.Windows.Forms.Label lbltrangthai;
        private System.Windows.Forms.TextBox txttendangnhap;
        private System.Windows.Forms.Label lbltendangnhap;
        private Guna.UI2.WinForms.Guna2Button btnthem;
        private Guna.UI2.WinForms.Guna2Button btnxoa;
        private Guna.UI2.WinForms.Guna2Button btnsua;
        private Guna.UI2.WinForms.Guna2Button btnlammoi;
        private Guna.UI2.WinForms.Guna2Button btntimkiem;
        private System.Windows.Forms.GroupBox grptimkiem;
        private System.Windows.Forms.TextBox txttimkiem;
        private System.Windows.Forms.DataGridView dgvtaikhoan;
        private System.Windows.Forms.Label lbltieude;
        private Guna.UI2.WinForms.Guna2Button btnquaylai;
        private System.Windows.Forms.ComboBox cbomahanvien;
    }
}