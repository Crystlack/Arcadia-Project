using LOR_DiceSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GoldenSparkMod.Status_Effects;

namespace GoldenSparkMod.Dice_Effects
{
    public class DiceCardAbility_ClashLoseElectrify : DiceCardAbilityBase
    {
        public static string Desc = "[On Clash Lose] Gain 3 Electrified next Scene";
        public override string[] Keywords => new string[] { "Electrified" };

        public override void OnLoseParrying()
        {
            base.owner.bufListDetail.AddReadyBuf(new BattleUnitBuf_Electrified(3));
        }
    }
}
