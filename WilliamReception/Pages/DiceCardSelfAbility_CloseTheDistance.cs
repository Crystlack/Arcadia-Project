using LOR_DiceSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WilliamReception.Pages
{
    public class DiceCardSelfAbility_CloseTheDistance : DiceCardSelfAbilityBase
    {
        public static string Desc = "Speed +2 to the Speed die this page is slotted in; [On Use] Gain 2 Haste next Scene";

        public override void OnApplyCard()
        {
            var spd = owner?.speedDiceResult[card.slotOrder];
            if (spd != null)
            {
                spd.value += 2;
            }
            owner.view.speedDiceSetterUI.GetSpeedDiceByIndex(card.slotOrder).ChangeSprite(spd.faces, spd.value);
        }

        public override void OnReleaseCard()
        {
            var spd = owner?.speedDiceResult[card.slotOrder];
            if (spd != null)
            {
                spd.value -= 2;
            }
            owner.view.speedDiceSetterUI.GetSpeedDiceByIndex(card.slotOrder).ChangeSprite(spd.faces, spd.value);
        }

        public override void OnUseCard()
        {
            owner?.bufListDetail?.AddKeywordBufByCard(KeywordBuf.Quickness, 2, owner);
        }
    }
}
