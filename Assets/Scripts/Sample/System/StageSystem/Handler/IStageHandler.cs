using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DesignPattern_Sample_XAN { 

	public abstract class IStageHandler 
	{
		protected int mLv;
		protected int mCountToFinish;
		protected StageSystem mStageSystem;
		protected IStageHandler mNextStageHandler;

        public IStageHandler(int mLv, int mCountToFinish, StageSystem mStageSystem)
        {
            this.mLv = mLv;
            this.mCountToFinish = mCountToFinish;
            this.mStageSystem = mStageSystem;
        }

        public virtual IStageHandler SetNextStageHandler(IStageHandler nextStagehandler) {
			mNextStageHandler = nextStagehandler;

			return mNextStageHandler;
		}

		protected abstract void UpdateStage();

		public void Handle(int lv) {
			if (lv == mLv)
			{
				UpdateStage();
				CheckIsFinished();
			}
			else {
				mNextStageHandler?.Handle(lv);
			}
		}

        private void CheckIsFinished()
        {
            if (mStageSystem.GetCountOfEnemyKilled()>= mCountToFinish)
            {
				mStageSystem.EnterNextStage();
            }
        }

        
	}
}
