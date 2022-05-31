using LOR_DiceSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoldenSparkMod.Page_Effects
{
    public class DiceCardSelfAbility_GodKiller : DiceCardSelfAbilityBase
    {
        public static string Desc = "If speed is higher than target's, increase the minimum and maximum rolls of this page by 6.";

        public override void OnUseCard()
        {
            var target_speed = card.target.speedDiceResult[card.targetSlotOrder];
            if (this.card.speedDiceResultValue > target_speed.value || target_speed.breaked)
            {
                this.card.ApplyDiceStatBonus(DiceMatch.AllDice, new DiceStatBonus
                {
                    min = 6,
                    max = 6
                });
            }
        }
    }
}
