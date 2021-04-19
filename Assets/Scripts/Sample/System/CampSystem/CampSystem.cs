using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DesignPattern_Sample_XAN
{ 

	public class CampSystem : IGameSystem
	{
        private Dictionary<SoldierType, SoldierCamp> mSoldierCampDIc = new Dictionary<SoldierType, SoldierCamp>();
        private Dictionary<EnemyType, CaptiveCamp> mCaptiveCampDIc = new Dictionary<EnemyType, CaptiveCamp>();

        public override void Init()
        {
            base.Init();
            InitCamp(SoldierType.Rookie);
            InitCamp(SoldierType.Sergeant);
            InitCamp(SoldierType.Captain);

            InitCampCaptive(EnemyType.Elf);
        }

        private void InitCamp(SoldierType soldierType) {
            GameObject gameObject = null;
            string gameObjectName = null;
            string name = null;
            string icon = null;
            Vector3 pos = Vector3.zero;
            float trainTime = 0;
            switch (soldierType)
            {
                case SoldierType.Rookie:
                    gameObjectName = "SoldierCamp_Rookie";
                    name = "新手兵营";
                    icon = "RookieCamp";
                    trainTime = 3;
                    break;
                case SoldierType.Sergeant:
                    gameObjectName = "SoldierCamp_Sergeant";
                    name = "中士兵营";
                    icon = "SergeantCamp";
                    trainTime = 4;
                    break;
                case SoldierType.Captain:
                    gameObjectName = "SoldierCamp_Captain";
                    name = "上尉兵营";
                    icon = "CaptainCamp";
                    trainTime = 5;
                    break;
                default:

                    Debug.LogError(GetType()+ "/InitCamp()/Init Failed.The soldierType is not Contained: " + soldierType.ToString());
                    break;
            }

            gameObject = GameObject.Find(gameObjectName);
            pos = UnityTool.FindChild(gameObject, "TrainPoint").transform.position;
            SoldierCamp camp = new SoldierCamp(gameObject,name,icon,soldierType,pos,trainTime);

            gameObject.AddComponent<CampOnClick>().Camp = camp;

            mSoldierCampDIc.Add(soldierType, camp);

        }

        public void InitCampCaptive(EnemyType enemyType) {
            GameObject gameObject = null;
            string gameObjectName = null;
            string name = null;
            string icon = null;
            Vector3 pos = Vector3.zero;
            float trainTime = 0;
            switch (enemyType)
            {
                case EnemyType.Elf:
                    gameObjectName = "CaptiveCamp_Elf";
                    name = "俘兵兵营";
                    icon = "CaptiveCamp";
                    trainTime = 3;
                    break;
                
                default:

                    Debug.LogError(GetType() + "/InitCamp()/Init Failed.The enemyType is not Contained: " + enemyType.ToString());
                    break;
            }

            gameObject = GameObject.Find(gameObjectName);
            pos = UnityTool.FindChild(gameObject, "TrainPoint").transform.position;
            CaptiveCamp camp = new CaptiveCamp(gameObject, name, icon, enemyType, pos, trainTime);

            gameObject.AddComponent<CampOnClick>().Camp = camp;

            mCaptiveCampDIc.Add(enemyType, camp);
        }

        public override void Update()
        {
            foreach (SoldierCamp camp in mSoldierCampDIc.Values)
            {
                camp.Update();
            }

            foreach (CaptiveCamp camp in mCaptiveCampDIc.Values)
            {
                camp.Update();
            }
        }
    }
}
