using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DesignPattern_Sample_XAN { 

	public class AliveCountVisitor : ICharactorVisitor
	{
        public int enemyCount { get; private set; }
        public int soldierCount { get; private set; }

        public void Reset() {
            enemyCount = 0;
            soldierCount = 0;
        }

        public override void VisitEnemy(IEnemy enemy)
        {
            if (enemy.IsKilled==false)
            {
                enemyCount += 1;

            }
        }

        public override void VisitSoldier(ISoldier soldier)
        {
            if (soldier.IsKilled == false)
            {
                soldierCount += 1;
            }
        }
    }
}
