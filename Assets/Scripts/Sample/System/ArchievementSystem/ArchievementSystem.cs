using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DesignPattern_Sample_XAN
{ 

	public class ArchievementSystem : IGameSystem
	{
        private int mEnemyKilledCount = 0;
        private int mSoldierKilledCount = 0;
        private int mMaxStageLv = 1;

        public override void Init()
        {
            base.Init();
            PlayGameFacade.RegisterObserver(GameEventType.EnemyKilled, new EnemyKilledObserverInArchievementSystem(this));
            PlayGameFacade.RegisterObserver(GameEventType.SoldierKilled,new SoldierKilledObserverInArchievementSystem(this));
            PlayGameFacade.RegisterObserver(GameEventType.NewStage, new NewStageObserverInArchievementSystem(this));
        }

        public void AddEnemyKilledCount(int number=1) {
            mEnemyKilledCount += 1;
        }

        public void AddSoldierKilledCount(int number = 1)
        {
            mSoldierKilledCount += 1;
        }

        public void SetMaxStageLv(int stageLv) {
            if (stageLv>mMaxStageLv)
            {
                mMaxStageLv = stageLv;
            }
        }

        public AchievementMemento CreateMemento() {
            AchievementMemento memento = new AchievementMemento();
            memento.enemyKilledCount = mEnemyKilledCount;
            memento.soldierKilledCount = mSoldierKilledCount;
            memento.maxStageCount = mMaxStageLv;

            return memento;
        }

        public void SetMemento(AchievementMemento memento) {

            mEnemyKilledCount = memento.enemyKilledCount;
            mSoldierKilledCount = memento.soldierKilledCount;
            mMaxStageLv = memento.maxStageCount;
        
        }
    }
}
