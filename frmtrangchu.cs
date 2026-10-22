using baitaplonQLVT;
using BTL_QLKVT;
using khách_hàng;
using ktv_quanlikiemke;
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
    public partial class frmtrangchu : Form
    {
        string str = @"Data Source=.;Initial Catalog=QL_khovattufinal;Integrated Security=True";
        public frmtrangchu()
        {
            InitializeComponent();
        }

        private void dgvdanhsachvattu_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void frmtrangchu_Load(object sender, EventArgs e)
        {
            // Khi mở form trang chủ, tự động tải danh sách vật tư lên bảng hiển thị
            LoadDanhSachVatTu();
        }
        // --- HÀM TẢI DANH SÁCH VẬT TƯ (BẢNG HANGHOA) ---
        private void LoadDanhSachVatTu()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(str))
                {
                    conn.Open();
                    // Lấy thông tin vật tư, có thể kết hợp lấy tên nhà cung cấp nếu muốn hiển thị rõ hơn
                    string query = @"SELECT h.MaHangHoa AS [Mã hàng hóa], 
                                            h.TenHangHoa AS [Tên vật tư], 
                                            n.TenNhaCungCap AS [Nhà cung cấp], 
                                            h.SoLuong AS [Số lượng], 
                                            h.DonViTinh AS [Đơn vị tính], 
                                            h.GhiChu AS [Ghi chú] 
                                     FROM HangHoa h 
                                     LEFT JOIN NhaCungCap n ON h.MaNhaCungCap = n.MaNhaCungCap";

                    SqlDataAdapter da = new SqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    // Giả sử tên DataGridView hiển thị danh sách ở giữa màn hình của bạn là dataGridView1
                    // Nếu tên khác, bạn thay dataGridView1 bằng tên control thực tế trên giao diện của bạn
                    dgvdanhsachvattu.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải danh sách vật tư: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btntrangchu_Click(object sender, EventArgs e)
        {

            // Đang ở trang chủ thì chỉ cần load lại danh sách vật tư
            LoadDanhSachVatTu();
        }

        private void btnvattu_Click(object sender, EventArgs e)
        { // Mở form Quản lý vật tư (ví dụ tên class là frmkhohang hoặc frmvattu)
           frmkhohang f = new frmkhohang();
           f.Show();
           this.Hide();
        }

        private void btnnhacungcap_Click(object sender, EventArgs e)
        {

            //Mở form Nhà cung cấp(bạn thay bằng tên form thực tế nếu có)
            frmNhaCungCap f = new frmNhaCungCap(); f.Show(); this.Hide();
            
        }

        private void btnkhachhang_Click(object sender, EventArgs e)
        {
            // Mở form Khách hàng
            khachhang f = new khachhang(); f.Show(); this.Hide();
        }

        private void btnnhanvien_Click(object sender, EventArgs e)
        {
            // Khởi tạo form nhân viên(giả sử tên form của bạn là frmnhanvien hoặc frmKiemKe tùy theo form quản lý nhân viên)
            qlynhanvien f = new qlynhanvien();
            f.Show(); // Hoặc f.ShowDialog();

            this.Hide(); // Ẩn trang chủ đi (hoặc dùng this.Close() nếu muốn đóng hẳn)
        }

       // private void btnnhapkho_Click(object sender, EventArgs e)
        //{
            // Mở form Nhập kho / Phiếu nhập
          //  form2 f = new form2();
          ///  f.Show(); // Hoặc f.ShowDialog();

           // this.Hide();
        //}

        private void btnxuatkho_Click(object sender, EventArgs e)
        {
            //frmLapPhieuXuat f = new frmLapPhieuXuat();
           // f.Show();
           // this.Hide();
        }

        private void btnkiemke_Click(object sender, EventArgs e)
        {
            /// Mở form kiểm kê thực tế của bạn lên
            frmkiemke f = new frmkiemke();
            f.Show();
            this.Hide(); // Ẩn trang chủ đi (hoặc dùng f.ShowDialog() tùy bạn chọn
        }

        private void btnbaocao_Click(object sender, EventArgs e)
        {
            /// Mở form kiểm kê thực tế của bạn lên
            frmbaocaothongke f = new frmbaocaothongke();
            f.Show();
            this.Hide(); // Ẩn trang chủ đi (hoặc dùng f.ShowDialog() tùy bạn chọn
        }

        private void btnphieunhap_Click(object sender, EventArgs e)
        {
            quanlyphieunhap f = new quanlyphieunhap();
            f.Show();
            this.Hide();
        }

        private void btnphieuxuat_Click(object sender, EventArgs e)
        {
            frmQuanLyXuat f = new frmQuanLyXuat();
            f.Show();
            this.Hide();
        }

        private void btntaikhoan_Click(object sender, EventArgs e)
        {
            // Mở form Quản lý tài khoản (có sẵn trong dự án của bạn: Frmquanlitaikhoan)
            Frmquanlitaikhoan f = new Frmquanlitaikhoan();
            f.Show();
            this.Hide();
        }
        // --- XỬ LÝ NÚT ĐĂNG XUẤT ---
        

        private void btndangxuat_Click_1(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn đăng xuất khỏi hệ thống không?",
                                          "Xác nhận đăng xuất",
                                          MessageBoxButtons.YesNo,
                                          MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                Application.Exit(); // Thoát hoàn toàn ứng dụng
            }
        }
    }
}
