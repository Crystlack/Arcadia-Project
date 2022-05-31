using LOR_DiceSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoldenSparkMod.Dice_Effects
{
    public class DiceCardAbility_NextDice2Power : DiceCardAbilityBase
    {
        public static string Desc = "[On Hit] Add +2 Power to next die";

        public override void OnSucceedAttack()
        {
            this.card.ApplyDiceStatBonus(DiceMatch.NextDice, new DiceStatBonus
            {
                power = 2
            });
        }
    }
}
