using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RPG_TEST.RPG.Action
{
    abstract class Skill
    {
        public string Skill_Name;
        public int CoolDown;
        public Role caster;
        public abstract void Cast();//施展
    }
}
