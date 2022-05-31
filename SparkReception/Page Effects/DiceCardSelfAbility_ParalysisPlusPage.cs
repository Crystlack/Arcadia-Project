using LOR_DiceSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoldenSparkMod.Page_Effects
{
	public class DiceCardSelfAbility_ParalysisPlusPage : DiceCardSelfAbilityBase
	{
		public static string Desc = "When inflicting Paralysis using Combat Pages this Scene, inflict 1 additional stack";
		public override string[] Keywords => new string[] { "Paralysis_Keyword" };

		public override void OnStartBattle()
		{
			base.owner.bufListDetail.AddBuf(new BattleUnitBuf_ParalysisPlusBuf());
		}
		private class BattleUnitBuf_ParalysisPlusBuf : BattleUnitBuf
		{
			public override int OnGiveKeywordBufByCard(BattleUnitBuf cardBuf, int stack, BattleUnitModel target)
			{
				if (cardBuf.bufType == KeywordBuf.Paralysis)
				{
					return 1;
				}
				else
				{
					return base.OnGiveKeywordBufByCard(cardBuf, stack, target);
				}
			}

			public override void OnRoundEnd()
			{
				this.Destroy();
			}
		}
	}
}
