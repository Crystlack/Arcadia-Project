using LOR_DiceSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GoldenSparkMod.Status_Effects;

namespace GoldenSparkMod.Passive_Effects
{
    public class PassiveAbility_GoldenSpark : PassiveAbilityBase
    {
        public override void OnWaveStart()
        {
            this.owner.bufListDetail.AddBuf(new BattleUnitBuf_combo());
        }
		public override void OnRoundStartAfter()
		{
			BattleUnitBuf activatedBuf = this.owner.bufListDetail.GetActivatedBuf(KeywordBuf.Paralysis);
			if (activatedBuf != null)
			{
				this.owner.bufListDetail.AddBuf(new BattleUnitBuf_Electrified(activatedBuf.stack));
				this.owner.bufListDetail.RemoveBuf(activatedBuf);
			}
		}
	}
}
