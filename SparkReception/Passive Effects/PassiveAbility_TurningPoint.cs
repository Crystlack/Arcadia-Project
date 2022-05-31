using LOR_DiceSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoldenSparkMod.Passive_Effects
{
    public class PassiveAbility_TurningPoint : PassiveAbilityBase
    {
		public override void OnUseCard(BattlePlayingCardDataInUnitModel curCard)
		{
			if (curCard != null)
			{
				if ((float)(this.owner.MaxHp / 2) > this.owner.hp)
				{
					curCard.ApplyDiceStatBonus(DiceMatch.AllDice, new DiceStatBonus
					{
						power = 1
					});
				}
				var target_speed = curCard.target.speedDiceResult[curCard.targetSlotOrder];
				if (curCard.speedDiceResultValue > target_speed.value || target_speed.breaked)
				{
					curCard.ApplyDiceStatBonus(DiceMatch.AllDice, new DiceStatBonus
					{
						power = 1
					});
				}
			}
		}
	}
}
