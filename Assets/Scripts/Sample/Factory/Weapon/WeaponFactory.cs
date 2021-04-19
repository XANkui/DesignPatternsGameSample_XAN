using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DesignPattern_Sample_XAN { 

	public class WeaponFactory : IWeaponFactory
	{
        public IWeapon CreateWeapon(WeaponType weaponType)
        {
            IWeapon weapon = null;
            WeaponBaseAttr baseAttr = FactoryManager.AttrFactory.GetWeaponBaseAttr(weaponType);
            GameObject weaponGO = FactoryManager.AssetFactory.LoadWeapon(baseAttr.AssetName);

            switch (weaponType)
            {
                case WeaponType.Gun:
                    weapon = new WeaponGun(baseAttr, weaponGO);
                    break;
                case WeaponType.Rifle:
                    weapon = new WeaponRifle(baseAttr, weaponGO);
                    break;
                case WeaponType.Rocket:
                    weapon = new WeaponRocket(baseAttr, weaponGO);
                    break;
              
            }

            return weapon;
        }
    }
}
