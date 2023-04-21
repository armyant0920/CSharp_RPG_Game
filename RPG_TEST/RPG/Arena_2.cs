using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RPG_TEST.RPG.Action;

namespace RPG_TEST.RPG
{
    class Arena_2
    {
        
        public static void Main(string[] args) {
            //List<Role> roles = new List<Role>();
            Console.WriteLine("this is arena2");
            Player.Player player1 = new Player.Player("Player1");
            Role role1 = new Role("Role1", 100, 10, 0, 10);
            player1.AddMember(role1);
            Player.Player player2 = new Player.Player("Player2");
            Role role2 = new Role("Role2", 100, 10, 0, 10);
            player2.AddMember(role2);

            SubscriptEvent(player1,player2);


            RPG_TEST.RPG.Action.Skill act = new Attack(role1,role2);

            act.DoAction();
            act = new Attack(role2,role1);
            act.DoAction();

            Console.WriteLine(role1);
            Console.WriteLine(role2);
            Console.ReadKey();
        }

        public static void SubscriptEvent(Player.Player player1, Player.Player player2)
        {
            foreach (Role role in player1.group)
            {
                //attack event 訂閱 
                role.AttackEvent += (sender, e) =>
                {
                    Console.WriteLine("{0} attack {1}", ((Role)sender).NAME, e.target.NAME);

                };

                role.DamageEvent += (sender, e) =>
                {
                    Role attacked = (Role)sender;
                    Console.WriteLine("{0} take {1} damage from {2},remain HP:{3}", attacked.NAME, e.damage, e.Attacker.NAME, Math.Max(attacked.HP, 0));
                };
                role.DieEvent += (sender, e) =>
                {
                    Console.WriteLine("{0} go down", ((Role)sender).NAME);
                };

            }

            foreach (Role role in player2.group)
            {
                //attack event 訂閱 
                role.AttackEvent += (sender, e) =>
                {
                    Console.WriteLine("{0} attack {1}", ((Role)sender).NAME, e.target.NAME);

                };

                role.DamageEvent += (sender, e) =>
                {
                    Role attacked = (Role)sender;
                    Console.WriteLine("{0} take {1} damage from {2},remain HP:{3}", attacked.NAME, e.damage, e.Attacker.NAME, Math.Max(attacked.HP, 0));
                };
                role.DieEvent += (sender, e) =>
                {
                    Console.WriteLine("{0} go down", ((Role)sender).NAME);
                };

            }
       
        }
    }
}
