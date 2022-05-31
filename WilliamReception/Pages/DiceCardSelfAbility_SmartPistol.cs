using LOR_DiceSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WilliamReception.Pages
{
    public class DiceCardSelfAbility_SmartPistol : DiceCardSelfAbilityBase
    {
        public static string Desc = "Dice on this page and the page clashing with it are unaffected by Power gain or loss; [On Use] Restore 1 Light and draw 1 page";

        public override void OnUseCard()
        {
            card.ignorePower = true;
            owner.cardSlotDetail.RecoverPlayPoint(1);
            owner.allyCardDetail.DrawCards(1);
        }

        public override void OnStartParrying()
        {
            var target = card?.target?.currentDiceAction;
            if (target != null)
            {
                target.ignorePower = true;
            }
        }
    }
}
