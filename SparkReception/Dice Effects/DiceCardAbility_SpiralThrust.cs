using LOR_DiceSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoldenSparkMod.Dice_Effects
{
    public class DiceCardAbility_SpiralThrust : DiceCardAbilityBase
    {
        public static string Desc = "[On Clash Win] Destroy all of the opponent's dice. If this die rolled max, inflict Stagger Damage equal to dice roll.";
        public override void OnWinParrying()
        {
            card?.target?.currentDiceAction?.DestroyDice(DiceMatch.AllDice);
            if (card.currentBehavior.DiceVanillaValue == card.currentBehavior.GetDiceVanillaMax())
            {
                card?.target?.TakeBreakDamage(card.currentBehavior.DiceResultValue);
            }
        }
    }
}
