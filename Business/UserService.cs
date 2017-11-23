using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Finger.Repository;
using Finger.Entity;

namespace Finger.Business
{
    public class UserService:BaseService
    {
        private UserRepository _repository = new UserRepository();
        public UserService()
        {
        }

        public bool AddUser(string name, string account, string pwd)
        {
            User newUser = new User();
            newUser.Id = this.NewGUID();
            newUser.Name = name;
            newUser.Account = account;
            newUser.Password = pwd;

            return this._repository.Insert(newUser) > 0;
        }

        public bool DeleteUser(string id)
        {
            return this._repository.Delete(id) > 0;
        }

        public bool UpdateUser(string id, string name, string account, string pwd)
        {
            return this._repository.Update(id, name, account, pwd) > 0;
        }

        public User Login(string account, string pwd)
        {
            return this._repository.Login(account, pwd);
        }

        public List<User> GetUserList()
        {
            return this._repository.GetList();
        }
    }
}
