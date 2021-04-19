using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace DesignPattern_Sample_XAN
{ 

	public class GameStateInfoUI : IBaseGameUI
	{
        public List<GameObject> mHeartLst;
        public Text mSoldierAlive;
        public Text mEnemyAlive;
        public Text mStageCount;
        public Button mPauseBtn;
        public Slider mEnergySlider;
        public Text mEnergyCount;
        public Button mBackMenuButton;
        public Text mMessage;
        public GameObject mGameOver;

        private float mMsgShowTime = 2;
        private float mMsgShowTimer = 0;

        private AliveCountVisitor mAliveCountVisitor = new AliveCountVisitor();

        public override void Init()
        {
            base.Init();
            GameObject canvas = GameObject.Find("Canvas");
            mRootUI = UnityTool.FindChild(canvas, "GameStateUI");

            GameObject Heart1 = UnityTool.FindChild(mRootUI, "Heart1");
            GameObject Heart2 = UnityTool.FindChild(mRootUI, "Heart2");
            GameObject Heart3 = UnityTool.FindChild(mRootUI, "Heart3");
            mHeartLst = new List<GameObject>();
            mHeartLst.Add(Heart1);
            mHeartLst.Add(Heart2);
            mHeartLst.Add(Heart3);

            mSoldierAlive = UITool.FindChild<Text>(mRootUI, "SoldierAlive");
            mEnemyAlive = UITool.FindChild<Text>(mRootUI, "EnemyAlive");
            mStageCount = UITool.FindChild<Text>(mRootUI, "StageCount");
            mPauseBtn = UITool.FindChild<Button>(mRootUI, "PauseBtn");
            mEnergySlider = UITool.FindChild<Slider>(mRootUI, "EnergySlider");
            mEnergyCount = UITool.FindChild<Text>(mRootUI, "EnergyCount");
            mBackMenuButton = UITool.FindChild<Button>(mRootUI, "BackMenuButton");
            mMessage = UITool.FindChild<Text>(mRootUI, "Message");
            mGameOver = UnityTool.FindChild(mRootUI, "GameOver");

            mMessage.text = "";
            mGameOver.SetActive(false);
            

        }

        public override void Update()
        {
            base.Update();
            UpdateAliveCount();

            if (mMsgShowTimer>0)
            {
                mMsgShowTimer -= Time.deltaTime;
                if (mMsgShowTimer<=0)
                {
                    mMessage.text = "";
                }
            }
        }

        public void ShowMsg(string msg) {
            mMessage.text = msg;
            mMsgShowTimer = mMsgShowTime;
        }

        public void UpdateEnergySliderTextInfo(int nowEnergy, int maxEnergy) {
            mEnergySlider.value = (float)nowEnergy / maxEnergy;
            mEnergyCount.text = "(" + nowEnergy+"/"+ maxEnergy + ")";
        }

        private void UpdateAliveCount() {
            mAliveCountVisitor.Reset();

            PlayGameFacade.RunVisitor(mAliveCountVisitor);
            mSoldierAlive.text = mAliveCountVisitor.soldierCount.ToString();
            mEnemyAlive.text = mAliveCountVisitor.enemyCount.ToString();
        }
    }
}
