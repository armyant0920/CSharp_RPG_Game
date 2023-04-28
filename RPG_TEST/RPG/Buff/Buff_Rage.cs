using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RPG_TEST.RPG.Buff
{
    class Buff_Rage:Buff_Base
    {


        public override Unit.Attribute getAttr()
        {                   
            return this.attr;
        }

        public Buff_Rage() {

            this.attr = new Unit.Attribute();
            attr.STR = 10;
        }

    }
}
