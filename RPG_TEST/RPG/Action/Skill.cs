﻿using System;
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

        public virtual string Skill_Name{get;private set;}
        public int Skill_CD;
        public Role Skill_Caster;
        public USEAGE[] Skill_Useage;
        public string Skill_Desc{get;private set;}
        public Role Skill_Target;
        public int priority;


        public Skill() { }

        [Obsolete("This method is deprecated,All Action should Extend its property and method.")]
        public Skill(string name,string desc,USEAGE[] useage) { }
        /// <summary>
        /// set skill caster
        /// </summary>
        /// <param name="role"></param>
        public Skill(Role role) { this.Skill_Caster = role; }


        //set Action attribute
        public virtual void SetAttribute() {


            //set priority attr
            this.priority = Skill_Caster.SPEED;

            
            //
            if (this.Skill_Caster._STATE == Role.STATE.FREEZE) {
                priority /= 2;
            }
            //if user has other state,set as blow...
            
        
        }
        
        public virtual void Cast() { }

        public virtual bool DoAction(){

            if (!CheckAvailable()) {
                Console.WriteLine("can't do");
                return false;
            }

            //if (Skill_Caster._STATE == Role.STATE.DEAD) {
            //    Console.WriteLine();
            //}

            Console.Write("{0}", Skill_Caster.NAME);
            return true;
        }
        //public abstract void Cast(Role Target);
        //public abstract void Cast(List<Role> Group);
        public virtual string HintText() {
            return this.Skill_Name;
            //StringBuilder sb = new StringBuilder();
            //sb.Append(string.Format(" NAME:{0}\n DESC:{1}\n USEAGE:{2}\n CD:{3}", Skill_Name, Skill_Desc, string.Join(",", Skill_Useage.Select(s => Enum.GetName(typeof(USEAGE), s))), Skill_CD));

            //return sb.ToString();
        }

        public virtual USEAGE[] Get_USEAGE()
        {
            return Skill_Useage;
        }


        public override string ToString()
        {
            return HintText();
        }

        //public virtual void SetCaster(Role role) {
        //    this.Skill_Caster = role;
        //}
        public virtual void SetTarget(Role role){
            this.Skill_Target = role;

        }
        /// <summary>
        /// basic AutoTarget
        /// </summary>
        /// <param name="enemy_player"></param>
        /// <returns></returns>
        public virtual Role AutoTarget(Player.Player enemy_player) { 
            
            //
            Role target=null;
            Random rnd = new Random();
            //ALLY
            if (Skill_Useage.Contains(USEAGE.ALLY)) {
                List<Role> targets = Skill_Caster.Owner.group.Where(x => x._STATE != Role.STATE.DEAD).ToList();
                target = targets.ElementAt(rnd.Next(targets.Count));
                    
            }
            //ENEMY
            if (Skill_Useage.Contains(USEAGE.ENEMY))
            {
                List<Role> targets = enemy_player.group.Where(x => x._STATE != Role.STATE.DEAD).ToList();
                target = targets.ElementAt(rnd.Next(targets.Count));

            }

            return target;



        }

        public virtual bool CheckAvailable() {
            bool available = false;

            switch (Skill_Caster._STATE) { 
            
                case Role.STATE.DEAD:
                    throw new CustomException.ActionException("Caster is dead");
                    

                case Role.STATE.SLEEP:
                    throw new CustomException.ActionException("Caster fall asleep");                    
            }


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
