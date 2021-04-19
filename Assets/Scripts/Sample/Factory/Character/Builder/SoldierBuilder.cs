using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DesignPattern_Sample_XAN { 

	public class SoldierBuilder : ICharactorBuilder
	{
        public SoldierBuilder(ICharacter character, Type t, WeaponType weaponType, Vector3 spawnPosition, int lv) : base(character, t, weaponType, spawnPosition, lv)
        {
        }

        public override void AddCharactorAttr()
        {
            CharactorBaseAttr baseAttr = FactoryManager.AttrFactory.GetCharactorBaseAttr(mT);
            mPrefabName = baseAttr.PrefabName;
            ICharacterAttr attr = new SoldierAttr(new SoldierAttrStrategy(), mLv, baseAttr);            
            mCharacter.Attr = attr;
        }

        public override void AddGameObject()
        {
            GameObject charactorGO = FactoryManager.AssetFactory.LoadSoldier(mPrefabName);
            charactorGO.transform.position = mSpawnPosition;
            mCharacter.CGameObject = charactorGO;
        }

        public override void AddWeapon()
        {
            IWeapon weapon = FactoryManager.WeaponFactory.CreateWeapon(mWeaponType);
            mCharacter.Weapon = weapon;
        }

        public override ICharacter GetResult()
        {
            return mCharacter;
        }

        public override void AddInCharactorSystem()
        {
            PlayGameFacade.Instance.AddSoldierToCharactorSystem(mCharacter as ISoldier);
        }
    }
}
