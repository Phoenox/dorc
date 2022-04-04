using System;
using System.Collections.Generic;

using Dorc.RoleplayingSystems.Fate;
using Microsoft.Extensions.DependencyInjection;
using MudBlazor.Extensions;

namespace Dorc.RoleplayingSystems.CoreWarrior
{
	public class Mech
	{
		public string Description { get; set; } = "";
		private int _tonnage = 50;

		public int Tonnage
		{
			get => _tonnage; 
			set => this.SetTonnage(value);
		}

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
			this.Class = ClassFromTonnage(this.Tonnage);
		}

		private void SetTonnage(int tons)
		{
			this._tonnage = tons;
			this.Class = ClassFromTonnage(tons);
		}
		
		private void SetClass(MechClass clazz)
		{
			this._class = clazz;
			if (clazz != MechClass.Other)
			{
				UpdateStressBarToFitClass();
			}
		}

		private void UpdateStressBarToFitClass()
		{
			var newCapacity = 2 + (int) this.Class;
			this.PhysicalStress = new StressBar(this.PhysicalStress, newCapacity);
		}
		
		private MechClass ClassFromTonnage(int tons)
		{
			return RoleplayingSystem.MechClassByTonnage(tons);
		}
	}

}