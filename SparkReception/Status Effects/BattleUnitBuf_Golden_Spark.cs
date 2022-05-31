using HarmonyLib;
using LOR_DiceSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoldenSparkMod.Status_Effects
{
    public class BattleUnitBuf_Golden_Spark : BattleUnitBuf
    {
        //public static string Desc = "Immobilize all enemies every 5 scenes. Increase the minimum and maximum amount of all dice equal to the number of stacks.";
        public int counter = 0;
        public override BufPositiveType positiveType
        {
            get
            {
                return BufPositiveType.Positive;
            }
        }

        protected override string keywordId
        {
            get
            {
                return "Golden_Spark";
            }
        }

        public new string bufActivatedName
        {
            get
            {
                return "Golden_Spark";
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

        public override string bufActivatedText
        {
            get
            {
                return string.Format("Immobilize half of the enemies (rounded up) every 5 scenes. Increase the maximum roll amount of all dice by {0}. Upon losing 3 clashes, take 10 Stagger damage.", this.stack);
            }
        }

        public BattleUnitBuf_Golden_Spark(int stack = 0)
        {
            this.stack = stack;
        }
        public override void OnRoundStart()
        {
            this.stack++;
            if (this.stack >= 5)
            {
                this.stack = 0;
                this._owner.bufListDetail.AddReadyReadyBuf((BattleUnitBuf) new BattleUnitBuf_costAllDown());
                var enemies = BattleObjectManager.instance.GetAliveListExceptFaction(this._owner.faction);
                int count = 0;
                switch (enemies.Count)
                {
                    case 5:
                        count = 3;
                        break;
                    case 4:
                    case 3:
                        count = 2;
                        break;
                    case 2:
                        count = 1;
                        break;
                    default:
                        count = 0;
                        break;
                }
                foreach (BattleUnitModel battleUnitModel in enemies.OrderBy(x => RandomUtil.valueForProb).Take(count))
                {
                    battleUnitModel.bufListDetail.AddKeywordBufThisRoundByEtc(KeywordBuf.Stun, 1, battleUnitModel);
                }
            }
        }
        public override void OnLoseParrying(BattleDiceBehavior behavior)
        {
            counter++;
            if (counter >= 3)
            {
                counter = 0;
                this._owner.TakeBreakDamage(10, DamageType.Card_Ability, this._owner);
            }
        }
        
        public override void Init(BattleUnitModel owner)
        {
            base.Init(owner);
            typeof(BattleUnitBuf).GetField("_bufIcon", AccessTools.all).SetValue(this, GoldenSparkModInit.ArtWorks["Silhouette"]);
            typeof(BattleUnitBuf).GetField("_iconInit", AccessTools.all).SetValue(this, true);
            this.stack = 0;
        }

        public override void BeforeRollDice(BattleDiceBehavior behavior)
        {
            behavior.ApplyDiceStatBonus(new DiceStatBonus
            {
                max = 1
            });
        }
        public class BattleUnitBuf_costAllDown : BattleUnitBuf
        {
            public override int GetCardCostAdder(BattleDiceCardModel card) => -2;

            public override void OnRoundEnd() => this.Destroy(); 
        }
    }
}
