using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DesignPattern_Sample_XAN {

	public enum SoldierType { 
		Rookie,
		Sergeant,
		Captain,
		Captive
	}

	public abstract class ISoldier : ICharacter
	{
		protected SoldierFSMSystem mSoldierFSMSystem;

		public ISoldier() : base() {
			MakeFSM();
		}

		public override void UpdateFSMAI(List<ICharacter> targetLst) {
            if (mIsKilled ==true)
            {
				return;
            }

			mSoldierFSMSystem.CurState.Reason(targetLst);
			mSoldierFSMSystem.CurState.Act(targetLst);
		}

		private void MakeFSM() {
			mSoldierFSMSystem = new SoldierFSMSystem();

			SoldierStateIdle soldierStateIdle = new SoldierStateIdle(mSoldierFSMSystem, this);
			soldierStateIdle.AddTransition(SoldierTransition.SeeEnemy, SoldierStateID.Chase);

			SoldierStateChase soldierStateChase = new SoldierStateChase(mSoldierFSMSystem,this);
			soldierStateChase.AddTransition(SoldierTransition.NoEnemy,SoldierStateID.Idle);
			soldierStateChase.AddTransition(SoldierTransition.CanAttack,SoldierStateID.Attack);

			SoldierStateAttack soldierStateAttack = new SoldierStateAttack(mSoldierFSMSystem, this);
			soldierStateAttack.AddTransition(SoldierTransition.NoEnemy, SoldierStateID.Idle);
			soldierStateAttack.AddTransition(SoldierTransition.SeeEnemy, SoldierStateID.Chase);

			mSoldierFSMSystem.AddState(soldierStateIdle,soldierStateChase,soldierStateAttack);
		}

        public override void RunVisitor(ICharactorVisitor visitor)
        {
			visitor.VisitSoldier(this);
        }

        public override void UnderAttack(int damage)
        {
			if (mIsKilled == true)
			{
				return;
			}
			base.UnderAttack(damage);

            if (mAttr.CurHp <= 0)
            {
				PlaySound();
				PlayEffect();

				Killed();
			}
        }

        public override void Killed()
        {
            base.Killed();

			PlayGameFacade.Instance.NotifySubject(GameEventType.SoldierKilled);
        }

        protected abstract void PlaySound();
		protected abstract void PlayEffect();

		
    }
}
