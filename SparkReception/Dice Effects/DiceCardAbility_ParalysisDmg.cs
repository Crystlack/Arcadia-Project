using LOR_DiceSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoldenSparkMod.Dice_Effects
{
    public class DiceCardAbility_ParalysisDmg : DiceCardAbilityBase
    {
        public static string Desc = "[On Hit] Inflict damage equal to Paralysis";
        public override string[] Keywords => new string[] { "Paralysis_Keyword" };

        public override void OnSucceedAttack(BattleUnitModel target)
        {
            if (target != null)
            {
                target.TakeDamage(base.owner.bufListDetail.GetKewordBufStack(KeywordBuf.Paralysis), DamageType.Attack, null, KeywordBuf.None);
            }
        }
    }
}
