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
    public partial class frmdangnhap : Form
    {
        string str = @"Data Source=.;Initial Catalog=QL_khovattufinal;Integrated Security=True";
        public frmdangnhap()
        {
            InitializeComponent();
        }
        private void btndangnhap_Click(object sender, EventArgs e)
        {
            // Kiểm tra dữ liệu nhập
            if (txttendangnhap.Text == "" || txtmatkhau.Text == "")
            {
                MessageBox.Show("Vui lòng nhập đầy đủ tài khoản và mật khẩu!");
                return;
            }

            // Kết nối SQL Server
            SqlConnection conn = new SqlConnection(str);
            conn.Open();

            // Câu lệnh kiểm tra tài khoản
            string sql = "SELECT COUNT(*) FROM TaiKhoan " +
                         "WHERE TenDangNhap = @TenDangNhap " +
                         "AND MatKhau = @MatKhau";

            SqlCommand cmd = new SqlCommand(sql, conn);

            cmd.Parameters.AddWithValue("@TenDangNhap", txttendangnhap.Text.Trim());
            cmd.Parameters.AddWithValue("@MatKhau", txtmatkhau.Text);

            int ketQua = (int)cmd.ExecuteScalar();

            if (ketQua > 0)
            {
                MessageBox.Show("Đăng nhập thành công!");

                frmtrangchu f = new frmtrangchu();
                f.Show();

                this.Hide();
            }
            else
            {
                MessageBox.Show("Sai tên đăng nhập hoặc mật khẩu!");
            }

            conn.Close();
        }

        private void pichienmatkhau_Click(object sender, EventArgs e)
        {
            // Kiểm tra xem mật khẩu đang bị ẩn (kí tự '*') hay không
            if (txtmatkhau.PasswordChar == '*')
            {
                // Nếu đang bị ẩn -> Xóa kí tự che đi để HIỆN mật khẩu
                // '\0' là kí tự rỗng (null) trong C#
                txtmatkhau.PasswordChar = '\0';
            }
            else
            {
                // Nếu đang hiện -> Đặt lại kí tự '*' để ẨN mật khẩu
                txtmatkhau.PasswordChar = '*';
            }
        }
    }
    }

