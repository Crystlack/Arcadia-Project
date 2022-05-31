using LOR_DiceSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoldenSparkMod.Dice_Effects
{
    public class DiceCardAbility_FallLikeAThunderbolt_ClashWinAddDice : DiceCardAbilityBase
    {
        public static string Desc = "[On Clash Win] Add a Pierce die (Roll: 10-15) ([On Hit] Inflict 5 Paralysis and 3 Bleed next Scene) to the dice queue";

        public override void OnWinParrying()
        {
            DiceBehaviour behavior = new DiceBehaviour
            {
                Min = 10,
                Dice = 15,
                Type = BehaviourType.Atk,
                Detail = BehaviourDetail.Penetrate
            };
            BattleDiceBehavior battleBehaviour = new BattleDiceBehavior();
            battleBehaviour.behaviourInCard = behavior;
            battleBehaviour.AddAbility(new DiceCardAbility_Hit5Paralysis3Bleed());
            battleBehaviour.SetIndex(0);
            this.card.AddDice(battleBehaviour);
        }

        private class DiceCardAbility_Hit5Paralysis3Bleed : DiceCardAbilityBase
        {
            public static string Desc = "[On Hit] Inflict 5 Paralysis and 3 Bleed next Scene";
            public override string[] Keywords => new string[] { "Paralysis_Keyword", "Bleeding_Keyword" };

            public override void OnSucceedAttack(BattleUnitModel target)
            {
                target.bufListDetail.AddKeywordBufByCard(KeywordBuf.Paralysis, 5, this.owner);
                target.bufListDetail.AddKeywordBufByCard(KeywordBuf.Bleeding, 3, this.owner);
            }
        }
    }
}
