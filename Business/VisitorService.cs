using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Finger.Repository;
using Finger.Entity;

namespace Finger.Business
{
    public class VisitorService:BaseService
    {
        private VisitorRepository _repository = new VisitorRepository();

        public Visitor AddVisitor(string name, string mobile, string identity, string company, string templateStr)
        {
            Visitor v = new Visitor();
            v.Id = this.NewGUID();
            v.Name = name;
            v.Mobile = mobile;
            v.Identity = identity;
            v.Company = company;
            v.Template = templateStr;

            if(_repository.Insert(v) > 0)
            {
                return v;
            }else
            {
                return null;
            }
        }

        public bool DeleteVisitor(string id)
        {
            return _repository.Delete(id) > 0;
        }

        public List<Visitor> GetAllVisitors()
        {
            List<Visitor> list = _repository.GetList();
            for(int i = 0; i < list.Count; i++)
            {
                list[i].FPID = i;
            }

            return list;
        }
    }
}
