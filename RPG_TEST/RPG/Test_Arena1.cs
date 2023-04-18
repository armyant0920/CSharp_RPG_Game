using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RPG_TEST.RPG.Action;

namespace RPG_TEST.RPG
{
    class Test_Arena1
    {

        static List<Role> roles;
        static Random rnd = new Random();
        static int round = 0;
        static bool First = true;

        static void Main(string[] args) {



            
            



            Console.WriteLine("create role");
            Init();
            Role GM = new Role("GM");
            GM.STR = 100;
            Role wounded = roles[0];
            wounded.HP = 1;
            HolyLight holy = new HolyLight(GM,wounded);
            holy.Cast();

            Console.ReadKey();

            //Role role1 = new 

            int pick = rnd.Next((roles.Count-1));

            Role role1 = roles[pick];
            Console.WriteLine(role1.ToString());
            roles.Remove(role1);
            pick = rnd.Next((roles.Count - 1));
            Role role2 = roles[pick];
            Console.WriteLine(role2.ToString());
            List<Role> players = new List<Role>();
            players.Add(role1);
            players.Add(role2);


            Console.WriteLine("########### battle begin ###########");
            

            foreach (Role role in players) { 
                //attack event 訂閱 
                role.AttackEvent += (sender, e) =>
                {
                    Console.WriteLine("{0} attack {1}",((Role)sender).NAME,e.target.NAME);

                };

                role.DamageEvent += (sender, e) =>
                {
                    Role attacked=(Role)sender;
                    Console.WriteLine("{0} take {1} damage from {2},remain HP:{3}", attacked.NAME, e.damage, e.Attacker.NAME,Math.Max(attacked.HP,0));
                };
                role.DieEvent += (sender, e) =>
                {
                    Console.WriteLine("{0} go down", ((Role)sender).NAME);
                };

            }

            //依照速度排序
            players.Sort((x,y)=>y.SPEED.CompareTo(x.SPEED));

            

            //players.OrderByDescending(p => p.SPD);

            //當沒有dead時
            
            while (players.Count(p => p._STATE == Role.STATE.DEAD) <= 0) {
                Console.ReadKey();
                //一個回合
                if (First)
                {
                    Console.WriteLine("===========Round{0} begin===========", ++round);
                    players[0].Attack(players[1]);
                }
                else {
                    players[1].Attack(players[0]);
                    Console.WriteLine("===========Round{0} end=============", round);

                }
                First = !First;
            }

            foreach (Role role in players.Where(p => p._STATE != Role.STATE.DEAD).ToArray()) {
                Console.WriteLine("{0} is alive", role.NAME);
            }

            
            Console.WriteLine("########### game over ###########");
            Console.WriteLine("press any key to leave");
            Console.ReadKey(); 


        }

        static void Init() {

            roles = new List<Role>();

            
            Role role1 = new Role("FootMan");
            
            Role role2 = new Role("Licker");
            
            Role role3 = new Role("MarryRose");
            Role role4 = new Role("Juri");
            Role role5 = new Role("Chun Li");
            Role role6 = new Role("Lyu");
            Role role7 = new Role("Ken");
            Role role8 = new Role("GPT4");
            Role role9 = new Role("Meta");
            Role role10 = new Role("OpenAI");
            roles.Add(role1);
            roles.Add(role2);
            roles.Add(role3);
            roles.Add(role4);
            roles.Add(role5);
            roles.Add(role6);
            roles.Add(role7);
            roles.Add(role8);
            roles.Add(role9);
            roles.Add(role10);


            
            foreach (Role role in roles) {

                int hp = 50 + rnd.Next(50);
                int str = 10 + rnd.Next(10);
                int def = 5 + rnd.Next(5);
                int speed = 10 + rnd.Next(10);
                role.HP = hp;
                role.MAX_HP = hp;
                role.STR = str;
                role.DEF = def;
                role.SPEED = speed;
            }
        }

    }
}
