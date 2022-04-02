using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using School_Manager.ManagerUser;



namespace School_Manager
{
    public partial class fCreating : Form
    {
        public fCreating()
        {
            InitializeComponent();
        }

        private void bntcreat_Click(object sender, EventArgs e)
        {
            if (txbcusername.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập tên đăng nhập");
                txbcusername.Focus();
            }
            else if (txbpass.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập mật khẩu");
                txbpass.Focus();
            }
            else if (txbpassagian.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập lại mật khẩu");
                txbpassagian.Focus();
            }
            else
          if (txbpass.Text != txbpassagian.Text)
            {
                MessageBox.Show(" Mật khẩu bạn nhập lại chưa đúng");
                txbpassagian.Focus();
                txbpassagian.SelectAll();
            }
            else
            {
                AccountUser accountUser = new AccountUser();
                accountUser.NguoiDung(txbcusername.Text, txbpass.Text, txbpassagian.Text);
                if (accountUser.Kiemtramatkhau() == true)
                {
                    MessageBox.Show("Đăng ký tài khoản thành công");
                    Thongtintaikhoan accif = new Thongtintaikhoan();
                    accif.save_data(txbcusername.Text, txbpass.Text);
                }
                else
                {
                    MessageBox.Show("Mật khẩu sai định dạng");
                    txbpass.Focus();
                    txbpass.SelectAll();
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult Result = MessageBox.Show("Bạn có muốn thoát không?", "Thông báo", MessageBoxButtons.OKCancel);
            if (Result == DialogResult.OK)
            {
               
                this.Close();
            }
        }

        private void bntcancel_Click(object sender, EventArgs e)
        {
            DialogResult Result = MessageBox.Show("Bạn có muốn hủy không?", "Thông báo", MessageBoxButtons.OKCancel);
            if (Result == DialogResult.OK)
            {
                this.Close();
            }
        }
    }
}
