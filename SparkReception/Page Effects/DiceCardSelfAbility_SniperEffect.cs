using GoldenSparkMod.Dice_Effects;
using LOR_DiceSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoldenSparkMod.Page_Effects
{
    public class DiceCardSelfAbility_SniperEffect : DiceCardSelfAbilityBase
    {
		
		public static string Desc = "[On Use] If Speed is higher than target's, dice on this page gain +2 Power and ‘[On Hit] Inflict 1 Feeble and Bleed this Scene’";
		public override string[] Keywords => new string[] { "Thunder_Dancer", "Weak_Keyword", "Bleeding_Keyword" };


		public override void OnUseCard()
		{
			var target_speed = card.target.speedDiceResult[card.targetSlotOrder];
			if (this.card.speedDiceResultValue > target_speed.value || target_speed.breaked)
			{
				this.card.ApplyDiceAbility(DiceMatch.AllDice, new DiceCardAbility_Feeble1Bleed1());
				this.card.ApplyDiceStatBonus(DiceMatch.AllDice, new DiceStatBonus
				{
					power = 2
				});
			}
		}
	}
}
