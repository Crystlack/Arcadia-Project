using LOR_DiceSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WilliamReception.Pages
{
    public class DiceCardSelfAbility_EyeOfTheAllfather : DiceCardSelfAbilityBase
    {
        public static string Desc = "Costs 1 less at Emotion Level 3 or higher; [On Use] Restore 2 Light";

        public override int GetCostAdder(BattleUnitModel unit, BattleDiceCardModel self)
        {
            return unit?.emotionDetail?.EmotionLevel >= 3 ? -1 : 0;
        }

        public override void OnUseCard()
        {
            owner.cardSlotDetail.RecoverPlayPoint(2);
        }
    }
}
