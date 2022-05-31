using LOR_DiceSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WilliamReception.Passives
{
    public class PassiveAbility_Unyielding : PassiveAbilityBase
    {
        private bool _activated;

        public override void OnWaveStart()
        {
            _activated = false;
        }

        public override bool BeforeTakeBreakDamage(BattleUnitModel attacker, int dmg)
        {
            if (!_activated && owner.hp <= dmg)
            {
                _activated = true;
                owner.bufListDetail.AddBuf(new BattleUnitBuf_UnyieldingBuf());
            }
            return false;
        }

        private class BattleUnitBuf_UnyieldingBuf : BattleUnitBuf
        {
            public override void OnRoundEnd()
            {
                Destroy();
            }

            public override int GetDamageReductionAll()
            {
                return 100;
            }
        }
    }
}
