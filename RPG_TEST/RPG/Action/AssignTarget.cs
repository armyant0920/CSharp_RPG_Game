using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RPG_TEST.RPG.Action
{
    interface AssignTarget

        
    {        
        //實作此介面的類別需傳入可能的目標集合,並實作選出指定目標
       Role Assign(List<Role> roles);
       //by 對象範圍
       //public abstract void Cast();
       //public abstract void Cast(Role Target);
       //public abstract void Cast(List<Role> Group);
        
        
    }
}
