using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DesignPattern_Sample_XAN { 

	public class EnemyKilledObserverInStageSystem : IGameEventObserver
	{
        private EnemyKilledSubject mSubject;
        private StageSystem mStageSystem;

        public EnemyKilledObserverInStageSystem(StageSystem stageSystem) {
            mStageSystem = stageSystem;
        }

        public override void Update()
        {
            mStageSystem.CountOfEnemyKilled =  mSubject.KilledCount;
        }

        public override void SetSubject(IGameEventSubject subject)
        {
            mSubject = subject as EnemyKilledSubject;
        }
    }
}
