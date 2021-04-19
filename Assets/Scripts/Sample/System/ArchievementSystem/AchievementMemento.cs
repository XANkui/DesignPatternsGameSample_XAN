using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DesignPattern_Sample_XAN { 

	public class AchievementMemento 
	{
		public int enemyKilledCount { get; set; }
		public int soldierKilledCount { get; set; }
		public int maxStageCount { get; set; }

		public void Save() {
			PlayerPrefs.SetInt("EnemyKilledCount", enemyKilledCount);
			PlayerPrefs.SetInt("SoldierKilledCount", soldierKilledCount);
			PlayerPrefs.SetInt("MaxStageCount", maxStageCount);
		}

		public void Load()
		{
			enemyKilledCount = PlayerPrefs.GetInt("EnemyKilledCount");
			soldierKilledCount = PlayerPrefs.GetInt("SoldierKilledCount" );
			maxStageCount = PlayerPrefs.GetInt("MaxStageCount");
		}
	}
}
