using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DesignPattern_Sample_XAN { 

	public class TrainSoldierCommand : ITrainCommand
	{
        SoldierType mSoldierType;
        WeaponType mWeaponType;
        Vector3 mSpawnPosition;
        int mLv;

        public TrainSoldierCommand(SoldierType mSoldierType, WeaponType mWeaponType, Vector3 mSpawnPosition, int mLv)
        {
            this.mSoldierType = mSoldierType;
            this.mWeaponType = mWeaponType;
            this.mSpawnPosition = mSpawnPosition;
            this.mLv = mLv;
        }

        public override void Excute()
        {
            switch (mSoldierType)
            {
                case SoldierType.Rookie:
                    FactoryManager.SoldierFactory.CreateCharacter<SoldierRookie>(mWeaponType,mSpawnPosition,mLv);
                    break;
                case SoldierType.Sergeant:
                    FactoryManager.SoldierFactory.CreateCharacter<SoldierSergeant>(mWeaponType, mSpawnPosition, mLv);
                    break;
                case SoldierType.Captain:
                    FactoryManager.SoldierFactory.CreateCharacter<SoldierCaptain>(mWeaponType, mSpawnPosition, mLv);
                    break;
                default:
                    Debug.LogError(GetType()+ "/Excute()/ There is not mSoldierType :" + mSoldierType.ToString());

                    break;
            }
        }
    }
}
