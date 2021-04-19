using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DesignPattern_Sample_XAN
{ 

	public class SoldierCaptain : ISoldier
	{
        protected override void PlaySound()
        {
            DoPlaySound("CaptainDeath");
        }

        protected override void PlayEffect()
        {
            DoPlayEffect("CaptainDeadEffect");
        }
    }
}
