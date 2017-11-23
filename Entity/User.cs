using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Finger.Entity
{
    public class User
    {
        private string _id = "";
        private string _name = "";
        private string _account = "";
        private string _password = "";
        
        public string Id
        {
            get { return this._id; }
            set { this._id = value; }
        }

        public string Name
        {
            get { return this._name; }
            set { this._name = value; }
        }

        public string Account
        {
            get { return this._account; }
            set { this._account = value; }
        }

        public string Password
        {
            get { return this._password; }
            set { this._password = value; }
        }

    }
}
