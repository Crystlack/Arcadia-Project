using LOR_DiceSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GoldenSparkMod.Status_Effects;

namespace GoldenSparkMod.Dice_Effects
{
    public class DiceCardAbility_Electrify : DiceCardAbilityBase
    {
        public static string Desc = "Electrify";
		public override string[] Keywords => new string[] { "Electrified" };

		public override void OnWinParrying()
		{
			base.owner.bufListDetail.AddKeywordBufByCard(KeywordBuf.Quickness, 1, base.owner);
			BattleUnitBuf battleUnitBuf = base.owner.bufListDetail.GetReadyBufList().Find((BattleUnitBuf buf) => buf is BattleUnitBuf_Electrified);
			if (battleUnitBuf != null)
			{
				battleUnitBuf.stack++;
			}
			else
			{
				base.owner.bufListDetail.AddReadyBuf(new BattleUnitBuf_Electrified(1));
			}
		}
	}
}
