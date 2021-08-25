using System;
using System.Collections.Generic;

using Dorc.RoleplayingSystems.Fate;

namespace Dorc.RoleplayingSystems.CoreWarrior
{

    public class Mech
    {
        public string Description { get; set; } = "";
        public int Tonnage { get; set; }
        public MechClass Class { get; set; }
        public List<string> Aspects { get; } = new();
        public List<Stunt> Stunts { get; } = new();
        public int HeatDissipation { get; set; } = 5;
        public StressBar PhysicalStress = new StressBar(5);

        public Mech()
        {
            this.Class = RoleplayingSystem.MechClassByTonnage(this.Tonnage);
        }
    }

}