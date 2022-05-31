using LOR_DiceSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoldenSparkMod.Passive_Effects
{
    public class PassiveAbility_Feedback : PassiveAbilityBase
    {
		public override void OnStartBattle()
		{
			DiceBehaviour diceBehaviour = new DiceBehaviour
			{
				Min = 3,
				Dice = 9,
				Type = BehaviourType.Standby,
				Detail = BehaviourDetail.Penetrate,
				EffectRes = "Nemo_Z"
			};
			DiceCardXmlInfo cardInfo = new DiceCardXmlInfo(new LorId(-1))
			{
				Artwork = "Basic1",
				Rarity = Rarity.Special,
				DiceBehaviourList = new List<DiceBehaviour>
				{
					diceBehaviour
				},
				Chapter = 1,
				Priority = 0,
				isError = true
			};
			BattleDiceBehavior battleDiceBehavior = new BattleDiceBehavior();
			battleDiceBehavior.behaviourInCard = diceBehaviour.Copy();
			battleDiceBehavior.SetIndex(0);
			this.owner.cardSlotDetail.keepCard.AddBehaviours(cardInfo, new List<BattleDiceBehavior>
			{
				battleDiceBehavior
			});
		}
	}
}
