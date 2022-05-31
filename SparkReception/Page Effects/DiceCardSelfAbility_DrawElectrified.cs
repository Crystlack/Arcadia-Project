using LOR_DiceSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GoldenSparkMod.Status_Effects;

namespace GoldenSparkMod.Page_Effects
{
    public class DiceCardSelfAbility_DrawElectrified : DiceCardSelfAbilityBase
    {
        
        public static string Desc = "[On Use] Draw 2 pages. If user has 3 or more electrified, draw an additional page";
        public override string[] Keywords => new string[] { "Thunder_Dancer", "Electrified", "DrawCard_Keyword" };

        public override void OnUseCard()
        {            
            if (this.owner.bufListDetail.GetActivatedBufList().Find(buf => (buf is BattleUnitBuf_Electrified)).stack >= 3)
            {
                this.owner.allyCardDetail.DrawCards(3);
                return;
            }
            this.owner.allyCardDetail.DrawCards(2);
        }
    }
}
