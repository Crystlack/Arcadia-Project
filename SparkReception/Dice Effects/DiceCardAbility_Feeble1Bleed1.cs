using LOR_DiceSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoldenSparkMod.Dice_Effects
{
    public class DiceCardAbility_Feeble1Bleed1 : DiceCardAbilityBase
    {
        public static string Desc = "[On Hit] Inflict 1 Feeble and 1 Bleed next scene";
        public override string[] Keywords => new string[] { "Bleeding_Keyword", "Weak_Keyword" };

        public override void OnSucceedAttack(BattleUnitModel target)
        {
            target.bufListDetail.AddKeywordBufByCard(KeywordBuf.Bleeding, 1, base.owner);
            target.bufListDetail.AddKeywordBufByCard(KeywordBuf.Weak, 1, base.owner);
        }
    }
}
