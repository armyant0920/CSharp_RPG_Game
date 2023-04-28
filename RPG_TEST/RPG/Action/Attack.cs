using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RPG_TEST.RPG.Action
{
    class Attack : Skill
    {
        public override string Skill_Name
        {
            get { return "Attack"; }
      
        }

        public new string Skill_Desc {
            get { return "Basic Single Target Melee Attack";}
        }
        new USEAGE[] Skill_Useage = new USEAGE[] { USEAGE.ENEMY };
        int Damage;

        public override USEAGE[] Get_USEAGE(){
            return Skill_Useage;
        }

        public Attack() { }
        
        public Attack(Role attacker, Role attacked)
        {
            this.Skill_Caster = attacker;
            this.Skill_Target = attacked;
       
        }

        public override void SetAttribute()
        {
            base.SetAttribute();
            this.priority = Skill_Caster.SPEED;
        }

        public override bool CheckAvailable()
        {
            Console.WriteLine("this is attack's check");
            switch (Skill_Caster._STATE) { 
                
                case Role.STATE.DEAD:
                    Console.WriteLine("you die,you can't do");
                    return false;
                case Role.STATE.SLEEP:
                    Console.WriteLine("Zzzz");
                    return false;
            }

            if (Skill_Target == null) {

                Console.WriteLine("No target");
                return false;
            }

            if (Skill_Target._STATE == Role.STATE.DEAD) {
                Console.WriteLine("target aleready death");
                return false;
            }

            return true;

            //return base.CheckAvailable();
        }

        public override bool DoAction()
        {

            if (!base.DoAction())
            {

                return false;

            }

            Console.Write("向{0} 使用了 {1}\n",Skill_Target.NAME,Skill_Name);
            Damage = Skill_Caster.Get_STR_All();
            
            //Damage = Math.Max(Damage - Skill_Target.DEF, 1);

            Skill_Target.Damaged(Skill_Caster, Damage);
            return true;
            
        }

        public override string HintText()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(string.Format(" NAME:{0}\n DESC:{1}\n USEAGE:{2}\n CD:{3}", Skill_Name, Skill_Desc, string.Join(",", Skill_Useage.Select(s => Enum.GetName(typeof(USEAGE), s))), Skill_CD));

            return sb.ToString();
        }


    }
}