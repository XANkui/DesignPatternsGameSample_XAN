using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DesignPattern_Sample_XAN { 

	public class WeaponGun : IWeapon
	{
        public WeaponGun(WeaponBaseAttr baseAttr, GameObject gameObject) : base(baseAttr, gameObject)
        {
        }

        protected override void PlayBulletEffect(Vector3 targetPosition)
        {
            DoPlayBulletEffect(0.05f, targetPosition);
        }

        protected override void SetEffectDisplayTime()
        {
            mEffectDisplayTime = 0.1f;
        }

        protected override void PlaySound()
        {
            DoPlaySound("GunShot");
        }
    }
}
