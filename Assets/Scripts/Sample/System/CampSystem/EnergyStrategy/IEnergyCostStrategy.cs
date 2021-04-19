using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DesignPattern_Sample_XAN { 

	public abstract class IEnergyCostStrategy 
	{
		public abstract int GetCampUpgradeCost(SoldierType soldierType, int lv);
		public abstract int GetWeaponUpgradeCost(WeaponType weaponType);
		public abstract int GetSoldierTrainCost(SoldierType soldierType, int lv);
	}
}
