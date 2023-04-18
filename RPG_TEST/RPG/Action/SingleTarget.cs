using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RPG_TEST.RPG.Action
{
    class SingleTarget:Skill,AssignTarget//Single target parent skill 

    {
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
                Console.WriteLine("{0} cast {1} to {2}",this.caster.NAME,this.Skill_Name,target);
                
               }catch(Exception ex){

                   Console.WriteLine("cast spell {0} occur ex:{1}",this.Skill_Name,ex.Message);
               
               
               }

           }
           else {
               throw new ArgumentNullException("empty target exception");
            
           }
           
           
       }


       public virtual void Assign(Role target)
       {
           this.target = target;
       }



    }
}
