using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace RPG_TEST.RPG
{
    class Buff_Base
    {
        public string Buff_name;
        public int Duration;//

        //public int Level;//buff level
        public Role Caster;//

        public Unit.Attribute attr;

        public virtual Unit.Attribute getAttr(){
            return attr;
        }

        
        
        
    }
}
