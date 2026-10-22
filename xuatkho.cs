using BTLnhom6_quanlybattu;
using khách_hàng;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace xuatkhovt
{
    public partial class xuatkho : Form
    {
        string str = @"Data Source=.;Initial Catalog=QL_khovattufinal;Integrated Security=True";
        // Biến cờ chống lặp vô hạn khi đồng bộ ComboBox
        private bool isSyncingKH = false;
        private bool isSyncingNV = false;
        public xuatkho()
        {
            InitializeComponent();
        }
        private void TinhTongTien()
        {
            int soluong = 0;
            float dongia = 0;

            int.TryParse(txtsoluong.Text.Trim(), out soluong);
            float.TryParse(txtdongia.Text.Trim(), out dongia);

            float tongTien = soluong * dongia;
            txttongtien.Text = tongTien.ToString("N0") + " đ";
        }
        // Đổ dữ liệu cho ComboBox Nhà cung cấp / Khách hàng
        private void LoadComboBoxKhachHang()
        {
            using (SqlConnection conn = new SqlConnection(str))
            {
                conn.Open();
                string sql = "SELECT MaKhachHang, TenKhachHang FROM KhachHang";
                SqlDataAdapter da = new SqlDataAdapter(sql, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);

                // ComboBox Mã khách hàng
                cbomakhachhang.DataSource = dt;
                cbomakhachhang.DisplayMember = "MaKhachHang";
                cbomakhachhang.ValueMember = "MaKhachHang";

                // ComboBox Tên khách hàng
                cbotenkhachhang.DataSource = dt.Copy();
                cbotenkhachhang.DisplayMember = "TenKhachHang";
                cbotenkhachhang.ValueMember = "MaKhachHang";

                cbomakhachhang.SelectedIndex = -1;
                cbotenkhachhang.SelectedIndex = -1;
            }
        }
        private void LoadComboBoxNhanVien()
        {
            using (SqlConnection conn = new SqlConnection(str))
            {
                conn.Open();
                string sql = "SELECT MaNhanVien, TenNhanVien FROM NhanVien";
                SqlDataAdapter da = new SqlDataAdapter(sql, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);

                // ComboBox Mã nhân viên
                cbomanguoilap.DataSource = dt;
                cbomanguoilap.DisplayMember = "MaNhanVien";
                cbomanguoilap.ValueMember = "MaNhanVien";

                // ComboBox Tên nhân viên
                cbotennguoilap.DataSource = dt.Copy();
                cbotennguoilap.DisplayMember = "TenNhanVien";
                cbotennguoilap.ValueMember = "MaNhanVien";

                cbomanguoilap.SelectedIndex = -1;
                cbotennguoilap.SelectedIndex = -1;
            }
        }
        // Cơ chế đồng bộ Mã - Tên Khách Hàng
        private void cbomakhachhang_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (isSyncingKH) return;
            if (cbomakhachhang.SelectedValue != null && cbomakhachhang.SelectedValue is string)
            {
                isSyncingKH = true;
                cbotenkhachhang.SelectedValue = cbomakhachhang.SelectedValue;
                isSyncingKH = false;
            }
        }

        private void cbotenkhachhang_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (isSyncingKH) return;
            if (cbotenkhachhang.SelectedValue != null && cbotenkhachhang.SelectedValue is string)
            {
                isSyncingKH = true;
                cbomakhachhang.SelectedValue = cbotenkhachhang.SelectedValue;
                isSyncingKH = false;
            }
        }

        // Cơ chế đồng bộ Mã - Tên Nhân Viên / Người lập
        private void cbomanguoilap_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (isSyncingNV) return;
            if (cbomanguoilap.SelectedValue != null && cbomanguoilap.SelectedValue is string)
            {
                isSyncingNV = true;
                cbotennguoilap.SelectedValue = cbomanguoilap.SelectedValue;
                isSyncingNV = false;
            }
        }

        private void cbotennguoilap_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (isSyncingNV) return;
            if (cbotennguoilap.SelectedValue != null && cbotennguoilap.SelectedValue is string)
            {
                isSyncingNV = true;
                cbomanguoilap.SelectedValue = cbotennguoilap.SelectedValue;
                isSyncingNV = false;
            }
        }
        private void Load_PhieuXuat(string maphieu, string mavt, string tenVat)
        {
            using (SqlConnection conn = new SqlConnection(str))
            {
                conn.Open();
                string sql = "SELECT ROW_NUMBER() OVER(ORDER BY px.MaPhieuXuat) AS Stt, " +
                             "px.MaPhieuXuat, px.NgayXuat, ct.MaHangHoa, h.TenHangHoa, " +
                             "ct.SoLuong, ct.DonGia, (ct.SoLuong * ct.DonGia) AS ThanhTien, " +
                             "px.MaKhachHang, px.MaNhanVien, px.GhiChu " +
                             "FROM PhieuXuat px " +
                             "JOIN ChiTietPhieuXuat ct ON px.MaPhieuXuat = ct.MaPhieuXuat " +
                             "JOIN HangHoa h ON ct.MaHangHoa = h.MaHangHoa " +
                             "WHERE (@maphieu = '' OR px.MaPhieuXuat LIKE '%' + @maphieu + '%') " +
                             "AND (@mavt = '' OR ct.MaHangHoa LIKE '%' + @mavt + '%') " +
                             "AND (@tenvat = '' OR h.TenHangHoa LIKE N'%' + @tenvat + '%')";

                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.Add("@maphieu", SqlDbType.VarChar, 20).Value = maphieu;
                cmd.Parameters.Add("@mavt", SqlDbType.VarChar, 20).Value = mavt;
                cmd.Parameters.Add("@tenvat", SqlDbType.NVarChar, 100).Value = tenVat;

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable tb = new DataTable();
                da.Fill(tb);

                dgvchitiet.DataSource = tb;
                dgvchitiet.Refresh();
            }
        }
        // Kiểm tra xem mã phiếu xuất đã tồn tại chưa
        private bool CheckTrungMaPhieu(string maPhieu, SqlConnection conn, SqlTransaction transaction)
        {
            string sql = "SELECT COUNT(*) FROM PhieuXuat WHERE MaPhieuXuat = @maphieu";
            using (SqlCommand cmd = new SqlCommand(sql, conn, transaction))
            {
                cmd.Parameters.Add("@maphieu", SqlDbType.VarChar, 20).Value = maPhieu;
                int count = (int)cmd.ExecuteScalar();
                return count > 0;
            }
        }


        private void btnlammoi_Click(object sender, EventArgs e)
        {
            txtmaphieu.Text = "PX" + DateTime.Now.ToString("yyyyMMddHHmmss");
            txtmavattu.Clear();
            txtvattu.Clear();
            txtsoluong.Clear();
            txtdongia.Clear();
            txttongtien.Clear();
            txtghichu.Clear();
            cbomakhachhang.SelectedIndex = -1;
            cbotenkhachhang.SelectedIndex = -1;
            cbomanguoilap.SelectedIndex = -1;
            cbotennguoilap.SelectedIndex = -1;

            if (dgvchitiet.Rows.Count > 0)
            {
                dgvchitiet.ClearSelection();
            }

            Load_PhieuXuat("", "", "");
        }

        private void dgvchitiet_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int i = e.RowIndex;
            if (i >= 0 && i < dgvchitiet.Rows.Count)
            {
                if (dgvchitiet.Rows[i].Cells["MaPhieuXuat"].Value != DBNull.Value)
                    txtmaphieu.Text = dgvchitiet.Rows[i].Cells["MaPhieuXuat"].Value.ToString();

                if (dgvchitiet.Rows[i].Cells["NgayXuat"].Value != DBNull.Value)
                {
                    dtpngaynhap.Value = Convert.ToDateTime(dgvchitiet.Rows[i].Cells["NgayXuat"].Value);
                }

                if (dgvchitiet.Rows[i].Cells["TenHangHoa"].Value != DBNull.Value)
                    txtvattu.Text = dgvchitiet.Rows[i].Cells["TenHangHoa"].Value.ToString();

                if (dgvchitiet.Rows[i].Cells["MaHangHoa"].Value != DBNull.Value)
                    txtmavattu.Text = dgvchitiet.Rows[i].Cells["MaHangHoa"].Value.ToString();

                if (dgvchitiet.Rows[i].Cells["SoLuong"].Value != DBNull.Value)
                    txtsoluong.Text = dgvchitiet.Rows[i].Cells["SoLuong"].Value.ToString();

                if (dgvchitiet.Rows[i].Cells["DonGia"].Value != DBNull.Value)
                    txtdongia.Text = dgvchitiet.Rows[i].Cells["DonGia"].Value.ToString();

                // Đồng bộ Khách hàng khi click chọn dòng
                if (dgvchitiet.Rows[i].Cells["MaKhachHang"].Value != DBNull.Value)
                {
                    string maKH = dgvchitiet.Rows[i].Cells["MaKhachHang"].Value.ToString();
                    cbomakhachhang.SelectedValue = maKH;
                    cbotenkhachhang.SelectedValue = maKH;
                }

                // Đồng bộ Nhân viên khi click chọn dòng
                if (dgvchitiet.Rows[i].Cells["MaNhanVien"].Value != DBNull.Value)
                {
                    string maNV = dgvchitiet.Rows[i].Cells["MaNhanVien"].Value.ToString();
                    cbomanguoilap.SelectedValue = maNV;
                    cbotennguoilap.SelectedValue = maNV;
                }
            }
        }

        private void txtdongia_TextChanged(object sender, EventArgs e)
        {
            TinhTongTien();
        }

        private void txttongtien_TextChanged(object sender, EventArgs e)
        {
            TinhTongTien();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            txtmaphieu.Text = "PX" + DateTime.Now.ToString("yyyyMMddHHmmss");

            LoadComboBoxKhachHang();
            LoadComboBoxNhanVien();

            Load_PhieuXuat("", "", "");

            if (dgvchitiet.Rows.Count > 0)
            {
                dgvchitiet.ClearSelection();
            }

            txtmavattu.Clear();
            txtvattu.Clear();
            txtsoluong.Clear();
            txtdongia.Clear();
            txttongtien.Clear();
            txtghichu.Clear();
            cbomakhachhang.SelectedIndex = -1;
            cbotenkhachhang.SelectedIndex = -1;
            cbomanguoilap.SelectedIndex = -1;
            cbotennguoilap.SelectedIndex = -1;
        }

        private void btnluu_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(str))
            {
                conn.Open();

                string sqlPX = "IF NOT EXISTS (SELECT 1 FROM PhieuXuat WHERE MaPhieuXuat = @maphieu) " +
                               "INSERT INTO PhieuXuat(MaPhieuXuat, NgayXuat, MaKhachHang, MaNhanVien, GhiChu) " +
                               "VALUES(@maphieu, @ngay, @makk, @manv, @ghichu)";
                SqlCommand cmdPX = new SqlCommand(sqlPX, conn);
                cmdPX.Parameters.AddWithValue("@maphieu", txtmaphieu.Text.Trim());
                cmdPX.Parameters.AddWithValue("@ngay", dtpngaynhap.Value);
                cmdPX.Parameters.AddWithValue("@makk", cbomakhachhang.SelectedValue?.ToString() ?? "");
                cmdPX.Parameters.AddWithValue("@manv", cbomanguoilap.SelectedValue?.ToString() ?? "");
                cmdPX.Parameters.AddWithValue("@ghichu", txtghichu.Text.Trim());
                cmdPX.ExecuteNonQuery();

                string sqlCT = "INSERT INTO ChiTietPhieuXuat(MaPhieuXuat, MaHangHoa, SoLuong, DonGia) " +
                               "VALUES(@maphieu, @mavt, @soluong, @dongia)";
                SqlCommand cmdCT = new SqlCommand(sqlCT, conn);
                cmdCT.Parameters.AddWithValue("@maphieu", txtmaphieu.Text.Trim());
                cmdCT.Parameters.AddWithValue("@mavt", txtmavattu.Text.Trim());
                cmdCT.Parameters.AddWithValue("@soluong", int.Parse(txtsoluong.Text.Trim()));
                cmdCT.Parameters.AddWithValue("@dongia", float.Parse(txtdongia.Text.Trim()));
                cmdCT.ExecuteNonQuery();

                Load_PhieuXuat("", "", "");
                MessageBox.Show("Lưu thành công!");
            }
        }

        private void btnsua_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtmaphieu.Text.Trim()) || string.IsNullOrEmpty(txtmavattu.Text.Trim()))
            {
                MessageBox.Show("Vui lòng chọn dòng cần sửa trên bảng!");
                return;
            }

            using (SqlConnection conn = new SqlConnection(str))
            {
                conn.Open();

                string sqlPX = "UPDATE PhieuXuat SET NgayXuat = @ngay, MaKhachHang = @makh, MaNhanVien = @manv, GhiChu = @ghichu " +
                               "WHERE MaPhieuXuat = @maphieu";
                using (SqlCommand cmdPX = new SqlCommand(sqlPX, conn))
                {
                    cmdPX.Parameters.AddWithValue("@maphieu", txtmaphieu.Text.Trim());
                    cmdPX.Parameters.AddWithValue("@ngay", dtpngaynhap.Value);
                    cmdPX.Parameters.AddWithValue("@makh", cbomakhachhang.SelectedValue?.ToString() ?? "");
                    cmdPX.Parameters.AddWithValue("@manv", cbomanguoilap.SelectedValue?.ToString() ?? "");
                    cmdPX.Parameters.AddWithValue("@ghichu", txtghichu.Text.Trim());
                    cmdPX.ExecuteNonQuery();
                }

                string sqlCT = "UPDATE ChiTietPhieuXuat SET SoLuong = @soluong, DonGia = @dongia " +
                               "WHERE MaPhieuXuat = @maphieu AND MaHangHoa = @mavt";
                using (SqlCommand cmdCT = new SqlCommand(sqlCT, conn))
                {
                    cmdCT.Parameters.AddWithValue("@maphieu", txtmaphieu.Text.Trim());
                    cmdCT.Parameters.AddWithValue("@mavt", txtmavattu.Text.Trim());
                    cmdCT.Parameters.AddWithValue("@soluong", int.Parse(txtsoluong.Text.Trim()));
                    cmdCT.Parameters.AddWithValue("@dongia", float.Parse(txtdongia.Text.Trim()));
                    cmdCT.ExecuteNonQuery();
                }

                Load_PhieuXuat("", "", "");
                MessageBox.Show("Sửa thành công!");
            }
        }

        private void btnxoa_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(str))
            {
                conn.Open();
                string sql = "DELETE FROM ChiTietPhieuXuat WHERE MaPhieuXuat = @maphieu AND MaHangHoa = @mavt";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@maphieu", txtmaphieu.Text.Trim());
                cmd.Parameters.AddWithValue("@mavt", txtmavattu.Text.Trim());
                cmd.ExecuteNonQuery();

                Load_PhieuXuat("", "", "");
                MessageBox.Show("Xóa thành công!");
            }
        }

        private void btntimkiem_Click(object sender, EventArgs e)
        {
            string maPhieu = txttimkiemmaphieuxuat.Text.Trim();
            string maVatTu = "";
            string tenVatTu = txttimkiemtenvattu.Text.Trim();

            Load_PhieuXuat(maPhieu, maVatTu, tenVatTu);
        }

        private void btnxuatfile_Click(object sender, EventArgs e)
        {
            SaveFileDialog s = new SaveFileDialog() { Filter = "CSV|*.csv", FileName = "PhieuXuat.csv" };
            if (s.ShowDialog() == DialogResult.OK)
            {
                using (System.IO.StreamWriter sw = new System.IO.StreamWriter(s.FileName, false, Encoding.UTF8))
                {
                    foreach (DataGridViewRow r in dgvchitiet.Rows)
                    {
                        if (!r.IsNewRow)
                        {
                            string line = string.Join(",", r.Cells.Cast<DataGridViewCell>().Select(c => c.Value?.ToString() ?? ""));
                            sw.WriteLine(line);
                        }
                    }
                }
                MessageBox.Show("Xuất file thành công!");
            }
        }

        private void btnquaylai_Click(object sender, EventArgs e)
        {
            frmQuanLyXuat tc = new frmQuanLyXuat();
            tc.Show();
            this.Close();
        }

        
    }
}
