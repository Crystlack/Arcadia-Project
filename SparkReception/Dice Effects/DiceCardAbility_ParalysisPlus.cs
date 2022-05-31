using LOR_DiceSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoldenSparkMod.Dice_Effects
{
    public class DiceCardAbility_ParalysisPlus : DiceCardAbilityBase
    {
        public static string Desc = "[On Hit] When inflicting Paralysis using Combat Pages this Scene, inflict 1 additional stack";
        public override string[] Keywords => new string[] { "Paralysis_Keyword" };

        public override void OnSucceedAttack(BattleUnitModel target)
        {
            if (target != null)
            {
                base.owner.bufListDetail.AddBuf(new BattleUnitBuf_ParalysisPlusBuf());
            }
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
        }
    }
}
