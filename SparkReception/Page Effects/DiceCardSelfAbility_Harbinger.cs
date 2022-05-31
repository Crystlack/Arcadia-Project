using LOR_DiceSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoldenSparkMod.Page_Effects
{
    public class DiceCardSelfAbility_Harbinger : DiceCardSelfAbilityBase
    {
        
        public static string Desc = "[On Use] Deal 20 damage to self; all dice on this page gain ‘[On Hit] Recover HP equal to the amount of damage dealt’";
        public override string[] Keywords => new string[] { "Blackout","Recover_Keyword" };

        public override void OnUseCard()
        {
            base.owner.TakeDamage(20, DamageType.Card_Ability, null, KeywordBuf.None);
            this.card.ApplyDiceAbility(DiceMatch.AllDice, new DiceCardAbility_elenaAreaDice());
        }
    }
}
