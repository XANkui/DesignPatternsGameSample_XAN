using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DesignPattern_Sample_XAN { 

	public class SoldierEnergyCostStrategy : IEnergyCostStrategy
	{
        public override int GetCampUpgradeCost(SoldierType soldierType, int lv)
        {
            int energy = 0;

            switch (soldierType)
            {
                case SoldierType.Rookie:
                    energy = 60;
                    break;
                case SoldierType.Sergeant:
                    energy = 65;
                    break;
                case SoldierType.Captain:
                    energy = 70;
                    break;
                default:
                    Debug.LogError(GetType() + "/GetCampUpgradeCost()/ SoldierType Does not Set Strategy ");
                    break;
            }
            energy += (lv -1)*2;

            energy = energy > 100 ? 100 : energy;

            return energy;
        }

        public override int GetWeaponUpgradeCost(WeaponType weaponType)
        {
            int energy = 0;

            switch (weaponType)
            {
                case WeaponType.Gun:
                    energy = 30;
                    break;
                case WeaponType.Rifle:
                    energy = 40;
                    break;

                case WeaponType.Rocket:
                    break;
                default:
                    Debug.LogError(GetType() + "/GetWeaponUpgradeCost()/ WeaponType Does not Set Strategy ");

                    break;
            }

            return energy;
        }

        public override int GetSoldierTrainCost(SoldierType soldierType, int lv)
        {
            int energy = 0;

            switch (soldierType)
            {
                case SoldierType.Rookie:
                    energy = 10;
                    break;
                case SoldierType.Sergeant:
                    energy = 15;
                    break;
                case SoldierType.Captain:
                    energy = 20;
                    break;
                case SoldierType.Captive:
                    return 10;
                    break;
                default:
                    Debug.LogError(GetType() + "/GetSoldierTrainCost()/ SoldierType Does not Set Strategy ");
                    break;
            }
            energy += (lv - 1) * 2;

            return energy;
        }
    }
}
