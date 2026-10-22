using BTL_QLKVT;
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
using xuatkhovt;

namespace khách_hàng
{
    public partial class frmQuanLyXuat : Form
    {
        string connectionString = @"Data Source=.;Initial Catalog=QL_khovattufinal;Integrated Security=True";

        public frmQuanLyXuat()
        {

            InitializeComponent();
            LoadComboBoxMaVatTu();
            LoadDataQuanLyXuat();
        }
        // 1. Tải danh sách Phiếu Xuất lên dgvquanlyxuat (Bảng xuất)
        private void LoadDataQuanLyXuat()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = @"SELECT px.MaPhieuXuat AS [Mã phiếu], 
                                        px.NgayXuat AS [Ngày xuất], 
                                        px.MaKhachHang AS [Mã KH], 
                                        px.MaNhanVien AS [Mã NV], 
                                        ct.MaHangHoa AS [Mã vật tư], 
                                        hh.TenHangHoa AS [Tên vật tư], 
                                        ct.SoLuong AS [Số lượng], 
                                        ct.DonGia AS [Đơn giá], 
                                        px.GhiChu AS [Ghi chú] 
                                 FROM PhieuXuat px
                                 JOIN ChiTietPhieuXuat ct ON px.MaPhieuXuat = ct.MaPhieuXuat
                                 JOIN HangHoa hh ON ct.MaHangHoa = hh.MaHangHoa";

                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);

                dgvquanlyxuat.DataSource = dt;
            }
        }


        // Tải danh sách Mã vật tư vào ComboBox
        private void LoadComboBoxMaVatTu()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT MaHangHoa, TenHangHoa FROM HangHoa";
                    SqlDataAdapter da = new SqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    DataRow row = dt.NewRow();
                    row["MaHangHoa"] = "";
                    row["TenHangHoa"] = "-- Tất cả vật tư --";
                    dt.Rows.InsertAt(row, 0);

                    cbomavattu.DataSource = dt;
                    cbomavattu.DisplayMember = "MaHangHoa"; // Hoặc TenHangHoa tùy ý bạn muốn hiển thị mã hay tên
                    cbomavattu.ValueMember = "MaHangHoa";
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi tải danh sách vật tư: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void dgvquanlyxuat_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dgvquanlyxuat.Rows.Count)
            {
                DataGridViewRow row = dgvquanlyxuat.Rows[e.RowIndex];
                if (row.Cells["Mã phiếu"].Value != null && row.Cells["Mã phiếu"].Value != DBNull.Value)
                {
                    string maPhieu = row.Cells["Mã phiếu"].Value.ToString().Trim();

                    // Ví dụ: Đưa mã phiếu lên ô TextBox tìm kiếm hoặc xử lý tiếp
                    txtmaphieu.Text = maPhieu;
                }
            }
        }

        private void guna2GroupBox1_Click(object sender, EventArgs e)
        {

        }

        private void Quản_lý_xuất_Load(object sender, EventArgs e)
        {

        }

        private void btnthem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Mở form lập phiếu xuất mới thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            xuatkho f = new xuatkho();
            f.Show();
            LoadDataQuanLyXuat();
        }

        private void btnxoa_Click(object sender, EventArgs e)
        {
            if (dgvquanlyxuat.SelectedRows.Count > 0)
            {
                string maPhieu = dgvquanlyxuat.SelectedRows[0].Cells["Mã phiếu"].Value.ToString();
                DialogResult dr = MessageBox.Show($"Bạn có chắc chắn muốn xóa phiếu xuất [{maPhieu}] không?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (dr == DialogResult.Yes)
                {
                    using (SqlConnection conn = new SqlConnection(connectionString))
                    {
                        conn.Open();
                        SqlCommand cmdDetail = new SqlCommand("DELETE FROM ChiTietPhieuXuat WHERE MaPhieuXuat = @MaPhieu", conn);
                        cmdDetail.Parameters.AddWithValue("@MaPhieu", maPhieu);
                        cmdDetail.ExecuteNonQuery();

                        SqlCommand cmdMaster = new SqlCommand("DELETE FROM PhieuXuat WHERE MaPhieuXuat = @MaPhieu", conn);
                        cmdMaster.Parameters.AddWithValue("@MaPhieu", maPhieu);
                        cmdMaster.ExecuteNonQuery();

                        MessageBox.Show("Xóa phiếu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadDataQuanLyXuat();
                    }
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn dòng phiếu xuất cần xóa!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void btntimkiem_Click(object sender, EventArgs e)
        {

            string maPhieu = txtmaphieu.Text.Trim();
            string maVatTu = cbomavattu.SelectedValue?.ToString();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = @"SELECT px.MaPhieuXuat AS [Mã phiếu], 
                                        px.NgayXuat AS [Ngày xuất], 
                                        px.MaKhachHang AS [Mã KH], 
                                        px.MaNhanVien AS [Mã NV], 
                                        ct.MaHangHoa AS [Mã vật tư], 
                                        hh.TenHangHoa AS [Tên vật tư], 
                                        ct.SoLuong AS [Số lượng], 
                                        ct.DonGia AS [Đơn giá], 
                                        px.GhiChu AS [Ghi chú] 
                                 FROM PhieuXuat px
                                 JOIN ChiTietPhieuXuat ct ON px.MaPhieuXuat = ct.MaPhieuXuat
                                 JOIN HangHoa hh ON ct.MaHangHoa = hh.MaHangHoa
                                 WHERE 1=1";

                if (!string.IsNullOrEmpty(maPhieu))
                {
                    query += " AND px.MaPhieuXuat LIKE @MaPhieu";
                }

                if (!string.IsNullOrEmpty(maVatTu))
                {
                    query += " AND ct.MaHangHoa = @MaVatTu";
                }

                SqlCommand cmd = new SqlCommand(query, conn);

                if (!string.IsNullOrEmpty(maPhieu))
                {
                    cmd.Parameters.AddWithValue("@MaPhieu", "%" + maPhieu + "%");
                }

                if (!string.IsNullOrEmpty(maVatTu))
                {
                    cmd.Parameters.AddWithValue("@MaVatTu", maVatTu);
                }

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvquanlyxuat.DataSource = dt;

                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("Không tìm thấy thông tin phù hợp!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void btnloc_Click(object sender, EventArgs e)
        {
            DateTime tuNgay = dtptungay.Value.Date;
            DateTime denNgay = dtpdenngay.Value.Date;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = @"SELECT px.MaPhieuXuat AS [Mã phiếu], 
                                        px.NgayXuat AS [Ngày xuất], 
                                        px.MaKhachHang AS [Mã KH], 
                                        px.MaNhanVien AS [Mã NV], 
                                        ct.MaHangHoa AS [Mã vật tư],
hh.TenHangHoa AS [Tên vật tư],
ct.SoLuong AS [Số lượng], 
                                        ct.DonGia AS [Đơn giá], 
                                        px.GhiChu AS [Ghi chú] 
                                 FROM PhieuXuat px
                                 JOIN ChiTietPhieuXuat ct ON px.MaPhieuXuat = ct.MaPhieuXuat
                                 JOIN HangHoa hh ON ct.MaHangHoa = hh.MaHangHoa
                                 WHERE px.NgayXuat BETWEEN @TuNgay AND @DenNgay";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@TuNgay", tuNgay);
                cmd.Parameters.AddWithValue("@DenNgay", denNgay); // (Sửa lỗi chính tả biến nếu cần, hoặc dùng lệnh dưới)

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvquanlyxuat.DataSource = dt;

                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("Không tìm thấy phiếu xuất nào phù hợp với điều kiện lọc!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void btnlammoi_Click(object sender, EventArgs e)
        {
            dtptungay.Value = DateTime.Now;
            dtpdenngay.Value = DateTime.Now;

            LoadDataQuanLyXuat();
        }
        private void btnquaylai_Click(object sender, EventArgs e)
        {
            frmtrangchu f = new frmtrangchu();
            f.Show();
            this.Hide();
        }

        private void dgvquanlyxuat_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvquanlyxuat_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            LoadComboBoxMaVatTu();
            LoadDataQuanLyXuat();
        }
    }
}