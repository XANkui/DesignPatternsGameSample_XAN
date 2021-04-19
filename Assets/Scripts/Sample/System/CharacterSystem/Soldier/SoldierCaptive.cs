using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DesignPattern_Sample_XAN { 

	public class SoldierCaptive : ISoldier
	{
        private IEnemy mEnemy;

        public SoldierCaptive(IEnemy enemy) {
            mEnemy = enemy;

            ICharacterAttr attr = new SoldierAttr(enemy.Attr.AttrStrategy,1,enemy.Attr.BaseAttr);

            this.Attr = attr;
            this.CGameObject = enemy.CGameObject;
            this.Weapon = enemy.Weapon;

        }

        protected override void PlaySound()
        {
            return;
        }

        protected override void PlayEffect()
        {
            mEnemy.PlayEffect();
        }
    }
}
