using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DesignPattern_Sample_XAN { 

	public class CharactorBuilderDirector 
	{
		public static ICharacter Construct(ICharactorBuilder builder) {
			builder.AddCharactorAttr();
			builder.AddGameObject();
			builder.AddWeapon();
			builder.AddInCharactorSystem();

			return builder.GetResult();
		}
	}
}
