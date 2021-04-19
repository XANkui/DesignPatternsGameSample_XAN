using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DesignPattern_Sample_XAN { 

	public class SoldierKilledObserverInArchievementSystem : IGameEventObserver
	{
        private ArchievementSystem mArchievementSystem;
        public SoldierKilledObserverInArchievementSystem(ArchievementSystem archievementSystem)
        {
            mArchievementSystem = archievementSystem;
        }

        public override void Update()
        {
            mArchievementSystem.AddSoldierKilledCount();
        }

        public override void SetSubject(IGameEventSubject subject)
        {

        }
    }
}
