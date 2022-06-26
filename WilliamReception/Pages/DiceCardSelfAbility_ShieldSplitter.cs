using LOR_DiceSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WilliamReception.Pages
{
    public class DiceCardSelfAbility_ShieldSplitter : DiceCardSelfAbilityBase
    {
        public static string Desc = "Costs 1 less at Emotion Level 3 or higher; All Offensive dice of this page gain '[On Hit] Restore 1 Light'";

        public override int GetCostAdder(BattleUnitModel unit, BattleDiceCardModel self)
        {
            return unit.emotionDetail.EmotionLevel >= 3 ? -1 : 0;
        }

        public override void OnStartBattle()
        {
            card.ApplyDiceAbility(DiceMatch.AllAttackDice, new DiceCardAbility_Hit1Light());
        }

        private class DiceCardAbility_Hit1Light : DiceCardAbilityBase
        {
            public override void OnSucceedAttack()
            {
                owner.cardSlotDetail.RecoverPlayPoint(1);
            }
        }
    }
}
