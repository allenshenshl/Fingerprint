using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Finger.Entity;
using Finger.Business;

namespace Finger.UI
{
    public partial class Main : Form
    {
        private List<Visitor> _visitList = new List<Visitor>();
        private VisitLogService _logService = new VisitLogService();

        public Main()
        {
            InitializeComponent();            
        }
               

        private void Main_Load(object sender, EventArgs e)
        {
            Robot.Control = this.axZKFPEngX1;

            initControl();

            addRegTemplate();

            switchToMatch();

            cbLogFilter.SelectedIndex = 0;

            bindGridView();

            if(Session.Account.ToLower() != "admin")
            {
                btnDeleteLog.Enabled = false;
            }
        }

        private void bindGridView()
        {
            BindingSource bs = new BindingSource();

            List<VisitLog> logs = _logService.GetLogList(cbLogFilter.SelectedIndex, txtVisitor.Text.Trim(), txtAccepter.Text.Trim());
            
            if(logs.Count > 0)
            {
                gvLog.AutoGenerateColumns = false;
                lblLogTip.Visible = false;
                bs.DataSource = logs;
                this.gvLog.DataSource = bs;
            }else
            {
                this.gvLog.DataSource = null;
                lblLogTip.Visible = true;
            }            
        }       

        private void connectMachineItem_Click(object sender, EventArgs e)
        {
            if(Robot.Control == null)
            {
                Robot.Control = this.axZKFPEngX1;
            }

            initControl();

            addRegTemplate();

            switchToMatch();
        }

        private void closeMachineItem_Click(object sender, EventArgs e)
        {
            Robot.Close();

            this.statusRobot.Text = "指纹仪状态：关闭连接";
        }

        private void quitItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void systemUserItem_Click(object sender, EventArgs e)
        {
            User userFrm = new User();
            userFrm.ShowDialog();
        }

        private void initControl()
        {
            int initResult = Robot.InitControl();
            if (initResult == 0)
            {
                this.statusRobot.Text = "指纹仪状态：初始化完成";
                btnRegister.Enabled = true;
                btnMatch.Enabled = true;
            }
            else if (initResult == 1)
            {
                this.statusRobot.Text = "指纹仪状态：指纹识别驱动程序加载失败";
            }
            else if (initResult == 2)
            {
                this.statusRobot.Text = "指纹仪状态：没有连接指纹识别仪";
            }
        }

        private void addRegTemplate()
        {
            VisitorService vs = new VisitorService();
            _visitList = vs.GetAllVisitors();

            Robot.AddRegTemplateToFPCache(_visitList);
        }

        public void refreshData(Visitor v)
        {          
            if(v != null)
            {
                v.FPID = _visitList.Count;
                _visitList.Add(v);
                Robot.AddSingleTemplateToFPCache(v.FPID, v.Template);
            }
            bindGridView();
            switchToMatch();
        }

        private void axZKFPEngX1_OnCapture(object sender, AxZKFPEngXControl.IZKFPEngXEvents_OnCaptureEvent e)
        {
            if(e.actionResult == true)
            {
                int[] matchInfo = e.aTemplate as int[];
                
                if(matchInfo[0] >= 0)
                {
                    Visitor v = _visitList[matchInfo[0]];

                    VisitLog log = _logService.GetTodayLogNotLeaveOfVisitor(v.Id);
                    if (log == null)
                    {
                        // 添加访问记录
                        VisitorFrm regForm = new VisitorFrm(v);
                        regForm.OnFormClose += refreshData;

                        regForm.ShowDialog(this);
                    }else
                    {
                        // 添加离开记录
                        leaveVisitor(log);
                    }                    
                }
                else
                {
                    if(MessageBox.Show("您好，未找到匹配的访客信息，您要登记新访客吗？", "提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        switchToRegister();
                    }
                }
            }else
            {
                MessageBox.Show("您好，没有获取到完整的指纹信息，请重新录入指纹！", "提示");
            }
        }

        private void leaveVisitor(VisitLog log)
        {
            FrmLeave frmLeave = new FrmLeave(log);
            if(frmLeave.ShowDialog() == DialogResult.OK)
            {
                refreshData(null);
            }
        }

        private void axZKFPEngX1_OnEnroll(object sender, AxZKFPEngXControl.IZKFPEngXEvents_OnEnrollEvent e)
        {
            VisitorFrm regForm = new VisitorFrm();
            regForm.OnFormClose += refreshData;

            regForm.ShowDialog(this);
        }

        private void axZKFPEngX1_OnFeatureInfo(object sender, AxZKFPEngXControl.IZKFPEngXEvents_OnFeatureInfoEvent e)
        {
            if(Robot.Control.IsRegister)
            {
                int enrollTimes = Robot.Control.EnrollCount - Robot.Control.EnrollIndex + 1;
                if(enrollTimes == Robot.Control.EnrollCount)
                {
                    enrollStatus.Text = "";
                }else
                {
                    enrollStatus.Text = "指纹录入第" + (Robot.Control.EnrollCount - Robot.Control.EnrollIndex + 1) + "次";
                }                
            }
        }

        private void switchToRegister()
        {
            if (Robot.IsConnected)
            {
                Robot.BeginEnroll();
                pbFinger.Image = null;
                statusRobot.Text = "指纹仪状态：登记模式";
                MessageBox.Show("确定之后请开始录入指纹并行登记，一共录入三次！", "提示");

                btnRegister.Enabled = false;
                btnMatch.Enabled = true;
            }            
        }

        private void switchToMatch()
        {
            if (Robot.IsConnected)
            {
                Robot.BeginCapture();
                pbFinger.Image = null;
                statusRobot.Text = "指纹仪状态：匹配模式";

                btnMatch.Enabled = false;
                btnRegister.Enabled = true;
            }
            
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            switchToRegister();
        }

        private void btnMatch_Click(object sender, EventArgs e)
        {
            switchToMatch();
        }

        private void Main_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void cbLogFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            bindGridView();
        }

        private void btnDeleteLog_Click(object sender, EventArgs e)
        {
            VisitLog log = null;
            if (gvLog.SelectedRows.Count > 0)
            {
                log = gvLog.SelectedRows[0].DataBoundItem as VisitLog;
            }

            if (log == null)
            {
                MessageBox.Show("请点击行头，选择要删除的记录！", "提示");
                return;
            }

            if (MessageBox.Show("确定要删除访问记录吗？", "提示", MessageBoxButtons.YesNo) == DialogResult.Yes){
                _logService.DeleteLog(log.Id);

                bindGridView();
            }            
        }

        private void btnModifyLog_Click(object sender, EventArgs e)
        {
            VisitLog log = null;
            if (gvLog.SelectedRows.Count > 0)
            {
                log = gvLog.SelectedRows[0].DataBoundItem as VisitLog;
            }
            
            if (log == null)
            {
                MessageBox.Show("请点击行头，选择要修改的记录！", "提示");
                return;
            }

            EditLog logFrm = new EditLog(log);
            logFrm.OnFormClose += refreshData;

            logFrm.ShowDialog(this);
        }

        private void axZKFPEngX1_OnImageReceived(object sender, AxZKFPEngXControl.IZKFPEngXEvents_OnImageReceivedEvent e)
        {
            Graphics gs = pbFinger.CreateGraphics();
            int dc = gs.GetHdc().ToInt32();
            axZKFPEngX1.PrintImageAt(dc, 0, 0, pbFinger.Width, pbFinger.Height);
        }

        private void gvLog_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.ColumnIndex == 7)
            {
                VisitLog log = gvLog.Rows[e.RowIndex].DataBoundItem as VisitLog;

                if(log != null)
                {
                    if(log.LeaveTime.Length == 0)
                    {
                        leaveVisitor(log);
                    }
                    else
                    {
                        MessageBox.Show("访客:[" + log.VisitorName + "]已经离开了哦", "提示");
                    }                    
                }
            }
        }

        private void btnQuery_Click(object sender, EventArgs e)
        {
            bindGridView();
        }
        
    }
}
