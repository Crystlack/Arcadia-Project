using LOR_DiceSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WilliamReception.Passives
{
    public class PassiveAbility_XI_TheStrength : PassiveAbilityBase
    {
        private int _el0page = 101;
        private int _el3page = 102;
        private int _el5page = 103;

        public override void OnWaveStart()
        {
            var egoHand = owner?.personalEgoDetail;
            var emotion = owner?.emotionDetail?.EmotionLevel;

            egoHand?.AddCard(new LorId(WilliamModInit.packageId, _el0page));

            if (emotion >= 3)
                egoHand?.AddCard(new LorId(WilliamModInit.packageId, _el3page));

            if (emotion >= 5)
                egoHand?.AddCard(new LorId(WilliamModInit.packageId, _el5page));

            owner?.bufListDetail.AddBuf(new BattleUnitBuf_WilliamCombo());
        }

        public override bool IsImmune(KeywordBuf buf)
        {
            return buf == KeywordBuf.NullifyPower;
        }

        public override void OnRoundStart()
        {
            var bufListDetail = owner.bufListDetail;
            bufListDetail.AddKeywordBufThisRoundByEtc(KeywordBuf.Strength, 1);

            if (owner.emotionDetail.EmotionLevel >= 3)
                bufListDetail.AddKeywordBufThisRoundByEtc(KeywordBuf.Strength, 1);

            if (BattleObjectManager.instance.GetAliveList(owner.faction).Count == 1)
                bufListDetail.AddKeywordBufThisRoundByEtc(KeywordBuf.Strength, 2);
        }

        private class BattleUnitBuf_WilliamCombo : BattleUnitBuf
        {
            private List<LorId> _cards = new List<LorId>();

            private LorId _pointBlank = new LorId(WilliamModInit.packageId, 118);
            private LorId[] _pointBlankCombo = {
                new LorId(WilliamModInit.packageId, 114),
                new LorId(WilliamModInit.packageId, 115)
            };

            private LorId _shieldSplitter = new LorId(WilliamModInit.packageId, 119);
            private LorId[] _shieldSplitterCombo =
            {
                new LorId(WilliamModInit.packageId, 116),
                new LorId(WilliamModInit.packageId, 117)
            };

            public override void OnUseCard(BattlePlayingCardDataInUnitModel card)
            {
                var id = card?.card?.GetID();
                if (id != null && !_cards.Contains(id))
                {
                    _cards.Add(id);
                }
            }

            public override void OnRoundEnd()
            {
                if (_pointBlankCombo.All(card => _cards.Contains(card)))
                {
                    _owner?.allyCardDetail?.AddNewCard(_pointBlank);
                }
                if (_shieldSplitterCombo.All(card => _cards.Contains(card)))
                {
                    _owner?.allyCardDetail?.AddNewCard(_shieldSplitter);
                }

                _cards.Clear();
            }
        }
    }
}
