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

        public int Buff_STR;
        public int Buff_DEF;
        public int Buff_SPEED;
        //try to include all attribute concept,role itself,buff effect,equip....etc count

        public Unit.Attribute ATTR;

        
        public List<Unit.Attribute> attrs;

        /// <summary>
        /// by attr_name sum all of same fieldname attr,for extend attribute easiler
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public int Get_AttrByType(string name) {

            int result = 0;

            foreach (Unit.Attribute attr in attrs) {

                foreach (FieldInfo field in attr.GetType().GetFields())
                {
                    if (field.Name.Equals(name))
                    {
                        result += (int)field.GetValue(attr);

                    }
                }
                
            }
            return result;
        }

        public void AddBuff(Buff_Base buff) {
            this.buffs.Add(buff);
        
        }

        public int Get_STR_All() {
            int STR = 0;
           //add buff attr first
            if (buffs.Count > 0) { 
                foreach(Buff_Base buff in buffs){
                    if (!attrs.Contains(buff.attr))
                        attrs.Add(buff.attr);
                }
            }


            foreach (Unit.Attribute attr in attrs)
            {
                STR += attr.STR;
            }

            return STR;
        }

     

        public int Get_BuffDEF()
        {
            int buff_def = 0;
            foreach (Buff_Base buff in buffs)
            {

                foreach (FieldInfo field in buff.GetType().GetFields())
                {
                    if (field.Name == "DEF")
                    {
                        buff_def += (int)field.GetValue(buff);

                    }
                }
            }
            return buff_def;
        }

        public int Get_BuffSTR() {

            int buff_str = 0;
            foreach (Buff_Base buff in buffs)
            {

                foreach (FieldInfo field in buff.GetType().GetFields())
                {
                    if (field.Name == "STR")
                    {
                        buff_str += (int)field.GetValue(buff);

                    }
                }
            }
            return buff_str;
        
            
        }

        public int Get_DEF_All()
        {
            return DEF + Buff_DEF;
        }

        public int Get_SPEED_All()
        {
            return SPEED + Buff_SPEED;
        }

        public Player.Player Owner;
        public Player.Player GetOwner()
        {

            return this.Owner;
        }

        public List<Skill> skills;//provide 
        public List<Buff_Base> buffs;


        public STATE _STATE;
        
        public void Set_State(STATE state){
            this._STATE=state;
        }
        public enum STATE { 
            NONE,
            DEAD,
            SLEEP,//can't move
            POISION,//every turn end take damage
            PARALYSIS,//STR/2
            FREEZE//SPD/2        
        }


        public Role() { SetSubscription(); }
        public Role(string name) { this.NAME = name; SetSubscription(); }

        public Role(string name, int hp, int str, int def,int spd)
        {
            //set attr
            this.attrs = new List<Unit.Attribute>();
            this.ATTR = new Unit.Attribute();
            attrs.Add(ATTR);
            ATTR.STR = str;
            ATTR.DEF = def;
            ATTR.SPEED = spd;
            this.buffs = new List<Buff_Base>();



            this.STR = str;
            this.DEF = def;
            this.SPEED = spd;            

            //*************

            this.NAME = name;
            this.MAX_HP = hp;
            this.HP = hp;            
            
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
            else {

            Console.WriteLine("{0} remainHP: {1}", this.NAME,this.HP);//
            
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

        /// <summary>
        /// Round End, buuf、effect、State handle
        /// </summary>
        public void RoundEndEvent() { 
            //
            if (_STATE == STATE.POISION) { 
                //take poision damage
            }
        
        }
       


        public int Damaged(Role damage_source,int damage) {

            int actualDamage = 0;

            actualDamage = damage;
            //check this unit's abaility to determine actual damage
            actualDamage = Math.Max(damage - DEF, 1);
          
            DamageEvent.Invoke(this, new DamageEventArgs(damage_source,this,actualDamage));


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

        
 

        public Skill SelectSkill() {
            Skill skill = null;
       


            return skill;
        }

        public void Recovery() {
            HP = MAX_HP;
            _STATE = STATE.NONE;
            Console.WriteLine("recovery this unit");

        }

        public bool CheckMoveAble() {
            bool result = false;

            switch (this._STATE) { 
            
                case Role.STATE.DEAD:
                    return false;
                
                case Role.STATE.SLEEP:
                    return false;
                
                default:
                    Console.WriteLine("undefined");
                    break;
            
            }


            return result;

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
                if (field.Name != "skills" )
                sb.Append(string.Format("{0}:{1}\t", field.Name, field.GetValue(this)));
            }
            
            return sb.ToString();
        
        }

    
    }

}
