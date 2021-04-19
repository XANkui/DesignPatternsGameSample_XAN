using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DesignPattern_Sample_XAN { 

	public interface ICharactorFactory 
	{
		ICharacter CreateCharacter<T>(WeaponType weaponType, Vector3 spawnPosition, int lv=1)where T :ICharacter,new();
	}
}
