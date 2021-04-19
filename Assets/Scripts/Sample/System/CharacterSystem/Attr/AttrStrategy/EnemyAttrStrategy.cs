using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DesignPattern_Sample_XAN { 

	public class EnemyAttrStrategy : IAttrStrategy
	{
        public int GetExtraHPValue(int lv)
        {
            return 0;
        }

        public int GetDmgDescValue(int lv)
        {
            return 0;
        }

        public int GetCritDmg(float critRate)
        {
            if (Random.Range(0.0f,1.0f)< critRate)
            {
                return (int)(10 * Random.Range(0.5f, 1.0f));
            }

            return 0;
        }
    }
}
