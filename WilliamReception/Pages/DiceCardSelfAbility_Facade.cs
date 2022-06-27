using LOR_DiceSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WilliamReception.Pages
{
    public class DiceCardSelfAbility_Facade : DiceCardSelfAbilityBase
    {
        public static string Desc = "[On Play] Swaps William Cheytac's pages with alternative versions of those pages";

        public override bool IsValidTarget(BattleUnitModel unit, BattleDiceCardModel self, BattleUnitModel targetUnit)
        {
            return true;
        }

        public override void OnUseInstance(BattleUnitModel unit, BattleDiceCardModel self, BattleUnitModel targetUnit)
        {
            foreach (var c in owner.allyCardDetail.GetHand())
            {
                var id = c.GetID().id;
                if (104 <= id && id <= 113)
                {
                    owner.allyCardDetail.AddNewCard(new LorId(WilliamModInit.packageId, id % 2 == 0 ? id + 1 : id - 1));
                    owner.allyCardDetail.ExhaustACard(c);
                }
            }

            foreach (var c in owner.allyCardDetail.GetDeck())
            {
                var id = c.GetID().id;
                if (104 <= id && id <= 113)
                {
                    owner.allyCardDetail.AddNewCardToDeck(new LorId(WilliamModInit.packageId, id % 2 == 0 ? id + 1 : id - 1));
                    owner.allyCardDetail.ExhaustACardAnywhere(c);
                }
            }
        }
    }
}
