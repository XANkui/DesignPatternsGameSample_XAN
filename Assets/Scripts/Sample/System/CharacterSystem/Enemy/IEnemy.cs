using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DesignPattern_Sample_XAN { 

	public abstract class IEnemy : ICharacter
	{
		protected EnemyFSMSystem mFSMSystem;

		public IEnemy() {
			MakeFSM();
		}

		public override void UpdateFSMAI(List<ICharacter> targetLst) {
			if (mIsKilled == true)
			{
				return;
			}
			mFSMSystem.CurState.Reason(targetLst);
			mFSMSystem.CurState.Act(targetLst);
		}

		private void MakeFSM() {
			mFSMSystem = new EnemyFSMSystem();

			EnemyStateChase enemyStateChase = new EnemyStateChase(mFSMSystem, this);
			enemyStateChase.AddTransition(EnemyTransition.CanAttack,EnemyStateID.Attack);


			EnemyStateAttack enemyStateAttack = new EnemyStateAttack(mFSMSystem, this);
			enemyStateAttack.AddTransition(EnemyTransition.LostSoldier, EnemyStateID.Chase);

			mFSMSystem.AddState(enemyStateAttack, enemyStateChase);
		}

        public override void RunVisitor(ICharactorVisitor visitor)
        {
			visitor.VisitEnemy(this);
        }

        public override void UnderAttack(int damage)
        {
            if (mIsKilled==true)
            {
				return;
            }

            base.UnderAttack(damage);

			PlayEffect();

            if (mAttr.CurHp <=0)
            {
				Killed();
            }
        }

		public abstract void PlayEffect();

        public override void Killed()
        {
            base.Killed();

			PlayGameFacade.Instance.NotifySubject(GameEventType.EnemyKilled);
        }

    }
}
