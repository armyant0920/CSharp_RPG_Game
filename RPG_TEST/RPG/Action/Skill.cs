using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RPG_TEST.RPG.Action
{
     class Skill
    {


       public  enum USEAGE
        {
            ALLY,
            ENEMY,
            NONE,
            ALL        
        }

        enum RANGE { 
            SINGLE,
            GROUP                
        }

        public string Skill_Name;
        public int Skill_CD;
        public Role Skill_Caster;
        public USEAGE[] Skill_Useage;
        public string Skill_Desc;
        public Role Skill_Target;
        public int priority;


        public Skill() { }
        public Skill(string name,string desc,USEAGE[] useage) { }

        //設定優先度
        public virtual void SetPriority() { }


        public virtual void Cast() { }

        public virtual void DoAction(){
            Console.Write("{0}",Skill_Caster.NAME);
        }
        //public abstract void Cast(Role Target);
        //public abstract void Cast(List<Role> Group);

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(string.Format("{0}\n{1}",Skill_Name,Skill_Desc));

            return sb.ToString();
        }

        public bool CheckAvailable() {
            bool available = false;

            
            //no target check
            if(!Skill_Useage.Contains(USEAGE.NONE) && this.Skill_Target==null){
                return false;
     
            }
            //ally 
            if (Skill_Useage.Contains(USEAGE.ALLY)) {
                if (Skill_Target.GetOwner().Player_Name != Skill_Caster.GetOwner().Player_Name) {
                    throw new ArgumentException("target is not ally");
                }    
            }



            return available;
        }

    }
}
