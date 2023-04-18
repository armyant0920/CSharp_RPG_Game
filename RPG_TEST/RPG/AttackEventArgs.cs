using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RPG_TEST.RPG
{
    class AttackEventArgs:EventArgs
    {
        //public Role attacker;
        public Role target { get; private set; }
        public AttackEventArgs(Role role) {
            //attacker =(Role) this;
            target = role;
        }
    }
}
