using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DesignPattern_Sample_XAN {

	public enum EnemyTransition
	{
		NullTansition = 0,
		CanAttack,
		LostSoldier

	}

	public enum EnemyStateID
	{
		NullState,
		Chase,
		Attack
	}

	public abstract class IEnemyState 
	{
		protected Dictionary<EnemyTransition, EnemyStateID> mMap = new Dictionary<EnemyTransition, EnemyStateID>();
		protected EnemyStateID mStateID;
		protected ICharacter mCharacter;
		protected EnemyFSMSystem mFSM;

		public IEnemyState(EnemyFSMSystem fsm, ICharacter character)
		{
			mFSM = fsm;
			mCharacter = character;
		}

		public EnemyStateID StateID { get { return mStateID; } }

		public void AddTransition(EnemyTransition trans, EnemyStateID stateId)
		{
			if (trans == EnemyTransition.NullTansition)
			{
				Debug.LogError(GetType() + "/AddTransition()/ SoldierTransition is NullTansition ");
				return;
			}

			if (stateId == EnemyStateID.NullState)
			{
				Debug.LogError(GetType() + "/AddTransition()/ stateId is NullState ");
				return;
			}

			if (mMap.ContainsKey(trans))
			{
				Debug.LogError(GetType() + "/AddTransition()/ The trans is Contained in mMap");
				return;
			}

			mMap.Add(trans, stateId);
		}

		public void DeleteTransition(EnemyTransition trans)
		{
			if (trans == EnemyTransition.NullTansition)
			{
				Debug.LogError(GetType() + "/DeleteTransition()/ SoldierTransition is NullTansition");
				return;
			}


			if (mMap.ContainsKey(trans) == false)
			{
				Debug.LogError(GetType() + "/DeleteTransition()/ The trans is not Contained in mMap ");
				return;
			}

			mMap.Remove(trans);
		}

		public EnemyStateID GetOutputState(EnemyTransition trans)
		{
			if (mMap.ContainsKey(trans) == false)
			{
				return EnemyStateID.NullState;
			}

			return mMap[trans];
		}

		public virtual void DoBeforeEntering() { }
		public virtual void DoBeforeLeaving() { }

		public abstract void Reason(List<ICharacter> targetLst);
		public abstract void Act(List<ICharacter> targetLst);
	}
}
