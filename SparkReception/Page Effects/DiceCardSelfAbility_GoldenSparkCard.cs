using LOR_DiceSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GoldenSparkMod.Passive_Effects;

namespace GoldenSparkMod.Page_Effects
{
    public class DiceCardSelfAbility_GoldenSparkCard : DiceCardSelfAbilityBase
    {
        public static string Desc = "Can be used at Emotion Level 4 or above. [On Use] Recover Full [Stagger Resist] and [Manifest E.G.O.] next Scene";

		public override void OnUseCard()
		{
			base.owner.breakDetail.ResetGauge();
			base.owner.breakDetail.RecoverBreakLife(1, true);
			if (this.owner.passiveDetail.HasPassive<PassiveAbility_RevolutionaryEGO>())
			{
				this.owner.bufListDetail.AddBuf(new PassiveAbility_RevolutionaryEGO.BattleUnitBuf_SparkEGO());
			}
		}
	}
}
