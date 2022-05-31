using LOR_DiceSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoldenSparkMod.Dice_Effects
{
    public class DiceCardAbility_ParalysisFragile : DiceCardAbilityBase
    {
        public static string Desc = "[On Hit] If target has Paralysis, inflict Fragile equal to the amount of Paralysis on target";
        public override string[] Keywords => new string[] { "Paralysis_Keyword", "Vulnerable_Keyword" };

        public override void OnSucceedAttack(BattleUnitModel target)
        {
            if (target != null)
            {
                target.bufListDetail.AddKeywordBufByEtc(KeywordBuf.Vulnerable, base.owner.bufListDetail.GetKewordBufStack(KeywordBuf.Paralysis), null);
            }
        }
    }
}
