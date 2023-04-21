using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RPG_TEST.RPG.Action
{
    class Attack : Skill
    {
        string Skill_name = "ATTACK";
        string Skill_Desc = "Normal attack";
        USEAGE[] Skill_Useage = new USEAGE[] { USEAGE.ENEMY };
        int Damage;
        

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
            Console.Write("向{0} 使用了 {1}",Skill_Target.NAME,Skill_Name);
            Damage = Skill_Caster.STR;
            Damage = Math.Max(Damage - Skill_Target.DEF, 1);

            Skill_Target.Damaged(Skill_Caster, Damage);
            
        }


    }
}