﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RPG_TEST.RPG.Action
{
    class HolyLight:Skill,Target.SingleTarget
    {
        string Skill_name = "Holy Light";

        Role target;



        public HolyLight(Role caster, Role target)
        {
            this.caster = caster;
            this.target = target;
        }

        public  Role AssignTarget(List<Role> roles)
        {
            Role target = null;
            //加入檢查邏輯
            return target;

        }

        public override void Cast()
        {
            
            
            try {

                int healing = Math.Min(this.caster.STR,target.MAX_HP-target.HP);//取得caster屬性

                Console.WriteLine("Holy...heal this!");
                Console.WriteLine("healing hp:{0} ",healing);
                target.HP = Math.Min(target.HP + healing, target.MAX_HP);
                

                
            
            }catch(Exception ex){
                Console.WriteLine("cast holy light occur ex:{0}",ex.Message);

            }

            //throw new NotImplementedException();
        }
    }
}
