using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DesignPattern_Sample_XAN { 

	public class AttrFactory : IAttrFactory
	{
        private Dictionary<Type, CharactorBaseAttr> mCharactorBaseAttrDict;
        private Dictionary<WeaponType, WeaponBaseAttr> mWeaponBaseAttrDict;

        public AttrFactory() {

            InitCharactorBaseAttr();
            InitWeaponBaseAttr();
        }

        void InitCharactorBaseAttr() {
            mCharactorBaseAttrDict = new Dictionary<Type, CharactorBaseAttr>();
            mCharactorBaseAttrDict.Add(typeof(SoldierRookie), new CharactorBaseAttr("新手士兵", 80,2.5f, "RookieIcon", "Soldier2",0));
            mCharactorBaseAttrDict.Add(typeof(SoldierSergeant), new CharactorBaseAttr("中尉士兵", 90,3f, "SergeantIcon", "Soldier3", 0));
            mCharactorBaseAttrDict.Add(typeof(SoldierCaptain), new CharactorBaseAttr("上尉士兵", 100,3f, "CaptainIcon", "Soldier1", 0));

            mCharactorBaseAttrDict.Add(typeof(EnemyElf), new CharactorBaseAttr("小精灵", 100,3f, "ElfIcon", "Enemy1", 0.2f));
            mCharactorBaseAttrDict.Add(typeof(EnemyOgre), new CharactorBaseAttr("怪物", 128,4f, "OgreIcon", "Enemy2", 0.3f));
            mCharactorBaseAttrDict.Add(typeof(EnemyTroll), new CharactorBaseAttr("巨魔", 200,1f, "TrollIcon", "Enemy3", 0.4f));
        }

        void InitWeaponBaseAttr() {
            mWeaponBaseAttrDict = new Dictionary<WeaponType, WeaponBaseAttr>();
            mWeaponBaseAttrDict.Add(WeaponType.Gun, new WeaponBaseAttr("手枪", 20,5,"WeaponGun")) ;
            mWeaponBaseAttrDict.Add(WeaponType.Rifle, new WeaponBaseAttr("长枪", 30,7,"WeaponRifle")) ;
            mWeaponBaseAttrDict.Add(WeaponType.Rocket, new WeaponBaseAttr("火箭", 40,8,"WeaponRocket")) ;
        }

        public CharactorBaseAttr GetCharactorBaseAttr(Type t)
        {
            if (mCharactorBaseAttrDict.ContainsKey(t) == false)
            {
                Debug.LogError(GetType()+ "/GetCharactorBaseAttr()/mCharactorBaseAttrDict is not Contained : " + t);
                return null;
            }

            return mCharactorBaseAttrDict[t];
        }

        public WeaponBaseAttr GetWeaponBaseAttr(WeaponType weaponType)
        {
            if (mWeaponBaseAttrDict.ContainsKey(weaponType) == false)
            {
                Debug.LogError(GetType() + "/GetWeaponBaseAttr()/mWeaponBaseAttrDict is not Contained : " + weaponType);
                return null;
            }

            return mWeaponBaseAttrDict[weaponType];
        }
    }
}
