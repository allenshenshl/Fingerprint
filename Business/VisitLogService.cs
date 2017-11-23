using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Finger.Repository;
using Finger.Entity;

namespace Finger.Business
{
    public class VisitLogService:BaseService
    {
        private VisitLogRepository _logRepository = new VisitLogRepository();
        public VisitLogService()
        {

        }

        public bool AddLog(string logTime, string purpose, string recepter, string remark, string visitorId)
        {
            if(logTime.Length == 0)
            {
                logTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            }else
            {
                logTime = DateTime.Parse(logTime).ToString("yyyy-MM-dd HH:mm:ss");
            }
            VisitLog log = new VisitLog();
            log.Id = this.NewGUID();
            log.Time = logTime;
            log.Purpose = purpose;
            log.Recepter = recepter;
            log.Remark = remark;
            log.VisitorId = visitorId;

            return _logRepository.insert(log) > 0;
        }       

        public bool DeleteLog(string id)
        {
            return _logRepository.delete(id) > 0;
        }

        public bool UpdateLog(string id, string logTime, string purpose, string recepter, string remark, string leftTime)
        {
            if (logTime.Length == 0)
            {
                logTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            }else
            {
                logTime = DateTime.Parse(logTime).ToString("yyyy-MM-dd HH:mm:ss");
            }
            if(leftTime.Length > 0)
            {
                leftTime = DateTime.Parse(leftTime).ToString("yyyy-MM-dd HH:mm:ss");
            }
            VisitLog log = new VisitLog();
            log.Id = id;
            log.Time = logTime;
            log.Purpose = purpose;
            log.Recepter = recepter;
            log.Remark = remark;
            log.LeaveTime = leftTime;

            return _logRepository.update(log) > 0;
        }

        public bool UpdateLeaveTime(string id, string leaveTime)
        {
            if(leaveTime.Length == 0)
            {
                leaveTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            }
            else
            {
                leaveTime = DateTime.Parse(leaveTime).ToString("yyyy-MM-dd HH:mm:ss");
            }

            return _logRepository.updateColumn(id, "leave_time", leaveTime) > 0;
        }

        public VisitLog GetTodayLogNotLeaveOfVisitor(string visitorId)
        {
            List<VisitLog> list = this.GetLogList(0, "","");
            foreach(VisitLog log in list)
            {
                if(log.VisitorId == visitorId && log.LeaveTime == "")
                {
                    return log;
                }
            }

            return null;
        }

        public List<VisitLog> GetLogList(int filterIndex, string visitor, string accepter)
        {
            DateTime startTime = DateTime.Now.Date;
            switch (filterIndex)
            {
                case 0:
                    startTime = DateTime.Now.Date;
                    break;
                case 1:
                    startTime = GetTimeStartByType("Week", DateTime.Now);
                    break;
                case 2:
                    startTime = GetTimeStartByType("Month", DateTime.Now);
                    break;                
                default:
                    startTime = DateTime.Parse("1970-01-01");
                    break;
            }
            return _logRepository.GetList(startTime.ToString("yyyy-MM-dd 00:00:00"), visitor, accepter);
        }

        /// <summary>
        /// 获取结束时间
        /// </summary>
        /// <param name="TimeType">Week、Month、Season、Year</param>
        /// <param name="now"></param>
        /// <returns></returns>
        public DateTime GetTimeStartByType(string TimeType, DateTime now)
        {
            switch (TimeType)
            {
                case "Week":
                    return now.AddDays(-(int)now.DayOfWeek);
                case "Month":
                    return now.AddDays(-now.Day + 1);
                case "Season":
                    var time = now.AddMonths(0 - ((now.Month - 1) % 3));
                    return time.AddDays(-time.Day + 1);
                case "Year":
                    return now.AddDays(-now.DayOfYear + 1);
                default:
                    return DateTime.Now;
            }
        }

    }
}
