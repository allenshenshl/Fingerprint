using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Finger.Business;

namespace Finger.UI
{
    public partial class Login : Form
    {
        private UserService _userService = new UserService();
        public Login()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string account = txtAccount.Text.Trim();
            string pwd = txtPwd.Text.Trim();

             Finger.Entity.User currentUser = _userService.Login(account, pwd);

            if (currentUser != null)
            {
                Session.Account = account;
                Main mainForm = new Main();
                mainForm.Show();                

                this.Hide();
            }
            else
            {
                MessageBox.Show("您好，用户名或密码错误，请重新输入！", "提示");
            }            
        }

        private void Login_Load(object sender, EventArgs e)
        {
            DataBaseService dataBaseService = new DataBaseService();
            dataBaseService.InitDataBase();
        }

        private void btnQuit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
