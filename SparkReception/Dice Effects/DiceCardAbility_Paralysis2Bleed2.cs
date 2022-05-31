using LOR_DiceSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoldenSparkMod.Dice_Effects
{
    public class DiceCardAbility_Paralysis2Bleed2 : DiceCardAbilityBase
    {
        public static string Desc = "[On Hit] Inflict 2 Pralysis and 2 Bleed next scene";
        public override string[] Keywords => new string[] { "Paralysis_Keyword", "Bleeding_Keyword" };

        public override void OnSucceedAttack(BattleUnitModel target)
        {
            target.bufListDetail.AddKeywordBufByCard(KeywordBuf.Paralysis, 2, base.owner);
            target.bufListDetail.AddKeywordBufByCard(KeywordBuf.Bleeding, 2, base.owner);
        }
    }
}
