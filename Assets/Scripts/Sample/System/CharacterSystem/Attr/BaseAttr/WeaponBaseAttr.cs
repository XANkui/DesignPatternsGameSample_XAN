using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DesignPattern_Sample_XAN { 

	public class WeaponBaseAttr 
	{
		protected string mName;
		protected int mAtk;
		protected float mAtkRange;
		protected string mAssetName;

        public WeaponBaseAttr(string mName, int mAtk, float mAtkRange, string mAssetName)
        {
            this.mName = mName;
            this.mAtk = mAtk;
            this.mAtkRange = mAtkRange;
            this.mAssetName = mAssetName;
        }

        public string Name { get { return mName; } }
        public int Atk { get { return mAtk; } }
        public float AtkRange { get { return mAtkRange; } }
        public string AssetName { get { return mAssetName; } }
    }
}
