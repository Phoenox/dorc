using System;
using System.Collections.Generic;

using Dorc.RoleplayingSystems.Fate;
using Microsoft.Extensions.DependencyInjection;
using MudBlazor.Extensions;

namespace Dorc.RoleplayingSystems.CoreWarrior
{
	public class Mech
	{
		public string Name { get; set; } = "";
		public string Description { get; set; } = "";
		public string HighConcept { get; set; } = "";
		public string Trouble { get; set; } = "";
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
		public List<Equipment> Equipment { get; } = new();
		public int HeatDissipation { get; set; } = 5;
		public StressBar PhysicalStress = new StressBar("Physical", 5);

		public string Image { get; set; } = "data:image/png;base64,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mjFjhqqqqvTFF1/oypUrBX9Hof31n3/+0dKlS/Xpp58qCAJdvHgx5z6PHz9WEAQ568NjTKVSWrFihaqrq1VbW6sNGzbk7NuxB0jSCQkASWpsbNSiRYvyNueffvpJn332mW7cuKFUKqVly5ZpwYIF4e0XLlxQVVWVTpw4of/++09bt27V+PHj9eLFi0F/X2bCc/z4ce3YsUOnT58eNEAePnyodDqtdDqtt2/f5vxMQ0ODli5dqlQqpZs3b2rq1Kn68ccfw9tjCRBGVAAgHT16VAsXLtSRI0fyAmTy5Mnau3dv+HVbW5uCIFBHR4ckadWqVVq5cmV4e19fn+rq6rR//35J0pYtWzRnzpywKG9tbdUnn3yiP//8M7xPd3e3rl27piAI9Pvvv+cU8JkAefbsWcFjv337toIg0PXr18Pv7du3TxMnTgy/jixAGFEBwHtPnz7VlClTdPfu3bwAef78uYIg0N9//51zn+rqah07dkySNHv2bO3cuTPn9mXLlumHH36Q1L/nfvnll1q7dq3evHmjzz//XFu3bs07jlevXikIAp08eTJnf3748KGCINDMmTM1bdo0LV++XJcuXQrvd/z4cVVVVeU81tWrVxUEgVKplKQIAoQRFQDka2xs1O7duyUpL0Du3bunIAjU1taWc59JkybpwIEDkqQpU6Zo3759Obd/++23WrVqVfj148ePNXHiRM2dO1cNDQ3q6+vLO45MgGRGWJkJ0aVLl7Rnzx5dvnxZ165d06ZNm1RVVaXm5mZJ0qFDhzRhwoScx7p165aCINDt27cllRggjKgAYGDHjh3TvHnzwg09jg4kY/369QqCQGfPni14LB8GSLYPG4D6+npt3rxZUsQdCCMqABie77//Xh9//LFqampUU1Oj0aNHa8SIEaqpqdGZM2ck9b8H8vPPP4f36ejoyHsPpLGxMby9r69PkyZNCt8DkaRz585p9OjRWrdunWbNmqXXr1/nHctgAZKR2d/nzZunNWvWKJVKhcdz8+bN8Of2799f3HsgjKgAoDgvX77UgwcPwvXLL79ozJgxevDggdLptKT+T2FNnz5dHR0devnypb766ivNnz8/fIzz589r5MiROnXqlHp6erR9+/acT2E9efJEdXV1OnTokPr6+rR48WJ999134f3fvXundDoddjt//fWX0ul02BWdP39eFy9e1PPnz9XV1aVdu3bpo48+0tmzZ8MJU319vZYsWaIXL17o33//1YwZM7Rt27bwdxQMEEZUABCdQp/C6u3t1caNG1VTU6Pq6mp9/fXXBf8OZPr06eHfgVy+fFlSfzfS0NCg1atXhz+bSqVUV1engwcPSnr/KaoP12+//SZJ+vXXXzVr1iyNGjVKY8eOVX19vf7444+c33/r1i0tWbJEI0eO1Lhx47R+/frCfwfCiAoAUMhA+dDV1aWgpaVFTU1Nam9vV2dnp7q6ulgsFovFyludnZ1qb29XU1OTWlpa9D/ETBHkkn2aEQAAAABJRU5ErkJggg==";

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