using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace RPG_TEST.RPG
{
    class Buff
    {
        public string Buff_name;
        public int Duration;//持續回合

        public int Level;//buff level
        public Role Caster;//施展buff的角色,用以追蹤效果
    }
}
