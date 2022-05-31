using LOR_DiceSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WilliamReception.Dice
{
    public class DiceCardAbility_DivineRightToLife : DiceCardAbilityBase
    {
        public static string Desc = "Power affects this die x2; [On Clash Win] Destroy all of opponent's dice";

        public override bool IsDoublePower()
        {
            return true;
        }

        public override void OnWinParrying()
        {
            card?.target?.currentDiceAction?.DestroyDice(DiceMatch.AllDice);
        }
    }
}
