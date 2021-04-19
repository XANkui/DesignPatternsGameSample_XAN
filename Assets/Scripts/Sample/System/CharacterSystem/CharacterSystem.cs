using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DesignPattern_Sample_XAN
{ 

	public class CharacterSystem : IGameSystem
	{
        private List<ICharacter> mEnemysLst = new List<ICharacter>();
        private List<ICharacter> mSoldiersLst = new List<ICharacter>();

        public void AddEnemy(IEnemy enemy) {
            mEnemysLst.Add(enemy);
        }

        public void RemoveEnemy(IEnemy enemy) {
            mEnemysLst.Remove(enemy);
        }

        public void AddSoldier(ISoldier soldier)
        {
            mSoldiersLst.Add(soldier);
        }

        public void RemoveSoldier(ISoldier soldier)
        {
            mSoldiersLst.Remove(soldier);
        }

        public override void Update()
        {

            UpdateEnemys();
            UpdateSoldiers();

            RemoveCharactorIsKilled(mEnemysLst);
            RemoveCharactorIsKilled(mSoldiersLst);
        }

        public void RunVisitor(ICharactorVisitor visitor) {
            foreach (ICharacter character in mEnemysLst)
            {
                character.RunVisitor(visitor);
            }

            foreach (ICharacter character in mSoldiersLst)
            {
                character.RunVisitor(visitor);
            }
        }


        private void UpdateEnemys() {
            foreach (IEnemy enemy in mEnemysLst)
            {
                enemy.Update();
                enemy.UpdateFSMAI(mSoldiersLst);
            }
        }

        private void UpdateSoldiers() {
            foreach (ISoldier soldier in mSoldiersLst)
            {
                soldier.Update();
                soldier.UpdateFSMAI(mEnemysLst);
            }
        }


        private void RemoveCharactorIsKilled(List<ICharacter> characters)
        {
            
            List<ICharacter> canDestroyes = new List<ICharacter>();
            foreach (ICharacter character in characters)
            {
                if (character.IsCanDestroy==true)
                {
                    
                    canDestroyes.Add(character);
                }
            }

            foreach (ICharacter character in canDestroyes)
            {
                characters.Remove(character);
                character.Release();
            }
        }
    }
}
