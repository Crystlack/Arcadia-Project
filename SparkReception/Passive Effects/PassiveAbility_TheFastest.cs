using LOR_DiceSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoldenSparkMod.Passive_Effects
{
    public class PassiveAbility_TheFastest : PassiveAbilityBase
    {
		public override void OnAfterRollSpeedDice()
		{
			int num = 0;
			int num2 = 0;
			int index = 0;
			int num3 = 0;
			for (int i = 0; i < this.owner.speedDiceCount; i++)
			{
				SpeedDice speedDice = this.owner.speedDiceResult[i];
				bool flag = !speedDice.breaked && speedDice.value < num2;
				if (flag)
				{
					index = num;
					num3 = num2;
					num = i;
					num2 = speedDice.value;
				}
				else
				{
					bool flag2 = !speedDice.breaked && speedDice.value < num3;
					if (flag2)
					{
						index = i;
						num3 = speedDice.value;
					}
				}
			}
			this.owner.speedDiceResult[num].value = 999;
			this.owner.speedDiceResult[index].value = 999;
			this.owner.speedDiceResult.Sort(delegate (SpeedDice d1, SpeedDice d2)
			{
				bool flag3 = d1.breaked && d2.breaked;
				int result;
				if (flag3)
				{
					result = ((d1.value > d2.value) ? -1 : 1);
				}
				else
				{
					bool flag4 = d1.breaked && !d2.breaked;
					if (flag4)
					{
						result = -1;
					}
					else
					{
						bool flag5 = !d1.breaked && d2.breaked;
						if (flag5)
						{
							result = 1;
						}
						else
						{
							result = ((d1.value > d2.value) ? -1 : 1);
						}
					}
				}
				return result;
			});
		}
	}
}
