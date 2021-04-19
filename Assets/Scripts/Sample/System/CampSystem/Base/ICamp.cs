using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DesignPattern_Sample_XAN { 

	public abstract class ICamp 
	{
		protected GameObject mGameObject;
		protected string mName;
		protected string mIconSprite;
		protected SoldierType mSoldierType;
		protected Vector3 mPosition;    // 集合点
		protected float mTrainTime;

        protected IEnergyCostStrategy mEnergyCostStrategy;
        protected int mEnergyCostUpgradeCamp;
        protected int mEnergyCostUpgradeWeapon;
        protected int mEnergyCostTrainSoldier;

        private float mTrainTimer; // 训练计时器
        private List<ITrainCommand> mTrainCommandLst;

        public string Name { get => mName; }
        public string IconSprite { get => mIconSprite; }
        public int TrainCount { get => mTrainCommandLst.Count; }
        public float TrainRemainTime { get => mTrainTimer; }

        public ICamp(GameObject mGameObject, string mName, string mIconSprite, SoldierType mSoldierType, Vector3 mPosition, float mTrainTime)
        {
            this.mGameObject = mGameObject;
            this.mName = mName;
            this.mIconSprite = mIconSprite;
            this.mSoldierType = mSoldierType;
            this.mPosition = mPosition;
            this.mTrainTime = mTrainTime;

            this.mTrainTimer = mTrainTime;
            mTrainCommandLst = new List<ITrainCommand>();
        }

        public abstract int Lv { get; }
        public abstract WeaponType WeaponType { get; }

        public abstract int EnergyCostUpgradeCamp { get; }
        public abstract int EnergyCostUpgradeWeapon { get; }
        public abstract int EnergyCostTrainSoldier { get; }

        public abstract void Train();

        public abstract void UpdateEnergyCostValues();
        public abstract void UpgradeCamp();
        public abstract void UpgradeWeapon();

        

        public virtual void Update() {
            UpdateTrainCommand();
        }

        void UpdateTrainCommand() {
            if (mTrainCommandLst.Count<=0)
            {
                return;
            }

            mTrainTimer -= Time.deltaTime;
            if (mTrainTimer <= 0)
            {
                mTrainCommandLst[0].Excute();
                mTrainCommandLst.RemoveAt(0);
                mTrainTimer = mTrainTime;
            }
        }
        

        public void CancelTrain() {
            if (mTrainCommandLst.Count > 0)
            {
                mTrainCommandLst.RemoveAt(mTrainCommandLst.Count - 1);

                if (mTrainCommandLst.Count<=0)
                {
                    mTrainTimer = mTrainTime;
                }
            }
        }

        protected void AddTRainCommand(ITrainCommand cmd) {
            mTrainCommandLst.Add(cmd);
        }
    }
}
