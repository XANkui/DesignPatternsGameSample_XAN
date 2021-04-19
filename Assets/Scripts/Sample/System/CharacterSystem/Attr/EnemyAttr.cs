using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DesignPattern_Sample_XAN {

    public class EnemyAttr : ICharacterAttr
    {
        public EnemyAttr(IAttrStrategy strategy, int lv, CharactorBaseAttr baseAttr) : base(strategy, lv, baseAttr)
        {
        }
    }
}
