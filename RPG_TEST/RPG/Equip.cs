using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RPG_TEST.RPG
{
    abstract class Equip
    {
        public string Equip_name;
        public int Price;
        enum Category { 
            Head,
            Hand,
            Body,
            Shield,
            Foot,
            Accessories
        }
        //使用
        //概念應該會是創建很多子類道具,實作各自技能
        //角色透過

        public  void Skill() { 

        }
    }
}
