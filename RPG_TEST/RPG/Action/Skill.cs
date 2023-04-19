using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RPG_TEST.RPG.Action
{
    abstract class Skill
    {


        enum AVAILABLE
        {
            ALLY,
            ENEMY,
            NONE,
            ALL        
        }

        enum RANGE { 
            SINGLE,
            GROUP                
        }

        public string Skill_Name;
        public int CoolDown;
        public Role caster;

        //by 對象範圍
        public abstract void Cast();
        //public abstract void Cast(Role Target);
        //public abstract void Cast(List<Role> Group);

    }
}
