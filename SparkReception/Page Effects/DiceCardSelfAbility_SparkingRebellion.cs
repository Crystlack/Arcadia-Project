using LOR_DiceSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoldenSparkMod.Page_Effects
{
    public class DiceCardSelfAbility_SparkingRebellion : DiceCardSelfAbilityBase
    {
        public static string Desc = "[On Use] If Speed is higher than target's, add a Single-Use copy of 'A Spark of Rebellion' to all other allies' hands";

		public override void OnUseCard()
		{
			var target_speed = card.target.speedDiceResult[card.targetSlotOrder];
			if (this.card.speedDiceResultValue > target_speed.value || target_speed.breaked)
			{
				foreach (BattleUnitModel battleUnitModel in BattleObjectManager.instance.GetAliveList(base.owner.faction))
				{
					if (battleUnitModel != base.owner)
					{
						battleUnitModel.allyCardDetail.AddNewCard(new LorId("GoldenSparkReception", 4), false);
					}
				}
			}
		}
	}
}
