using LOR_DiceSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoldenSparkMod.Dice_Effects
{
    public class DiceCardAbility_draw1AtkPralysis : DiceCardAbilityBase
    {
		public static string Desc = "[On Hit] Draw 1 page, inflict 1 Pralysis next scene";
		public override string[] Keywords => new string[] { "Paralysis_Keyword", "DrawCard_Keyword" };

		public override void OnSucceedAttack(BattleUnitModel target)
		{
			base.owner.allyCardDetail.DrawCards(1);
			if (target != null)
			{
				target.bufListDetail.AddKeywordBufByCard(KeywordBuf.Paralysis, 1, base.owner);
			}
		}
	}
}
