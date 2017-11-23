using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Finger.Entity;
using System.Data.SQLite;
using System.Data;

namespace Finger.Repository
{
    public class UserRepository : BaseRepository
    {
        public int Insert(User user)
        {
            string sql = "insert into user(id, name, account, password) values(@id, @name, @account, @password)";
            SQLiteParameter[] parameters = new SQLiteParameter[4];
            parameters[0] = new SQLiteParameter("@id", user.Id);
            parameters[1] = new SQLiteParameter("@name", user.Name);
            parameters[2] = new SQLiteParameter("@account", user.Account);
            parameters[3] = new SQLiteParameter("@password", user.Password);

            return SQLHelper.ExecuteNonQuery(sql, parameters);
        }

        public int Delete(string id)
        {
            string sql = "delete from user where id=@id";
            SQLiteParameter[] parameters = new SQLiteParameter[1];
            parameters[0] = new SQLiteParameter("@id", id);

            return SQLHelper.ExecuteNonQuery(sql, parameters);
        }

        public int Update(string id, string name, string account, string password)
        {
            string sql = "update user set name=@name, account=@account, password=@password where id=@id";
            SQLiteParameter[] parameters = new SQLiteParameter[4];
            parameters[0] = new SQLiteParameter("@name", name);
            parameters[1] = new SQLiteParameter("@account", account);
            parameters[2] = new SQLiteParameter("@password", password);
            parameters[3] = new SQLiteParameter("@id", id);

            return SQLHelper.ExecuteNonQuery(sql, parameters);
        }


        public User Login(string account, string pwd)
        {
            string sql = "select id, name from user where account=@account and password=@password limit 1";
            SQLiteParameter[] parameters = new SQLiteParameter[2];
            parameters[0] = new SQLiteParameter("@account", account);
            parameters[1] = new SQLiteParameter("@password", pwd);

            DataTable table = SQLHelper.ExecuteQuery(sql, parameters);
            if(table.Rows.Count > 0)
            {
                User user = new User();
                user.Id = table.Rows[0]["id"].ToString();
                user.Name = table.Rows[0]["name"].ToString();

                return user;
            }            

            return null;
        }

        public List<User> GetList()
        {
            string sql = "select id, name, account, password from user";
            SQLiteDataReader reader = SQLHelper.ExecuteReader(sql, null);
            List<User> list = new List<User>();

            while (reader.Read())
            {
                User u = new User();
                u.Id = reader["id"].ToString();
                u.Name = reader["name"].ToString();
                u.Account = reader["account"].ToString();
                u.Password = reader["password"].ToString();

                list.Add(u);
            }

            return list;
        }
    }
}
