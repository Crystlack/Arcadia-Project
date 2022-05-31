using LOR_DiceSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WilliamReception.Dice
{
    public class DiceCardAbility_OneShotKillDice : DiceCardAbilityBase
    {
        public static string Desc = "[On Clash Win] Destroy all dice on target’s page; inflict 3 Bleed, 2 Bind and 1 Paralysis next Scene";

        public override void OnWinParrying()
        {
            var target = card?.target;

            target?.currentDiceAction?.DestroyDice(DiceMatch.AllDice);
            target?.bufListDetail?.AddKeywordBufByCard(KeywordBuf.Bleeding, 3, owner);
            target?.bufListDetail?.AddKeywordBufByCard(KeywordBuf.Binding, 2, owner);
            target?.bufListDetail?.AddKeywordBufByCard(KeywordBuf.Paralysis, 1, owner);
        }
    }
}
