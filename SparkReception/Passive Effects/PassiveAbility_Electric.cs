using LOR_DiceSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GoldenSparkMod.Status_Effects;

namespace GoldenSparkMod.Passive_Effects
{
	public class PassiveAbility_Electric : PassiveAbilityBase
	{
		public override void OnWaveStart()
		{
			this.owner.bufListDetail.AddBuf(new BattleUnitBuf_Electrified(1));
		}
	}
}
