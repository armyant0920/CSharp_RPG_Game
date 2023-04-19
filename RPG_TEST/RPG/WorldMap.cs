using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RPG_TEST.RPG
{
    class WorldMap
    {



        static void ShowMenu(Player.Player player) {

            Console.WriteLine("Town:T");
            Console.WriteLine("Wild:W");            
            Console.WriteLine("hint:input above code to enter");

            string input=Console.ReadKey().KeyChar.ToString();


            switch(input){
            
                case "T":
                    GotoTown();
                    break;
                case "W":
                    GotoWild(player);
                    break;
                default:
                    Console.WriteLine("Unknow input,please choose again");
                    break;    
            
            }
        
        }

        #region Town Settings

        static void GotoTown() {

            
            Console.WriteLine("welcome to small town,choose where you want to go");
            Console.WriteLine("INN:Q");
            Console.WriteLine("SHOP:A");
            Console.WriteLine("BAR:Z");
            Console.WriteLine("LEAVE:X");
            string input = Console.ReadKey().KeyChar.ToString();
            switch (input) { 
            
                case "Q":
                    GotoTown();
                    break;

                case "A":
                    GotoShop();
                    break;
                case "Z":
                    GotoBar();
                    break;
                case "X":
                    Leave();
                    break;
                default:
                    Console.WriteLine("no such option");
                    break;
            }
 
        }

        static void GotoInn() {
            Console.WriteLine("Zzz....heal all member");
            //healing team member
        }

        static void GotoShop() {
           
            Console.WriteLine("Let's shipping");
        }
        static void GotoBar() {
            Console.WriteLine("Let's drink!");
        
        }

        static void Leave() {
            Console.WriteLine();
        }

        

        #endregion





        //wild setting
        static void GotoWild(Player.Player player)
        {
            Random rnd = new Random();

            int dice = 1 + rnd.Next(100);

            if (dice < 10) Console.WriteLine("!!!!");

            if (dice > 10 && dice <50) Console.WriteLine("@@@@");

            if (dice > 50) StartFight(player);

        }

        static void StartFight(Player.Player player) { 

            //
            Battle battle = new Battle(player, RandomFight.PlayWithAI());
            
        
        }


    }
}
