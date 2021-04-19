using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DesignPattern_Sample_XAN { 

	public abstract class ICharactorBuilder 
	{
		protected ICharacter mCharacter;
		protected System.Type mT;
		protected WeaponType mWeaponType;
		protected Vector3 mSpawnPosition;
		protected int mLv;

		protected string mPrefabName;
		
		public ICharactorBuilder(ICharacter character, System.Type t, WeaponType weaponType, Vector3 spawnPosition,int lv) {
			mCharacter = character;
			mT = t;
			mWeaponType = weaponType;
			mSpawnPosition = spawnPosition;
			mLv = lv;
		}

		public abstract void AddCharactorAttr();
		public abstract void AddGameObject();
		public abstract void AddWeapon();
		public abstract void AddInCharactorSystem();
		public abstract ICharacter GetResult();
	}
}
