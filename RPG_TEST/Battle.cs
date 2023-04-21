using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RPG_TEST.RPG.Player;
using RPG_TEST.RPG;
using RPG_TEST.RPG.Action;

namespace RPG_TEST
{
    class Battle
    {
        List<Player> teams;


        public Battle(params Player[] players) { 
            //basically should be only 2 players       
        
            

        }
        /// <summary>
        /// 
        /// </summary>
        public void Battle_begin() { 
                
            
        }

        public void Battle_end() { 
            //
        
        }


        public void Round() { 
            
        
        }

        public void RoleDecision(Role role) { 
        
            //1.vaild role pick action
            try
            {
                Skill skill = PickAction(role);

                bool useable =skill.CheckAvailable();

            }
            catch (Exception ex) {

                Console.WriteLine("occur exception:{0}",ex.Message);
            }
            
            

        
        }


        public Skill PickAction(Role role) {
            //show skill list first
            Console.WriteLine("choose action from blow list");
            List<Skill>skills= role.ShowSkills();

            ConsoleKeyInfo input = Console.ReadKey();

            if (input.Equals (ConsoleKey.Escape)) {
                Console.WriteLine("press ESC,cancel move");
                throw new ArgumentException("press Cancel");
            }

            for(int i=0;i<skills.Count;i++){
                if (input.KeyChar.ToString() == i.ToString()) {
                    Console.WriteLine("role {0} pick action:{1}",role.NAME,skills[i]);
                    //

                    //
                    return skills[i];
                }
                Console.WriteLine("invaild input,please ");
                
            }
            return null;

        }
        

        
    }
}
