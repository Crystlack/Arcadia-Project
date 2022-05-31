using LOR_DiceSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HarmonyLib;

namespace GoldenSparkMod.Status_Effects
{
	public class BattleUnitBuf_Electrified : BattleUnitBuf
	{
		protected override string keywordId
		{
			get
			{
				return "Electrified";
			}
		}

		protected override string keywordIconId
		{
			get
			{
				return "Paralysis";
			}
		}

		public new string bufActivatedName
		{
			get
			{
				return "Electrified";
			}
		}

		public new string bufActivatedNameWithStack
		{
			get
			{
				if (this.stack > 0)
				{
					 return string.Format("{0} {1}", this.bufActivatedName, this.stack);
				}
				else
				{
					return this.bufActivatedName;
				}
			}
		}

		public new string bufKeywordText
		{
			get
			{
				return string.Format("{0} {1}", this.bufActivatedName, this.stack);
			}
		}
		public override void Init(BattleUnitModel owner)
		{
			base.Init(owner);
			typeof(BattleUnitBuf).GetField("_bufIcon", AccessTools.all).SetValue(this, GoldenSparkModInit.ArtWorks["Electrify"]);
			typeof(BattleUnitBuf).GetField("_iconInit", AccessTools.all).SetValue(this, true);
		}

		/*public override string bufActivatedText
		{
			get
			{
				return string.Format("For the Scene, up to {0} dice have their maximum roll value *increased by 3 when using pages.", this.stack);
			}
		}*/

		public BattleUnitBuf_Electrified(int stack = 1)
		{
			this.stack = stack;
		}

		public override void OnUseCard(BattlePlayingCardDataInUnitModel card)
		{
			card.AddDiceFace(DiceMatch.Random(this.stack), 1);
		}

		public override void OnRoundEnd()
		{
			this.Destroy();
		}
	}
}
