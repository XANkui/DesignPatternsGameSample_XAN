using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DesignPattern_Sample_XAN { 

	public class NewStageSubject : IGameEventSubject
	{
        private int mStageCount = 1;
        public int StageCount => mStageCount;

        public override void Notify()
        {
            mStageCount++;

            base.Notify();
        }
    }
}
