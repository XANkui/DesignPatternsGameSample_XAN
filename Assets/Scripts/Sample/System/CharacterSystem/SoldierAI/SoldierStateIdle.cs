using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DesignPattern_Sample_XAN { 

	public class SoldierStateIdle : ISoldierState
	{
        public SoldierStateIdle(SoldierFSMSystem fsm, ICharacter character) : base(fsm, character)
        {
            mStateID = SoldierStateID.Idle;
        }

        public override void Reason(List<ICharacter> targetLst)
        {
            if (targetLst!=null && targetLst.Count>0)
            {
                mFSM.PerformTrnsition(SoldierTransition.SeeEnemy);
            }
        }

        public override void Act(List<ICharacter> targetLst)
        {
            mCharacter.PlayAnim("stand");
        }
    }
}
