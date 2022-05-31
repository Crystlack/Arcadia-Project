using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace GoldenSparkMod.Behavior_Actions
{
    // Decompiled with JetBrains decompiler
    // Type: BehaviourAction_blackoutSpecial
    // Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
    // MVID: 7D9F3D8F-8146-434A-9316-0AD0A2194B2A
    // Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Library Of Ruina\LibraryOfRuina_Data\Managed\Assembly-CSharp.dll

    using System.Collections.Generic;
    using UnityEngine;

    public class BehaviourAction_blackoutSpecial : BehaviourActionBase
    {
        private static int _motionCount;
        private static BattleUnitModel _target;
        private bool _bMoved;

        public override bool IsMovable() => false;

        public override bool IsOpponentMovable() => false;

        public override List<RencounterManager.MovingAction> GetMovingAction(
          ref RencounterManager.ActionAfterBehaviour self,
          ref RencounterManager.ActionAfterBehaviour opponent)
        {
            bool flag = false;
            if (opponent.behaviourResultData != null)
                flag = opponent.behaviourResultData.IsFarAtk();
            if (BehaviourAction_blackoutSpecial._target != opponent.view.model)
                BehaviourAction_blackoutSpecial._motionCount = 0;
            if (self.result != Result.Win || flag)
                return base.GetMovingAction(ref self, ref opponent);
            this._self = self.view.model;
            BehaviourAction_blackoutSpecial._target = opponent.view.model;
            List<RencounterManager.MovingAction> movingAction1 = new List<RencounterManager.MovingAction>();
            RencounterManager.MovingAction movingAction2 = new RencounterManager.MovingAction(ActionDetail.S3, CharMoveState.Custom, delay: 1f, speed: 30f);
            movingAction2.SetCustomMoving(new RencounterManager.MovingAction.MoveCustomEvent(this.MoveForward));
            movingAction1.Add(movingAction2);
            if (BehaviourAction_blackoutSpecial._motionCount == 0)
            {
                List<RencounterManager.MovingAction> infoList = opponent.infoList;
                // ISSUE: explicit non-virtual call
                /*if ((infoList != null ? (__nonvirtual(infoList.Count) > 0 ? 1 : 0) : 0) != 0)
                {
                    opponent.infoList?.Clear();
                    opponent.infoList = new List<RencounterManager.MovingAction>();
                }*/
                RencounterManager.MovingAction movingAction3 = new RencounterManager.MovingAction(ActionDetail.S3, CharMoveState.Stop, 0.0f, delay: 1f);
                RencounterManager.MovingAction movingAction4 = new RencounterManager.MovingAction(ActionDetail.Damaged, CharMoveState.Stop, 0.0f, delay: 1f);
                movingAction3.customEffectRes = "Nikolai_SpecialAtk";
                movingAction3.SetEffectTiming(EffectTiming.PRE, EffectTiming.NONE, EffectTiming.NONE);
                movingAction1.Add(movingAction3);
                opponent.infoList.Add(movingAction4);
                RencounterManager.MovingAction movingAction5 = new RencounterManager.MovingAction(ActionDetail.S3, CharMoveState.Stop, 0.0f, delay: 1f);
                RencounterManager.MovingAction movingAction6 = new RencounterManager.MovingAction(ActionDetail.Damaged, CharMoveState.Stop, 0.0f, delay: 1f);
                movingAction5.SetEffectTiming(EffectTiming.NONE, EffectTiming.PRE, EffectTiming.PRE);
                movingAction1.Add(movingAction5);
                opponent.infoList.Add(movingAction6);
                ++BehaviourAction_blackoutSpecial._motionCount;
            }
            else
            {
                List<RencounterManager.MovingAction> infoList = opponent.infoList;
                // ISSUE: explicit non-virtual call
                /*if ((infoList != null ? (__nonvirtual(infoList.Count) > 0 ? 1 : 0) : 0) != 0)
                {
                    opponent.infoList?.Clear();
                    opponent.infoList = new List<RencounterManager.MovingAction>();
                }*/
                RencounterManager.MovingAction movingAction7 = new RencounterManager.MovingAction(ActionDetail.S3, CharMoveState.Stop, 0.0f, delay: 0.5f);
                movingAction7.customEffectRes = "Nikolai_SpecialAtkAfter";
                RencounterManager.MovingAction movingAction8 = new RencounterManager.MovingAction(ActionDetail.Damaged, CharMoveState.Stop, 0.0f, delay: 0.5f);
                movingAction7.SetEffectTiming(EffectTiming.PRE, EffectTiming.NONE, EffectTiming.NONE);
                movingAction1.Add(movingAction7);
                opponent.infoList.Add(movingAction8);
                RencounterManager.MovingAction movingAction9 = new RencounterManager.MovingAction(ActionDetail.S4, CharMoveState.Stop, 0.0f, delay: 1f);
                RencounterManager.MovingAction movingAction10 = new RencounterManager.MovingAction(ActionDetail.Damaged, CharMoveState.MoveBack, 2f, delay: 1f);
                movingAction9.customEffectRes = "FX_Mon_Nicolai_S2";
                movingAction9.SetEffectTiming(EffectTiming.PRE, EffectTiming.NONE, EffectTiming.PRE);
                movingAction1.Add(movingAction9);
                opponent.infoList.Add(movingAction10);
                BehaviourAction_blackoutSpecial._motionCount = 0;
            }
            return movingAction1;
        }

        /*private int __nonvirtual(int count)
        {
            throw new NotImplementedException();
        }*/

        private bool MoveForward(float deltaTime)
        {
            bool flag = false;
            if (!this._bMoved)
            {
                Vector3 worldPosition = BehaviourAction_blackoutSpecial._target.view.WorldPosition;
                float num1 = (float)((double)SingletonBehavior<HexagonalMapManager>.Instance.tileSize * (double)BehaviourAction_blackoutSpecial._target.view.transform.localScale.x + 6.0);
                int num2 = 1;
                if ((double)this._self.view.WorldPosition.x < (double)BehaviourAction_blackoutSpecial._target.view.WorldPosition.x)
                    num2 = -1;
                Vector3 vector3 = new Vector3((float)num2 * num1, 0.0f, 0.0f);
                this._self.moveDetail.Move(worldPosition + vector3, 150f);
                this._bMoved = true;
            }
            else if (this._self.moveDetail.isArrived)
                flag = true;
            return flag;
        }
    }

}
