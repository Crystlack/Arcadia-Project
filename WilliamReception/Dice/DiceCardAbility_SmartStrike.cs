using LOR_DiceSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WilliamReception.Dice
{
    public class DiceCardAbility_SmartStrike : DiceCardAbilityBase
    {
        public static string Desc = "[On Clash Lose] Take no damage from losing this Clash";

        public override void OnLoseParrying()
        {
            card?.target?.currentDiceAction?.currentBehavior?.ApplyDiceStatBonus(new DiceStatBonus
            {
                dmg = -9999,
                dmgRate = -9999
            });
        }
    }
}
