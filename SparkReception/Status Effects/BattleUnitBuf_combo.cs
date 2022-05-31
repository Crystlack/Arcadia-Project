using LOR_DiceSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoldenSparkMod.Status_Effects
{
    public class BattleUnitBuf_combo : BattleUnitBuf
    {
        public List<LorId> used_cards = new List<LorId>();

        public override void OnUseCard(BattlePlayingCardDataInUnitModel card)
        {
            this.used_cards.Add(card.card.GetID());
        }

        public override void OnRoundEnd()
        {
            List<LorId> cards = this.used_cards;
            if (cards.Contains(new LorId("GoldenSparkReception", 2)) && cards.Contains(new LorId("GoldenSparkReception", 6)) && cards.Contains(new LorId("GoldenSparkReception", 8)))
            {
                this._owner.allyCardDetail.AddNewCard(new LorId("GoldenSparkReception", 11));
            }
            if (cards.Contains(new LorId("GoldenSparkReception", 5)) && cards.Contains(new LorId("GoldenSparkReception", 7)))
            {
                this._owner.allyCardDetail.AddNewCard(new LorId("GoldenSparkReception", 12));
            }
            if (cards.Contains(new LorId("GoldenSparkReception", 1)) && cards.Contains(new LorId("GoldenSparkReception", 9)))
            {
                this._owner.allyCardDetail.AddNewCard(new LorId("GoldenSparkReception", 13));
            }
            this.used_cards.Clear();
        }
    }
}
