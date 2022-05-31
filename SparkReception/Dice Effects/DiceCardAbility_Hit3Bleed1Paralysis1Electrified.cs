using LOR_DiceSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GoldenSparkMod.Status_Effects;

namespace GoldenSparkMod.Dice_Effects
{
    public class DiceCardAbility_Hit3Bleed1Paralysis1Electrified : DiceCardAbilityBase
    {
        public static string Desc = "[On Hit] Inflict 3 Bleed and 1 Paralysis next Scene; gain 1 Electrified next Scene";
        public override string[] Keywords => new string[] { "Bleeding_Keyword", "Paralysis_Keyword", "Electrified" };

        public override void OnSucceedAttack(BattleUnitModel target)
        {
            base.owner.bufListDetail.AddReadyBuf(new BattleUnitBuf_Electrified(1));
            target.bufListDetail.AddKeywordBufByCard(KeywordBuf.Bleeding, 3, base.owner);
            target.bufListDetail.AddKeywordBufByCard(KeywordBuf.Paralysis, 1, base.owner);
        }
    }
}
