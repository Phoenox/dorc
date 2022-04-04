using System;
using System.Collections.Generic;

using Dorc.RoleplayingSystems.Fate;
using MudBlazor.Extensions;

namespace Dorc.RoleplayingSystems.CoreWarrior
{
	public class Mech
	{
		public string Description { get; set; } = "";
		public int Tonnage { get; set; } = 0;

		private MechClass _class;
		public MechClass Class
		{
			get => _class; 
			set => this.SetClass(value);
		}
		public List<string> Aspects { get; } = new();
		public List<Stunt> Stunts { get; } = new();
		public List<Equipment> Equipment { get; } = new();
		public int HeatDissipation { get; set; } = 5;
		public StressBar PhysicalStress = new StressBar("Physical", 5);

		public Mech()
		{
			this.Class = RoleplayingSystem.MechClassByTonnage(this.Tonnage);
		}

		private void SetClass(MechClass clazz)
		{
			this._class = clazz;
			if (clazz != MechClass.Other)
			{
				var newCapacity = 2 + clazz.As<int>();
				this.PhysicalStress = new StressBar(this.PhysicalStress, newCapacity);
			}
		}
	}

}