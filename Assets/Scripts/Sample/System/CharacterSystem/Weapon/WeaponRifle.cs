using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DesignPattern_Sample_XAN { 

	public class WeaponRifle : IWeapon
	{
        public WeaponRifle(WeaponBaseAttr baseAttr, GameObject gameObject) : base(baseAttr, gameObject)
        {
        }

        protected override void PlayBulletEffect(Vector3 targetPosition)
        {
            DoPlayBulletEffect(0.1f, targetPosition);
        }

        protected override void SetEffectDisplayTime()
        {
            mEffectDisplayTime = 0.2f;
        }

        protected override void PlaySound()
        {
            DoPlaySound("RifleShot");
        }
    }
}
