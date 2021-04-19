using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace DesignPattern_Sample_XAN
{ 

	public abstract class ICharacter 
	{

		protected ICharacterAttr mAttr;
		protected GameObject mGameObject;
		protected NavMeshAgent mNaNavMeshAgent;
		protected AudioSource mAudioSource;

		protected Animation mAnimation;

		protected IWeapon mWeapon;

		protected bool mIsKilled = false;
		protected bool mIsCanDestroy = false;

		private float mDestroyTime = 2;
		private float mDestroyTimer = 0;

		public float AtkRange { get { return mWeapon.AtkRange; } }
		public ICharacterAttr Attr { get => mAttr; set { mAttr = value; } }
		public Vector3 Position {
			get {
				if (mGameObject == null)
				{
					Debug.LogError(GetType() + "/GetPositoin()/ mGameObject is null");
					return Vector3.zero;
				}

				return mGameObject.transform.position;
			}
		}

		public GameObject CGameObject {
			set {
				mGameObject = value;
				mNaNavMeshAgent = mGameObject.GetComponent<NavMeshAgent>();
				mAudioSource = mGameObject.GetComponent<AudioSource>();
				mAnimation = mGameObject.GetComponentInChildren<Animation>();
			}
			get => mGameObject;
		}

		public IWeapon Weapon {
			set {
				mWeapon = value;
				mWeapon.Owner = this;

				GameObject child = UnityTool.FindChild(mGameObject, "weapon-point");
				UnityTool.Attach(child, mWeapon.WGameObject);
			}

			get => mWeapon;
		}

		public bool IsKilled => mIsKilled;
		public bool IsCanDestroy => mIsCanDestroy;

		public abstract void RunVisitor(ICharactorVisitor visitor);

		public void Update() {
            if (mIsKilled==true)
            {
				
				mDestroyTimer -= Time.deltaTime;
                if (mDestroyTimer <= 0)
                {

					mIsCanDestroy = true;
                }

				return;
            }

			mWeapon.Update();
		}

		public abstract void UpdateFSMAI(List<ICharacter> targetLst);

		public void Attack(ICharacter target) {
			mWeapon.Fire(target.Position);
			mGameObject.transform.LookAt(target.Position);
			PlayAnim("attack");
			target.UnderAttack(mWeapon.Atk+mAttr.CritValue);
		}

		public virtual void UnderAttack(int damage) {
			mAttr.TakeDamage(damage);

			// 被攻击的效果

			// 死亡的效果
		}

		public virtual void Killed() {

			mIsKilled = true;
			mNaNavMeshAgent.Stop();
			mDestroyTimer = mDestroyTime;

		}

		public void Release() {
			
			GameObject.Destroy(mGameObject);
		}

		public void PlayAnim(string animName) {
			mAnimation.CrossFade(animName);
		}

		public void MoveTo(Vector3 targetPosition) {
			mNaNavMeshAgent.SetDestination(targetPosition);
			PlayAnim("move");
		}

		protected void DoPlayEffect(string effectName)
		{
			// 加载特效
			GameObject effectGo = FactoryManager.AssetFactory.LoadEffect(effectName) ;
			effectGo.transform.position = Position;
			// 特效销毁
			effectGo.AddComponent<DestroySelfForTime>();
		}

		protected void DoPlaySound(string soundName)
		{
			AudioClip clip = FactoryManager.AssetFactory.LoadAudioClip(soundName) ;  
			mAudioSource.clip = clip;
			mAudioSource.Play();
		}

	}
}
