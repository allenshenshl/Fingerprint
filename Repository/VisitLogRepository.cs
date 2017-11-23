using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Finger.Entity;
using System.Data.SQLite;

namespace Finger.Repository
{
    public class VisitLogRepository:BaseRepository
    {
        public int insert(VisitLog log)
        {
            string sql = "insert into visit_log(id, time, purpose, recepter, remark, visitor_id, leave_time) values(@id, @time, @purpose, @recepter, @remark, @visitor_id, @leave_time)";
            SQLiteParameter[] parameters = new SQLiteParameter[7];
            parameters[0] = new SQLiteParameter("@id", log.Id);
            parameters[1] = new SQLiteParameter("@time", log.Time);
            parameters[2] = new SQLiteParameter("@purpose", log.Purpose);
            parameters[3] = new SQLiteParameter("@recepter", log.Recepter);
            parameters[4] = new SQLiteParameter("@remark", log.Remark);
            parameters[5] = new SQLiteParameter("@visitor_id", log.VisitorId);
            parameters[6] = new SQLiteParameter("@leave_time", log.LeaveTime);

            return SQLHelper.ExecuteNonQuery(sql, parameters);
        }

        public int delete(string id)
        {
            string sql = "delete from visit_log where id=@id";
            SQLiteParameter[] parameters = new SQLiteParameter[1];
            parameters[0] = new SQLiteParameter("@id", id);

            return SQLHelper.ExecuteNonQuery(sql, parameters);
        }

        public int update(VisitLog log)
        {
            string sql = "update visit_log set time=@time, purpose=@purpose, recepter=@recepter, remark=@remark, leave_time=@leave_time where id=@id";
            SQLiteParameter[] parameters = new SQLiteParameter[6];
            parameters[0] = new SQLiteParameter("@id", log.Id);
            parameters[1] = new SQLiteParameter("@time", log.Time);
            parameters[2] = new SQLiteParameter("@purpose", log.Purpose);
            parameters[3] = new SQLiteParameter("@recepter", log.Recepter);
            parameters[4] = new SQLiteParameter("@remark", log.Remark);
            parameters[5] = new SQLiteParameter("@leave_time", log.LeaveTime);

            return SQLHelper.ExecuteNonQuery(sql, parameters);
        }

        public int updateColumn(string id, string colName, string value)
        {
            string sql = "update visit_log set " + colName + "=@val where id=@id";
            SQLiteParameter[] parameters = new SQLiteParameter[2];
            parameters[0] = new SQLiteParameter("@id", id);
            parameters[1] = new SQLiteParameter("@val", value);

            return SQLHelper.ExecuteNonQuery(sql, parameters);
        }

        public List<VisitLog> GetList(string startDate, string visitor, string accepter)
        {
            string sql = "select l.id, l.time, l.purpose, l.recepter, l.remark, l.leave_time, l.visitor_id, v.name, v.company from visit_log l left join visitor v on l.visitor_id=v.id where l.time>@startTime and v.name like '%" +
                visitor + "%' and l.recepter like '%" +accepter +"%' order by l.time desc";
            SQLiteParameter[] parameters = new SQLiteParameter[1];
            parameters[0] = new SQLiteParameter("@startTime", startDate);

            SQLiteDataReader reader = SQLHelper.ExecuteReader(sql, parameters);
            List<VisitLog> list = new List<VisitLog>();

            while (reader.Read())
            {
                VisitLog log = new VisitLog();
                log.Id = reader["id"].ToString();
                log.Time = reader["time"].ToString();
                log.Purpose = reader["purpose"].ToString();
                log.Recepter = reader["recepter"].ToString();
                log.Remark = reader["remark"].ToString();
                log.VisitorName = reader["name"].ToString();
                log.VisitorCompany = reader["company"].ToString();
                log.LeaveTime = reader["leave_time"].ToString();
                log.VisitorId = reader["visitor_id"].ToString();

                list.Add(log);
            }

            return list;
        }
    }
}
