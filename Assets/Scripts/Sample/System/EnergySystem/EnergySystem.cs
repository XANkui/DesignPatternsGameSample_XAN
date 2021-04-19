using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DesignPattern_Sample_XAN
{ 

	public class EnergySystem : IGameSystem
	{
        const int MAX_ENERFY = 100;
        private float mNowEnergy = MAX_ENERFY;

        private float mRecoverEnergySpeed = 3;

        public override void Init()
        {
            base.Init();
        }

        public override void Update()
        {
            base.Update();
            PlayGameFacade.UpdateEnergySliderTextInfo((int)mNowEnergy, MAX_ENERFY);
            if (mNowEnergy >= MAX_ENERFY) return;

            mNowEnergy += mRecoverEnergySpeed * Time.deltaTime;

            mNowEnergy = Mathf.Min(mNowEnergy,MAX_ENERFY);

        }

        public bool TakeEnergy(int value) {

            if (mNowEnergy>=value)
            {
                mNowEnergy -= value;

                return true;
            }

            return false;
        }

        public void RecycleEnergy(int value) {
            mNowEnergy += value;

            mNowEnergy = Mathf.Min(mNowEnergy, MAX_ENERFY);
        }
    }
}
