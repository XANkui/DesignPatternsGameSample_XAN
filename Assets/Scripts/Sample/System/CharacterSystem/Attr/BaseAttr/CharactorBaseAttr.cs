using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DesignPattern_Sample_XAN { 

	public class CharactorBaseAttr 
	{
		protected string mName;
		protected int mMaxHp;
		protected float mMoveSpeed;
		protected string mIconSprite;
		protected string mPrefabName;
		protected float mCritRate;  // 敌人暴击率

        public CharactorBaseAttr(string mName, int mMaxHp, float mMoveSpeed, string mIconSprite, string mPrefabName, float mCritRate)
        {
            this.mName = mName;
            this.mMaxHp = mMaxHp;
            this.mMoveSpeed = mMoveSpeed;
            this.mIconSprite = mIconSprite;
            this.mPrefabName = mPrefabName;
            this.mCritRate = mCritRate;
        }

		public string Name { get { return mName; } }
		public int MaxHp { get { return mMaxHp; } }
		public float MoveSpeed { get { return mMoveSpeed; } }
		public string IconSprite { get { return mIconSprite; } }
		public string PrefabName { get { return mPrefabName; } }
		public float CritRate { get { return mCritRate; } }
	}
}
