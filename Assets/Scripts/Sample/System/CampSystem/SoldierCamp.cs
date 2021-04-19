using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DesignPattern_Sample_XAN {

    public class SoldierCamp : ICamp
    {
        const int MAX_LV = 4;
        private int mLv = 1;
        private WeaponType mWeaponType = WeaponType.Gun;


        public SoldierCamp(GameObject mGameObject, string mName, string mIconSprite, SoldierType mSoldierType, Vector3 mPosition, float mTrainTime, WeaponType weaponType=WeaponType.Gun,int lv=1) : base(mGameObject, mName, mIconSprite, mSoldierType, mPosition, mTrainTime)
        {
            mLv = lv;
            mWeaponType = weaponType;

            mEnergyCostStrategy = new SoldierEnergyCostStrategy();
            UpdateEnergyCostValues();
        }

        public override int Lv => mLv;

        public override WeaponType WeaponType => mWeaponType;

        public override int EnergyCostUpgradeCamp { get { if (mLv >= MAX_LV) return -1; return mEnergyCostUpgradeCamp; } }
        public override int EnergyCostUpgradeWeapon { get { if (mWeaponType+1 >= WeaponType.Max) return -1; return mEnergyCostUpgradeWeapon; } }
        public override int EnergyCostTrainSoldier => mEnergyCostTrainSoldier;

        public override void Train()
        {
            ITrainCommand cmd = new TrainSoldierCommand(mSoldierType,mWeaponType, mPosition, mLv);
            AddTRainCommand(cmd);
        }

        public override void UpdateEnergyCostValues()
        {
            mEnergyCostUpgradeCamp = mEnergyCostStrategy.GetCampUpgradeCost(mSoldierType,mLv);
            mEnergyCostUpgradeWeapon = mEnergyCostStrategy.GetWeaponUpgradeCost(mWeaponType);
            mEnergyCostTrainSoldier = mEnergyCostStrategy.GetSoldierTrainCost(mSoldierType,mLv);
        }

        public override void UpgradeCamp()
        {
            mLv++;

            UpdateEnergyCostValues();
        }

        public override void UpgradeWeapon()
        {
            mWeaponType = mWeaponType + 1;

            UpdateEnergyCostValues();
        }
    }
}
