using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DesignPattern_Sample_XAN { 

	public class EnemyElf : IEnemy
	{
        public override void PlayEffect()
        {
            DoPlayEffect("ElfHitEffect");
        }
    }
}
