using System;

namespace Finger.Business
{
    public class BaseService
    {
        public BaseService()
        {

        }

        public string NewGUID()
        {
            return Guid.NewGuid().ToString();
        }
    }
}
