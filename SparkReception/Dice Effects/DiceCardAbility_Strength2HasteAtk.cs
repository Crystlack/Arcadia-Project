using LOR_DiceSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoldenSparkMod.Dice_Effects
{
    public class DiceCardAbility_Strength2HasteAtk : DiceCardAbilityBase
    {
        public static string Desc = "[On Hit] Gain 1 Strength and 2 Haste next scene.";
        public override string[] Keywords => new string[] { "Strength_Keyword", "Quickness_Keyword" };

        public override void OnSucceedAttack()
        {
            base.owner.bufListDetail.AddKeywordBufByCard(KeywordBuf.Strength, 1, base.owner);
            base.owner.bufListDetail.AddKeywordBufByCard(KeywordBuf.Quickness, 2, base.owner);
        }
    }
}
