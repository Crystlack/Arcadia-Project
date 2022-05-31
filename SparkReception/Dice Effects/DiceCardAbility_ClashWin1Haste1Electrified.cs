using LOR_DiceSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GoldenSparkMod.Status_Effects;

namespace GoldenSparkMod.Dice_Effects
{
    public class DiceCardAbility_ClashWin1Haste1Electrified : DiceCardAbilityBase
    {
        public static string Desc = "[On Clash Win] Gain 1 Haste and Electrified next scene";
        public override string[] Keywords => new string[] { "Quickness_Keyword", "Electrified" };
        public override void OnWinParrying()
        {
            base.owner.bufListDetail.AddKeywordBufByCard(KeywordBuf.Quickness, 1, base.owner);
            base.owner.bufListDetail.AddReadyBuf(new BattleUnitBuf_Electrified(1));
        }
    }
}
