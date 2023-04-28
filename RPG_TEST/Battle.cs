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
        /// <summary>
        /// auto decide unit's action in input player team
        /// </summary>
        /// <param name="player"></param>
        public static void AutoChoose(Player myteam,Player enemyteam) {

            List<Skill> Picked_Actions = new List<Skill>();
            Random rnd = new Random();
            foreach (Role role in myteam.group) {
                
                int selected = rnd.Next(role.skills.Count);
                Skill action = role.skills[selected];
                
                //check availiable,maybe only availiable skills should be inclide?

                // check pick action available first,
                //I think it could check by action itself
                //but if all action not availble?
                //single target:if enemy,if no enemy target,means over,in select section it shouldn't happen
                //single target:if ally,if no ally,try

                if (action.Skill_Useage.Contains(Skill.USEAGE.ENEMY)) {
                    //pick only alive enemy

                    List<Role> targets = enemyteam.group.Where(x => x._STATE != Role.STATE.DEAD).ToList();
                    //selected =rnd.Next(targets.Count);        
                    action.SetTarget(targets.ElementAt(rnd.Next(targets.Count)));                    
                }

                if (action.Skill_Useage.Contains(Skill.USEAGE.ALLY)) {
                    
                    List<Role> targets = myteam.group.Where(x => x._STATE != Role.STATE.DEAD).ToList();
                    action.SetTarget(targets.ElementAt(rnd.Next(targets.Count)));
                }

                //override by invidual action
                action.SetAttribute();


                Picked_Actions.Add(action);
                
            }
            
        }

        //for easy way,just give current pick role and all role,
        //then all owner<>role's owner =enemy,vise versa
        
        //or even input param = all battle ground,
        //since battle ground should include all element..

        public static void ShowMember(List<Role> all) {//Role role,
            
            

            Console.WriteLine("plz choose target");

            //if show enemys
            //List<Role> targets = all.Where(r => r.Owner != role.Owner && r._STATE != Role.STATE.DEAD).ToList();

            for (int i = 0; i < all.Count; i++) {
                Console.WriteLine(all[i]);
                Console.WriteLine("key:{0}", i);
            
            }
            

        
        }

        public static int Pick() {


            Console.WriteLine("press key");

            int pick=-1;
            ConsoleKeyInfo keyinfo = Console.ReadKey();
            if (int.TryParse(keyinfo.KeyChar.ToString(), out pick))
            {
                return pick;
            }
            else if (keyinfo.Key != ConsoleKey.Escape)
            {
                Console.WriteLine("illegal input index,choose again");
                return Pick();
                //throw new KeyNotFoundException("illegal input key");
                
            }
            else {
                return -1;
                // throw new KeyNotFoundException("illegal input key");
            }
            
        }

        

        public static Skill PickAction(Role role) {
            //show skill list first
            Console.WriteLine("choose action from blow list");
            List<Skill>skills= role.ShowSkills();

            ConsoleKeyInfo input = Console.ReadKey();

            Console.WriteLine("user press key:{0}",input.KeyChar.ToString());
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



        public static List<Skill> PlayerRound(Player player) {
            //choose interface for each player
            List<Skill> list = new List<Skill>();
            foreach (Role role in player.group) {
                //pick action
                Skill skill = PickAction(role);
                //pick target
                
                //
                
            }


            return list;
        
        }
        

        
    }
}
