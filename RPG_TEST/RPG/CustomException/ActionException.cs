using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RPG_TEST.RPG.CustomException
{
    class ActionException:Exception
    {
        public ActionException() {  }

        public ActionException(string message) : base(message) { 
        }
       

    }
}
