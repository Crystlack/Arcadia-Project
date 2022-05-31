using LOR_DiceSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WilliamReception.Passives
{
    public class PassiveAbility_Facade : PassiveAbilityBase
    {
        private int _facadeID = 120;

        public override void OnWaveStart()
        {
            owner.personalEgoDetail.AddCard(new LorId(WilliamModInit.packageId, _facadeID));
        }
    }
}
