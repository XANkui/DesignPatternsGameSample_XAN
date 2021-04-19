using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DesignPattern_Sample_XAN
{ 

	public class SoldierRookie : ISoldier
	{
        protected override void PlaySound()
        {
            DoPlaySound("RookieDeath");
        }

        protected override void PlayEffect()
        {
            DoPlayEffect("RookieDeadEffect");
        }
    }
}
