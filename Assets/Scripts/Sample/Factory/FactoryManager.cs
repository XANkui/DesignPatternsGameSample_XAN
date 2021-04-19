using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DesignPattern_Sample_XAN { 

	public static class FactoryManager 
	{
		private static IAssetFactory mAssetFactory  =null;
		private static ICharactorFactory mSoldierFactory = null;
		private static ICharactorFactory mEnemyFactory = null;
		private static IWeaponFactory mWeaponFactory = null;
		private static IAttrFactory mAttrFactory = null;

		public static IAssetFactory AssetFactory {
			get {
                if (mAssetFactory==null)
                {
					//mAssetFactory = new ResourecesAssetFactory();
					mAssetFactory = new ResourcesAssetProxyFactory();
                }

				return mAssetFactory;
			}
		}

		public static ICharactorFactory SoldierFactory
		{
			get
			{
				if (mSoldierFactory == null)
				{
					mSoldierFactory = new SoldierFactory();
				}

				return mSoldierFactory;
			}
		}

		public static ICharactorFactory EnemyFactory
		{
			get
			{
				if (mEnemyFactory == null)
				{
					mEnemyFactory = new EnemyFactory();
				}

				return mEnemyFactory;
			}
		}

		public static IWeaponFactory WeaponFactory
		{
			get
			{
				if (mWeaponFactory == null)
				{
					mWeaponFactory = new WeaponFactory();
				}

				return mWeaponFactory;
			}
		}

		public static IAttrFactory AttrFactory
		{
			get
			{
				if (mAttrFactory == null)
				{
					mAttrFactory = new AttrFactory();
				}

				return mAttrFactory;
			}
		}
	}
}
