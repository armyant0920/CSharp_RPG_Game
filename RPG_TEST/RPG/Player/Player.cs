using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RPG_TEST.RPG.Item;
namespace RPG_TEST.RPG.Player
{
    class Player
    {
         const int MAX_GROUP=3;//max member count
         const int MAX_Package = 30;//max item can be hold
        public string Player_Name;
        public int Money { get; private set; }

        List<Item.Item> Bag;

        public List<Role> group=new List<Role>();

        public Player(string name){
            this.Player_Name = name;
            Bag = new List<Item.Item>();
        
        }

        public void AddMember(Role role) {

            if (group.Count >= MAX_GROUP) {
                Console.WriteLine("Reach group size limit");
                return;
            }

            group.Add(role);
        
        }



    }
}
