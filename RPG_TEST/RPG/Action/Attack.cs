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

        public Attack() { }
        
        public Attack(Role attacker, Role attacked)
        {
            this.Skill_Caster = attacker;
            this.Skill_Target = attacked;
       
        }

        public override void SetPriority()
        {
            base.SetPriority();
            this.priority = Skill_Caster.SPEED;
        }

        public override void DoAction()
        {
            base.DoAction();
            Console.Write("向{0} 使用了 {1}\n",Skill_Target.NAME,Skill_Name);
            Damage = Skill_Caster.STR;
            
            //Damage = Math.Max(Damage - Skill_Target.DEF, 1);

            Skill_Target.Damaged(Skill_Caster, Damage);
            
        }

        public override string HintText()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(string.Format(" NAME:{0}\n DESC:{1}\n USEAGE:{2}\n CD:{3}", Skill_Name, Skill_Desc, string.Join(",",Skill_Useage.Select(s=>Enum.GetName(typeof(USEAGE),s))), Skill_CD));

            return sb.ToString();
        }


    }
}