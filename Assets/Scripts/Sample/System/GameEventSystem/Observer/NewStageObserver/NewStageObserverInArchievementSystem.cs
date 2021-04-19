using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DesignPattern_Sample_XAN { 

	public class NewStageObserverInArchievementSystem : IGameEventObserver
	{
        private NewStageSubject mNewStageSubject;
        private ArchievementSystem mArchievementSystem;
        public NewStageObserverInArchievementSystem(ArchievementSystem archievementSystem)
        {
            mArchievementSystem = archievementSystem;
        }

        public override void Update()
        {
            mArchievementSystem.SetMaxStageLv(mNewStageSubject.StageCount);
        }

        public override void SetSubject(IGameEventSubject subject)
        {
            mNewStageSubject = subject as NewStageSubject;
        }
    }
}
