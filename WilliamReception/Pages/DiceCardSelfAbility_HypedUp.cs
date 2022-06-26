using LOR_DiceSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WilliamReception.Pages
{
    public class DiceCardSelfAbility_HypedUp : DiceCardSelfAbilityBase
    {
        public static string Desc = "[On Use] Restore 1 Light; Draw 1 page; Gain 1 Strength next Scene";

        public override void OnUseCard()
        {
            owner?.cardSlotDetail?.RecoverPlayPoint(1);
            owner?.allyCardDetail?.DrawCards(1);
            owner?.bufListDetail?.AddKeywordBufByCard(KeywordBuf.Strength, 1, owner);
        }
    }
}
