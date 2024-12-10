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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
               "Bạn có muốn đóng ứng dụng không?",  
               "Xác nhận",                         
               MessageBoxButtons.YesNo,             
               MessageBoxIcon.Question             
           );

            // Xử lý kết quả
            if (result == DialogResult.Yes)
            {
                // Đóng ứng dụng nếu chọn Có
                this.Close();
            }
            else
            {
             
              
            }
        }
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Hiển thị hộp thoại xác nhận
            DialogResult result = MessageBox.Show(
                "Bạn có muốn đóng ứng dụng không?",  
                "Xác nhận",                          
                MessageBoxButtons.YesNo,            
                MessageBoxIcon.Question             
            );

            // Xử lý kết quả
            if (result == DialogResult.No)
            {
                // Hủy sự kiện đóng form nếu chọn "Không"
                e.Cancel = true;
            }
            // Nếu chọn "Có", form sẽ tiếp tục đóng (mặc định)
        }

        private void btnthem_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();

            // Gắn delegate để nhận dữ liệu từ Form2
            form2.TruyenThongTin += (hoTen, ms, luong) =>
            {
                // Thêm dữ liệu vào DataGridView
                dtg1.Rows.Add(hoTen, ms, luong);
            };

            // Hiển thị Form2
            form2.ShowDialog();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (dtg1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Hãy chọn một dòng để sửa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Lấy dòng được chọn
            DataGridViewRow selectedRow = dtg1.SelectedRows[0];
            string currentHoTen = selectedRow.Cells[0].Value.ToString();
            string currentMS = selectedRow.Cells[1].Value.ToString();
            string currentLuong = selectedRow.Cells[2].Value.ToString();

            // Mở Form2 với thông tin của dòng đã chọn
            Form2 form2 = new Form2 (currentHoTen, currentMS, currentLuong);
            form2.TruyenThongTin += (hoTen, ms, luong) =>
            {
                // Cập nhật lại dữ liệu trong DataGridView
                selectedRow.Cells[0].Value = hoTen;
                selectedRow.Cells[1].Value = ms;
                selectedRow.Cells[2].Value = luong;
            };

            // Hiển thị Form2
            form2.ShowDialog();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dtg1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Hãy chọn một dòng để xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Lấy dòng được chọn và xóa nó
            foreach (DataGridViewRow row in dtg1.SelectedRows)
            {
                dtg1.Rows.RemoveAt(row.Index);
            }
        }
    }
    }

