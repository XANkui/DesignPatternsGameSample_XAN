using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DesignPattern_Sample_XAN { 

	public class ResourecesAssetFactory : IAssetFactory
	{
        public const string SoldierPath = "Characters/Soldier/";
        public const string EnemyPath = "Characters/Enemy/";
        public const string WeaponPath = "Weapons/";
        public const string EffectPath = "Effects/";
        public const string AudioPath = "Audios/";
        public const string SpritePath = "Sprites/";

        public GameObject LoadSoldier(string name)
        {
            return InstantiateGameObject(SoldierPath + name);
        }

        public GameObject LoadEnemy(string name)
        {
            return InstantiateGameObject(EnemyPath + name);
        }

        public GameObject LoadWeapon(string name)
        {
            return InstantiateGameObject(WeaponPath + name);
        }

        public GameObject LoadEffect(string name)
        {
            return InstantiateGameObject(EffectPath+name);
        }

        public AudioClip LoadAudioClip(string name)
        {
            return LoadAsset<AudioClip>(AudioPath + name) as AudioClip;
        }

        public Sprite LoadSprite(string name)
        {
            return LoadAsset<Sprite>(SpritePath + name) as Sprite;
        }

        private GameObject InstantiateGameObject(string path) {
            GameObject o = LoadAsset<GameObject>(path);
            if (o==null)
            {
                Debug.LogError(GetType()+ "/InstantiateGameObject()/ Resource load failed, Path is :"+path);
                return null;
            }

            return GameObject.Instantiate(o);
        }

        public T LoadAsset<T>(string path) where T : Object
        {
            T o = Resources.Load<T>(path);
            if (o == null)
            {
                Debug.LogError(GetType() + "/LoadAsset()/ Resource load failed, Path is :" + path);
                return null;
            }

            return o;
        }
    }
}
