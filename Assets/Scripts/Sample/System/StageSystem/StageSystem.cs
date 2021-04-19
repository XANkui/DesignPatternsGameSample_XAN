using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DesignPattern_Sample_XAN { 

	public class StageSystem : IGameSystem
	{
		private int mLv = 1;
        private List<Vector3> mPosLst;
        private Vector3 mTargetPosition;

        private int mCountOfEnemyKilled = 0;

        private IStageHandler mRootStageHandler;

        public Vector3 TargetPosition => mTargetPosition;

        public int CountOfEnemyKilled { set => mCountOfEnemyKilled = value; }

        public override void Init()
        {
            base.Init();

            InitSpawnAndTargetPosition();
			InitStageChain();

            PlayGameFacade.RegisterObserver(GameEventType.EnemyKilled, new EnemyKilledObserverInStageSystem(this));
        }

        public override void Update()
        {
            base.Update();

            mRootStageHandler.Handle(mLv);
        }

        private void InitSpawnAndTargetPosition()
        {
            mPosLst = new List<Vector3>();
            int i = 1;
            while (true)
            {
                GameObject go = GameObject.Find("EnemySpawnPosition" + i);
                if (go != null)
                {
                    i++;
                    mPosLst.Add(go.transform.position);
                    go.SetActive(false);
                }
                else {
                    break;
                }
            }

            GameObject targetGo = GameObject.Find("TargetPosition");
            mTargetPosition = targetGo.transform.position;
        }

        private Vector3 RandamPosition() {
            return mPosLst[UnityEngine.Random.Range(0, mPosLst.Count)];
        }

        private void InitStageChain()
        {
            int lv = 1;
            NormalStageHandler handler1 = new NormalStageHandler(lv++, 3,this,EnemyType.Elf,WeaponType.Gun,3, RandamPosition());
            NormalStageHandler handler2 = new NormalStageHandler(lv++, 6,this,EnemyType.Elf,WeaponType.Rifle,3, RandamPosition());
            NormalStageHandler handler3 = new NormalStageHandler(lv++,9,this,EnemyType.Elf,WeaponType.Rocket,3, RandamPosition());
            NormalStageHandler handler4 = new NormalStageHandler(lv++,13,this,EnemyType.Ogre,WeaponType.Gun,4, RandamPosition());
            NormalStageHandler handler5 = new NormalStageHandler(lv++,17,this,EnemyType.Ogre,WeaponType.Rifle,4, RandamPosition());
            NormalStageHandler handler6 = new NormalStageHandler(lv++,21,this,EnemyType.Ogre,WeaponType.Rocket,4, RandamPosition());
            NormalStageHandler handler7 = new NormalStageHandler(lv++,26,this,EnemyType.Troll,WeaponType.Gun,5, RandamPosition());
            NormalStageHandler handler8 = new NormalStageHandler(lv++,31,this,EnemyType.Troll, WeaponType.Rifle,5, RandamPosition());
            NormalStageHandler handler9 = new NormalStageHandler(lv++,36,this,EnemyType.Troll, WeaponType.Rocket,5, RandamPosition());

            mRootStageHandler = handler1;
            mRootStageHandler.SetNextStageHandler(handler2)
                .SetNextStageHandler(handler2)
                .SetNextStageHandler(handler3)
                .SetNextStageHandler(handler4)
                .SetNextStageHandler(handler5)
                .SetNextStageHandler(handler6)
                .SetNextStageHandler(handler7)
                .SetNextStageHandler(handler8)
                .SetNextStageHandler(handler9)
                ;
        }

        public int GetCountOfEnemyKilled() {
			return mCountOfEnemyKilled;
		}

		public void EnterNextStage() {

            mLv++;

            PlayGameFacade.NotifySubject(GameEventType.NewStage);
        }
	}
}
