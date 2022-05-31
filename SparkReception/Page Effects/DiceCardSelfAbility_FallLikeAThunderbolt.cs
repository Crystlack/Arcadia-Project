using LOR_DiceSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GoldenSparkMod.Status_Effects;

namespace GoldenSparkMod.Page_Effects
{
    public class DiceCardSelfAbility_FallLikeAThunderbolt : DiceCardSelfAbilityBase
    {
        
        public static string Desc = "[Combat Start] If Speed is higher than target's, gain 1 Strength this Scene, next Scene & the Scene after; [On Use] Restore Light equal to the amount of Electrified this character has";
        public override string[] Keywords => new string[] { "Strength_Keyword", "Energy_Keyword", "Electrified", "Lightning_Rush" };

        public override void OnStartBattle()
        {
            var target_speed = card.target.speedDiceResult[card.targetSlotOrder];
            if (this.card.speedDiceResultValue > target_speed.value || target_speed.breaked)
            {
                this.owner.bufListDetail.AddKeywordBufThisRoundByCard(KeywordBuf.Strength, 1, this.owner);
                this.owner.bufListDetail.AddKeywordBufByCard(KeywordBuf.Strength, 1, this.owner);
                this.owner.bufListDetail.AddKeywordBufNextNextByCard(KeywordBuf.Strength, 1, this.owner);
            }
        }

        public override void OnUseCard()
        {
            BattleUnitBuf electrified = this.owner.bufListDetail.GetActivatedBufList().Find(x => (x is BattleUnitBuf_Electrified));
            this.owner.cardSlotDetail.RecoverPlayPoint(electrified != null ? electrified.stack : 0);
        }
    }
}
