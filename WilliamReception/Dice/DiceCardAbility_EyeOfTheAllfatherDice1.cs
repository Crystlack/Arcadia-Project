using LOR_DiceSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WilliamReception.Dice
{
    public class DiceCardAbility_EyeOfTheAllfatherDice1 : DiceCardAbilityBase
    {
        public static string Desc = "[On Clash Win] Next die gains +4 Power";

        public override void OnWinParrying()
        {
            card.ApplyDiceStatBonus(DiceMatch.NextDice, new DiceStatBonus
            {
                power = 4
            });
        }
    }
}
