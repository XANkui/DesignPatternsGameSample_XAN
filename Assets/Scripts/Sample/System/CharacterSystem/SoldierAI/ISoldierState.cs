using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DesignPattern_Sample_XAN {

	public enum SoldierTransition
	{
		NullTansition=0,
		SeeEnemy,
		NoEnemy,
		CanAttack
	}

	public enum SoldierStateID { 
		NullState,
		Idle,
		Chase,
		Attack
	}


	public abstract class ISoldierState 
	{
		protected Dictionary<SoldierTransition, SoldierStateID> mMap = new Dictionary<SoldierTransition, SoldierStateID>();
		protected SoldierStateID mStateID;
		protected ICharacter mCharacter;
		protected SoldierFSMSystem mFSM;

		public ISoldierState(SoldierFSMSystem fsm, ICharacter character) {
			mFSM = fsm;
			mCharacter = character;
		}

		public SoldierStateID StateID { get { return mStateID; } }

		public void AddTransition(SoldierTransition trans, SoldierStateID stateId) {
            if (trans == SoldierTransition.NullTansition)
            {
				Debug.LogError(GetType()+ "/AddTransition()/ SoldierTransition is NullTansition ");
				return;
			}

			if (stateId == SoldierStateID.NullState)
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

		public void DeleteTransition(SoldierTransition trans) {
			if (trans == SoldierTransition.NullTansition)
			{
				Debug.LogError(GetType()+ "/DeleteTransition()/ SoldierTransition is NullTansition");
				return;
			}


			if (mMap.ContainsKey(trans) == false)
            {
				Debug.LogError(GetType() + "/DeleteTransition()/ The trans is not Contained in mMap ");
				return;
			}

			mMap.Remove(trans);
		}

		public SoldierStateID GetOutputState(SoldierTransition trans) {
            if (mMap.ContainsKey(trans)==false)
            {
				return SoldierStateID.NullState;
            }

			return mMap[trans];
		}

		public virtual void DoBeforeEntering() { }
		public virtual void DoBeforeLeaving() { }

		public abstract void Reason(List<ICharacter> targetLst);
		public abstract void Act(List<ICharacter> targetLst);
	}
}
