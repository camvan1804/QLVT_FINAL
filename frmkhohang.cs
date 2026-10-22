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

namespace ktv_quanlikiemke
{

    public partial class frmkhohang : Form
    {
        string str = @"Data Source=.;Initial Catalog=QL_khovattufinal;Integrated Security=True";
        string tableName = "HangHoa";
        public frmkhohang()
        {
            InitializeComponent();
        }

        private void frmkhohang_Load(object sender, EventArgs e)
        {
            LoadData();
            LoadComboBoxNhaCungCap();

            // Gắn sự kiện click cho DataGridView
            dgvhanghoa.CellClick += dgvhanghoa_CellClick;
        }
        // Đổ dữ liệu vào ComboBox Nhà Cung Cấp
        private void LoadComboBoxNhaCungCap()
        {
            using (SqlConnection conn = new SqlConnection(str))
            {
                conn.Open();
                string query = "SELECT MaNhaCungCap, TenNhaCungCap FROM NhaCungCap";
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);

                cbonhacungcap.DataSource = dt;
                cbonhacungcap.DisplayMember = "TenNhaCungCap";
                cbonhacungcap.ValueMember = "MaNhaCungCap";
                cbonhacungcap.SelectedIndex = -1;
            }
        }
        // Hàm tải dữ liệu lên DataGridView kèm theo Tên Nhà Cung Cấp
        private void LoadData()
        {
            using (SqlConnection conn = new SqlConnection(str))
            {
                conn.Open();
                string query = @"SELECT h.MaHangHoa, h.TenHangHoa, h.MaNhaCungCap, n.TenNhaCungCap, 
                                       h.SoLuong, h.DonViTinh, h.GhiChu 
                                FROM " + tableName + " h " +
                                "LEFT JOIN NhaCungCap n ON h.MaNhaCungCap = n.MaNhaCungCap";

                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);

                dgvhanghoa.DataSource = dt;
            }
        }
        // 1. Chức năng Thêm hàng hóa
        private void btnthem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtmahanghoa.Text))
            {
                MessageBox.Show("Vui lòng nhập mã hàng hóa!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtmahanghoa.Focus();
                return;
            }

            using (SqlConnection conn = new SqlConnection(str))
            {
                conn.Open();
                string query = "INSERT INTO " + tableName + " (MaHangHoa, TenHangHoa, MaNhaCungCap, SoLuong, DonViTinh, GhiChu) " +
                               "VALUES (@MaHangHoa, @TenHangHoa, @MaNhaCungCap, @SoLuong, @DonViTinh, @GhiChu)";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@MaHangHoa", txtmahanghoa.Text.Trim());
                cmd.Parameters.AddWithValue("@TenHangHoa", txttenhanghoa.Text.Trim());
                cmd.Parameters.AddWithValue("@MaNhaCungCap", cbonhacungcap.SelectedValue != null ? cbonhacungcap.SelectedValue.ToString() : cbonhacungcap.Text);
                cmd.Parameters.AddWithValue("@SoLuong", string.IsNullOrEmpty(txtsoluong.Text) ? 0 : int.Parse(txtsoluong.Text));
                cmd.Parameters.AddWithValue("@DonViTinh", txtdonvitinh.Text.Trim());
                cmd.Parameters.AddWithValue("@GhiChu", txtghichu.Text.Trim());

                cmd.ExecuteNonQuery();
                MessageBox.Show("Thêm vật tư/hàng hóa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadData();
                ClearFields();
            }
        }
        // 2. Chức năng Sửa hàng hóa
        private void btnsua_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtmahanghoa.Text))
            {
                MessageBox.Show("Vui lòng chọn hàng hóa cần sửa!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (SqlConnection conn = new SqlConnection(str))
            {
                conn.Open();
                string query = "UPDATE " + tableName + " SET TenHangHoa = @TenHangHoa, MaNhaCungCap = @MaNhaCungCap, " +
                               "SoLuong = @SoLuong, DonViTinh = @DonViTinh, GhiChu = @GhiChu " +
                               "WHERE MaHangHoa = @MaHangHoa";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@MaHangHoa", txtmahanghoa.Text.Trim());
                cmd.Parameters.AddWithValue("@TenHangHoa", txttenhanghoa.Text.Trim());
                cmd.Parameters.AddWithValue("@MaNhaCungCap", cbonhacungcap.SelectedValue != null ? cbonhacungcap.SelectedValue.ToString() : cbonhacungcap.Text);
                cmd.Parameters.AddWithValue("@SoLuong", int.Parse(txtsoluong.Text));
                cmd.Parameters.AddWithValue("@DonViTinh", txtdonvitinh.Text.Trim());
                cmd.Parameters.AddWithValue("@GhiChu", txtghichu.Text.Trim());

                cmd.ExecuteNonQuery();
                MessageBox.Show("Cập nhật hàng hóa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadData();
                ClearFields();
            }
        }
        // 3. Chức năng Xóa hàng hóa
        private void btnxoa_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtmahanghoa.Text))
            {
                MessageBox.Show("Vui lòng chọn hàng hóa cần xóa!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show("Bạn có chắc chắn muốn xóa mặt hàng này không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                using (SqlConnection conn = new SqlConnection(str))
                {
                    conn.Open();
                    string query = "DELETE FROM " + tableName + " WHERE MaHangHoa = @MaHangHoa";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@MaHangHoa", txtmahanghoa.Text.Trim());

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Xóa hàng hóa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadData();
                    ClearFields();
                }
            }
        }
        // 4. Chức năng Làm mới (Reset form)
        private void btnlammoi_Click(object sender, EventArgs e)
        {
            ClearFields();
            LoadData();
        }
        private void ClearFields()
        {
            txtmahanghoa.Clear();
            txttenhanghoa.Clear();
            txtsoluong.Clear();
            txtdonvitinh.Clear();
            txtghichu.Clear();
            cbonhacungcap.SelectedIndex = -1;
            txtmahanghoa.ReadOnly = false;
        }
        // 5. Chức năng Tìm kiếm (Hỗ trợ tìm theo mã hoặc theo tên dựa trên RadioButton)
        private void btntimkiem_Click(object sender, EventArgs e)
        {
            string ma = txttimkiemma.Text.Trim();
            string ten = txttimkiemten.Text.Trim();

            if (ma == "" && ten == "")
            {
                MessageBox.Show("Vui lòng nhập mã hoặc tên hàng hóa cần tìm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (SqlConnection conn = new SqlConnection(str))
            {
                conn.Open();
                string sql = @"
                    SELECT h.MaHangHoa, h.TenHangHoa,
                           h.MaNhaCungCap,
                           n.TenNhaCungCap AS NhaCungCap,
                           h.SoLuong, h.DonViTinh, h.GhiChu
                    FROM HangHoa h
                    LEFT JOIN NhaCungCap n
                        ON h.MaNhaCungCap = n.MaNhaCungCap
                    WHERE (@ma = '' OR h.MaHangHoa LIKE @timma)
                      AND (@ten = '' OR h.TenHangHoa LIKE @timten)";

                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@ma", ma);
                cmd.Parameters.AddWithValue("@ten", ten);
                cmd.Parameters.AddWithValue("@timma", "%" + ma + "%");
                cmd.Parameters.AddWithValue("@timten", "%" + ten + "%");

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                dgvhanghoa.DataSource = dt;

                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("Không tìm thấy hàng hóa phù hợp!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
        // 6. Sự kiện Click dòng trên DataGridView để đổ dữ liệu lên các ô nhập

        private void dgvhanghoa_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvhanghoa.Rows[e.RowIndex];
                txtmahanghoa.Text = row.Cells["MaHangHoa"].Value.ToString();
                txtmahanghoa.ReadOnly = true; // Khóa mã hàng hóa khi chọn để tránh sửa khóa chính

                txttenhanghoa.Text = row.Cells["TenHangHoa"].Value.ToString();

                
                if (row.Cells["MaNhaCungCap"].Value != DBNull.Value)
                {
                    cbonhacungcap.SelectedValue = row.Cells["MaNhaCungCap"].Value.ToString();
                }
                else
                {
                    cbonhacungcap.SelectedIndex = -1;
                }

                txtsoluong.Text = row.Cells["SoLuong"].Value.ToString();
                txtdonvitinh.Text = row.Cells["DonViTinh"].Value.ToString();
                txtghichu.Text = row.Cells["GhiChu"].Value.ToString();
            }
        }

        private void btnquaylai_Click(object sender, EventArgs e)
        {
            frmtrangchu tc = new frmtrangchu();
            tc.Show();
            this.Close();
        }
    }
}

