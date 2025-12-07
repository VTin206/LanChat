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
    public partial class DangNhap : Form
    {
        public DangNhap()
        {
            InitializeComponent();
        }

        private void DangNhap_Load(object sender, EventArgs e)
        {

        }

        private void lblExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1(txtName.Text);
            form1.FormClosed += (s, args) => this.Close();
            form1.Show();
            this.Hide();
        }

        private void btnLogin_Click_1(object sender, EventArgs e)
        {
            string user = txtName.Text.Trim();
            string pass = txtPassword.Text.Trim();

            DatabaseHelper db = new DatabaseHelper();

            bool isValid = db.LoginUser(user, pass);

            if (isValid)
            {
                MessageBox.Show("Đăng nhập thành công!");
                Form1 mainForm = new Form1(user);
                mainForm.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Sai tên đăng nhập hoặc mật khẩu.");
            }
        }
        private void lblSignIn_Click(object sender, EventArgs e)
        {
            DangKy dangKy = new DangKy();
            dangKy.FormClosed += (s, args) => this.Show();
            dangKy.Show();
            this.Hide();
        }

        private void lblForgotPassword_Click(object sender, EventArgs e)
        {
            QuenMatKhau quenMatKhau = new QuenMatKhau();
            quenMatKhau.FormClosed += (s, args) => this.Show();
            quenMatKhau.Show();
            this.Hide();
        }
    }
}
