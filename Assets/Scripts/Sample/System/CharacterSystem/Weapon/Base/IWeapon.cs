using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DesignPattern_Sample_XAN
{

	public enum WeaponType { 
		Gun =0,
		Rifle,
		Rocket,
		Max
	}

	public abstract class IWeapon 
	{
		WeaponBaseAttr mBaseAttr;
		//protected int mAtkPlusValue;

		protected GameObject mGameObject;		
		protected ParticleSystem mParticle;
		protected LineRenderer mLineRenderer;
		protected Light mLight;
		protected AudioSource mAudioSource;
		protected ICharacter mOwner;

		protected float mEffectDisplayTime = 0;

		public float AtkRange { get { return mBaseAttr.AtkRange; } }
		public int Atk { get { return mBaseAttr.Atk; } }

		public ICharacter Owner { set { mOwner = value; } }

		public GameObject WGameObject { get { return mGameObject; } }

		public IWeapon(WeaponBaseAttr baseAttr, GameObject gameObject) {
			mBaseAttr = baseAttr;

			mGameObject = gameObject;

			Transform effect = mGameObject.transform.Find("Effect");
			mParticle = effect.GetComponent<ParticleSystem>();
			mLineRenderer = effect.GetComponent<LineRenderer>();
			mLight = effect.GetComponent<Light>();
			mAudioSource = effect.GetComponent<AudioSource>();
		}

		public void Update() {
            if (mEffectDisplayTime>0)
            {
				mEffectDisplayTime -= Time.deltaTime;

                if (mEffectDisplayTime <= 0)
                {
					DisableEffect();

				}
            }
		}

		public void Fire(Vector3 targetPosition) {
			// 枪口特效
			PlayMuzzleEffect();

			// 子弹轨迹
			PlayBulletEffect(targetPosition);

			// 设置特效时间
			SetEffectDisplayTime();

			// 播放声音
			PlaySound();
		}

		protected virtual void PlayMuzzleEffect() {
			mParticle.Stop();
			mParticle.Play();
			mLight.enabled = true;
		}

		protected abstract void PlayBulletEffect(Vector3 targetPosition);

		protected void DoPlayBulletEffect(float  width, Vector3 targetPosition) {
			mLineRenderer.enabled = true;
			mLineRenderer.startWidth = 0.05f;
			mLineRenderer.endWidth = 0.05f;
			mLineRenderer.SetPosition(0, mGameObject.transform.position);
			mLineRenderer.SetPosition(1, targetPosition);
		}
		protected abstract void SetEffectDisplayTime();

		protected abstract void PlaySound();

		protected void DoPlaySound(string clipName)
		{

			AudioClip clip = FactoryManager.AssetFactory.LoadAudioClip(clipName); 
			mAudioSource.clip = clip;
			mAudioSource.Play();
		}

		protected virtual void DisableEffect() {
			mLight.enabled = false;
			mLineRenderer.enabled = false;
		}

		
	}
}
