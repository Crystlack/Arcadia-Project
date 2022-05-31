using LOR_DiceSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoldenSparkMod.Dice_Effects
{
    public class DiceCardAbility_ClashLoseExtraDice : DiceCardAbilityBase
    {
        public static string Desc = "[On Clash Lose] Gain 1 Negative Emotion Point; add a Blunt die (Roll: 13-21) ([On Hit] Recover HP equal to the amount of damage dealt) to the dice queue";
        public override string[] Keywords => new string[] { "Recover_Keyword" };

        public override void OnLoseParrying()
        {
            BattleDiceBehavior battleDiceBehavior = BattleDiceCardModel.CreatePlayingCard(ItemXmlDataList.instance.GetCardItem(new LorId("GoldenSparkReception", 14), false)).CreateDiceCardBehaviorList()[0];
            battleDiceBehavior.AddAbility(new DiceCardAbility_elenaAreaDice());
            base.card.AddDice(battleDiceBehavior);
        }
    }
}
