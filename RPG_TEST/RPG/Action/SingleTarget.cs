using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RPG_TEST.RPG.Action
{
    class SingleTarget:Skill,AssignTarget//Single target parent skill 

    {
        enum AVAILABLE{
            ALLY,
            ENEMY                
        }

       protected Role target;


       public SingleTarget() { } 

       public SingleTarget(Role target) {
           this.target = target;
       }


       public override void Cast()
       {
           if (target != null)
           {
               try{
                Console.WriteLine("{0} cast {1} to {2}",this.Skill_Caster.NAME,this.Skill_Name,target);
                
               }catch(Exception ex){

                   Console.WriteLine("cast spell {0} occur ex:{1}",this.Skill_Name,ex.Message);
               
               
               }

           }
           else {
               throw new ArgumentNullException("empty target exception");
            
           }
           
           
       }


       public virtual Role Assign(List<Role> roles)
       {
           //this.target = target;
           Console.WriteLine("請選擇目標");

           Role target = null;

           foreach (Role role in roles) { 
            
           }


           return target;
       }



    }
}
