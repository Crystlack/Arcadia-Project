using LOR_DiceSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WilliamReception.Pages
{
    public class DiceCardSelfAbility_AntiRiotTactics : DiceCardSelfAbilityBase
    {
        public static string Desc = "Costs 1 less at Emotion Level 3 or higher; [Combat Start] Gain 1 Protection and Stagger Protection this Scene";

        public override int GetCostAdder(BattleUnitModel unit, BattleDiceCardModel self)
        {
            return unit?.emotionDetail?.EmotionLevel >= 3 ? -1 : 0;
        }

        public override void OnStartBattle()
        {
            owner.bufListDetail.AddKeywordBufThisRoundByCard(KeywordBuf.Protection, 1, owner);
            owner.bufListDetail.AddKeywordBufThisRoundByCard(KeywordBuf.BreakProtection, 1, owner);
        }
    }
}
