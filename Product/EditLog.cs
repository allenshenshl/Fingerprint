using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Finger.Entity;
using Finger.Business;

namespace Finger.UI
{
    public partial class EditLog : Form
    {
        private VisitLogService _logService = new VisitLogService();
        private VisitLog _currentLog = null;

        public delegate void OnCloseHandler(Visitor v);
        public OnCloseHandler OnFormClose;
        public EditLog()
        {
            InitializeComponent();
        }

        public EditLog(VisitLog log)
        {
            InitializeComponent();

            _currentLog = log;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtPurpose.Text.Trim().Length > 0 && txtRecepter.Text.Trim().Length > 0)
            {
                if (validateTime(txtTime.Text.Trim()) && validateTime(txtLeaveTime.Text.Trim()))
                {
                    _logService.UpdateLog(_currentLog.Id, txtTime.Text.Trim(), txtPurpose.Text.Trim(), txtRecepter.Text.Trim(), txtRemark.Text.Trim(), txtLeaveTime.Text.Trim());
                }
                else
                {
                    MessageBox.Show("访问时间格式不正确，请重新填写！", "提示");
                }

                this.Close();
                OnFormClose(null);
            }
            else
            {
                MessageBox.Show("访客信息不完整，请补充完整！", "提示");

            }
        }

        private bool validateTime(string logTime)
        {
            try
            {
                if (logTime.Length == 0)
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

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void EditLog_Load(object sender, EventArgs e)
        {
            lblVisitorName.Text = _currentLog.VisitorName;

            txtPurpose.Text = _currentLog.Purpose;
            txtTime.Text = _currentLog.Time;
            txtRecepter.Text = _currentLog.Recepter;
            txtRemark.Text = _currentLog.Remark;
            txtLeaveTime.Text = _currentLog.LeaveTime;
        }
    }
}
