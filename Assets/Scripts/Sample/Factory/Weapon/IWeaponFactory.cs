using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DesignPattern_Sample_XAN { 

	public interface IWeaponFactory 
	{
		IWeapon CreateWeapon(WeaponType weaponType);
	}
}
