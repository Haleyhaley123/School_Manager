using School_Manager.ManagerUser;
using School_Manager.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace School_Manager
{
    public partial class fLogin : Form
    {
        public fLogin()
        {
            InitializeComponent();
        }

        private void btnlogin_Click(object sender, EventArgs e)
        {
            bool isLogin = false;
            var listUser = BaseManagerUser.GetlistDataUser();
            User userLogin = new User()
            {
                UserName = txbUserName.Text.Trim(),
                Password = txbPassWord.Text.Trim()
            };
            foreach (User user in listUser)
            {
                if(user.UserName.Trim() == txbUserName.Text.Trim() && user.Password.Trim() == txbPassWord.Text.Trim())
                {
                    isLogin = true;
                    break;
                }    
            }    
            if (isLogin)
            {
                if (checkBox1.Checked)
                {
                    MessageBox.Show("Đăng nhập thành công", "Chúc mừng", MessageBoxButtons.OK);
                    string user = txbUserName.Text;
                    string password = txbPassWord.Text;
                    Properties.Settings.Default.username = user;
                    Properties.Settings.Default.password = password;
                    Properties.Settings.Default.Save();
                    MessageBox.Show("Bạn đã ghi nhớ", "Thông báo");
                    fManager fmc = new fManager(userLogin);
                    this.Hide();
                    fmc.ShowDialog();
                    this.Show();

                }
                else
                {
                    MessageBox.Show("Đăng nhập thành công", "Chúc mừng", MessageBoxButtons.OK);
                    Properties.Settings.Default.Reset();
                    fManager fm = new fManager(userLogin);
                    this.Hide();
                    fm.ShowDialog();

                }
            }
            else
            {
                MessageBox.Show("Sai tài khoản hoặc mật khẩu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txbUserName.Focus();

            }
        }

        private void btcreat_Click(object sender, EventArgs e)
        {
            fCreating fc = new fCreating();
            this.Hide();
            fc.ShowDialog();
            this.Show();

        }

        private void btnexit_Click(object sender, EventArgs e)
        {
            DialogResult Result = MessageBox.Show("Bạn có muốn thoát không?", "Thông báo", MessageBoxButtons.OKCancel);
            if (Result == DialogResult.OK)
            {
                Application.Exit();
                this.Close();
            }
        }
    }
}
