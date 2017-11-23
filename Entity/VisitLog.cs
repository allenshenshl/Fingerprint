using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Finger.Entity
{
    public class VisitLog
    {
        private string _id = "";
        private string _time = DateTime.Now.ToLongDateString();
        private string _purpose = "";
        private string _recepter = "";
        private string _remark = "";
        private string _visitorId = "";
        private string _visitorName = "";
        private string _vistorCompany = "";
        private string _leaveTime = "";

        public string Id
        {
            get { return this._id; }
            set { this._id = value; }
        }

        public string Time
        {
            get { return this._time; }
            set { this._time = value; }
        }

        public string Purpose
        {
            get { return this._purpose; }
            set { this._purpose = value; }
        }

        public string Recepter
        {
            get { return this._recepter; }
            set { this._recepter = value; }
        }

        public string Remark
        {
            get { return this._remark; }
            set { this._remark = value; }
        }

        public string VisitorId
        {
            get { return this._visitorId; }
            set { this._visitorId = value; }
        }

        public string VisitorName
        {
            get { return this._visitorName; }
            set { this._visitorName = value; }
        }

        public string VisitorCompany
        {
            get { return this._vistorCompany; }
            set { this._vistorCompany = value; }
        }

        public string LeaveTime
        {
            get { return this._leaveTime; }
            set { this._leaveTime = value; }
        }
    }
}
