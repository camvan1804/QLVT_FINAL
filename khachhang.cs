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

namespace khách_hàng
{
    public partial class khachhang : Form
    {

        string str = @"Data Source=.;Initial Catalog=QL_khovattufinal;Integrated Security=True";
        SqlConnection conn;

        public khachhang()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Khởi tạo đối tượng kết nối và gọi LoadData khi form mở lên
            conn = new SqlConnection(str);
            LoadData();
        }

        private void LoadData()
        {
            if (conn.State == ConnectionState.Closed)
                conn.Open();

            string query = "SELECT * FROM KhachHang";
            SqlDataAdapter da = new SqlDataAdapter(query, conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dgvkhachhang.DataSource = dt;

            if (conn.State == ConnectionState.Open)
                conn.Close();
        }

        private void dgvkhachhang_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvkhachhang.Rows[e.RowIndex];
                txtmakhachhang.Text = row.Cells["makhachhang"].Value.ToString();
                txttenkhachhang.Text = row.Cells["tenkhachhang"].Value.ToString();
                txtsodienthoai.Text = row.Cells["sodienthoai"].Value.ToString();
                txtdiachi.Text = row.Cells["diachi"].Value.ToString();
                txtghichu.Text = row.Cells["ghichu"].Value.ToString();

                // Khóa ô Mã KH khi chọn dòng để sửa (tránh sửa trùng khóa chính)
                txtmakhachhang.Enabled = false;
            }
        }

        private void btnluu_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtmakhachhang.Text) || string.IsNullOrEmpty(txttenkhachhang.Text))
            {
                MessageBox.Show("Mã khách hàng và Tên khách hàng không được để trống!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (conn.State == ConnectionState.Closed)
                conn.Open();

            string query = "INSERT INTO KhachHang (makhachhang, tenkhachhang, sodienthoai, diachi, ghichu) VALUES (@makhachhang, @tenkhachhang, @sodienthoai, @diachi, @ghichu)";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@makhachhang", txtmakhachhang.Text.Trim());
            cmd.Parameters.AddWithValue("@tenkhachhang", txttenkhachhang.Text.Trim());
            cmd.Parameters.AddWithValue("@sodienthoai", txtsodienthoai.Text.Trim());
            cmd.Parameters.AddWithValue("@diachi", txtdiachi.Text.Trim());
            cmd.Parameters.AddWithValue("@ghichu", txtghichu.Text.Trim());

            cmd.ExecuteNonQuery();

            if (conn.State == ConnectionState.Open)
                conn.Close();

            MessageBox.Show("Thêm mới khách hàng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            LoadData();
            ClearInputs();
        }

        private void btnxoa_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtmakhachhang.Text))
            {
                MessageBox.Show("Vui lòng chọn khách hàng cần xóa từ danh sách!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult dr = MessageBox.Show("Bạn có chắc chắn muốn xóa khách hàng này không?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                if (conn.State == ConnectionState.Closed)
                    conn.Open();

                string query = "DELETE FROM KhachHang WHERE makhachhang = @makhachhang";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@makhachhang", txtmakhachhang.Text.Trim());

                cmd.ExecuteNonQuery();

                if (conn.State == ConnectionState.Open)
                    conn.Close();

                MessageBox.Show("Xóa khách hàng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadData();
                ClearInputs();
            }
        }

        private void btnsua_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtmakhachhang.Text))
            {
                MessageBox.Show("Vui lòng chọn khách hàng cần sửa từ danh sách!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (conn.State == ConnectionState.Closed)
                conn.Open();

            string query = "UPDATE KhachHang SET tenkhachhang = @tenkhachhang, sodienthoai = @sodienthoai, diachi = @diachi, ghichu = @ghichu WHERE makhachhang = @makhachhang";

            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@makhachhang", txtmakhachhang.Text.Trim());
            cmd.Parameters.AddWithValue("@tenkhachhang", txttenkhachhang.Text.Trim());
            cmd.Parameters.AddWithValue("@sodienthoai", txtsodienthoai.Text.Trim());
            cmd.Parameters.AddWithValue("@diachi", txtdiachi.Text.Trim());
            cmd.Parameters.AddWithValue("@ghichu", txtghichu.Text.Trim());

            cmd.ExecuteNonQuery();

            if (conn.State == ConnectionState.Open)
                conn.Close();

            MessageBox.Show("Sửa thông tin khách hàng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            LoadData();
            ClearInputs();
        }

        private void btntimkiem_Click(object sender, EventArgs e)
        {
            if (conn.State == ConnectionState.Closed)
                conn.Open();

            string query = "SELECT * FROM KhachHang WHERE MaKhachHang LIKE @makhachhang AND TenKhachHang LIKE @tenkhachhang";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@makhachhang", "%" + txttimma.Text.Trim() + "%");
            cmd.Parameters.AddWithValue("@tenkhachhang", "%" + txttimten.Text.Trim() + "%");

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dgvkhachhang.DataSource = dt;

            if (conn.State == ConnectionState.Open)
                conn.Close();
        }
        
        

        private void btnlammoi_Click(object sender, EventArgs e)
        {
            txttimma.Clear();
            txttimten.Clear();
            ClearInputs();
            LoadData();
        }

        private void ClearInputs()
        {
            txtmakhachhang.Clear();
            txttenkhachhang.Clear();
            txtsodienthoai.Clear();
            txtdiachi.Clear();
            txtghichu.Clear();
            txtmakhachhang.Enabled = true;
        }

        private void btnquaylai_Click(object sender, EventArgs e)
        {
            frmtrangchu tc = new frmtrangchu();
            tc.Show();
            this.Close();
        }
    }
}
    
