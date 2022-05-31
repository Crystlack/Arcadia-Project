using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LOR_DiceSystem;

namespace GoldenSparkMod.Priority_Scripts
{
    public class DiceCardPriority_ThunderDancerCombo : DiceCardPriorityBase
    {
        public override int GetPriorityBonus(BattleUnitModel owner)
        {
            var hand = owner.allyCardDetail.GetHand().Select(x => x.GetID());
            return hand.Contains(new LorId("GoldenSparkReception", 2)) &&
               hand.Contains(new LorId("GoldenSparkReception", 6)) &&
               hand.Contains(new LorId("GoldenSparkReception", 8)) &&
               owner.cardSlotDetail.PlayPoint >= 7 ? 100 : 0;
        }
    }
}
