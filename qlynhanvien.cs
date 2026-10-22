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
    public partial class qlynhanvien : Form
    {
        string str = @"Data Source=.;Initial Catalog=QL_khovattufinal;Integrated Security=True";
        public qlynhanvien()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            Load_nhanvien("", "", "");
            Load_ghichu();
            CheckTrungMaNV("");

        }
        private void Load_nhanvien(string manv, string tennv, string dt)
        {
            // b1: ket noi db
            SqlConnection conn = new SqlConnection(str);
            if (conn.State == ConnectionState.Closed)
                conn.Open();

            string sql = "SELECT ROW_NUMBER() OVER(ORDER BY MaNhanVien) AS Stt, * " +
                         "FROM NhanVien " +
                         "WHERE MaNhanVien LIKE '%' + @manv + '%' " +
                         "AND TenNhanVien LIKE N'%' + @tennv + '%' " +
                         "AND SoDienThoai LIKE '%' + @dt + '%'";

            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.Add("@manv", SqlDbType.VarChar, 50).Value = manv;
            cmd.Parameters.Add("@tennv", SqlDbType.NVarChar, 100).Value = tennv;
            cmd.Parameters.Add("@dt", SqlDbType.VarChar, 50).Value = dt;

            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;

            DataTable tb = new DataTable();
            da.Fill(tb);

            cmd.Dispose();
            conn.Close();


            dgvnhanvien.DataSource = tb;
            dgvnhanvien.Refresh();
        }
        private void Load_ghichu()
        {
            SqlConnection conn = new SqlConnection(str);
            if (conn.State == ConnectionState.Closed)
                conn.Open();

            string sql = "Select distinct GhiChu from NhanVien";
            SqlCommand cmd = new SqlCommand(sql, conn);
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;

            DataTable tb = new DataTable();
            da.Fill(tb);
            cmd.Dispose();
            conn.Close();
        }
        private bool CheckTrungMaNV(string maNV)
        {
            SqlConnection conn = new SqlConnection(str);
            if (conn.State == ConnectionState.Closed)
                conn.Open();

            string sql = "SELECT COUNT(*) FROM NhanVien WHERE MaNhanVien = @manv";
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.Add("@manv", SqlDbType.VarChar, 50).Value = maNV;
            int kq = (int)cmd.ExecuteScalar();
            cmd.Dispose();
            conn.Close();

            return kq > 0;
        }
       
        private void btnthem_Click(object sender, EventArgs e)
        {
            string manv = txtmanhanvien.Text.Trim();
            string tennv = txttennhanvien.Text.Trim();
            DateTime ngaysinh = dtpngaysinh.Value;
            string sdt = txtsodienthoai.Text.Trim();
            string email = txtemail.Text.Trim();
            string diachi = txtdiachi.Text.Trim();
            string ghichu = txtghichu.Text.Trim();
            if (txtmanhanvien.Text == "")
            {
                txtmanhanvien.Focus();
                MessageBox.Show("Ma tác giả không để trống ");
                return;
            }
            SqlConnection conn = new SqlConnection(str);
            if (conn.State == ConnectionState.Closed)
                conn.Open();


            string sql = "INSERT INTO NhanVien (MaNhanVien, TenNhanVien, NgaySinh, SoDienThoai, Email, DiaChi, GhiChu) " +
                                   "VALUES (@manv, @tennv, @ngaysinh, @sdt, @email, @diachi, @ghichu)";
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.Add("@manv", SqlDbType.VarChar, 20).Value = manv;
            cmd.Parameters.Add("@tennv", SqlDbType.NVarChar, 100).Value = tennv;
            cmd.Parameters.Add("@ngaysinh", SqlDbType.Date).Value = ngaysinh;
            cmd.Parameters.Add("@sdt", SqlDbType.VarChar, 20).Value = sdt;
            cmd.Parameters.Add("@email", SqlDbType.VarChar, 100).Value = email;
            cmd.Parameters.Add("@diachi", SqlDbType.NVarChar, 200).Value = diachi;
            cmd.Parameters.Add("@ghichu", SqlDbType.NVarChar, 200).Value = ghichu;

            cmd.ExecuteNonQuery();
            cmd.Dispose();
            conn.Close();
            MessageBox.Show("Đã lưu");
            Load_nhanvien("", "", "");
        }

        private void dgvnhanvien_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            int i = e.RowIndex;
            txtmanhanvien.Text = dgvnhanvien.Rows[i].Cells["manhanvien"].Value.ToString();
            txttennhanvien.Text = dgvnhanvien.Rows[i].Cells["tennhanvien"].Value.ToString();
            if (dgvnhanvien.Rows[i].Cells["NgaySinh"].Value != DBNull.Value)
            {
                dtpngaysinh.Value = Convert.ToDateTime(dgvnhanvien.Rows[i].Cells["NgaySinh"].Value);
            }

            txtsodienthoai.Text = dgvnhanvien.Rows[i].Cells["SoDienThoai"].Value.ToString();
            txtemail.Text = dgvnhanvien.Rows[i].Cells["Email"].Value.ToString();
            txtdiachi.Text = dgvnhanvien.Rows[i].Cells["DiaChi"].Value.ToString();
            txtghichu.Text = dgvnhanvien.Rows[i].Cells["GhiChu"].Value.ToString();
        }

        private void btnxoa_Click_1(object sender, EventArgs e)
        {
            string manv = txtmanhanvien.Text.Trim();
            DialogResult kq = MessageBox.Show("Bạn có chắc chắn muốn xóa nhân viên này không?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (kq == DialogResult.Yes)
            {
                SqlConnection conn = new SqlConnection(str);
                if (conn.State == ConnectionState.Closed)
                    conn.Open();

                string sql = "DELETE FROM NhanVien WHERE MaNhanVien = @manv";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.Add("@manv", SqlDbType.VarChar, 20).Value = manv;
                cmd.ExecuteNonQuery();

                cmd.Dispose();
                conn.Close();

                MessageBox.Show("Xóa nhân viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Load_nhanvien("", "", "");

            }
        }

        private void btnsua_Click_1(object sender, EventArgs e)
        {
            string manv = txtmanhanvien.Text.Trim();
            string tennv = txttennhanvien.Text.Trim();
            DateTime ngaysinh = dtpngaysinh.Value;
            string sdt = txtsodienthoai.Text.Trim();
            string email = txtemail.Text.Trim();
            string diachi = txtdiachi.Text.Trim();
            string ghichu = txtghichu.Text.Trim();
            SqlConnection conn = new SqlConnection(str);
            if (conn.State == ConnectionState.Closed)
                conn.Open();
            string sql = "UPDATE NhanVien SET TenNhanVien = @tennv, NgaySinh = @ngaysinh, SoDienThoai = @sdt, Email = @email, DiaChi = @diachi, GhiChu = @ghichu" +
                " WHERE MaNhanVien = @manv";
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.Add("@manv", SqlDbType.VarChar, 20).Value = manv;
            cmd.Parameters.Add("@tennv", SqlDbType.NVarChar, 100).Value = tennv;
            cmd.Parameters.Add("@ngaysinh", SqlDbType.Date).Value = ngaysinh;
            cmd.Parameters.Add("@sdt", SqlDbType.VarChar, 20).Value = sdt;
            cmd.Parameters.Add("@email", SqlDbType.VarChar, 100).Value = email;
            cmd.Parameters.Add("@diachi", SqlDbType.NVarChar, 200).Value = diachi;
            cmd.Parameters.Add("@ghichu", SqlDbType.NVarChar, 200).Value = ghichu;

            cmd.ExecuteNonQuery();
            cmd.Dispose();
            conn.Close();
            MessageBox.Show("Sửa thành công");
            Load_nhanvien("", "", "");
        }

        private void btntimkiem_Click_1(object sender, EventArgs e)
        {
            string manv = txttimkiemmanhanvien.Text.Trim();
            Load_nhanvien(manv, "", "");
        }

        private void btnlammoi_Click_1(object sender, EventArgs e)
        {
            txtmanhanvien.Clear();
            txttennhanvien.Clear();
            dtpngaysinh.Value = DateTime.Now;
            txtsodienthoai.Clear();
            txtemail.Clear();
            txtdiachi.Clear();
            txtghichu.Clear();
            txttimkiemmanhanvien.Clear();
            txtmanhanvien.Enabled = true;
            Load_nhanvien("", "", "");
        }

        private void btnquaylai_Click(object sender, EventArgs e)
        {
            frmtrangchu tc = new frmtrangchu();
            tc.Show();
            this.Close();
        }
    }
}
