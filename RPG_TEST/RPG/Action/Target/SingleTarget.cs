using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RPG_TEST.RPG.Action.Target
{
    interface SingleTarget
    {
        Role AssignTarget(List<Role>roles);
    }
}
