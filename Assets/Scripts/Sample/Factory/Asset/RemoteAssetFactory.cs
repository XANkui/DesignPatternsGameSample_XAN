﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DesignPattern_Sample_XAN { 

	public class RemoteAssetFactory : IAssetFactory
	{
        public GameObject LoadSoldier(string name)
        {
            throw new System.NotImplementedException();
        }

        public GameObject LoadEnemy(string name)
        {
            throw new System.NotImplementedException();
        }

        public GameObject LoadWeapon(string name)
        {
            throw new System.NotImplementedException();
        }

        public GameObject LoadEffect(string name)
        {
            throw new System.NotImplementedException();
        }

        public AudioClip LoadAudioClip(string name)
        {
            throw new System.NotImplementedException();
        }

        public Sprite LoadSprite(string name)
        {
            throw new System.NotImplementedException();
        }
    }
}
