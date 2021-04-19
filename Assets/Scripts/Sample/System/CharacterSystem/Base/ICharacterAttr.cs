using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DesignPattern_Sample_XAN { 

	public class ICharacterAttr 
	{

		protected CharactorBaseAttr mBaseAttr;

		protected int mLv;  // 战士等级
		protected int mCurHp;		
		protected int mDmgDescValue;

		protected IAttrStrategy mAttrStrategy;

		public IAttrStrategy AttrStrategy => mAttrStrategy;

		public CharactorBaseAttr BaseAttr => mBaseAttr;

		public ICharacterAttr(IAttrStrategy strategy, int lv, CharactorBaseAttr baseAttr) {

			mLv = lv;
			mBaseAttr = baseAttr;
			mAttrStrategy = strategy;
			mDmgDescValue = mAttrStrategy.GetDmgDescValue(mLv);
			mCurHp = mBaseAttr.MaxHp + mAttrStrategy.GetExtraHPValue(mLv);
		}

		public int CritValue { get { return mAttrStrategy.GetCritDmg(mBaseAttr.CritRate); } }

		public int CurHp { get { return mCurHp; } }

		public void TakeDamage(int damage) {
			damage -= mDmgDescValue;
            if (damage <5)
            {
				damage = 5;
            }
			mCurHp -= damage;
		}
	}
}
