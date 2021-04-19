using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DesignPattern_Sample_XAN { 

	public class TrainCaptiveCommand : ITrainCommand
	{
        private EnemyType mEnemyType;
        private WeaponType mWeaponType;

        private Vector3 mPosition;
        private int mLv;

        public TrainCaptiveCommand(EnemyType mEnemyType, WeaponType mWeaponType, Vector3 mPosition, int mLv)
        {
            this.mEnemyType = mEnemyType;
            this.mWeaponType = mWeaponType;
            this.mPosition = mPosition;
            this.mLv = mLv;
        }

        public override void Excute()
        {
            IEnemy enemy = null;
            switch (mEnemyType)
            {
                case EnemyType.Elf:
                    enemy = FactoryManager.EnemyFactory.CreateCharacter<EnemyElf>(mWeaponType,mPosition) as IEnemy;
                    break;
                case EnemyType.Ogre:
                    enemy = FactoryManager.EnemyFactory.CreateCharacter<EnemyOgre>(mWeaponType, mPosition) as IEnemy;

                    break;
                case EnemyType.Troll:
                    enemy = FactoryManager.EnemyFactory.CreateCharacter<EnemyTroll>(mWeaponType, mPosition) as IEnemy;

                    break;
                default:
                    Debug.Log(GetType()+ "/Excute()/ There is no one in EnemyType :"+mEnemyType.ToString());

                    break;
            }

            PlayGameFacade.Instance.RemoveEnemyToCharactorSystem(enemy);
            SoldierCaptive captive = new SoldierCaptive(enemy);
            PlayGameFacade.Instance.AddSoldierToCharactorSystem(captive);
        }
    }
}
