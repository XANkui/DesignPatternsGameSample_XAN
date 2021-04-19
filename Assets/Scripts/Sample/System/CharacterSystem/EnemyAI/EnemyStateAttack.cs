using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DesignPattern_Sample_XAN { 

	public class EnemyStateAttack : IEnemyState
	{
        private float mAttackTime = 1;
        private float mAttackTimer = 1;
        public EnemyStateAttack(EnemyFSMSystem fsm, ICharacter character) : base(fsm, character)
        {
            mStateID = EnemyStateID.Attack;
            mAttackTimer = mAttackTime;
        }

        public override void Reason(List<ICharacter> targetLst)
        {
            if (targetLst == null || targetLst.Count == 0)
            {
                mFSM.PerformTrnsition(EnemyTransition.LostSoldier);
            }
            else {
                float distance = Vector3.Distance(mCharacter.Position, targetLst[0].Position);
                if (distance >mCharacter.AtkRange)
                {
                    mFSM.PerformTrnsition(EnemyTransition.LostSoldier);
                }
            }
        }

        public override void Act(List<ICharacter> targetLst)
        {
            if (targetLst == null || targetLst.Count == 0)
            {
                return;
            }

            mAttackTimer += Time.deltaTime;
            if (mAttackTimer>=mAttackTime)
            {
                mCharacter.Attack(targetLst[0]);
                mAttackTimer = 0;
            }
        }
    }
}
