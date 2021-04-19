using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DesignPattern_Sample_XAN {

	public enum EnemyType { 
		Elf,
		Ogre,
		Troll
	}

	public class EnemyFSMSystem 
	{
		private List<IEnemyState> mStateLst = new List<IEnemyState>();

		private IEnemyState mCurState;
		public IEnemyState CurState { get { return mCurState; } }

		public void AddState(params IEnemyState[] states)
		{
			foreach (IEnemyState s in states)
			{
				AddState(s);
			}
		}

		public void AddState(IEnemyState state)
		{
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

			foreach (IEnemyState s in mStateLst)
			{
				if (s.StateID == state.StateID)
				{
					Debug.LogError(GetType() + "/AddState()/ state had been contained : " + state);
					return;
				}
			}

			mStateLst.Add(state);
		}

		public void DeleteState(EnemyStateID stateID)
		{
			if (stateID == EnemyStateID.NullState)
			{
				Debug.LogError(GetType() + "/DeleteState()/ state is NullState ");
				return;
			}

			foreach (IEnemyState s in mStateLst)
			{
				if (s.StateID == stateID)
				{
					mStateLst.Remove(s);
					return;
				}
			}

			Debug.LogError(GetType() + "/DeleteState()/ stateID is not contained: " + stateID.ToString());

		}


		public void PerformTrnsition(EnemyTransition trans)
		{
			if (trans == EnemyTransition.NullTansition)
			{
				Debug.LogError(GetType() + "/PerformTrnsition()/ trans is NullTansition ");
				return;
			}

			EnemyStateID nextStateId = mCurState.GetOutputState(trans);
			if (nextStateId == EnemyStateID.NullState)
			{
				Debug.LogError(GetType() + "/PerformTrnsition()/ stateId is NullState ");
				return;
			}

			foreach (IEnemyState s in mStateLst)
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
