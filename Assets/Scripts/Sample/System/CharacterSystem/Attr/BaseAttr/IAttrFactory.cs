using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DesignPattern_Sample_XAN { 

	public interface IAttrFactory 
	{
		CharactorBaseAttr GetCharactorBaseAttr(System.Type t);
		WeaponBaseAttr GetWeaponBaseAttr(WeaponType weaponType);
	}
}
