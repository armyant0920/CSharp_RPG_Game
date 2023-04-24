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


        public Role() { SetSubscription(); }
        public Role(string name) { this.NAME = name; SetSubscription(); }

        public Role(string name, int hp, int str, int def,int spd)
        {
            this.NAME = name;
            this.MAX_HP = hp;
            this.HP = hp;            
            this.STR = str;
            this.DEF = def;
            this.SPEED = spd;            
            this._STATE = STATE.NONE;//
            SetSubscription();
        }

        private void SetSubscription() {
            skills = new List<Skill>();
            AttackEvent += new EventHandler<AttackEventArgs>(Role_AttackEvent);
            DieEvent += new EventHandler<DieEventArgs>(Role_DieEvent);
            DamageEvent += new EventHandler<DamageEventArgs>(Role_DamageEvent);
        
        }

        void Role_DamageEvent(object sender, DamageEventArgs e)
        {

            Console.WriteLine("{0} take {1} damage from {2}",this.NAME,e.damage,e.Attacker.NAME);//
            //if this damage>current HP,trigger DieEvent
            this.HP = Math.Max(this.HP - e.damage, 0);
            if (HP <= 0)
            {
                this.HP = 0;
                this._STATE = STATE.DEAD;

                DieEvent.Invoke(this, new DieEventArgs());

            }
                //throw new NotImplementedException();
        }

        void Role_AttackEvent(object sender, AttackEventArgs e)
        {
            Console.WriteLine("{0} attack {1}",((Role)sender).NAME,e.target.NAME);
            //throw new NotImplementedException();
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


        public int Damaged(Role damage_source,int damage) {


            //check this unit's abaility to determine actual damage
            int actualDamage = Math.Max(damage - DEF, 1);


            //HP -= actualDamage;
          
            DamageEvent.Invoke(this, new DamageEventArgs(damage_source,this,actualDamage));
            //if (HP <= 0)
            //{
            //    this.HP = 0;
            //    this._STATE = STATE.DEAD;
             
            //    DieEvent.Invoke(this, new DieEventArgs());

            //}

            return actualDamage;
        }

        void Role_DieEvent(object sender, DieEventArgs e)
        {
            Console.WriteLine("{0} fallen",((Role)sender).NAME);
            //throw new NotImplementedException();
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

        public void LearnSkill(Skill skill) {
            //if unit already learn this skill,do not add to skill_list
            if (this.skills.Exists(x => x.Skill_Name == skill.Skill_Name)) {
                Console.WriteLine("{0} already has skill: {1}", this.NAME, skill.Skill_Name);
                return;
            }

            skills.Add(skill);
            Console.WriteLine("{0} learned {1}",this.NAME,skill.Skill_Name);
            
        
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
