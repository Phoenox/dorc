using System.Collections.Generic;

using Dorc.RoleplayingSystems.Fate;

namespace Dorc.RoleplayingSystems.CoreWarrior
{

    public class Character : Dorc.RoleplayingSystems.Fate.Core.Character
    {

        public List<Stunt> MechStunts = new();
        public Mech Mech = new();

    }

}