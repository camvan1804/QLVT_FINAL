using baitaplonQLVT;
using BTL_QLKVT;
using khách_hàng;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using xuatkhovt;

namespace BTLnhom6_quanlybattu
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frmdangnhap());
            // Application.Run(new quanlyphieunhap());
            // Application.Run(new frmNhaCungCap());
            // Application.Run(new khachhang());
            //  Application.Run(new qlynhanvien());
            //Application.Run(new form2());
            //Application.Run(new xuatkho()); 
            // Application.Run(new frmkiemke()); 
           // Application.Run(new frmbaocaothongke());
        }
    }
}
