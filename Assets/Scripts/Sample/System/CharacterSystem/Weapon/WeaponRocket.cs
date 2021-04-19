using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DesignPattern_Sample_XAN { 

	public class WeaponRocket : IWeapon
	{
        public WeaponRocket(WeaponBaseAttr baseAttr, GameObject gameObject) : base(baseAttr, gameObject)
        {
        }

        protected override void PlayBulletEffect(Vector3 targetPosition)
        {
            DoPlayBulletEffect(0.3f, targetPosition);
        }

        protected override void SetEffectDisplayTime()
        {
            mEffectDisplayTime = 0.3f;
        }

        protected override void PlaySound()
        {
            DoPlaySound("RocketShot");
        }
    }
}
