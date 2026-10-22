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
    public partial class frmNhaCungCap : Form
    {
        string str = @"Data Source=.;Initial Catalog=QL_khovattufinal;Integrated Security=True";

        public frmNhaCungCap()
        {
            InitializeComponent();
            LoadDanhSachNCC();
        }
        void LoadDanhSachNCC()
        {
            using (SqlConnection conn = new SqlConnection(str))
            {
                conn.Open();
                string sql = "SELECT * FROM NhaCungCap";
                SqlDataAdapter da = new SqlDataAdapter(sql, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvnhacungcap.DataSource = dt;
            }
        }

        private void dgvnhacungcap_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvnhacungcap.Rows[e.RowIndex];

                txtmanhacungcap.Text = row.Cells["MaNhaCungCap"]?.Value?.ToString() ?? "";
                txttennhacungcap.Text = row.Cells["TenNhaCungCap"]?.Value?.ToString() ?? "";
                txtsodienthoai.Text = row.Cells["SoDienThoai"]?.Value?.ToString() ?? "";
                txtdiachi.Text = row.Cells["DiaChi"]?.Value?.ToString() ?? "";
                txtemail.Text = row.Cells["Email"]?.Value?.ToString() ?? "";
                txtghichu.Text = row.Cells["GhiChu"]?.Value?.ToString() ?? "";
            }
        }

        private void btnluu_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtmanhacungcap.Text) || string.IsNullOrWhiteSpace(txttennhacungcap.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ mã và tên nhà cung cấp!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (SqlConnection conn = new SqlConnection(str))
            {
                conn.Open();
                string sql = "INSERT INTO NhaCungCap (MaNhaCungCap, TenNhaCungCap, SoDienThoai, DiaChi, Email, GhiChu) " +
                             "VALUES (@ma, @ten, @sdt, @diachi, @email, @ghichu)";
                SqlCommand cmd = new SqlCommand(sql, conn);

                cmd.Parameters.AddWithValue("@ma", txtmanhacungcap.Text.Trim());
                cmd.Parameters.AddWithValue("@ten", txttennhacungcap.Text.Trim());
                cmd.Parameters.AddWithValue("@sdt", txtsodienthoai.Text.Trim());
                cmd.Parameters.AddWithValue("@diachi", txtdiachi.Text.Trim());
                cmd.Parameters.AddWithValue("@email", txtemail.Text.Trim());
                cmd.Parameters.AddWithValue("@ghichu", txtghichu.Text.Trim());

                cmd.ExecuteNonQuery();
                MessageBox.Show("Lưu nhà cung cấp thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadDanhSachNCC();
                btnlammoi_Click(sender, e);
            }
        }

        private void btnxoa_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtmanhacungcap.Text))
            {
                MessageBox.Show("Vui lòng chọn nhà cung cấp cần xoá!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show("Bạn có chắc chắn muốn xóa nhà cung cấp này không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                using (SqlConnection conn = new SqlConnection(str))
                {
                    conn.Open();
                    string sql = "DELETE FROM NhaCungCap WHERE MaNhaCungCap = @ma";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@ma", txtmanhacungcap.Text.Trim());

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Xoá thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadDanhSachNCC();
                    btnlammoi_Click(sender, e);
                }
            }
        }

        private void btntimkiem_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(str))
            {
                conn.Open();
                string sql = "SELECT * FROM NhaCungCap " +
                             "WHERE TenNhaCungCap LIKE @ten AND MaNhaCungCap LIKE @ma";

                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@ten", "%" + txttimkiemtennhacungcap.Text.Trim() + "%");
                cmd.Parameters.AddWithValue("@ma", "%" + txttimkiemmanhacungcap.Text.Trim() + "%");

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                dgvnhacungcap.DataSource = dt;
            }
        }

        private void btnlammoi_Click(object sender, EventArgs e)
        {
            txttimkiemmanhacungcap.Clear();
            txttimkiemtennhacungcap.Clear();
            txtmanhacungcap.Clear();
            txttennhacungcap.Clear();
            txtsodienthoai.Clear();
            txtdiachi.Clear();
            txtemail.Clear();
            txtghichu.Clear();
            txtmanhacungcap.ReadOnly = false;
            LoadDanhSachNCC();
        }

        private void btnsua_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtmanhacungcap.Text))
            {
                MessageBox.Show("Vui lòng chọn nhà cung cấp cần sửa!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (SqlConnection conn = new SqlConnection(str))
            {
                conn.Open();
                string sql = "UPDATE NhaCungCap SET TenNhaCungCap = @ten, " +
                             "SoDienThoai = @sdt, DiaChi = @diachi, Email = @email, GhiChu = @ghichu " +
                             "WHERE MaNhaCungCap = @ma";

                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@ma", txtmanhacungcap.Text.Trim());
                cmd.Parameters.AddWithValue("@ten", txttennhacungcap.Text.Trim());
                cmd.Parameters.AddWithValue("@sdt", txtsodienthoai.Text.Trim());
                cmd.Parameters.AddWithValue("@diachi", txtdiachi.Text.Trim());
                cmd.Parameters.AddWithValue("@email", txtemail.Text.Trim());
                cmd.Parameters.AddWithValue("@ghichu", txtghichu.Text.Trim());

                cmd.ExecuteNonQuery();
                MessageBox.Show("Sửa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadDanhSachNCC();
            }
        }
        private void btnquaylai_Click(object sender, EventArgs e)
        {
            frmtrangchu f = new frmtrangchu();
            f.Show();
            this.Hide();
        }

        
    }
}
