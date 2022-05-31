using LOR_DiceSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GoldenSparkMod.Status_Effects;
using CustomMapUtility;

namespace GoldenSparkMod.Passive_Effects
{
    public class PassiveAbility_RevolutionaryEnemy : PassiveAbilityBase
    {
        private bool _ego = false;
        private bool _egoReady = false;
        private int _threshold = 350;
        private int _damageReduct = 0;
        private int _spiralThrust = 78;
        private int _deicide = 80;
        private int _thunderstorm = 79;
        private bool _thunderstormPriority = false;
        private int _cdMin = 4;
        private int _cdMax = 6;
        private int _cd = 0;

        public override void OnWaveStart()
        {
            this._cd = RandomUtil.Range(this._cdMin, this._cdMax);
            
        }

        public override bool BeforeTakeDamage(BattleUnitModel attacker, int dmg)
        {
            if (!_ego && owner.hp - dmg <= _threshold)
            {
                _egoReady = true;
                _damageReduct = (int) owner.hp - _threshold;
                
            }

            return base.BeforeTakeDamage(attacker, dmg);
        }

        public override int GetDamageReductionAll()
        {
            if (this._ego || !_egoReady)
                return 0;
            if (this._egoReady && owner.hp > _threshold)
                return _damageReduct;
            return 9999;
        }
        
        public override void OnRoundStart()
        {
            if (_ego)
            {
                CustomMapHandler.EnforceTheme();
            }
            if (this._egoReady && !this._ego)
            {
                this._cd = 1;
                this._thunderstormPriority = true;
                owner.bufListDetail.AddBuf(new BattleUnitBuf_Golden_Spark(5));
                this._ego = true;
                this.owner.view.ChangeSkin("GoldenSparkEGO");
                CustomMapHandler.StartEnemyTheme("RollerMobster.wav", true);
                CustomMapHandler.EnforceTheme();

                this.owner.breakDetail.ResetGauge();
                this.owner.breakDetail.RecoverBreakLife(1, true);
                this.owner.cardSlotDetail.RecoverPlayPoint(owner.cardSlotDetail.GetMaxPlayPoint());
                this.owner.bufListDetail.AddReadyReadyBuf((BattleUnitBuf)new BattleUnitBuf_Golden_Spark.BattleUnitBuf_costAllDown());
                var enemies = BattleObjectManager.instance.GetAliveListExceptFaction(owner.faction);
                int count = 0;
                switch (enemies.Count)
                {
                    case 5:
                        count = 3;
                        break;
                    case 4:
                    case 3:
                        count = 2;
                        break;
                    case 2:
                        count = 1;
                        break;
                    default:
                        count = 0;
                        break;
                }
                foreach (BattleUnitModel battleUnitModel in enemies.OrderBy(x => RandomUtil.valueForProb).Take(count))
                {
                    battleUnitModel.bufListDetail.AddKeywordBufThisRoundByEtc(KeywordBuf.Stun, 1, battleUnitModel);
                }
                this._cdMin = 3;
                this._cdMax = 5;
                this._cd = RandomUtil.Range(_cdMin, _cdMax);
                Singleton<StageController>.Instance.GetStageModel().SetStageStorgeData("SparkEGOManifest", true);
            }

            if (this._cd == 0)
            {
                if (this._thunderstormPriority)
                {
                    owner.allyCardDetail.AddNewCard(new LorId(GoldenSparkModInit.packageId, _thunderstorm)).AddCost(-1);
                    _thunderstormPriority = false;
                }
                else if(_ego)
                {
                    owner.allyCardDetail.AddNewCard(RandomUtil.SelectOne(new LorId(GoldenSparkModInit.packageId, _spiralThrust),
                        new LorId(GoldenSparkModInit.packageId, _deicide),
                        new LorId(GoldenSparkModInit.packageId, _thunderstorm))).AddCost(-3);
                }
                else
                {
                    owner.allyCardDetail.AddNewCard(RandomUtil.SelectOne(new LorId(GoldenSparkModInit.packageId, _spiralThrust),
                        new LorId(GoldenSparkModInit.packageId, _deicide))).AddCost(-4);
                }
                _cd = RandomUtil.Range(this._cdMin, this._cdMax);
            }
            --this._cd;

        }
        
        public override void OnRoundEnd()
        {
            this.owner.allyCardDetail.DrawCards(1);
            this.owner.cardSlotDetail.RecoverPlayPoint(1);
            _damageReduct = 0;
            if (!_ego)
            {
                Singleton<StageController>.Instance.GetStageModel().GetStageStorageData("SparkEGOManifest", out bool isEgo);
                if (isEgo)
                {
                    this._egoReady = true;
                }
            }
        }
    }
}
