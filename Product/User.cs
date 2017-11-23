using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Finger.Business;

namespace Finger.UI
{
    public partial class User : Form
    {
        private UserService _userService = new UserService();
        private List<Entity.User> _userList = new List<Entity.User>();
        private Entity.User _currentUser = null;
        public User()
        {
            InitializeComponent();
        }

        private void btnAddNew_Click(object sender, EventArgs e)
        {
            txtAccount.Text = "";
            txtName.Text = "";
            txtPassword.Text = "";

            _currentUser = null;            
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if(_currentUser != null)
            {
                if(MessageBox.Show("是否要删除用户：" + _currentUser.Name + "？", "提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    _userService.DeleteUser(_currentUser.Id);

                    bindList();
                }                
            }else
            {
                MessageBox.Show("请先选择要删除的用户!", "提示");
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if(_currentUser == null)
            {
                if(txtName.Text.Trim().Length > 0 && txtAccount.Text.Trim().Length > 0 && txtPassword.Text.Length > 0)
                {
                    _userService.AddUser(txtName.Text.Trim(), txtAccount.Text.Trim(), txtPassword.Text.Trim());

                    bindList();
                }else
                {
                    MessageBox.Show("账号信息不完整，请补充完整！", "提示");
                }
            }else
            {
                if (txtName.Text.Trim().Length > 0 && txtAccount.Text.Trim().Length > 0 && txtPassword.Text.Length > 0)
                {
                    _userService.UpdateUser(_currentUser.Id, txtName.Text.Trim(), txtAccount.Text.Trim(), txtPassword.Text.Trim());

                    bindList();
                }
                else
                {
                    MessageBox.Show("账号信息不完整，请补充完整！", "提示");
                }
            }
        }

        private void User_Load(object sender, EventArgs e)
        {
            bindList();

            if(Session.Account.ToLower() != "admin")
            {
                btnAddNew.Enabled = false;
                btnDelete.Enabled = false;
                btnSave.Enabled = false;
            }
        }

        private void bindList()
        {
            _userList = _userService.GetUserList();
            lbUsers.DisplayMember = "name";
            lbUsers.ValueMember = "id";
            lbUsers.DataSource = _userList;
        }

        private void lbUsers_SelectedIndexChanged(object sender, EventArgs e)
        {
            _currentUser = _userList[lbUsers.SelectedIndex];

            txtAccount.Text = _currentUser.Account;
            txtName.Text = _currentUser.Name;
            txtPassword.Text = _currentUser.Password;
        }

        private void btnQuit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
