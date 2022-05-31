using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LOR_DiceSystem;

namespace GoldenSparkMod.Priority_Scripts
{
    public class DiceCardPriority_LightningRushCombo : DiceCardPriorityBase
    {
        public override int GetPriorityBonus(BattleUnitModel owner)
        {
            var hand = owner.allyCardDetail.GetHand().Select(x => x.GetID());
            return hand.Contains(new LorId("GoldenSparkReception", 1)) &&
                hand.Contains(new LorId("GoldenSparkReception", 9)) &&
                owner.cardSlotDetail.PlayPoint >= 4 ? 100 : 0;
        }
    }
}
