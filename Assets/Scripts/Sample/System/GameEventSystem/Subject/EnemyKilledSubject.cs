using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DesignPattern_Sample_XAN { 

	public class EnemyKilledSubject :IGameEventSubject
	{
		private int mKilledCount = 0;
		public int KilledCount => mKilledCount;

        public override void Notify()
        {
            mKilledCount++;

            base.Notify();
        }
    }
}
