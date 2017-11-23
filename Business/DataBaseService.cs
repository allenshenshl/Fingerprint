using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Finger.Repository;
using System.IO;
using Finger.Entity;

namespace Finger.Business
{
    public class DataBaseService:BaseService
    {
        private BaseRepository _repository = new BaseRepository();
        private string _dataFile = "data.db";
        public void InitDataBase()
        {
            // 创建数据库文件
            if (!File.Exists(_dataFile))
            {
                SQLiteDBHelper.CreateDB(_dataFile);

                // 设置连接字符串
                SQLiteDBHelper.SetConnectionString(Environment.CurrentDirectory +"\\" + _dataFile);
                
                // 创建表结构
                _repository.CreateSchema();

                UserRepository userRep = new UserRepository();
                User systemUser = new User();
                systemUser.Id = this.NewGUID();
                systemUser.Name = "系统管理员";
                systemUser.Account = "admin";
                systemUser.Password = "888888";

                userRep.Insert(systemUser);
            }else
            {
                // 设置连接字符串
                SQLiteDBHelper.SetConnectionString(Environment.CurrentDirectory + "\\" + _dataFile);
            }            
        }
    }
}
