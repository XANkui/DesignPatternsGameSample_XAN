using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DesignPattern_Sample_XAN { 

	public class SoldierStateAttack : ISoldierState
	{
        private float mAttackTime = 1;
        private float mAttackTimer = 1;

        public SoldierStateAttack(SoldierFSMSystem fsm, ICharacter character) : base(fsm, character)
        {
            mStateID = SoldierStateID.Attack;
            mAttackTimer = mAttackTime;
        }

        public override void Reason(List<ICharacter> targetLst)
        {
            if (targetLst ==null || targetLst.Count <= 0)
            {
                mFSM.PerformTrnsition(SoldierTransition.NoEnemy);
                return;
            }

            float distance = Vector3.Distance(mCharacter.Position, targetLst[0].Position);
            if (distance > mCharacter.AtkRange)
            {
                mFSM.PerformTrnsition(SoldierTransition.SeeEnemy);
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
                mAttackTimer -= mAttackTime;
            }
        }
    }
}
