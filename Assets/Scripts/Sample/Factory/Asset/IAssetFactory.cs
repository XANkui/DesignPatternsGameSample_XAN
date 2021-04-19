using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DesignPattern_Sample_XAN { 

	public interface IAssetFactory 
	{
		GameObject LoadSoldier(string name);
		GameObject LoadEnemy(string name);
		GameObject LoadWeapon(string name);
		GameObject LoadEffect(string name);
		AudioClip LoadAudioClip(string name);
		Sprite LoadSprite(string name);
	}
}
