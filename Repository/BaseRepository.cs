using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SQLite;

namespace Finger.Repository
{
    public class BaseRepository
    {
        public SQLiteDBHelper SQLHelper = new SQLiteDBHelper();
        public void CreateSchema()
        {
            List<KeyValuePair<string, SQLiteParameter[]>> sqlList = new List<KeyValuePair<string, SQLiteParameter[]>>();

            // 用户表
            string sql = "CREATE TABLE IF NOT EXISTS user(id   TEXT PRIMARY KEY NOT NULL COLLATE NOCASE,  name TEXT,  account TEXT,  password TEXT); ";
            sqlList.Add(new KeyValuePair<string, SQLiteParameter[]>(sql, null));

            // 访客
            sql = "CREATE TABLE IF NOT EXISTS visitor(id TEXT PRIMARY KEY NOT NULL COLLATE NOCASE, name TEXT, mobile TEXT, identity TEXT, company TEXT, template TEXT);";
            sqlList.Add(new KeyValuePair<string, SQLiteParameter[]>(sql, null));

            // 拜访记录
            sql = "CREATE TABLE IF NOT EXISTS visit_log(id   TEXT PRIMARY KEY NOT NULL COLLATE NOCASE, time TEXT, purpose TEXT, recepter TEXT, remark TEXT, visitor_id TEXT, leave_time TEXT); ";
            sqlList.Add(new KeyValuePair<string, SQLiteParameter[]>(sql, null));

            SQLHelper.ExecuteNonQueryBatch(sqlList);
        }
    }
}
