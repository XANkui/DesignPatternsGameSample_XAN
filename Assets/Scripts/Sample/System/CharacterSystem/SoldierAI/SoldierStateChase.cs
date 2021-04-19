using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DesignPattern_Sample_XAN { 

	public class SoldierStateChase : ISoldierState
	{
        public SoldierStateChase(SoldierFSMSystem fsm, ICharacter character) : base(fsm, character)
        {
            mStateID = SoldierStateID.Chase;
        }

        public override void Reason(List<ICharacter> targetLst)
        {
            if (targetLst==null || targetLst.Count ==0)
            {
                mFSM.PerformTrnsition(SoldierTransition.NoEnemy);
                return;
            }

            float distance = Vector3.Distance(targetLst[0].Position, mCharacter.Position);
            if (distance <= mCharacter.AtkRange)
            {
                mFSM.PerformTrnsition(SoldierTransition.CanAttack);
            }
        }

        public override void Act(List<ICharacter> targetLst)
        {
            if (targetLst != null && targetLst.Count > 0)
            {
                mCharacter.MoveTo(targetLst[0].Position);
            }
        }
    }
}
