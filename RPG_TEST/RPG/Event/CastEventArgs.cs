using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RPG_TEST.RPG.Action;

namespace RPG_TEST.RPG.Event
{
    class CastEventArgs:EventArgs
    {
        public Role target;

        public CastEventArgs(SingleTarget single_cast) { 
        
            
        }
        
    }
}
