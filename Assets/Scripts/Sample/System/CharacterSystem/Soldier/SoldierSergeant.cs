using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DesignPattern_Sample_XAN
{ 

	public class SoldierSergeant : ISoldier
	{
        protected override void PlaySound()
        {
            DoPlaySound("SergeantDeath");
        }

        protected override void PlayEffect()
        {
            DoPlayEffect("SergeantDeadEffect");
        }
    }
}
