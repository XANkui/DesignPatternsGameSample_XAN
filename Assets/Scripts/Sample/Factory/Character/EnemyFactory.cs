using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DesignPattern_Sample_XAN { 

	public class EnemyFactory : ICharactorFactory
	{
        public ICharacter CreateCharacter<T>(WeaponType weaponType, Vector3 spawnPosition, int lv = 1) where T : ICharacter,new()
        {
            ICharacter character = new T();

            ICharactorBuilder builder = new EnemyBuilder(character,typeof(T),weaponType,spawnPosition,lv);
            character = CharactorBuilderDirector.Construct(builder);

            return character;
        }
    }
}
