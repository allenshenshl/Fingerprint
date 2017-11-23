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
    public partial class FrmLeave : Form
    {
        private VisitLog _log = new VisitLog();
        public FrmLeave()
        {
            InitializeComponent();
        }

        public FrmLeave(VisitLog log)
        {
            InitializeComponent();
            _log = log;
        }

        private void btnCheck_Click(object sender, EventArgs e)
        {
            if (validateTime(txtLeaveTime.Text.Trim()))
            {
                VisitLogService service = new VisitLogService();
                service.UpdateLeaveTime(_log.Id, txtLeaveTime.Text.Trim());

                this.DialogResult = DialogResult.OK;
                this.Close();
            }else
            {
                MessageBox.Show("您输入的时间格式不正确，请重新输入！", "提示");
            }
            
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void FrmLeave_Load(object sender, EventArgs e)
        {
            lblVisitorName.Text = _log.VisitorName;
            txtLeaveTime.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
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
    }
}
