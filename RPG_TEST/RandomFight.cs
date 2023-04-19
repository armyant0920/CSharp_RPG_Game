using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RPG_TEST.RPG.Player;
using RPG_TEST.RPG;

namespace RPG_TEST
{
    class RandomFight
    {
        static Random rnd = new Random();

//        static string[]UnitPool = {"Golbin","Ghoul","Thief","Wolf","Zombie"};

        static Role Golbin = new Role("");



        static List<Role> pool = new List<Role> {
            new Role("Golbin",rnd.Next(11)+20,rnd.Next(2)+10,1,11),
            new Role("Ghoul",rnd.Next(6)+15,rnd.Next(5)+10,0,12),
            new Role("Thief",rnd.Next(11)+20,rnd.Next(1)+10,0,13),
            new Role("Wolf",rnd.Next(11)+25,rnd.Next(4)+10,0,14),
            new Role("Zombie",rnd.Next(11)+30,rnd.Next(3)+10,0,10),
        
        
        };



        public static Player PlayWithAI() {

          
            Player AI = new Player("AI");
            //set group member
            int group_size = rnd.Next(3)+1;
            //預設最少1,最多3
            for (int i = 1; i <= group_size; i++) {
                int pick=rnd.Next(pool.Count);
                Role role = pool[pick];
                AI.AddMember(role);
                //string pickname = UnitPool[rnd.Next(UnitPool.Length)];
                //Role role = new Role(pickname);

            }

            return AI;
        }

    }
}
