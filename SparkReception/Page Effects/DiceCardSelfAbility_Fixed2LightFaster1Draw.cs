using LOR_DiceSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoldenSparkMod.Page_Effects
{
    public class DiceCardSelfAbility_Fixed2LightFaster1Draw : DiceCardSelfAbilityBase
    {
		
		public static string Desc = "[On Use] Restore 2 Light; If speed is higher than target's, draw 2 pages";
		public override string[] Keywords => new string[] { "Energy_Keyword", "DrawCard_Keyword", "Thunder_Dancer" };

		public override bool IsFixedCost()
		{
			return true;
		}

		public override void OnUseCard()
		{
			base.owner.cardSlotDetail.RecoverPlayPoint(2);
			var target_speed = card.target.speedDiceResult[card.targetSlotOrder];
			if (card.target != null && (card.speedDiceResultValue > target_speed.value || target_speed.breaked))
			{
				base.owner.allyCardDetail.DrawCards(2);
			}
		}
	}
}
