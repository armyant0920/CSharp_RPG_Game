using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using RPG_TEST.RPG.Action;
using RPG_TEST.RPG.Event;

namespace RPG_TEST.RPG
{
    class Role
    {
        public int level = 1;//default level
        public string NAME;
        public int HP;//{get;set;}
        public int MAX_HP;
        //public int SP;
        //public int MAX_SP;
        public int STR;// { get; set; }
        public int DEF;//{get;set;}
        public int SPEED;
        public Player.Player Owner;
        public List<Skill> skills;//provide 
        
        public STATE _STATE;
        
        public void Set_State(STATE state){
            this._STATE=state;
        }
        public enum STATE { 
            NONE,
            DEAD,
            SLEEP,
            POISION,
            FREEZE        
        }


        public Role() { }
        public Role(string name){this.NAME=name;}

        public Role(string name, int hp, int str, int def,int spd)
        {
            this.NAME = name;
            this.MAX_HP = hp;
            this.HP = hp;            
            this.STR = str;
            this.DEF = def;
            this.SPEED = spd;            
            this._STATE = STATE.NONE;//
        }

        public void Cast(Role target) {
            //if (skill is SingleTarget) {                        
            //}
            
        }


        public void Cast(Skill skill) { 
        
            //if is a single_target_skill
            //do..
            if (skill is SingleTarget) {
                SingleTarget_Action(skill);
            }


        }

        public void SingleTarget_Action(Skill skill){
            SingleTarget spell = (SingleTarget)skill;
            //Role target = spell.Assign();
        }

        


        public void Attack(Role target) { 
            //觸發attack事件
            AttackEvent.Invoke(this, new AttackEventArgs(target));
            int attackDamage = STR;
            int actualDamage = target.Damaged(this, attackDamage);
        }


        public int Damaged(Role attacker,int damage) {
            int actualDamage = Math.Max(damage - DEF, 1);
            HP -= actualDamage;
          
            DamageEvent.Invoke(this, new DamageEventArgs(attacker,this,actualDamage));
            if (HP <= 0)
            {
                this.HP = 0;
                this._STATE = STATE.DEAD;
                DieEvent.Invoke(this, new DieEventArgs());

            }

            return actualDamage;
        }
        public event EventHandler<AttackEventArgs> AttackEvent;
        public event EventHandler<DamageEventArgs> DamageEvent;
        public event EventHandler<CastEventArgs> CastEvent;
        public event EventHandler<DieEventArgs> DieEvent;

        /// <summary>
        /// 負責印出List內的資訊並回傳List
        /// </summary>
        /// <returns></returns>
        public List<Skill> ShowSkills() {

            
            List<Skill> temp;
            if (skills.Count < 1)
            {
                //if role not learn any skill yet,return basic order
                temp = new List<Skill>();
                string[] param = new string[] { "" };


                Skill attack = new Skill("Attack", "A basic action only occur if role has no skill", new Skill.USEAGE[] { Skill.USEAGE.ENEMY });
                temp.Add(attack);

            }
            else {
                temp = skills;
            }

            //if skills is not null
            
          
            for (int i = 0; i < temp.Count; i++)
            {
                Console.WriteLine(temp[i]);
                Console.WriteLine("key:{0}", i);
            }
            

            return temp;
        }

        public Player.Player GetOwner() {

            return this.Owner;
        }
 

        public Skill SelectSkill() {
            Skill skill = null;
       


            return skill;
        }

        public override string ToString()
        {
         
            StringBuilder sb = new StringBuilder();
            

            //foreach (PropertyInfo prop in this.GetType().GetProperties())
            //{
               
            //    sb.Append(string.Format("{0}:{1}\t", prop.Name, prop.GetValue(this, null)));

            //}

            foreach (FieldInfo field in this.GetType().GetFields())
            {
                sb.Append(string.Format("{0}:{1}\t", field.Name, field.GetValue(this)));
            }
            
            return sb.ToString();
        
        }

    
    }

}
