using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RPG_TEST.RPG
{
    class DamageEventArgs : EventArgs
    {
        public Role Attacker { get; private set; }
        public Role Attacked { get; private set; }
        public int damage { get; private set; }
        public DamageEventArgs(Role attacker,Role attacked, int damage) {

            this.Attacker = attacker;
            this.Attacked = attacked;
            this.damage = damage;
        }

    }
}
