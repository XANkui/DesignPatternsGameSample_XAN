using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DesignPattern_Sample_XAN { 

	public class ResourcesAssetProxyFactory : IAssetFactory
	{
        private ResourecesAssetFactory mResourecesAssetFactory = new ResourecesAssetFactory();

        private Dictionary<string, GameObject> mSoldierDict = new Dictionary<string, GameObject>();
        private Dictionary<string, GameObject> mEnemyDict = new Dictionary<string, GameObject>();
        private Dictionary<string, GameObject> mWeaponDict = new Dictionary<string, GameObject>();
        private Dictionary<string, GameObject> mEffectDict = new Dictionary<string, GameObject>();
        private Dictionary<string, AudioClip> mAudioClipDict = new Dictionary<string, AudioClip>();
        private Dictionary<string, Sprite> mSpriteDict = new Dictionary<string, Sprite>();

        public GameObject LoadSoldier(string name)
        {
            if (mSoldierDict.ContainsKey(name))
            {
                return GameObject.Instantiate(mSoldierDict[name]);
            }
            else {
                GameObject asset = mResourecesAssetFactory.LoadAsset<GameObject>(ResourecesAssetFactory.SoldierPath+name);
                mSoldierDict.Add(name,asset);
                return GameObject.Instantiate(asset);
            }
        }

        public GameObject LoadEnemy(string name)
        {
            if (mEnemyDict.ContainsKey(name))
            {
                return GameObject.Instantiate(mEnemyDict[name]);
            }
            else
            {
                GameObject asset = mResourecesAssetFactory.LoadAsset<GameObject>(ResourecesAssetFactory.EnemyPath + name);
                mEnemyDict.Add(name, asset);
                return GameObject.Instantiate(asset);
            }
        }

        public GameObject LoadWeapon(string name)
        {
            if (mWeaponDict.ContainsKey(name))
            {
                return GameObject.Instantiate(mWeaponDict[name]);
            }
            else
            {
                GameObject asset = mResourecesAssetFactory.LoadAsset<GameObject>(ResourecesAssetFactory.WeaponPath + name);
                mWeaponDict.Add(name, asset);
                return GameObject.Instantiate(asset);
            }
        }

        public GameObject LoadEffect(string name)
        {
            if (mEffectDict.ContainsKey(name))
            {
                return GameObject.Instantiate(mEffectDict[name]);
            }
            else
            {
                GameObject asset = mResourecesAssetFactory.LoadAsset<GameObject>(ResourecesAssetFactory.EffectPath + name);
                mEffectDict.Add(name, asset);
                return GameObject.Instantiate(asset);
            }
        }

        public AudioClip LoadAudioClip(string name)
        {
            if (mAudioClipDict.ContainsKey(name))
            {
                return (mAudioClipDict[name]);
            }
            else
            {
                AudioClip asset = mResourecesAssetFactory.LoadAsset<AudioClip>(ResourecesAssetFactory.AudioPath + name);
                mAudioClipDict.Add(name, asset);
                return (asset);
            }
        }

        public Sprite LoadSprite(string name)
        {
            if (mSpriteDict.ContainsKey(name))
            {
                return (mSpriteDict[name]);
            }
            else
            {
                Sprite asset = mResourecesAssetFactory.LoadAsset<Sprite>(ResourecesAssetFactory.SpritePath + name);
                mSpriteDict.Add(name, asset);
                return (asset);
            }
        }
    }
}
