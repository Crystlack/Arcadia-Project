using LOR_DiceSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WilliamReception.Dice
{
    public class DiceCardAbility_Breach : DiceCardAbilityBase
    {
        public static string Desc = "Reduce Power of target's current Defensive die by 5";

		public override void BeforeRollDice()
		{
			if (behavior.TargetDice != null)
			{
				BattleDiceBehavior targetDice = behavior.TargetDice;
				if (IsDefenseDice(targetDice.Detail))
				{
					targetDice.ApplyDiceStatBonus(new DiceStatBonus
					{
						power = -5
					});
				}
			}
		}
	}
}
