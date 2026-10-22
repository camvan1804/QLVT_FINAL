using BTLnhom6_quanlybattu;
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

namespace baitaplonQLVT
{
    public partial class form2 : Form
    {
        string str = @"Data Source=.;Initial Catalog=QL_khovattufinal;Integrated Security=True";

        public form2()
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
        private void LoadComboBoxNhaCungCap()
        {
            using (SqlConnection conn = new SqlConnection(str))
            {
                conn.Open();
                string sql = "SELECT MaNhaCungCap, TenNhaCungCap FROM NhaCungCap";
                SqlDataAdapter da = new SqlDataAdapter(sql, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                cbomanhacungcap.DataSource = dt;
                cbomanhacungcap.DisplayMember = "MaNhaCungCap";
                cbomanhacungcap.ValueMember = "MaNhaCungCap";

                cbonhacungcap.DataSource = dt.Copy();
                cbonhacungcap.DisplayMember = "TenNhaCungCap";
                cbonhacungcap.ValueMember = "MaNhaCungCap";
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

                // ComboBox mã nhân viên
                cbomanguoilap.DataSource = dt;
                cbomanguoilap.DisplayMember = "MaNhanVien";
                cbomanguoilap.ValueMember = "MaNhanVien";

                // ComboBox tên nhân viên
                cbotennguoilap.DataSource = dt.Copy();
                cbotennguoilap.DisplayMember = "TenNhanVien";
                cbotennguoilap.ValueMember = "MaNhanVien";
            }
        }
        private void Load_PhieuNhap(string maphieu, string mavt, string tenVat)
        {
            using (SqlConnection conn = new SqlConnection(str))
            {
                conn.Open();
                string sql = "SELECT ROW_NUMBER() OVER(ORDER BY pn.MaPhieuNhap) AS Stt, " +
                             "pn.MaPhieuNhap, pn.NgayNhap, ct.MaHangHoa, h.TenHangHoa, " +
                             "ct.SoLuong, ct.DonGia, (ct.SoLuong * ct.DonGia) AS ThanhTien, " +
                             "pn.MaNhaCungCap, pn.MaNhanVien, pn.GhiChu " +
                             "FROM PhieuNhap pn " +
                             "JOIN ChiTietPhieuNhap ct ON pn.MaPhieuNhap = ct.MaPhieuNhap " +
                             "JOIN HangHoa h ON ct.MaHangHoa = h.MaHangHoa " +
                             "WHERE (@maphieu = '' OR pn.MaPhieuNhap LIKE '%' + @maphieu + '%') " +
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
        // Kiểm tra xem mã phiếu đã tồn tại chưa
        private bool CheckTrungMaPhieu(string maPhieu, SqlConnection conn, SqlTransaction transaction)
        {
            string sql = "SELECT COUNT(*) FROM PhieuNhap WHERE MaPhieuNhap = @maphieu";
            using (SqlCommand cmd = new SqlCommand(sql, conn, transaction))
            {
                cmd.Parameters.Add("@maphieu", SqlDbType.VarChar, 20).Value = maPhieu;
                int count = (int)cmd.ExecuteScalar();
                return count > 0;
            }
        }
        private void dgvchitiet_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int i = e.RowIndex;
            if (i >= 0 && i < dgvchitiet.Rows.Count)
            {
                if (dgvchitiet.Rows[i].Cells["MaPhieuNhap"].Value != DBNull.Value)
                    txtmaphieu.Text = dgvchitiet.Rows[i].Cells["MaPhieuNhap"].Value.ToString();

                if (dgvchitiet.Rows[i].Cells["NgayNhap"].Value != DBNull.Value)
                {
                    dtpngaynhap.Value = Convert.ToDateTime(dgvchitiet.Rows[i].Cells["NgayNhap"].Value);
                }

                if (dgvchitiet.Rows[i].Cells["TenHangHoa"].Value != DBNull.Value)
                    txtvattu.Text = dgvchitiet.Rows[i].Cells["TenHangHoa"].Value.ToString();

                if (dgvchitiet.Rows[i].Cells["MaHangHoa"].Value != DBNull.Value)
                    txtmavattu.Text = dgvchitiet.Rows[i].Cells["MaHangHoa"].Value.ToString();

                if (dgvchitiet.Rows[i].Cells["SoLuong"].Value != DBNull.Value)
                    txtsoluong.Text = dgvchitiet.Rows[i].Cells["SoLuong"].Value.ToString();

                if (dgvchitiet.Rows[i].Cells["DonGia"].Value != DBNull.Value)
                    txtdongia.Text = dgvchitiet.Rows[i].Cells["DonGia"].Value.ToString();

                if (dgvchitiet.Rows[i].Cells["MaNhaCungCap"].Value != DBNull.Value)
                {
                    cbomanhacungcap.SelectedValue = dgvchitiet.Rows[i].Cells["MaNhaCungCap"].Value.ToString();
                }

                if (dgvchitiet.Rows[i].Cells["MaNhanVien"].Value != DBNull.Value)
                {
                    cbomanguoilap.SelectedValue = dgvchitiet.Rows[i].Cells["MaNhanVien"].Value.ToString();
                }
            }
        }
        private void txtdongia_TextChanged_1(object sender, EventArgs e)
        {
            TinhTongTien();
        }

        private void txttongtien_TextChanged(object sender, EventArgs e)
        {
            TinhTongTien();
        }
        private void form2_Load_1(object sender, EventArgs e)
        {
            txtmaphieu.Text = "PN" + DateTime.Now.ToString("yyyyMMddHHmmss");
            LoadComboBoxNhaCungCap();
            LoadComboBoxNhanVien();

            // Tải danh sách phiếu nhập lên DataGridView
            Load_PhieuNhap("", "", "");

            // Làm sạch các ô nhập liệu để form trống, sẵn sàng cho việc thêm mới
            txtmavattu.Clear();
            txtvattu.Clear();
            txtsoluong.Clear();
            txtdongia.Clear();
            txttongtien.Clear();
            cbomanhacungcap.SelectedIndex = -1;
            cbonhacungcap.SelectedIndex = -1;
            cbomanguoilap.SelectedIndex = -1;
            cbotennguoilap.SelectedIndex = -1;
        }

        private void btnluu_Click(object sender, EventArgs e)
        {
            string maphieu = txtmaphieu.Text.Trim();
            DateTime ngaynhap = dtpngaynhap.Value;
            string manhacungcap = cbomanhacungcap.Text.Trim();
            string manhanvien = cbomanguoilap.Text.Trim();
            string mahanghoa = txtmavattu.Text.Trim();

            int soluong = 0;
            int.TryParse(txtsoluong.Text.Trim(), out soluong);

            float dongia = 0;
            float.TryParse(txtdongia.Text.Trim(), out dongia);

            string ghichu = "";

            if (maphieu == "")
            {
                txtmaphieu.Focus();
                MessageBox.Show("Mã phiếu không được để trống!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (mahanghoa == "")
            {
                txtmavattu.Focus();
                MessageBox.Show("Mã vật tư không được để trống!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (SqlConnection conn = new SqlConnection(str))
            {
                conn.Open();
                SqlTransaction transaction = conn.BeginTransaction();

                string tenhanghoa = txtvattu.Text.Trim();
                if (string.IsNullOrEmpty(tenhanghoa))
                {
                    tenhanghoa = "Vật tư " + mahanghoa;
                }

                // 1. Kiểm tra hàng hóa
                string sqlCheckHH = "SELECT COUNT(*) FROM HangHoa WHERE MaHangHoa = @mahanghoa";
                using (SqlCommand cmdCheck = new SqlCommand(sqlCheckHH, conn, transaction))
                {
                    cmdCheck.Parameters.Add("@mahanghoa", SqlDbType.VarChar, 20).Value = mahanghoa;
                    int countHH = (int)cmdCheck.ExecuteScalar();

                    if (countHH == 0)
                    {
                        string sqlInsertHH = "INSERT INTO HangHoa (MaHangHoa, TenHangHoa, MaNhaCungCap, SoLuong, DonViTinh) " +
                                             "VALUES (@mahanghoa, @tenhanghoa, @manhacungcap, 0, N'Cái')";
                        using (SqlCommand cmdInsHH = new SqlCommand(sqlInsertHH, conn, transaction))
                        {
                            cmdInsHH.Parameters.Add("@mahanghoa", SqlDbType.VarChar, 20).Value = mahanghoa;
                            cmdInsHH.Parameters.Add("@tenhanghoa", SqlDbType.NVarChar, 100).Value = tenhanghoa;
                            cmdInsHH.Parameters.Add("@manhacungcap", SqlDbType.VarChar, 20).Value = manhacungcap;
                            cmdInsHH.ExecuteNonQuery();
                        }
                    }
                }

                // 2. Kiểm tra Phiếu Nhập
                if (!CheckTrungMaPhieu(maphieu, conn, transaction))
                {
                    string sqlPN = "INSERT INTO PhieuNhap (MaPhieuNhap, NgayNhap, MaNhaCungCap, MaNhanVien, GhiChu) " +
                                   "VALUES (@maphieu, @ngaynhap, @manhacungcap, @manhanvien, @ghichu)";
                    using (SqlCommand cmdPN = new SqlCommand(sqlPN, conn, transaction))
                    {
                        cmdPN.Parameters.Add("@maphieu", SqlDbType.VarChar, 20).Value = maphieu;
                        cmdPN.Parameters.Add("@ngaynhap", SqlDbType.Date).Value = ngaynhap;
                        cmdPN.Parameters.Add("@manhacungcap", SqlDbType.VarChar, 20).Value = manhacungcap;
                        cmdPN.Parameters.Add("@manhanvien", SqlDbType.VarChar, 20).Value = manhanvien;
                        cmdPN.Parameters.Add("@ghichu", SqlDbType.NVarChar, 200).Value = ghichu;
                        cmdPN.ExecuteNonQuery();
                    }
                }

                // 3. Chi tiết phiếu nhập
                string sqlCheckCT = "SELECT COUNT(*) FROM ChiTietPhieuNhap WHERE MaPhieuNhap = @maphieu AND MaHangHoa = @mahanghoa";
                int countCT = 0;
                using (SqlCommand cmdCheckCT = new SqlCommand(sqlCheckCT, conn, transaction))
                {
                    cmdCheckCT.Parameters.Add("@maphieu", SqlDbType.VarChar, 20).Value = maphieu;
                    cmdCheckCT.Parameters.Add("@mahanghoa", SqlDbType.VarChar, 20).Value = mahanghoa;
                    countCT = (int)cmdCheckCT.ExecuteScalar();
                }

                if (countCT > 0)
                {
                    string sqlUpdateCT = "UPDATE ChiTietPhieuNhap SET SoLuong = SoLuong + @soluong, DonGia = @dongia " +
                                         "WHERE MaPhieuNhap = @maphieu AND MaHangHoa = @mahanghoa";
                    using (SqlCommand cmdUpCT = new SqlCommand(sqlUpdateCT, conn, transaction))
                    {
                        cmdUpCT.Parameters.Add("@maphieu", SqlDbType.VarChar, 20).Value = maphieu;
                        cmdUpCT.Parameters.Add("@mahanghoa", SqlDbType.VarChar, 20).Value = mahanghoa;
                        cmdUpCT.Parameters.Add("@soluong", SqlDbType.Int).Value = soluong;
                        cmdUpCT.Parameters.Add("@dongia", SqlDbType.Float).Value = dongia;
                        cmdUpCT.ExecuteNonQuery();
                    }
                }
                else
                {
                    string sqlCT = "INSERT INTO ChiTietPhieuNhap (MaPhieuNhap, MaHangHoa, SoLuong, DonGia) " +
                                   "VALUES (@maphieu, @mahanghoa, @soluong, @dongia)";
                    using (SqlCommand cmdCT = new SqlCommand(sqlCT, conn, transaction))
                    {
                        cmdCT.Parameters.Add("@maphieu", SqlDbType.VarChar, 20).Value = maphieu;
                        cmdCT.Parameters.Add("@mahanghoa", SqlDbType.VarChar, 20).Value = mahanghoa;
                        cmdCT.Parameters.Add("@soluong", SqlDbType.Int).Value = soluong;
                        cmdCT.Parameters.Add("@dongia", SqlDbType.Float).Value = dongia;
                        cmdCT.ExecuteNonQuery();
                    }
                }

                // 4. Cập nhật tồn kho
                string sqlUpdateKho = "UPDATE HangHoa SET SoLuong = SoLuong + @soluong WHERE MaHangHoa = @mahanghoa";
                using (SqlCommand cmdKho = new SqlCommand(sqlUpdateKho, conn, transaction))
                {
                    cmdKho.Parameters.Add("@soluong", SqlDbType.Int).Value = soluong;
                    cmdKho.Parameters.Add("@mahanghoa", SqlDbType.VarChar, 20).Value = mahanghoa;
                    cmdKho.ExecuteNonQuery();
                }

                transaction.Commit();
                MessageBox.Show("Lưu chi tiết phiếu nhập thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Load_PhieuNhap("", "", "");

                // Làm mới form chuẩn bị nhập tiếp
                txtmaphieu.Text = "PN" + DateTime.Now.ToString("yyyyMMddHHmmss");
                txtmavattu.Clear();
                txtvattu.Clear();
                txtsoluong.Clear();
                txtdongia.Clear();
                txttongtien.Clear();
                txtmavattu.Focus();
            }
        }

        private void btnxoa_Click_1(object sender, EventArgs e)
        {
            string maphieu = txtmaphieu.Text.Trim();
            string mahanghoa = txtmavattu.Text.Trim();

            if (maphieu == "" || mahanghoa == "")
            {
                MessageBox.Show("Vui lòng chọn dòng chi tiết cần xóa trên bảng!");
                return;
            }

            DialogResult kq = MessageBox.Show("Bạn có chắc chắn muốn xóa mặt hàng này khỏi phiếu nhập?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (kq == DialogResult.Yes)
            {
                SqlConnection conn = new SqlConnection(str);
                if (conn.State == ConnectionState.Closed)
                    conn.Open();

                string sql = "DELETE FROM ChiTietPhieuNhap WHERE MaPhieuNhap = @maphieu AND MaHangHoa = @mahanghoa";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.Add("@maphieu", SqlDbType.VarChar, 20).Value = maphieu;
                cmd.Parameters.Add("@mahanghoa", SqlDbType.VarChar, 20).Value = mahanghoa;
                cmd.ExecuteNonQuery();

                cmd.Dispose();
                conn.Close();

                MessageBox.Show("Xóa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Load_PhieuNhap("", "", "");
            }
        }

        private void btnsua_Click_1(object sender, EventArgs e)
        {
            string maphieu = txtmaphieu.Text.Trim();
            string mahanghoa = txtmavattu.Text.Trim();
            int soluong = 0;
            int.TryParse(txtsoluong.Text.Trim(), out soluong);

            float dongia = 0;
            float.TryParse(txtdongia.Text.Trim(), out dongia);

            SqlConnection conn = new SqlConnection(str);
            if (conn.State == ConnectionState.Closed)
                conn.Open();

            string sql = "UPDATE ChiTietPhieuNhap SET SoLuong = @soluong, DonGia = @dongia " +
                         "WHERE MaPhieuNhap = @maphieu AND MaHangHoa = @mahanghoa";
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.Add("@maphieu", SqlDbType.VarChar, 20).Value = maphieu;
            cmd.Parameters.Add("@mahanghoa", SqlDbType.VarChar, 20).Value = mahanghoa;
            cmd.Parameters.Add("@soluong", SqlDbType.Int).Value = soluong;
            cmd.Parameters.Add("@dongia", SqlDbType.Float).Value = dongia;

            cmd.ExecuteNonQuery();
            cmd.Dispose();
            conn.Close();

            MessageBox.Show("Sửa thông tin chi tiết phiếu nhập thành công!");
            Load_PhieuNhap("", "", "");
        }

        private void dgvchitiet_CellClick_2(object sender, DataGridViewCellEventArgs e)
        {
            int i = e.RowIndex;
            if (i >= 0 && i < dgvchitiet.Rows.Count)
            {
                txtmaphieu.Text = dgvchitiet.Rows[i].Cells["MaPhieuNhap"].Value.ToString();

                if (dgvchitiet.Rows[i].Cells["NgayNhap"].Value != DBNull.Value)
                {
                    dtpngaynhap.Value = Convert.ToDateTime(dgvchitiet.Rows[i].Cells["NgayNhap"].Value);
                }
                txtvattu.Text = dgvchitiet.Rows[i].Cells["TenHangHoa"].Value.ToString();
                txtmavattu.Text = dgvchitiet.Rows[i].Cells["MaHangHoa"].Value.ToString();
                txtsoluong.Text = dgvchitiet.Rows[i].Cells["SoLuong"].Value.ToString();
                txtdongia.Text = dgvchitiet.Rows[i].Cells["DonGia"].Value.ToString();

                if (dgvchitiet.Rows[i].Cells["MaNhaCungCap"].Value != DBNull.Value)
                {
                    cbomanhacungcap.SelectedValue = dgvchitiet.Rows[i].Cells["MaNhaCungCap"].Value.ToString();
                }

                if (dgvchitiet.Rows[i].Cells["MaNhanVien"].Value != DBNull.Value)
                {
                    cbomanguoilap.SelectedValue = dgvchitiet.Rows[i].Cells["MaNhanVien"].Value.ToString();
                }
            }
        }

        private void btntimkiem_Click_1(object sender, EventArgs e)
        {

            string maVat = txttimkiemmavattu.Text.Trim();   // Lấy mã vật tư từ ô tìm kiếm mã
            string tenVat = txttimkiemtenvattu.Text.Trim(); // Lấy tên vật tư từ ô tìm kiếm tên

            // Gọi đúng thứ tự: maphieu = "", mavt = maVat, tenVat = tenVat
            Load_PhieuNhap("", maVat, tenVat);
        }


        private void btnlammoi_Click_1(object sender, EventArgs e)
        {
            txtmaphieu.Text = "PN" + DateTime.Now.ToString("yyyyMMddHHmmss");

            txtmavattu.Clear();
            txtvattu.Clear();
            txtsoluong.Clear();
            txtdongia.Clear();
            txttongtien.Clear();

            txttimkiemtenvattu.Clear();
            txttimkiemmavattu.Clear();

            txtmavattu.Focus();
            Load_PhieuNhap("", "", "");
        }
        private void btnquaylai_Click(object sender, EventArgs e)
        {
            // Mở lại form trang chủ
            quanlyphieunhap tc = new quanlyphieunhap();
            tc.Show();

            // Đóng hoặc ẩn form kiểm kê hiện tại đi
            this.Close(); // hoặc dùng this.Hide();
        }
    }
}
    


