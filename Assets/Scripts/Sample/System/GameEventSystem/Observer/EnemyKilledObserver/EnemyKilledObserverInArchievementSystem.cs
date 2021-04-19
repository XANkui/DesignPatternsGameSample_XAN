using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DesignPattern_Sample_XAN { 

	public class EnemyKilledObserverInArchievementSystem : IGameEventObserver
	{
        private ArchievementSystem mArchievementSystem;
        public EnemyKilledObserverInArchievementSystem(ArchievementSystem archievementSystem) {
            mArchievementSystem = archievementSystem;
        }

        public override void Update()
        {
            mArchievementSystem.AddEnemyKilledCount();
        }

        public override void SetSubject(IGameEventSubject subject)
        {
            
        }
    }
}
