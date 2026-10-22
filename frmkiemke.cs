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

namespace BTLnhom6_quanlybattu
{
    public partial class frmkiemke : Form
    {
        string str = @"Data Source=.;Initial Catalog=QL_khovattufinal;Integrated Security=True;";
        string tableName = "KiemKeVatTu"; 
        
        public frmkiemke()
        {
            InitializeComponent();
        }

        private void frmkiemke_Load(object sender, EventArgs e)
        {
            // Gọi hàm đổ dữ liệu cho ComboBox trước khi tải bảng
            LoadComboBoxHangHoa();
            LoadComboBoxNhanVien();

            LoadData();

            // Gắn sự kiện tự động tính chênh lệch khi gõ số lượng
            txtsoluongton.TextChanged += TinhChenhLech;
            txtsoluongthucte.TextChanged += TinhChenhLech;
            txtsoluongthucte.TextChanged += TinhChenhLech;
        }
        // Hàm tải dữ liệu lên DataGridView (Giả sử dgv của bạn tên là dgvkiemke hoặc dataGridView1, ở đây tôi dùng datagridview1 hoặc tên bạn đặt)
        private void LoadData()
        {
            using (SqlConnection conn = new SqlConnection(str))
            {
                conn.Open();
                string query = "SELECT * FROM " + tableName;
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);

                dgvkiemke.DataSource = dt;
                dgvkiemke.Refresh();
            }
        }
        private void LoadComboBoxHangHoa()
        {
            using (SqlConnection conn = new SqlConnection(str))
            {
                conn.Open();
                string sql = "SELECT MaHangHoa, TenHangHoa FROM HangHoa";
                SqlDataAdapter da = new SqlDataAdapter(sql, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);

                cbomahanghoa.DataSource = dt;
                cbomahanghoa.DisplayMember = "MaHangHoa";
                cbomahanghoa.ValueMember = "MaHangHoa";
                cbomahanghoa.SelectedIndex = -1;
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

                cbomanhanvien.DataSource = dt;
                cbomanhanvien.DisplayMember = "MaNhanVien";
                cbomanhanvien.ValueMember = "MaNhanVien";
                cbomanhanvien.SelectedIndex = -1;
            }
        }

        private void btnthem_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(str))
            {
                conn.Open();
                string query = "INSERT INTO " + tableName + " (MaPhieu, NgayKiemKe, MaHangHoa, MaNhanVien, SoLuongTon, SoLuongThucTe) " +
                               "VALUES (@MaPhieu, @NgayKiemKe, @MaHangHoa, @MaNhanVien, @SoLuongTon, @SoLuongThucTe)";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@MaPhieu", txtmaphieu.Text.Trim());
                cmd.Parameters.AddWithValue("@NgayKiemKe", dtpngaykiemke.Value);
                cmd.Parameters.AddWithValue("@MaHangHoa", cbomahanghoa.SelectedValue != null ? cbomahanghoa.SelectedValue.ToString() : cbomahanghoa.Text);
                cmd.Parameters.AddWithValue("@MaNhanVien", cbomanhanvien.SelectedValue != null ? cbomanhanvien.SelectedValue.ToString() : cbomanhanvien.Text);
                cmd.Parameters.AddWithValue("@SoLuongTon", string.IsNullOrEmpty(txtsoluongton.Text) ? 0 : int.Parse(txtsoluongton.Text));
                cmd.Parameters.AddWithValue("@SoLuongThucTe", string.IsNullOrEmpty(txtsoluongthucte.Text) ? 0 : int.Parse(txtsoluongthucte.Text));

                cmd.ExecuteNonQuery();
                MessageBox.Show("Thêm phiếu kiểm kê thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadData();
                ClearFields();
            }
        }

        private void btnsua_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(str))
            {
                conn.Open();

                string query = "UPDATE " + tableName + " SET NgayKiemKe = @NgayKiemKe, MaHangHoa = @MaHangHoa, MaNhanVien = @MaNhanVien, " +
                               "SoLuongTon = @SoLuongTon, SoLuongThucTe = @SoLuongThucTe " +
                               "WHERE MaPhieu = @MaPhieu";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@MaPhieu", txtmaphieu.Text.Trim());
                cmd.Parameters.AddWithValue("@NgayKiemKe", dtpngaykiemke.Value);
                cmd.Parameters.AddWithValue("@MaHangHoa", cbomahanghoa.Text.Trim());
                cmd.Parameters.AddWithValue("@MaNhanVien", cbomanhanvien.Text.Trim());
                cmd.Parameters.AddWithValue("@SoLuongTon", Convert.ToDecimal(txtsoluongton.Text));
                cmd.Parameters.AddWithValue("@SoLuongThucTe", Convert.ToDecimal(txtsoluongthucte.Text));

                cmd.ExecuteNonQuery();
                MessageBox.Show("Cập nhật thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadData();
                ClearFields();
            }
        }

        private void btnxoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn muốn xóa phiếu này không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                using (SqlConnection conn = new SqlConnection(str))
                {
                    conn.Open();
                    string query = "DELETE FROM " + tableName + " WHERE MaPhieu = @MaPhieu";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@MaPhieu", txtmaphieu.Text);

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Xóa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadData();
                    ClearFields();
                }
            }
        }

        private void btnlammoi_Click(object sender, EventArgs e)
        {
            ClearFields();
            LoadData();
            if (dgvkiemke.Rows.Count > 0)
            {
                dgvkiemke.ClearSelection();
            }
        }
        private void ClearFields()
        {
            txtmaphieu.Clear();
            txtsoluongton.Clear();
            txtsoluongthucte.Clear();
            txtchenhlech.Clear();
            txtmaphieu.ReadOnly = false;
            dtpngaykiemke.Value = DateTime.Now;
            cbomahanghoa.SelectedIndex = -1;
            cbomanhanvien.SelectedIndex = -1;
        }

        private void btntimkiem_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(str))
            {
                conn.Open();
                string query = "SELECT * FROM " + tableName + " WHERE MaPhieu LIKE @keyword OR MaHangHoa LIKE @keyword";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@keyword", "%" + txttimkiem.Text.Trim() + "%");

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvkiemke.DataSource = dt;
            }
        }

        private void dgvkiemke_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvkiemke.Rows[e.RowIndex];
                txtmaphieu.Text = row.Cells["MaPhieu"].Value.ToString();
                txtmaphieu.ReadOnly = true; // Khóa mã phiếu khi chọn để sửa/xóa
                dtpngaykiemke.Value = Convert.ToDateTime(row.Cells["NgayKiemKe"].Value);
                cbomahanghoa.Text = row.Cells["MaHangHoa"].Value.ToString();
                cbomanhanvien.Text = row.Cells["MaNhanVien"].Value.ToString();
                txtsoluongton.Text = row.Cells["SoLuongTon"].Value.ToString();
                txtsoluongthucte.Text = row.Cells["SoLuongThucTe"].Value.ToString();
                txtchenhlech.Text = row.Cells["ChenhLech"].Value.ToString();
                //txtghichu.Text = row.Cells["GhiChu"].Value.ToString();
            }
        }
        // 7. Hàm tự động tính chênh lệch (Thực tế - Tồn)
        private void TinhChenhLech(object sender, EventArgs e)
        {
            int ton = 0, thucte = 0;
            int.TryParse(txtsoluongton.Text, out ton);
            int.TryParse(txtsoluongthucte.Text, out thucte);
            int chenhlech = thucte - ton;
            txtchenhlech.Text = chenhlech.ToString();
        }

        private void btnquaylai_Click(object sender, EventArgs e)
        {
            frmtrangchu tc = new frmtrangchu();
            tc.Show();
            this.Close();
        }
    }
}
