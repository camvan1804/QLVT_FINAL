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
    public partial class frmbaocaothongke : Form
    {
        string str = @"Data Source=.;Initial Catalog=QL_khovattufinal;Integrated Security=True";
        public frmbaocaothongke()
        {
            InitializeComponent();
            LoadCacLoaiBaoCao();
        }
        void LoadCacLoaiBaoCao()
        {
            cboloaibaocao.Items.Add("Báo cáo tồn kho hiện tại");
            cboloaibaocao.Items.Add("Báo cáo vật tư sắp hết (Số lượng <= 10)");
            cboloaibaocao.SelectedIndex = 0;
        }
        private void btnthongke_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(str))
            {
                conn.Open();
                string query = "SELECT * FROM PhieuNhap WHERE NgayNhap BETWEEN @tungay AND @denngay";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.Add("@tungay", SqlDbType.Date).Value = dtptungay.Value.Date;
                cmd.Parameters.Add("@denngay", SqlDbType.Date).Value = dtpdenngay.Value.Date.AddDays(1).AddSeconds(-1);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                dgvbaocao.DataSource = dt;
                dgvbaocao.Refresh();

                // Bỏ chọn dòng mặc định để hiện toàn bộ danh sách cùng lúc
                if (dgvbaocao.Rows.Count > 0)
                {
                    dgvbaocao.ClearSelection();
                }

                lbltongdong.Text = "Tổng số bản ghi: " + dt.Rows.Count.ToString();
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
