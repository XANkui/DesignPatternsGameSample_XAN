using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DesignPattern_Sample_XAN { 

	public class EnemyStateChase : IEnemyState
	{
        public EnemyStateChase(EnemyFSMSystem fsm, ICharacter character) : base(fsm, character)
        {
            mStateID = EnemyStateID.Chase;
        }

        private Vector3 mDestinationPosition;
        public override void DoBeforeEntering()
        {
            mDestinationPosition = PlayGameFacade.Instance.GetEnemyDestinationPosition();
        }

        public override void Reason(List<ICharacter> targetLst)
        {
            if (targetLst != null && targetLst.Count > 0) {
                float distance = Vector3.Distance(mCharacter.Position, targetLst[0].Position);
                if (distance <= mCharacter.AtkRange)
                {
                    mFSM.PerformTrnsition(EnemyTransition.CanAttack);
                }
            }
        }

        public override void Act(List<ICharacter> targetLst)
        {
            if (targetLst != null && targetLst.Count > 0)
            {
                // 攻击敌人
                mCharacter.MoveTo(targetLst[0].Position);
            }
            else {
                // 进攻目标据点位置
                mCharacter.MoveTo(mDestinationPosition);
            }
        }
    }
}
