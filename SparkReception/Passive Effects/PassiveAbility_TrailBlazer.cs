using LOR_DiceSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoldenSparkMod.Passive_Effects
{
    public class PassiveAbility_TrailBlazer : PassiveAbilityBase
    {
		public override void OnRollDice(BattleDiceBehavior behavior)
		{
			if (behavior.card != null)
			{
				var target_speed = behavior.card.target.speedDiceResult[behavior.card.targetSlotOrder];
				if (behavior.card.speedDiceResultValue > target_speed.value || target_speed.breaked)
				{
					BattleCardTotalResult battleCardResultLog = this.owner.battleCardResultLog;
					if (battleCardResultLog != null)
					{
						battleCardResultLog.SetPassiveAbility(this);
					}
					behavior.ApplyDiceStatBonus(new DiceStatBonus
					{
						dmg = 3
					});
				}
			}
		}
	}
}
