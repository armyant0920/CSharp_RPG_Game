using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RPG_TEST.RPG;
using RPG_TEST.RPG.Player;
using RPG_TEST.RPG.Action;

namespace RPG_TEST
{
    class Selection
    {

        List<Role> targets;//又或者直接在
        List<ALLOWS> rules;

        enum ALLOWS{
            ALLY,
            ENEMY,
            ALIVE,
            DEAD,
            FREEZE,
            POSITIONS,
            SLEEP
        }

        static void SelectTarget() {


            Console.WriteLine("pl");    
        
        }

        static Role SelectTarget2()
        {
            Role role = null;
            return role;
        }

        static void InitCondition(Player player,Skill skill) { 
            

        }









    }
}
