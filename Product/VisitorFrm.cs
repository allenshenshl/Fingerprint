using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Finger.Business;
using Finger.Entity;

namespace Finger.UI
{
    public partial class VisitorFrm : Form
    {
        private Visitor _currentVisitor = null;

        public delegate void OnCloseHandler(Visitor v);
        public OnCloseHandler OnFormClose;
        public Visitor _newVisitor = null;

        public VisitorFrm()
        {
            InitializeComponent();
        }

        public VisitorFrm(Visitor visitor)
        {
            InitializeComponent();
            _currentVisitor = visitor;            
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if(_currentVisitor == null)
            {
                VisitorService vs = new VisitorService();
                VisitLogService vls = new VisitLogService();

                if(txtName.Text.Trim().Length > 0 && txtMobile.Text.Trim().Length > 0 && txtIdentity.Text.Trim().Length > 0)
                {
                    _newVisitor = vs.AddVisitor(txtName.Text.Trim(), txtMobile.Text.Trim(), txtIdentity.Text.Trim(), txtCompany.Text.Trim(), Robot.GetLatestTemplate());
                    if (txtPurpose.Text.Trim().Length > 0 && txtRecepter.Text.Trim().Length > 0 && _newVisitor != null)
                    {
                        if (validateTime(txtTime.Text.Trim()))
                        {
                            vls.AddLog(txtTime.Text.Trim(), txtPurpose.Text.Trim(), txtRecepter.Text.Trim(), txtRemark.Text.Trim(), _newVisitor.Id);

                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("访问时间格式不正确，请重新填写！", "提示");
                        }
                        
                    }else
                    {
                        MessageBox.Show("访客信息不完整，请补充完整！", "提示");
                    }
                }
                else
                {
                    MessageBox.Show("身份信息不完整，请补充完整！", "提示");
                }
            }
            else
            {
                VisitLogService vls = new VisitLogService();
                if (txtPurpose.Text.Trim().Length > 0 && txtRecepter.Text.Trim().Length > 0)
                {
                    if (validateTime(txtTime.Text.Trim()))
                    {
                        vls.AddLog(txtTime.Text.Trim(), txtPurpose.Text.Trim(), txtRecepter.Text.Trim(), txtRemark.Text.Trim(), _currentVisitor.Id);

                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("访问时间格式不正确，请重新填写！", "提示");
                    }
                }
                else
                {
                    MessageBox.Show("访客信息不完整，请补充完整！", "提示");

                }
            }                     
        }

        private bool validateTime(string logTime)
        {
            try
            {                
                if(logTime.Length == 0)
                {
                    return true;
                }
                DateTime.Parse(logTime);
                return true;
            }
            catch
            {
                return false;
            }
        }

        private void VisitorFrm_FormClosed(object sender, FormClosedEventArgs e)
        {
            OnFormClose(_newVisitor);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void VisitorFrm_Load(object sender, EventArgs e)
        {
            if(_currentVisitor != null)
            {
                txtName.Text = _currentVisitor.Name;
                txtMobile.Text = _currentVisitor.Mobile;
                txtIdentity.Text = _currentVisitor.Identity;
                txtCompany.Text = _currentVisitor.Company;

                txtName.Enabled = false;
                txtMobile.Enabled = false;
                txtIdentity.Enabled = false;
                txtCompany.Enabled = false;

                this.Text = "添加访问信息";
            }

            txtTime.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        }
    }
}
