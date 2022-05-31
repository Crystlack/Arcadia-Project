using LOR_DiceSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GoldenSparkMod.Status_Effects;

namespace GoldenSparkMod.Dice_Effects
{
    public class DiceCardAbility_WinLoseElectrify : DiceCardAbilityBase
    {
        public static string Desc = "[On Clash Win/Lose] Gain 1 Electrified next scene";
        public override string[] Keywords => new string[] { "Electrified" };

        public override void OnLoseParrying()
        {
            base.owner.bufListDetail.AddReadyBuf(new BattleUnitBuf_Electrified(1));
        }

        public override void OnWinParrying()
        {
            base.owner.bufListDetail.AddReadyBuf(new BattleUnitBuf_Electrified(1));
        }
    }
}
