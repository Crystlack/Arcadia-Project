using LOR_DiceSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoldenSparkMod.Dice_Effects
{
    public class DiceCardAbility_ParalysisHeal : DiceCardAbilityBase
    {
        public static string Desc = "[On Hit] Recover HP equal to Paralysis";
        public override string[] Keywords => new string[] { "Paralysis_Keyword", "Recover_Keyword" };

        public override void OnSucceedAttack()
        {
            if (this.card.target != null)
            {
                base.owner.RecoverHP(base.owner.bufListDetail.GetKewordBufStack(KeywordBuf.Paralysis));
            }
        }
    }
}
