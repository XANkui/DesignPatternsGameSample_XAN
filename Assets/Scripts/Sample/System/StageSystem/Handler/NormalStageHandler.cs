using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DesignPattern_Sample_XAN { 

	public class NormalStageHandler : IStageHandler
	{
        private EnemyType mEnemyType;
        private WeaponType mWeaponType;
        private int mCount;
        private Vector3 mPosition;


        private int mSpawnTime = 1;
        private float mSpawnTimer = 0;
        private int mCountSpawned = 0;

        public NormalStageHandler(int mLv, int mCountToFinish,StageSystem mStageSystem, EnemyType mEnemyType, WeaponType mWeaponType, int mCount, Vector3 mPosition) : base(mLv, mCountToFinish, mStageSystem)
        {
            this.mEnemyType = mEnemyType;
            this.mWeaponType = mWeaponType;
            this.mCount = mCount;
            this.mPosition = mPosition;

            mSpawnTimer = mSpawnTime;
        }

        protected override void UpdateStage()
        {
            if (mCountSpawned < mCount)
            {
                mSpawnTimer -= Time.deltaTime;
                if (mSpawnTimer<=0)
                {
                    SpawnEnemy();
                    mSpawnTimer = mSpawnTime;
                }
            }
        }

        private void SpawnEnemy()
        {
            mCountSpawned++;
            switch (mEnemyType)
            {
                case EnemyType.Elf:
                    FactoryManager.EnemyFactory.CreateCharacter<EnemyElf>(mWeaponType,mPosition);
                    break;
                case EnemyType.Ogre:
                    FactoryManager.EnemyFactory.CreateCharacter<EnemyOgre>(mWeaponType, mPosition);
                    break;
                case EnemyType.Troll:
                    FactoryManager.EnemyFactory.CreateCharacter<EnemyTroll>(mWeaponType, mPosition);
                    break;
                default:
                    Debug.LogError(GetType()+ "/()/ The EnemyType had not been setted: "+ mEnemyType.ToString());
                    break;
            }
        }
    }
}
