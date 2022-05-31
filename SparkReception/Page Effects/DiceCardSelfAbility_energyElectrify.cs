using LOR_DiceSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GoldenSparkMod.Status_Effects;

namespace GoldenSparkMod.Page_Effects
{

    public class DiceCardSelfAbility_energyElectrify : DiceCardSelfAbilityBase
    {
        
        public static string Desc = "[On Use] Restore 1 Light; Gain 2 Electrified next Scene";
        public override string[] Keywords => new string[] { "Blackout","Electrified", "Energy_Keyword" };

        public override void OnUseCard()
        {
            base.owner.cardSlotDetail.RecoverPlayPointByCard(1);
            base.owner.bufListDetail.AddReadyBuf(new BattleUnitBuf_Electrified(2));
        }
    }
}
