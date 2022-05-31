using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoldenSparkMod.Behavior_Actions
{
    public class BehaviourAction_blackoutAction : BehaviourActionBase
    {
        public override List<RencounterManager.MovingAction> GetMovingAction(
          ref RencounterManager.ActionAfterBehaviour self,
          ref RencounterManager.ActionAfterBehaviour opponent)
        {
            List<RencounterManager.MovingAction> movingAction1 = new List<RencounterManager.MovingAction>();
            bool flag = false;
            if (opponent.behaviourResultData != null)
                flag = opponent.behaviourResultData.IsFarAtk();
            if (self.result == Result.Win && self.data.actionType == ActionType.Atk && !flag)
            {
                RencounterManager.MovingAction movingAction2 = new RencounterManager.MovingAction(ActionDetail.S3, CharMoveState.MoveForward, 30f, false, 0.5f);
                movingAction2.SetEffectTiming(EffectTiming.PRE, EffectTiming.PRE, EffectTiming.PRE);
                movingAction1.Add(movingAction2);
                opponent.infoList.Add(new RencounterManager.MovingAction(ActionDetail.Damaged, CharMoveState.Stop, updateDir: false, delay: 0.5f));
            }
            else
                movingAction1 = base.GetMovingAction(ref self, ref opponent);
            return movingAction1;
        }
    }
}
