using LOR_DiceSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WilliamReception.Dice
{
    public class DiceCardAbility_EyeOfTheAllfatherDice2 : DiceCardAbilityBase
    {
        public static string Desc = "[On Hit] Gain 1 Strength next Scene and the Scene after";

        public override void OnSucceedAttack()
        {
            owner.bufListDetail.AddKeywordBufByCard(KeywordBuf.Strength, 1, owner);
            owner.bufListDetail.AddKeywordBufNextNextByCard(KeywordBuf.Strength, 1, owner);
        }
    }
}
