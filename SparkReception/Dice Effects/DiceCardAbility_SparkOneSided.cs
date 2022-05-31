using LOR_DiceSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoldenSparkMod.Dice_Effects
{
    public class DiceCardAbility_SparkOneSided : DiceCardAbilityBase
    {
		public static string Desc = "[On Hit] Inflict 3 Paralysis next Scene if the attack was one-sided.";
		public override string[] Keywords => new string[] { "Paralysis_Keyword" };

		public override void OnSucceedAttack(BattleUnitModel target)
		{
			bool flag = !this.behavior.IsParrying();
			if (flag)
			{
				target.bufListDetail.AddKeywordBufByCard(KeywordBuf.Paralysis, 3, base.owner);
			}
		}
	}
}
