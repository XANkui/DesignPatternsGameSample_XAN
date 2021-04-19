using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DesignPattern_Sample_XAN
{ 

	public class SoldierFSMSystem 
	{
		private List<ISoldierState> mStateLst = new List<ISoldierState>();

		private ISoldierState mCurState;
		public ISoldierState CurState { get { return mCurState; } }

		public void AddState(params ISoldierState[] states) {
            foreach (ISoldierState s in states)
            {
				AddState(s);
            }
		}

		public void AddState(ISoldierState state) {
            if (state == null)
            {
				Debug.LogError(GetType() + "/AddState()/ state is null ");
				return;
			}

            if (mStateLst.Count == 0)
            {
				mStateLst.Add(state);
				mCurState = state;
				return;
            }

            foreach (ISoldierState s in mStateLst)
            {
                if (s.StateID == state.StateID)
                {
					Debug.LogError(GetType() + "/AddState()/ state had been contained : "+ state);
					return;
				}
            }

			mStateLst.Add(state);
		}

		public void DeleteState(SoldierStateID stateID) {
            if (stateID == SoldierStateID.NullState)
            {
				Debug.LogError(GetType() + "/DeleteState()/ state is NullState ");
				return;
			}

            foreach (ISoldierState s in mStateLst)
            {
                if (s.StateID == stateID)
                {
					mStateLst.Remove(s);
					return;
                }
            }

			Debug.LogError(GetType() + "/DeleteState()/ stateID is not contained: " + stateID.ToString());
			
		}


		public void PerformTrnsition(SoldierTransition trans) {
            if (trans == SoldierTransition.NullTansition)
            {
				Debug.LogError(GetType() + "/PerformTrnsition()/ trans is NullTansition ");
				return;
			}

			SoldierStateID nextStateId = mCurState.GetOutputState(trans);
			if (nextStateId == SoldierStateID.NullState)
			{
				Debug.LogError(GetType() + "/PerformTrnsition()/ stateId is NullState ");
				return;
			}

            foreach (ISoldierState s in mStateLst)
            {
                if (s.StateID == nextStateId)
                {
					mCurState.DoBeforeLeaving();
					mCurState = s;
					mCurState.DoBeforeEntering();
                }
            }
		}
	}
}
