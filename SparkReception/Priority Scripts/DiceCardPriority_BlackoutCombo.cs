using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LOR_DiceSystem;

namespace GoldenSparkMod.Priority_Scripts
{
    public class DiceCardPriority_BlackoutCombo : DiceCardPriorityBase
    {
        public override int GetPriorityBonus(BattleUnitModel owner)
        {
            var hand = owner.allyCardDetail.GetHand().Select(x => x.GetID());
            return hand.Contains(new LorId("GoldenSparkReception", 5)) &&
                hand.Contains(new LorId("GoldenSparkReception", 7)) &&
                owner.cardSlotDetail.PlayPoint >= 5 ? 100 : 0;
        }
    }
}
