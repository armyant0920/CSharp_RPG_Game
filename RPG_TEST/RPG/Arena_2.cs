using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RPG_TEST.RPG.Action;

namespace RPG_TEST.RPG
{
    class Arena_2
    {
        
        static bool _continue=true;

        public static void Main(string[] args) {
            //List<Role> roles = new List<Role>();
            Console.WriteLine("this is arena2");
            Player.Player player1 = new Player.Player("Player1");
            Role role1 = new Role("Role1", 100, 10, 2, 10);
            player1.AddMember(role1);
            Player.Player player2 = new Player.Player("Player2");
            Role role2 = new Role("Role2", 100, 200, 0, 10);
            player2.AddMember(role2);

            //SubscriptEvent(player1,player2);
            role1.LearnSkill(new Action.Attack());
            role1.LearnSkill(new Action.Attack());//test for duplicate
            List<Skill> role1_actliist = role1.ShowSkills();
            //Console.WriteLine(role1.ShowSkills());
            Console.WriteLine("test for picking");
            int select_index;

            if (int.TryParse(Console.ReadKey().KeyChar.ToString(), out select_index))
            {
                Skill skill = role1_actliist[select_index];

                Console.WriteLine("press: {0},pick: {1}",select_index,skill.Skill_Name);

            }
            else {
                Console.WriteLine("your input key is invalid");
                
            }
            
            


            role2.LearnSkill(new Action.Attack());
            List<Skill> role2_actliist = role2.ShowSkills();
            //Console.WriteLine(role2.ShowSkills());

            //**********************
            
            
            //Skill skill=Battle.PickAction(role1);
            //Console.WriteLine("pick:{0}",skill);




            RPG_TEST.RPG.Action.Skill act = new Attack(role1,role2);
            Console.ReadKey();
            act.DoAction();
            act = new Attack(role2,role1);
            Console.ReadKey();
            act.DoAction();

            Console.WriteLine(role1);
            Console.WriteLine(role2);
            Console.ReadKey();
        }




        /// <summary>
        /// try to use queue structure handle actions
        /// </summary>
        public static void QueueTest() { 
            
        }

        public static void RoundAction(List<Skill> actions){

            //by action's priority sort
            actions.Sort((x, y) => y.priority.CompareTo(x.priority));
            
            foreach(Skill act in actions){

                try
                {
                    act.CheckAvailable();
                    act.DoAction();
                }
                catch (CustomException.ActionException ex)
                {
                    Console.WriteLine("action fail:{0}",ex.Message);
                }
                catch (Exception ex) {
                    Console.WriteLine("action occur unexpection exception:{0}\n{1}",ex.Message,ex.StackTrace);
                
                }
                //finally{
                
                //    //if any team all out,quit battle
                //    if (CheckTeam()) { 
                //    };
                
                //}
                

            }
        
        }

        public static bool CheckTeam(Player.Player player1,Player.Player player2) { 
            //check player's team  if all team member death,quit
            bool b = true;

            foreach (Role role in player1.group)
            {
                //if any member alive 
                b = player1.group.Any(r => r._STATE != Role.STATE.DEAD);
                if (b == false) {
                    EndMessage(player1);
                    return false;
                }
                //player1.group.Exists(r => r._STATE != Role.STATE.DEAD);          
            }
            foreach (Role role in player2.group) {
                b = player2.group.Any(r => r._STATE != Role.STATE.DEAD);
                if (b == false) return b;
            }

            return b;
        }

        public static void EndMessage(Player.Player player) { 

            
        }
    }
}
