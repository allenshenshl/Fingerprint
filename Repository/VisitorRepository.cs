using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Finger.Entity;
using System.Data.SQLite;

namespace Finger.Repository
{
    public class VisitorRepository : BaseRepository
    {
        public int Insert(Visitor visitor)
        {
            string sql = "insert into visitor(id, name, mobile, identity, company, template) values(@id, @name, @mobile, @identity, @company, @template)";
            SQLiteParameter[] parameters = new SQLiteParameter[6];
            parameters[0] = new SQLiteParameter("@id", visitor.Id);
            parameters[1] = new SQLiteParameter("@name", visitor.Name);
            parameters[2] = new SQLiteParameter("@mobile", visitor.Mobile);
            parameters[3] = new SQLiteParameter("@identity", visitor.Identity);
            parameters[4] = new SQLiteParameter("@company", visitor.Company);
            parameters[5] = new SQLiteParameter("@template", visitor.Template);

            return SQLHelper.ExecuteNonQuery(sql, parameters);
        }

        public int Delete(string id)
        {
            string sql = "delete from visitor where id=@id";
            SQLiteParameter[] parameters = new SQLiteParameter[1];
            parameters[0] = new SQLiteParameter("@id", id);

            return SQLHelper.ExecuteNonQuery(sql, parameters);
        }

        public List<Visitor> GetList()
        {
            string sql = "select id, name, mobile, identity, company, template from visitor";
            SQLiteDataReader reader = SQLHelper.ExecuteReader(sql, null);
            List<Visitor> list = new List<Visitor>();

            while (reader.Read())
            {
                Visitor v = new Visitor();
                v.Id = reader["id"].ToString();
                v.Name = reader["name"].ToString();
                v.Mobile = reader["mobile"].ToString();
                v.Identity = reader["identity"].ToString();
                v.Company = reader["company"].ToString();
                v.Template = reader["template"].ToString();

                list.Add(v);
            }

            return list;
        }
    }
}
