using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LoginWork.Controllers
{
    public static class session
    {
        public static int log = 2;
        public static int setsess(int val)
        {
            log = val;
            return log;
        }
        public static int getsess()
        {
            return log;
        }

    }
}