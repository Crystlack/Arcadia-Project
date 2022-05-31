using LOR_DiceSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CustomMapUtility;
using GoldenSparkMod.Status_Effects;

namespace GoldenSparkMod.Passive_Effects
{
    public class PassiveAbility_RevolutionaryEGO : PassiveAbilityBase
    {
		public override void OnWaveStart()
		{
			this.owner.personalEgoDetail.AddCard(new LorId("GoldenSparkReception", 81));
		}

		public static void AddCardsEgo(BattleUnitModel target = null)
		{
			if (target.emotionDetail.EmotionLevel > 0)
			{
				target.personalEgoDetail.AddCard(new LorId("GoldenSparkReception", 82));
				target.personalEgoDetail.AddCard(new LorId("GoldenSparkReception", 84));
			}
			target.personalEgoDetail.AddCard(new LorId("GoldenSparkReception", 83));
		}

		public static void AddGolden(int stack = 0, BattleUnitModel target = null)
		{
			if (target != null && !target.IsDead())
			{
				target.bufListDetail.AddBuf(new BattleUnitBuf_Golden_Spark(stack));
				target.breakDetail.ResetGauge();
				target.breakDetail.RecoverBreakLife(1, true);
				foreach (BattleUnitModel battleUnitModel in BattleObjectManager.instance.GetAliveList(false).Where((BattleUnitModel unit) => unit != target))
				{
					battleUnitModel.bufListDetail.AddKeywordBufThisRoundByEtc(KeywordBuf.Stun, 1, null);
				}
			}
		}

		public override void OnLevelUpEmotion()
		{
			if (this.owner.emotionDetail.EmotionLevel == 1)
			{
				this.owner.personalEgoDetail.AddCard(new LorId("GoldenSparkReception", 82));
				this.owner.personalEgoDetail.AddCard(new LorId("GoldenSparkReception", 84));
			}
			
		}

		/*private bool _egoCheck = false;

		private bool _activated = false;*/

		public class BattleUnitBuf_SparkEGO : BattleUnitBuf
        {
            public override void OnRoundStart()
			{
				
				this._owner.personalEgoDetail.AddCard(new LorId("GoldenSparkReception", 83));

				this._owner.view.ChangeSkin("GoldenSparkEGO");
				this._owner.breakDetail.ResetGauge();
				foreach (BattleDiceCardModel battleDiceCardModel in this._owner.personalEgoDetail.GetHand().ToList<BattleDiceCardModel>())
				{
					this._owner.personalEgoDetail.RemoveCard(battleDiceCardModel.GetID());
				}
				AddCardsEgo(this._owner);
				AddGolden(5, this._owner);
				CustomMapHandler.StartEnemyTheme("RollerMobster.wav", true);
				CustomMapHandler.EnforceTheme();
				this.Destroy();
			}
        }
	}
}
