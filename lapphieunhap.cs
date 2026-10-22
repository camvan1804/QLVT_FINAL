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
    public partial class quanlyphieunhap : Form

    {
        string str = @"Data Source=.;Initial Catalog=QL_khovattufinal;Integrated Security=True";
        public quanlyphieunhap()
        {
            InitializeComponent();
        }

        private void quanlyphieunhap_Load(object sender, EventArgs e)
        {
            // Đặt ngày mặc định: Từ ngày đầu tháng hiện tại -> Đến ngày hôm nay
            dtptungay.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            dtpdenngay.Value = DateTime.Now;

            // Load dữ liệu bảng và các combobox
            LoadDanhSachVatTuNhap();
            LoadComboBoxPhieuNhap();
            LoadComboBoxVatTu();
        }

        private void LoadDanhSachVatTuNhap()
        {
            using (SqlConnection conn = new SqlConnection(str))
            {

                conn.Open();
                string sql = @"
                        SELECT 
                            pn.MaPhieuNhap AS [Mã phiếu], 
                            pn.NgayNhap AS [Ngày nhập], 
                            ncc.TenNhaCungCap AS [Tên NCC], 
                            nv.TenNhanVien AS [Tên nhân viên], 
                            ct.MaHangHoa AS [Mã vật tư], 
                            h.TenHangHoa AS [Tên vật tư], 
                            h.DonViTinh AS [Đơn vị tính], 
                            ct.SoLuong AS [Số lượng], 
                            ct.DonGia AS [Đơn giá], 
                            (ct.SoLuong * ct.DonGia) AS [Thành tiền], 
                            pn.GhiChu AS [Ghi chú]
                        FROM PhieuNhap pn
                        INNER JOIN ChiTietPhieuNhap ct ON pn.MaPhieuNhap = ct.MaPhieuNhap
                        INNER JOIN HangHoa h ON ct.MaHangHoa = h.MaHangHoa
                        LEFT JOIN NhaCungCap ncc ON pn.MaNhaCungCap = ncc.MaNhaCungCap
                        LEFT JOIN NhanVien nv ON pn.MaNhanVien = nv.MaNhanVien
                        ORDER BY pn.NgayNhap DESC, pn.MaPhieuNhap DESC";

                SqlDataAdapter da = new SqlDataAdapter(sql, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);

                dgvchitiet.DataSource = dt;
                FormatDataGridView();
            }
        }
        private void FormatDataGridView()
        {
            if (dgvchitiet.Columns["Đơn giá"] != null)
                dgvchitiet.Columns["Đơn giá"].DefaultCellStyle.Format = "N0";

            if (dgvchitiet.Columns["Thành tiền"] != null)
                dgvchitiet.Columns["Thành tiền"].DefaultCellStyle.Format = "N0";

            if (dgvchitiet.Columns["Ngày nhập"] != null)
                dgvchitiet.Columns["Ngày nhập"].DefaultCellStyle.Format = "dd/MM/yyyy";
        }


        // Đổ dữ liệu cho ComboBox Phiếu Nhập (Mã phiếu và Ghi chú/Mã phiếu)


        private void LoadComboBoxPhieuNhap()
        {
            using (SqlConnection conn = new SqlConnection(str))
            {

                conn.Open();
                string sql = "SELECT MaPhieuNhap FROM PhieuNhap";
                SqlDataAdapter da = new SqlDataAdapter(sql, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);

                cbomaphieunhap.DataSource = dt;
                cbomaphieunhap.DisplayMember = "MaPhieuNhap";
                cbomaphieunhap.ValueMember = "MaPhieuNhap";
                cbomaphieunhap.SelectedIndex = -1;
                cbomaphieunhap.Text = "";

            }
        }




        // Đổ dữ liệu cho ComboBox Vật Tư (Mã vật tư và Tên vật tư)
        private void LoadComboBoxVatTu()
        {
            using (SqlConnection conn = new SqlConnection(str))
            {
                conn.Open();
                string sql = "SELECT MaHangHoa, TenHangHoa FROM HangHoa";
                SqlDataAdapter da = new SqlDataAdapter(sql, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);

                cbomavattu.DataSource = dt;
                cbomavattu.DisplayMember = "MaHangHoa";
                cbomavattu.ValueMember = "MaHangHoa";
                cbomavattu.SelectedIndex = -1;
                cbomavattu.Text = "";
            }
        }
        private void ResetBoLoc()
        {
            cbomaphieunhap.SelectedIndex = -1;
            cbomaphieunhap.Text = "";

            cbomavattu.SelectedIndex = -1;
            cbomavattu.Text = "";

            // Nếu bạn có thêm các ComboBox khác thì reset luôn tại đây



        }




        private void Lập_phiếu_nhập_Load(object sender, EventArgs e)
        {

        }

        private void guna2TextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        /*private void dgvphieunhap_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int i = e.RowIndex;
            if (i >= 0 && i < dgvphieunhap.Rows.Count)
            {
                string maPhieu = dgvphieunhap.Rows[i].Cells["MaPhieuNhap"].Value.ToString();
                LoadChiTietPhieuNhap(maPhieu);
            }
        }*/
        private void guna2Button1_Click_1(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(str))
            {

                conn.Open();
                string sql = @"
                        SELECT 
                            pn.MaPhieuNhap AS [Mã phiếu], 
                            pn.NgayNhap AS [Ngày nhập], 
                            ncc.TenNhaCungCap AS [Tên NCC], 
                            nv.TenNhanVien AS [Tên nhân viên], 
                            ct.MaHangHoa AS [Mã vật tư], 
                            h.TenHangHoa AS [Tên vật tư], 
                            h.DonViTinh AS [Đơn vị tính], 
                            ct.SoLuong AS [Số lượng], 
                            ct.DonGia AS [Đơn giá], 
                            (ct.SoLuong * ct.DonGia) AS [Thành tiền], 
                            pn.GhiChu AS [Ghi chú]
                        FROM PhieuNhap pn
                        INNER JOIN ChiTietPhieuNhap ct ON pn.MaPhieuNhap = ct.MaPhieuNhap
                        INNER JOIN HangHoa h ON ct.MaHangHoa = h.MaHangHoa
                        LEFT JOIN NhaCungCap ncc ON pn.MaNhaCungCap = ncc.MaNhaCungCap
                        LEFT JOIN NhanVien nv ON pn.MaNhanVien = nv.MaNhanVien
                        WHERE pn.NgayNhap BETWEEN @tuNgay AND @denNgay
                        ORDER BY pn.NgayNhap DESC";

                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.Add("@tuNgay", SqlDbType.Date).Value = dtptungay.Value.Date;
                cmd.Parameters.Add("@denNgay", SqlDbType.Date).Value = dtpdenngay.Value.Date;

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                dgvchitiet.DataSource = dt;
                FormatDataGridView();

                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("Không tìm thấy dữ liệu nhập kho trong khoảng thời gian này!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }


        private void btnxoa_Click(object sender, EventArgs e)
        {
            if (dgvchitiet.SelectedRows.Count == 0 && dgvchitiet.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn phiếu nhập cần hủy/xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string maPhieu = dgvchitiet.CurrentRow.Cells["MaPhieuNhap"].Value.ToString();

            DialogResult kq = MessageBox.Show($"Bạn có chắc chắn muốn hủy phiếu nhập [{maPhieu}] không?\n(Thao tác này sẽ trừ ngược lại số lượng tồn kho của các mặt hàng trong phiếu)",
                "Xác nhận hủy phiếu", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (kq == DialogResult.Yes)
            {
                using (SqlConnection conn = new SqlConnection(str))
                {
                    conn.Open();
                    SqlTransaction transaction = conn.BeginTransaction();



                    // Bước A: Lấy danh sách các mặt hàng và số lượng trong phiếu để trừ kho
                    string sqlGetCT = "SELECT MaHangHoa, SoLuong FROM ChiTietPhieuNhap WHERE MaPhieuNhap = @maphieu";
                    DataTable dtCT = new DataTable();
                    using (SqlCommand cmdGet = new SqlCommand(sqlGetCT, conn, transaction))
                    {
                        cmdGet.Parameters.Add("@maphieu", SqlDbType.VarChar, 20).Value = maPhieu;
                        SqlDataAdapter da = new SqlDataAdapter(cmdGet);
                        da.Fill(dtCT);
                    }

                    // Bước B: Trừ ngược lại số lượng tồn kho trong bảng HangHoa
                    foreach (DataRow row in dtCT.Rows)
                    {
                        string maHH = row["MaHangHoa"].ToString();
                        int slXoa = Convert.ToInt32(row["SoLuong"]);

                        string sqlUpdateKho = "UPDATE HangHoa SET SoLuong = SoLuong - @soluong WHERE MaHangHoa = @mahh";
                        using (SqlCommand cmdUpKho = new SqlCommand(sqlUpdateKho, conn, transaction))
                        {
                            cmdUpKho.Parameters.Add("@soluong", SqlDbType.Int).Value = slXoa;
                            cmdUpKho.Parameters.Add("@mahh", SqlDbType.VarChar, 20).Value = maHH;
                            cmdUpKho.ExecuteNonQuery();
                        }
                    }

                    // Bước C: Xóa dữ liệu trong bảng ChiTietPhieuNhap
                    string sqlDelCT = "DELETE FROM ChiTietPhieuNhap WHERE MaPhieuNhap = @maphieu";
                    using (SqlCommand cmdDelCT = new SqlCommand(sqlDelCT, conn, transaction))
                    {
                        cmdDelCT.Parameters.Add("@maphieu", SqlDbType.VarChar, 20).Value = maPhieu;
                        cmdDelCT.ExecuteNonQuery();
                    }

                    // Bước D: Xóa dữ liệu trong bảng PhieuNhap
                    string sqlDelPN = "DELETE FROM PhieuNhap WHERE MaPhieuNhap = @maphieu";
                    using (SqlCommand cmdDelPN = new SqlCommand(sqlDelPN, conn, transaction))
                    {
                        cmdDelPN.Parameters.Add("@maphieu", SqlDbType.VarChar, 20).Value = maPhieu;
                        cmdDelPN.ExecuteNonQuery();
                    }

                    transaction.Commit();
                    MessageBox.Show("Đã hủy phiếu nhập và cập nhật lại kho thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadDanhSachVatTuNhap(); // Tải lại danh sách
                }

            }
        }


        private void btnthem_Click_1(object sender, EventArgs e)
        {
            form2 frm = new form2();
            frm.ShowDialog(); // Mở form lập phiếu nhập
            LoadDanhSachVatTuNhap(); // Tải lại danh sách sau khi thêm
        }

        private void btnlammoi_Click(object sender, EventArgs e)
        {
            dtptungay.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            dtpdenngay.Value = DateTime.Now;

            cbomaphieunhap.SelectedIndex = -1;
            cbomaphieunhap.Text = "";
            cbomavattu.SelectedIndex = -1;
            cbomavattu.Text = "";

            LoadDanhSachVatTuNhap();
        }



        /* private void dgvphieunhap_CellClick_1(object sender, DataGridViewCellEventArgs e)
         {

             if (e.RowIndex >= 0)
             {
                 DataGridViewRow row = dgvphieunhap.Rows[e.RowIndex];

                 var cellValue = row.Cells["MaPhieuNhap"].Value;
                 if (cellValue != null && cellValue != DBNull.Value)
                 {
                     string maPhieu = cellValue.ToString();

                     // Lấy mã vật tư đang chọn trên ComboBox phía trên
                     string maVatTuDangChon = cbomavattu != null && cbomavattu.SelectedValue != null ? cbomavattu.SelectedValue.ToString().Trim() : "";

                     // Nếu người dùng chọn "System.Data.DataRowView" hoặc để trống thì coi như không lọc theo vật tư
                     if (maVatTuDangChon == "System.Data.DataRowView")
                     {
                         maVatTuDangChon = "";
                     }

                     // Truyền cả mã phiếu và mã vật tư đang chọn xuống hàm load chi tiết
                     LoadChiTietPhieuNhap(maPhieu, maVatTuDangChon);
                 }
             }
         }*/

        


        private void btnquaylai_Click(object sender, EventArgs e)
        {
            // Mở lại form trang chủ
            frmtrangchu tc = new frmtrangchu();
            tc.Show();

            // Đóng hoặc ẩn form kiểm kê hiện tại đi
            this.Close(); // hoặc dùng this.Hide();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dgvchitiet.Rows.Count)
            {
                DataGridViewRow row = dgvchitiet.Rows[e.RowIndex];

                // Lấy Mã phiếu và Mã vật tư từ dòng đang chọn trên bảng
                var valMaPhieu = row.Cells["Mã phiếu"].Value;
                var valMaVatTu = row.Cells["Mã vật tư"].Value;

                string maPhieu = (valMaPhieu != null && valMaPhieu != DBNull.Value) ? valMaPhieu.ToString().Trim() : "";
                string maVatTu = (valMaVatTu != null && valMaVatTu != DBNull.Value) ? valMaVatTu.ToString().Trim() : "";

                // Ví dụ: Hiển thị thông báo kiểm tra khi bạn ấn vào dòng
                MessageBox.Show($"Bạn vừa chọn:\n- Mã phiếu: {maPhieu}\n- Mã vật tư: {maVatTu}", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Nếu bạn muốn tự động điền giá trị này vào các ComboBox phía trên để tiện thao tác, có thể bật dòng dưới đây:
                // cbomaphieunhap.Text = maPhieu;
                // cbomavattu.Text = maVatTu;
            }
        }

        private void dgvchitiet_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void cbomaphieunhap_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btntimkiem_Click_1(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(str))
            {

                conn.Open();

                string maPhieu = cbomaphieunhap.SelectedValue != null ? cbomaphieunhap.SelectedValue.ToString().Trim() : cbomaphieunhap.Text.Trim();
                string maVatTu = cbomavattu.SelectedValue != null ? cbomavattu.SelectedValue.ToString().Trim() : cbomavattu.Text.Trim();

                if (maPhieu == "System.Data.DataRowView") maPhieu = "";
                if (maVatTu == "System.Data.DataRowView") maVatTu = "";

                if (string.IsNullOrEmpty(maPhieu) && string.IsNullOrEmpty(maVatTu))
                {
                    MessageBox.Show("Vui lòng chọn hoặc nhập Mã phiếu / Mã vật tư cần tìm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string sql = @"
                        SELECT 
                            pn.MaPhieuNhap AS [Mã phiếu], 
                            pn.NgayNhap AS [Ngày nhập], 
                            ncc.TenNhaCungCap AS [Tên NCC], 
                            nv.TenNhanVien AS [Tên nhân viên], 
                            ct.MaHangHoa AS [Mã vật tư], 
                            h.TenHangHoa AS [Tên vật tư], 
                            h.DonViTinh AS [Đơn vị tính], 
                            ct.SoLuong AS [Số lượng], 
                            ct.DonGia AS [Đơn giá], 
                            (ct.SoLuong * ct.DonGia) AS [Thành tiền], 
                            pn.GhiChu AS [Ghi chú]
                        FROM PhieuNhap pn
                        INNER JOIN ChiTietPhieuNhap ct ON pn.MaPhieuNhap = ct.MaPhieuNhap
                        INNER JOIN HangHoa h ON ct.MaHangHoa = h.MaHangHoa
                        LEFT JOIN NhaCungCap ncc ON pn.MaNhaCungCap = ncc.MaNhaCungCap
                        LEFT JOIN NhanVien nv ON pn.MaNhanVien = nv.MaNhanVien
                        WHERE 1=1";

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;

                if (!string.IsNullOrEmpty(maPhieu))
                {
                    sql += " AND pn.MaPhieuNhap LIKE @maPhieu";
                    cmd.Parameters.AddWithValue("@maPhieu", "%" + maPhieu + "%");
                }

                if (!string.IsNullOrEmpty(maVatTu))
                {
                    sql += " AND ct.MaHangHoa LIKE @maVatTu";
                    cmd.Parameters.AddWithValue("@maVatTu", "%" + maVatTu + "%");
                }

                cmd.CommandText = sql;

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                dgvchitiet.DataSource = dt;
                FormatDataGridView();

                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("Không tìm thấy kết quả phù hợp!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
    }
}
    
    

