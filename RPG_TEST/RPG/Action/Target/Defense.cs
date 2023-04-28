using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RPG_TEST.RPG.Action.Target
{
    class Defense:Skill
    {
        public override string Skill_Name
        {
            get
            {
                return "DEFENSE";
            }
            
        }

        public new string Skill_Desc {

            get
            {
                return "Basic defense";
            }
        }

        public override void SetAttribute()
        {
            base.SetAttribute();
        }

        public override bool DoAction()
        {
             return base.DoAction();
        }

    }
}
