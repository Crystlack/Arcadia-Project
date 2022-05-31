using LOR_DiceSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoldenSparkMod.Passive_Effects
{
    public class PassiveAbility_SpeedOfLightningEnemy : PassiveAbilityBase
    {
        public override int SpeedDiceNumAdder()
        {
            return this.owner.emotionDetail.EmotionLevel < 2 ? 2 : this.owner.emotionDetail.EmotionLevel < 4 ? 3 : 4;
        }

        public override void OnRollSpeedDice()
        {
            foreach (SpeedDice speedDice in this.owner.speedDiceResult.FindAll(x => !x.breaked).OrderBy(x => x.value).Take(2))
            {
                speedDice.value = 999;
            }
            this.owner.speedDiceResult = this.owner.speedDiceResult.OrderBy(x => x.breaked).OrderByDescending(x => x.value).ToList();
        }
    }
}