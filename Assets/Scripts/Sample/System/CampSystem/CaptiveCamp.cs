using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DesignPattern_Sample_XAN { 

	public class CaptiveCamp : ICamp
	{
        private WeaponType mWeaponType = WeaponType.Gun;
        private int mEnergyCostTrain;
        private EnemyType mEnemyType;
        public CaptiveCamp(GameObject mGameObject, string mName, string mIconSprite, EnemyType enemyType, Vector3 mPosition, float mTrainTime, WeaponType weaponType = WeaponType.Gun, int lv = 1) : base(mGameObject, mName, mIconSprite, SoldierType.Captive, mPosition, mTrainTime)
        {
            mEnemyType = enemyType;
            mEnergyCostStrategy = new SoldierEnergyCostStrategy();
            UpdateEnergyCostValues();
        }

        public override int Lv => 1;

        public override WeaponType WeaponType => mWeaponType;

        public override int EnergyCostUpgradeCamp => 0;

        public override int EnergyCostUpgradeWeapon => 0;

        public override int EnergyCostTrainSoldier => mEnergyCostTrain;

        public override void Train()
        {
            TrainCaptiveCommand cmd = new TrainCaptiveCommand(mEnemyType,mWeaponType,mPosition,1);
            AddTRainCommand(cmd);
        }

        public override void UpdateEnergyCostValues()
        {
            mEnergyCostTrain = mEnergyCostStrategy.GetSoldierTrainCost(mSoldierType,1);
        }

        public override void UpgradeCamp()
        {
            return;
        }

        public override void UpgradeWeapon()
        {
            return;
        }
    }
}
