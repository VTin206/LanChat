using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BasicChat
{
    public partial class DangKy : Form
    {
        public DangKy()
        {
            InitializeComponent();
        }
   
        private void lblExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnSignIn_Click(object sender, EventArgs e)
        {
            string username = txtName.Text.Trim();
            string password = txtPassword.Text.Trim();
            string email = txtEmail.Text.Trim();

            DatabaseHelper db = new DatabaseHelper();

            bool isSuccess = db.RegisterUser(username, password, email);
            if (isSuccess)
            {
                MessageBox.Show("Đăng ký thành công! Bạn có thể đăng nhập ngay.");
            }
            else
            {
                MessageBox.Show("Tên đăng nhập đã tồn tại, vui lòng chọn tên khác.");
            }
            DangNhap dangNhap = new DangNhap();
            dangNhap.Show();
            this.Hide();
        }
    }
}
