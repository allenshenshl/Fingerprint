using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Finger.Entity
{
    public class Visitor
    {
        private string _id = "";
        private string _name = "";
        private string _mobile = "";
        private string _identity = "";
        private string _company = "";
        private string _template = "";
        private int _fpId = 0;

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

        public string Mobile
        {
            get { return this._mobile; }
            set { this._mobile = value; }
        }

        public string Identity
        {
            get { return this._identity; }
            set { this._identity = value; }
        }

        public string Company
        {
            get { return this._company; }
            set { this._company = value; }
        }


        public string Template
        {
            get { return this._template; }
            set { this._template = value; }
        }

        public int FPID
        {
            get { return this._fpId; }
            set { this._fpId = value; }
        }

    }
}
