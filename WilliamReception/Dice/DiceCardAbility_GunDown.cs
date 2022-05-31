using LOR_DiceSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WilliamReception.Dice
{
    public class DiceCardAbility_GunDown : DiceCardAbilityBase
    {
        public static string Desc = "[On Hit] Draw 1 Page; Inflict 1 Bleed next Scene";

        public override void OnSucceedAttack(BattleUnitModel target)
        {
            owner.allyCardDetail.DrawCards(1);
            target?.bufListDetail?.AddKeywordBufByCard(KeywordBuf.Bleeding, 1, owner);
        }
    }
}
