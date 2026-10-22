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

namespace BTL_QLKVT
{
    public partial class Frmquanlitaikhoan : Form
    {
        string str = @"Data Source=.;Initial Catalog=QL_khovattufinal;Integrated Security=True;";
        string tableName = "TaiKhoan";
        private bool hienMatKhau = false;

        public Frmquanlitaikhoan()
        {
            InitializeComponent();
        }

        private void Frmquanlitaikhoan_Load(object sender, EventArgs e)
        {
            LoadData();
            LoadVaiTroVaTrangThai();
            LoadNhanVienVaoComboBox();
            dgvtaikhoan.CellClick += dgvtaikhoan_CellClick;
            txtmatkhau.UseSystemPasswordChar = true;
        }

        private void LoadVaiTroVaTrangThai()
        {
            if (cbovaitro != null && cbovaitro.Items.Count == 0)
            {
                cbovaitro.Items.Add("Quản trị viên");
                cbovaitro.Items.Add("Thủ kho");
                cbovaitro.Items.Add("Nhân viên");
            }
            if (cbotrangthai != null && cbotrangthai.Items.Count == 0)
            {
                cbotrangthai.Items.Add("1");
                cbotrangthai.Items.Add("0");
            }
        }
        private void LoadNhanVienVaoComboBox()
        {
            using (SqlConnection conn = new SqlConnection(str))
            {
                conn.Open();
                string query = "SELECT MaNhanVien, TenNhanVien FROM NhanVien";
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);

                cbomahanvien.DataSource = dt;
                cbomahanvien.DisplayMember = "TenNhanVien"; // Hiển thị tên nhân viên
                cbomahanvien.ValueMember = "MaNhanVien";     // Lấy mã nhân viên ngầm bên dưới

                cbomahanvien.SelectedIndex = -1; // <--- Thêm dòng này để không tự động chọn dòng đầu tiên
            }
        }

        private void LoadData()
        {
            using (SqlConnection conn = new SqlConnection(str))
            {
                try
                {
                    conn.Open();
                    // SỬA: Dùng JOIN kết nối bảng NhanVien để lấy Tên thật
                    string query = @"SELECT tk.TenDangNhap, tk.MatKhau, tk.MaNhanVien, nv.TenNhanVien AS HoTen, 
                                     'Nhân viên' AS VaiTro, tk.TrangThai 
                                     FROM TaiKhoan tk 
                                     LEFT JOIN NhanVien nv ON tk.MaNhanVien = nv.MaNhanVien";
                    SqlDataAdapter da = new SqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dgvtaikhoan.DataSource = dt;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi tải dữ liệu tài khoản: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnthem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txttendangnhap.Text))
            {
                MessageBox.Show("Vui lòng nhập tên đăng nhập!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txttendangnhap.Focus();
                return;
            }

            using (SqlConnection conn = new SqlConnection(str))
            {
                try
                {
                    conn.Open();
                    // SỬA: Chỉ lưu 4 cột có thật trong Database
                    string query = "INSERT INTO " + tableName + " (TenDangNhap, MatKhau, MaNhanVien, TrangThai) " +
                                   "VALUES (@TenDangNhap, @MatKhau, @MaNhanVien, @TrangThai)";

                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@TenDangNhap", txttendangnhap.Text.Trim());
                    cmd.Parameters.AddWithValue("@MatKhau", txtmatkhau.Text.Trim());
                    // Lưu ý: Ô txthoten trên form của bạn sẽ được dùng để nhập MÃ NHÂN VIÊN
                    cmd.Parameters.AddWithValue("@MaNhanVien", cbomahanvien.SelectedValue.ToString());
                    cmd.Parameters.AddWithValue("@TrangThai", string.IsNullOrEmpty(cbotrangthai.Text) ? 1 : int.Parse(cbotrangthai.Text));

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Thêm tài khoản thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadData();
                    ClearFields();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi thêm: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnsua_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txttendangnhap.Text))
            {
                MessageBox.Show("Vui lòng chọn tài khoản cần sửa!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (SqlConnection conn = new SqlConnection(str))
            {
                try
                {
                    conn.Open();
                    // SỬA: Chỉ cập nhật 4 cột có thật
                    string query = "UPDATE " + tableName + " SET MatKhau = @MatKhau, MaNhanVien = @MaNhanVien, TrangThai = @TrangThai " +
                                   "WHERE TenDangNhap = @TenDangNhap";

                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@TenDangNhap", txttendangnhap.Text.Trim());
                    cmd.Parameters.AddWithValue("@MatKhau", txtmatkhau.Text.Trim());
                    cmd.Parameters.AddWithValue("@MaNhanVien", cbomahanvien.SelectedValue.ToString());
                    cmd.Parameters.AddWithValue("@TrangThai", int.Parse(cbotrangthai.Text));

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Cập nhật tài khoản thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadData();
                    ClearFields();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi sửa: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void btnxoa_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txttendangnhap.Text))
            {
                MessageBox.Show("Vui lòng chọn tài khoản cần xóa!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show("Bạn có chắc chắn muốn xóa tài khoản này không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                using (SqlConnection conn = new SqlConnection(str))
                {
                    try
                    {
                        conn.Open();
                        string query = "DELETE FROM " + tableName + " WHERE TenDangNhap = @TenDangNhap";
                        SqlCommand cmd = new SqlCommand(query, conn);
                        cmd.Parameters.AddWithValue("@TenDangNhap", txttendangnhap.Text.Trim());

                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Xóa tài khoản thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadData();
                        ClearFields();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi khi xóa: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btnlammoi_Click(object sender, EventArgs e)
        {
            ClearFields();
            LoadData();
        }

        private void ClearFields()
        {
            txttendangnhap.Clear();
            txtmatkhau.Clear();
            cbomahanvien.SelectedIndex = -1;
            cbovaitro.SelectedIndex = -1;
            cbotrangthai.SelectedIndex = -1;
            txttendangnhap.ReadOnly = false;
        }

        private void btntimkiem_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(str))
            {
                try
                {
                    conn.Open();
                    // SỬA: Câu lệnh tìm kiếm có sử dụng JOIN
                    string query = @"SELECT tk.TenDangNhap, tk.MatKhau, tk.MaNhanVien, nv.TenNhanVien AS HoTen, 
                                     'Nhân viên' AS VaiTro, tk.TrangThai 
                                     FROM TaiKhoan tk 
                                     LEFT JOIN NhanVien nv ON tk.MaNhanVien = nv.MaNhanVien
                                     WHERE tk.TenDangNhap LIKE @keyword OR nv.TenNhanVien LIKE @keyword";

                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@keyword", "%" + txttimkiem.Text.Trim() + "%");

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dgvtaikhoan.DataSource = dt;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi tìm kiếm: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void btneye_Click(object sender, EventArgs e)
        {
            hienMatKhau = !hienMatKhau;
            if (hienMatKhau)
            {
                txtmatkhau.UseSystemPasswordChar = false;
            }
            else
            {
                txtmatkhau.UseSystemPasswordChar = true;
            }
        }

        private void btnquaylai_Click(object sender, EventArgs e)
        {
            frmtrangchu tc = new frmtrangchu();
            tc.Show();
            this.Close();
        }

        private void dgvtaikhoan_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvtaikhoan.Rows[e.RowIndex];
                txttendangnhap.Text = row.Cells["TenDangNhap"].Value?.ToString() ?? "";
                txttendangnhap.ReadOnly = true;

                txtmatkhau.Text = row.Cells["MatKhau"].Value?.ToString() ?? "";

                // Gán giá trị mã nhân viên cho ComboBox khi click chọn dòng trên bảng
                if (row.Cells["MaNhanVien"].Value != null && row.Cells["MaNhanVien"].Value != DBNull.Value)
                {
                    cbomahanvien.SelectedValue = row.Cells["MaNhanVien"].Value.ToString();
                }

                cbovaitro.Text = row.Cells["VaiTro"].Value?.ToString() ?? "";

                object valTrangThai = row.Cells["TrangThai"].Value;
                if (valTrangThai != null && valTrangThai != DBNull.Value)
                {
                    bool isTrangThai = Convert.ToBoolean(valTrangThai);
                    cbotrangthai.Text = isTrangThai ? "1" : "0";
                }
                else
                {
                    cbotrangthai.Text = "1";
                }
            }
        }
    }
}

