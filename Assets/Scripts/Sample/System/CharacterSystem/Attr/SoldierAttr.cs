using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DesignPattern_Sample_XAN
{

    public class SoldierAttr : ICharacterAttr
    {
        public SoldierAttr(IAttrStrategy strategy, int lv, CharactorBaseAttr baseAttr) : base(strategy, lv, baseAttr)
        {
        }
    }
}
