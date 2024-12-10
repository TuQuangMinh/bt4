using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Baitap4
{
    public partial class Form2 : Form
    {
        public delegate void ThongTin (String a,String b,String c);
        public event ThongTin TruyenThongTin;
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }
        public Form2(string hoTen, string ms, string luong) : this()
        {
            // Gán giá trị vào các TextBox khi Form2 được mở để sửa
            txtHoTen.Text = hoTen;
            txtMSNV.Text = ms;
            txtLuong.Text = luong;
        }
        private void btnDongY_Click(object sender, EventArgs e)
        {
            string hoTen = txtHoTen.Text;
            string ms = txtMSNV.Text;
            string luong = txtLuong.Text;

            // Gọi delegate để truyền dữ liệu
            TruyenThongTin?.Invoke(hoTen, ms, luong);

            // Đóng Form2
            this.Close();
        }

        private void btnBoQua_Click(object sender, EventArgs e)
        {
            this.Close ();
        }
    }
}
