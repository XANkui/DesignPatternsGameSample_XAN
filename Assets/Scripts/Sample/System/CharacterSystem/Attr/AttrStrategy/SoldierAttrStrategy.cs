using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DesignPattern_Sample_XAN { 

	public class SoldierAttrStrategy : IAttrStrategy
	{
        public int GetExtraHPValue(int lv)
        {
            return (lv - 1) * 10;
        }

        public int GetDmgDescValue(int lv)
        {
            return (lv - 1) * 5;
        }

        public int GetCritDmg(float critRate)
        {
            return 0;
        }
    }
}
